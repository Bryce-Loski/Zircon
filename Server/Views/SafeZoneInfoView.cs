using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class SafeZoneInfoView : UserControl
    {
        public SafeZoneInfoView()
        {
            InitializeComponent();
            SafeZoneInfoDataGridView.DataSource = SMain.Session.GetCollection<SafeZoneInfo>().Binding;
            // RegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(SafeZoneInfoDataGridView);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<SafeZoneInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<SafeZoneInfo>(SafeZoneInfoDataGridView); }
    }
}
