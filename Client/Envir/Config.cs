using Client.Rendering;
using Library;
using System;
using System.Drawing;

namespace Client.Envir
{
    /// <summary>
    /// 客户端配置类，对应 Zircon.ini 配置文件
    /// 使用 ConfigReader 反射机制自动读写配置项
    /// 所有配置项按 [Section] 分组，支持多种数据类型
    /// </summary>
    [ConfigPath(@".\Zircon.ini")]
    public static class Config
    {
        /// <summary>登录场景固定分辨率 1024x768</summary>
        public static readonly Size IntroSceneSize = new Size(1024, 768);

        public const string DefaultIPAddress = "127.0.0.1";
        public const int DefaultPort = 7000;

        // ===== 网络配置 =====
        [ConfigSection("Network")]
        /// <summary>是否使用自定义网络配置（否则使用默认值）</summary>
        public static bool UseNetworkConfig { get; set; } = false;
        /// <summary>服务器 IP 地址</summary>
        public static string IPAddress { get; set; } = DefaultIPAddress;
        /// <summary>服务器端口号</summary>
        public static int Port { get; set; } = DefaultPort;
        /// <summary>连接超时时间</summary>
        public static TimeSpan TimeOutDuration { get; set; } = TimeSpan.FromSeconds(15);

        // ===== 错误追踪配置 =====
        [ConfigSection("Audit")]
        /// <summary>是否启用 Sentry 错误追踪服务</summary>
        public static bool SentryEnabled { get; set; } = false;
        /// <summary>Sentry 数据源名称（DSN 连接字符串）</summary>
        public static string SentryDSN { get; set; } = "";


        // ===== 图形配置 =====
        [ConfigSection("Graphics")]
        /// <summary>是否全屏显示</summary>
        public static bool FullScreen { get; set; } = true;
        /// <summary>是否启用垂直同步（限制帧率与显示器刷新率同步）</summary>
        public static bool VSync { get; set; }
        /// <summary>是否限制 FPS（防止 CPU/GPU 过度占用）</summary>
        public static bool LimitFPS { get; set; }
        /// <summary>是否使用扩展登录场景（全分辨率显示）</summary>
        public static bool ExtendedLogin { get; set; }
        /// <summary>游戏窗口分辨率</summary>
        public static Size GameSize { get; set; } = IntroSceneSize;
        /// <summary>当前使用的渲染管线标识（SharpDXD3D9 或 SharpDXD3D11）</summary>
        public static string RenderingPipeline { get; set; } = RenderingPipelineIds.SharpDXD3D9;
        /// <summary>纹理缓存持续时间（超时后释放 GPU 纹理内存）</summary>
        public static TimeSpan CacheDuration { get; set; } = TimeSpan.FromMinutes(30);
        /// <summary>字体名称</summary>
        public static string FontName { get; set; } = "MS Sans Serif";
        /// <summary>地图文件存放路径</summary>
        public static string MapPath { get; set; } = @".\Map\";
        /// <summary>是否将鼠标锁定在窗口内</summary>
        public static bool ClipMouse { get; set; } = false;
        /// <summary>是否显示调试信息标签（FPS、坐标等）</summary>
        public static bool DebugLabel { get; set; } = false;
        /// <summary>字体大小调整系数</summary>
        public static float FontSizeMod { get; set; } = 0.0F;
        /// <summary>界面语言（English/Chinese）</summary>
        public static string Language { get; set; } = "English";
        /// <summary>是否使用无边框窗口模式</summary>
        public static bool Borderless { get; set; } = false;
        /// <summary>是否启用平滑移动（插值移动动画）</summary>
        public static bool SmoothMove { get; set; } = false;


        // ===== 音效配置 =====
        [ConfigSection("Sound")]
        /// <summary>窗口失焦时是否继续播放音效</summary>
        public static bool SoundInBackground { get; set; } = true;
        /// <summary>同一音效最大重叠播放次数</summary>
        public static int SoundOverLap { get; set; } = 5;
        /// <summary>系统音效音量（0-100）</summary>
        public static int SystemVolume { get; set; } = 25;
        /// <summary>系统音效是否静音</summary>
        public static bool SystemVolumeMuted { get; set; } = false;
        public static int MusicVolume { get; set; } = 25;
        public static bool MusicVolumeMuted { get; set; } = false;
        public static int PlayerVolume { get; set; } = 25;
        public static bool PlayerVolumeMuted { get; set; } = false;
        public static int MonsterVolume { get; set; } = 25;
        public static bool MonsterVolumeMuted { get; set; } = false;
        public static int MagicVolume { get; set; } = 25;
        public static bool MagicVolumeMuted { get; set; } = false;

