namespace Server.Views
{
    partial class NPCPageView
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
            npcPageTabPage = new System.Windows.Forms.TabPage();
            checksTabPage = new System.Windows.Forms.TabPage();
            actionsTabPage = new System.Windows.Forms.TabPage();
            buttonsTabPage = new System.Windows.Forms.TabPage();
            typesTabPage = new System.Windows.Forms.TabPage();
            goodsTabPage = new System.Windows.Forms.TabPage();
            valuesTabPage = new System.Windows.Forms.TabPage();
            NPCPageGrid = new System.Windows.Forms.DataGridView();
            ChecksGrid = new System.Windows.Forms.DataGridView();
            ActionsGrid = new System.Windows.Forms.DataGridView();
            ButtonsGrid = new System.Windows.Forms.DataGridView();
            TypesGrid = new System.Windows.Forms.DataGridView();
            GoodsGrid = new System.Windows.Forms.DataGridView();
            ValuesGrid = new System.Windows.Forms.DataGridView();
            DialogTypeImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            CheckTypeImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ActionTypeImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ItemTypeImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            DataTypeImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ValueTypeImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            FieldTypeImageComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();

            viewToolStrip.SuspendLayout();
            viewTabControl.SuspendLayout();
            npcPageTabPage.SuspendLayout();
            checksTabPage.SuspendLayout();
            actionsTabPage.SuspendLayout();
            buttonsTabPage.SuspendLayout();
            typesTabPage.SuspendLayout();
            goodsTabPage.SuspendLayout();
            valuesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NPCPageGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ChecksGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ActionsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ButtonsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TypesGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GoodsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ValuesGrid).BeginInit();
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
            DialogTypeImageComboBox.Name = "DialogTypeImageComboBox"; DialogTypeImageComboBox.HeaderText = "Dialog Type";
            CheckTypeImageComboBox.Name = "CheckTypeImageComboBox"; CheckTypeImageComboBox.HeaderText = "Check Type";
            ActionTypeImageComboBox.Name = "ActionTypeImageComboBox"; ActionTypeImageComboBox.HeaderText = "Action Type";
            ItemTypeImageComboBox.Name = "ItemTypeImageComboBox"; ItemTypeImageComboBox.HeaderText = "Item Type";
            DataTypeImageComboBox.Name = "DataTypeImageComboBox"; DataTypeImageComboBox.HeaderText = "Data Type";
            ValueTypeImageComboBox.Name = "ValueTypeImageComboBox"; ValueTypeImageComboBox.HeaderText = "Value Type";
            FieldTypeImageComboBox.Name = "FieldTypeImageComboBox"; FieldTypeImageComboBox.HeaderText = "Field Type";

            // viewTabControl
            viewTabControl.Controls.Add(npcPageTabPage);
            viewTabControl.Controls.Add(checksTabPage);
            viewTabControl.Controls.Add(actionsTabPage);
            viewTabControl.Controls.Add(buttonsTabPage);
            viewTabControl.Controls.Add(typesTabPage);
            viewTabControl.Controls.Add(goodsTabPage);
            viewTabControl.Controls.Add(valuesTabPage);
            viewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            viewTabControl.Location = new System.Drawing.Point(0, 25);
            viewTabControl.Name = "viewTabControl";

            npcPageTabPage.Controls.Add(NPCPageGrid); npcPageTabPage.Name = "npcPageTabPage"; npcPageTabPage.Text = "NPC Page";
            checksTabPage.Controls.Add(ChecksGrid); checksTabPage.Name = "checksTabPage"; checksTabPage.Text = "Checks";
            actionsTabPage.Controls.Add(ActionsGrid); actionsTabPage.Name = "actionsTabPage"; actionsTabPage.Text = "Actions";
            buttonsTabPage.Controls.Add(ButtonsGrid); buttonsTabPage.Name = "buttonsTabPage"; buttonsTabPage.Text = "Buttons";
            typesTabPage.Controls.Add(TypesGrid); typesTabPage.Name = "typesTabPage"; typesTabPage.Text = "Types";
            goodsTabPage.Controls.Add(GoodsGrid); goodsTabPage.Name = "goodsTabPage"; goodsTabPage.Text = "Goods";
            valuesTabPage.Controls.Add(ValuesGrid); valuesTabPage.Name = "valuesTabPage"; valuesTabPage.Text = "Values";

            // Grids
            NPCPageGrid.Dock = System.Windows.Forms.DockStyle.Fill; NPCPageGrid.Name = "NPCPageGrid"; NPCPageGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            NPCPageGrid.Columns.Add(DialogTypeImageComboBox);

            ChecksGrid.Dock = System.Windows.Forms.DockStyle.Fill; ChecksGrid.Name = "ChecksGrid"; ChecksGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            ChecksGrid.Columns.Add(CheckTypeImageComboBox);

            ActionsGrid.Dock = System.Windows.Forms.DockStyle.Fill; ActionsGrid.Name = "ActionsGrid"; ActionsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            ActionsGrid.Columns.Add(ActionTypeImageComboBox);

            ButtonsGrid.Dock = System.Windows.Forms.DockStyle.Fill; ButtonsGrid.Name = "ButtonsGrid"; ButtonsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            TypesGrid.Dock = System.Windows.Forms.DockStyle.Fill; TypesGrid.Name = "TypesGrid"; TypesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            TypesGrid.Columns.Add(ItemTypeImageComboBox);

            GoodsGrid.Dock = System.Windows.Forms.DockStyle.Fill; GoodsGrid.Name = "GoodsGrid"; GoodsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            ValuesGrid.Dock = System.Windows.Forms.DockStyle.Fill; ValuesGrid.Name = "ValuesGrid"; ValuesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            ValuesGrid.Columns.Add(DataTypeImageComboBox);
            ValuesGrid.Columns.Add(ValueTypeImageComboBox);
            ValuesGrid.Columns.Add(FieldTypeImageComboBox);

            // NPCPageView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(viewTabControl);
            Controls.Add(viewToolStrip);
            Name = "NPCPageView";
            Size = new System.Drawing.Size(800, 500);

            viewToolStrip.ResumeLayout(false); viewToolStrip.PerformLayout();
            npcPageTabPage.ResumeLayout(false); checksTabPage.ResumeLayout(false); actionsTabPage.ResumeLayout(false);
            buttonsTabPage.ResumeLayout(false); typesTabPage.ResumeLayout(false); goodsTabPage.ResumeLayout(false); valuesTabPage.ResumeLayout(false);
            viewTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NPCPageGrid).EndInit(); ((System.ComponentModel.ISupportInitialize)ChecksGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)ActionsGrid).EndInit(); ((System.ComponentModel.ISupportInitialize)ButtonsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)TypesGrid).EndInit(); ((System.ComponentModel.ISupportInitialize)GoodsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)ValuesGrid).EndInit();
            ResumeLayout(false); PerformLayout();
        }
        #endregion

        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ImportButton;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.ToolStripButton InsertRowButton;
        private System.Windows.Forms.TabControl viewTabControl;
        private System.Windows.Forms.TabPage npcPageTabPage;
        private System.Windows.Forms.TabPage checksTabPage;
        private System.Windows.Forms.TabPage actionsTabPage;
        private System.Windows.Forms.TabPage buttonsTabPage;
        private System.Windows.Forms.TabPage typesTabPage;
        private System.Windows.Forms.TabPage goodsTabPage;
        private System.Windows.Forms.TabPage valuesTabPage;
        private System.Windows.Forms.DataGridView NPCPageGrid;
        private System.Windows.Forms.DataGridView ChecksGrid;
        private System.Windows.Forms.DataGridView ActionsGrid;
        private System.Windows.Forms.DataGridView ButtonsGrid;
        private System.Windows.Forms.DataGridView TypesGrid;
        private System.Windows.Forms.DataGridView GoodsGrid;
        private System.Windows.Forms.DataGridView ValuesGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn DialogTypeImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn CheckTypeImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn ActionTypeImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn ItemTypeImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn DataTypeImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn ValueTypeImageComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn FieldTypeImageComboBox;
    }
}
