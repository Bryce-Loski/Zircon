using Library;
using Server.DBModels;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【魔爆术】(FuryBlast) - 被动增强技能
    /// 
    /// 效果：被动技能，为所有雷系攻击技能附加麻痹效果。
    ///       被其他雷系技能通过 GetAugmentedSkill() 引用。
    /// 元素属性：雷 (Element.Lightning)
    /// 
    /// 实现机制：
    /// - 无 MagicCast/MagicComplete（不主动施放）
    /// - GetPower() 决定麻痹强度
    /// - Level 决定麻痹触发概率（Random(MaxLevel) <= Level）
    /// - 被引用的技能：ChainLightning, LightningBall, LightningBeam,
    ///   LightningStrike, LightningWave, ThunderBolt, ThunderStrike 等雷系技能
    /// </summary>
    [MagicType(MagicType.FuryBlast)]
    public class Shocked : MagicObject
    {
        protected override Element Element => Element.Lightning;

        public Shocked(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }
    }
}
