namespace Server.Views
{
    partial class LootBoxInfoView
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
            itemsTabPage = new System.Windows.Forms.TabPage();
            MainGrid = new System.Windows.Forms.DataGridView();
            LootBoxItemInfoGrid = new System.Windows.Forms.DataGridView();

            viewToolStrip.SuspendLayout();
            viewTabControl.SuspendLayout();
            mainTabPage.SuspendLayout();
            itemsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LootBoxItemInfoGrid).BeginInit();
            SuspendLayout();

            // viewToolStrip
            viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { SaveButton, ImportButton, ExportButton });
            viewToolStrip.Location = new System.Drawing.Point(0, 0);
            viewToolStrip.Name = "viewToolStrip";
            viewToolStrip.Size = new System.Drawing.Size(800, 25);

            SaveButton.Name = "SaveButton"; SaveButton.Text = "Save Database"; SaveButton.Click += SaveButton_Click;
            ImportButton.Name = "ImportButton"; ImportButton.Text = "Import"; ImportButton.Click += ImportButton_Click;
            ExportButton.Name = "ExportButton"; ExportButton.Text = "Export"; ExportButton.Click += ExportButton_Click;

            // viewTabControl
            viewTabControl.Controls.Add(mainTabPage);
            viewTabControl.Controls.Add(itemsTabPage);
            viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            viewTabControl.Location = new System.Drawing.Point(0, 25);
            viewTabControl.Name = "viewTabControl";

            // mainTabPage
            mainTabPage.Controls.Add(MainGrid);
            mainTabPage.Name = "mainTabPage";
            mainTabPage.Text = "Loot Box Info";

            // itemsTabPage
            itemsTabPage.Controls.Add(LootBoxItemInfoGrid);
            itemsTabPage.Name = "itemsTabPage";
            itemsTabPage.Text = "Items";

            // MainGrid
            MainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            MainGrid.Name = "MainGrid";
            MainGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // LootBoxItemInfoGrid
            LootBoxItemInfoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            LootBoxItemInfoGrid.Name = "LootBoxItemInfoGrid";
            LootBoxItemInfoGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // LootBoxInfoView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(viewTabControl);
            Controls.Add(viewToolStrip);
            Name = "LootBoxInfoView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            mainTabPage.ResumeLayout(false);
            itemsTabPage.ResumeLayout(false);
            viewTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)LootBoxItemInfoGrid).EndInit();
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
        private System.Windows.Forms.TabPage itemsTabPage;
        private System.Windows.Forms.DataGridView MainGrid;
        private System.Windows.Forms.DataGridView LootBoxItemInfoGrid;
    }
}
