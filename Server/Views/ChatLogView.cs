using Server.Envir;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class ChatLogView : UserControl
    {
        public static BindingList<string> Logs = new BindingList<string>();

        public ChatLogView()
        {
            InitializeComponent();

            LogListBox.DataSource = Logs;
        }

        private void InterfaceTimer_Tick(object sender, EventArgs e)
        {
            while (!SEnvir.ChatLogs.IsEmpty)
            {
                string log;

                if (!SEnvir.DisplayChatLogs.TryDequeue(out log)) continue;

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
