namespace Server
{
    partial class SMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ---- MenuStrip ----
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            serverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            StartServerButton = new System.Windows.Forms.ToolStripMenuItem();
            StopServerButton = new System.Windows.Forms.ToolStripMenuItem();
            pluginsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pluginsToolStrip = new System.Windows.Forms.ToolStrip();

            // ---- SplitContainer + TreeView + TabControl ----
            mainSplitContainer = new System.Windows.Forms.SplitContainer();
            navigationTreeView = new System.Windows.Forms.TreeView();
            mainTabControl = new System.Windows.Forms.TabControl();

            // ---- StatusStrip ----
            mainStatusStrip = new System.Windows.Forms.StatusStrip();
            ConnectionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ObjectLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ProcessLabel = new System.Windows.Forms.ToolStripStatusLabel();
            LoopLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ConDelay = new System.Windows.Forms.ToolStripStatusLabel();
            SaveDelay = new System.Windows.Forms.ToolStripStatusLabel();
            TotalDownloadLabel = new System.Windows.Forms.ToolStripStatusLabel();
            TotalUploadLabel = new System.Windows.Forms.ToolStripStatusLabel();
            DownloadSpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            UploadSpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            EMailsSentLabel = new System.Windows.Forms.ToolStripStatusLabel();

            // ---- Timer ----
            InterfaceTimer = new System.Windows.Forms.Timer(components);

            mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainSplitContainer).BeginInit();
            mainSplitContainer.Panel1.SuspendLayout();
            mainSplitContainer.Panel2.SuspendLayout();
            mainSplitContainer.SuspendLayout();
            mainStatusStrip.SuspendLayout();
            SuspendLayout();

            // ================================================================
            // mainMenuStrip
            // ================================================================
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                serverMenuItem,
                pluginsMenuItem
            });
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new System.Drawing.Size(1294, 24);

            // ---- Server Menu ----
            serverMenuItem.Name = "serverMenuItem";
            serverMenuItem.Text = "&Server";
            serverMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                StartServerButton,
                StopServerButton
            });

            // ---- StartServerButton ----
            StartServerButton.Name = "StartServerButton";
            StartServerButton.Text = "&Start Server";
            StartServerButton.ShortcutKeys = System.Windows.Forms.Keys.F5;
            StartServerButton.Click += StartServerButton_Click;

            // ---- StopServerButton ----
            StopServerButton.Name = "StopServerButton";
            StopServerButton.Text = "S&top Server";
            StopServerButton.ShortcutKeys = System.Windows.Forms.Keys.F6;
            StopServerButton.Click += StopServerButton_Click;

            // ---- Plugins Menu ----
            pluginsMenuItem.Name = "pluginsMenuItem";
            pluginsMenuItem.Text = "&Plugins";

            // ---- pluginsToolStrip (plugin toolbar below menu) ----
            pluginsToolStrip.Location = new System.Drawing.Point(0, 24);
            pluginsToolStrip.Name = "pluginsToolStrip";
            pluginsToolStrip.Size = new System.Drawing.Size(1294, 25);
            pluginsToolStrip.Visible = false;

            // ================================================================
            // mainSplitContainer
            // ================================================================
            mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            mainSplitContainer.Location = new System.Drawing.Point(0, 49);
            mainSplitContainer.Name = "mainSplitContainer";
            mainSplitContainer.Size = new System.Drawing.Size(1294, 785);
            mainSplitContainer.SplitterDistance = 180;

            // ---- navigationTreeView (Panel1) ----
            navigationTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            navigationTreeView.Location = new System.Drawing.Point(0, 0);
            navigationTreeView.Name = "navigationTreeView";
            navigationTreeView.Size = new System.Drawing.Size(180, 785);
            navigationTreeView.HideSelection = false;
            navigationTreeView.FullRowSelect = true;
            navigationTreeView.ShowLines = false;
            navigationTreeView.AfterSelect += NavigationTreeView_AfterSelect;

            // ---- mainTabControl (Panel2) ----
            mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            mainTabControl.Location = new System.Drawing.Point(0, 0);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.Size = new System.Drawing.Size(1110, 785);
            mainTabControl.SelectedIndexChanged += MainTabControl_SelectedIndexChanged;

            mainSplitContainer.Panel1.Controls.Add(navigationTreeView);
            mainSplitContainer.Panel2.Controls.Add(mainTabControl);

            // ================================================================
            // mainStatusStrip (11 status labels)
            // ================================================================
            mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                ConnectionLabel,
                ObjectLabel,
                ProcessLabel,
                LoopLabel,
                ConDelay,
                SaveDelay,
                TotalDownloadLabel,
                TotalUploadLabel,
                DownloadSpeedLabel,
                UploadSpeedLabel,
                EMailsSentLabel
            });
            mainStatusStrip.Location = new System.Drawing.Point(0, 834);
            mainStatusStrip.Name = "mainStatusStrip";
            mainStatusStrip.Size = new System.Drawing.Size(1294, 25);

            ConnectionLabel.Name = "ConnectionLabel";
            ConnectionLabel.Text = "Connections: 0";

            ObjectLabel.Name = "ObjectLabel";
            ObjectLabel.Text = "Objects: 0";

            ProcessLabel.Name = "ProcessLabel";
            ProcessLabel.Text = "Process Count: 0";

            LoopLabel.Name = "LoopLabel";
            LoopLabel.Text = "Loop Count: 0";

            ConDelay.Name = "ConDelay";
            ConDelay.Text = "Con Delay: 0ms";

            SaveDelay.Name = "SaveDelay";
            SaveDelay.Text = "Save Delay: 0ms";

            TotalDownloadLabel.Name = "TotalDownloadLabel";
            TotalDownloadLabel.Text = "Downloaded: 0B";

            TotalUploadLabel.Name = "TotalUploadLabel";
            TotalUploadLabel.Text = "Uploaded: 0B";

            DownloadSpeedLabel.Name = "DownloadSpeedLabel";
            DownloadSpeedLabel.Text = "D/L Speed: 0Bps";

            UploadSpeedLabel.Name = "UploadSpeedLabel";
            UploadSpeedLabel.Text = "U/L Speed: 0Bps";

            EMailsSentLabel.Name = "EMailsSentLabel";
            EMailsSentLabel.Text = "E-Mails Sent: 0";

            // ================================================================
            // InterfaceTimer
            // ================================================================
            InterfaceTimer.Interval = 1000;
            InterfaceTimer.Tick += InterfaceTimer_Tick;

            // ================================================================
            // SMain Form
            // ================================================================
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1294, 859);
            Controls.Add(mainSplitContainer);
            Controls.Add(pluginsToolStrip);
            Controls.Add(mainMenuStrip);
            Controls.Add(mainStatusStrip);
            MainMenuStrip = mainMenuStrip;
            Name = "SMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Zircon Server";
            Load += SMain_Load;

            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            mainSplitContainer.Panel1.ResumeLayout(false);
            mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainSplitContainer).EndInit();
            mainSplitContainer.ResumeLayout(false);
            mainStatusStrip.ResumeLayout(false);
            mainStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // ---- MenuStrip ----
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem serverMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartServerButton;
        private System.Windows.Forms.ToolStripMenuItem StopServerButton;
        private System.Windows.Forms.ToolStripMenuItem pluginsMenuItem;
        private System.Windows.Forms.ToolStrip pluginsToolStrip;

        // ---- SplitContainer + Navigation + Tabs ----
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.TreeView navigationTreeView;
        private System.Windows.Forms.TabControl mainTabControl;

        // ---- StatusStrip ----
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ConnectionLabel;
        private System.Windows.Forms.ToolStripStatusLabel ObjectLabel;
        private System.Windows.Forms.ToolStripStatusLabel ProcessLabel;
        private System.Windows.Forms.ToolStripStatusLabel LoopLabel;
        private System.Windows.Forms.ToolStripStatusLabel ConDelay;
        private System.Windows.Forms.ToolStripStatusLabel SaveDelay;
        private System.Windows.Forms.ToolStripStatusLabel TotalDownloadLabel;
        private System.Windows.Forms.ToolStripStatusLabel TotalUploadLabel;
        private System.Windows.Forms.ToolStripStatusLabel DownloadSpeedLabel;
        private System.Windows.Forms.ToolStripStatusLabel UploadSpeedLabel;
        private System.Windows.Forms.ToolStripStatusLabel EMailsSentLabel;

        // ---- Timer ----
        private System.Windows.Forms.Timer InterfaceTimer;
    }
}
