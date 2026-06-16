namespace Server.Views
{
    partial class NPCInfoView
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
            viewTabControl = new System.Windows.Forms.TabControl();
            mainTabPage = new System.Windows.Forms.TabPage();
            requirementsTabPage = new System.Windows.Forms.TabPage();
            MainGrid = new System.Windows.Forms.DataGridView();
            RequirementGrid = new System.Windows.Forms.DataGridView();
            RequiredClassImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            RequirementImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            MapIconImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            DaysOfWeekImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();

            viewToolStrip.SuspendLayout();
            viewTabControl.SuspendLayout();
            mainTabPage.SuspendLayout();
            requirementsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RequirementGrid).BeginInit();
            SuspendLayout();

            // viewToolStrip
            viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { SaveButton, ImportButton, ExportButton, InsertRowButton });
            viewToolStrip.Location = new System.Drawing.Point(0, 0);
            viewToolStrip.Name = "viewToolStrip";
            viewToolStrip.Size = new System.Drawing.Size(800, 25);

            SaveButton.Name = "SaveButton"; SaveButton.Text = "Save Database"; SaveButton.Click += SaveButton_Click;
            ImportButton.Name = "ImportButton"; ImportButton.Text = "Import"; ImportButton.Click += ImportButton_Click;
            ExportButton.Name = "ExportButton"; ExportButton.Text = "Export"; ExportButton.Click += ExportButton_Click;
            InsertRowButton.Name = "InsertRowButton"; InsertRowButton.Text = "Insert Row"; InsertRowButton.Click += InsertRowButton_Click;

            // ComboBox columns
            RequiredClassImageComboBox.Name = "RequiredClassImageComboBox"; RequiredClassImageComboBox.HeaderText = "Class";
            RequirementImageComboBox.Name = "RequirementImageComboBox"; RequirementImageComboBox.HeaderText = "Requirement";
            MapIconImageComboBox.Name = "MapIconImageComboBox"; MapIconImageComboBox.HeaderText = "Map Icon";
            DaysOfWeekImageComboBox.Name = "DaysOfWeekImageComboBox"; DaysOfWeekImageComboBox.HeaderText = "Days Of Week";

            // viewTabControl
            viewTabControl.Controls.Add(mainTabPage);
            viewTabControl.Controls.Add(requirementsTabPage);
            viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            viewTabControl.Location = new System.Drawing.Point(0, 25);
            viewTabControl.Name = "viewTabControl";

            // mainTabPage
            mainTabPage.Controls.Add(MainGrid);
            mainTabPage.Name = "mainTabPage";
            mainTabPage.Text = "NPC Info";

            // requirementsTabPage
            requirementsTabPage.Controls.Add(RequirementGrid);
            requirementsTabPage.Name = "requirementsTabPage";
            requirementsTabPage.Text = "Requirements";

            // MainGrid
            MainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            MainGrid.Name = "MainGrid";
            MainGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            MainGrid.Columns.Add(MapIconImageComboBox);

            // RequirementGrid
            RequirementGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            RequirementGrid.Name = "RequirementGrid";
            RequirementGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            RequirementGrid.Columns.Add(RequirementImageComboBox);
            RequirementGrid.Columns.Add(RequiredClassImageComboBox);
            RequirementGrid.Columns.Add(DaysOfWeekImageComboBox);

            // NPCInfoView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(viewTabControl);
            Controls.Add(viewToolStrip);
            Name = "NPCInfoView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            mainTabPage.ResumeLayout(false);
            requirementsTabPage.ResumeLayout(false);
            viewTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)RequirementGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ImportButton;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.ToolStripButton InsertRowButton;
        private System.Windows.Forms.TabControl viewTabControl;
        private System.Windows.Forms.TabPage mainTabPage;
        private System.Windows.Forms.TabPage requirementsTabPage;
        private System.Windows.Forms.DataGridView MainGrid;
        private System.Windows.Forms.DataGridView RequirementGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn RequiredClassImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn RequirementImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn MapIconImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn DaysOfWeekImageComboBox;
    }
}
