using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【雷电术】- 雷系单体攻击技能
    /// 
    /// 效果：召唤雷电劈向目标，造成雷系伤害并有概率附加麻痹。
    /// 元素属性：雷 (Element.Lightning)
    /// 
    /// 实现机制：
    /// - 与 LightningBall 结构相同，600ms固定延迟
    /// - 同样联动 FuryBlast 麻痹强化
    /// </summary>
    [MagicType(MagicType.ThunderBolt)]
    public class ThunderBolt : MagicObject
    {
        protected override Element Element => Element.Lightning;

        public ThunderBolt(PlayerObject player, UserMagic magic) : base(player, magic)
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
