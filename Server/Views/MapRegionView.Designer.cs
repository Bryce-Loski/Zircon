namespace Server.Views
{
    partial class MapRegionView
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
            InsertRowButton = new System.Windows.Forms.ToolStripButton();
            EditMapButton = new System.Windows.Forms.ToolStripButton();
            MapRegionGrid = new System.Windows.Forms.DataGridView();
            RegionTypeImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();

            viewToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MapRegionGrid).BeginInit();
            SuspendLayout();

            // viewToolStrip
            viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { SaveButton, ImportButton, ExportButton, InsertRowButton, EditMapButton });
            viewToolStrip.Location = new System.Drawing.Point(0, 0);
            viewToolStrip.Name = "viewToolStrip";
            viewToolStrip.Size = new System.Drawing.Size(800, 25);

            SaveButton.Name = "SaveButton"; SaveButton.Text = "Save Database"; SaveButton.Click += SaveButton_Click;
            ImportButton.Name = "ImportButton"; ImportButton.Text = "Import"; ImportButton.Click += ImportButton_Click;
            ExportButton.Name = "ExportButton"; ExportButton.Text = "Export"; ExportButton.Click += ExportButton_Click;
            InsertRowButton.Name = "InsertRowButton"; InsertRowButton.Text = "Insert Row"; InsertRowButton.Click += InsertRowButton_Click;
            EditMapButton.Name = "EditMapButton"; EditMapButton.Text = "Edit Map"; EditMapButton.Click += EditMapButton_Click;

            // ComboBox columns
            RegionTypeImageComboBox.Name = "RegionTypeImageComboBox"; RegionTypeImageComboBox.HeaderText = "Region Type";

            // MapRegionGrid
            MapRegionGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            MapRegionGrid.Location = new System.Drawing.Point(0, 25);
            MapRegionGrid.Name = "MapRegionGrid";
            MapRegionGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            MapRegionGrid.Columns.Add(RegionTypeImageComboBox);

            // MapRegionView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(MapRegionGrid);
            Controls.Add(viewToolStrip);
            Name = "MapRegionView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MapRegionGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ImportButton;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.ToolStripButton InsertRowButton;
        private System.Windows.Forms.ToolStripButton EditMapButton;
        private System.Windows.Forms.DataGridView MapRegionGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn RegionTypeImageComboBox;
    }
}
