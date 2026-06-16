using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【大地吹息】- 风系线状AOE攻击技能
    /// 
    /// 效果：沿面向方向释放一条8格长、3格宽的风系伤害带，
    ///       附带强力击退效果（10格），侧翼伤害衰减至30%。
    /// 元素属性：风 (Element.Wind)
    /// 击退参数：Repel=10
    /// 
    /// 实现机制：
    /// - 线状AOE模板（与焦土术/冻土术相同结构）
    /// - 沿方向1-8格，正交偏移±2/对角偏移±1
    /// - ModifyPowerMultiplier: 侧翼目标只受30%伤害
    /// </summary>
    [MagicType(MagicType.BlowEarth)]
    public class BlowEarth : MagicObject
    {
        protected override Element Element => Element.Wind;
        protected override int Repel => 10;

        public BlowEarth(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }

        public override MagicCast MagicCast(MapObject target, Point location, MirDirection direction)
        {
            var response = new MagicCast
            {
                Ob = null
            };

            Point lastLocation;

            for (int i = 1; i <= 8; i++)
            {
                var loc = Functions.Move(CurrentLocation, direction, i);
                Cell cell = CurrentMap.GetCell(loc);

                if (cell == null) continue;
                response.Locations.Add(cell.Location);

                lastLocation = loc;

                var delay = SEnvir.Now.AddMilliseconds(800);

                ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, cell, true));

                switch (direction)
                {
                    case MirDirection.Up:
                    case MirDirection.Right:
                    case MirDirection.Down:
                    case MirDirection.Left:
                        ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(loc, Functions.ShiftDirection(direction, -2))), false));
                        ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(loc, Functions.ShiftDirection(direction, 2))), false));
                        break;
                    case MirDirection.UpRight:
                    case MirDirection.DownRight:
                    case MirDirection.DownLeft:
                    case MirDirection.UpLeft:
                        ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(loc, Functions.ShiftDirection(direction, 1))), false));
                        ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(loc, Functions.ShiftDirection(direction, -1))), false));
                        break;
                }

                if (lastLocation == CurrentLocation)
                    response.Cast = false;
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
