using Server.Envir;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class NPCListView : UserControl
    {
        public NPCListView()
        {
            InitializeComponent();
            NPCListDataGridView.DataSource = SEnvir.GameNPCList?.Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            NPCListDataGridView.MultiSelect = true;
            NPCListDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;

            SMain.SetUpView(NPCListDataGridView);
        }
    }
}
