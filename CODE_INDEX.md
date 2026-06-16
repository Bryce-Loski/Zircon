# Zircon 代码索引（详细版）

> 用于快速定位代码文件，基于项目实际结构生成

---

## 项目总览

| 项目 | 说明 | 文件数 | 代码行数 |
|------|------|:------:|:--------:|
| **LibraryCore** | 共享核心库（枚举、数据模型、工具函数） | ~80 | ~8,000 |
| **ServerLibrary** | 服务端核心逻辑（游戏机制、AI、数据库） | ~200+ | ~50,000+ |
| **Client** | 客户端（渲染、UI、场景） | ~100+ | ~70,000+ |
| **Server** | 服务端 GUI（管理界面） | ~134 | ~22,669 |
| **PluginCore** | 插件框架 | ~10 | ~1,500 |
| **Launcher** | 启动器 | ~6 | ~800 |
| **LibraryEditor** | 图库编辑器 | ~14 | ~4,000 |
| **ImageManager** | 图片管理工具 | ~4 | ~2,000 |

---

## 一、LibraryCore（共享核心库）

### 枚举与常量

| 文件 | 行数 | 关键内容 |
|------|:----:|---------|
| [LibraryCore/Enum.cs](LibraryCore/Enum.cs) | 3221 | `MagicType` `MonsterFlag` `BuffType` `PoisonType` `PetMode` `ItemType` `Stat` 等全部枚举 |
| [LibraryCore/Stat.cs](LibraryCore/Stat.cs) | 929 | `Stat` 枚举定义（含 StatDescription 属性）、`Stats` 字典类 |
| [LibraryCore/Globals.cs](LibraryCore/Globals.cs) | 1185 | 全局常量（`InventorySize` `CompanionMoveDelay` 等）、DBCollection 列表、客户端模型 |
| [LibraryCore/Functions.cs](LibraryCore/Functions.cs) | — | 工具函数（距离计算、方向转换、随机数等） |
| [LibraryCore/ConfigReader.cs](LibraryCore/ConfigReader.cs) | — | 配置文件读取器 |

### SystemModels（系统数据模型，对应 System.db 表）

| 文件 | 关键内容 |
|------|---------|
| [LibraryCore/SystemModels/MagicInfo.cs](LibraryCore/SystemModels/MagicInfo.cs) | 技能数据（MP消耗、CD、基础威力、等级威力） |
| [LibraryCore/SystemModels/MonsterInfo.cs](LibraryCore/SystemModels/MonsterInfo.cs) | 怪物数据（HP、攻防、MoveDelay、AttackDelay） |
| [LibraryCore/SystemModels/ItemInfo.cs](LibraryCore/SystemModels/ItemInfo.cs) | 物品数据（类型、重量、属性） |
| [LibraryCore/SystemModels/MapInfo.cs](LibraryCore/SystemModels/MapInfo.cs) | 地图数据（区域、传送点） |
| [LibraryCore/SystemModels/CompanionInfo.cs](LibraryCore/SystemModels/CompanionInfo.cs) | 伴侣造型（MonsterInfo关联） |
| [LibraryCore/SystemModels/CompanionLevelInfo.cs](LibraryCore/SystemModels/CompanionLevelInfo.cs) | 伴侣等级参数（格数/负重/饥饿上限） |
| [LibraryCore/SystemModels/CompanionSkillInfo.cs](LibraryCore/SystemModels/CompanionSkillInfo.cs) | 伴侣技能池（Level/StatType/MaxAmount/Weight） |
| [LibraryCore/SystemModels/BaseStat.cs](LibraryCore/SystemModels/BaseStat.cs) | 职业基础属性 |
| [LibraryCore/SystemModels/DropInfo.cs](LibraryCore/SystemModels/DropInfo.cs) | 掉落表 |

### MirDB（数据库框架）

| 文件 | 关键内容 |
|------|---------|
| [LibraryCore/MirDB/DBCollection.cs](LibraryCore/MirDB/DBCollection.cs) | 数据库集合管理 |
| [LibraryCore/MirDB/DBBindingList.cs](LibraryCore/MirDB/DBBindingList.cs) | 绑定列表 |
| [LibraryCore/MirDB/Attributes.cs](LibraryCore/MirDB/Attributes.cs) | 字段属性标注 |

### Network（网络协议）

| 文件 | 关键内容 |
|------|---------|
| [LibraryCore/Network/](LibraryCore/Network/) | C/S 网络包定义 |

---

## 二、ServerLibrary（服务端核心）

### 核心引擎

| 文件 | 行数 | 关键内容 |
|------|:----:|---------|
| [ServerLibrary/Envir/SEnvir.cs](ServerLibrary/Envir/SEnvir.cs) | ~4000 | 服务端主循环、对象管理、地图加载、数据库操作 |
| [ServerLibrary/Envir/SConnection.cs](ServerLibrary/Envir/SConnection.cs) | — | 连接管理 |
| [ServerLibrary/Envir/Config.cs](ServerLibrary/Envir/Config.cs) | — | 服务端配置 |
| [ServerLibrary/Envir/EmailService.cs](ServerLibrary/Envir/EmailService.cs) | — | 邮件服务 |
| [ServerLibrary/Envir/WebServer.cs](ServerLibrary/Envir/WebServer.cs) | — | Web API 服务 |

### 游戏对象（Models/）

| 文件 | 行数 | 关键方法 |
|------|:----:|---------|
| [ServerLibrary/Models/PlayerObject.cs](ServerLibrary/Models/PlayerObject.cs) | **16525** | 玩家所有逻辑（技能/物品/交易/PK/任务/装备） |
| [ServerLibrary/Models/MonsterObject.cs](ServerLibrary/Models/MonsterObject.cs) | 3139 | 怪物基类（AI/属性/召唤/驯服/掉落） |
| [ServerLibrary/Models/MapObject.cs](ServerLibrary/Models/MapObject.cs) | 1860 | 地图对象基类（移动/Buff/属性/战斗接口） |
| [ServerLibrary/Models/MagicObject.cs](ServerLibrary/Models/MagicObject.cs) | 352 | 技能基类（MagicCast/MagicComplete/ModifyPower） |
| [ServerLibrary/Models/Map.cs](ServerLibrary/Models/Map.cs) | 706 | 地图管理（格子系统/GetCells/寻路） |
| [ServerLibrary/Models/NPCObject.cs](ServerLibrary/Models/NPCObject.cs) | — | NPC 逻辑 |
| [ServerLibrary/Models/SpellObject.cs](ServerLibrary/Models/SpellObject.cs) | — | 法术对象（AOE持续效果） |

