using Library;
using Server.DBModels;
using Server.Envir;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【抗拒火环】- 周围推开技能
    /// 
    /// 效果：将周围8个方向的敌人推开，推开距离基于技能等级。
    ///       成功率与等级差和魔法等级相关。
    /// 元素属性：无 (Element.None)
    /// 特性：UpdateCombatTime = false
    /// 
    /// 实现机制：
    /// - MagicCast: 对8个方向(Up~UpLeft)各创建一个 DelayedAction
    /// - MagicComplete: 检查目标等级必须低于玩家
    ///   成功率 = Random(16) < 6+Level*3+PlayerLevel-TargetLevel
    ///   调用 ob.Pushed(direction, GetPower()) 推开目标
    /// </summary>
    [MagicType(MagicType.Repulsion)]
    public class Repulsion : MagicObject
    {
        protected override Element Element => Element.None;
        public override bool UpdateCombatTime => false;

        public Repulsion(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }

        public override MagicCast MagicCast(MapObject target, Point location, MirDirection direction)
        {
            var response = new MagicCast
            {
                Ob = null
            };

            var delay = SEnvir.Now.AddMilliseconds(500);

            for (MirDirection d = MirDirection.Up; d <= MirDirection.UpLeft; d++)
            {
                var cell = CurrentMap.GetCell(Functions.Move(CurrentLocation, d));
                ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, cell, d));
            }

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            Cell cell = (Cell)data[1];
            var direction = (MirDirection)data[2];

            if (cell?.Objects == null) return;

            for (int i = cell.Objects.Count - 1; i >= 0; i--)
            {
                MapObject ob = cell.Objects[i];
                if (!Player.CanAttackTarget(ob) || ob.Level >= Player.Level || SEnvir.Random.Next(16) >= 6 + Magic.Level * 3 + Player.Level - ob.Level) continue;

                //CanPush check ?

                if (ob.Pushed(direction, Magic.GetPower()) <= 0) continue;

                Player.LevelMagic(Magic);
                break;
            }
        }
    }
}
