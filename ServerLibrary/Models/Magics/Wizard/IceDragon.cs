using Library;
using Server.DBModels;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics.Wizard
{
    /// <summary>
    /// 【冰龙术】- 冰系单体攻击技能（自定义技能）
    /// 
    /// 效果：召唤冰龙攻击目标，造成冰系伤害并附带轻微减速。
    /// 元素属性：冰 (Element.Ice)
    /// 减速参数：Slow=2，SlowLevel=3
    /// 
    /// 实现机制：
    /// - 标准单体远程攻击模板
    /// - 减速效果较弱（Slow=2），定位为高伤害单体技能
    /// </summary>
    [MagicType(MagicType.IceDragon)]
    public class IceDragon : MagicObject
    {
        protected override Element Element => Element.Ice;
        protected override int Slow => 2;
        protected override int SlowLevel => 3;

        public IceDragon(PlayerObject player, UserMagic magic) : base(player, magic)
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
