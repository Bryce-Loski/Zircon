namespace Server.Views
{
    partial class MonsterInfoStatView
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
            MonsterInfoStatDataGridView = new System.Windows.Forms.DataGridView();
            StatImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();

            viewToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MonsterInfoStatDataGridView).BeginInit();
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

            // MonsterInfoStatDataGridView
            MonsterInfoStatDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            MonsterInfoStatDataGridView.Location = new System.Drawing.Point(0, 25);
            MonsterInfoStatDataGridView.Name = "MonsterInfoStatDataGridView";
            MonsterInfoStatDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            MonsterInfoStatDataGridView.Columns.Add(StatImageComboBox);

            // MonsterInfoStatView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(MonsterInfoStatDataGridView);
            Controls.Add(viewToolStrip);
            Name = "MonsterInfoStatView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MonsterInfoStatDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ImportButton;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.DataGridView MonsterInfoStatDataGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatImageComboBox;
    }
}
