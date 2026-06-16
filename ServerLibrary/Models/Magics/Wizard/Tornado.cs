using Library;
using Library.SystemModels;
using Server.DBModels;
using Server.Envir;
using System;
using System.Drawing;
using System.Linq;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【召唤龙卷风】- 风系召唤技能
    /// 
    /// 效果：在指定位置召唤一个龙卷风怪物（Monsters.Tornado），
    ///       龙卷风的属性基于法师自身属性进行缩放加成。
    /// 元素属性：风 (Element.Wind)
    /// 
    /// 实现机制：
    /// - MagicCast: 获取 MonsterFlag.Tornado 对应的 MonsterInfo
    /// - MagicComplete: 创建 Monsters.Tornado 实例
    ///   设置 VisibleTime=10秒，添加 BuffType.Tornado Buff
    ///   属性缩放（bonusScalingFactor=10）：
    ///   - MinDC/MaxDC = Level + MinMC/MaxMC/10 * max(1,Level) + WindAttack
    ///   - HP = Level*10 + 玩家HP/10 * max(1,Level)
    ///   - AC/MR 同理缩放，敏捷/准确固定100
    /// TODO: 动画音效未完成，Level 3增加移速，Level 4增加击退
    /// </summary>
    [MagicType(MagicType.Tornado)]
    public class Tornado : MagicObject
    {
        protected override Element Element => Element.Wind;

        public Tornado(PlayerObject player, UserMagic magic) : base(player, magic)
        {
            //TODO
            //Finish skill anim and sound
            //Level 3 increases movement speed
            //Level 4 adds push back??
            //Mon-56 - 6000
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

            response.Locations.Add(location);

            var info = SEnvir.MonsterInfoList.Binding.First(x => x.Flag == MonsterFlag.Tornado);

            var delay = SEnvir.Now.AddMilliseconds(400);

            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, location, info));

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            var location = (Point)data[1];
            var info = (MonsterInfo)data[2];

            if (MonsterObject.GetMonster(info) is not Monsters.Tornado ob) return;

            ob.VisibleTime = SEnvir.Now.AddSeconds(10);

            int bonusScalingFactor = 10;

            Stats buffStatsRegen = new Stats
            {
                [Stat.MinDC] = Magic.Level + (Player.Stats[Stat.MinMC] / bonusScalingFactor) * Math.Max(1, Magic.Level) + Player.Stats[Stat.WindAttack],
                [Stat.MaxDC] = Magic.Level + (Player.Stats[Stat.MaxMC] / bonusScalingFactor) * Math.Max(1, Magic.Level) + Player.Stats[Stat.WindAttack],

                [Stat.Health] = (Magic.Level * 10) + (Player.Stats[Stat.Health] / bonusScalingFactor) * Math.Max(1, Magic.Level),
                [Stat.MinAC] = Magic.Level + (Player.Stats[Stat.MinAC] / bonusScalingFactor) * Math.Max(1, Magic.Level),
                [Stat.MaxAC] = Magic.Level + (Player.Stats[Stat.MaxAC] / bonusScalingFactor) * Math.Max(1, Magic.Level),
                [Stat.MinMR] = Magic.Level + (Player.Stats[Stat.MinMR] / bonusScalingFactor) * Math.Max(1, Magic.Level),
                [Stat.MaxMR] = Magic.Level + (Player.Stats[Stat.MaxMR] / bonusScalingFactor) * Math.Max(1, Magic.Level),
                [Stat.MaxMR] = Magic.Level + (Player.Stats[Stat.MaxMR] / bonusScalingFactor) * Math.Max(1, Magic.Level),
                [Stat.Agility] = 100,
                [Stat.Accuracy] = 100
            };

            ob.BuffAdd(BuffType.Tornado, TimeSpan.FromSeconds(10), buffStatsRegen, true, false, TimeSpan.Zero);

            ob.Spawn(Player.CurrentMap, location);

            Player.LevelMagic(Magic);
        }
    }
}