#### PlayerObject.cs 核心方法索引

| 方法 | 行号 | 说明 |
|------|:----:|------|
| `ProcessAction()` | L341 | 延迟动作处理（DelayedAction 回调） |
| `RefreshStats()` | L2037 | 玩家属性刷新（装备/Buff/基础属性） |
| `CompanionRefreshBuff()` | L3203 | 伴侣技能属性叠加到主人 Buff |
| `Magic()` | L13455 | 技能施放入口（接收 C.Magic 包） |
| `MagicAttack()` | L14066 | 技能伤害结算（power 计算/元素/抗性/减速） |
| `Attacked()` | L14298 | 玩家受击（红毒/转生/魔法盾/暴击） |
| `GetElementPower()` | L15269 | 元素攻击力计算 |

#### MonsterObject.cs 核心方法索引

| 方法 | 行号 | 说明 |
|------|:----:|------|
| `RefreshStats()` | L706 | 怪物属性刷新（SummonLevel加成） |
| `ProcessAction()` | L897 | 怪物延迟动作 |
| `Process()` | L925 | 怪物 Process 主循环 |
| `ProcessAI()` | L962 | 怪物 AI 主循环 |
| `UnTame()` | L1010 | 解除驯服 |
| `PetRecall()` | L1020 | 宠物召回 |
| `UpdateMoveTime()` | L2339 | 移动时间更新（MoveDelay 控制） |
| `Attacked()` | L2359 | 怪物受击 |

#### MapObject.cs 核心方法索引

| 方法 | 行号 | 说明 |
|------|:----:|------|
| `CanMove` | L86 | 移动许可判断（MoveTime/ActionTime/毒/束缚） |
| `ProcessAction()` | L778 | 延迟动作虚方法 |
| `RefreshStats()` | L1159 | 属性刷新虚方法 |
| `Attacked()` | L1562 | 受击虚方法 |
| `GetMC()` | L1753 | 魔法攻击力（幸运值影响取最大值概率） |
| `GetMR()` | L1837 | 魔法防御力（随机 MinMR~MaxMR） |

### 技能系统（Models/Magics/）

#### Warrior（战士 · 37个技能文件 · 2575行）

| 文件 | 中文名 | 类型 |
|------|--------|------|
| [Warrior/Swordsmanship.cs](ServerLibrary/Models/Magics/Warrior/Swordsmanship.cs) | 基础剑法 | 被动 |
| [Warrior/Thrusting.cs](ServerLibrary/Models/Magics/Warrior/Thrusting.cs) | 刺杀剑术 | 主动 |
| [Warrior/HalfMoon.cs](ServerLibrary/Models/Magics/Warrior/HalfMoon.cs) | 半月弯刀 | 主动 |
| [Warrior/FlamingSword.cs](ServerLibrary/Models/Magics/Warrior/FlamingSword.cs) | 烈火剑法 | 主动 |
| [Warrior/ShoulderDash.cs](ServerLibrary/Models/Magics/Warrior/ShoulderDash.cs) | 野蛮冲撞 | 主动 |
| [Warrior/FireSword.cs](ServerLibrary/Models/Magics/Warrior/FireSword.cs) | 烈火剑法(高级) | 主动 |
| [Warrior/BladeStorm.cs](ServerLibrary/Models/Magics/Warrior/BladeStorm.cs) | 逐日剑法 | 主动 |
| [Warrior/DragonRise.cs](ServerLibrary/Models/Magics/Warrior/DragonRise.cs) | 龙升 | 主动 |
| [Warrior/SeismicSlam.cs](ServerLibrary/Models/Magics/Warrior/SeismicSlam.cs) | 地震斩 | 主动 |
| [Warrior/ElementalSwords.cs](ServerLibrary/Models/Magics/Warrior/ElementalSwords.cs) | 元素剑法 | 主动 |
| [Warrior/Invincibility.cs](ServerLibrary/Models/Magics/Warrior/Invincibility.cs) | 无敌 | 主动 |
| [Warrior/DefensiveMastery.cs](ServerLibrary/Models/Magics/Warrior/DefensiveMastery.cs) | 防御精通 | 被动 |
| [Warrior/ReflectDamage.cs](ServerLibrary/Models/Magics/Warrior/ReflectDamage.cs) | 反伤 | 主动 |
| [Warrior/Might.cs](ServerLibrary/Models/Magics/Warrior/Might.cs) | 力量 | 被动 |
| [Warrior/Defiance.cs](ServerLibrary/Models/Magics/Warrior/Defiance.cs) | 铁布衫 | 主动 |
| [Warrior/HundredFist.cs](ServerLibrary/Models/Magics/Warrior/HundredFist.cs) | 百裂拳 | 主动 |
| [Warrior/Assault.cs](ServerLibrary/Models/Magics/Warrior/Assault.cs) | 冲拳 | 主动 |
| [Warrior/Fetter.cs](ServerLibrary/Models/Magics/Warrior/Fetter.cs) | 束缚 | 主动 |
| [Warrior/Beckon.cs](ServerLibrary/Models/Magics/Warrior/Beckon.cs) | 召唤 | 主动 |
| [Warrior/MassBeckon.cs](ServerLibrary/Models/Magics/Warrior/MassBeckon.cs) | 群体召唤 | 主动 |
| [Warrior/Interchange.cs](ServerLibrary/Models/Magics/Warrior/Interchange.cs) | 移形换位 | 主动 |
| [Warrior/Shuriken.cs](ServerLibrary/Models/Magics/Warrior/Shuriken.cs) | 手里剑 | 主动 |
| [Warrior/TaecheonSword.cs](ServerLibrary/Models/Magics/Warrior/TaecheonSword.cs) | 天剑 | 主动 |
| [Warrior/CrushingWave.cs](ServerLibrary/Models/Magics/Warrior/CrushingWave.cs) | 崩浪 | 主动 |
| [Warrior/DestructiveSurge.cs](ServerLibrary/Models/Magics/Warrior/DestructiveSurge.cs) | 破坏冲锋 | 主动 |
| [Warrior/DefensiveBlow.cs](ServerLibrary/Models/Magics/Warrior/DefensiveBlow.cs) | 防守反击 | 主动 |
| [Warrior/OffensiveBlow.cs](ServerLibrary/Models/Magics/Warrior/OffensiveBlow.cs) | 进攻反击 | 主动 |
| [Warrior/PotionMastery.cs](ServerLibrary/Models/Magics/Warrior/PotionMastery.cs) | 炼药术 | 被动 |
| [Warrior/AdvancedPotionMastery.cs](ServerLibrary/Models/Magics/Warrior/AdvancedPotionMastery.cs) | 高级炼药术 | 被动 |
| [Warrior/SwiftBlade.cs](ServerLibrary/Models/Magics/Warrior/SwiftBlade.cs) | 迅刃 | 被动 |
| [Warrior/Slaying.cs](ServerLibrary/Models/Magics/Warrior/Slaying.cs) | 屠戮 | 被动 |
| [Warrior/Endurance.cs](ServerLibrary/Models/Magics/Warrior/Endurance.cs) | 耐力 | 被动 |
| [Warrior/MagicImmunity.cs](ServerLibrary/Models/Magics/Warrior/MagicImmunity.cs) | 魔法免疫 | 被动 |
| [Warrior/PhysicalImmunity.cs](ServerLibrary/Models/Magics/Warrior/PhysicalImmunity.cs) | 物理免疫 | 被动 |

