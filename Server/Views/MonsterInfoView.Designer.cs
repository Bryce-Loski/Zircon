namespace Server.Views
{
    partial class MonsterInfoView
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
            UpdateMonsterImageButton = new System.Windows.Forms.ToolStripButton();
            viewTabControl = new System.Windows.Forms.TabControl();
            monsterInfoTabPage = new System.Windows.Forms.TabPage();
            monsterStatsTabPage = new System.Windows.Forms.TabPage();
            dropsTabPage = new System.Windows.Forms.TabPage();
            respawnsTabPage = new System.Windows.Forms.TabPage();
            MonsterInfoGrid = new System.Windows.Forms.DataGridView();
            MonsterInfoStatsGrid = new System.Windows.Forms.DataGridView();
            DropsGrid = new System.Windows.Forms.DataGridView();
            RespawnsGrid = new System.Windows.Forms.DataGridView();
            MonsterImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            StatComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();

            viewToolStrip.SuspendLayout();
            viewTabControl.SuspendLayout();
            monsterInfoTabPage.SuspendLayout();
            monsterStatsTabPage.SuspendLayout();
            dropsTabPage.SuspendLayout();
            respawnsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MonsterInfoGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MonsterInfoStatsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DropsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RespawnsGrid).BeginInit();
            SuspendLayout();

            // viewToolStrip
            viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { SaveButton, ImportButton, ExportButton, UpdateMonsterImageButton });
            viewToolStrip.Location = new System.Drawing.Point(0, 0);
            viewToolStrip.Name = "viewToolStrip";
            viewToolStrip.Size = new System.Drawing.Size(800, 25);

            SaveButton.Name = "SaveButton"; SaveButton.Text = "Save Database"; SaveButton.Click += SaveButton_Click;
            ImportButton.Name = "ImportButton"; ImportButton.Text = "Import"; ImportButton.Click += ImportButton_Click;
            ExportButton.Name = "ExportButton"; ExportButton.Text = "Export"; ExportButton.Click += ExportButton_Click;
            UpdateMonsterImageButton.Name = "UpdateMonsterImageButton"; UpdateMonsterImageButton.Text = "Convert Old to New"; UpdateMonsterImageButton.Click += UpdateMonsterImageButton_Click;

            // ComboBox columns
            MonsterImageComboBox.Name = "MonsterImageComboBox"; MonsterImageComboBox.HeaderText = "Image";
            StatComboBox.Name = "StatComboBox"; StatComboBox.HeaderText = "Stat";

            // viewTabControl
            viewTabControl.Controls.Add(monsterInfoTabPage);
            viewTabControl.Controls.Add(monsterStatsTabPage);
            viewTabControl.Controls.Add(dropsTabPage);
            viewTabControl.Controls.Add(respawnsTabPage);
            viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            viewTabControl.Location = new System.Drawing.Point(0, 25);
            viewTabControl.Name = "viewTabControl";

            // monsterInfoTabPage
            monsterInfoTabPage.Controls.Add(MonsterInfoGrid);
            monsterInfoTabPage.Name = "monsterInfoTabPage";
            monsterInfoTabPage.Text = "Monster Info";

            // monsterStatsTabPage
            monsterStatsTabPage.Controls.Add(MonsterInfoStatsGrid);
            monsterStatsTabPage.Name = "monsterStatsTabPage";
            monsterStatsTabPage.Text = "Monster Stats";

            // dropsTabPage
            dropsTabPage.Controls.Add(DropsGrid);
            dropsTabPage.Name = "dropsTabPage";
            dropsTabPage.Text = "Drops";

            // respawnsTabPage
            respawnsTabPage.Controls.Add(RespawnsGrid);
            respawnsTabPage.Name = "respawnsTabPage";
            respawnsTabPage.Text = "Respawns";

            // MonsterInfoGrid
            MonsterInfoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            MonsterInfoGrid.Name = "MonsterInfoGrid";
            MonsterInfoGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            MonsterInfoGrid.Columns.Add(MonsterImageComboBox);

            // MonsterInfoStatsGrid
            MonsterInfoStatsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            MonsterInfoStatsGrid.Name = "MonsterInfoStatsGrid";
            MonsterInfoStatsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            MonsterInfoStatsGrid.Columns.Add(StatComboBox);

            // DropsGrid
            DropsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            DropsGrid.Name = "DropsGrid";
            DropsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // RespawnsGrid
            RespawnsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            RespawnsGrid.Name = "RespawnsGrid";
            RespawnsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // MonsterInfoView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(viewTabControl);
            Controls.Add(viewToolStrip);
            Name = "MonsterInfoView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            monsterInfoTabPage.ResumeLayout(false);
            monsterStatsTabPage.ResumeLayout(false);
            dropsTabPage.ResumeLayout(false);
            respawnsTabPage.ResumeLayout(false);
            viewTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MonsterInfoGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)MonsterInfoStatsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)DropsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)RespawnsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ImportButton;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.ToolStripButton UpdateMonsterImageButton;
        private System.Windows.Forms.TabControl viewTabControl;
        private System.Windows.Forms.TabPage monsterInfoTabPage;
        private System.Windows.Forms.TabPage monsterStatsTabPage;
        private System.Windows.Forms.TabPage dropsTabPage;
        private System.Windows.Forms.TabPage respawnsTabPage;
        private System.Windows.Forms.DataGridView MonsterInfoGrid;
        private System.Windows.Forms.DataGridView MonsterInfoStatsGrid;
        private System.Windows.Forms.DataGridView DropsGrid;
        private System.Windows.Forms.DataGridView RespawnsGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn MonsterImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatComboBox;
    }
}
