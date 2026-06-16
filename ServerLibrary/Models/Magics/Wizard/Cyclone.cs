using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【击风】- 风系单体攻击技能
    /// 
    /// 效果：召唤旋风吹向目标，造成风系伤害并击退目标5格。
    /// 元素属性：风 (Element.Wind)
    /// 击退参数：Repel=5（击退5格）
    /// 
    /// 实现机制：
    /// - 标准单体远程攻击模板，600ms固定延迟
    /// - 击退效果通过基类的 Repel 属性自动触发
    /// - 伤害公式: Magic.GetPower() + Player.GetMC()
    /// </summary>
    [MagicType(MagicType.Cyclone)]
    public class Cyclone : MagicObject
    {
        protected override Element Element => Element.Wind;
        protected override int Repel => 5;

        public Cyclone(PlayerObject player, UserMagic magic) : base(player, magic)
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

            var delay = SEnvir.Now.AddMilliseconds(600);

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
