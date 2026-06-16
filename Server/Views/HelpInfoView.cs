using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class HelpInfoView : UserControl
    {
        public HelpInfoView()
        {
            InitializeComponent();
            HelpDataGridView.DataSource = SMain.Session.GetCollection<HelpInfo>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(HelpDataGridView);
            SMain.SetUpView(PageDataGridView);
            SMain.SetUpView(ItemDataGridView);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<HelpInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<HelpInfo>(HelpDataGridView); }
    }
}
