using Library;
using System;
using System.IO;
using System.Security.Cryptography;

namespace Server.Envir
{
    /// <summary>
    /// 服务端配置类，对应 Server.ini 配置文件
    /// 包含网络、系统、权限、邮件、Web服务、玩家、怪物、物品、倍率、钓鱼等所有服务端配置
    /// </summary>
    [ConfigPath(@".\Server.ini")]
    public static class Config
    {
        // ===== 网络配置 =====
        [ConfigSection("Network")]
        public static string IPAddress { get; set; } = "127.0.0.1";
        public static ushort Port { get; set; } = 7000;
        public static TimeSpan TimeOut { get; set; } = TimeSpan.FromSeconds(20);
        public static TimeSpan PingDelay { get; set; } = TimeSpan.FromSeconds(2);
        public static ushort UserCountPort { get; set; } = 3000;
        public static int MaxPacket { get; set; } = 50;
        public static TimeSpan PacketBanTime { get; set; } = TimeSpan.FromMinutes(5);
        public static string SyncRemotePreffix { get; set; } = "http://127.0.0.1:80/Command/";

        // ===== 系统配置 =====
        [ConfigSection("System")]
        public static bool CheckVersion { get; set; } = true;
        public static string VersionPath { get; set; } = @".\Zircon.dll";

        public static string MapPath { get; set; } = @".\Map\";
        public static byte[] ClientHash;
        public static string MasterPassword { get; set; } = @"REDACTED";
        public static string SyncKey { get; set; } = "REDACTED";
        public static string ClientPath { get; set; }
        public static DateTime ReleaseDate { get; set; } = new DateTime(2017, 12, 22, 18, 00, 00, DateTimeKind.Utc);
        public static bool TestServer { get; set; } = false;
        public static string StarterGuildName { get; set; } = "Starter Guild";
        public static bool LazyLoadMaps { get; set; } = true;
        public static DateTime EasterEventEnd { get; set; } = new DateTime(2018, 04, 09, 00, 00, 00, DateTimeKind.Utc);
        public static DateTime HalloweenEventEnd { get; set; } = new DateTime(2018, 11, 07, 00, 00, 00, DateTimeKind.Utc);
        public static DateTime ChristmasEventEnd { get; set; } = new DateTime(2019, 01, 03, 00, 00, 00, DateTimeKind.Utc);
        public static TimeSpan DBSaveDelay { get; set; } = TimeSpan.FromMinutes(5);
        public static bool EncryptionEnabled { get; set; } = false;
        public static string EncryptionKey { get; set; } = string.Empty;

        // ===== 权限控制 =====
        [ConfigSection("Control")]
        public static bool AllowLogin { get; set; } = true;
        public static bool AllowNewAccount { get; set; } = true;
        public static bool AllowChangePassword { get; set; } = true;

        public static bool AllowRequestPasswordReset { get; set; } = true;
        public static bool AllowWebResetPassword { get; set; } = true;
        public static bool AllowManualResetPassword { get; set; } = true;

        public static bool AllowDeleteAccount { get; set; } = true;

        public static bool AllowManualActivation { get; set; } = true;
        public static bool AllowWebActivation { get; set; } = true;
        public static bool AllowRequestActivation { get; set; } = true;
        public static bool AllowSystemDBSync { get; set; } = false;

        public static bool AllowNewCharacter { get; set; } = true;
        public static bool AllowDeleteCharacter { get; set; } = true;
        public static bool AllowStartGame { get; set; }
        public static TimeSpan RelogDelay { get; set; } = TimeSpan.FromSeconds(10);
        public static bool AllowWarrior { get; set; } = true;
        public static bool AllowWizard { get; set; } = true;
        public static bool AllowTaoist { get; set; } = true;
        public static bool AllowAssassin { get; set; } = true;

        // ===== 邮件服务配置 =====
        [ConfigSection("Mail")]
        public static string MailServer { get; set; } = @"smtp.gmail.com";
        public static int MailPort { get; set; } = 587;
        public static bool MailUseSSL { get; set; } = true;
        public static string MailAccount { get; set; } = @"admin@zirconserver.com";
        public static string MailPassword { get; set; } = @"REDACTED";
        public static string MailFrom { get; set; } = "admin@zirconserver.com";
        public static string MailDisplayName { get; set; } = "Admin";

        // ===== Web 服务配置（账号激活、密码重置等 HTTP 接口） =====
        [ConfigSection("WebServer")]
        public static bool EnableWebServer { get; set; } = false;
        public static string WebPrefix { get; set; } = @"http://*:80/Command/";
        public static string WebCommandLink { get; set; } = @"https://www.zirconserver.com/Command";

        public static string ActivationSuccessLink { get; set; } = @"https://www.zirconserver.com/activation-successful/";
        public static string ActivationFailLink { get; set; } = @"https://www.zirconserver.com/activation-unsuccessful/";
        public static string ResetSuccessLink { get; set; } = @"https://www.zirconserver.com/password-reset-successful/";
        public static string ResetFailLink { get; set; } = @"https://www.zirconserver.com/password-reset-unsuccessful/";
        public static string DeleteSuccessLink { get; set; } = @"https://www.zirconserver.com/account-deletetion-successful/";
        public static string DeleteFailLink { get; set; } = @"https://www.zirconserver.com/account-deletetion-unsuccessful/";

