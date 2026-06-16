namespace Server.Views
{
    partial class DiagnosticView
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
            DiagnosticButton = new System.Windows.Forms.ToolStripButton();
            ResetTimeButton = new System.Windows.Forms.ToolStripButton();
            DiagnosticGrid = new System.Windows.Forms.DataGridView();
            colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTotalMilliseconds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colLargestMilliseconds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTotalSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colLargestSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DiagnosticGrid).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { DiagnosticButton, ResetTimeButton });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(907, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // DiagnosticButton
            // 
            DiagnosticButton.CheckOnClick = true;
            DiagnosticButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            DiagnosticButton.Name = "DiagnosticButton";
            DiagnosticButton.Size = new System.Drawing.Size(72, 22);
            DiagnosticButton.Text = "Diagnostics";
            DiagnosticButton.CheckedChanged += DiagnosticButton_CheckedChanged;
            // 
            // ResetTimeButton
            // 
            ResetTimeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ResetTimeButton.Name = "ResetTimeButton";
            ResetTimeButton.Size = new System.Drawing.Size(78, 22);
            ResetTimeButton.Text = "Reset Times";
            ResetTimeButton.Click += ResetTimeButton_Click;
            // 
            // DiagnosticGrid
            // 
            DiagnosticGrid.AllowUserToAddRows = false;
            DiagnosticGrid.AllowUserToDeleteRows = false;
            DiagnosticGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            DiagnosticGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DiagnosticGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colName, colCount, colTotalMilliseconds, colLargestMilliseconds, colTotalSize, colLargestSize });
            DiagnosticGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            DiagnosticGrid.Location = new System.Drawing.Point(0, 25);
            DiagnosticGrid.Name = "DiagnosticGrid";
            DiagnosticGrid.ReadOnly = true;
            DiagnosticGrid.RowHeadersVisible = false;
            DiagnosticGrid.Size = new System.Drawing.Size(907, 562);
            DiagnosticGrid.TabIndex = 1;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Name";
            colName.Name = "colName";
            // 
            // colCount
            // 
            colCount.DataPropertyName = "Count";
            colCount.HeaderText = "Count";
            colCount.Name = "colCount";
            // 
            // colTotalMilliseconds
            // 
            colTotalMilliseconds.DataPropertyName = "TotalMilliseconds";
            colTotalMilliseconds.HeaderText = "Total Milliseconds";
            colTotalMilliseconds.Name = "colTotalMilliseconds";
            // 
            // colLargestMilliseconds
            // 
            colLargestMilliseconds.DataPropertyName = "LargestMilliseconds";
            colLargestMilliseconds.HeaderText = "Largest Milliseconds";
            colLargestMilliseconds.Name = "colLargestMilliseconds";
            // 
            // colTotalSize
            // 
            colTotalSize.DataPropertyName = "TotalSize";
            colTotalSize.HeaderText = "Total Size";
            colTotalSize.Name = "colTotalSize";
            // 
            // colLargestSize
            // 
            colLargestSize.DataPropertyName = "LargestSize";
            colLargestSize.HeaderText = "Largest Size";
            colLargestSize.Name = "colLargestSize";
            // 
            // DiagnosticView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(907, 587);
            Controls.Add(DiagnosticGrid);
            Controls.Add(toolStrip1);
            Name = "DiagnosticView";
            Size = new System.Drawing.Size(907, 587);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DiagnosticGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton DiagnosticButton;
        private System.Windows.Forms.ToolStripButton ResetTimeButton;
        private System.Windows.Forms.DataGridView DiagnosticGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalMilliseconds;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLargestMilliseconds;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLargestSize;
    }
}
