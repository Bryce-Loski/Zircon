using Library;
using Server.DBModels;
using Server.Envir;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using S = Library.Network.ServerPackets;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【凝血离魂】- 牺牲生命值换取魔法攻击力的增益技能
    /// 
    /// 效果：牺牲 (1+Level)*10% 的最大生命值，
    ///       同时增加 (1+Level)*10% 的魔法攻击力。
    ///       被动效果：每次攻击成功时增加技能经验。
    /// 元素属性：无 (Element.None)
    /// 特性：UpdateCombatTime = false
    /// 
    /// 实现机制：
    /// - GetPassiveStats: 被动增加 MCPercent = (1+Level)*10
    /// - MagicComplete: 添加 BuffType.Renounce Buff
    ///   持续时间 = 30 + Level*30 秒
    ///   HealthPercent = -(1+Level)*10（减少HP%）
    ///   MCPercent = (1+Level)*10（增加魔攻%）
    ///   记录损失的生命值到 RenounceHPLost
    /// - MagicAttackSuccessPassive: Buff持续期间每次攻击成功升级技能
    /// </summary>
    [MagicType(MagicType.Renounce)]
    public class Renounce : MagicObject
    {
        protected override Element Element => Element.None;
        public override bool UpdateCombatTime => false;

        public Renounce(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }

        public override Stats GetPassiveStats()
        {
            var stats = new Stats
            {
                [Stat.MCPercent] = (1 + Magic.Level) * 10
            };

            return stats;
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
                [Stat.HealthPercent] = -(1 + Magic.Level) * 10,
                [Stat.MCPercent] = (1 + Magic.Level) * 10,
            };
            int health = Player.CurrentHP;

            BuffInfo buff = Player.BuffAdd(BuffType.Renounce, TimeSpan.FromSeconds(30 + Magic.Level * 30), buffStats, false, false, TimeSpan.Zero);

            buff.Stats[Stat.RenounceHPLost] = health - Player.CurrentHP;
            Player.Enqueue(new S.BuffChanged() { Index = buff.Index, Stats = new Stats(buff.Stats) });

            Player.LevelMagic(Magic);
        }

        public override void MagicAttackSuccessPassive(MapObject ob, List<MagicType> types)
        {
            if (Player.Buffs.Any(x => x.Type == BuffType.Renounce))
            {
                Player.LevelMagic(Magic);
            }
        }
    }
}
