using Library;
using Server.DBModels;
using Server.Envir;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【冰霜噬咬】- 冰系自身增益+延迟爆发技能（自定义技能）
    /// 
    /// 效果：激活后获得 FrostBite Buff，持续期间攻击有概率附加额外冰系伤害。
    ///       Buff结束时，对周围3格内所有怪物造成一次冰系爆发伤害（不攻击Boss）。
    /// 元素属性：冰 (Element.Ice)
    /// 特性：UpdateCombatTime = false（不触发战斗计时）
    /// 
    /// 实现机制：
    /// - MagicComplete: 添加 BuffType.FrostBite Buff
    ///   持续时间 = 3 + Level*3 秒
    ///   Buff属性：FrostBiteDamage = GetMC()+GetPower()+IceAttack*2
    ///            FrostBiteChance = 5 + Level*5（触发概率%）
    /// - FrostBiteEnd(): Buff到期回调，对周围3格怪物创建 DelayedMagicDamage
    ///   伤害上限 = MaxMC*50 + IceAttack*70
    /// </summary>
    [MagicType(MagicType.FrostBite)]
    public class FrostBite : MagicObject
    {
        protected override Element Element => Element.Ice;
        public override bool UpdateCombatTime => false;
        protected override int Slow => 5;
        protected override int SlowLevel => 5;

        public FrostBite(PlayerObject player, UserMagic magic) : base(player, magic)
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
            if (Player.Buffs.Any(x => x.Type == BuffType.FrostBite)) return;

            Stats buffStats = new Stats
            {
                [Stat.FrostBiteDamage] = Player.GetMC() + Magic.GetPower() + Player.Stats[Stat.IceAttack] * 2,
                [Stat.FrostBiteChance] = 5 + (Magic.Level * 5)
            };

            Player.BuffAdd(BuffType.FrostBite, TimeSpan.FromSeconds(3 + Magic.Level * 3), buffStats, false, false, TimeSpan.Zero);

            Player.LevelMagic(Magic);
        }

        public void FrostBiteEnd(BuffInfo buff)
        {
            Player.LevelMagic(Magic);

            var delay = SEnvir.Now.AddMilliseconds(500);

            foreach (MapObject ob in Player.GetTargets(CurrentMap, CurrentLocation, 3))
            {
                if (!Player.CanAttackTarget(ob)) continue;

                if (ob.Race != ObjectType.Monster) continue;

                MonsterObject mob = (MonsterObject)ob;

                if (mob.MonsterInfo.IsBoss) continue;

                ActionList.Add(new DelayedAction(delay, ActionType.DelayedMagicDamage, new List<MagicType> { Type }, ob, true, buff.Stats, 0));
            }
        }

        public override int ModifyPowerAdditionner(bool primary, int power, MapObject ob, Stats stats = null, int extra = 0)
        {
            power += Math.Min(stats[Stat.FrostBiteDamage], Player.Stats[Stat.MaxMC] * 50 + Player.Stats[Stat.IceAttack] * 70);

            return power;
        }
    }
}
