namespace Server.Views
{
    partial class AccountView
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
            AccountDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)AccountDataGridView).BeginInit();
            SuspendLayout();

            AccountDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            AccountDataGridView.Name = "AccountDataGridView";
            AccountDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(AccountDataGridView);
            Name = "AccountView";
            Size = new System.Drawing.Size(937, 373);

            ((System.ComponentModel.ISupportInitialize)AccountDataGridView).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView AccountDataGridView;
    }
}
