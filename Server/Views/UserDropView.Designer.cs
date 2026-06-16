namespace Server.Views
{
    partial class UserDropView
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
            UserDropDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)UserDropDataGridView).BeginInit();
            SuspendLayout();

            UserDropDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            UserDropDataGridView.Name = "UserDropDataGridView";
            UserDropDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(UserDropDataGridView);
            Name = "UserDropView";
            Size = new System.Drawing.Size(693, 408);

            ((System.ComponentModel.ISupportInitialize)UserDropDataGridView).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView UserDropDataGridView;
    }
}