#### Wizard（法师 · 46个技能文件 · 4623行）

| 文件 | 中文名 | 类型 |
|------|--------|------|
| [Wizard/FireBall.cs](ServerLibrary/Models/Magics/Wizard/FireBall.cs) | 火球术 | 攻击 |
| [Wizard/GreatFireBall.cs](ServerLibrary/Models/Magics/Wizard/) | 大火球 | 攻击 |
| [Wizard/FireWall.cs](ServerLibrary/Models/Magics/Wizard/FireWall.cs) | 火墙 | 持续 |
| [Wizard/FireStorm.cs](ServerLibrary/Models/Magics/Wizard/FireStorm.cs) | 火焰风暴 | 群攻 |
| [Wizard/IceStorm.cs](ServerLibrary/Models/Magics/Wizard/IceStorm.cs) | **冰咆哮（含详细执行链路注释）** | 群攻 |
| [Wizard/IceDragon.cs](ServerLibrary/Models/Magics/Wizard/IceDragon.cs) | 冰龙 | 召唤 |
| [Wizard/LightningBall.cs](ServerLibrary/Models/Magics/Wizard/LightningBall.cs) | 雷电球 | 攻击 |
| [Wizard/LightningBeam.cs](ServerLibrary/Models/Magics/Wizard/LightningBeam.cs) | 激光 | 直线 |
| [Wizard/LightningStrike.cs](ServerLibrary/Models/Magics/Wizard/LightningStrike.cs) | 天雷 | 攻击 |
| [Wizard/LightningWave.cs](ServerLibrary/Models/Magics/Wizard/LightningWave.cs) | 雷光波 | 群攻 |
| [Wizard/ChainLightning.cs](ServerLibrary/Models/Magics/Wizard/ChainLightning.cs) | 闪电链 | 连锁 |
| [Wizard/Teleportation.cs](ServerLibrary/Models/Magics/Wizard/Teleportation.cs) | 瞬移 | 位移 |
| [Wizard/Repulsion.cs](ServerLibrary/Models/Magics/Wizard/Repulsion.cs) | 排斥 | 控制 |
| [Wizard/ElectricShock.cs](ServerLibrary/Models/Magics/Wizard/ElectricShock.cs) | 电击术（驯服怪物） | 控制 |
| [Wizard/MagicShield.cs](ServerLibrary/Models/Magics/Wizard/MagicShield.cs) | 魔法盾 | 防御 |
| [Wizard/SuperiorMagicShield.cs](ServerLibrary/Models/Magics/Wizard/SuperiorMagicShield.cs) | 高级魔法盾 | 防御 |
| [Wizard/MirrorImage.cs](ServerLibrary/Models/Magics/Wizard/MirrorImage.cs) | 幻影 | 辅助 |
| [Wizard/FrostBite.cs](ServerLibrary/Models/Magics/Wizard/FrostBite.cs) | 霜冻 | 控制 |
| [Wizard/IceBlades.cs](ServerLibrary/Models/Magics/Wizard/IceBlades.cs) | 冰刃 | 攻击 |
| [Wizard/IceAura.cs](ServerLibrary/Models/Magics/Wizard/IceAura.cs) | 冰环 | 范围 |
| [Wizard/FrozenEarth.cs](ServerLibrary/Models/Magics/Wizard/FrozenEarth.cs) | 冰封大地 | 控制 |
| [Wizard/GreaterFrozenEarth.cs](ServerLibrary/Models/Magics/Wizard/GreaterFrozenEarth.cs) | 高级冰封 | 控制 |
| [Wizard/IceBreaker.cs](ServerLibrary/Models/Magics/Wizard/IceBreaker.cs) | 破冰 | 攻击 |
| [Wizard/IceRain.cs](ServerLibrary/Models/Magics/Wizard/IceRain.cs) | 冰雨 | 群攻 |
| [Wizard/IceBolt.cs](ServerLibrary/Models/Magics/Wizard/IceBolt.cs) | 冰箭 | 攻击 |
| [Wizard/Asteroid.cs](ServerLibrary/Models/Magics/Wizard/Asteroid.cs) | 天之怒火 | 群攻 |
| [Wizard/MeteorShower.cs](ServerLibrary/Models/Magics/Wizard/MeteorShower.cs) | 流星雨 | 群攻 |
| [Wizard/DragonTornado.cs](ServerLibrary/Models/Magics/Wizard/DragonTornado.cs) | 龙卷风 | 群攻 |
| [Wizard/Tornado.cs](ServerLibrary/Models/Magics/Wizard/Tornado.cs) | 旋风 | 控制 |
| [Wizard/Tempest.cs](ServerLibrary/Models/Magics/Wizard/Tempest.cs) | 暴风 | 群攻 |
| [Wizard/Storm.cs](ServerLibrary/Models/Magics/Wizard/Storm.cs) | 风暴 | 群攻 |
| [Wizard/Cyclone.cs](ServerLibrary/Models/Magics/Wizard/Cyclone.cs) | 气旋 | 群攻 |
| [Wizard/FrozenDragon.cs](ServerLibrary/Models/Magics/Wizard/FrozenDragon.cs) | 冰龙破 | 攻击 |
| [Wizard/JudgementOfHeaven.cs](ServerLibrary/Models/Magics/Wizard/JudgementOfHeaven.cs) | 天罚 | 攻击 |
| [Wizard/ThunderBolt.cs](ServerLibrary/Models/Magics/Wizard/ThunderBolt.cs) | 雷击 | 攻击 |
| [Wizard/ThunderStrike.cs](ServerLibrary/Models/Magics/Wizard/ThunderStrike.cs) | 雷暴 | 攻击 |
| [Wizard/Renounce.cs](ServerLibrary/Models/Magics/Wizard/Renounce.cs) | 牺牲（扣血换魔） | 辅助 |
| [Wizard/Shocked.cs](ServerLibrary/Models/Magics/Wizard/Shocked.cs) | 震慑 | 控制 |
| [Wizard/ScortchedEarth.cs](ServerLibrary/Models/Magics/Wizard/ScortchedEarth.cs) | 焦土 | 持续 |
| [Wizard/FireBounce.cs](ServerLibrary/Models/Magics/Wizard/FireBounce.cs) | 反弹火球 | 攻击 |
| [Wizard/GeoManipulation.cs](ServerLibrary/Models/Magics/Wizard/GeoManipulation.cs) | 地脉操控 | 辅助 |
| [Wizard/ExpelUndead.cs](ServerLibrary/Models/Magics/Wizard/ExpelUndead.cs) | 驱逐亡灵 | 控制 |
| [Wizard/Burning.cs](ServerLibrary/Models/Magics/Wizard/Burning.cs) | 燃烧 | 持续 |
| [Wizard/GustBlast.cs](ServerLibrary/Models/Magics/Wizard/GustBlast.cs) | 疾风弹 | 攻击 |
| [Wizard/ElementalHurricane.cs](ServerLibrary/Models/Magics/Wizard/ElementalHurricane.cs) | 元素风暴 | 群攻 |
| [Wizard/BlowEarth.cs](ServerLibrary/Models/Magics/Wizard/BlowEarth.cs) | 吹地 | 辅助 |
| [Wizard/AdamantineFireBall.cs](ServerLibrary/Models/Magics/Wizard/AdamantineFireBall.cs) | 金刚火球 | 攻击 |

