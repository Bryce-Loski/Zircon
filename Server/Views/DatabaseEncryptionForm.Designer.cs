namespace Server.Views
{
    partial class DatabaseEncryptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtEncryptionKey = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGenerateRandomKey = new System.Windows.Forms.Button();
            this.lblKey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkEnabled
            // 
            this.chkEnabled.Location = new System.Drawing.Point(12, 12);
            this.chkEnabled.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(359, 20);
            this.chkEnabled.TabIndex = 0;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(12, 40);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(228, 13);
            this.lblKey.TabIndex = 5;
            this.lblKey.Text = "Encryption Key (32 bytes) Encoded into base64";
            // 
            // txtEncryptionKey
            // 
            this.txtEncryptionKey.Location = new System.Drawing.Point(12, 56);
            this.txtEncryptionKey.Margin = new System.Windows.Forms.Padding(2);
            this.txtEncryptionKey.Multiline = true;
            this.txtEncryptionKey.Name = "txtEncryptionKey";
            this.txtEncryptionKey.Size = new System.Drawing.Size(359, 47);
            this.txtEncryptionKey.TabIndex = 1;
            // 
            // btnGenerateRandomKey
            // 
            this.btnGenerateRandomKey.Location = new System.Drawing.Point(12, 113);
            this.btnGenerateRandomKey.Name = "btnGenerateRandomKey";
            this.btnGenerateRandomKey.Size = new System.Drawing.Size(359, 22);
            this.btnGenerateRandomKey.TabIndex = 4;
            this.btnGenerateRandomKey.Text = "Generate Key";
            this.btnGenerateRandomKey.UseVisualStyleBackColor = true;
            this.btnGenerateRandomKey.Click += new System.EventHandler(this.btnGenerateRandomKey_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 139);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(359, 22);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DatabaseEncryptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 173);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGenerateRandomKey);
            this.Controls.Add(this.txtEncryptionKey);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.chkEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatabaseEncryptionForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database Encryption";
            this.Load += new System.EventHandler(this.DatabaseEncryptionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtEncryptionKey;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGenerateRandomKey;
        private System.Windows.Forms.Label lblKey;
    }
}
