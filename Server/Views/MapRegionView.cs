using Library;
using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class MapRegionView : UserControl
    {
        public MapRegionView()
        {
            InitializeComponent();

            MapRegionGrid.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            // MapLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;

            RegionTypeImageComboBox.Items.AddEnumValues<RegionType>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(MapRegionGrid);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void EditMapButton_Click(object sender, EventArgs e)
        {
            if (MapViewer.CurrentViewer == null)
            {
                MapViewer.CurrentViewer = new MapViewer();
                MapViewer.CurrentViewer.Show();
            }

            MapViewer.CurrentViewer.BringToFront();

            if (MapRegionGrid.CurrentRow == null) return;

            var region = MapRegionGrid.CurrentRow.DataBoundItem as MapRegion;
            if (region == null) return;

            MapViewer.CurrentViewer.Save();
            MapViewer.CurrentViewer.MapRegion = region;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            JsonImporter.Import<MapRegion>();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            JsonExporter.Export<MapRegion>(MapRegionGrid);
        }

        private void InsertRowButton_Click(object sender, EventArgs e)
        {
            SMain.InsertRowAfterFocusedObject<MapRegion>(MapRegionGrid);
        }
    }
}
