using Library;
using Library.SystemModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class MilestoneInfoView : UserControl
    {
        public MilestoneInfoView()
        {
            InitializeComponent();
            MainGrid.DataSource = SMain.Session.GetCollection<MilestoneInfo>().Binding;

            TypeImageComboBox.Items.AddEnumValues<MilestoneType>();
            RequiredClassImageComboBox.Items.AddEnumValues<RequiredClass>();
            GradeImageComboBox.Items.AddEnumValues<MilestoneGrade>();
            // ItemInfoLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            // MonsterInfoLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            // RegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding.Where(x => x.RegionType == RegionType.None || x.RegionType == RegionType.Area);
            // CurrencyInfoLookUpEdit.DataSource = SMain.Session.GetCollection<CurrencyInfo>().Binding;
            // InstanceInfoLookUpEdit.DataSource = SMain.Session.GetCollection<InstanceInfo>().Binding;
            // QuestInfoLookUpEdit.DataSource = SMain.Session.GetCollection<QuestInfo>().Binding;
            // MagicInfoLookUpEdit.DataSource = SMain.Session.GetCollection<MagicInfo>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(MainGrid);
            SMain.SetUpView(MilestoneInfoTaskGrid);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<MilestoneInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<MilestoneInfo>(MainGrid); }
    }
}
