namespace Server.Views
{
    partial class HelpInfoView
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
            HelpTabPage = new System.Windows.Forms.TabPage();
            PageTabPage = new System.Windows.Forms.TabPage();
            ItemTabPage = new System.Windows.Forms.TabPage();
            HelpDataGridView = new System.Windows.Forms.DataGridView();
            PageDataGridView = new System.Windows.Forms.DataGridView();
            ItemDataGridView = new System.Windows.Forms.DataGridView();

            viewToolStrip.SuspendLayout();
            viewTabControl.SuspendLayout();
            HelpTabPage.SuspendLayout();
            PageTabPage.SuspendLayout();
            ItemTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HelpDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PageDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemDataGridView).BeginInit();
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
            viewTabControl.Controls.Add(HelpTabPage);
            viewTabControl.Controls.Add(PageTabPage);
            viewTabControl.Controls.Add(ItemTabPage);
            viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            viewTabControl.Location = new System.Drawing.Point(0, 25);
            viewTabControl.Name = "viewTabControl";

            // HelpTabPage
            HelpTabPage.Controls.Add(HelpDataGridView);
            HelpTabPage.Name = "HelpTabPage";
            HelpTabPage.Text = "Help";

            // PageTabPage
            PageTabPage.Controls.Add(PageDataGridView);
            PageTabPage.Name = "PageTabPage";
            PageTabPage.Text = "Pages";

            // ItemTabPage
            ItemTabPage.Controls.Add(ItemDataGridView);
            ItemTabPage.Name = "ItemTabPage";
            ItemTabPage.Text = "Items";

            // HelpDataGridView
            HelpDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            HelpDataGridView.Name = "HelpDataGridView";
            HelpDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // PageDataGridView
            PageDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            PageDataGridView.Name = "PageDataGridView";
            PageDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // ItemDataGridView
            ItemDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            ItemDataGridView.Name = "ItemDataGridView";
            ItemDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // HelpInfoView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(viewTabControl);
            Controls.Add(viewToolStrip);
            Name = "HelpInfoView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            HelpTabPage.ResumeLayout(false);
            PageTabPage.ResumeLayout(false);
            ItemTabPage.ResumeLayout(false);
            viewTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)HelpDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)PageDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ImportButton;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.TabControl viewTabControl;
        private System.Windows.Forms.TabPage HelpTabPage;
        private System.Windows.Forms.TabPage PageTabPage;
        private System.Windows.Forms.TabPage ItemTabPage;
        private System.Windows.Forms.DataGridView HelpDataGridView;
        private System.Windows.Forms.DataGridView PageDataGridView;
        private System.Windows.Forms.DataGridView ItemDataGridView;
    }
}
