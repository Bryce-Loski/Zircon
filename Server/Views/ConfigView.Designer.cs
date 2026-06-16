namespace Server.Views
{
    partial class ConfigView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            viewToolStrip = new System.Windows.Forms.ToolStrip();
            SaveButton = new System.Windows.Forms.ToolStripButton();
            ReloadButton = new System.Windows.Forms.ToolStripButton();
            configTabControl = new System.Windows.Forms.TabControl();
            OpenDialog = new System.Windows.Forms.OpenFileDialog();
            FolderDialog = new System.Windows.Forms.FolderBrowserDialog();

            viewToolStrip.SuspendLayout();
            SuspendLayout();

            // ================================================================
            // ToolStrip
            // ================================================================
            viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { SaveButton, ReloadButton });
            viewToolStrip.Location = new System.Drawing.Point(0, 0);
            viewToolStrip.Name = "viewToolStrip";
            viewToolStrip.Size = new System.Drawing.Size(900, 25);

            SaveButton.Name = "SaveButton";
            SaveButton.Text = "Save Config";
            SaveButton.Click += SaveButton_Click;

            ReloadButton.Name = "ReloadButton";
            ReloadButton.Text = "Reload";
            ReloadButton.Click += ReloadButton_Click;

            // ================================================================
            // TabControl
            // ================================================================
            configTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            configTabControl.Location = new System.Drawing.Point(0, 25);
            configTabControl.Name = "configTabControl";

            // ---- Network Tab ----
            var networkTab = new System.Windows.Forms.TabPage("Network");
            var networkPanel = CreateTableLayoutPanel();
            networkTab.Controls.Add(networkPanel);
            int nr = 0;
            IPAddressEdit = AddTextBox(networkPanel, "IP Address", ref nr);
            PortEdit = AddTextBox(networkPanel, "Port", ref nr);
            TimeOutEdit = AddTextBox(networkPanel, "Timeout", ref nr);
            PingDelayEdit = AddTextBox(networkPanel, "Ping Delay", ref nr);
            UserCountPortEdit = AddTextBox(networkPanel, "User Count Port", ref nr);
            MaxPacketEdit = AddTextBox(networkPanel, "Max Packet", ref nr);
            PacketBanTimeEdit = AddTextBox(networkPanel, "Packet Ban Time", ref nr);
            configTabControl.TabPages.Add(networkTab);

            // ---- Control Tab ----
            var controlTab = new System.Windows.Forms.TabPage("Control");
            var controlPanel = CreateTableLayoutPanel();
            controlTab.Controls.Add(controlPanel);
            int cr = 0;
            AllowNewAccountEdit = AddCheckBox(controlPanel, "Allow New Account", ref cr);
            AllowChangePasswordEdit = AddCheckBox(controlPanel, "Allow Change Password", ref cr);
            AllowLoginEdit = AddCheckBox(controlPanel, "Allow Login", ref cr);
            AllowNewCharacterEdit = AddCheckBox(controlPanel, "Allow New Character", ref cr);
            AllowDeleteCharacterEdit = AddCheckBox(controlPanel, "Allow Delete Character", ref cr);
            AllowStartGameEdit = AddCheckBox(controlPanel, "Allow Start Game", ref cr);
            AllowWarriorEdit = AddCheckBox(controlPanel, "Allow Warrior", ref cr);
            AllowWizardEdit = AddCheckBox(controlPanel, "Allow Wizard", ref cr);
            AllowTaoistEdit = AddCheckBox(controlPanel, "Allow Taoist", ref cr);
            AllowAssassinEdit = AddCheckBox(controlPanel, "Allow Assassin", ref cr);
            RelogDelayEdit = AddTextBox(controlPanel, "Relog Delay", ref cr);
            AllowRequestPasswordResetEdit = AddCheckBox(controlPanel, "Allow Request Password Reset", ref cr);
            AllowWebResetPasswordEdit = AddCheckBox(controlPanel, "Allow Web Reset Password", ref cr);
            AllowManualResetPasswordEdit = AddCheckBox(controlPanel, "Allow Manual Reset Password", ref cr);
            AllowDeleteAccountEdit = AddCheckBox(controlPanel, "Allow Delete Account", ref cr);
            AllowManualActivationEdit = AddCheckBox(controlPanel, "Allow Manual Activation", ref cr);
            AllowWebActivationEdit = AddCheckBox(controlPanel, "Allow Web Activation", ref cr);
            AllowRequestActivationEdit = AddCheckBox(controlPanel, "Allow Request Activation", ref cr);
            configTabControl.TabPages.Add(controlTab);

            // ---- System Tab ----
            var systemTab = new System.Windows.Forms.TabPage("System");
            var systemPanel = CreateTableLayoutPanel();
            systemTab.Controls.Add(systemPanel);
            int sr = 0;
            CheckVersionEdit = AddCheckBox(systemPanel, "Check Version", ref sr);
            VersionPathEdit = AddTextBoxWithButton(systemPanel, "Version Path", "Browse...", VersionPathBrowseButton_Click, ref sr);
            DBSaveDelayEdit = AddTextBox(systemPanel, "DB Save Delay", ref sr);
            MapPathEdit = AddTextBoxWithButton(systemPanel, "Map Path", "Browse...", MapPathBrowseButton_Click, ref sr);
            LazyLoadMapsEdit = AddCheckBox(systemPanel, "Lazy Load Maps", ref sr);
            MasterPasswordEdit = AddTextBox(systemPanel, "Master Password", ref sr);
            ClientPathEdit = AddTextBoxWithButton(systemPanel, "Client Path", "Browse...", ClientPathBrowseButton_Click, ref sr);
            ReleaseDateEdit = AddDateTimePicker(systemPanel, "Release Date", ref sr);
            RabbitEventEndEdit = AddDateTimePicker(systemPanel, "Easter Event End", ref sr);
            SyncronizeLocalButton = AddButton(systemPanel, "Sync Local", ref sr);
            SyncronizeRemoteButton = AddButton(systemPanel, "Sync Remote", ref sr);
            DatabaseEncryptionButton = AddButton(systemPanel, "Database Encryption", ref sr);
            CheckVersionButton = AddButton(systemPanel, "Check Version Now", ref sr);
            configTabControl.TabPages.Add(systemTab);

            // ---- Mail Tab ----
            var mailTab = new System.Windows.Forms.TabPage("Mail");
            var mailPanel = CreateTableLayoutPanel();
            mailTab.Controls.Add(mailPanel);
            int mr = 0;
            MailServerEdit = AddTextBox(mailPanel, "Mail Server", ref mr);
            MailPortEdit = AddTextBox(mailPanel, "Mail Port", ref mr);
            MailUseSSLEdit = AddCheckBox(mailPanel, "Use SSL", ref mr);
            MailAccountEdit = AddTextBox(mailPanel, "Mail Account", ref mr);
            MailPasswordEdit = AddTextBox(mailPanel, "Mail Password", ref mr);
            MailFromEdit = AddTextBox(mailPanel, "Mail From", ref mr);
            MailDisplayNameEdit = AddTextBox(mailPanel, "Display Name", ref mr);
            configTabControl.TabPages.Add(mailTab);

            // ---- Web Server Tab ----
            var webTab = new System.Windows.Forms.TabPage("Web Server");
            var webPanel = CreateTableLayoutPanel();
            webTab.Controls.Add(webPanel);
            int wr = 0;
            WebPrefixEdit = AddTextBox(webPanel, "Web Prefix", ref wr);
            WebCommandLinkEdit = AddTextBox(webPanel, "Web Command Link", ref wr);
            ActivationSuccessLinkEdit = AddTextBox(webPanel, "Activation Success Link", ref wr);
            ActivationFailLinkEdit = AddTextBox(webPanel, "Activation Fail Link", ref wr);
            ResetSuccessLinkEdit = AddTextBox(webPanel, "Reset Success Link", ref wr);
            ResetFailLinkEdit = AddTextBox(webPanel, "Reset Fail Link", ref wr);
            DeleteSuccessLinkEdit = AddTextBox(webPanel, "Delete Success Link", ref wr);
            DeleteFailLinkEdit = AddTextBox(webPanel, "Delete Fail Link", ref wr);
            BuyPrefixEdit = AddTextBox(webPanel, "Buy Prefix", ref wr);
            BuyAddressEdit = AddTextBox(webPanel, "Buy Address", ref wr);
            IPNPrefixEdit = AddTextBox(webPanel, "IPN Prefix", ref wr);
            ReceiverEMailEdit = AddTextBox(webPanel, "Receiver E-Mail", ref wr);
            ProcessGameGoldEdit = AddCheckBox(webPanel, "Process Game Gold", ref wr);
            AllowBuyGameGoldEdit = AddCheckBox(webPanel, "Allow Buy Game Gold", ref wr);
            configTabControl.TabPages.Add(webTab);

            // ---- Players Tab ----
            var playersTab = new System.Windows.Forms.TabPage("Players");
            var playersPanel = CreateTableLayoutPanel();
            playersTab.Controls.Add(playersPanel);
            int pr = 0;
            MaxViewRangeEdit = AddTextBox(playersPanel, "Max View Range", ref pr);
            ShoutDelayEdit = AddTextBox(playersPanel, "Shout Delay", ref pr);
            GlobalDelayEdit = AddTextBox(playersPanel, "Global Delay", ref pr);
            MaxLevelEdit = AddTextBox(playersPanel, "Max Level", ref pr);
            DayCycleCountEdit = AddTextBox(playersPanel, "Day Cycle Count", ref pr);
            SkillExpEdit = AddTextBox(playersPanel, "Skill Exp", ref pr);
            AllowObservationEdit = AddCheckBox(playersPanel, "Allow Observation", ref pr);
            BrownDurationEdit = AddTextBox(playersPanel, "Brown Duration", ref pr);
            PKPointRateEdit = AddTextBox(playersPanel, "PK Point Rate", ref pr);
            PKPointTickRateEdit = AddTextBox(playersPanel, "PK Point Tick Rate", ref pr);
            RedPointEdit = AddTextBox(playersPanel, "Red Point", ref pr);
            PvPCurseDurationEdit = AddTextBox(playersPanel, "PvP Curse Duration", ref pr);
            PvPCurseRateEdit = AddTextBox(playersPanel, "PvP Curse Rate", ref pr);
            AutoReviveDelayEdit = AddTextBox(playersPanel, "Auto Revive Delay", ref pr);
            EnableStruckEdit = AddCheckBox(playersPanel, "Enable Struck", ref pr);
            EnableHermitEdit = AddCheckBox(playersPanel, "Enable Hermit", ref pr);
            EnableFortuneEdit = AddCheckBox(playersPanel, "Enable Fortune", ref pr);
            AdminGamemasterStartEdit = AddCheckBox(playersPanel, "Admin Gamemaster Start", ref pr);
            AdminObserverStartEdit = AddCheckBox(playersPanel, "Admin Observer Start", ref pr);
            AdminSupermanStartEdit = AddCheckBox(playersPanel, "Admin Superman Start", ref pr);
            configTabControl.TabPages.Add(playersTab);

            // ---- Monsters Tab ----
            var monstersTab = new System.Windows.Forms.TabPage("Monsters");
            var monstersPanel = CreateTableLayoutPanel();
            monstersTab.Controls.Add(monstersPanel);
            int monr = 0;
            DeadDurationEdit = AddTextBox(monstersPanel, "Dead Duration", ref monr);
            HarvestDurationEdit = AddTextBox(monstersPanel, "Harvest Duration", ref monr);
            MysteryShipRegionIndexEdit = AddComboBox(monstersPanel, "Mystery Ship Region", ref monr);
            LairRegionIndexEdit = AddComboBox(monstersPanel, "Lair Region", ref monr);
            configTabControl.TabPages.Add(monstersTab);

            // ---- Items Tab ----
            var itemsTab = new System.Windows.Forms.TabPage("Items");
            var itemsPanel = CreateTableLayoutPanel();
            itemsTab.Controls.Add(itemsPanel);
            int ir = 0;
            DropDurationEdit = AddTextBox(itemsPanel, "Drop Duration", ref ir);
            DropDistanceEdit = AddTextBox(itemsPanel, "Drop Distance", ref ir);
            DropLayersEdit = AddTextBox(itemsPanel, "Drop Layers", ref ir);
            TorchRateEdit = AddTextBox(itemsPanel, "Torch Rate", ref ir);
            SpecialRepairDelayEdit = AddTextBox(itemsPanel, "Special Repair Delay", ref ir);
            MaxLuckEdit = AddTextBox(itemsPanel, "Max Luck", ref ir);
            LuckRateEdit = AddTextBox(itemsPanel, "Luck Rate", ref ir);
            MaxCurseEdit = AddTextBox(itemsPanel, "Max Curse", ref ir);
            CurseRateEdit = AddTextBox(itemsPanel, "Curse Rate", ref ir);
            MaxStrengthEdit = AddTextBox(itemsPanel, "Max Strength", ref ir);
            StrengthAddRateEdit = AddTextBox(itemsPanel, "Strength Add Rate", ref ir);
            StrengthLossRateEdit = AddTextBox(itemsPanel, "Strength Loss Rate", ref ir);
            configTabControl.TabPages.Add(itemsTab);

            // ---- Rates Tab ----
            var ratesTab = new System.Windows.Forms.TabPage("Rates");
            var ratesPanel = CreateTableLayoutPanel();
            ratesTab.Controls.Add(ratesPanel);
            int rr = 0;
            ExperienceRateEdit = AddTextBox(ratesPanel, "Experience Rate", ref rr);
            DropRateEdit = AddTextBox(ratesPanel, "Drop Rate", ref rr);
            GoldRateEdit = AddTextBox(ratesPanel, "Gold Rate", ref rr);
            SkillRateEdit = AddTextBox(ratesPanel, "Skill Rate", ref rr);
            CompanionRateEdit = AddTextBox(ratesPanel, "Companion Rate", ref rr);
            configTabControl.TabPages.Add(ratesTab);

            // ================================================================
            // ConfigView
            // ================================================================
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(configTabControl);
            Controls.Add(viewToolStrip);
            Name = "ConfigView";
            Size = new System.Drawing.Size(900, 600);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        #region Layout Helpers

        private static System.Windows.Forms.TableLayoutPanel CreateTableLayoutPanel()
        {
            var panel = new System.Windows.Forms.TableLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                ColumnCount = 2,
                AutoScroll = true,
                Padding = new System.Windows.Forms.Padding(8),
            };
            panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            return panel;
        }

        private static System.Windows.Forms.TextBox AddTextBox(System.Windows.Forms.TableLayoutPanel panel, string label, ref int row)
        {
            panel.RowCount++;
            panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            panel.Controls.Add(new System.Windows.Forms.Label { Text = label, Dock = System.Windows.Forms.DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft }, 0, row);
            var textBox = new System.Windows.Forms.TextBox { Dock = System.Windows.Forms.DockStyle.Fill };
            panel.Controls.Add(textBox, 1, row);
            row++;
            return textBox;
        }

        private static System.Windows.Forms.TextBox AddTextBoxWithButton(System.Windows.Forms.TableLayoutPanel panel, string label, string btnText, System.EventHandler clickHandler, ref int row)
        {
            panel.RowCount++;
            panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            panel.Controls.Add(new System.Windows.Forms.Label { Text = label, Dock = System.Windows.Forms.DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft }, 0, row);

            var container = new System.Windows.Forms.TableLayoutPanel { Dock = System.Windows.Forms.DockStyle.Fill, ColumnCount = 2 };
            container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            var textBox = new System.Windows.Forms.TextBox { Dock = System.Windows.Forms.DockStyle.Fill };
            var button = new System.Windows.Forms.Button { Text = btnText, Dock = System.Windows.Forms.DockStyle.Fill };
            button.Click += clickHandler;
            container.Controls.Add(textBox, 0, 0);
            container.Controls.Add(button, 1, 0);
            panel.Controls.Add(container, 1, row);
            row++;
            return textBox;
        }

        private static System.Windows.Forms.CheckBox AddCheckBox(System.Windows.Forms.TableLayoutPanel panel, string label, ref int row)
        {
            panel.RowCount++;
            panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            panel.Controls.Add(new System.Windows.Forms.Label { Text = label, Dock = System.Windows.Forms.DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft }, 0, row);
            var checkBox = new System.Windows.Forms.CheckBox { Dock = System.Windows.Forms.DockStyle.Left };
            panel.Controls.Add(checkBox, 1, row);
            row++;
            return checkBox;
        }

        private static System.Windows.Forms.DateTimePicker AddDateTimePicker(System.Windows.Forms.TableLayoutPanel panel, string label, ref int row)
        {
            panel.RowCount++;
            panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            panel.Controls.Add(new System.Windows.Forms.Label { Text = label, Dock = System.Windows.Forms.DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft }, 0, row);
            var dtp = new System.Windows.Forms.DateTimePicker { Dock = System.Windows.Forms.DockStyle.Fill, Format = System.Windows.Forms.DateTimePickerFormat.Short };
            panel.Controls.Add(dtp, 1, row);
            row++;
            return dtp;
        }

        private static System.Windows.Forms.ComboBox AddComboBox(System.Windows.Forms.TableLayoutPanel panel, string label, ref int row)
        {
            panel.RowCount++;
            panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            panel.Controls.Add(new System.Windows.Forms.Label { Text = label, Dock = System.Windows.Forms.DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft }, 0, row);
            var combo = new System.Windows.Forms.ComboBox
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList,
                ValueMember = "Index",
                DisplayMember = "Description"
            };
            panel.Controls.Add(combo, 1, row);
            row++;
            return combo;
        }

        private static System.Windows.Forms.Button AddButton(System.Windows.Forms.TableLayoutPanel panel, string label, ref int row)
        {
            panel.RowCount++;
            panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            panel.Controls.Add(new System.Windows.Forms.Label { Text = label, Dock = System.Windows.Forms.DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleLeft }, 0, row);
            var button = new System.Windows.Forms.Button { Text = label, Dock = System.Windows.Forms.DockStyle.Left };
            panel.Controls.Add(button, 1, row);
            row++;
            return button;
        }

        #endregion

        // ---- ToolStrip ----
        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ReloadButton;

        // ---- TabControl ----
        private System.Windows.Forms.TabControl configTabControl;

        // ---- Network ----
        private System.Windows.Forms.TextBox IPAddressEdit;
        private System.Windows.Forms.TextBox PortEdit;
        private System.Windows.Forms.TextBox TimeOutEdit;
        private System.Windows.Forms.TextBox PingDelayEdit;
        private System.Windows.Forms.TextBox UserCountPortEdit;
        private System.Windows.Forms.TextBox MaxPacketEdit;
        private System.Windows.Forms.TextBox PacketBanTimeEdit;

        // ---- Control ----
        private System.Windows.Forms.CheckBox AllowNewAccountEdit;
        private System.Windows.Forms.CheckBox AllowChangePasswordEdit;
        private System.Windows.Forms.CheckBox AllowLoginEdit;
        private System.Windows.Forms.CheckBox AllowNewCharacterEdit;
        private System.Windows.Forms.CheckBox AllowDeleteCharacterEdit;
        private System.Windows.Forms.CheckBox AllowStartGameEdit;
        private System.Windows.Forms.CheckBox AllowWarriorEdit;
        private System.Windows.Forms.CheckBox AllowWizardEdit;
        private System.Windows.Forms.CheckBox AllowTaoistEdit;
        private System.Windows.Forms.CheckBox AllowAssassinEdit;
        private System.Windows.Forms.TextBox RelogDelayEdit;
        private System.Windows.Forms.CheckBox AllowRequestPasswordResetEdit;
        private System.Windows.Forms.CheckBox AllowWebResetPasswordEdit;
        private System.Windows.Forms.CheckBox AllowManualResetPasswordEdit;
        private System.Windows.Forms.CheckBox AllowDeleteAccountEdit;
        private System.Windows.Forms.CheckBox AllowManualActivationEdit;
        private System.Windows.Forms.CheckBox AllowWebActivationEdit;
        private System.Windows.Forms.CheckBox AllowRequestActivationEdit;

        // ---- System ----
        private System.Windows.Forms.CheckBox CheckVersionEdit;
        private System.Windows.Forms.TextBox VersionPathEdit;
        private System.Windows.Forms.TextBox DBSaveDelayEdit;
        private System.Windows.Forms.TextBox MapPathEdit;
        private System.Windows.Forms.CheckBox LazyLoadMapsEdit;
        private System.Windows.Forms.TextBox MasterPasswordEdit;
        private System.Windows.Forms.TextBox ClientPathEdit;
        private System.Windows.Forms.DateTimePicker ReleaseDateEdit;
        private System.Windows.Forms.DateTimePicker RabbitEventEndEdit;
        private System.Windows.Forms.Button SyncronizeLocalButton;
        private System.Windows.Forms.Button SyncronizeRemoteButton;
        private System.Windows.Forms.Button DatabaseEncryptionButton;
        private System.Windows.Forms.Button CheckVersionButton;

        // ---- Mail ----
        private System.Windows.Forms.TextBox MailServerEdit;
        private System.Windows.Forms.TextBox MailPortEdit;
        private System.Windows.Forms.CheckBox MailUseSSLEdit;
        private System.Windows.Forms.TextBox MailAccountEdit;
        private System.Windows.Forms.TextBox MailPasswordEdit;
        private System.Windows.Forms.TextBox MailFromEdit;
        private System.Windows.Forms.TextBox MailDisplayNameEdit;

        // ---- WebServer ----
        private System.Windows.Forms.TextBox WebPrefixEdit;
        private System.Windows.Forms.TextBox WebCommandLinkEdit;
        private System.Windows.Forms.TextBox ActivationSuccessLinkEdit;
        private System.Windows.Forms.TextBox ActivationFailLinkEdit;
        private System.Windows.Forms.TextBox ResetSuccessLinkEdit;
        private System.Windows.Forms.TextBox ResetFailLinkEdit;
        private System.Windows.Forms.TextBox DeleteSuccessLinkEdit;
        private System.Windows.Forms.TextBox DeleteFailLinkEdit;
        private System.Windows.Forms.TextBox BuyPrefixEdit;
        private System.Windows.Forms.TextBox BuyAddressEdit;
        private System.Windows.Forms.TextBox IPNPrefixEdit;
        private System.Windows.Forms.TextBox ReceiverEMailEdit;
        private System.Windows.Forms.CheckBox ProcessGameGoldEdit;
        private System.Windows.Forms.CheckBox AllowBuyGameGoldEdit;

        // ---- Players ----
        private System.Windows.Forms.TextBox MaxViewRangeEdit;
        private System.Windows.Forms.TextBox ShoutDelayEdit;
        private System.Windows.Forms.TextBox GlobalDelayEdit;
        private System.Windows.Forms.TextBox MaxLevelEdit;
        private System.Windows.Forms.TextBox DayCycleCountEdit;
        private System.Windows.Forms.TextBox SkillExpEdit;
        private System.Windows.Forms.CheckBox AllowObservationEdit;
        private System.Windows.Forms.TextBox BrownDurationEdit;
        private System.Windows.Forms.TextBox PKPointRateEdit;
        private System.Windows.Forms.TextBox PKPointTickRateEdit;
        private System.Windows.Forms.TextBox RedPointEdit;
        private System.Windows.Forms.TextBox PvPCurseDurationEdit;
        private System.Windows.Forms.TextBox PvPCurseRateEdit;
        private System.Windows.Forms.TextBox AutoReviveDelayEdit;
        private System.Windows.Forms.CheckBox EnableStruckEdit;
        private System.Windows.Forms.CheckBox EnableHermitEdit;
        private System.Windows.Forms.CheckBox EnableFortuneEdit;
        private System.Windows.Forms.CheckBox AdminGamemasterStartEdit;
        private System.Windows.Forms.CheckBox AdminObserverStartEdit;
        private System.Windows.Forms.CheckBox AdminSupermanStartEdit;

        // ---- Monsters ----
        private System.Windows.Forms.TextBox DeadDurationEdit;
        private System.Windows.Forms.TextBox HarvestDurationEdit;
        private System.Windows.Forms.ComboBox MysteryShipRegionIndexEdit;
        private System.Windows.Forms.ComboBox LairRegionIndexEdit;

        // ---- Items ----
        private System.Windows.Forms.TextBox DropDurationEdit;
        private System.Windows.Forms.TextBox DropDistanceEdit;
        private System.Windows.Forms.TextBox DropLayersEdit;
        private System.Windows.Forms.TextBox TorchRateEdit;
        private System.Windows.Forms.TextBox SpecialRepairDelayEdit;
        private System.Windows.Forms.TextBox MaxLuckEdit;
        private System.Windows.Forms.TextBox LuckRateEdit;
        private System.Windows.Forms.TextBox MaxCurseEdit;
        private System.Windows.Forms.TextBox CurseRateEdit;
        private System.Windows.Forms.TextBox MaxStrengthEdit;
        private System.Windows.Forms.TextBox StrengthAddRateEdit;
        private System.Windows.Forms.TextBox StrengthLossRateEdit;

        // ---- Rates ----
        private System.Windows.Forms.TextBox ExperienceRateEdit;
        private System.Windows.Forms.TextBox DropRateEdit;
        private System.Windows.Forms.TextBox GoldRateEdit;
        private System.Windows.Forms.TextBox SkillRateEdit;
        private System.Windows.Forms.TextBox CompanionRateEdit;

        // ---- Dialogs ----
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.FolderBrowserDialog FolderDialog;
    }
}
