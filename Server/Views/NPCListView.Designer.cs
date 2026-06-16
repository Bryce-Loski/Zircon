namespace Server.Views
{
    partial class NPCListView
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
            NPCListDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)NPCListDataGridView).BeginInit();
            SuspendLayout();

            NPCListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            NPCListDataGridView.Name = "NPCListDataGridView";
            NPCListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(NPCListDataGridView);
            Name = "NPCListView";
            Size = new System.Drawing.Size(693, 408);

            ((System.ComponentModel.ISupportInitialize)NPCListDataGridView).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView NPCListDataGridView;
    }
}
