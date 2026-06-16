namespace Server.Views
{
    partial class EventInfoView
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
            viewToolStrip = new System.Windows.Forms.ToolStrip();
            SaveButton = new System.Windows.Forms.ToolStripButton();
            ImportButton = new System.Windows.Forms.ToolStripButton();
            ExportButton = new System.Windows.Forms.ToolStripButton();
            viewTabControl = new System.Windows.Forms.TabControl();
            worldOuterTabPage = new System.Windows.Forms.TabPage();
            playerOuterTabPage = new System.Windows.Forms.TabPage();
            monsterOuterTabPage = new System.Windows.Forms.TabPage();
            worldTabControl = new System.Windows.Forms.TabControl();
            playerTabControl = new System.Windows.Forms.TabControl();
            monsterTabControl = new System.Windows.Forms.TabControl();
            worldMainTabPage = new System.Windows.Forms.TabPage();
            worldTriggersTabPage = new System.Windows.Forms.TabPage();
            worldActionsTabPage = new System.Windows.Forms.TabPage();
            playerMainTabPage = new System.Windows.Forms.TabPage();
            playerTriggersTabPage = new System.Windows.Forms.TabPage();
            playerActionsTabPage = new System.Windows.Forms.TabPage();
            monsterMainTabPage = new System.Windows.Forms.TabPage();
            monsterTriggersTabPage = new System.Windows.Forms.TabPage();
            monsterActionsTabPage = new System.Windows.Forms.TabPage();
            WorldEventInfoGrid = new System.Windows.Forms.DataGridView();
            WorldTriggersGrid = new System.Windows.Forms.DataGridView();
            WorldActionsGrid = new System.Windows.Forms.DataGridView();
            PlayerEventInfoGrid = new System.Windows.Forms.DataGridView();
            PlayerTriggersGrid = new System.Windows.Forms.DataGridView();
            PlayerActionsGrid = new System.Windows.Forms.DataGridView();
            MonsterEventInfoGrid = new System.Windows.Forms.DataGridView();
            MonsterTriggersGrid = new System.Windows.Forms.DataGridView();
            MonsterActionsGrid = new System.Windows.Forms.DataGridView();

            viewToolStrip.SuspendLayout();
            viewTabControl.SuspendLayout();
            worldOuterTabPage.SuspendLayout();
            playerOuterTabPage.SuspendLayout();
            monsterOuterTabPage.SuspendLayout();
            worldTabControl.SuspendLayout();
            playerTabControl.SuspendLayout();
            monsterTabControl.SuspendLayout();
            worldMainTabPage.SuspendLayout();
            worldTriggersTabPage.SuspendLayout();
            worldActionsTabPage.SuspendLayout();
            playerMainTabPage.SuspendLayout();
            playerTriggersTabPage.SuspendLayout();
            playerActionsTabPage.SuspendLayout();
            monsterMainTabPage.SuspendLayout();
            monsterTriggersTabPage.SuspendLayout();
            monsterActionsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)WorldEventInfoGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WorldTriggersGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WorldActionsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerEventInfoGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerTriggersGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerActionsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MonsterEventInfoGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MonsterTriggersGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MonsterActionsGrid).BeginInit();
            SuspendLayout();

            // viewToolStrip
            viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { SaveButton, ImportButton, ExportButton });
            viewToolStrip.Location = new System.Drawing.Point(0, 0);
            viewToolStrip.Name = "viewToolStrip";
            viewToolStrip.Size = new System.Drawing.Size(900, 25);

            SaveButton.Name = "SaveButton"; SaveButton.Text = "Save Database"; SaveButton.Click += SaveButton_Click;
            ImportButton.Name = "ImportButton"; ImportButton.Text = "Import"; ImportButton.Click += ImportButton_Click;
            ExportButton.Name = "ExportButton"; ExportButton.Text = "Export"; ExportButton.Click += ExportButton_Click;

            // viewTabControl
            viewTabControl.Controls.Add(worldOuterTabPage);
            viewTabControl.Controls.Add(playerOuterTabPage);
            viewTabControl.Controls.Add(monsterOuterTabPage);
            viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            viewTabControl.Location = new System.Drawing.Point(0, 25);
            viewTabControl.Name = "viewTabControl";

            // World outer tab
            worldOuterTabPage.Controls.Add(worldTabControl);
            worldOuterTabPage.Name = "worldOuterTabPage";
            worldOuterTabPage.Text = "World Event Info";

            // World inner tabs
            worldTabControl.Controls.Add(worldMainTabPage);
            worldTabControl.Controls.Add(worldTriggersTabPage);
            worldTabControl.Controls.Add(worldActionsTabPage);
            worldTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            worldTabControl.Name = "worldTabControl";

            worldMainTabPage.Controls.Add(WorldEventInfoGrid); worldMainTabPage.Name = "worldMainTabPage"; worldMainTabPage.Text = "Events";
            worldTriggersTabPage.Controls.Add(WorldTriggersGrid); worldTriggersTabPage.Name = "worldTriggersTabPage"; worldTriggersTabPage.Text = "Triggers";
            worldActionsTabPage.Controls.Add(WorldActionsGrid); worldActionsTabPage.Name = "worldActionsTabPage"; worldActionsTabPage.Text = "Actions";

            WorldEventInfoGrid.Dock = System.Windows.Forms.DockStyle.Fill; WorldEventInfoGrid.Name = "WorldEventInfoGrid"; WorldEventInfoGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            WorldTriggersGrid.Dock = System.Windows.Forms.DockStyle.Fill; WorldTriggersGrid.Name = "WorldTriggersGrid"; WorldTriggersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            WorldActionsGrid.Dock = System.Windows.Forms.DockStyle.Fill; WorldActionsGrid.Name = "WorldActionsGrid"; WorldActionsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // Player outer tab
            playerOuterTabPage.Controls.Add(playerTabControl);
            playerOuterTabPage.Name = "playerOuterTabPage";
            playerOuterTabPage.Text = "Player Event Info";

            // Player inner tabs
            playerTabControl.Controls.Add(playerMainTabPage);
            playerTabControl.Controls.Add(playerTriggersTabPage);
            playerTabControl.Controls.Add(playerActionsTabPage);
            playerTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            playerTabControl.Name = "playerTabControl";

            playerMainTabPage.Controls.Add(PlayerEventInfoGrid); playerMainTabPage.Name = "playerMainTabPage"; playerMainTabPage.Text = "Events";
            playerTriggersTabPage.Controls.Add(PlayerTriggersGrid); playerTriggersTabPage.Name = "playerTriggersTabPage"; playerTriggersTabPage.Text = "Triggers";
            playerActionsTabPage.Controls.Add(PlayerActionsGrid); playerActionsTabPage.Name = "playerActionsTabPage"; playerActionsTabPage.Text = "Actions";

            PlayerEventInfoGrid.Dock = System.Windows.Forms.DockStyle.Fill; PlayerEventInfoGrid.Name = "PlayerEventInfoGrid"; PlayerEventInfoGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            PlayerTriggersGrid.Dock = System.Windows.Forms.DockStyle.Fill; PlayerTriggersGrid.Name = "PlayerTriggersGrid"; PlayerTriggersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            PlayerActionsGrid.Dock = System.Windows.Forms.DockStyle.Fill; PlayerActionsGrid.Name = "PlayerActionsGrid"; PlayerActionsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // Monster outer tab
            monsterOuterTabPage.Controls.Add(monsterTabControl);
            monsterOuterTabPage.Name = "monsterOuterTabPage";
            monsterOuterTabPage.Text = "Monster Event Info";

            // Monster inner tabs
            monsterTabControl.Controls.Add(monsterMainTabPage);
            monsterTabControl.Controls.Add(monsterTriggersTabPage);
            monsterTabControl.Controls.Add(monsterActionsTabPage);
            monsterTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            monsterTabControl.Name = "monsterTabControl";

            monsterMainTabPage.Controls.Add(MonsterEventInfoGrid); monsterMainTabPage.Name = "monsterMainTabPage"; monsterMainTabPage.Text = "Events";
            monsterTriggersTabPage.Controls.Add(MonsterTriggersGrid); monsterTriggersTabPage.Name = "monsterTriggersTabPage"; monsterTriggersTabPage.Text = "Triggers";
            monsterActionsTabPage.Controls.Add(MonsterActionsGrid); monsterActionsTabPage.Name = "monsterActionsTabPage"; monsterActionsTabPage.Text = "Actions";

            MonsterEventInfoGrid.Dock = System.Windows.Forms.DockStyle.Fill; MonsterEventInfoGrid.Name = "MonsterEventInfoGrid"; MonsterEventInfoGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            MonsterTriggersGrid.Dock = System.Windows.Forms.DockStyle.Fill; MonsterTriggersGrid.Name = "MonsterTriggersGrid"; MonsterTriggersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            MonsterActionsGrid.Dock = System.Windows.Forms.DockStyle.Fill; MonsterActionsGrid.Name = "MonsterActionsGrid"; MonsterActionsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // EventInfoView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(viewTabControl);
            Controls.Add(viewToolStrip);
            Name = "EventInfoView";
            Size = new System.Drawing.Size(900, 550);

            viewToolStrip.ResumeLayout(false); viewToolStrip.PerformLayout();
            worldMainTabPage.ResumeLayout(false); worldTriggersTabPage.ResumeLayout(false); worldActionsTabPage.ResumeLayout(false);
            playerMainTabPage.ResumeLayout(false); playerTriggersTabPage.ResumeLayout(false); playerActionsTabPage.ResumeLayout(false);
            monsterMainTabPage.ResumeLayout(false); monsterTriggersTabPage.ResumeLayout(false); monsterActionsTabPage.ResumeLayout(false);
            worldTabControl.ResumeLayout(false); playerTabControl.ResumeLayout(false); monsterTabControl.ResumeLayout(false);
            worldOuterTabPage.ResumeLayout(false); playerOuterTabPage.ResumeLayout(false); monsterOuterTabPage.ResumeLayout(false);
            viewTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)WorldEventInfoGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)WorldTriggersGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)WorldActionsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerEventInfoGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerTriggersGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerActionsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)MonsterEventInfoGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)MonsterTriggersGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)MonsterActionsGrid).EndInit();
            ResumeLayout(false); PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ImportButton;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.TabControl viewTabControl;
        private System.Windows.Forms.TabPage worldOuterTabPage;
        private System.Windows.Forms.TabPage playerOuterTabPage;
        private System.Windows.Forms.TabPage monsterOuterTabPage;
        private System.Windows.Forms.TabControl worldTabControl;
        private System.Windows.Forms.TabControl playerTabControl;
        private System.Windows.Forms.TabControl monsterTabControl;
        private System.Windows.Forms.TabPage worldMainTabPage;
        private System.Windows.Forms.TabPage worldTriggersTabPage;
        private System.Windows.Forms.TabPage worldActionsTabPage;
        private System.Windows.Forms.TabPage playerMainTabPage;
        private System.Windows.Forms.TabPage playerTriggersTabPage;
        private System.Windows.Forms.TabPage playerActionsTabPage;
        private System.Windows.Forms.TabPage monsterMainTabPage;
        private System.Windows.Forms.TabPage monsterTriggersTabPage;
        private System.Windows.Forms.TabPage monsterActionsTabPage;
        private System.Windows.Forms.DataGridView WorldEventInfoGrid;
        private System.Windows.Forms.DataGridView WorldTriggersGrid;
        private System.Windows.Forms.DataGridView WorldActionsGrid;
        private System.Windows.Forms.DataGridView PlayerEventInfoGrid;
        private System.Windows.Forms.DataGridView PlayerTriggersGrid;
        private System.Windows.Forms.DataGridView PlayerActionsGrid;
        private System.Windows.Forms.DataGridView MonsterEventInfoGrid;
        private System.Windows.Forms.DataGridView MonsterTriggersGrid;
        private System.Windows.Forms.DataGridView MonsterActionsGrid;
    }
}