#### Taoist（道士 · 51个技能文件 · 3998行）

| 文件 | 中文名 | 类型 |
|------|--------|------|
| [Taoist/Heal.cs](ServerLibrary/Models/Magics/Taoist/Heal.cs) | 治愈术 | 治疗 |
| [Taoist/MassHeal.cs](ServerLibrary/Models/Magics/Taoist/MassHeal.cs) | 群体治愈 | 治疗 |
| [Taoist/PoisonDust.cs](ServerLibrary/Models/Magics/Taoist/PoisonDust.cs) | 毒粉 | 控制 |
| [Taoist/GreaterPoisonDust.cs](ServerLibrary/Models/Magics/Taoist/GreaterPoisonDust.cs) | 高级毒粉 | 控制 |
| [Taoist/ExplosiveTalisman.cs](ServerLibrary/Models/Magics/Taoist/ExplosiveTalisman.cs) | 爆裂符 | 攻击 |
| [Taoist/ImprovedExplosiveTalisman.cs](ServerLibrary/Models/Magics/Taoist/ImprovedExplosiveTalisman.cs) | 强化爆裂符 | 攻击 |
| [Taoist/SummonSkeleton.cs](ServerLibrary/Models/Magics/Taoist/SummonSkeleton.cs) | 召唤骷髅 | 召唤 |
| [Taoist/SummonShinsu.cs](ServerLibrary/Models/Magics/Taoist/SummonShinsu.cs) | 召唤神兽 | 召唤 |
| [Taoist/SummonJinSkeleton.cs](ServerLibrary/Models/Magics/Taoist/SummonJinSkeleton.cs) | 召唤金骷髅 | 召唤 |
| [Taoist/SummonDemonicCreature.cs](ServerLibrary/Models/Magics/Taoist/SummonDemonicCreature.cs) | 召唤恶魔 | 召唤 |
| [Taoist/SummonDead.cs](ServerLibrary/Models/Magics/Taoist/SummonDead.cs) | 召唤亡灵 | 召唤 |
| [Taoist/Invisibility.cs](ServerLibrary/Models/Magics/Taoist/Invisibility.cs) | 隐身术 | 辅助 |
| [Taoist/MassInvisibility.cs](ServerLibrary/Models/Magics/Taoist/MassInvisibility.cs) | 群体隐身 | 辅助 |
| [Taoist/TrapOctagon.cs](ServerLibrary/Models/Magics/Taoist/TrapOctagon.cs) | 困魔咒 | 控制 |
| [Taoist/Resurrection.cs](ServerLibrary/Models/Magics/Taoist/Resurrection.cs) | 复活术 | 辅助 |
| [Taoist/Purification.cs](ServerLibrary/Models/Magics/Taoist/Purification.cs) | 净化 | 辅助 |
| [Taoist/Neutralize.cs](ServerLibrary/Models/Magics/Taoist/Neutralize.cs) | 封魔 | 控制 |
| [Taoist/SoulResonance.cs](ServerLibrary/Models/Magics/Taoist/SoulResonance.cs) | 灵魂共鸣 | 辅助 |
| [Taoist/CelestialLight.cs](ServerLibrary/Models/Magics/Taoist/CelestialLight.cs) | 圣光 | 治疗 |
| [Taoist/EvilSlayer.cs](ServerLibrary/Models/Magics/Taoist/EvilSlayer.cs) | 灭魂 | 攻击 |
| [Taoist/GreaterEvilSlayer.cs](ServerLibrary/Models/Magics/Taoist/GreaterEvilSlayer.cs) | 高级灭魂 | 攻击 |
| [Taoist/SpiritSword.cs](ServerLibrary/Models/Magics/Taoist/SpiritSword.cs) | 灵魂剑 | 被动 |
| [Taoist/BloodLust.cs](ServerLibrary/Models/Magics/Taoist/BloodLust.cs) | 嗜血 | 被动 |
| [Taoist/CorpseExploder.cs](ServerLibrary/Models/Magics/Taoist/CorpseExploder.cs) | 尸爆 | 攻击 |
| [Taoist/ElementalSuperiority.cs](ServerLibrary/Models/Magics/Taoist/ElementalSuperiority.cs) | 元素强化 | 被动 |
| [Taoist/StrengthOfFaith.cs](ServerLibrary/Models/Magics/Taoist/StrengthOfFaith.cs) | 信仰之力 | 被动 |
| [Taoist/CursedDoll.cs](ServerLibrary/Models/Magics/Taoist/CursedDoll.cs) | 诅咒娃娃 | 控制 |
| [Taoist/DarkSoulPrison.cs](ServerLibrary/Models/Magics/Taoist/DarkSoulPrison.cs) | 暗魂牢笼 | 控制 |
| [Taoist/HeavenlySky.cs](ServerLibrary/Models/Magics/Taoist/HeavenlySky.cs) | 天堂 | 辅助 |
| [Taoist/DemonExplosion.cs](ServerLibrary/Models/Magics/Taoist/DemonExplosion.cs) | 恶魔爆炸 | 攻击 |
| [Taoist/CombatKick.cs](ServerLibrary/Models/Magics/Taoist/CombatKick.cs) | 战斗踢 | 控制 |
| [Taoist/ThunderKick.cs](ServerLibrary/Models/Magics/Taoist/ThunderKick.cs) | 雷霆踢 | 控制 |
| [Taoist/MagicResistance.cs](ServerLibrary/Models/Magics/Taoist/MagicResistance.cs) | 魔法抵抗 | 被动 |
| [Taoist/Resilience.cs](ServerLibrary/Models/Magics/Taoist/Resilience.cs) | 韧性 | 被动 |
| [Taoist/Infection.cs](ServerLibrary/Models/Magics/Taoist/Infection.cs) | 感染 | 持续 |
| [Taoist/PoisonCloud.cs](ServerLibrary/Models/Magics/Taoist/PoisonCloud.cs) | 毒雾 | 持续 |
| [Taoist/LifeSteal.cs](ServerLibrary/Models/Magics/Taoist/LifeSteal.cs) | 吸血 | 被动 |
| [Taoist/EmpoweredHealing.cs](ServerLibrary/Models/Magics/Taoist/EmpoweredHealing.cs) | 强化治疗 | 被动 |
| [Taoist/SearingLight.cs](ServerLibrary/Models/Magics/Taoist/SearingLight.cs) | 灼热之光 | 攻击 |
| [Taoist/BrainStorm.cs](ServerLibrary/Models/Magics/Taoist/BrainStorm.cs) | 雷暴 | 攻击 |
| [Taoist/BindingTalisman.cs](ServerLibrary/Models/Magics/Taoist/BindingTalisman.cs) | 束缚符 | 控制 |
| [Taoist/Parasite.cs](ServerLibrary/Models/Magics/Taoist/Parasite.cs) | 寄生 | 控制 |
| [Taoist/DemonicRecovery.cs](ServerLibrary/Models/Magics/Taoist/DemonicRecovery.cs) | 恶魔恢复 | 治疗 |
| [Taoist/Transparency.cs](ServerLibrary/Models/Magics/Taoist/Transparency.cs) | 透明 | 辅助 |
| [Taoist/Spiritualism.cs](ServerLibrary/Models/Magics/Taoist/Spiritualism.cs) | 灵性 | 被动 |

