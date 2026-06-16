using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【地狱火】- 火系线状AOE攻击技能
    /// 
    /// 效果：沿面向方向释放一条8格长、3格宽的火系伤害带。
    /// 元素属性：火 (Element.Fire)
    /// 
    /// 实现机制：
    /// - MagicCast: 沿方向循环1-8格，对每格及其两侧（垂直方向偏移±2或±1）
    ///   创建 DelayedAction，正前方800ms延迟
    ///   正交方向(上下左右)：向两侧各偏移2格
    ///   对角方向(右上等)：向两侧各偏移1格
    /// - MagicComplete: 逐格伤害判定，primary标记区分中心/侧翼
    /// - ModifyPowerMultiplier: 侧翼目标只受30%伤害
    /// - 联动 RetrogressionOfEnergy 灼烧强化
    /// </summary>
    [MagicType(MagicType.ScortchedEarth)]
    public class ScortchedEarth : MagicObject
    {
        protected override Element Element => Element.Fire;

        public ScortchedEarth(PlayerObject player, UserMagic magic) : base(player, magic)
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

            for (int i = 1; i <= 8; i++)
            {
                location = Functions.Move(CurrentLocation, direction, i);
                Cell cell = CurrentMap.GetCell(location);

                if (cell == null) continue;
                response.Locations.Add(cell.Location);

                var delay = SEnvir.Now.AddMilliseconds(800);

                ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, cell, true));

                switch (direction)
                {
                    case MirDirection.Up:
                    case MirDirection.Right:
                    case MirDirection.Down:
                    case MirDirection.Left:
                        ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(location, Functions.ShiftDirection(direction, -2))), false));
                        ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(location, Functions.ShiftDirection(direction, 2))), false));
                        break;
                    case MirDirection.UpRight:
                    case MirDirection.DownRight:
                    case MirDirection.DownLeft:
                    case MirDirection.UpLeft:
                        ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(location, Functions.ShiftDirection(direction, 1))), false));
                        ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(location, Functions.ShiftDirection(direction, -1))), false));
                        break;
                }
            }

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            Cell cell = (Cell)data[1];
            bool primary = (bool)data[2];

            if (cell?.Objects == null) return;

            var burning = GetAugmentedSkill(MagicType.RetrogressionOfEnergy);

            for (int i = cell.Objects.Count - 1; i >= 0; i--)
            {
                if (i >= cell.Objects.Count) continue;
                MapObject ob = cell.Objects[i];
                if (!Player.CanAttackTarget(ob)) continue;

                var damage = Player.MagicAttack(new List<MagicType> { Type }, ob, primary);

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

        public override int ModifyPowerMultiplier(bool primary, int power, Stats stats = null, int extra = 0)
        {
            if (!primary)
                power = (int)(power * 0.3F);

            return power;
        }
    }
}
