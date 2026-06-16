using Library;
using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class MapInfoView : UserControl
    {
        public MapInfoView()
        {
            InitializeComponent();

            MapInfoGrid.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
            // MonsterLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            // MapInfoLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
            // ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            // RegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;

            LightComboBox.Items.AddEnumValues<LightSetting>();
            WeatherComboBox.Items.AddEnumValues<Weather>();
            DirectionImageComboBox.Items.AddEnumValues<MirDirection>();
            MapIconImageComboBox.Items.AddEnumValues<MapIcon>();
            StartClassImageComboBox.Items.AddEnumValues<RequiredClass>();
            RequiredClassImageComboBox.Items.AddEnumValues<RequiredClass>();
            StatImageComboBox.Items.AddEnumValues<Stat>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(MapInfoGrid);
            SMain.SetUpView(GuardsGrid);
            SMain.SetUpView(RegionGrid);
            SMain.SetUpView(MiningGrid);

            UpdateInfoStats();
        }

        private void UpdateInfoStats()
        {
            bool needSave = false;

            foreach (var map in SMain.Session.GetCollection<MapInfo>().Binding)
            {
                if (map.MonsterHealth != 0)
                {
                    var stat = SMain.Session.GetCollection<MapInfoStat>().CreateNewObject();
                    stat.Stat = Stat.MonsterHealth;
                    stat.Amount = map.MonsterHealth;
                    map.BuffStats.Add(stat);

                    map.MonsterHealth = 0;
                    needSave = true;
                }

                if (map.MonsterDamage != 0)
                {
                    var stat = SMain.Session.GetCollection<MapInfoStat>().CreateNewObject();
                    stat.Stat = Stat.MonsterDamage;
                    stat.Amount = map.MonsterDamage;
                    map.BuffStats.Add(stat);

                    map.MonsterDamage = 0;
                    needSave = true;
                }

                if (map.DropRate != 0)
                {
                    var stat = SMain.Session.GetCollection<MapInfoStat>().CreateNewObject();
                    stat.Stat = Stat.MonsterDrop;
                    stat.Amount = map.DropRate;
                    map.BuffStats.Add(stat);

                    map.DropRate = 0;
                    needSave = true;
                }

                if (map.ExperienceRate != 0)
                {
                    var stat = SMain.Session.GetCollection<MapInfoStat>().CreateNewObject();
                    stat.Stat = Stat.MonsterExperience;
                    stat.Amount = map.ExperienceRate;
                    map.BuffStats.Add(stat);

                    map.ExperienceRate = 0;
                    needSave = true;
                }

                if (map.GoldRate != 0)
                {
                    var stat = SMain.Session.GetCollection<MapInfoStat>().CreateNewObject();
                    stat.Stat = Stat.MonsterGold;
                    stat.Amount = map.GoldRate;
                    map.BuffStats.Add(stat);

                    map.GoldRate = 0;
                    needSave = true;
                }

                if (map.MaxMonsterHealth != 0)
                {
                    var stat = SMain.Session.GetCollection<MapInfoStat>().CreateNewObject();
                    stat.Stat = Stat.MaxMonsterHealth;
                    stat.Amount = map.MaxMonsterHealth;
                    map.BuffStats.Add(stat);

                    map.MaxMonsterHealth = 0;
                    needSave = true;
                }

                if (map.MaxMonsterDamage != 0)
                {
                    var stat = SMain.Session.GetCollection<MapInfoStat>().CreateNewObject();
                    stat.Stat = Stat.MaxMonsterDamage;
                    stat.Amount = map.MaxMonsterDamage;
                    map.BuffStats.Add(stat);

                    map.MaxMonsterDamage = 0;
                    needSave = true;
                }

                if (map.MaxDropRate != 0)
                {
                    var stat = SMain.Session.GetCollection<MapInfoStat>().CreateNewObject();
                    stat.Stat = Stat.MaxMonsterDrop;
                    stat.Amount = map.MaxDropRate;
                    map.BuffStats.Add(stat);

                    map.MaxDropRate = 0;
                    needSave = true;
                }

                if (map.MaxExperienceRate != 0)
                {
                    var stat = SMain.Session.GetCollection<MapInfoStat>().CreateNewObject();
                    stat.Stat = Stat.MaxMonsterExperience;
                    stat.Amount = map.MaxExperienceRate;
                    map.BuffStats.Add(stat);

                    map.MaxExperienceRate = 0;
                    needSave = true;
                }

                if (map.MaxGoldRate != 0)
                {
                    var stat = SMain.Session.GetCollection<MapInfoStat>().CreateNewObject();
                    stat.Stat = Stat.MaxMonsterGold;
                    stat.Amount = map.MaxGoldRate;
                    map.BuffStats.Add(stat);

                    map.MaxGoldRate = 0;
                    needSave = true;
                }
            }

            if (needSave)
            {
                SMain.Session.Save(true);
            }
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

            if (RegionGrid.CurrentRow == null) return;

            var region = RegionGrid.CurrentRow.DataBoundItem as MapRegion;
            if (region == null) return;

            MapViewer.CurrentViewer.Save();
            MapViewer.CurrentViewer.MapRegion = region;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            JsonImporter.Import<MapInfo>();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            JsonExporter.Export<MapInfo>(MapInfoGrid);
        }

        private void InsertRowButton_Click(object sender, EventArgs e)
        {
            SMain.InsertRowAfterFocusedObject<MapInfo>(MapInfoGrid);
        }
    }
}
