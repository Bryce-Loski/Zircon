using Server.Envir;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class CharacterView : UserControl
    {
        public CharacterView()
        {
            InitializeComponent();
            CharacterDataGridView.DataSource = SEnvir.CharacterInfoList?.Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CharacterDataGridView.MultiSelect = true;
            CharacterDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }
    }
}
