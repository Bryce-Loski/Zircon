using Library.SystemModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class CastleInfoView : UserControl
    {
        public CastleInfoView()
        {
            InitializeComponent();
            MainGrid.DataSource = SMain.Session.GetCollection<CastleInfo>().Binding;

            // MonsterLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding.Where(x => x.Flag == Library.MonsterFlag.CastleObjective || x.Flag == Library.MonsterFlag.CastleDefense);
            // RegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            // MapLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
            // ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(MainGrid);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<CastleInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<CastleInfo>(MainGrid); }
    }
}
