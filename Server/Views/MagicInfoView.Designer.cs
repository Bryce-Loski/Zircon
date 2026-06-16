namespace Server.Views
{
    partial class MagicInfoView
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
            MainGrid = new System.Windows.Forms.DataGridView();
            MagicImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            SchoolImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            PropertyImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ClassImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();

            viewToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainGrid).BeginInit();
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
            MagicImageComboBox.Name = "MagicImageComboBox"; MagicImageComboBox.HeaderText = "Magic";
            SchoolImageComboBox.Name = "SchoolImageComboBox"; SchoolImageComboBox.HeaderText = "School";
            PropertyImageComboBox.Name = "PropertyImageComboBox"; PropertyImageComboBox.HeaderText = "Property";
            ClassImageComboBox.Name = "ClassImageComboBox"; ClassImageComboBox.HeaderText = "Class";

            // MainGrid
            MainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            MainGrid.Location = new System.Drawing.Point(0, 25);
            MainGrid.Name = "MainGrid";
            MainGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            MainGrid.Columns.Add(MagicImageComboBox);
            MainGrid.Columns.Add(SchoolImageComboBox);
            MainGrid.Columns.Add(PropertyImageComboBox);
            MainGrid.Columns.Add(ClassImageComboBox);

            // MagicInfoView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(MainGrid);
            Controls.Add(viewToolStrip);
            Name = "MagicInfoView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MainGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ImportButton;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.DataGridView MainGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn MagicImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn SchoolImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn PropertyImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn ClassImageComboBox;
    }
}
