using Library;
using Server.DBModels;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【灼烧强化】(RetrogressionOfEnergy) - 被动增强技能
    /// 
    /// 效果：被动技能，为所有火系攻击技能附加灼烧效果。
    ///       被其他火系技能通过 GetAugmentedSkill() 引用。
    /// 元素属性：火 (Element.Fire)
    /// 
    /// 实现机制：
    /// - 无 MagicCast/MagicComplete（不主动施放）
    /// - GetPower() 决定灼烧伤害值
    /// - Level 决定灼烧等级
    /// - 被引用的技能：FireBall, AdamantineFireBall, FireStorm, FireWall,
    ///   FireBounce, Asteroid, ScortchedEarth, MeteorShower 等火系技能
    /// </summary>
    [MagicType(MagicType.RetrogressionOfEnergy)]
    public class Burning : MagicObject
    {
        protected override Element Element => Element.Fire;

        public Burning(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }
    }
}
