namespace Server.Views
{
    partial class InstanceInfoView
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
            mainTabPage = new System.Windows.Forms.TabPage();
            mapsTabPage = new System.Windows.Forms.TabPage();
            statsTabPage = new System.Windows.Forms.TabPage();
            MainGrid = new System.Windows.Forms.DataGridView();
            InstanceMapGrid = new System.Windows.Forms.DataGridView();
            InstanceInfoStatsGrid = new System.Windows.Forms.DataGridView();
            InstanceTypeImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            StatComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();

            viewToolStrip.SuspendLayout();
            viewTabControl.SuspendLayout();
            mainTabPage.SuspendLayout();
            mapsTabPage.SuspendLayout();
            statsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InstanceMapGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InstanceInfoStatsGrid).BeginInit();
            SuspendLayout();

            // viewToolStrip
            viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { SaveButton, ImportButton, ExportButton });
            viewToolStrip.Location = new System.Drawing.Point(0, 0);
            viewToolStrip.Name = "viewToolStrip";
            viewToolStrip.Size = new System.Drawing.Size(800, 25);

            SaveButton.Name = "SaveButton"; SaveButton.Text = "Save Database"; SaveButton.Click += SaveButton_Click;
            ImportButton.Name = "ImportButton"; ImportButton.Text = "Import"; ImportButton.Click += ImportButton_Click;
            ExportButton.Name = "ExportButton"; ExportButton.Text = "Export"; ExportButton.Click += ExportButton_Click;

            // ComboBox columns
            InstanceTypeImageComboBox.Name = "InstanceTypeImageComboBox"; InstanceTypeImageComboBox.HeaderText = "Type";
            StatComboBox.Name = "StatComboBox"; StatComboBox.HeaderText = "Stat";

            // viewTabControl
            viewTabControl.Controls.Add(mainTabPage);
            viewTabControl.Controls.Add(mapsTabPage);
            viewTabControl.Controls.Add(statsTabPage);
            viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            viewTabControl.Location = new System.Drawing.Point(0, 25);
            viewTabControl.Name = "viewTabControl";

            // mainTabPage
            mainTabPage.Controls.Add(MainGrid);
            mainTabPage.Name = "mainTabPage";
            mainTabPage.Text = "Instance Info";

            // mapsTabPage
            mapsTabPage.Controls.Add(InstanceMapGrid);
            mapsTabPage.Name = "mapsTabPage";
            mapsTabPage.Text = "Maps";

            // statsTabPage
            statsTabPage.Controls.Add(InstanceInfoStatsGrid);
            statsTabPage.Name = "statsTabPage";
            statsTabPage.Text = "Stats";

            // MainGrid
            MainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            MainGrid.Name = "MainGrid";
            MainGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            MainGrid.Columns.Add(InstanceTypeImageComboBox);

            // InstanceMapGrid
            InstanceMapGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            InstanceMapGrid.Name = "InstanceMapGrid";
            InstanceMapGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // InstanceInfoStatsGrid
            InstanceInfoStatsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            InstanceInfoStatsGrid.Name = "InstanceInfoStatsGrid";
            InstanceInfoStatsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            InstanceInfoStatsGrid.Columns.Add(StatComboBox);

            // InstanceInfoView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(viewTabControl);
            Controls.Add(viewToolStrip);
            Name = "InstanceInfoView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            mainTabPage.ResumeLayout(false);
            mapsTabPage.ResumeLayout(false);
            statsTabPage.ResumeLayout(false);
            viewTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)InstanceMapGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)InstanceInfoStatsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ImportButton;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.TabControl viewTabControl;
        private System.Windows.Forms.TabPage mainTabPage;
        private System.Windows.Forms.TabPage mapsTabPage;
        private System.Windows.Forms.TabPage statsTabPage;
        private System.Windows.Forms.DataGridView MainGrid;
        private System.Windows.Forms.DataGridView InstanceMapGrid;
        private System.Windows.Forms.DataGridView InstanceInfoStatsGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn InstanceTypeImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatComboBox;
    }
}
