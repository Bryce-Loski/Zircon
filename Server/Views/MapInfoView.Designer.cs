namespace Server.Views
{
    partial class MapInfoView
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
            viewTabControl = new System.Windows.Forms.TabControl();
            mapInfoTabPage = new System.Windows.Forms.TabPage();
            guardsTabPage = new System.Windows.Forms.TabPage();
            regionTabPage = new System.Windows.Forms.TabPage();
            miningTabPage = new System.Windows.Forms.TabPage();
            MapInfoGrid = new System.Windows.Forms.DataGridView();
            GuardsGrid = new System.Windows.Forms.DataGridView();
            RegionGrid = new System.Windows.Forms.DataGridView();
            MiningGrid = new System.Windows.Forms.DataGridView();
            LightComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            WeatherComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            DirectionImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            MapIconImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            StartClassImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            RequiredClassImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            StatImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();

            viewToolStrip.SuspendLayout();
            viewTabControl.SuspendLayout();
            mapInfoTabPage.SuspendLayout();
            guardsTabPage.SuspendLayout();
            regionTabPage.SuspendLayout();
            miningTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MapInfoGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GuardsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RegionGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MiningGrid).BeginInit();
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
            LightComboBox.Name = "LightComboBox"; LightComboBox.HeaderText = "Light";
            WeatherComboBox.Name = "WeatherComboBox"; WeatherComboBox.HeaderText = "Weather";
            DirectionImageComboBox.Name = "DirectionImageComboBox"; DirectionImageComboBox.HeaderText = "Direction";
            MapIconImageComboBox.Name = "MapIconImageComboBox"; MapIconImageComboBox.HeaderText = "Map Icon";
            StartClassImageComboBox.Name = "StartClassImageComboBox"; StartClassImageComboBox.HeaderText = "Start Class";
            RequiredClassImageComboBox.Name = "RequiredClassImageComboBox"; RequiredClassImageComboBox.HeaderText = "Required Class";
            StatImageComboBox.Name = "StatImageComboBox"; StatImageComboBox.HeaderText = "Stat";

            // viewTabControl
            viewTabControl.Controls.Add(mapInfoTabPage);
            viewTabControl.Controls.Add(guardsTabPage);
            viewTabControl.Controls.Add(regionTabPage);
            viewTabControl.Controls.Add(miningTabPage);
            viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            viewTabControl.Location = new System.Drawing.Point(0, 25);
            viewTabControl.Name = "viewTabControl";

            // mapInfoTabPage
            mapInfoTabPage.Controls.Add(MapInfoGrid);
            mapInfoTabPage.Name = "mapInfoTabPage";
            mapInfoTabPage.Text = "Map Info";

            // guardsTabPage
            guardsTabPage.Controls.Add(GuardsGrid);
            guardsTabPage.Name = "guardsTabPage";
            guardsTabPage.Text = "Guards";

            // regionTabPage
            regionTabPage.Controls.Add(RegionGrid);
            regionTabPage.Name = "regionTabPage";
            regionTabPage.Text = "Regions";

            // miningTabPage
            miningTabPage.Controls.Add(MiningGrid);
            miningTabPage.Name = "miningTabPage";
            miningTabPage.Text = "Mining";

            // MapInfoGrid
            MapInfoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            MapInfoGrid.Name = "MapInfoGrid";
            MapInfoGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            MapInfoGrid.Columns.Add(LightComboBox);
            MapInfoGrid.Columns.Add(WeatherComboBox);

            // GuardsGrid
            GuardsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            GuardsGrid.Name = "GuardsGrid";
            GuardsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            GuardsGrid.Columns.Add(DirectionImageComboBox);

            // RegionGrid
            RegionGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            RegionGrid.Name = "RegionGrid";
            RegionGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // MiningGrid
            MiningGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            MiningGrid.Name = "MiningGrid";
            MiningGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            // MapInfoView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(viewTabControl);
            Controls.Add(viewToolStrip);
            Name = "MapInfoView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            mapInfoTabPage.ResumeLayout(false);
            guardsTabPage.ResumeLayout(false);
            regionTabPage.ResumeLayout(false);
            miningTabPage.ResumeLayout(false);
            viewTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MapInfoGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)GuardsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)RegionGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)MiningGrid).EndInit();
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
        private System.Windows.Forms.TabControl viewTabControl;
        private System.Windows.Forms.TabPage mapInfoTabPage;
        private System.Windows.Forms.TabPage guardsTabPage;
        private System.Windows.Forms.TabPage regionTabPage;
        private System.Windows.Forms.TabPage miningTabPage;
        private System.Windows.Forms.DataGridView MapInfoGrid;
        private System.Windows.Forms.DataGridView GuardsGrid;
        private System.Windows.Forms.DataGridView RegionGrid;
        private System.Windows.Forms.DataGridView MiningGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn LightComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn WeatherComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn DirectionImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn MapIconImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn StartClassImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn RequiredClassImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatImageComboBox;
    }
}
