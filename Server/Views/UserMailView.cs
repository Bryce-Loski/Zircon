using Server.Envir;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class UserMailView : UserControl
    {
        public UserMailView()
        {
            InitializeComponent();
            UserMailDataGridView.DataSource = SEnvir.MailInfoList?.Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UserMailDataGridView.MultiSelect = true;
            UserMailDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }
    }
}
