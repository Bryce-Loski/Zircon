using Library;
using Server.DBModels;
using Server.Envir;
using System;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【火墙】- 火系持续性地面法术
    /// 
    /// 效果：在目标位置及其上下左右5个格子放置火墙，
    ///       火墙每2秒对经过的敌人造成火系伤害。
    /// 元素属性：火 (Element.Fire)
    /// 特性：CanStruck = false（不会被怪物攻击打断）
    /// 
    /// 实现机制：
    /// - MagicCast: 在攻沙战(ConquestWar)中，先清除玩家旧火墙
    ///   对中心+上下左右5个格子创建 DelayedAction
    /// - MagicComplete: 先清除格子上的旧火墙/风暴法术，
    ///   再创建 SpellObject(SpellEffect.FireWall)
    ///   持续时间 = (Level+2)*5 次tick，tick频率 = 2秒
    /// - ModifyPowerMultiplier: 伤害乘以 0.60（60%系数）
    /// - 联动 RetrogressionOfEnergy 灼烧强化
    /// </summary>
    [MagicType(MagicType.FireWall)]
    public class FireWall : MagicObject
    {
        protected override Element Element => Element.Fire;
        public override bool CanStruck => false;

        public FireWall(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }

        public override int GetBurn(int burn, Stats stats = null)
        {
            var burning = GetAugmentedSkill(MagicType.RetrogressionOfEnergy);

            if (burning != null)
            {
                return burning.GetPower();
            }

            return base.GetBurn(burn, stats);
        }

        public override int GetBurnLevel(int burnLevel, Stats stats = null)
        {
            var burning = GetAugmentedSkill(MagicType.RetrogressionOfEnergy);

            if (burning != null)
            {
                return burning.Level + 1;
            }

            return base.GetBurnLevel(burnLevel, stats);
        }

        public override MagicCast MagicCast(MapObject target, Point location, MirDirection direction)
        {
            var response = new MagicCast
            {
                Ob = null
            };

            if (!Functions.InRange(Player.CurrentLocation, location, Globals.MagicRange))
            {
                response.Cast = false;
                return response;
            }

            foreach (ConquestWar war in SEnvir.ConquestWars)
            {
                if (war.Map != Player.CurrentMap) continue;

                for (int i = Player.SpellList.Count - 1; i >= 0; i--)
                {
                    if (Player.SpellList[i].Effect != SpellEffect.FireWall) continue;

                    Player.SpellList[i].Despawn();
                }

                break;
            }

            var delay = SEnvir.Now.AddMilliseconds(500);

            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(location, MirDirection.Up))));
            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(location, MirDirection.Down))));
            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(location)));
            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(location, MirDirection.Left))));
            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, CurrentMap.GetCell(Functions.Move(location, MirDirection.Right))));

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            Cell cell = (Cell)data[1];

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
                TickCount = (Magic.Level + 2) * 5,
                TickFrequency = TimeSpan.FromSeconds(2),
                Owner = Player,
                Effect = SpellEffect.FireWall,
                Magic = Magic,
            };

            ob.Spawn(cell.Map, cell.Location);

            Player.LevelMagic(Magic);

            var burning = GetAugmentedSkill(MagicType.RetrogressionOfEnergy);

            if (burning != null)
            {
                Player.LevelMagic(burning);
            }
        }

        public override int ModifyPowerAdditionner(bool primary, int power, MapObject ob, Stats stats = null, int extra = 0)
        {
            power += Magic.GetPower() + Player.GetMC();

            return power;
        }

        public override int ModifyPowerMultiplier(bool primary, int power, Stats stats = null, int extra = 0)
        {
            power = (int)(power * 0.60F);

            return power;
        }
    }
}
