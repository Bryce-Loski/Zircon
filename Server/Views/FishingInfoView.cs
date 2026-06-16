using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class FishingInfoView : UserControl
    {
        public FishingInfoView()
        {
            InitializeComponent();
            MainGrid.DataSource = SMain.Session.GetCollection<FishingInfo>().Binding;

            // RegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            // ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(MainGrid);
            SMain.SetUpView(FishingDropInfoGrid);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<FishingInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<FishingInfo>(MainGrid); }
    }
}
