using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【冰咆哮】- 冰系范围AOE攻击技能
    /// 
    /// 效果：在指定位置召唤冰风暴，对3x3范围内所有敌人造成冰系伤害并减速。
    /// 元素属性：冰 (Element.Ice)
    /// 减速参数：Slow=5，SlowLevel=5
    /// 
    /// 实现机制：
    /// - MagicCast: 地面指向性，GetCells(location, 0, 1) 获取3x3区域
    ///   500ms延迟后对所有格子创建 DelayedAction
    /// - MagicComplete: 逐格遍历对象进行伤害判定
    /// </summary>
    [MagicType(MagicType.IceStorm)]
    public class IceStorm : MagicObject
    {
        protected override Element Element => Element.Ice;
        protected override int Slow => 5;
        protected override int SlowLevel => 5;

        public IceStorm(PlayerObject player, UserMagic magic) : base(player, magic)
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

            response.Locations.Add(location);
            var cells = Player.CurrentMap.GetCells(location, 0, 1);

            var delay = SEnvir.Now.AddMilliseconds(500);

            foreach (Cell cell in cells)
                Player.ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, cell));

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