        // ===== 登录配置 =====
        [ConfigSection("Login")]
        /// <summary>是否记住登录凭据</summary>
        public static bool RememberDetails { get; set; } = false;
        /// <summary>记住的邮箱地址</summary>
        public static string RememberedEMail { get; set; } = string.Empty;
        /// <summary>记住的密码（存储为加密值）</summary>
        public static string RememberedPassword { get; set; } = string.Empty;

        // ===== 游戏玩法配置 =====
        [ConfigSection("Game")]
        /// <summary>是否显示技能特效</summary>
        public static bool DrawEffects { get; set; } = true;
        /// <summary>是否显示粒子效果</summary>
        public static bool DrawParticles { get; set; } = false;
        /// <summary>是否显示天气效果</summary>
        public static bool DrawWeather { get; set; } = true;
        /// <summary>是否显示目标轮廓线</summary>
        public static bool ShowTargetOutline { get; set; } = true;
        /// <summary>是否显示地面物品名称</summary>
        public static bool ShowItemNames { get; set; } = true;
        /// <summary>是否显示怪物名称</summary>
        public static bool ShowMonsterNames { get; set; } = true;
        /// <summary>是否显示玩家名称</summary>
        public static bool ShowPlayerNames { get; set; } = true;
        /// <summary>是否显示玩家血条</summary>
        public static bool ShowUserHealth { get; set; } = true;
        /// <summary>是否显示怪物血条</summary>
        public static bool ShowMonsterHealth { get; set; } = true;
        /// <summary>是否显示伤害数字</summary>
        public static bool ShowDamageNumbers { get; set; } = true;
        public static bool EscapeCloseAll { get; set; } = false;
        public static bool ShiftOpenChat { get; set; } = true;
        public static bool SpecialRepair { get; set; } = true;
        public static bool RightClickDeTarget { get; set; } = true;
        public static bool HideChatBar { get; set; } = true;
        public static bool ShowMagicBarFrames { get; set; } = true;

        public static bool MonsterBoxExpanded { get; set; } = true;
        public static bool MonsterBoxVisible { get; set; } = true;
        public static bool QuestTrackerVisible { get; set; } = true;

        public static bool LogChat { get; set; } = true;

        public static int RankingClass { get; set; } = (int)RequiredClass.All;
        public static bool RankingOnline { get; set; } = true;
        public static string HighlightedItems { get; set; } = string.Empty;

        // ===== 聊天颜色配置 =====
        // 定义各聊天频道的前景色和背景色
        [ConfigSection("Colours")]
        public static Color LocalTextForeColour { get; set; } = Color.White;
        public static Color GMWhisperInTextForeColour { get; set; } = Color.Red;
        public static Color WhisperInTextForeColour { get; set; } = Color.Cyan;
        public static Color WhisperOutTextForeColour { get; set; } = Color.Aquamarine;
        public static Color GroupTextForeColour { get; set; } = Color.Plum;
        public static Color GuildTextForeColour { get; set; } = Color.LightPink;
        public static Color ShoutTextForeColour { get; set; } = Color.Yellow;
        public static Color GlobalTextForeColour { get; set; } = Color.Lime;
        public static Color ObserverTextForeColour { get; set; } = Color.Silver;
        public static Color HintTextForeColour { get; set; } = Color.AntiqueWhite;
        public static Color SystemTextForeColour { get; set; } = Color.Red;
        public static Color GainsTextForeColour { get; set; } = Color.GreenYellow;
        public static Color AnnouncementTextForeColour { get; set; } = Color.DarkBlue;

        public static Color LocalTextBackColour { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public static Color GMWhisperInTextBackColour { get; set; } = Color.FromArgb(200, 255, 255, 255);
        public static Color WhisperInTextBackColour { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public static Color WhisperOutTextBackColour { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public static Color GroupTextBackColour { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public static Color GuildTextBackColour { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public static Color ShoutTextBackColour { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public static Color GlobalTextBackColour { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public static Color ObserverTextBackColour { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public static Color HintTextBackColour { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public static Color SystemTextBackColour { get; set; } = Color.FromArgb(200, 255, 255, 255);
        public static Color GainsTextBackColour { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public static Color AnnouncementTextBackColour { get; set; } = Color.FromArgb(200, 255, 255, 255);
    }
}
