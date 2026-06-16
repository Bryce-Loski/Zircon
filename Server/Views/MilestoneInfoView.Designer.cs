namespace Server.Views
{
    partial class MilestoneInfoView
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
            tasksTabPage = new System.Windows.Forms.TabPage();
            MainGrid = new System.Windows.Forms.DataGridView();
            MilestoneInfoTaskGrid = new System.Windows.Forms.DataGridView();
            TypeImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            RequiredClassImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            GradeImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();

            viewToolStrip.SuspendLayout();
            viewTabControl.SuspendLayout();
            mainTabPage.SuspendLayout();
            tasksTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MilestoneInfoTaskGrid).BeginInit();
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
            TypeImageComboBox.Name = "TypeImageComboBox"; TypeImageComboBox.HeaderText = "Type";
            RequiredClassImageComboBox.Name = "RequiredClassImageComboBox"; RequiredClassImageComboBox.HeaderText = "Class";
            GradeImageComboBox.Name = "GradeImageComboBox"; GradeImageComboBox.HeaderText = "Grade";

            // viewTabControl
            viewTabControl.Controls.Add(mainTabPage);
            viewTabControl.Controls.Add(tasksTabPage);
            viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            viewTabControl.Location = new System.Drawing.Point(0, 25);
            viewTabControl.Name = "viewTabControl";

            // mainTabPage
            mainTabPage.Controls.Add(MainGrid);
            mainTabPage.Name = "mainTabPage";
            mainTabPage.Text = "Milestone Info";

            // tasksTabPage
            tasksTabPage.Controls.Add(MilestoneInfoTaskGrid);
            tasksTabPage.Name = "tasksTabPage";
            tasksTabPage.Text = "Tasks";

            // MainGrid
            MainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            MainGrid.Name = "MainGrid";
            MainGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            MainGrid.Columns.Add(TypeImageComboBox);
            MainGrid.Columns.Add(GradeImageComboBox);

            // MilestoneInfoTaskGrid
            MilestoneInfoTaskGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            MilestoneInfoTaskGrid.Name = "MilestoneInfoTaskGrid";
            MilestoneInfoTaskGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            MilestoneInfoTaskGrid.Columns.Add(RequiredClassImageComboBox);

            // MilestoneInfoView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(viewTabControl);
            Controls.Add(viewToolStrip);
            Name = "MilestoneInfoView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            mainTabPage.ResumeLayout(false);
            tasksTabPage.ResumeLayout(false);
            viewTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)MilestoneInfoTaskGrid).EndInit();
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
        private System.Windows.Forms.TabPage tasksTabPage;
        private System.Windows.Forms.DataGridView MainGrid;
        private System.Windows.Forms.DataGridView MilestoneInfoTaskGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn TypeImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn RequiredClassImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn GradeImageComboBox;
    }
}
