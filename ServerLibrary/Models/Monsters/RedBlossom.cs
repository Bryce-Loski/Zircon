using Library;
using Server.Envir;
using System;
using System.Drawing;
using S = Library.Network.ServerPackets;

namespace Server.Models.Monsters
{
    public class RedBlossom : SpittingSpider
    {
        protected override bool InAttackRange()
        {
            return Target.CurrentMap == CurrentMap
                && Target.CurrentLocation != CurrentLocation
                && Functions.InRange(CurrentLocation, Target.CurrentLocation, 5);
        }

        public override void ProcessTarget()
        {
            if (Target == null) return;

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

                int dx = Math.Abs(Target.CurrentLocation.X - CurrentLocation.X);
                int dy = Math.Abs(Target.CurrentLocation.Y - CurrentLocation.Y);

                if (dx != 0 && dx != dy && dy != 0 && SEnvir.Random.Next(8) > 0)
                    MoveTo(Target.CurrentLocation);
                else
                    Attack();
            }
        }

        protected override void Attack()
        {
            Direction = Functions.DirectionFromPoint(CurrentLocation, Target.CurrentLocation);
            UpdateAttackTime();

            int dx = Math.Abs(Target.CurrentLocation.X - CurrentLocation.X);
            int dy = Math.Abs(Target.CurrentLocation.Y - CurrentLocation.Y);

            if (dx == 0 || dx == dy || dy == 0)
            {
                Broadcast(new S.ObjectAttack
                {
                    ObjectID = ObjectID,
                    Direction = Direction,
                    Location = CurrentLocation
                });

                LineAttack(5);
            }
            else
            {
                Broadcast(new S.ObjectRangeAttack
                {
                    ObjectID = ObjectID,
                    Direction = Direction,
                    Location = CurrentLocation
                });

                // 基类 SpittingSpider.LineAttack 仅取一个 distance 参数，
                // 内部使用 Direction 字段。此处针对每个方向临时切换 Direction，
                // 让 LineAttack 在该方向上施放，覆盖全 8 方向。
                MirDirection original = Direction;
                foreach (MirDirection direction in Enum.GetValues(typeof(MirDirection)))
                {
                    Direction = direction;
                    LineAttack(5);
                }
                Direction = original;
            }
        }
    }
}
