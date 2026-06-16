using Server.Envir;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class UserConquestStatsView : UserControl
    {
        public UserConquestStatsView()
        {
            InitializeComponent();
            UserConquestStatsDataGridView.DataSource = SEnvir.UserConquestStatsList?.Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UserConquestStatsDataGridView.MultiSelect = true;
            UserConquestStatsDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }
    }
}
