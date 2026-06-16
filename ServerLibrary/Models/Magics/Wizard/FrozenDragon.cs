using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics.Wizard
{
    /// <summary>
    /// 【冻龙术】- 冰系自身周围大范围AOE技能（自定义技能）
    /// 
    /// 效果：以自身为中心5x5范围内召唤冻龙攻击，造成冰系伤害并减速。
    ///       分两波攻击（i=1,2），延迟递增实现波浪扩散效果。
    /// 元素属性：冰 (Element.Ice)
    /// 减速参数：Slow=2，SlowLevel=5
    /// 
    /// 实现机制：
    /// - MagicCast: GetCells(CurrentLocation, 0, 2) 获取5x5范围
    ///   双层循环：外层 i=1~2（两波），内层遍历所有格子
    ///   延迟 = 500 + 500*distance*i ms，第二波延迟翻倍
    /// - MagicComplete: 逐格伤害判定
    /// </summary>
    [MagicType(MagicType.FrozenDragon)]
    public class FrozenDragon : MagicObject
    {
        protected override Element Element => Element.Ice;
        protected override int Slow => 2;
        protected override int SlowLevel => 5;

        public FrozenDragon(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }

        public override MagicCast MagicCast(MapObject target, Point location, MirDirection direction)
        {
            var response = new MagicCast
            {
                Ob = null
            };

            response.Locations.Add(Player.CurrentLocation);

            var cells = CurrentMap.GetCells(Player.CurrentLocation, 0, 2);

            for (int i = 1; i <= 2; i++)
            {
                foreach (Cell cell in cells)
                {
                    var distance = Functions.Distance(Player.CurrentLocation, cell.Location);

                    var delay = SEnvir.Now.AddMilliseconds(500 + (500 * distance * i));

                    Player.ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, cell));
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

                Player.MagicAttack(new List<MagicType> { Type }, ob);
            }
        }

        public override int ModifyPowerAdditionner(bool primary, int power, MapObject ob, Stats stats = null, int extra = 0)
        {
            power += Magic.GetPower() + Player.GetMC();

            return power;
        }
    }
}
