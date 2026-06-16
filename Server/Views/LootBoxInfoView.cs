using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class LootBoxInfoView : UserControl
    {
        public LootBoxInfoView()
        {
            InitializeComponent();
            MainGrid.DataSource = SMain.Session.GetCollection<LootBoxInfo>().Binding;

            // LootBoxItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            // ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            // CurrencyLookUpEdit.DataSource = SMain.Session.GetCollection<CurrencyInfo>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(MainGrid);
            SMain.SetUpView(LootBoxItemInfoGrid);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<LootBoxInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<LootBoxInfo>(MainGrid); }
    }
}
