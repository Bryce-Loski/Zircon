using Server.Envir;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class AccountView : UserControl
    {
        public AccountView()
        {
            InitializeComponent();
            AccountDataGridView.DataSource = SEnvir.AccountInfoList?.Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AccountDataGridView.MultiSelect = true;
            AccountDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }
    }
}
