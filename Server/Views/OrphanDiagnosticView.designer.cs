namespace Server.Views
{
    partial class OrphanDiagnosticView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            ScanOrphansButton = new System.Windows.Forms.ToolStripButton();
            CleanOrphansButton = new System.Windows.Forms.ToolStripButton();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            DiagnosticGrid = new System.Windows.Forms.DataGridView();
            colObjectType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colParentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colParentProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colParentList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTotalRows = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colLinkedRows = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCleanableOrphans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colExistingTemporaryOrphans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMissingParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDeletedParent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMissingParentListLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMarkedTemporary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colSampleIndices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            memoTextBox = new System.Windows.Forms.TextBox();
            toolStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DiagnosticGrid).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ScanOrphansButton, CleanOrphansButton });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(865, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // ScanOrphansButton
            // 
            ScanOrphansButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ScanOrphansButton.Name = "ScanOrphansButton";
            ScanOrphansButton.Size = new System.Drawing.Size(38, 22);
            ScanOrphansButton.Text = "Scan";
            ScanOrphansButton.Click += ScanOrphansButton_Click;
            // 
            // CleanOrphansButton
            // 
            CleanOrphansButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            CleanOrphansButton.Name = "CleanOrphansButton";
            CleanOrphansButton.Size = new System.Drawing.Size(42, 22);
            CleanOrphansButton.Text = "Clean";
            CleanOrphansButton.Click += CleanOrphansButton_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(DiagnosticGrid, 0, 0);
            tableLayoutPanel1.Controls.Add(memoTextBox, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            tableLayoutPanel1.Size = new System.Drawing.Size(865, 417);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // DiagnosticGrid
            // 
            DiagnosticGrid.AllowUserToAddRows = false;
            DiagnosticGrid.AllowUserToDeleteRows = false;
            DiagnosticGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            DiagnosticGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DiagnosticGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                colObjectType, colParentType, colParentProperty, colParentList,
                colTotalRows, colLinkedRows, colCleanableOrphans, colExistingTemporaryOrphans,
                colMissingParent, colDeletedParent, colMissingParentListLink,
                colMarkedTemporary, colSampleIndices
            });
            DiagnosticGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            DiagnosticGrid.Location = new System.Drawing.Point(3, 3);
            DiagnosticGrid.Name = "DiagnosticGrid";
            DiagnosticGrid.ReadOnly = true;
            DiagnosticGrid.RowHeadersVisible = false;
            DiagnosticGrid.Size = new System.Drawing.Size(859, 300);
            DiagnosticGrid.TabIndex = 0;
            // 
            // colObjectType
            // 
            colObjectType.DataPropertyName = "ObjectType";
            colObjectType.HeaderText = "Object Type";
            colObjectType.Name = "colObjectType";
            // 
            // colParentType
            // 
            colParentType.DataPropertyName = "ParentType";
            colParentType.HeaderText = "Parent Type";
            colParentType.Name = "colParentType";
            // 
            // colParentProperty
            // 
            colParentProperty.DataPropertyName = "ParentProperty";
            colParentProperty.HeaderText = "Parent Property";
            colParentProperty.Name = "colParentProperty";
            // 
            // colParentList
            // 
            colParentList.DataPropertyName = "ParentList";
            colParentList.HeaderText = "Parent List";
            colParentList.Name = "colParentList";
            // 
            // colTotalRows
            // 
            colTotalRows.DataPropertyName = "TotalRows";
            colTotalRows.HeaderText = "Total Rows";
            colTotalRows.Name = "colTotalRows";
            // 
            // colLinkedRows
            // 
            colLinkedRows.DataPropertyName = "LinkedRows";
            colLinkedRows.HeaderText = "Linked Rows";
            colLinkedRows.Name = "colLinkedRows";
            // 
            // colCleanableOrphans
            // 
            colCleanableOrphans.DataPropertyName = "CleanableOrphans";
            colCleanableOrphans.HeaderText = "Cleanable Orphans";
            colCleanableOrphans.Name = "colCleanableOrphans";
            // 
            // colExistingTemporaryOrphans
            // 
            colExistingTemporaryOrphans.DataPropertyName = "ExistingTemporaryOrphans";
            colExistingTemporaryOrphans.HeaderText = "Existing Temporary Orphans";
            colExistingTemporaryOrphans.Name = "colExistingTemporaryOrphans";
            // 
            // colMissingParent
            // 
            colMissingParent.DataPropertyName = "MissingParent";
            colMissingParent.HeaderText = "Missing Parent";
            colMissingParent.Name = "colMissingParent";
            // 
            // colDeletedParent
            // 
            colDeletedParent.DataPropertyName = "DeletedParent";
            colDeletedParent.HeaderText = "Deleted Parent";
            colDeletedParent.Name = "colDeletedParent";
            // 
            // colMissingParentListLink
            // 
            colMissingParentListLink.DataPropertyName = "MissingParentListLink";
            colMissingParentListLink.HeaderText = "Missing Parent List Link";
            colMissingParentListLink.Name = "colMissingParentListLink";
            // 
            // colMarkedTemporary
            // 
            colMarkedTemporary.DataPropertyName = "MarkedTemporary";
            colMarkedTemporary.HeaderText = "Marked Temporary";
            colMarkedTemporary.Name = "colMarkedTemporary";
            // 
            // colSampleIndices
            // 
            colSampleIndices.DataPropertyName = "SampleIndices";
            colSampleIndices.HeaderText = "Sample Indices";
            colSampleIndices.Name = "colSampleIndices";
            // 
            // memoTextBox
            // 
            memoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            memoTextBox.Location = new System.Drawing.Point(3, 309);
            memoTextBox.Multiline = true;
            memoTextBox.Name = "memoTextBox";
            memoTextBox.ReadOnly = true;
            memoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            memoTextBox.Size = new System.Drawing.Size(859, 105);
            memoTextBox.TabIndex = 1;
            // 
            // OrphanDiagnosticView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(865, 442);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(toolStrip1);
            Name = "OrphanDiagnosticView";
            Size = new System.Drawing.Size(865, 442);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DiagnosticGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ScanOrphansButton;
        private System.Windows.Forms.ToolStripButton CleanOrphansButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView DiagnosticGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjectType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentProperty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinkedRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCleanableOrphans;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExistingTemporaryOrphans;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMissingParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeletedParent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMissingParentListLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarkedTemporary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSampleIndices;
        private System.Windows.Forms.TextBox memoTextBox;
    }
}
