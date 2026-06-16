namespace Server.Views
{
    partial class QuestInfoView
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
            questInfoTabPage = new System.Windows.Forms.TabPage();
            requirementsTabPage = new System.Windows.Forms.TabPage();
            taskTabPage = new System.Windows.Forms.TabPage();
            monsterDetailsTabPage = new System.Windows.Forms.TabPage();
            rewardsTabPage = new System.Windows.Forms.TabPage();
            QuestInfoGrid = new System.Windows.Forms.DataGridView();
            RequirementsGrid = new System.Windows.Forms.DataGridView();
            TaskGrid = new System.Windows.Forms.DataGridView();
            MonsterDetailsGrid = new System.Windows.Forms.DataGridView();
            RewardsGrid = new System.Windows.Forms.DataGridView();
            RequirementImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            TaskImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            RequiredClassImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            TypeImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();

            viewToolStrip.SuspendLayout();
            viewTabControl.SuspendLayout();
            questInfoTabPage.SuspendLayout();
            requirementsTabPage.SuspendLayout();
            taskTabPage.SuspendLayout();
            monsterDetailsTabPage.SuspendLayout();
            rewardsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)QuestInfoGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RequirementsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TaskGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MonsterDetailsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RewardsGrid).BeginInit();
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
            RequirementImageComboBox.Name = "RequirementImageComboBox"; RequirementImageComboBox.HeaderText = "Requirement";
            TaskImageComboBox.Name = "TaskImageComboBox"; TaskImageComboBox.HeaderText = "Task";
            RequiredClassImageComboBox.Name = "RequiredClassImageComboBox"; RequiredClassImageComboBox.HeaderText = "Required Class";
            TypeImageComboBox.Name = "TypeImageComboBox"; TypeImageComboBox.HeaderText = "Quest Type";

            // viewTabControl
            viewTabControl.Controls.Add(questInfoTabPage);
            viewTabControl.Controls.Add(requirementsTabPage);
            viewTabControl.Controls.Add(taskTabPage);
            viewTabControl.Controls.Add(monsterDetailsTabPage);
            viewTabControl.Controls.Add(rewardsTabPage);
            viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            viewTabControl.Location = new System.Drawing.Point(0, 25);
            viewTabControl.Name = "viewTabControl";

            questInfoTabPage.Controls.Add(QuestInfoGrid); questInfoTabPage.Name = "questInfoTabPage"; questInfoTabPage.Text = "Quest Info";
            requirementsTabPage.Controls.Add(RequirementsGrid); requirementsTabPage.Name = "requirementsTabPage"; requirementsTabPage.Text = "Requirements";
            taskTabPage.Controls.Add(TaskGrid); taskTabPage.Name = "taskTabPage"; taskTabPage.Text = "Tasks";
            monsterDetailsTabPage.Controls.Add(MonsterDetailsGrid); monsterDetailsTabPage.Name = "monsterDetailsTabPage"; monsterDetailsTabPage.Text = "Monster Details";
            rewardsTabPage.Controls.Add(RewardsGrid); rewardsTabPage.Name = "rewardsTabPage"; rewardsTabPage.Text = "Rewards";

            // Grids
            QuestInfoGrid.Dock = System.Windows.Forms.DockStyle.Fill; QuestInfoGrid.Name = "QuestInfoGrid"; QuestInfoGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            QuestInfoGrid.Columns.Add(TypeImageComboBox);

            RequirementsGrid.Dock = System.Windows.Forms.DockStyle.Fill; RequirementsGrid.Name = "RequirementsGrid"; RequirementsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            RequirementsGrid.Columns.Add(RequirementImageComboBox);
            RequirementsGrid.Columns.Add(RequiredClassImageComboBox);

            TaskGrid.Dock = System.Windows.Forms.DockStyle.Fill; TaskGrid.Name = "TaskGrid"; TaskGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            TaskGrid.Columns.Add(TaskImageComboBox);

            MonsterDetailsGrid.Dock = System.Windows.Forms.DockStyle.Fill; MonsterDetailsGrid.Name = "MonsterDetailsGrid"; MonsterDetailsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            RewardsGrid.Dock = System.Windows.Forms.DockStyle.Fill; RewardsGrid.Name = "RewardsGrid"; RewardsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            RewardsGrid.Columns.Add(RequiredClassImageComboBox);

            // QuestInfoView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(viewTabControl);
            Controls.Add(viewToolStrip);
            Name = "QuestInfoView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false); viewToolStrip.PerformLayout();
            questInfoTabPage.ResumeLayout(false); requirementsTabPage.ResumeLayout(false); taskTabPage.ResumeLayout(false);
            monsterDetailsTabPage.ResumeLayout(false); rewardsTabPage.ResumeLayout(false);
            viewTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)QuestInfoGrid).EndInit(); ((System.ComponentModel.ISupportInitialize)RequirementsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)TaskGrid).EndInit(); ((System.ComponentModel.ISupportInitialize)MonsterDetailsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)RewardsGrid).EndInit();
            ResumeLayout(false); PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ImportButton;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.TabControl viewTabControl;
        private System.Windows.Forms.TabPage questInfoTabPage;
        private System.Windows.Forms.TabPage requirementsTabPage;
        private System.Windows.Forms.TabPage taskTabPage;
        private System.Windows.Forms.TabPage monsterDetailsTabPage;
        private System.Windows.Forms.TabPage rewardsTabPage;
        private System.Windows.Forms.DataGridView QuestInfoGrid;
        private System.Windows.Forms.DataGridView RequirementsGrid;
        private System.Windows.Forms.DataGridView TaskGrid;
        private System.Windows.Forms.DataGridView MonsterDetailsGrid;
        private System.Windows.Forms.DataGridView RewardsGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn RequirementImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn TaskImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn RequiredClassImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn TypeImageComboBox;
    }
}
