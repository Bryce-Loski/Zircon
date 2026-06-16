using Library;
using Server.DBModels;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【火球术】- 法师初级火系单体攻击技能
    /// 
    /// 效果：向目标发射一颗火球，造成火系魔法伤害。
    /// 元素属性：火 (Element.Fire)
    /// 
    /// 实现机制：
    /// - MagicCast: 单体远程攻击，延迟 = 距离 * 500ms（飞行时间）
    /// - MagicComplete: 调用 Player.MagicAttack 计算伤害
    /// - 伤害公式: Magic.GetPower() + Player.GetMC()（魔法力加成）
    /// - 联动增强: 若学会 RetrogressionOfEnergy（能量回归/灼烧强化），
    ///   命中时触发灼烧效果（GetBurn/GetBurnLevel），并为强化技能增加经验
    /// </summary>
    [MagicType(MagicType.FireBall)]
    public class FireBall : MagicObject
    {
        protected override Element Element => Element.Fire;

        public FireBall(PlayerObject player, UserMagic magic) : base(player, magic)
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
                Ob = target
            };

            if (!Player.CanAttackTarget(target))
            {
                response.Ob = null;
                response.Locations.Add(location);
                return response;
            }

            response.Targets.Add(target.ObjectID);

            var delay = GetDelayFromDistance(500, target);

            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, target));

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
