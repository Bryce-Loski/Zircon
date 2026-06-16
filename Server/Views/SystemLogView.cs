using Server.Envir;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class SystemLogView : UserControl
    {
        public static BindingList<string> Logs = new BindingList<string>();

        public SystemLogView()
        {
            InitializeComponent();

            LogListBox.DataSource = Logs;
        }

        private void InterfaceTimer_Tick(object sender, EventArgs e)
        {
            while (!SEnvir.DisplayLogs.IsEmpty)
            {
                string log;

                if (!SEnvir.DisplayLogs.TryDequeue(out log)) continue;

                Logs.Add(log);
            }

            if (Logs.Count > 0)
                ClearLogsButton.Enabled = true;
        }

        private void ClearLogsButton_Click(object sender, EventArgs e)
        {
            Logs.Clear();
            ClearLogsButton.Enabled = false;
        }
    }
}
