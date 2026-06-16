using Library;
using Server.DBModels;
using Server.Envir;
using System.Collections.Generic;
using System.Drawing;
using S = Library.Network.ServerPackets;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【混元掌】(RayOfLight) - 火系弹射攻击技能（自定义技能）
    /// 
    /// 效果：火球命中目标后自动弹跳到附近3格内的其他怪物，
    ///       最多弹跳 Magic.Level + 2 次。
    /// 元素属性：火 (Element.Fire)
    /// 
    /// 实现机制：
    /// - MagicCast: 调用 Bounce() 发起首次攻击
    /// - Bounce(): 递归弹射方法，计算源到目标的飞行延迟(距离*48ms)
    ///   首次弹射(bounce=-1)时设定总次数 = Level+2
    ///   后续弹射通过 S.ObjectProjectile 广播弹射视觉效果
    /// - MagicComplete: 命中后在目标周围3格内随机选取一个怪物作为下一个弹射目标
    /// - 联动 RetrogressionOfEnergy 灼烧强化
    /// - 伤害公式: Magic.GetPower() + Player.GetMC()
    /// </summary>
    [MagicType(MagicType.RayOfLight)]
    public class FireBounce : MagicObject
    {
        protected override Element Element => Element.Fire;

        public FireBounce(PlayerObject player, UserMagic magic) : base(player, magic)
        {
            //Custom Skill
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
            if (!Player.CanAttackTarget(target))
                return new MagicCast();

            var response = Bounce(Player, target, -1);

            response.Targets.Add(target.ObjectID);

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            MapObject target = (MapObject)data[1];
            Point targetLocation = (Point)data[2];
            int bounce = (int)data[3];

            if (!Player.CanAttackTarget(target))
                return;

            if (!Functions.InRange(target.CurrentLocation, targetLocation, Globals.MagicRange))
                return;

            if (Player.MagicAttack(new List<MagicType> { Type }, target, true, null, bounce) < 1)
                return;

            var burning = GetAugmentedSkill(MagicType.RetrogressionOfEnergy);

            if (burning != null)
            {
                Player.LevelMagic(burning);
            }

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

                Bounce(target, nextTarget, --bounce);
            }
        }

        private MagicCast Bounce(MapObject source, MapObject target, int bounce = -1)
        {
            var response = new MagicCast
            {
                Ob = source
            };

            if (!Player.CanAttackTarget(target) || bounce == 0)
                return response;

            var delay = SEnvir.Now.AddMilliseconds(Functions.Distance(source.CurrentLocation, target.CurrentLocation) * 48);

            if (bounce == -1)
            {
                bounce = Magic.Level + 2;
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

            Player.ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, target, target.CurrentLocation, bounce));

            return response;
        }

        public override int ModifyPowerAdditionner(bool primary, int power, MapObject ob, Stats stats = null, int bounce = 0)
        {
            power += Magic.GetPower() + Player.GetMC();

            return power;
        }
    }
}
