using Library.SystemModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class RespawnInfoView : UserControl
    {
        public RespawnInfoView()
        {
            InitializeComponent();
            MainGrid.DataSource = SMain.Session.GetCollection<RespawnInfo>().Binding;

            // MonsterLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            // RegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding.Where(x => x.RegionType == RegionType.None || x.RegionType == RegionType.Spawn || x.RegionType == RegionType.SpawnConnection);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(MainGrid);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<RespawnInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<RespawnInfo>(MainGrid); }
    }
}
