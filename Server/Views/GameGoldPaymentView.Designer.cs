namespace Server.Views
{
    partial class GameGoldPaymentView
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
            GameGoldPaymentDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)GameGoldPaymentDataGridView).BeginInit();
            SuspendLayout();

            GameGoldPaymentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            GameGoldPaymentDataGridView.Name = "GameGoldPaymentDataGridView";
            GameGoldPaymentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(GameGoldPaymentDataGridView);
            Name = "GameGoldPaymentView";
            Size = new System.Drawing.Size(937, 373);

            ((System.ComponentModel.ISupportInitialize)GameGoldPaymentDataGridView).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView GameGoldPaymentDataGridView;
    }
}
