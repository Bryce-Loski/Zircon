using Library;
using Server.DBModels;
using Server.Envir;
using System;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【天罚】- 自身增益Buff技能
    /// 
    /// 效果：激活天罚Buff，持续期间获得伤害反射效果。
    ///       反射值 = (2+Level)*20，持续时间 = 30+Level*30 秒。
    /// 元素属性：无 (Element.None)
    /// 特性：UpdateCombatTime = false
    /// 
    /// 实现机制：
    /// - MagicComplete: 添加 BuffType.JudgementOfHeaven Buff
    ///   Stat.JudgementOfHeaven = (2+Level)*20
    ///   持续时间 = 30 + Level*30 秒
    /// - 600ms施放延迟
    /// </summary>
    [MagicType(MagicType.JudgementOfHeaven)]
    public class JudgementOfHeaven : MagicObject
    {
        protected override Element Element => Element.None;
        public override bool UpdateCombatTime => false;

        public JudgementOfHeaven(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }

        public override MagicCast MagicCast(MapObject target, Point location, MirDirection direction)
        {
            var response = new MagicCast
            {
                Ob = null
            };

            var delay = SEnvir.Now.AddMilliseconds(600);

            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type));

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            Stats buffStats = new Stats
            {
                [Stat.JudgementOfHeaven] = (2 + Magic.Level) * 20,
            };

            Player.BuffAdd(BuffType.JudgementOfHeaven, TimeSpan.FromSeconds(30 + Magic.Level * 30), buffStats, false, false, TimeSpan.Zero);

            Player.LevelMagic(Magic);
        }
    }
}
