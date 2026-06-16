namespace Server.Views
{
    partial class UserConquestStatsView
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
            UserConquestStatsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)UserConquestStatsDataGridView).BeginInit();
            SuspendLayout();

            UserConquestStatsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            UserConquestStatsDataGridView.Name = "UserConquestStatsDataGridView";
            UserConquestStatsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(UserConquestStatsDataGridView);
            Name = "UserConquestStatsView";
            Size = new System.Drawing.Size(693, 408);

            ((System.ComponentModel.ISupportInitialize)UserConquestStatsDataGridView).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView UserConquestStatsDataGridView;
    }
}
