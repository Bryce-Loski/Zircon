namespace Server.Views
{
    partial class UserMailView
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
            UserMailDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)UserMailDataGridView).BeginInit();
            SuspendLayout();

            UserMailDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            UserMailDataGridView.Name = "UserMailDataGridView";
            UserMailDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(UserMailDataGridView);
            Name = "UserMailView";
            Size = new System.Drawing.Size(693, 408);

            ((System.ComponentModel.ISupportInitialize)UserMailDataGridView).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView UserMailDataGridView;
    }
}