#### Assassin（刺客 · 56个技能文件 · 3691行）

| 文件 | 中文名 | 类型 |
|------|--------|------|
| [Assassin/Cloak.cs](ServerLibrary/Models/Magics/Assassin/Cloak.cs) | 潜行 | 辅助 |
| [Assassin/Stealth.cs](ServerLibrary/Models/Magics/Assassin/Stealth.cs) | 隐身 | 辅助 |
| [Assassin/Resolution.cs](ServerLibrary/Models/Magics/Assassin/Resolution.cs) | 决心 | 被动 |
| [Assassin/FatalBlow.cs](ServerLibrary/Models/Magics/Assassin/FatalBlow.cs) | 致命一击 | 主动 |
| [Assassin/CrescentMoon.cs](ServerLibrary/Models/Magics/Assassin/CrescentMoon.cs) | 月牙 | 攻击 |
| [Assassin/WraithGrip.cs](ServerLibrary/Models/Magics/Assassin/WraithGrip.cs) | 幽灵抓取 | 控制 |
| [Assassin/Rejuvenation.cs](ServerLibrary/Models/Magics/Assassin/Rejuvenation.cs) |  rejuvenation | 治疗 |
| [Assassin/DragonRepulse.cs](ServerLibrary/Models/Magics/Assassin/DragonRepulse.cs) | 龙波 | 攻击 |
| [Assassin/Evasion.cs](ServerLibrary/Models/Magics/Assassin/Evasion.cs) | 闪避 | 被动 |
| [Assassin/RagingWind.cs](ServerLibrary/Models/Magics/Assassin/RagingWind.cs) | 狂风 | 攻击 |
| [Assassin/FlashOfLight.cs](ServerLibrary/Models/Magics/Assassin/FlashOfLight.cs) | 闪光 | 控制 |
| [Assassin/Discipline.cs](ServerLibrary/Models/Magics/Assassin/Discipline.cs) | 戒律 | 被动 |
| [Assassin/Containment.cs](ServerLibrary/Models/Magics/Assassin/Containment.cs) | 封印 | 控制 |
| [Assassin/Vitality.cs](ServerLibrary/Models/Magics/Assassin/Vitality.cs) | 活力 | 被动 |
| [Assassin/DarkConversion.cs](ServerLibrary/Models/Magics/Assassin/DarkConversion.cs) | 黑暗转化 | 辅助 |
| [Assassin/DragonWave.cs](ServerLibrary/Models/Magics/Assassin/DragonWave.cs) | 龙波 | 攻击 |
| [Assassin/GhostWalk.cs](ServerLibrary/Models/Magics/Assassin/GhostWalk.cs) | 幽灵步 | 位移 |
| [Assassin/PoisonousCloud.cs](ServerLibrary/Models/Magics/Assassin/PoisonousCloud.cs) | 毒雾 | 持续 |
| [Assassin/FourWheels.cs](ServerLibrary/Models/Magics/Assassin/FourWheels.cs) | 四轮 | 攻击 |
| [Assassin/DragonBlood.cs](ServerLibrary/Models/Magics/Assassin/DragonBlood.cs) | 龙血 | 被动 |
| [Assassin/TheNewBeginning.cs](ServerLibrary/Models/Magics/Assassin/TheNewBeginning.cs) | 新生 | 被动 |
| [Assassin/Chain.cs](ServerLibrary/Models/Magics/Assassin/Chain.cs) | 链 | 攻击 |
| [Assassin/HellFire.cs](ServerLibrary/Models/Magics/Assassin/HellFire.cs) | 地狱火 | 攻击 |
| [Assassin/Karma.cs](ServerLibrary/Models/Magics/Assassin/Karma.cs) | 因果 | 被动 |
| [Assassin/Massacre.cs](ServerLibrary/Models/Magics/Assassin/Massacre.cs) | 屠杀 | 攻击 |
| [Assassin/BloodyFlower.cs](ServerLibrary/Models/Magics/Assassin/BloodyFlower.cs) | 血花 | 攻击 |
| [Assassin/WaningMoon.cs](ServerLibrary/Models/Magics/Assassin/WaningMoon.cs) | 残月 | 攻击 |
| [Assassin/PledgeOfBlood.cs](ServerLibrary/Models/Magics/Assassin/PledgeOfBlood.cs) | 血誓 | 辅助 |
| [Assassin/LastStand.cs](ServerLibrary/Models/Magics/Assassin/LastStand.cs) | 背水一战 | 被动 |
| [Assassin/Abyss.cs](ServerLibrary/Models/Magics/Assassin/Abyss.cs) | 深渊 | 控制 |
| [Assassin/Release.cs](ServerLibrary/Models/Magics/Assassin/Release.cs) | 释放 | 辅助 |
| [Assassin/Rake.cs](ServerLibrary/Models/Magics/Assassin/Rake.cs) | 耙 | 攻击 |
| [Assassin/Hemorrhage.cs](ServerLibrary/Models/Magics/Assassin/Hemorrhage.cs) | 出血 | 被动 |
| [Assassin/Shredding.cs](ServerLibrary/Models/Magics/Assassin/Shredding.cs) | 撕裂 | 被动 |
| [Assassin/DualWeaponSkills.cs](ServerLibrary/Models/Magics/Assassin/DualWeaponSkills.cs) | 双武器 | 被动 |
| [Assassin/SweetBrier.cs](ServerLibrary/Models/Magics/Assassin/SweetBrier.cs) | 甜蜜荆棘 | 攻击 |
| [Assassin/Concentration.cs](ServerLibrary/Models/Magics/Assassin/Concentration.cs) | 专注 | 被动 |
| [Assassin/FullBloom.cs](ServerLibrary/Models/Magics/Assassin/FullBloom.cs) | 盛开 | 攻击 |
| [Assassin/WhiteLotus.cs](ServerLibrary/Models/Magics/Assassin/WhiteLotus.cs) | 白莲 | 攻击 |
| [Assassin/RedLotus.cs](ServerLibrary/Models/Magics/Assassin/RedLotus.cs) | 红莲 | 攻击 |
| [Assassin/TouchOfTheDeparted.cs](ServerLibrary/Models/Magics/Assassin/TouchOfTheDeparted.cs) | 亡灵之触 | 控制 |
| [Assassin/MagicCombustion.cs](ServerLibrary/Models/Magics/Assassin/MagicCombustion.cs) | 魔法燃烧 | 攻击 |
| [Assassin/ChangeOfSeasons.cs](ServerLibrary/Models/Magics/Assassin/ChangeOfSeasons.cs) | 换季 | 辅助 |
| [Assassin/BurningFire.cs](ServerLibrary/Models/Magics/Assassin/BurningFire.cs) | 燃烧火焰 | 攻击 |
| [Assassin/FlamingDaggers.cs](ServerLibrary/Models/Magics/Assassin/FlamingDaggers.cs) | 火焰匕首 | 攻击 |
| [Assassin/FlameSplash.cs](ServerLibrary/Models/Magics/Assassin/FlameSplash.cs) | 火焰飞溅 | 攻击 |
| [Assassin/ChainOfFire.cs](ServerLibrary/Models/Magics/Assassin/ChainOfFire.cs) | 火焰链 | 攻击 |
| [Assassin/CalamityOfFullMoon.cs](ServerLibrary/Models/Magics/Assassin/CalamityOfFullMoon.cs) | 满月之灾 | 攻击 |
| [Assassin/ElementalPuppet.cs](ServerLibrary/Models/Magics/Assassin/ElementalPuppet.cs) | 元素傀儡 | 召唤 |
| [Assassin/SummonPuppet.cs](ServerLibrary/Models/Magics/Assassin/SummonPuppet.cs) | 召唤傀儡 | 召唤 |
| [Assassin/ArtOfShadows.cs](ServerLibrary/Models/Magics/Assassin/ArtOfShadows.cs) | 影之术 | 辅助 |
| [Assassin/AdventOfDemon.cs](ServerLibrary/Models/Magics/Assassin/AdventOfDemon.cs) | 恶魔降临 | 主动 |
| [Assassin/AdventOfDevil.cs](ServerLibrary/Models/Magics/Assassin/AdventOfDevil.cs) | 魔鬼降临 | 主动 |
| [Assassin/VineTreeDance.cs](ServerLibrary/Models/Magics/Assassin/VineTreeDance.cs) | 藤蔓舞 | 攻击 |
| [Assassin/DanceOfSwallow.cs](ServerLibrary/Models/Magics/Assassin/DanceOfSwallow.cs) | 燕舞 | 攻击 |
| [Assassin/WillowDance.cs](ServerLibrary/Models/Magics/Assassin/WillowDance.cs) | 柳舞 | 攻击 |

