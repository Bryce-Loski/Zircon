using Library;
using Library.Network;
using Server.Envir;
using System;
using System.Collections.Generic;
using System.Drawing;
using S = Library.Network.ServerPackets;

namespace Server.Models.Monsters
{
    public class FireBird : MonsterObject
    {
        public int AttackRange = 10;

        protected override bool InAttackRange()
        {
            return Target.CurrentMap == CurrentMap
                && Target.CurrentLocation != CurrentLocation
                && Functions.InRange(CurrentLocation, Target.CurrentLocation, AttackRange);
        }

        public override void ProcessTarget()
        {
            if (Target == null) return;

            if (InAttackRange() && CanAttack)
            {
                Attack();
            }
            else if (CurrentLocation == Target.CurrentLocation)
            {
                MirDirection mirDirection = (MirDirection)SEnvir.Random.Next(8);
                int i = SEnvir.Random.Next(2) == 0 ? 1 : -1;
                for (int index = 0; index < 8 && !Walk(mirDirection); ++index)
                    mirDirection = Functions.ShiftDirection(mirDirection, i);
            }
            else
            {
                if (Functions.InRange(CurrentLocation, Target.CurrentLocation, 2)) return;
                MoveTo(Target.CurrentLocation);
            }
        }

        public override void ProcessAction(DelayedAction action)
        {
            if (action.Type == ActionType.RangeAttack)
                ScorchedEarth((MirDirection)action.Data[0]);
            else
                base.ProcessAction(action);
        }

        protected override void Attack()
        {
            Direction = Functions.DirectionFromPoint(CurrentLocation, Target.CurrentLocation);
            UpdateAttackTime();

            if (SEnvir.Random.Next(6) == 0 || !Functions.InRange(Target.CurrentLocation, CurrentLocation, 2))
            {
                RangeAttack();
            }
            else
            {
                Broadcast(new S.ObjectAttack
                {
                    ObjectID = ObjectID,
                    Direction = Direction,
                    Location = CurrentLocation
                });

                foreach (MapObject target in GetTargets(CurrentMap, Functions.Move(CurrentLocation, Direction, 2), 1))
                {
                    ActionList.Add(new DelayedAction(
                        SEnvir.Now.AddMilliseconds(400),
                        ActionType.DelayAttack,
                        target,
                        GetDC(),
                        AttackElement));
                }
            }
        }

        private void RangeAttack()
        {
            if (SEnvir.Random.Next(2) == 0)
            {
                MassCycloneCustom(MagicType.IgyuCyclone, 45);
            }
            else
            {
                foreach (MirDirection mirDirection in Enum.GetValues(typeof(MirDirection)))
                {
                    ActionList.Add(new DelayedAction(
                        SEnvir.Now.AddMilliseconds(500 + 500 * (int)mirDirection),
                        ActionType.RangeAttack,
                        mirDirection));
                }
            }
        }

        private void ScorchedEarth(MirDirection direction)
        {
            if (Dead) return;
            UpdateAttackTime();
            LineAoEDirectional(10, 0, 0, MagicType.IgyuScorchedEarth, Element.Fire, direction);
        }

        // 焦土：以指定方向施放线性 AoE。
        // 基类的 LineAoE 不接收方向参数（自动指向目标），FireBird 需要指定方向，
        // 因此在此实现一个带方向参数的私有版本。
        private void LineAoEDirectional(int distance, int min, int max, MagicType magic, Element element, MirDirection dir)
        {
            List<uint> targetIDs = new List<uint>();
            List<Point> locations = new List<Point>();

            Broadcast(new S.ObjectMagic
            {
                ObjectID = ObjectID,
                Direction = dir,
                CurrentLocation = CurrentLocation,
                Cast = true,
                Type = magic,
                Targets = targetIDs,
                Locations = locations
            });

            UpdateAttackTime();

            for (int i = min; i <= max; ++i)
            {
                MirDirection mirDirection = Functions.ShiftDirection(dir, i);

                for (int distance1 = 1; distance1 <= distance; ++distance1)
                {
                    Point location = Functions.Move(CurrentLocation, mirDirection, distance1);
                    Cell cell = CurrentMap.GetCell(location);
                    if (cell == null) continue;

                    locations.Add(cell.Location);

                    if (cell.Objects != null)
                    {
                        foreach (MapObject ob in cell.Objects)
                        {
                            if (CanAttackTarget(ob))
                            {
                                ActionList.Add(new DelayedAction(
                                    SEnvir.Now.AddMilliseconds(500 + distance1 * 75),
                                    ActionType.DelayAttack,
                                    ob,
                                    GetMC(),
                                    element));
                            }
                        }
                    }

                    switch (mirDirection)
                    {
                        case MirDirection.Up:
                        case MirDirection.Right:
                        case MirDirection.Down:
                        case MirDirection.Left:
                            ApplyAoEToCell(Functions.Move(location, Functions.ShiftDirection(mirDirection, -2)), distance1, locations, element);
                            ApplyAoEToCell(Functions.Move(location, Functions.ShiftDirection(mirDirection, 2)), distance1, locations, element);
                            break;
                        case MirDirection.UpRight:
                        case MirDirection.DownRight:
                        case MirDirection.DownLeft:
                        case MirDirection.UpLeft:
                            ApplyAoEToCell(Functions.Move(location, Functions.ShiftDirection(mirDirection, -1)), distance1, locations, element);
                            ApplyAoEToCell(Functions.Move(location, Functions.ShiftDirection(mirDirection, 1)), distance1, locations, element);
                            break;
                    }
                }
            }
        }

        private void ApplyAoEToCell(Point point, int distance1, List<Point> locations, Element element)
        {
            Cell cell = CurrentMap.GetCell(point);
            if (cell == null) return;

            locations.Add(cell.Location);

            if (cell.Objects == null) return;

            foreach (MapObject ob in cell.Objects)
            {
                if (!CanAttackTarget(ob)) continue;

                ActionList.Add(new DelayedAction(
                    SEnvir.Now.AddMilliseconds(500 + distance1 * 75),
                    ActionType.DelayAttack,
                    ob,
                    GetMC(),
                    element));
            }
        }

        // MassCycloneCustom：基类 MassCyclone() 无参数，固定使用 MagicType.Cyclone 与 Config.MaxViewRange。
        // FireBird 需要指定法术类型与范围，此处复刻其逻辑。
        private void MassCycloneCustom(MagicType magic, int range)
        {
            Direction = Functions.DirectionFromPoint(CurrentLocation, Target.CurrentLocation);

            List<uint> targetIDs = new List<uint>();
            List<Point> locations = new List<Point>();

            Broadcast(new S.ObjectMagic
            {
                ObjectID = ObjectID,
                Direction = Direction,
                CurrentLocation = CurrentLocation,
                Cast = true,
                Type = magic,
                Targets = targetIDs,
                Locations = locations
            });

            UpdateAttackTime();

            List<Cell> cells = CurrentMap.GetCells(CurrentLocation, 0, range);
            foreach (Cell cell in cells)
            {
                if (cell.Objects == null)
                {
                    if (SEnvir.Random.Next(30) == 0)
                        locations.Add(cell.Location);
                    continue;
                }

                foreach (MapObject ob in cell.Objects)
                {
                    if (SEnvir.Random.Next(4) == 0) continue;
                    if (!CanAttackTarget(ob)) continue;

                    targetIDs.Add(ob.ObjectID);

                    ActionList.Add(new DelayedAction(
                        SEnvir.Now.AddMilliseconds(500),
                        ActionType.DelayAttack,
                        ob,
                        GetDC(),
                        Element.Wind));
                }
            }
        }

    }
}
