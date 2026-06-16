using Library;
using Library.SystemModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class MovementInfoView : UserControl
    {
        public MovementInfoView()
        {
            InitializeComponent();
            MainGrid.DataSource = SMain.Session.GetCollection<MovementInfo>().Binding;

            // MapLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding.Where(x => x.RegionType == RegionType.None || x.RegionType == RegionType.Connection || x.RegionType == RegionType.SpawnConnection);
            // ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            // SpawnLookUpEdit.DataSource = SMain.Session.GetCollection<RespawnInfo>().Binding;
            // InstanceLookUpEdit.DataSource = SMain.Session.GetCollection<InstanceInfo>().Binding;

            MapIconImageComboBox.Items.AddEnumValues<MapIcon>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(MainGrid);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<MovementInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<MovementInfo>(MainGrid); }
    }
}