### 怪物 AI（Models/Monsters/ · 约120个文件）

| 文件 | 说明 |
|------|------|
| [Monsters/Companion.cs](ServerLibrary/Models/Monsters/Companion.cs) | **伴侣宠物**（884行·瞬移跟随/自动拾取/背包/装备/技能/饥饿） |
| [Monsters/Shinsu.cs](ServerLibrary/Models/Monsters/Shinsu.cs) | 神兽召唤 |
| [Monsters/Guard.cs](ServerLibrary/Models/Monsters/Guard.cs) | 城市守卫 |
| [Monsters/CastleLord.cs](ServerLibrary/Models/Monsters/CastleLord.cs) | 城堡领主 |
| [Monsters/DragonQueen.cs](ServerLibrary/Models/Monsters/DragonQueen.cs) | 龙族女王 BOSS |
| [Monsters/DragonLord.cs](ServerLibrary/Models/Monsters/DragonLord.cs) | 龙族领主 BOSS |
| [Monsters/EmperorSaWoo.cs](ServerLibrary/Models/Monsters/EmperorSaWoo.cs) | 帝王 BOSS |
| [Monsters/ArchLichTaedu.cs](ServerLibrary/Models/Monsters/ArchLichTaedu.cs) | 大法师 BOSS |
| [Monsters/BanyoLordGuzak.cs](ServerLibrary/Models/Monsters/BanyoLordGuzak.cs) | 半兽人领主 BOSS |
| [Monsters/PachontheChaosbringer.cs](ServerLibrary/Models/Monsters/PachontheChaosbringer.cs) | 混沌使者 BOSS |
| [Monsters/QitiandashengAI.cs](ServerLibrary/Models/Monsters/QitiandashengAI.cs) | 齐天大圣 BOSS |
| [Monsters/RedMoonTheFallen.cs](ServerLibrary/Models/Monsters/RedMoonTheFallen.cs) | 赤月恶魔 BOSS |
| [Monsters/ZumaKing.cs](ServerLibrary/Models/Monsters/ZumaKing.cs) | 祖玛教主 BOSS |
| [Monsters/UmaKing.cs](ServerLibrary/Models/Monsters/UmaKing.cs) | 牛魔教主 BOSS |
| [Monsters/Monkey.cs](ServerLibrary/Models/Monsters/Monkey.cs) | 猴子（可拾取） |
| [Monsters/TreeMonster.cs](ServerLibrary/Models/Monsters/TreeMonster.cs) | 树怪 |
| [Monsters/ChristmasMonster.cs](ServerLibrary/Models/Monsters/ChristmasMonster.cs) | 圣诞怪 |
| [Monsters/HalloweenMonster.cs](ServerLibrary/Models/Monsters/HalloweenMonster.cs) | 万圣节怪 |

