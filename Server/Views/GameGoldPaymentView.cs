using Server.Envir;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class GameGoldPaymentView : UserControl
    {
        public GameGoldPaymentView()
        {
            InitializeComponent();
            GameGoldPaymentDataGridView.DataSource = SEnvir.GameGoldPaymentList?.Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GameGoldPaymentDataGridView.MultiSelect = true;
            GameGoldPaymentDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }
    }
}
