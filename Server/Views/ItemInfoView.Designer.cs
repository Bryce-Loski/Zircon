namespace Server.Views
{
    partial class ItemInfoView
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
            itemInfoTabPage = new System.Windows.Forms.TabPage();
            itemStatsTabPage = new System.Windows.Forms.TabPage();
            dropsTabPage = new System.Windows.Forms.TabPage();
            ItemInfoGrid = new System.Windows.Forms.DataGridView();
            ItemStatsGrid = new System.Windows.Forms.DataGridView();
            DropsGrid = new System.Windows.Forms.DataGridView();
            ItemTypeImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            RequiredClassImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            RequiredGenderImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            StatImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            RequiredTypeImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();

            viewToolStrip.SuspendLayout();
            viewTabControl.SuspendLayout();
            itemInfoTabPage.SuspendLayout();
            itemStatsTabPage.SuspendLayout();
            dropsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ItemInfoGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemStatsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DropsGrid).BeginInit();
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
            ItemTypeImageComboBox.Name = "ItemTypeImageComboBox"; ItemTypeImageComboBox.HeaderText = "Item Type";
            RequiredClassImageComboBox.Name = "RequiredClassImageComboBox"; RequiredClassImageComboBox.HeaderText = "Required Class";
            RequiredGenderImageComboBox.Name = "RequiredGenderImageComboBox"; RequiredGenderImageComboBox.HeaderText = "Required Gender";
            StatImageComboBox.Name = "StatImageComboBox"; StatImageComboBox.HeaderText = "Stat";
            RequiredTypeImageComboBox.Name = "RequiredTypeImageComboBox"; RequiredTypeImageComboBox.HeaderText = "Required Type";

            // viewTabControl
            viewTabControl.Controls.Add(itemInfoTabPage);
            viewTabControl.Controls.Add(itemStatsTabPage);
            viewTabControl.Controls.Add(dropsTabPage);
            viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            viewTabControl.Location = new System.Drawing.Point(0, 25);
            viewTabControl.Name = "viewTabControl";

            // itemInfoTabPage
            itemInfoTabPage.Controls.Add(ItemInfoGrid);
            itemInfoTabPage.Name = "itemInfoTabPage";
            itemInfoTabPage.Text = "Item Info";

            // itemStatsTabPage
            itemStatsTabPage.Controls.Add(ItemStatsGrid);
            itemStatsTabPage.Name = "itemStatsTabPage";
            itemStatsTabPage.Text = "Item Stats";

            // dropsTabPage
            dropsTabPage.Controls.Add(DropsGrid);
            dropsTabPage.Name = "dropsTabPage";
            dropsTabPage.Text = "Drops";

            // ItemInfoGrid
            ItemInfoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            ItemInfoGrid.Name = "ItemInfoGrid";
            ItemInfoGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            ItemInfoGrid.Columns.Add(ItemTypeImageComboBox);
            ItemInfoGrid.Columns.Add(RequiredClassImageComboBox);
            ItemInfoGrid.Columns.Add(RequiredGenderImageComboBox);
            ItemInfoGrid.Columns.Add(RequiredTypeImageComboBox);

            // ItemStatsGrid
            ItemStatsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            ItemStatsGrid.Name = "ItemStatsGrid";
            ItemStatsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            ItemStatsGrid.Columns.Add(StatImageComboBox);

            // DropsGrid
            DropsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            DropsGrid.Name = "DropsGrid";
            DropsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // ItemInfoView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(viewTabControl);
            Controls.Add(viewToolStrip);
            Name = "ItemInfoView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            itemInfoTabPage.ResumeLayout(false);
            itemStatsTabPage.ResumeLayout(false);
            dropsTabPage.ResumeLayout(false);
            viewTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ItemInfoGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemStatsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)DropsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ImportButton;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.TabControl viewTabControl;
        private System.Windows.Forms.TabPage itemInfoTabPage;
        private System.Windows.Forms.TabPage itemStatsTabPage;
        private System.Windows.Forms.TabPage dropsTabPage;
        private System.Windows.Forms.DataGridView ItemInfoGrid;
        private System.Windows.Forms.DataGridView ItemStatsGrid;
        private System.Windows.Forms.DataGridView DropsGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn ItemTypeImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn RequiredClassImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn RequiredGenderImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn RequiredTypeImageComboBox;
    }
}
