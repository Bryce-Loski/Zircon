namespace Server.Views
{
    partial class CurrencyInfoView
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
            imagesTabPage = new System.Windows.Forms.TabPage();
            MainGrid = new System.Windows.Forms.DataGridView();
            CurrencyInfoImageGrid = new System.Windows.Forms.DataGridView();
            CurrencyTypeImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            CurrencyCategoryImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();

            viewToolStrip.SuspendLayout();
            viewTabControl.SuspendLayout();
            mainTabPage.SuspendLayout();
            imagesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CurrencyInfoImageGrid).BeginInit();
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
            CurrencyTypeImageComboBox.Name = "CurrencyTypeImageComboBox"; CurrencyTypeImageComboBox.HeaderText = "Type";
            CurrencyCategoryImageComboBox.Name = "CurrencyCategoryImageComboBox"; CurrencyCategoryImageComboBox.HeaderText = "Category";

            // viewTabControl
            viewTabControl.Controls.Add(mainTabPage);
            viewTabControl.Controls.Add(imagesTabPage);
            viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            viewTabControl.Location = new System.Drawing.Point(0, 25);
            viewTabControl.Name = "viewTabControl";

            // mainTabPage
            mainTabPage.Controls.Add(MainGrid);
            mainTabPage.Name = "mainTabPage";
            mainTabPage.Text = "Currency Info";

            // imagesTabPage
            imagesTabPage.Controls.Add(CurrencyInfoImageGrid);
            imagesTabPage.Name = "imagesTabPage";
            imagesTabPage.Text = "Images";

            // MainGrid
            MainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            MainGrid.Name = "MainGrid";
            MainGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            MainGrid.Columns.Add(CurrencyTypeImageComboBox);
            MainGrid.Columns.Add(CurrencyCategoryImageComboBox);

            // CurrencyInfoImageGrid
            CurrencyInfoImageGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            CurrencyInfoImageGrid.Name = "CurrencyInfoImageGrid";
            CurrencyInfoImageGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // CurrencyInfoView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(viewTabControl);
            Controls.Add(viewToolStrip);
            Name = "CurrencyInfoView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            mainTabPage.ResumeLayout(false);
            imagesTabPage.ResumeLayout(false);
            viewTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)CurrencyInfoImageGrid).EndInit();
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
        private System.Windows.Forms.TabPage imagesTabPage;
        private System.Windows.Forms.DataGridView MainGrid;
        private System.Windows.Forms.DataGridView CurrencyInfoImageGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn CurrencyTypeImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn CurrencyCategoryImageComboBox;
    }
}
