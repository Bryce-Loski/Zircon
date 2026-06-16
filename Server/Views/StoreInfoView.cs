using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class StoreInfoView : UserControl
    {
        public StoreInfoView()
        {
            InitializeComponent();
            StoreInfoDataGridView.DataSource = SMain.Session.GetCollection<StoreInfo>().Binding;
            // ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(StoreInfoDataGridView);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<StoreInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<StoreInfo>(StoreInfoDataGridView); }
    }
}
