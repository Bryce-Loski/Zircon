using Library.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class DiagnosticView : UserControl
    {
        private BindingList<DiagnosticValue> Results;

        public DiagnosticView()
        {
            InitializeComponent();

            Results = new BindingList<DiagnosticValue>();

            foreach (KeyValuePair<string, DiagnosticValue> pair in BaseConnection.Diagnostics)
                Results.Add(pair.Value);

            DiagnosticGrid.DataSource = Results;

            DiagnosticButton.Checked = BaseConnection.Monitor;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DiagnosticGrid.MultiSelect = true;
            DiagnosticGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void DiagnosticButton_CheckedChanged(object sender, EventArgs e)
        {
            BaseConnection.Monitor = DiagnosticButton.Checked;
        }

        private void ResetTimeButton_Click(object sender, EventArgs e)
        {
            foreach (DiagnosticValue result in Results)
            {
                result.Count = 0;
                result.TotalSize = 0;
                result.LargestSize = 0;
                result.TotalTime = TimeSpan.Zero;
                result.LargestTime = TimeSpan.Zero;
            }
        }
    }
}
