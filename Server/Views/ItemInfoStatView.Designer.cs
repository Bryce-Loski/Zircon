namespace Server.Views
{
    partial class ItemInfoStatView
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
            ItemInfoStatDataGridView = new System.Windows.Forms.DataGridView();
            StatImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();

            viewToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ItemInfoStatDataGridView).BeginInit();
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

            // ItemInfoStatDataGridView
            ItemInfoStatDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            ItemInfoStatDataGridView.Location = new System.Drawing.Point(0, 25);
            ItemInfoStatDataGridView.Name = "ItemInfoStatDataGridView";
            ItemInfoStatDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            ItemInfoStatDataGridView.Columns.Add(StatImageComboBox);

            // ItemInfoStatView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(ItemInfoStatDataGridView);
            Controls.Add(viewToolStrip);
            Name = "ItemInfoStatView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ItemInfoStatDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ImportButton;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.DataGridView ItemInfoStatDataGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatImageComboBox;
    }
}
