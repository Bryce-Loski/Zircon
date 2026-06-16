# Legend of Mir 3 Zircon

> 传奇3 Zircon 引擎，基于 C# / .NET 10，支持 Windows 平台。
>
> 上游仓库：[suprcode/mir3-zircon](https://github.com/Suprcode/mir3-zircon) | 社区论坛：[LOMCN](http://www.lomcn.org/forum/forumdisplay.php?735)

---

## 一、环境要求

| 依赖项 | 说明 |
|--------|------|
| **.NET 10 SDK** | 所有项目已升级到 `net10.0`，[下载 .NET 10](https://dotnet.microsoft.com/download/dotnet/10.0) |
| **Windows 10/11** | 客户端依赖 DirectX / Vulkan，服务端 GUI 依赖 DevExpress WinForms |
| **Visual Studio 2022+** | 推荐（可选，命令行也能编译） |
| **DevExpress v25.2** | 服务端 GUI 项目（Server）依赖，NuGet 会自动还原 |
| **Git LFS**（可选） | 若需大文件资源版本管理 |

---

## 二、资源文件获取

游戏运行需要以下资源文件，**不包含在本仓库中**：

| 文件 | 说明 | 获取方式 |
|------|------|---------|
| **System.db** | 游戏配置数据库（怪物、物品、地图、NPC、技能等全部数据） | 从上游 releases 或社区下载，放在服务端运行目录 |
| **Map/*.map** | 地图文件 | Launcher 自动下载，或手动放到 `Map/` 目录 |
| ***.lib** | 图库资源（WTL/Mir3 格式） | Launcher 自动下载 |
| **Sound/*.wav/.ogg** | 音频资源 | Launcher 自动下载 |

### Launcher 自动下载

Launcher 默认从 `https://mirfiles.com/resources/mir3/zircon/patch/` 下载 `PList.Bin` 清单和 `.gz` 压缩资源包，会自动解压到客户端目录。

修改下载源：编辑 `Launcher/Config.cs` 中的 `Host` 字段，或编译后修改 `Launcher.ini`。

---

## 三、编译与运行

### 编译（命令行）

```powershell
# 编译整个解决方案
dotnet build "Zircon Server.sln" -c Release

# 单独编译某个项目
dotnet build Server/Server.csproj -c Release
dotnet build ServerCore/ServerCore.csproj -c Release
dotnet build Client/Client.csproj -c Release
```

> **注意**：Client 项目只能在 Windows 上编译（依赖 DirectX / Vulkan SDK）。
> ServerCore（无头服务端）和 ServerLibrary 可跨平台编译。

### 运行服务端

有两种运行方式：

**方式 A：Server（带 GUI）**
```
Server.exe
```
- 基于 DevExpress WinForms 的管理界面
- 可查看在线玩家、实时日志、地图查看器、插件管理等
- 首次运行会自动生成 `Server.ini` 配置文件

**方式 B：ServerCore（无头/命令行）**
```
ServerCore.exe
```
- 纯控制台运行，适合 Linux 服务器部署（通过 Wine）或 Docker
- 按 `Ctrl+C` 优雅关闭
- 同样读取 `Server.ini`

### 服务端配置 Server.ini

首次运行自动生成，关键配置项：

```ini
[Network]
IPAddress = 127.0.0.1        # 监听地址
Port = 7000                  # 监听端口
UserCountPort = 3000         # 在线人数查询端口

[System]
MapPath = .\Map\             # 地图文件目录
TestServer = false           # 测试模式（true=跳过部分验证）
LazyLoadMaps = true          # 懒加载地图（减少启动内存）
DBSaveDelay = 00:05:00       # 数据库自动保存间隔
EncryptionEnabled = false    # 数据库加密开关
EncryptionKey =              # AES-256 密钥（Base64，32字节）

[Control]
AllowLogin = true            # 允许登录
AllowNewAccount = true       # 允许注册新账号
AllowChangePassword = true   # 允许修改密码
```

### 运行客户端

```
Client.exe
```

客户端连接地址在登录界面配置，或通过 `Config.cs` 中的默认设置。

### 运行 Launcher

```
Launcher.exe
```

Launcher 会自动下载/更新资源文件，然后启动 Client。

---

## 四、DIY 游戏内容

### 4.1 直接修改代码

| 想改什么 | 改哪里 |
|---------|--------|
| 技能伤害公式 | `ServerLibrary/Models/PlayerObject.cs` → `GetDC/MC/SC` 方法 |
| 怪物 AI | `ServerLibrary/Models/Monsters/*.cs`（每种怪物独立文件） |
| 伴侣瞬移速度 | `LibraryCore/Globals.cs` → `CompanionMoveDelay`（默认 100ms） |
| 背包大小 | `LibraryCore/Globals.cs` → `InventorySize`（默认 48） |
| 新增枚举值 | `LibraryCore/Enum.cs`（注意与 System.db 的兼容性） |
| 快捷键 | `Client/UserModels/KeyBindInfo.cs` → `KeyBindAction` 枚举 |
| 新增网络包 | `LibraryCore/Network/ClientPackets.cs` / `ServerPackets.cs` |
| 地图传送/回城逻辑 | `ServerLibrary/Models/PlayerObject.cs` → `Teleport()` |

### 4.2 修改 System.db（游戏数据）

System.db 是 MirDB 二进制格式，不能直接用文本编辑器打开。

**工具链（Python 脚本）位于 `System解析/` 目录**（需自行搭建）：

```bash
# 导出 System.db → 43个结构化 TXT 文件
python export_system_db.py <System.db路径> <输出目录>

# 修改 TXT 文件（如改物品属性、怪物属性、新增地图等）
# ...用任何文本编辑器修改...

# 导入回 System.db（自动备份原文件）
python import_system_db.py <System.db路径> <TXT目录>
```

导出的 TXT 文件示例（`System解析/` 目录下已有导出结果供参考）：

| 文件 | 内容 | 记录数 |
|------|------|:------:|
| `ItemInfo.txt` | 物品定义（名称、类型、等级要求等） | ~1384 |
| `ItemInfoStat.txt` | 物品属性加成 | ~37450 |
| `MonsterInfo.txt` | 怪物定义 | ~416 |
| `MonsterInfoStat.txt` | 怪物属性 | ~38128 |
| `MagicInfo.txt` | 技能定义 | ~151 |
| `MapInfo.txt` | 地图定义 | ~295 |
| `NPCInfo.txt` | NPC 定义 | ~1194 |
| `DropInfo.txt` | 掉落表 | ~127664 |
| `RespawnInfo.txt` | 刷新表 | ~20508 |
| `_汇总表.txt` | 所有表的记录数汇总 | 37 |

### 4.3 数据库加密

如需启用数据库加密（保护 System.db / Users.db 不被轻易修改）：

```ini
[System]
EncryptionEnabled = true
EncryptionKey = <Base64编码的32字节密钥>
```

密钥生成：`openssl rand -base64 32`

> 加密后客户端通过服务端 `GoodVersion` 包获取密钥，无需客户端额外配置。

---

## 五、开发工具

### 内置工具（C# 项目）

| 工具 | 用途 |
|------|------|
| **LibraryEditor** | 可视化编辑 `.lib` 图库（WTL/Mir3 格式），支持图层预览、碰撞区域编辑 |
| **ImageManager** | 批量图片格式转换（BMP/PNG → WTL/Mir3），用于制作图库资源 |
| **PatchManager** | 生成补丁包，配合 Launcher 实现客户端自动更新 |
| **PluginStandalone** | 独立运行插件（调试用），通过 App.config 指定插件 DLL 路径 |

### 命令行工具

| 工具 | 用途 |
|------|------|
| `Tools/convert_audio_to_ogg.cmd` | 批量将音频文件（wav/mp3/flac 等）转为 OGG 格式（需 ffmpeg） |

### 数据库工具（Python）

| 工具 | 用途 |
|------|------|
| `export_system_db.py` | 将 System.db 导出为结构化 TXT 文件（43 张表） |
| `import_system_db.py` | 将修改后的 TXT 导入回 System.db（基于 Index 精准匹配） |

> 导出结果已在 `System解析/` 目录供参考查阅，修改后通过 import 脚本回写即可。
>
> **注意**：TXT 中 `[INDEX=n]` 为记录标识，`Index` 字段为数据字段，导入时两者独立处理，不要混淆。

---

## 六、项目结构

```
Zircon/
├── LibraryCore/       # 共享核心：枚举(Enum.cs)、数据模型、网络包、加密、工具函数
├── ServerLibrary/     # 服务端核心：游戏逻辑、战斗、AI、DB模型
│   ├── Models/        # PlayerObject、MonsterObject、怪物AI（按种类分文件）
│   ├── DBModels/      # 数据库模型（AccountInfo、CharacterInfo 等）
│   └── Envir/         # SEnvir（主循环）、Config、网络管理
├── Client/            # 客户端：渲染（DX9/DX11/Vulkan）、场景、UI控件
│   ├── Scenes/        # GameScene、LoginScene、SelectScene
│   ├── Scenes/Views/  # 所有对话框（背包、技能、NPC、排行等）
│   └── Rendering/     # 渲染管线（D3D9/D3D11/Vulkan）
├── Server/            # 服务端 GUI（DevExpress WinForms）
├── ServerCore/        # 无头服务端（纯命令行）
├── Launcher/          # 启动器（自动下载资源）
├── PluginCore/        # 插件框架（接口定义 + 加载器）
├── PluginStandalone/  # 插件独立运行宿主
├── LibraryEditor/     # 图库编辑器
├── ImageManager/      # 图片转换工具
├── PatchManager/      # 补丁管理器
├── Patcher/           # 补丁应用工具
├── System解析/        # System.db 导出的 TXT 文件（参考用）
└── Tools/             # 辅助脚本（音频转换等）
```

---

## 七、快速开始

```powershell
# 1. 克隆仓库
git clone https://github.com/your-fork/mir3-zircon.git
cd mir3-zircon

# 2. 编译
dotnet build "Zircon Server.sln" -c Release

# 3. 准备资源
#    将 System.db 放到 Server/bin/Release/ 目录
#    创建 Map/ 目录并放入地图文件（或通过 Launcher 下载）

# 4. 启动服务端
cd Server/bin/Release
./Server.exe        # 或 ServerCore.exe（无头模式）

# 5. 启动客户端
cd Client/bin/Release
./Client.exe        # 或通过 Launcher.exe 自动更新后启动
```

---

## 八、常见问题

**Q: 编译报错 NETSDK1100（Client 项目）**
> Client 是 Windows-only 项目，macOS/Linux 无法编译。ServerLibrary 和 ServerCore 可跨平台。

**Q: 服务端启动后客户端连不上**
> 检查 `Server.ini` 中 `IPAddress` 和 `Port`，确保客户端连接地址一致。默认端口 7000。

**Q: 如何查看 System.db 的内容但不想搭建工具链**
> 直接查看 `System解析/` 目录，已有 43 张表的完整导出结果，可直接用文本编辑器阅读。

**Q: 修改了代码如何生效**
> 重新编译对应项目，替换 DLL 即可。服务端修改需要重启服务端，客户端修改需要重新分发。
