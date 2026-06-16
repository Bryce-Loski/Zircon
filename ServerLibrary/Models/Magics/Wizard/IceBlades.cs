using Library;
using Server.DBModels;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【冰月震天】- 冰系单体攻击技能
    /// 
    /// 效果：召唤冰刃刺向目标，造成冰系伤害并附带减速效果。
    /// 元素属性：冰 (Element.Ice)
    /// 减速参数：Slow=5，SlowLevel=5
    /// 
    /// 实现机制：
    /// - 与 IceBolt 结构相同的标准单体远程攻击
    /// - 减速参数不同（更高的减速等级但更低的减速值）
    /// </summary>
    [MagicType(MagicType.IceBlades)]
    public class IceBlades : MagicObject
    {
        protected override Element Element => Element.Ice;
        protected override int Slow => 5;
        protected override int SlowLevel => 5;

        public IceBlades(PlayerObject player, UserMagic magic) : base(player, magic)
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
