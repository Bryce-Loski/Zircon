using Library;
using Server.DBModels;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【冰月神掌】- 冰系单体攻击技能
    /// 
    /// 效果：向目标发射冰箭，造成冰系伤害并附带减速效果。
    /// 元素属性：冰 (Element.Ice)
    /// 减速参数：Slow=10（减速值），SlowLevel=3（减速等级）
    /// 
    /// 实现机制：
    /// - 标准单体远程攻击模板：目标选取 → 飞行延迟 → 伤害判定
    /// - 减速效果通过基类的 Slow/SlowLevel 属性自动在命中时触发
    /// - 伤害公式: Magic.GetPower() + Player.GetMC()
    /// </summary>
    [MagicType(MagicType.IceBolt)]
    public class IceBolt : MagicObject
    {
        protected override Element Element => Element.Ice;
        protected override int Slow => 10;
        protected override int SlowLevel => 3;

        public IceBolt(PlayerObject player, UserMagic magic) : base(player, magic)
        {

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
