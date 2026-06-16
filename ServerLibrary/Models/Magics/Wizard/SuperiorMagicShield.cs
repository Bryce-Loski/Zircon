using Library;
using Server.DBModels;
using Server.Envir;
using System;
using System.Drawing;
using System.Linq;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【魔光盾】(ShieldOfPreservation) - 魔法盾的升级版
    /// 
    /// 效果：生成高级魔法护盾，护盾值基于魔法值计算，永久持续直到被打破。
    ///       护盾值 = MaxMana * (0.25 + Level*0.05)。
    /// 元素属性：无 (Element.None)
    /// 特性：UpdateCombatTime = false
    /// 
    /// 实现机制：
    /// - MagicComplete: 检查是否已有 SuperiorMagicShield Buff
    ///   先移除低级 MagicShield Buff，再添加 SuperiorMagicShield
    ///   持续时间 = TimeSpan.MaxValue（永久）
    /// - 1100ms施放延迟
    /// </summary>
    [MagicType(MagicType.ShieldOfPreservation)]
    public class SuperiorMagicShield : MagicObject
    {
        protected override Element Element => Element.None;
        public override bool UpdateCombatTime => false;

        public SuperiorMagicShield(PlayerObject player, UserMagic magic) : base(player, magic)
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
            if (Player.Buffs.Any(x => x.Type == BuffType.SuperiorMagicShield)) return;

            Player.BuffRemove(BuffType.MagicShield);

            Stats buffStats = new Stats
            {
                [Stat.SuperiorMagicShield] = (int)(Player.Stats[Stat.Mana] * (0.25F + Magic.Level * 0.05F))
            };

            Player.BuffAdd(BuffType.SuperiorMagicShield, TimeSpan.MaxValue, buffStats, true, false, TimeSpan.Zero);

            Player.LevelMagic(Magic);
        }
    }
}
