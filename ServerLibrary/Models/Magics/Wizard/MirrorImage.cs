using Library;
using Server.DBModels;
using Server.Envir;
using System.Drawing;
using System.Linq;
using M = Server.Models.Monsters;
using S = Library.Network.ServerPackets;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【镜像分身】- 元素分身召唤技能
    /// 
    /// 效果：在指定位置召唤一个镜像分身怪物(Monsters.MirrorImage)，
    ///       分身的元素属性由装备的暗石(DarkStone)决定。
    ///       分身持续 Level*5 秒（最少5秒），同时只能存在1个。
    /// 元素属性：无 (Element.None)，分身属性由暗石决定
    /// 
    /// 实现机制：
    /// - MagicCast: 地面指向性，检查施法距离
    /// - MagicComplete: 
    ///   检查暗石元素(Fire/Ice/Lightning/Wind)，无暗石则不召唤
    ///   检查是否已有 MirrorImage 宠物（同时只允许1个）
    ///   创建 Monsters.MirrorImage 实例，设置 Element/ExplodeTime/TameTime
    ///   通过 S.ObjectEffect 播放召唤特效
    /// </summary>
    [MagicType(MagicType.MirrorImage)]
    public class MirrorImage : MagicObject
    {
        protected override Element Element => Element.None;

        public MirrorImage(PlayerObject player, UserMagic magic) : base(player, magic)
        {
            //MagicEx - 2020
            //Magic - 2390?
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

            var delay = SEnvir.Now.AddMilliseconds(500);

            ActionList.Add(new DelayedAction(delay, ActionType.DelayMagic, Type, location));

            return response;
        }

        public override void MagicComplete(params object[] data)
        {
            Element element = Element.None;
            if (Player.Equipment[(int)EquipmentSlot.Amulet]?.Info.ItemType == ItemType.DarkStone)
            {
                Stats darkstoneStats = Player.Equipment[(int)EquipmentSlot.Amulet].Info.Stats;

                if (darkstoneStats.GetAffinityValue(Element.Fire) > 0)
                    element = Element.Fire;
                else if (darkstoneStats.GetAffinityValue(Element.Ice) > 0)
                    element = Element.Ice;
                else if (darkstoneStats.GetAffinityValue(Element.Lightning) > 0)
                    element = Element.Lightning;
                else if (darkstoneStats.GetAffinityValue(Element.Wind) > 0)
                    element = Element.Wind;
            }

            if (element == Element.None) return;

            if (Player.Pets.Any(x => x.MonsterInfo.Flag == MonsterFlag.MirrorImage))
                return;

            Point location = (Point)data[1];
            int count = 1;

            for (int i = 0; i < count; i++)
            {
                M.MirrorImage mob = new()
                {
                    MonsterInfo = SEnvir.MonsterInfoList.Binding.First(x => x.Flag == MonsterFlag.MirrorImage),
                    Player = Player,
                    Direction = Direction,
                    Element = element,
                    Location = location,
                    ExplodeTime = SEnvir.Now.AddSeconds(Magic.Level > 0 ? Magic.Level * 5 : 5),
                    TameTime = SEnvir.Now.AddDays(365)
                };

                if (mob.Spawn(CurrentMap, location))
                {
                    mob.Broadcast(new S.ObjectEffect { Effect = Effect.MirrorImage, ObjectID = mob.ObjectID });

                    Player.Pets.Add(mob);
                    mob.PetOwner = Player;
                }
            }
        }
    }
}
