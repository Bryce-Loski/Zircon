using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【雷球术】- 雷系单体攻击技能
    /// 
    /// 效果：向目标发射雷球，造成雷系伤害并有概率附加麻痹效果。
    /// 元素属性：雷 (Element.Lightning)
    /// 
    /// 实现机制：
    /// - 标准单体远程攻击模板
    /// - GetShock: 检查是否学会 FuryBlast（天怒/麻痹强化），
    ///   若学会且随机判定通过(Random(MagicMaxLevel) <= Level)，附加麻痹效果
    /// - 伤害公式: Magic.GetPower() + Player.GetMC()
    /// </summary>
    [MagicType(MagicType.LightningBall)]
    public class LightningBall : MagicObject
    {
        protected override Element Element => Element.Lightning;

        public LightningBall(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }

        public override int GetShock(int shock, Stats stats = null)
        {
            var shocked = GetAugmentedSkill(MagicType.FuryBlast);

            if (shocked != null && SEnvir.Random.Next(Globals.MagicMaxLevel) <= shocked.Level)
            {
                return shocked.GetPower();
            }

            return base.GetShock(shock, stats);
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

            Player.MagicAttack(new List<MagicType> { Type }, target);
        }

        public override int ModifyPowerAdditionner(bool primary, int power, MapObject ob, Stats stats = null, int extra = 0)
        {
            power += Magic.GetPower() + Player.GetMC();

            return power;
        }
    }
}
