using Library;
using Library.SystemModels;
using Server.DBModels;
using Server.Envir;
using System;
using System.Collections.Generic;
using System.Linq;
using S = Library.Network.ServerPackets;

namespace Server.Models.Monsters
{
    public class BlueBlossom : MonsterObject
    {
        protected override bool InAttackRange()
        {
            return Target.CurrentMap == CurrentMap
                && Target.CurrentLocation != CurrentLocation
                && Functions.InRange(CurrentLocation, Target.CurrentLocation, 8);
        }

        public override bool ShouldAttackTarget(MapObject ob) => CanAttackTarget(ob);

        public override bool CanAttackTarget(MapObject ob) => CanHelpTarget(ob);

        public override bool CanHelpTarget(MapObject ob)
        {
            return base.CanHelpTarget(ob)
                && ob.CurrentHP < ob.Stats[Stat.Health]
                && ob.Buffs.All(x => x.Type != BuffType.Heal);
        }

        public override void ProcessAction(DelayedAction action)
        {
            if (action.Type == ActionType.DelayAttack)
                Heal((MapObject)action.Data[0]);
            else
                base.ProcessAction(action);
        }

        public override void ProcessSearch() => ProperSearch();

        public void Heal(MapObject ob)
        {
            if (ob?.Node == null || ob.Dead) return;

            Stats stats = new Stats
            {
                [Stat.Healing] = Stats[Stat.Healing],
                [Stat.HealingCap] = Stats[Stat.HealingCap]
            };

            ob.BuffAdd(BuffType.Heal, TimeSpan.MaxValue, stats, false, false, TimeSpan.FromSeconds(1.0));
        }

        protected override void Attack()
        {
            Direction = Functions.DirectionFromPoint(CurrentLocation, Target.CurrentLocation);

            Broadcast(new S.ObjectRangeAttack
            {
                ObjectID = ObjectID,
                Direction = Direction,
                Location = CurrentLocation,
                Targets = new List<uint> { Target.ObjectID }
            });

            UpdateAttackTime();

            ActionList.Add(new DelayedAction(
                SEnvir.Now.AddMilliseconds(400 + Functions.Distance(CurrentLocation, Target.CurrentLocation) * 48),
                ActionType.DelayAttack,
                Target));
        }
    }
}
