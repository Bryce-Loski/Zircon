using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class BaseStatView : UserControl
    {
        public BaseStatView()
        {
            InitializeComponent();
            BaseStatDataGridView.DataSource = SMain.Session.GetCollection<BaseStat>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(BaseStatDataGridView);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<BaseStat>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<BaseStat>(BaseStatDataGridView); }
    }
}
