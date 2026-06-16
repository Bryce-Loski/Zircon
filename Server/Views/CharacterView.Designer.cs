namespace Server.Views
{
    partial class CharacterView
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
            CharacterDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)CharacterDataGridView).BeginInit();
            SuspendLayout();

            CharacterDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            CharacterDataGridView.Name = "CharacterDataGridView";
            CharacterDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(CharacterDataGridView);
            Name = "CharacterView";
            Size = new System.Drawing.Size(612, 503);

            ((System.ComponentModel.ISupportInitialize)CharacterDataGridView).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView CharacterDataGridView;
    }
}
