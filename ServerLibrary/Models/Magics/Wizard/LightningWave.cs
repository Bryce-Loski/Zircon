using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【雷电波】- 雷系范围AOE攻击技能
    /// 
    /// 效果：在指定位置释放雷电波，对3x3范围内所有敌人造成雷系伤害。
    /// 元素属性：雷 (Element.Lightning)
    /// 
    /// 实现机制：
    /// - 标准地面AOE模板，GetCells(location, 0, 1) 获取3x3区域
    /// - 500ms延迟后逐格伤害判定
    /// - 联动 FuryBlast 麻痹强化
    /// </summary>
    [MagicType(MagicType.LightningWave)]
    public class LightningWave : MagicObject
    {
        protected override Element Element => Element.Lightning;

        public LightningWave(PlayerObject player, UserMagic magic) : base(player, magic)
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

            if (!Functions.InRange(CurrentLocation, location, Globals.MagicRange))
            {
                response.Cast = false;
                return response;
            }

            response.Locations.Add(location);

            var cells = CurrentMap.GetCells(location, 0, 1);

            var delay = SEnvir.Now.AddMilliseconds(500);

            foreach (Cell cell in cells)
            {
                ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, cell));
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
