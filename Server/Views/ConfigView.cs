using Library;
using Library.SystemModels;
using Server.Envir;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using S = Library.Network.ServerPackets;

namespace Server.Views
{
    public partial class ConfigView : UserControl
    {
        public ConfigView()
        {
            InitializeComponent();
            this.SyncronizeRemoteButton.Click += SyncronizeRemoteButton_Click;
            this.SyncronizeLocalButton.Click += SyncronizeLocalButton_Click;
            this.DatabaseEncryptionButton.Click += DatabaseEncryptionButton_Click;
            this.CheckVersionButton.Click += CheckVersionButton_Click;

            // Set up ComboBox data sources
            MysteryShipRegionIndexEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            LairRegionIndexEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
        }

        private void DatabaseEncryptionButton_Click(object sender, EventArgs e)
        {
            var form = new DatabaseEncryptionForm();
            form.ShowDialog();
        }

        private void SyncronizeRemoteButton_Click(object sender, EventArgs e)
        {
            var form = new SyncForm();
            form.ShowDialog();
        }

        private void SyncronizeLocalButton_Click(object sender, EventArgs e)
        {
            SEnvir.Log($"Starting local syncronization...");

            SMain.Session.Save(true);

            File.Copy(SMain.Session.SystemPath, Path.Combine(Config.ClientPath, "Data", Path.GetFileName(SMain.Session.SystemPath)), true);

            SEnvir.Log($"Syncronization completed...");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadSettings();
        }

