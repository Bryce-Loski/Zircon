using Library;
using Server.DBModels;
using Server.Envir;
using System;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【旋风墙】- 风系持续性地面法术
    /// 
    /// 效果：在目标位置3x3范围内召唤飓风，每2秒对范围内敌人造成风系伤害。
    ///       与火墙术类似但为风属性，可替代火墙放置在相同位置。
    /// 元素属性：风 (Element.Wind)
    /// 击退参数：Repel=5
    /// 特性：CanStruck = false（不可被打断）
    /// 
    /// 实现机制：
    /// - MagicCast: 攻沙战中先清除旧飓风
    ///   GetCells(location, 0, 1) 获取3x3区域
    /// - MagicComplete: 清除旧火墙/飓风后创建 SpellObject(SpellEffect.Tempest)
    ///   持续时间 = (Level+2)*5 次tick，tick频率 = 2秒
    /// - ModifyPowerMultiplier: 伤害乘以 0.80（80%系数，比火墙60%更高）
    /// </summary>
    [MagicType(MagicType.Tempest)]
    public class Tempest : MagicObject
    {
        protected override Element Element => Element.Wind;
        protected override int Repel => 5;
        public override bool CanStruck => false;

        public Tempest(PlayerObject player, UserMagic magic) : base(player, magic)
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

            var power = (Magic.Level + 2) * 5;

            foreach (ConquestWar war in SEnvir.ConquestWars)
            {
                if (war.Map != CurrentMap) continue;

                for (int i = Player.SpellList.Count - 1; i >= 0; i--)
                {
                    if (Player.SpellList[i].Effect != SpellEffect.Tempest) continue;

                    Player.SpellList[i].Despawn();
                }

                break;
            }

            var cells = CurrentMap.GetCells(location, 0, 1);

            var delay = SEnvir.Now.AddMilliseconds(500);

            foreach (Cell cell in cells)
            {
                ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, cell, power));
            }

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            Cell cell = (Cell)data[1];
            int power = (int)data[2];

            if (cell == null) return;

            if (cell.Objects != null)
            {
                for (int i = cell.Objects.Count - 1; i >= 0; i--)
                {
                    if (cell.Objects[i].Race != ObjectType.Spell) continue;

                    SpellObject spell = (SpellObject)cell.Objects[i];

                    if (spell.Effect != SpellEffect.FireWall && spell.Effect != SpellEffect.Tempest) continue;

                    spell.Despawn();
                }
            }

            SpellObject ob = new SpellObject
            {
                DisplayLocation = cell.Location,
                TickCount = power,
                TickFrequency = TimeSpan.FromSeconds(2),
                Owner = Player,
                Effect = SpellEffect.Tempest,
                Magic = Magic,
            };

            ob.Spawn(cell.Map, cell.Location);

            Player.LevelMagic(Magic);
        }

        public override int ModifyPowerAdditionner(bool primary, int power, MapObject ob, Stats stats = null, int extra = 0)
        {
            power += Magic.GetPower() + Player.GetMC();

            return power;
        }

        public override int ModifyPowerMultiplier(bool primary, int power, Stats stats = null, int extra = 0)
        {
            power = (int)(power * 0.80F);

            return power;
        }
    }
}
