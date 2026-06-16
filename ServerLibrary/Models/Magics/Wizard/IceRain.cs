using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【高级凝血离魂】(AdvancedRenounce) - 冰系大范围AOE攻击技能
    /// 
    /// 效果：在目标位置7x7范围内随机降下多波冰雨（Level+1波），
    ///       每波随机命中约30%的格子，对命中格造成冰系伤害。
    /// 元素属性：冰 (Element.Ice)
    /// 
    /// 实现机制：
    /// - MagicCast: GetCells(location, 0, 3, true) 获取7x7范围
    ///   循环 Level+1 次（波数），每波对每个格子 20% 概率命中
    ///   延迟递增：500 + 10*48 + index*200 ms，实现错落效果
    /// - MagicComplete: 逐格伤害判定（TODO注释提到未实现冰冻毒效果）
    /// </summary>
    [MagicType(MagicType.AdvancedRenounce)]
    public class IceRain : MagicObject
    {
        protected override Element Element => Element.Ice;

        public IceRain(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }

        public override MagicCast MagicCast(MapObject target, Point location, MirDirection direction)
        {
            var response = new MagicCast
            {
                Ob = null
            };

            if (!Functions.InRange(Player.CurrentLocation, location, Globals.MagicRange))
            {
                response.Cast = false;
                return response;
            }

            var cells = CurrentMap.GetCells(location, 0, 3, true);

            int delayIndex = 0;

            for (int i = 0; i < Magic.Level + 1; i++)
            {
                foreach (Cell cell in cells)
                {
                    if (SEnvir.Random.Next(10) > 2) continue;

                    var delay = SEnvir.Now.AddMilliseconds(500 + (10 * 48) + (delayIndex++ * 200));

                    response.Locations.Add(cell.Location);

                    ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, cell));
                }
            }

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            Cell cell = (Cell)data[1];

            if (cell?.Objects == null) return;

            for (int i = cell.Objects.Count - 1; i >= 0; i--)
            {
                if (i >= cell.Objects.Count) continue;
                MapObject ob = cell.Objects[i];
                if (!Player.CanAttackTarget(ob)) continue;

                //TODO - Chance of freezing poison

                Player.MagicAttack(new List<MagicType> { Type }, ob, true, null);
            }
        }

        public override int ModifyPowerAdditionner(bool primary, int power, MapObject ob, Stats stats = null, int extra = 0)
        {
            power += Magic.GetPower() + Player.GetMC();

            return power;
        }
    }
}
