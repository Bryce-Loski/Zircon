using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class BundleInfoView : UserControl
    {
        public BundleInfoView()
        {
            InitializeComponent();
            MainGrid.DataSource = SMain.Session.GetCollection<BundleInfo>().Binding;

            // BundleItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            // ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(MainGrid);
            SMain.SetUpView(BundleItemInfoGrid);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<BundleInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<BundleInfo>(MainGrid); }
    }
}
