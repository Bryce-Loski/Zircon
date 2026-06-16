using Library;
using Library.SystemModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class NPCInfoView : UserControl
    {
        public NPCInfoView()
        {
            InitializeComponent();
            MainGrid.DataSource = SMain.Session.GetCollection<NPCInfo>().Binding;

            // RegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding.Where(x => x.RegionType == RegionType.None || x.RegionType == RegionType.Npc);
            // PageLookUpEdit.DataSource = SMain.Session.GetCollection<NPCPage>().Binding;
            // QuestInfoLookUpEdit.DataSource = SMain.Session.GetCollection<QuestInfo>().Binding;
            // ItemInfoLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;

            RequiredClassImageComboBox.Items.AddEnumValues<RequiredClass>();
            RequirementImageComboBox.Items.AddEnumValues<NPCRequirementType>();
            MapIconImageComboBox.Items.AddEnumValues<MapIcon>();
            DaysOfWeekImageComboBox.Items.AddEnumValues<DaysOfWeek>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(MainGrid);
            SMain.SetUpView(RequirementGrid);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<NPCInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<NPCInfo>(MainGrid); }

        private void InsertRowButton_Click(object sender, EventArgs e)
        {
            SMain.InsertRowAfterFocusedObject<NPCInfo>(MainGrid);
        }
    }
}