### 数据库模型（DBModels/）

| 文件 | 说明 |
|------|------|
| [DBModels/CharacterInfo.cs](ServerLibrary/DBModels/CharacterInfo.cs) | 角色信息（职业/等级/经验/属性） |
| [DBModels/UserItem.cs](ServerLibrary/DBModels/UserItem.cs) | 玩家物品（槽位/耐久/强化） |
| [DBModels/UserMagic.cs](ServerLibrary/DBModels/UserMagic.cs) | 玩家技能（等级/经验/**GetPower()**） |
| [DBModels/UserCompanion.cs](ServerLibrary/DBModels/UserCompanion.cs) | 伴侣数据（等级/饥饿/7技能属性/物品） |
| [DBModels/CompanionFilters.cs](ServerLibrary/DBModels/CompanionFilters.cs) | 伴侣拾取过滤器 |
| [DBModels/GuildInfo.cs](ServerLibrary/DBModels/GuildInfo.cs) | 行会信息 |
| [DBModels/GuildMemberInfo.cs](ServerLibrary/DBModels/GuildMemberInfo.cs) | 行会成员 |
| [DBModels/AuctionInfo.cs](ServerLibrary/DBModels/AuctionInfo.cs) | 拍卖行 |
| [DBModels/MailInfo.cs](ServerLibrary/DBModels/MailInfo.cs) | 邮件 |
| [DBModels/UserQuest.cs](ServerLibrary/DBModels/UserQuest.cs) | 任务进度 |
| [DBModels/BlockInfo.cs](ServerLibrary/DBModels/BlockInfo.cs) | IP封禁 |
| [DBModels/UserFortuneInfo.cs](ServerLibrary/DBModels/UserFortuneInfo.cs) | 幸运值 |
| [DBModels/UserDiscipline.cs](ServerLibrary/DBModels/UserDiscipline.cs) | 修炼系统 |
| [DBModels/UserCurrency.cs](ServerLibrary/DBModels/UserCurrency.cs) | 货币系统 |
| [DBModels/UserConquest.cs](ServerLibrary/DBModels/UserConquest.cs) | 攻城战数据 |

### 管理命令（Envir/Commands/）

| 目录 | 说明 |
|------|------|
| [Commands/Admin/](ServerLibrary/Envir/Commands/Command/Admin/) | 管理员命令（Ban/Kick/GiveGameGold/GiveSkills/CreateGuild/Goto 等） |
| [Commands/Player/](ServerLibrary/Envir/Commands/Command/Player/) | 玩家命令 |

---

## 三、Client（客户端）

### 场景（Scenes/）

| 文件 | 说明 |
|------|------|
| [Scenes/GameScene.cs](Client/Scenes/GameScene.cs) | 游戏主场景（地图渲染/玩家控制/技能释放） |
| [Scenes/LoginScene.cs](Client/Scenes/LoginScene.cs) | 登录场景 |
| [Scenes/SelectScene.cs](Client/Scenes/SelectScene.cs) | 角色选择场景 |
| [Scenes/Views/](Client/Scenes/Views/) | 39个 UI 视图文件 |

### 控件（Controls/）

| 文件 | 说明 |
|------|------|
| [Controls/DXControl.cs](Client/Controls/DXControl.cs) | UI 控件基类 |
| [Controls/DXWindow.cs](Client/Controls/DXWindow.cs) | 窗口基类 |
| [Controls/DXButton.cs](Client/Controls/DXButton.cs) | 按钮 |
| [Controls/DXLabel.cs](Client/Controls/DXLabel.cs) | 文本标签 |
| [Controls/DXTextBox.cs](Client/Controls/DXTextBox.cs) | 文本框 |
| [Controls/DXListBox.cs](Client/Controls/DXListBox.cs) | 列表框 |
| [Controls/DXItemCell.cs](Client/Controls/DXItemCell.cs) | 物品格子 |
| [Controls/DXItemGrid.cs](Client/Controls/DXItemGrid.cs) | 物品网格 |
| [Controls/DXTabControl.cs](Client/Controls/DXTabControl.cs) | 标签页 |
| [Controls/DXConfigWindow.cs](Client/Controls/DXConfigWindow.cs) | 设置窗口 |
| [Controls/DXMessageBox.cs](Client/Controls/DXMessageBox.cs) | 消息框 |
| [Controls/DXKeyBindWindow.cs](Client/Controls/DXKeyBindWindow.cs) | 快捷键设置 |

### 客户端模型（Models/）

| 文件 | 说明 |
|------|------|
| [Models/MapObject.cs](Client/Models/MapObject.cs) | 地图对象基类 |
| [Models/PlayerObject.cs](Client/Models/PlayerObject.cs) | 玩家对象（动画/装备外观） |
| [Models/MonsterObject.cs](Client/Models/MonsterObject.cs) | 怪物对象（动画/特效） |
| [Models/NPCObject.cs](Client/Models/NPCObject.cs) | NPC 对象 |
| [Models/ItemObject.cs](Client/Models/ItemObject.cs) | 地面物品对象 |
| [Models/SpellObject.cs](Client/Models/SpellObject.cs) | 法术效果对象 |
| [Models/UserObject.cs](Client/Models/UserObject.cs) | 玩家数据模型 |
| [Models/MirEffect.cs](Client/Models/MirEffect.cs) | 特效系统 |
| [Models/DamageInfo.cs](Client/Models/DamageInfo.cs) | 伤害数字显示 |

### 渲染（Rendering/）

| 目录 | 说明 |
|------|------|
| [Rendering/SharpDXD3D9/](Client/Rendering/SharpDXD3D9/) | Direct3D 9 渲染管线 |
| [Rendering/SharpDXD3D11/](Client/Rendering/SharpDXD3D11/) | Direct3D 11 渲染管线 |
| [Rendering/RenderingPipelineManager.cs](Client/Rendering/RenderingPipelineManager.cs) | 渲染管线管理器 |

### 网络与环境（Envir/）

| 文件 | 说明 |
|------|------|
| [Envir/CEnvir.cs](Client/Envir/CEnvir.cs) | 客户端环境（主循环/渲染/输入） |
| [Envir/CConnection.cs](Client/Envir/CConnection.cs) | 客户端网络连接 |
| [Envir/Config.cs](Client/Envir/Config.cs) | 客户端配置 |
| [Envir/DXSoundManager.cs](Client/Envir/DXSoundManager.cs) | 音效管理器 |

---

## 四、Server（服务端 GUI）

| 文件 | 说明 |
|------|------|
| [Server/SMain.cs](Server/SMain.cs) | 服务端主窗体 |
| [Server/Views/](Server/Views/) | 134个管理界面（角色/物品/地图/行会/怪物等编辑窗体） |

---

## 五、核心机制速查

### 伤害计算链路

```
PlayerObject.Magic()           → 技能入口（CD/蓝耗/施法距离校验）
  ↓
MagicObject.MagicCast()        → 施法阶段（目标选取/DelayedAction创建）
  ↓
MagicObject.MagicComplete()    → 结算阶段（逐格伤害判定）
  ↓
PlayerObject.MagicAttack()     → 伤害计算（power流水线）
  ├── ModifyPowerAdditionner()  → 加法层（GetPower + GetMC）
  ├── ModifyPowerMultiplier()   → 乘法层（系数调整）
  ├── power -= ob.GetMR()       → 怪物魔抗减免
  ├── 元素加成 / 元素抗性减免
  └── ob.Attacked()             → 最终扣血（暴击/红毒/魔法盾）
```

### 伴侣系统关键参数

| 参数 | 位置 | 值 |
|------|------|-----|
| 瞬移间隔 | `Globals.CompanionMoveDelay` | 100ms |
| 装备槽数 | `Globals.CompanionEquipmentSize` | 4 |
| 背包数组大小 | `Globals.CompanionInventorySize` | 30 |
| 最大可用格数 | `CompanionLevelInfo.InventorySpace` | Lv15时12格 |
| 最大负重 | `CompanionLevelInfo.InventoryWeight` | Lv15时800 |
| 饥饿上限 | `CompanionLevelInfo.Hunger` | Lv15时500 |
| 技能解锁等级 | `CompanionSkillInfo.Level` | 3/5/7/10/11/13/15 |

### 数据库文件

| 文件 | 说明 |
|------|------|
| `System.db` | 系统数据库（技能/怪物/物品/地图/NPC等配置数据，AES-256加密） |
| `UserData.db` | 用户数据库（角色/物品/行会/拍卖等运行时数据） |
| `System解析/*.txt` | System.db 的 TXT 导出（参数化可读） |

---

## 六、第三方资料

| 目录 | 说明 |
|------|------|
| `第三方资料/zircon-legend-server/` | Legend 服务端（技能实现对比参考） |
| `第三方资料/zircon-legend-client/` | Legend 客户端 |

---

> 本索引基于代码实际结构生成，用于快速定位文件位置。
> 如需更新，运行：`find ServerLibrary Client -name "*.cs" | sort`
