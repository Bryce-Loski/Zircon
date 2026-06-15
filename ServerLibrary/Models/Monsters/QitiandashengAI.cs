using Library;
using Library.Network;
using Server.Envir;
using System;
using System.Collections.Generic;
using System.Drawing;
using S = Library.Network.ServerPackets;

namespace Server.Models.Monsters
{
    public class QitiandashengAI : SpittingSpider
    {
        public DateTime CastTime;
        public TimeSpan CastDelay = TimeSpan.FromSeconds(15.0);

        protected override bool InAttackRange()
        {
            if (Target.CurrentMap != CurrentMap || Target.CurrentLocation == CurrentLocation)
                return false;

            int dx = Math.Abs(Target.CurrentLocation.X - CurrentLocation.X);
            int dy = Math.Abs(Target.CurrentLocation.Y - CurrentLocation.Y);

            return dx <= 3 && dy <= 3 && (dx == 0 || dx == dy || dy == 0);
        }

        public override void ProcessTarget()
        {
            if (Target == null) return;

            if (CanAttack && SEnvir.Now > CastTime)
            {
                List<MapObject> targets = GetTargets(CurrentMap, CurrentLocation, ViewRange);
                if (targets.Count > 0)
                {
                    foreach (MapObject mapObject in targets)
                    {
                        if (CurrentHP <= Stats[Stat.Health] / 2 || SEnvir.Random.Next(2) <= 0)
                            QierBian(mapObject.CurrentLocation);
                    }

                    UpdateAttackTime();

                    Broadcast(new S.ObjectMagic
                    {
                        ObjectID = ObjectID,
                        Direction = Direction,
                        CurrentLocation = CurrentLocation,
                        Cast = true,
                        Type = MagicType.None,
                        Targets = new List<uint> { Target.ObjectID }
                    });

                    CastTime = SEnvir.Now + CastDelay;
                }
            }

            if (!InAttackRange())
            {
                if (CurrentLocation == Target.CurrentLocation)
                {
                    MirDirection mirDirection = (MirDirection)SEnvir.Random.Next(8);
                    int i = SEnvir.Random.Next(2) == 0 ? 1 : -1;
                    for (int index = 0; index < 8 && !Walk(mirDirection); ++index)
                        mirDirection = Functions.ShiftDirection(mirDirection, i);
                }
                else
                {
                    MoveTo(Target.CurrentLocation);
                }
            }
            else
            {
                if (!CanAttack) return;
                Attack();
            }
        }

        protected override void Attack()
        {
            Direction = Functions.DirectionFromPoint(CurrentLocation, Target.CurrentLocation);

            if (SEnvir.Random.Next(3) == 0 || !Functions.InRange(Target.CurrentLocation, CurrentLocation, 2))
            {
                Broadcast(new S.ObjectRangeAttack
                {
                    ObjectID = ObjectID,
                    Direction = Direction,
                    Location = CurrentLocation,
                    Targets = new List<uint>()
                });

                LineAttack(3);
            }
            else
            {
                Broadcast(new S.ObjectAttack
                {
                    ObjectID = ObjectID,
                    Direction = Direction,
                    Location = CurrentLocation
                });

                foreach (MapObject target in GetTargets(CurrentMap, Functions.Move(CurrentLocation, Direction), 1))
                {
                    ActionList.Add(new DelayedAction(
                        SEnvir.Now.AddMilliseconds(400),
                        ActionType.DelayAttack,
                        target,
                        GetDC(),
                        AttackElement));
                    break;
                }
            }

            UpdateAttackTime();
        }

        // 七十二变：在指定位置召唤一个同类型怪物分身
        private void QierBian(Point location)
        {
            if (MonsterInfo == null) return;

            MonsterObject mob = GetMonster(MonsterInfo);
            if (mob == null) return;

            mob.Spawn(CurrentMap, location);
        }
    }
}
