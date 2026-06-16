using Library;
using Server.DBModels;
using Server.Envir;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【瞬间移动】- 随机传送技能
    /// 
    /// 效果：随机传送到当前地图的任意位置。
    ///       成功率 = (2+Level*2) / (MagicMaxLevel+5)。
    ///       某些地图禁止使用（SkillDelay>0）。
    /// 元素属性：无 (Element.None)
    /// 特性：UpdateCombatTime = false
    /// 
    /// 实现机制：
    /// - MagicComplete: 
    ///   检查地图是否允许使用（Info.SkillDelay）
    ///   成功率判定后调用 Player.Teleport(CurrentMap, GetRandomLocation())
    /// </summary>
    [MagicType(MagicType.Teleportation)]
    public class Teleportation : MagicObject
    {
        protected override Element Element => Element.None;
        public override bool UpdateCombatTime => false;

        public Teleportation(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }

        public override MagicCast MagicCast(MapObject target, Point location, MirDirection direction)
        {
            var response = new MagicCast
            {
                Ob = null
            };

            var delay = SEnvir.Now.AddMilliseconds(500);

            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type));

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            if (CurrentMap.Info.SkillDelay > 0)
            {
                Player.Connection.ReceiveChatWithObservers(con => string.Format(con.Language.SkillBadMap, Magic.Info.Name), MessageType.System);
                return;
            }

            if (SEnvir.Random.Next(Globals.MagicMaxLevel + 5) > 2 + Magic.Level * 2) return;
            /*
            if (CurrentMap.Info.SkillDelay > 0)
            {
                TimeSpan delay = TimeSpan.FromMilliseconds(CurrentMap.Info.SkillDelay * 3);

                Connection.ReceiveChat(con => string.Format(con.Language.SkillEffort, magic.Info.Name, Functions.ToString(delay, true)), MessageType.System);

                UseItemTime = (UseItemTime < SEnvir.Now ? SEnvir.Now : UseItemTime) + delay;
                Enqueue(new S.ItemUseDelay { Delay = SEnvir.Now - UseItemTime });
            }*/

            Player.Teleport(CurrentMap, CurrentMap.GetRandomLocation());
            Player.LevelMagic(Magic);
        }
    }
}
