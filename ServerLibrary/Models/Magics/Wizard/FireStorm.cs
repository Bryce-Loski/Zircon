using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【爆裂火焰】- 火系范围AOE攻击技能
    /// 
    /// 效果：在指定位置召唤火风暴，对3x3范围内所有敌人造成火系伤害。
    /// 元素属性：火 (Element.Fire)
    /// 
    /// 实现机制：
    /// - MagicCast: 地面指向性技能，GetCells(location, 0, 1) 获取3x3区域格子
    ///   每个格子创建独立的 DelayedAction（500ms延迟）
    /// - MagicComplete: 逐格处理，遍历格子上的所有对象进行伤害判定
    /// - 联动 RetrogressionOfEnergy 灼烧强化
    /// - 伤害公式: Magic.GetPower() + Player.GetMC()
    /// </summary>
    [MagicType(MagicType.FireStorm)]
    public class FireStorm : MagicObject
    {
        protected override Element Element => Element.Fire;

        public FireStorm(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }

        public override int GetBurn(int burn, Stats stats = null)
        {
            var burning = GetAugmentedSkill(MagicType.RetrogressionOfEnergy);

            if (burning != null)
            {
                return burning.GetPower();
            }

            return base.GetBurn(burn, stats);
        }

        public override int GetBurnLevel(int burnLevel, Stats stats = null)
        {
            var burning = GetAugmentedSkill(MagicType.RetrogressionOfEnergy);

            if (burning != null)
            {
                return burning.Level + 1;
            }

            return base.GetBurnLevel(burnLevel, stats);
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
                ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, cell));

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            Cell cell = (Cell)data[1];

            if (cell?.Objects == null) return;

            var burning = GetAugmentedSkill(MagicType.RetrogressionOfEnergy);

            for (int i = cell.Objects.Count - 1; i >= 0; i--)
            {
                if (i >= cell.Objects.Count) continue;
                MapObject ob = cell.Objects[i];
                if (!Player.CanAttackTarget(ob)) continue;

                var damage = Player.MagicAttack(new List<MagicType> { Type }, ob);

                if (damage > 0)
                {
                    if (burning != null)
                    {
                        Player.LevelMagic(burning);
                    }
                }
            }
        }

        public override int ModifyPowerAdditionner(bool primary, int power, MapObject ob, Stats stats = null, int extra = 0)
        {
            power += Magic.GetPower() + Player.GetMC();

            return power;
        }
    }
}
