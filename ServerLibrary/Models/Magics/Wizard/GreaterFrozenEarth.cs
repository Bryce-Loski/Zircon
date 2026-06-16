using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【强化冻土术】- 冻土术的升级版，三方向扇形AOE
    /// 
    /// 效果：沿面向方向及其左右各偏转一个方向（共3个方向），
    ///       各释放8格长的冰系伤害带，覆盖更大的扇形区域。
    /// 元素属性：冰 (Element.Ice)
    /// 减速参数：Slow=5，SlowLevel=5
    /// 
    /// 实现机制：
    /// - 在 FrozenEarth 基础上增加外层循环 for(d=-1;d<=1)，
    ///   对 ShiftDirection(direction, d) 三个方向分别释放
    /// - ModifyPowerMultiplier: 侧翼目标只受30%伤害
    /// </summary>
    [MagicType(MagicType.GreaterFrozenEarth)]
    public class GreaterFrozenEarth : MagicObject
    {
        protected override Element Element => Element.Ice;
        protected override int Slow => 5;
        protected override int SlowLevel => 5;

        public GreaterFrozenEarth(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }

        public override MagicCast MagicCast(MapObject target, Point location, MirDirection direction)
        {
            var response = new MagicCast
            {
                Ob = null
            };

            for (int d = -1; d <= 1; d++)
                for (int i = 1; i <= 8; i++)
                {
                    var dir = Functions.ShiftDirection(direction, d);

                    var loc = Functions.Move(CurrentLocation, dir, i);
                    Cell cell = CurrentMap.GetCell(loc);

                    if (cell == null) continue;
                    response.Locations.Add(cell.Location);

                    var delay = SEnvir.Now.AddMilliseconds(800);

                    ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, cell, true));

                    switch (dir)
                    {
                        case MirDirection.Up:
                        case MirDirection.Right:
                        case MirDirection.Down:
                        case MirDirection.Left:
                            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(loc, Functions.ShiftDirection(dir, -2))), false));
                            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(loc, Functions.ShiftDirection(dir, 2))), false));
                            break;
                        case MirDirection.UpRight:
                        case MirDirection.DownRight:
                        case MirDirection.DownLeft:
                        case MirDirection.UpLeft:
                            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(loc, Functions.ShiftDirection(dir, 1))), false));
                            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(loc, Functions.ShiftDirection(dir, -1))), false));
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

            for (int i = cell.Objects.Count - 1; i >= 0; i--)
            {
                if (i >= cell.Objects.Count) continue;
                MapObject ob = cell.Objects[i];
                if (!Player.CanAttackTarget(ob)) continue;

                Player.MagicAttack(new List<MagicType> { Type }, ob, primary);
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
