using Library;
using Server.DBModels;
using Server.Envir;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【异形换位】- 定点传送技能
    /// 
    /// 效果：瞬间传送到指定位置，成功率 = 25 + Level*25%。
    ///       PvP后30秒内使用，冷却时间翻10倍。
    /// 元素属性：无 (Element.None)
    /// 特性：UpdateCombatTime = false
    /// 
    /// 实现机制：
    /// - MagicCast: 地面指向性，检查施法距离
    /// - MagicComplete: 
    ///   成功率判定 Random(100) <= 25+Level*25
    ///   调用 Player.Teleport 传送到目标位置
    ///   PvP冷却惩罚：PvPTime后30秒内 delay*10
    /// </summary>
    [MagicType(MagicType.GeoManipulation)]
    public class GeoManipulation : MagicObject
    {
        protected override Element Element => Element.None;
        public override bool UpdateCombatTime => false;

        public GeoManipulation(PlayerObject player, UserMagic magic) : base(player, magic)
        {

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

            var delay = SEnvir.Now.AddMilliseconds(500);

            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, location));

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            Point location = (Point)data[1];

            /* if (CurrentMap.Info.SkillDelay > 0)
             {
                 Connection.ReceiveChat(con => string.Format(con.Language.SkillBadMap, magic.Info.Name), MessageType.System);
                 return;
             }*/

            if (location == CurrentLocation) return;

            if (SEnvir.Random.Next(100) > 25 + Magic.Level * 25) return;

            if (!Player.Teleport(CurrentMap, location, false)) return;

            /*
            if (CurrentMap.Info.SkillDelay > 0)
            {
                TimeSpan delay = TimeSpan.FromMilliseconds(CurrentMap.Info.SkillDelay);

                Connection.ReceiveChat(con => string.Format(con.Language.SkillEffort, magic.Info.Name, Functions.ToString(delay, true)), MessageType.System);

                UseItemTime = (UseItemTime < SEnvir.Now ? SEnvir.Now : UseItemTime) + delay;
                Enqueue(new S.ItemUseDelay { Delay = SEnvir.Now - UseItemTime });
            }*/

            Player.LevelMagic(Magic);

            int delay = Magic.Info.Delay;
            if (SEnvir.Now <= Player.PvPTime.AddSeconds(30))
                delay *= 10;

            MagicCooldown(null, delay);
        }
    }
}
