using Library;
using Library.SystemModels;
using Server.Envir;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class EventInfoView : UserControl
    {
        public EventInfoView()
        {
            InitializeComponent();

            WorldEventInfoGrid.DataSource = SMain.Session.GetCollection<WorldEventInfo>().Binding;
            PlayerEventInfoGrid.DataSource = SMain.Session.GetCollection<PlayerEventInfo>().Binding;
            MonsterEventInfoGrid.DataSource = SMain.Session.GetCollection<MonsterEventInfo>().Binding;

            // WorldMonsterLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            // WorldRespawnLookUpEdit.DataSource = SMain.Session.GetCollection<RespawnInfo>().Binding;
            // WorldRegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding.Where(x => x.RegionType == RegionType.None || x.RegionType == RegionType.Area);
            // WorldMapLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
            // WorldInstanceLookUpEdit.DataSource = SMain.Session.GetCollection<InstanceInfo>().Binding;
            // WorldActionTypeLookUpEdit.DataSource = SEnvir.EventHandler.GetWorldEventActions();

            // PlayerMonsterLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            // PlayerRespawnLookUpEdit.DataSource = SMain.Session.GetCollection<RespawnInfo>().Binding;
            // PlayerRegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding.Where(x => x.RegionType == RegionType.None || x.RegionType == RegionType.Area);
            // PlayerMapLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
            // PlayerInstanceLookUpEdit.DataSource = SMain.Session.GetCollection<InstanceInfo>().Binding;
            // PlayerItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            // PlayerActionTypeLookUpEdit.DataSource = SEnvir.EventHandler.GetPlayerEventActions();

            // MonsterMonsterLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            // MonsterRespawnLookUpEdit.DataSource = SMain.Session.GetCollection<RespawnInfo>().Binding;
            // MonsterRegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding.Where(x => x.RegionType == RegionType.None || x.RegionType == RegionType.Area);
            // MonsterMapLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
            // MonsterInstanceLookUpEdit.DataSource = SMain.Session.GetCollection<InstanceInfo>().Binding;
            // MonsterItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            // MonsterActionTypeLookUpEdit.DataSource = SEnvir.EventHandler.GetMonsterEventActions();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(WorldEventInfoGrid);
            SMain.SetUpView(PlayerEventInfoGrid);
            SMain.SetUpView(MonsterEventInfoGrid);

            SMain.SetUpView(WorldTriggersGrid);
            SMain.SetUpView(WorldActionsGrid);

            SMain.SetUpView(PlayerTriggersGrid);
            SMain.SetUpView(PlayerActionsGrid);

            SMain.SetUpView(MonsterTriggersGrid);
            SMain.SetUpView(MonsterActionsGrid);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (viewTabControl.SelectedTab == worldOuterTabPage)
            {
                JsonImporter.Import<WorldEventInfo>();
            }
            else if (viewTabControl.SelectedTab == playerOuterTabPage)
            {
                JsonImporter.Import<PlayerEventInfo>();
            }
            else if (viewTabControl.SelectedTab == monsterOuterTabPage)
            {
                JsonImporter.Import<MonsterEventInfo>();
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (viewTabControl.SelectedTab == worldOuterTabPage)
            {
                JsonExporter.Export<WorldEventInfo>(WorldEventInfoGrid);
            }
            else if (viewTabControl.SelectedTab == playerOuterTabPage)
            {
                JsonExporter.Export<PlayerEventInfo>(PlayerEventInfoGrid);
            }
            else if (viewTabControl.SelectedTab == monsterOuterTabPage)
            {
                JsonExporter.Export<MonsterEventInfo>(MonsterEventInfoGrid);
            }
        }
    }
}
