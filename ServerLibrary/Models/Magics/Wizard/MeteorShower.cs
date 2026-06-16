using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【流星雨】- 火系多目标攻击技能
    /// 
    /// 效果：在目标区域召唤流星雨，随机攻击 6+Magic.Level 个目标。
    /// 元素属性：火 (Element.Fire)
    /// 
    /// 实现机制：
    /// - MagicCast: 获取目标位置3格内的所有可攻击目标，
    ///   随机选取最多 6+Level 个（不重复），每个目标独立创建 DelayedAction
    /// - MagicComplete: 对每个目标单独进行伤害判定
    /// - 联动 RetrogressionOfEnergy 灼烧强化
    /// - 伤害公式: Magic.GetPower() + Player.GetMC()
    /// </summary>
    [MagicType(MagicType.MeteorShower)]
    public class MeteorShower : MagicObject
    {
        protected override Element Element => Element.Fire;

        public MeteorShower(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }

        public override int GetBurn(int burn, Stats stats = null)
        {
            var burning = GetAugmentedSkill(MagicType.RetrogressionOfEnergy);

            if (burning != null)
            {
                return burning.GetPower();
            }

            return base.GetBurn(burn, stats);
        }

        public override int GetBurnLevel(int burnLevel, Stats stats = null)
        {
            var burning = GetAugmentedSkill(MagicType.RetrogressionOfEnergy);

            if (burning != null)
            {
                return burning.Level + 1;
            }

            return base.GetBurnLevel(burnLevel, stats);
        }

        public override MagicCast MagicCast(MapObject target, Point location, MirDirection direction)
        {
            var response = new MagicCast
            {
                Ob = null
            };

            var realTargets = new HashSet<MapObject>();
            var possibleTargets = Player.GetTargets(Player.CurrentMap, location, 3);

            while (realTargets.Count < 6 + Magic.Level)
            {
                if (possibleTargets.Count == 0) break;

                MapObject ob = possibleTargets[SEnvir.Random.Next(possibleTargets.Count)];

                possibleTargets.Remove(ob);

                if (!Functions.InRange(Player.CurrentLocation, ob.CurrentLocation, Globals.MagicRange)) continue;

                realTargets.Add(ob);
            }

            foreach (MapObject ob in realTargets)
            {
                var delay = GetDelayFromDistance(500, ob);

                response.Targets.Add(ob.ObjectID);
                ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, ob));
            }

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            MapObject target = (MapObject)data[1];

            var damage = Player.MagicAttack(new List<MagicType> { Type }, target);

            if (damage > 0)
            {
                var burning = GetAugmentedSkill(MagicType.RetrogressionOfEnergy);

                if (burning != null)
                {
                    Player.LevelMagic(burning);
                }
            }
        }

        public override int ModifyPowerAdditionner(bool primary, int power, MapObject ob, Stats stats = null, int extra = 0)
        {
            power += Magic.GetPower() + Player.GetMC();

            return power;
        }
    }
}
