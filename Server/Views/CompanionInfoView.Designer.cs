namespace Server.Views
{
    partial class CompanionInfoView
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
            companionInfoTabPage = new System.Windows.Forms.TabPage();
            companionLevelTabPage = new System.Windows.Forms.TabPage();
            companionSkillTabPage = new System.Windows.Forms.TabPage();
            companionInfoTabControl = new System.Windows.Forms.TabControl();
            companionMainTabPage = new System.Windows.Forms.TabPage();
            companionSpeechTabPage = new System.Windows.Forms.TabPage();
            CompanionInfoGrid = new System.Windows.Forms.DataGridView();
            CompanionSpeechGrid = new System.Windows.Forms.DataGridView();
            CompanionLevelInfoGrid = new System.Windows.Forms.DataGridView();
            CompanionSkillInfoGrid = new System.Windows.Forms.DataGridView();
            CompanionActionImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();

            viewToolStrip.SuspendLayout();
            viewTabControl.SuspendLayout();
            companionInfoTabPage.SuspendLayout();
            companionLevelTabPage.SuspendLayout();
            companionSkillTabPage.SuspendLayout();
            companionInfoTabControl.SuspendLayout();
            companionMainTabPage.SuspendLayout();
            companionSpeechTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CompanionInfoGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CompanionSpeechGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CompanionLevelInfoGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CompanionSkillInfoGrid).BeginInit();
            SuspendLayout();

            // viewToolStrip
            viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { SaveButton, ImportButton, ExportButton });
            viewToolStrip.Location = new System.Drawing.Point(0, 0);
            viewToolStrip.Name = "viewToolStrip";
            viewToolStrip.Size = new System.Drawing.Size(900, 25);

            SaveButton.Name = "SaveButton"; SaveButton.Text = "Save Database"; SaveButton.Click += SaveButton_Click;
            ImportButton.Name = "ImportButton"; ImportButton.Text = "Import"; ImportButton.Click += ImportButton_Click;
            ExportButton.Name = "ExportButton"; ExportButton.Text = "Export"; ExportButton.Click += ExportButton_Click;

            // ComboBox columns
            CompanionActionImageComboBox.Name = "CompanionActionImageComboBox"; CompanionActionImageComboBox.HeaderText = "Action";

            // viewTabControl
            viewTabControl.Controls.Add(companionInfoTabPage);
            viewTabControl.Controls.Add(companionLevelTabPage);
            viewTabControl.Controls.Add(companionSkillTabPage);
            viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            viewTabControl.Location = new System.Drawing.Point(0, 25);
            viewTabControl.Name = "viewTabControl";

            // Companion Info tab (has sub-tabs)
            companionInfoTabPage.Controls.Add(companionInfoTabControl);
            companionInfoTabPage.Name = "companionInfoTabPage";
            companionInfoTabPage.Text = "Companion Info";

            // Companion Info sub-tab control
            companionInfoTabControl.Controls.Add(companionMainTabPage);
            companionInfoTabControl.Controls.Add(companionSpeechTabPage);
            companionInfoTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            companionInfoTabControl.Name = "companionInfoTabControl";

            companionMainTabPage.Controls.Add(CompanionInfoGrid); companionMainTabPage.Name = "companionMainTabPage"; companionMainTabPage.Text = "Info";
            companionSpeechTabPage.Controls.Add(CompanionSpeechGrid); companionSpeechTabPage.Name = "companionSpeechTabPage"; companionSpeechTabPage.Text = "Speech";

            CompanionInfoGrid.Dock = System.Windows.Forms.DockStyle.Fill; CompanionInfoGrid.Name = "CompanionInfoGrid"; CompanionInfoGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            CompanionSpeechGrid.Dock = System.Windows.Forms.DockStyle.Fill; CompanionSpeechGrid.Name = "CompanionSpeechGrid"; CompanionSpeechGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            CompanionSpeechGrid.Columns.Add(CompanionActionImageComboBox);

            // Companion Level tab
            companionLevelTabPage.Controls.Add(CompanionLevelInfoGrid);
            companionLevelTabPage.Name = "companionLevelTabPage";
            companionLevelTabPage.Text = "Companion Level Info";

            CompanionLevelInfoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            CompanionLevelInfoGrid.Name = "CompanionLevelInfoGrid";
            CompanionLevelInfoGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // Companion Skill tab
            companionSkillTabPage.Controls.Add(CompanionSkillInfoGrid);
            companionSkillTabPage.Name = "companionSkillTabPage";
            companionSkillTabPage.Text = "Companion Skill Info";

            CompanionSkillInfoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            CompanionSkillInfoGrid.Name = "CompanionSkillInfoGrid";
            CompanionSkillInfoGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // CompanionInfoView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(viewTabControl);
            Controls.Add(viewToolStrip);
            Name = "CompanionInfoView";
            Size = new System.Drawing.Size(900, 500);

            viewToolStrip.ResumeLayout(false); viewToolStrip.PerformLayout();
            companionMainTabPage.ResumeLayout(false); companionSpeechTabPage.ResumeLayout(false);
            companionInfoTabControl.ResumeLayout(false);
            companionInfoTabPage.ResumeLayout(false); companionLevelTabPage.ResumeLayout(false); companionSkillTabPage.ResumeLayout(false);
            viewTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CompanionInfoGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)CompanionSpeechGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)CompanionLevelInfoGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)CompanionSkillInfoGrid).EndInit();
            ResumeLayout(false); PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ImportButton;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.TabControl viewTabControl;
        private System.Windows.Forms.TabPage companionInfoTabPage;
        private System.Windows.Forms.TabPage companionLevelTabPage;
        private System.Windows.Forms.TabPage companionSkillTabPage;
        private System.Windows.Forms.TabControl companionInfoTabControl;
        private System.Windows.Forms.TabPage companionMainTabPage;
        private System.Windows.Forms.TabPage companionSpeechTabPage;
        private System.Windows.Forms.DataGridView CompanionInfoGrid;
        private System.Windows.Forms.DataGridView CompanionSpeechGrid;
        private System.Windows.Forms.DataGridView CompanionLevelInfoGrid;
        private System.Windows.Forms.DataGridView CompanionSkillInfoGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn CompanionActionImageComboBox;
    }
}
