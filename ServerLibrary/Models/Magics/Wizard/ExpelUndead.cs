using Library;
using Server.DBModels;
using Server.Envir;
using System.Drawing;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【圣言术】- 对亡灵怪物的即死技能
    /// 
    /// 效果：对非Boss、等级<70的亡灵怪物进行驱逐判定，
    ///       成功则直接击杀。成功率基于等级差和魔法等级。
    /// 元素属性：无 (Element.None)
    /// 
    /// 实现机制：
    /// - 前置条件：目标必须是怪物、亡灵(Undead=true)、非Boss、等级<70
    /// - 等级判定: 怪物等级 >= PlayerLevel-1+Random(4) 则抵抗
    /// - 成功率 = 35 + Level*9 + (PlayerLevel-MonsterLevel)*5 + PhantomAttack/2
    /// - 成功时 ob.SetHP(0) 直接击杀
    /// </summary>
    [MagicType(MagicType.ExpelUndead)]
    public class ExpelUndead : MagicObject
    {
        protected override Element Element => Element.None;

        public ExpelUndead(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }

        public override MagicCast MagicCast(MapObject target, Point location, MirDirection direction)
        {
            var response = new MagicCast
            {
                Ob = target
            };

            if (!Player.CanAttackTarget(target) || target.Race != ObjectType.Monster || !((MonsterObject)target).MonsterInfo.Undead)
            {
                response.Ob = null;
                return response;
            }

            response.Targets.Add(target.ObjectID);

            var delay = SEnvir.Now.AddMilliseconds(500);

            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, target));

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            MonsterObject ob = (MonsterObject)data[1];

            if (ob?.Node == null || !Player.CanAttackTarget(ob) || ob.MonsterInfo.IsBoss || ob.Level >= 70) return;

            if (ob.Target == null && ob.CanAttackTarget(Player))
                ob.Target = Player;
            if (ob.Level >= Player.Level - 1 + SEnvir.Random.Next(4)) return;

            if (SEnvir.Random.Next(100) >= 35 + Magic.Level * 9 + (Player.Level - ob.Level) * 5 + Player.Stats[Stat.PhantomAttack] / 2) return;

            if (ob.EXPOwner == null && ob.Master == null)
                ob.EXPOwner = Player;

            ob.SetHP(0);

            Player.LevelMagic(Magic);
        }
    }
}
