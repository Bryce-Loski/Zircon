using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【雷暴术】- 雷系自身周围AOE攻击技能
    /// 
    /// 效果：以自身为中心释放雷暴，对范围内随机目标造成雷系伤害。
    ///       Level<=3时范围3格(7x7)，Level>3时范围6格(13x13)。
    /// 元素属性：雷 (Element.Lightning)
    /// 
    /// 实现机制：
    /// - MagicCast: 根据等级决定范围(3或6)
    ///   GetCells(CurrentLocation, 0, range) 获取范围内格子
    ///   对每个格子的对象50%概率选中攻击，空格子1/40概率显示视觉特效
    /// - ModifyPowerAdditionner: 额外增加50%伤害（power += power/2）
    /// - 联动 FuryBlast 麻痹强化
    /// </summary>
    [MagicType(MagicType.ThunderStrike)]
    public class ThunderStrike : MagicObject
    {
        protected override Element Element => Element.Lightning;

        public ThunderStrike(PlayerObject player, UserMagic magic) : base(player, magic)
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
                Ob = null
            };

            int range = 3;

            if (Magic.Level > 3)
            {
                range = 6;
            }

            var cells = CurrentMap.GetCells(CurrentLocation, 0, range);

            var delay = SEnvir.Now.AddMilliseconds(500);

            foreach (Cell cell in cells)
            {
                if (cell.Objects == null)
                {
                    if (SEnvir.Random.Next(40) == 0)
                        response.Locations.Add(cell.Location);

                    continue;
                }

                foreach (MapObject ob in cell.Objects)
                {
                    if (SEnvir.Random.Next(2) > 0) continue;
                    if (!Player.CanAttackTarget(ob)) continue;

                    response.Targets.Add(ob.ObjectID);

                    ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, ob));
                }
            }

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
            power += power / 2;

            return power;
        }
    }
}
