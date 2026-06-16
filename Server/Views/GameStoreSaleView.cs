using Server.Envir;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class GameStoreSaleView : UserControl
    {
        public GameStoreSaleView()
        {
            InitializeComponent();
            GameStoreSaleDataGridView.DataSource = SEnvir.GameStoreSaleList?.Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GameStoreSaleDataGridView.MultiSelect = true;
            GameStoreSaleDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }
    }
}
