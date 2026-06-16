namespace Server.Views
{
    partial class ChatLogView
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            viewToolStrip = new System.Windows.Forms.ToolStrip();
            ClearLogsButton = new System.Windows.Forms.ToolStripButton();
            LogListBox = new System.Windows.Forms.ListBox();
            InterfaceTimer = new System.Windows.Forms.Timer(components);

            viewToolStrip.SuspendLayout();
            SuspendLayout();

            // viewToolStrip
            viewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ClearLogsButton });
            viewToolStrip.Location = new System.Drawing.Point(0, 0);
            viewToolStrip.Name = "viewToolStrip";
            viewToolStrip.Size = new System.Drawing.Size(717, 25);

            // ClearLogsButton
            ClearLogsButton.Name = "ClearLogsButton";
            ClearLogsButton.Text = "Clear Logs";
            ClearLogsButton.Enabled = false;
            ClearLogsButton.Click += ClearLogsButton_Click;

            // LogListBox
            LogListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            LogListBox.Location = new System.Drawing.Point(0, 25);
            LogListBox.Name = "LogListBox";
            LogListBox.Size = new System.Drawing.Size(717, 458);

            // InterfaceTimer
            InterfaceTimer.Enabled = true;
            InterfaceTimer.Interval = 1000;
            InterfaceTimer.Tick += InterfaceTimer_Tick;

            // ChatLogView
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(LogListBox);
            Controls.Add(viewToolStrip);
            Name = "ChatLogView";
            Size = new System.Drawing.Size(717, 483);

            viewToolStrip.ResumeLayout(false);
            viewToolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip viewToolStrip;
        private System.Windows.Forms.ToolStripButton ClearLogsButton;
        private System.Windows.Forms.ListBox LogListBox;
        private System.Windows.Forms.Timer InterfaceTimer;
    }
}
