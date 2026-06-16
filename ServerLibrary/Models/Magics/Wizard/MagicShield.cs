using Library;
using Server.DBModels;
using Server.Envir;
using System;
using System.Drawing;
using System.Linq;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【魔法盾】- 防御增益技能
    /// 
    /// 效果：生成魔法护盾，吸收50%的伤害。
    ///       持续时间 = 30 + Level*20 + GetMC()/2 + PhantomAttack*2 秒。
    /// 元素属性：无 (Element.None)
    /// 特性：UpdateCombatTime = false（不触发战斗计时）
    /// 
    /// 实现机制：
    /// - MagicComplete: 检查是否已有 MagicShield 或 SuperiorMagicShield Buff
    ///   若已有则不重复添加
    ///   添加 BuffType.MagicShield，Stat.MagicShield = 50（50%减伤）
    /// - 1100ms施放延迟
    /// </summary>
    [MagicType(MagicType.MagicShield)]
    public class MagicShield : MagicObject
    {
        protected override Element Element => Element.None;
        public override bool UpdateCombatTime => false;

        public MagicShield(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }

        public override MagicCast MagicCast(MapObject target, Point location, MirDirection direction)
        {
            var response = new MagicCast
            {
                Ob = null
            };

            var delay = SEnvir.Now.AddMilliseconds(1100);

            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type));

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            if (Player.Buffs.Any(x => x.Type == BuffType.MagicShield) || Player.Buffs.Any(x => x.Type == BuffType.SuperiorMagicShield)) return;

            Stats buffStats = new Stats
            {
                [Stat.MagicShield] = 50
            };

            Player.BuffAdd(BuffType.MagicShield, TimeSpan.FromSeconds(30 + Magic.Level * 20 + Player.GetMC() / 2 + Player.Stats[Stat.PhantomAttack] * 2), buffStats, true, false, TimeSpan.Zero);

            Player.LevelMagic(Magic);
        }
    }
}
