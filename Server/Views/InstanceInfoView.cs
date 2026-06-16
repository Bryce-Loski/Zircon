using Library;
using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class InstanceInfoView : UserControl
    {
        public InstanceInfoView()
        {
            InitializeComponent();
            MainGrid.DataSource = SMain.Session.GetCollection<InstanceInfo>().Binding;

            // MapInfoLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
            // RegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            // ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;

            InstanceTypeImageComboBox.Items.AddEnumValues<InstanceType>();
            StatComboBox.Items.AddEnumValues<Stat>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(MainGrid);
            SMain.SetUpView(InstanceMapGrid);
            SMain.SetUpView(InstanceInfoStatsGrid);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<InstanceInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<InstanceInfo>(MainGrid); }
    }
}
