using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class DisciplineInfoView : UserControl
    {
        public DisciplineInfoView()
        {
            InitializeComponent();
            DisciplineInfoDataGridView.DataSource = SMain.Session.GetCollection<DisciplineInfo>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(DisciplineInfoDataGridView);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<DisciplineInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<DisciplineInfo>(DisciplineInfoDataGridView); }
    }
}
