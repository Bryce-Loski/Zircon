using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics.Wizard
{
    /// <summary>
    /// 【寒冰破碎】- 冰系自身周围AOE攻击技能（自定义技能）
    /// 
    /// 效果：以自身为中心5x5范围内爆发冰系伤害，附带减速效果。
    /// 元素属性：冰 (Element.Ice)
    /// 减速参数：Slow=5，SlowLevel=5
    /// 
    /// 实现机制：
    /// - MagicCast: GetCells(CurrentLocation, 0, 2) 获取5x5范围格子
    ///   延迟按距离递增：500 + 500*distance ms，实现由近及远的扩散效果
    /// - MagicComplete: 逐格伤害判定
    /// </summary>
    [MagicType(MagicType.IceBreaker)]
    public class IceBreaker : MagicObject
    {
        protected override Element Element => Element.Ice;
        protected override int Slow => 5;
        protected override int SlowLevel => 5;

        public IceBreaker(PlayerObject player, UserMagic magic) : base(player, magic)
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

            foreach (Cell cell in cells)
            {
                var distance = Functions.Distance(Player.CurrentLocation, cell.Location);

                var delay = SEnvir.Now.AddMilliseconds(500 + (500 * distance));

                Player.ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, cell));
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
