namespace Server.Views
{
    partial class GameStoreSaleView
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
            GameStoreSaleDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)GameStoreSaleDataGridView).BeginInit();
            SuspendLayout();

            GameStoreSaleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            GameStoreSaleDataGridView.Name = "GameStoreSaleDataGridView";
            GameStoreSaleDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(GameStoreSaleDataGridView);
            Name = "GameStoreSaleView";
            Size = new System.Drawing.Size(937, 373);

            ((System.ComponentModel.ISupportInitialize)GameStoreSaleDataGridView).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView GameStoreSaleDataGridView;
    }
}
