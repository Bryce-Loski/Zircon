namespace Server.Views
{
    partial class MapViewer
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
            components = new System.ComponentModel.Container();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            SaveButton = new System.Windows.Forms.ToolStripButton();
            CancelButton1 = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ZoomResetButton = new System.Windows.Forms.ToolStripButton();
            ZoomInButton = new System.Windows.Forms.ToolStripButton();
            ZoomOutButton = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            AttributesButton = new System.Windows.Forms.ToolStripButton();
            BlockedOnlyButton = new System.Windows.Forms.ToolStripButton();
            SelectionButton = new System.Windows.Forms.ToolStripButton();
            DXPanel = new System.Windows.Forms.Panel();
            MapVScroll = new System.Windows.Forms.VScrollBar();
            MapHScroll = new System.Windows.Forms.HScrollBar();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            MapSizeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            PositionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            SelectedCellsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                SaveButton, CancelButton1, toolStripSeparator1,
                ZoomResetButton, ZoomInButton, ZoomOutButton, toolStripSeparator2,
                AttributesButton, BlockedOnlyButton, SelectionButton
            });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(1078, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // SaveButton
            // 
            SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new System.Drawing.Size(35, 22);
            SaveButton.Text = "Save";
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton1
            // 
            CancelButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            CancelButton1.Name = "CancelButton1";
            CancelButton1.Size = new System.Drawing.Size(47, 22);
            CancelButton1.Text = "Cancel";
            CancelButton1.Click += CancelButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ZoomResetButton
            // 
            ZoomResetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ZoomResetButton.Name = "ZoomResetButton";
            ZoomResetButton.Size = new System.Drawing.Size(39, 22);
            ZoomResetButton.Text = "Reset";
            ZoomResetButton.Click += ZoomResetButton_Click;
            // 
            // ZoomInButton
            // 
            ZoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ZoomInButton.Name = "ZoomInButton";
            ZoomInButton.Size = new System.Drawing.Size(60, 22);
            ZoomInButton.Text = "Zoom In";
            ZoomInButton.Click += ZoomInButton_Click;
            // 
            // ZoomOutButton
            // 
            ZoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ZoomOutButton.Name = "ZoomOutButton";
            ZoomOutButton.Size = new System.Drawing.Size(67, 22);
            ZoomOutButton.Text = "Zoom Out";
            ZoomOutButton.Click += ZoomOutButton_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // AttributesButton
            // 
            AttributesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            AttributesButton.Name = "AttributesButton";
            AttributesButton.Size = new System.Drawing.Size(62, 22);
            AttributesButton.Text = "Attributes";
            AttributesButton.Click += AttributesButton_Click;
            // 
            // BlockedOnlyButton
            // 
            BlockedOnlyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            BlockedOnlyButton.Name = "BlockedOnlyButton";
            BlockedOnlyButton.Size = new System.Drawing.Size(108, 22);
            BlockedOnlyButton.Text = "Attribute Selection";
            BlockedOnlyButton.Click += BlockedOnlyButton_Click;
            // 
            // SelectionButton
            // 
            SelectionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            SelectionButton.Name = "SelectionButton";
            SelectionButton.Size = new System.Drawing.Size(60, 22);
            SelectionButton.Text = "Selection";
            SelectionButton.Click += SelectionButton_Click;
            // 
            // DXPanel
            // 
            DXPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DXPanel.Location = new System.Drawing.Point(0, 28);
            DXPanel.Name = "DXPanel";
            DXPanel.Size = new System.Drawing.Size(1061, 528);
            DXPanel.TabIndex = 2;
            DXPanel.MouseDown += DXPanel_MouseDown;
            DXPanel.MouseEnter += DXPanel_MouseEnter;
            DXPanel.MouseLeave += DXPanel_MouseLeave;
            DXPanel.MouseMove += DXPanel_MouseMove;
            DXPanel.MouseUp += DXPanel_MouseUp;
            // 
            // MapVScroll
            // 
            MapVScroll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            MapVScroll.Location = new System.Drawing.Point(1061, 28);
            MapVScroll.Name = "MapVScroll";
            MapVScroll.Size = new System.Drawing.Size(17, 528);
            MapVScroll.TabIndex = 4;
            MapVScroll.ValueChanged += MapVScroll_ValueChanged;
            // 
            // MapHScroll
            // 
            MapHScroll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            MapHScroll.Location = new System.Drawing.Point(0, 556);
            MapHScroll.Name = "MapHScroll";
            MapHScroll.Size = new System.Drawing.Size(1061, 17);
            MapHScroll.TabIndex = 5;
            MapHScroll.ValueChanged += MapHScroll_ValueChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { MapSizeLabel, PositionLabel, SelectedCellsLabel });
            statusStrip1.Location = new System.Drawing.Point(0, 584);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1078, 25);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // MapSizeLabel
            // 
            MapSizeLabel.Name = "MapSizeLabel";
            MapSizeLabel.Size = new System.Drawing.Size(90, 20);
            MapSizeLabel.Text = "Map Size : 0,0";
            // 
            // PositionLabel
            // 
            PositionLabel.Name = "PositionLabel";
            PositionLabel.Size = new System.Drawing.Size(78, 20);
            PositionLabel.Text = "Position: 0,0";
            // 
            // SelectedCellsLabel
            // 
            SelectedCellsLabel.Name = "SelectedCellsLabel";
            SelectedCellsLabel.Size = new System.Drawing.Size(98, 20);
            SelectedCellsLabel.Text = "Selected Cells : 0";
            // 
            // MapViewer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1078, 609);
            Controls.Add(statusStrip1);
            Controls.Add(MapHScroll);
            Controls.Add(MapVScroll);
            Controls.Add(DXPanel);
            Controls.Add(toolStrip1);
            Name = "MapViewer";
            Text = "Map Viewer";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ZoomResetButton;
        private System.Windows.Forms.ToolStripButton ZoomInButton;
        private System.Windows.Forms.ToolStripButton ZoomOutButton;
        private System.Windows.Forms.ToolStripButton AttributesButton;
        private System.Windows.Forms.ToolStripButton SelectionButton;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton CancelButton1;
        private System.Windows.Forms.ToolStripButton BlockedOnlyButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel DXPanel;
        private System.Windows.Forms.VScrollBar MapVScroll;
        private System.Windows.Forms.HScrollBar MapHScroll;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel MapSizeLabel;
        private System.Windows.Forms.ToolStripStatusLabel PositionLabel;
        private System.Windows.Forms.ToolStripStatusLabel SelectedCellsLabel;
    }
}
