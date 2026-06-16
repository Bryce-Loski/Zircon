using Server.Envir;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class UserDropView : UserControl
    {
        public UserDropView()
        {
            InitializeComponent();
            UserDropDataGridView.DataSource = SEnvir.UserDropList?.Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UserDropDataGridView.MultiSelect = true;
            UserDropDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }
    }
}
