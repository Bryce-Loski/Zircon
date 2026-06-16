using Library;
using Server.DBModels;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【疾风冲击】- 风系单体攻击技能
    /// 
    /// 效果：向目标释放疾风冲击，造成风系伤害并强力击退10格。
    /// 元素属性：风 (Element.Wind)
    /// 击退参数：Repel=10（击退10格）
    /// 
    /// 实现机制：
    /// - 与 Cyclone 结构相同，但击退距离更远（10格 vs 5格）
    /// - 延迟基于距离计算 GetDelayFromDistance(500, target)
    /// </summary>
    [MagicType(MagicType.GustBlast)]
    public class GustBlast : MagicObject
    {
        protected override Element Element => Element.Wind;

        protected override int Repel => 10;

        public GustBlast(PlayerObject player, UserMagic magic) : base(player, magic)
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
