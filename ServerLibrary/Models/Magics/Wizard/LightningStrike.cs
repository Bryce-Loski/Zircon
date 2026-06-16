using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;
using S = Library.Network.ServerPackets;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【雷击术】(TempestOfUnstableEnergy) - 雷系连锁弹射攻击技能（自定义技能）
    /// 
    /// 效果：类似连锁闪电，但弹射机制不同——每次弹射伤害递增而非递减。
    ///       最多弹射 Magic.Level + 2 次。
    /// 元素属性：雷 (Element.Lightning)
    /// 
    /// 实现机制：
    /// - Strike(): 递归弹射方法，与 FireBounce 的 Bounce() 结构类似
    ///   首次(strikesRemaining=-1)设定次数 = Level+2
    ///   后续通过 S.ObjectProjectile 广播弹射视觉
    /// - MagicComplete: 在目标周围3格内随机选取下一个怪物
    /// - ModifyPowerMultiplier: 伤害随弹射次数递增
    ///   multiplier = (MaxStrike - remaining) * (1/MaxStrike)
    /// - TODO: 视觉效果应改为粒子连线而非投射物
    /// - 联动 FuryBlast 麻痹强化
    /// </summary>
    [MagicType(MagicType.TempestOfUnstableEnergy)]
    public class LightningStrike : MagicObject
    {
        protected override Element Element => Element.Lightning;
        private int MaxStrike => Magic.Level + 2;

        public LightningStrike(PlayerObject player, UserMagic magic) : base(player, magic)
        {
            //TODO - Effect should be a particle effect connecting the targets together, not a projectile
            //https://youtu.be/DDmB8CTco8o?t=52 
        }

        public override int GetShock(int shock, Stats stats = null)
        {
            var shocked = GetAugmentedSkill(MagicType.FuryBlast);

            if (shocked != null && SEnvir.Random.Next(Globals.MagicMaxLevel) <= shocked.Level)
            {
                return shocked.GetPower();
            }

            return base.GetShock(shock, stats);
        }

        public override MagicCast MagicCast(MapObject target, Point location, MirDirection direction)
        {
            if (!Player.CanAttackTarget(target))
                return new MagicCast();

            var response = Strike(Player, target, -1);

            response.Targets.Add(target.ObjectID);

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            MapObject target = (MapObject)data[1];
            Point targetLocation = (Point)data[2];
            int strikesRemaining = (int)data[3];

            if (!Player.CanAttackTarget(target))
                return;

            if (!Functions.InRange(target.CurrentLocation, targetLocation, Globals.MagicRange))
                return;

            if (Player.MagicAttack(new List<MagicType> { Type }, target, true, null, strikesRemaining) < 1)
                return;

            var targets = new List<MapObject>();

            foreach (var ob in Player.GetTargets(Player.CurrentMap, target.CurrentLocation, 3))
            {
                if (!Player.CanAttackTarget(ob)) continue;

                if (ob.Race != ObjectType.Monster) continue;

                targets.Add(ob);
            }

            if (targets.Count > 0)
            {
                var nextTarget = targets[SEnvir.Random.Next(targets.Count)];

                Strike(target, nextTarget, --strikesRemaining);
            }
        }

        private MagicCast Strike(MapObject source, MapObject target, int strikesRemaining = -1)
        {
            var response = new MagicCast
            {
                Ob = source
            };

            if (!Player.CanAttackTarget(target) || strikesRemaining == 0)
                return response;

            var delay = SEnvir.Now.AddMilliseconds(Functions.Distance(source.CurrentLocation, target.CurrentLocation) * 48);

            if (strikesRemaining == -1)
            {
                strikesRemaining = MaxStrike;
                delay = delay.AddMilliseconds(500);
            }
            else
            {
                Player.Broadcast(new S.ObjectProjectile
                {
                    ObjectID = source.ObjectID,
                    Direction = source.Direction,
                    CurrentLocation = source.CurrentLocation,
                    Type = Type,
                    Targets = new List<uint> { target.ObjectID },
                    Locations = new List<Point>()
                });
            }

            Player.ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, target, target.CurrentLocation, strikesRemaining));

            return response;
        }

        public override int ModifyPowerAdditionner(bool primary, int power, MapObject ob, Stats stats = null, int strikesRemaining = 0)
        {
            power += Player.GetMC() + Magic.GetPower();

            return power;
        }

        public override int ModifyPowerMultiplier(bool primary, int power, Stats stats = null, int strikesRemaining = 0)
        {
            var multiplier = (int)((MaxStrike - strikesRemaining) * (1 / MaxStrike));

            power += (power * multiplier);

            return power;
        }
    }
}
