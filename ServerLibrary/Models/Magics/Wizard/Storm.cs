using Library;
using Server.DBModels;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【风暴】- 风系全屏AOE技能（未完全实现）
    /// 
    /// 效果：设计为绿色风暴覆盖全屏的AOE技能，带粒子效果。
    /// 元素属性：风 (Element.Wind)
    /// 
    /// 实现机制：
    /// - 仅有构造函数，无 MagicCast/MagicComplete
    /// - TODO: 动画和粒子效果未实现
    /// - 参考: MagicEx7=900, Icon=492
    /// </summary>
    [MagicType(MagicType.Storm)]
    public class Storm : MagicObject
    {
        protected override Element Element => Element.Wind;

        public Storm(PlayerObject player, UserMagic magic) : base(player, magic)
        {
            //MagicEx7 - 900?
            //TODO - Green storm covers screen, particle effect
            //Icon - 492
            //https://www.youtube.com/watch?v=XRRkVxSLj1E&t=62s
        }
    }
}