        public static string BuyPrefix { get; set; } = @"http://*:80/BuyGameGold/";
        public static string BuyAddress { get; set; } = @"http://145.239.204.13/BuyGameGold";
        public static string IPNPrefix { get; set; } = @"http://*:80/IPN/";
        public static string ReceiverEMail { get; set; } = @"REDACTED";
        public static bool ProcessGameGold { get; set; } = true;
        public static bool AllowBuyGameGold { get; set; } = true;


        // ===== 玩家相关配置（视野、聊天延迟、最高等级、PK系统等） =====
        [ConfigSection("Players")]
        public static int MaxViewRange { get; set; } = 18;
        public static TimeSpan ShoutDelay { get; set; } = TimeSpan.FromSeconds(10);
        public static TimeSpan GlobalDelay { get; set; } = TimeSpan.FromSeconds(60);
        public static int MaxLevel { get; set; } = 10;
        public static int DayCycleCount { get; set; } = 3;
        public static int SkillExp { get; set; } = 3;
        public static bool AllowObservation { get; set; } = true;
        public static TimeSpan BrownDuration { get; set; } = TimeSpan.FromSeconds(60);
        public static int PKPointRate { get; set; } = 50;
        public static TimeSpan PKPointTickRate { get; set; } = TimeSpan.FromSeconds(60);
        public static int RedPoint { get; set; } = 200;
        public static TimeSpan PvPCurseDuration { get; set; } = TimeSpan.FromMinutes(60);
        public static int PvPCurseRate { get; set; } = 4;
        public static TimeSpan AutoReviveDelay { get; set; } = TimeSpan.FromMinutes(10);
        public static TimeSpan RankChangeResetDelay { get; set; } = TimeSpan.FromHours(24);
        public static bool EnableStruck { get; set; } = false;
        public static bool EnableHermit { get; set; } = false;

        // ===== 怪物配置（尸体保留时间、采集时间等） =====
        [ConfigSection("Monsters")]
        public static TimeSpan DeadDuration { get; set; } = TimeSpan.FromMinutes(1);
        public static TimeSpan HarvestDuration { get; set; } = TimeSpan.FromMinutes(5);
        public static int MysteryShipRegionIndex { get; set; } = 0;
        public static int LairRegionIndex { get; set; } = 0;

        // ===== 物品配置（掉落保留时间、幸运值、强化等） =====
        [ConfigSection("Items")]
        public static TimeSpan DropDuration { get; set; } = TimeSpan.FromMinutes(60);
        public static int DropDistance { get; set; } = 5;
        public static int DropLayers { get; set; } = 5;
        public static int TorchRate { get; set; } = 10;
        public static TimeSpan SpecialRepairDelay { get; set; } = TimeSpan.FromHours(8);
        public static int MaxLuck { get; set; } = 7;
        public static int MaxCurse { get; set; } = -10;
        public static int CurseRate { get; set; } = 20;
        public static int LuckRate { get; set; } = 10;
        public static int MaxStrength { get; set; } = 5;
        public static int StrengthAddRate { get; set; } = 10;
        public static int StrengthLossRate { get; set; } = 20;
        public static bool DropVisibleOtherPlayers { get; set; } = false;
        public static bool EnableFortune { get; set; } = true;
        public static bool AdminStartInGamemasterMode { get; set; } = true;
        public static bool AdminStartInObserverMode { get; set; } = true;
        public static bool AdminStartInSupermanMode { get; set; } = true;

        // ===== 游戏倍率配置（经验、掉落、金币、技能、伙伴） =====
        [ConfigSection("Rates")]
        public static int ExperienceRate { get; set; } = 0;
        public static int DropRate { get; set; } = 0;
        public static int GoldRate { get; set; } = 0;
        public static int SkillRate { get; set; } = 0;
        public static int CompanionRate { get; set; } = 0;

        // ===== 钓鱼系统配置 =====
        [ConfigSection("Fishing")]
        public static bool FishEnablePerfectCatch { get; set; } = true;
        public static int FishNibbleChanceBase { get; set; } = 10;
        public static int FishPointsRequired { get; set; } = 50;
        public static int FishPointSuccessRewardMin { get; set; } = 2;
        public static int FishPointSuccessRewardMax { get; set; } = 5;
        public static int FishPointFailureRewardMin { get; set; } = 0;
        public static int FishPointFailureRewardMax { get; set; } = 5;

        public static void LoadVersion()
        {
            try
            {
                if (File.Exists(VersionPath))
                    using (FileStream stream = File.OpenRead(VersionPath))
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        ClientHash = sha256.ComputeHash(stream);
                    }
                else ClientHash = null;
            }
            catch (Exception ex)
            {
                SEnvir.Log(ex.ToString());
            }
        }
    }
}
