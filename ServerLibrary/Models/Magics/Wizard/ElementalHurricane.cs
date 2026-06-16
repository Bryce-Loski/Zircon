using Library;
using Server.DBModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using S = Library.Network.ServerPackets;

namespace Server.Models.Magics
{
    /// <summary>
    /// 【元素飓风】(BurstOfEnergy) - 切换式持续AOE技能（自定义技能）
    /// 
    /// 效果：开启后在周围持续造成AOE伤害（元素类型由装备暗石决定），
    ///       再次使用可关闭。持续消耗MP。
    /// 元素属性：动态（由 Amulet 槽位暗石决定，无暗石则为无属性）
    /// 
    /// 实现机制：
    /// - GetElement: 检查装备暗石(DarkStone)的元素属性
    /// - CheckCost: 若Buff已激活则MP消耗为0
    /// - MagicCast: 切换逻辑
    ///   已有Buff → 移除 BuffType.ElementalHurricane（关闭）
    ///   无Buff → 添加永久Buff，tickTime=500ms（开启）
    /// - MagicConsume: 消耗 MP = MaxMana * Cost / 1000（按千分比）
    /// - MagicComplete: 逐格AOE伤害，非主目标30%伤害
    /// </summary>
    [MagicType(MagicType.BurstOfEnergy)]
    public class ElementalHurricane : MagicObject
    {
        protected override Element Element => Element.None;

        public override Element GetElement(Element element)
        {
            bool hasStone = Player.Equipment[(int)EquipmentSlot.Amulet]?.Info.ItemType == ItemType.DarkStone;

            return hasStone ? Player.Equipment[(int)EquipmentSlot.Amulet].Info.Stats.GetAffinityElement() : base.GetElement(element);
        }

        public ElementalHurricane(PlayerObject player, UserMagic magic) : base(player, magic)
        {

        }

        public override bool CheckCost()
        {
            int cost = Magic.Cost;
            if (Player.Buffs.Any(x => x.Type == BuffType.ElementalHurricane))
                cost = 0;

            if (cost > Player.CurrentMP)
            {
                Player.Enqueue(new S.UserLocation { Direction = Direction, Location = CurrentLocation });
                return false;
            }

            return true;
        }

        public override MagicCast MagicCast(MapObject target, Point location, MirDirection direction)
        {
            var response = new MagicCast
            {
                Ob = null
            };

            if (Player.Buffs.Any(x => x.Type == BuffType.ElementalHurricane))
            {
                Player.BuffRemove(BuffType.ElementalHurricane);
            }
            else
            {
                var buff = Player.BuffAdd(BuffType.ElementalHurricane, TimeSpan.MaxValue, null, true, false, TimeSpan.FromSeconds(1));
                buff.TickTime = TimeSpan.FromMilliseconds(500);
            }

            return response;
        }

        public override void MagicConsume()
        {
            if (Player.Buffs.Any(x => x.Type == BuffType.ElementalHurricane))
                return;

            Player.ChangeMP(-(Player.Stats[Stat.Mana] * Magic.Cost / 1000));
        }

        public override void MagicComplete(params object[] data)
        {
            Cell cell = (Cell)data[1];
            bool primary = (bool)data[2];

            if (cell?.Objects == null) return;

            for (int i = cell.Objects.Count - 1; i >= 0; i--)
            {
                if (i >= cell.Objects.Count) continue;
                MapObject ob = cell.Objects[i];
                if (!Player.CanAttackTarget(ob)) continue;

                Player.MagicAttack(new List<MagicType> { Type }, ob, primary);
            }
        }

        public override int ModifyPowerAdditionner(bool primary, int power, MapObject ob, Stats stats = null, int extra = 0)
        {
            power += Magic.GetPower() + Player.GetMC();

            return power;
        }

        public override int ModifyPowerMultiplier(bool primary, int power, Stats stats = null, int extra = 0)
        {
            if (!primary)
                power = (int)(power * 0.3M);

            return power;
        }
    }
}