        public void LoadSettings()
        {
            //Network
            IPAddressEdit.Text = Config.IPAddress;
            PortEdit.Text = Config.Port.ToString();
            TimeOutEdit.Text = Config.TimeOut.ToString();
            PingDelayEdit.Text = Config.PingDelay.ToString();
            UserCountPortEdit.Text = Config.UserCountPort.ToString();
            MaxPacketEdit.Text = Config.MaxPacket.ToString();
            PacketBanTimeEdit.Text = Config.PacketBanTime.ToString();


            //Control
            AllowNewAccountEdit.Checked = Config.AllowNewAccount;
            AllowChangePasswordEdit.Checked = Config.AllowChangePassword;
            AllowLoginEdit.Checked = Config.AllowLogin;
            AllowNewCharacterEdit.Checked = Config.AllowNewCharacter;
            AllowDeleteCharacterEdit.Checked = Config.AllowDeleteCharacter;
            AllowStartGameEdit.Checked = Config.AllowStartGame;
            AllowWarriorEdit.Checked = Config.AllowWarrior;
            AllowWizardEdit.Checked = Config.AllowWizard;
            AllowTaoistEdit.Checked = Config.AllowTaoist;
            AllowAssassinEdit.Checked = Config.AllowAssassin;
            RelogDelayEdit.Text = Config.RelogDelay.ToString();
            AllowRequestPasswordResetEdit.Checked = Config.AllowRequestPasswordReset;
            AllowWebResetPasswordEdit.Checked = Config.AllowWebResetPassword;
            AllowManualResetPasswordEdit.Checked = Config.AllowManualResetPassword;
            AllowDeleteAccountEdit.Checked = Config.AllowDeleteAccount;
            AllowManualActivationEdit.Checked = Config.AllowManualActivation;
            AllowWebActivationEdit.Checked = Config.AllowWebActivation;
            AllowRequestActivationEdit.Checked = Config.AllowRequestActivation;

            //System
            CheckVersionEdit.Checked = Config.CheckVersion;
            VersionPathEdit.Text = Config.VersionPath;
            DBSaveDelayEdit.Text = Config.DBSaveDelay.ToString();
            MapPathEdit.Text = Config.MapPath;
            LazyLoadMapsEdit.Checked = Config.LazyLoadMaps;
            MasterPasswordEdit.Text = Config.MasterPassword;
            ClientPathEdit.Text = Config.ClientPath;
            ReleaseDateEdit.Value = Config.ReleaseDate;
            RabbitEventEndEdit.Value = Config.EasterEventEnd;

            //Mail
            MailServerEdit.Text = Config.MailServer;
            MailPortEdit.Text = Config.MailPort.ToString();
            MailUseSSLEdit.Checked = Config.MailUseSSL;
            MailAccountEdit.Text = Config.MailAccount;
            MailPasswordEdit.Text = Config.MailPassword;
            MailFromEdit.Text = Config.MailFrom;
            MailDisplayNameEdit.Text = Config.MailDisplayName;

            //WebServer
            WebPrefixEdit.Text = Config.WebPrefix;
            WebCommandLinkEdit.Text = Config.WebCommandLink;
            ActivationSuccessLinkEdit.Text = Config.ActivationSuccessLink;
            ActivationFailLinkEdit.Text = Config.ActivationFailLink;
            ResetSuccessLinkEdit.Text = Config.ResetSuccessLink;
            ResetFailLinkEdit.Text = Config.ResetFailLink;
            DeleteSuccessLinkEdit.Text = Config.DeleteSuccessLink;
            DeleteFailLinkEdit.Text = Config.DeleteFailLink;

            BuyPrefixEdit.Text = Config.BuyPrefix;
            BuyAddressEdit.Text = Config.BuyAddress;
            IPNPrefixEdit.Text = Config.IPNPrefix;
            ReceiverEMailEdit.Text = Config.ReceiverEMail;
            ProcessGameGoldEdit.Checked = Config.ProcessGameGold;
            AllowBuyGameGoldEdit.Checked = Config.AllowBuyGameGold;


            //Players
            MaxViewRangeEdit.Text = Config.MaxViewRange.ToString();
            ShoutDelayEdit.Text = Config.ShoutDelay.ToString();
            GlobalDelayEdit.Text = Config.GlobalDelay.ToString();
            MaxLevelEdit.Text = Config.MaxLevel.ToString();
            DayCycleCountEdit.Text = Config.DayCycleCount.ToString();
            SkillExpEdit.Text = Config.SkillExp.ToString();
            AllowObservationEdit.Checked = Config.AllowObservation;
            BrownDurationEdit.Text = Config.BrownDuration.ToString();
            PKPointRateEdit.Text = Config.PKPointRate.ToString();
            PKPointTickRateEdit.Text = Config.PKPointTickRate.ToString();
            RedPointEdit.Text = Config.RedPoint.ToString();
            PvPCurseDurationEdit.Text = Config.PvPCurseDuration.ToString();
            PvPCurseRateEdit.Text = Config.PvPCurseRate.ToString();
            AutoReviveDelayEdit.Text = Config.AutoReviveDelay.ToString();
            EnableStruckEdit.Checked = Config.EnableStruck;
            EnableHermitEdit.Checked = Config.EnableHermit;
            EnableFortuneEdit.Checked = Config.EnableFortune;
            AdminGamemasterStartEdit.Checked = Config.AdminStartInGamemasterMode;
            AdminObserverStartEdit.Checked = Config.AdminStartInObserverMode;
            AdminSupermanStartEdit.Checked = Config.AdminStartInSupermanMode;



            //Monsters
            DeadDurationEdit.Text = Config.DeadDuration.ToString();
            HarvestDurationEdit.Text = Config.HarvestDuration.ToString();
            MysteryShipRegionIndexEdit.SelectedValue = Config.MysteryShipRegionIndex;
            LairRegionIndexEdit.SelectedValue = Config.LairRegionIndex;

            //Items
            DropDurationEdit.Text = Config.DropDuration.ToString();
            DropDistanceEdit.Text = Config.DropDistance.ToString();
            DropLayersEdit.Text = Config.DropLayers.ToString();
            TorchRateEdit.Text = Config.TorchRate.ToString();
            SpecialRepairDelayEdit.Text = Config.SpecialRepairDelay.ToString();
            MaxLuckEdit.Text = Config.MaxLuck.ToString();
            LuckRateEdit.Text = Config.LuckRate.ToString();
            MaxCurseEdit.Text = Config.MaxCurse.ToString();
            CurseRateEdit.Text = Config.CurseRate.ToString();
            MaxStrengthEdit.Text = Config.MaxStrength.ToString();
            StrengthAddRateEdit.Text = Config.StrengthAddRate.ToString();
            StrengthLossRateEdit.Text = Config.StrengthLossRate.ToString();

            //Rates
            ExperienceRateEdit.Text = Config.ExperienceRate.ToString();
            DropRateEdit.Text = Config.DropRate.ToString();
            GoldRateEdit.Text = Config.GoldRate.ToString();
            SkillRateEdit.Text = Config.SkillRate.ToString();
            CompanionRateEdit.Text = Config.CompanionRate.ToString();
        }
        public void SaveSettings()
        {
            try
            {
            //Network
            Config.IPAddress = IPAddressEdit.Text;
            Config.Port = ushort.Parse(PortEdit.Text);
            Config.TimeOut = TimeSpan.Parse(TimeOutEdit.Text);
            Config.PingDelay = TimeSpan.Parse(PingDelayEdit.Text);
            Config.UserCountPort = ushort.Parse(UserCountPortEdit.Text);
            Config.MaxPacket = int.Parse(MaxPacketEdit.Text);
            Config.PacketBanTime = TimeSpan.Parse(PacketBanTimeEdit.Text);


            //Control
            Config.AllowNewAccount = AllowNewAccountEdit.Checked;
            Config.AllowChangePassword = AllowChangePasswordEdit.Checked;
            Config.AllowLogin = AllowLoginEdit.Checked;
            Config.AllowNewCharacter = AllowNewCharacterEdit.Checked;
            Config.AllowDeleteCharacter = AllowDeleteCharacterEdit.Checked;
            Config.AllowStartGame = AllowStartGameEdit.Checked;
            Config.AllowWarrior = AllowWarriorEdit.Checked;
            Config.AllowWizard = AllowWizardEdit.Checked;
            Config.AllowTaoist = AllowTaoistEdit.Checked;
            Config.AllowAssassin = AllowAssassinEdit.Checked;
            Config.RelogDelay = TimeSpan.Parse(RelogDelayEdit.Text);
            Config.AllowRequestPasswordReset = AllowRequestPasswordResetEdit.Checked;
            Config.AllowWebResetPassword = AllowWebResetPasswordEdit.Checked;
            Config.AllowManualResetPassword = AllowManualResetPasswordEdit.Checked;
            Config.AllowDeleteAccount = AllowDeleteAccountEdit.Checked;
            Config.AllowManualActivation = AllowManualActivationEdit.Checked;
            Config.AllowWebActivation = AllowWebActivationEdit.Checked;
            Config.AllowRequestActivation = AllowRequestActivationEdit.Checked;

            //System
            Config.CheckVersion = CheckVersionEdit.Checked;
            Config.VersionPath = VersionPathEdit.Text;
            Config.DBSaveDelay = TimeSpan.Parse(DBSaveDelayEdit.Text);
            Config.MapPath = MapPathEdit.Text;
            Config.LazyLoadMaps = LazyLoadMapsEdit.Checked;
            Config.MasterPassword = MasterPasswordEdit.Text;
            Config.ClientPath = ClientPathEdit.Text;
            Config.ReleaseDate = ReleaseDateEdit.Value;
            Config.EasterEventEnd = RabbitEventEndEdit.Value;

            //Mail
            Config.MailServer = MailServerEdit.Text;
            Config.MailPort = int.Parse(MailPortEdit.Text);
            Config.MailUseSSL = MailUseSSLEdit.Checked;
            Config.MailAccount = MailAccountEdit.Text;
            Config.MailPassword = MailPasswordEdit.Text;
            Config.MailFrom = MailFromEdit.Text;
            Config.MailDisplayName = MailDisplayNameEdit.Text;

            //WebServer
            Config.WebPrefix = WebPrefixEdit.Text;
            Config.WebCommandLink = WebCommandLinkEdit.Text;
            Config.ActivationSuccessLink = ActivationSuccessLinkEdit.Text;
            Config.ActivationFailLink = ActivationFailLinkEdit.Text;
            Config.ResetSuccessLink = ResetSuccessLinkEdit.Text;
            Config.ResetFailLink = ResetFailLinkEdit.Text;
            Config.DeleteSuccessLink = DeleteSuccessLinkEdit.Text;
            Config.DeleteFailLink = DeleteFailLinkEdit.Text;

            Config.BuyPrefix = BuyPrefixEdit.Text;
            Config.BuyAddress = BuyAddressEdit.Text;
            Config.IPNPrefix = IPNPrefixEdit.Text;
            Config.ReceiverEMail = ReceiverEMailEdit.Text;
            Config.ProcessGameGold = ProcessGameGoldEdit.Checked;
            Config.AllowBuyGameGold = AllowBuyGameGoldEdit.Checked;

            //Players
            Config.MaxViewRange = int.Parse(MaxViewRangeEdit.Text);
            Config.ShoutDelay = TimeSpan.Parse(ShoutDelayEdit.Text);
            Config.GlobalDelay = TimeSpan.Parse(GlobalDelayEdit.Text);
            Config.MaxLevel = int.Parse(MaxLevelEdit.Text);
            Config.DayCycleCount = int.Parse(DayCycleCountEdit.Text);
            Config.SkillExp = int.Parse(SkillExpEdit.Text);
            Config.AllowObservation = AllowObservationEdit.Checked;
            Config.BrownDuration = TimeSpan.Parse(BrownDurationEdit.Text);
            Config.PKPointRate = int.Parse(PKPointRateEdit.Text);
            Config.PKPointTickRate = TimeSpan.Parse(PKPointTickRateEdit.Text);
            Config.RedPoint = int.Parse(RedPointEdit.Text);
            Config.PvPCurseDuration = TimeSpan.Parse(PvPCurseDurationEdit.Text);
            Config.PvPCurseRate = int.Parse(PvPCurseRateEdit.Text);
            Config.AutoReviveDelay = TimeSpan.Parse(AutoReviveDelayEdit.Text);
            Config.EnableStruck = EnableStruckEdit.Checked;
            Config.EnableHermit = EnableHermitEdit.Checked;
            Config.EnableFortune = EnableFortuneEdit.Checked;
            Config.AdminStartInGamemasterMode = AdminGamemasterStartEdit.Checked;
            Config.AdminStartInObserverMode = AdminObserverStartEdit.Checked;
            Config.AdminStartInSupermanMode = AdminSupermanStartEdit.Checked;

            //Monsters
            Config.DeadDuration = TimeSpan.Parse(DeadDurationEdit.Text);
            Config.HarvestDuration = TimeSpan.Parse(HarvestDurationEdit.Text);
            Config.MysteryShipRegionIndex = MysteryShipRegionIndexEdit.SelectedValue != null ? (int)MysteryShipRegionIndexEdit.SelectedValue : 0;
            Config.LairRegionIndex = LairRegionIndexEdit.SelectedValue != null ? (int)LairRegionIndexEdit.SelectedValue : 0;

            //Items
            Config.DropDuration = TimeSpan.Parse(DropDurationEdit.Text);
            Config.DropDistance = int.Parse(DropDistanceEdit.Text);
            Config.DropLayers = int.Parse(DropLayersEdit.Text);
            Config.TorchRate = int.Parse(TorchRateEdit.Text);
            Config.SpecialRepairDelay = TimeSpan.Parse(SpecialRepairDelayEdit.Text);
            Config.MaxLuck = int.Parse(MaxLuckEdit.Text);
            Config.LuckRate = int.Parse(LuckRateEdit.Text);
            Config.MaxCurse = int.Parse(MaxCurseEdit.Text);
            Config.CurseRate = int.Parse(CurseRateEdit.Text);

            Config.MaxStrength = int.Parse(MaxStrengthEdit.Text);
            Config.StrengthAddRate = int.Parse(StrengthAddRateEdit.Text);
            Config.StrengthLossRate = int.Parse(StrengthLossRateEdit.Text);

            //Rates
            Config.ExperienceRate = int.Parse(ExperienceRateEdit.Text);
            Config.DropRate = int.Parse(DropRateEdit.Text);
            Config.GoldRate = int.Parse(GoldRateEdit.Text);
            Config.SkillRate = int.Parse(SkillRateEdit.Text);
            Config.CompanionRate = int.Parse(CompanionRateEdit.Text);

            if (SEnvir.Started)
            {
                SEnvir.ServerBuffChanged = true;
            }

            ConfigReader.Save(typeof(Config).Assembly);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"配置值格式错误：{ex.Message}\n请检查所有数值和时间间隔字段的格式。",
                    "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
        private void ReloadButton_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }


        private void CheckVersionButton_Click(object sender, EventArgs e)
        {
            byte[] old = Config.ClientHash;

            Config.LoadVersion();

            if (Functions.IsMatch(old, Config.ClientHash) || !SEnvir.Started) return;

            SEnvir.Broadcast(new S.Chat { Text = "A new version has been made available, please update when possible.", Type = MessageType.Announcement });
        }
        private void VersionPathBrowseButton_Click(object sender, EventArgs e)
        {
            if (OpenDialog.ShowDialog() != DialogResult.OK) return;

            VersionPathEdit.Text = OpenDialog.FileName;
        }
        private void MapPathBrowseButton_Click(object sender, EventArgs e)
        {
            if (FolderDialog.ShowDialog() != DialogResult.OK) return;

            MapPathEdit.Text = FolderDialog.SelectedPath;
        }

        private void ClientPathBrowseButton_Click(object sender, EventArgs e)
        {
            if (FolderDialog.ShowDialog() != DialogResult.OK) return;

            ClientPathEdit.Text = FolderDialog.SelectedPath;
        }
    }
}
