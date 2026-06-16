namespace Server.Views
{
    partial class SetInfoView
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
            SetInfoTabPage = new System.Windows.Forms.TabPage();
            SetStatsTabPage = new System.Windows.Forms.TabPage();
            SetInfoDataGridView = new System.Windows.Forms.DataGridView();
            SetStatsDataGridView = new System.Windows.Forms.DataGridView();
            StatImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            RequiredClassImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();

            viewToolStrip.SuspendLayout();
            viewTabControl.SuspendLayout();
            SetInfoTabPage.SuspendLayout();
            SetStatsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SetInfoDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SetStatsDataGridView).BeginInit();
            SuspendLayout();

            // viewToolStrip
            viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { SaveButton, ImportButton, ExportButton });
            viewToolStrip.Location = new System.Drawing.Point(0, 0);
            viewToolStrip.Name = "viewToolStrip";
            viewToolStrip.Size = new System.Drawing.Size(800, 25);

            SaveButton.Name = "SaveButton"; SaveButton.Text = "Save Database"; SaveButton.Click += SaveButton_Click;
            ImportButton.Name = "ImportButton"; ImportButton.Text = "Import"; ImportButton.Click += ImportButton_Click;
            ExportButton.Name = "ExportButton"; ExportButton.Text = "Export"; ExportButton.Click += ExportButton_Click;

            // StatImageComboBox
            StatImageComboBox.Name = "StatImageComboBox";
            StatImageComboBox.HeaderText = "Stat";

            // RequiredClassImageComboBox
            RequiredClassImageComboBox.Name = "RequiredClassImageComboBox";
            RequiredClassImageComboBox.HeaderText = "Class";

            // viewTabControl
            viewTabControl.Controls.Add(SetInfoTabPage);
            viewTabControl.Controls.Add(SetStatsTabPage);
            viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            viewTabControl.Location = new System.Drawing.Point(0, 25);
            viewTabControl.Name = "viewTabControl";

            // SetInfoTabPage
            SetInfoTabPage.Controls.Add(SetInfoDataGridView);
            SetInfoTabPage.Name = "SetInfoTabPage";
            SetInfoTabPage.Text = "Set Info";

            // SetStatsTabPage
            SetStatsTabPage.Controls.Add(SetStatsDataGridView);
            SetStatsTabPage.Name = "SetStatsTabPage";
            SetStatsTabPage.Text = "Set Stats";

            // SetInfoDataGridView
            SetInfoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            SetInfoDataGridView.Name = "SetInfoDataGridView";
            SetInfoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // SetStatsDataGridView
            SetStatsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            SetStatsDataGridView.Name = "SetStatsDataGridView";
            SetStatsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            SetStatsDataGridView.Columns.Add(StatImageComboBox);
            SetStatsDataGridView.Columns.Add(RequiredClassImageComboBox);

            // SetInfoView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(viewTabControl);
            Controls.Add(viewToolStrip);
            Name = "SetInfoView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            SetInfoTabPage.ResumeLayout(false);
            SetStatsTabPage.ResumeLayout(false);
            viewTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SetInfoDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)SetStatsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ImportButton;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.TabControl viewTabControl;
        private System.Windows.Forms.TabPage SetInfoTabPage;
        private System.Windows.Forms.TabPage SetStatsTabPage;
        private System.Windows.Forms.DataGridView SetInfoDataGridView;
        private System.Windows.Forms.DataGridView SetStatsDataGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn RequiredClassImageComboBox;
    }
}
