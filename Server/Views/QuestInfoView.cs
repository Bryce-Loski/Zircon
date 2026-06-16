using Library;
using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class QuestInfoView : UserControl
    {
        public QuestInfoView()
        {
            InitializeComponent();

            RequirementImageComboBox.Items.AddEnumValues<QuestRequirementType>();
            TaskImageComboBox.Items.AddEnumValues<QuestTaskType>();
            RequiredClassImageComboBox.Items.AddEnumValues<RequiredClass>();
            TypeImageComboBox.Items.AddEnumValues<QuestType>();

            QuestInfoGrid.DataSource = SMain.Session.GetCollection<QuestInfo>().Binding;

            // QuestInfoLookUpEdit.DataSource = SMain.Session.GetCollection<QuestInfo>().Binding;
            // ItemInfoLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            // MonsterInfoLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            // MapInfoLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
            // RegionLookUpEdit.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            // NPCLookUpEdit.DataSource = SMain.Session.GetCollection<NPCInfo>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(QuestInfoGrid);
            SMain.SetUpView(RequirementsGrid);
            SMain.SetUpView(TaskGrid);
            SMain.SetUpView(MonsterDetailsGrid);
            SMain.SetUpView(RewardsGrid);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            JsonImporter.Import<QuestInfo>();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            JsonExporter.Export<QuestInfo>(QuestInfoGrid);
        }
    }
}
