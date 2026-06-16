using Library;
using Library.SystemModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class CompanionInfoView : UserControl
    {
        public CompanionInfoView()
        {
            InitializeComponent();

            CompanionInfoGrid.DataSource = SMain.Session.GetCollection<CompanionInfo>().Binding;
            CompanionLevelInfoGrid.DataSource = SMain.Session.GetCollection<CompanionLevelInfo>().Binding;
            CompanionSkillInfoGrid.DataSource = SMain.Session.GetCollection<CompanionSkillInfo>().Binding;

            // MonsterInfoLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            // CurrencyInfoLookUpEdit.DataSource = SMain.Session.GetCollection<CurrencyInfo>().Binding;
            // ItemInfoLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;

            CompanionActionImageComboBox.Items.AddEnumValues<CompanionAction>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(CompanionInfoGrid);
            SMain.SetUpView(CompanionSpeechGrid);
            SMain.SetUpView(CompanionLevelInfoGrid);
            SMain.SetUpView(CompanionSkillInfoGrid);

            var goldCurrency = SMain.Session.GetCollection<CurrencyInfo>().Binding.Where(x => x.Type == CurrencyType.Gold).FirstOrDefault();

            if (goldCurrency == null) return;

            var companions = SMain.Session.GetCollection<CompanionInfo>().Binding;

            foreach (var companion in companions)
                companion.Currency ??= goldCurrency;

            CompanionInfoGrid.RefreshEdit();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (viewTabControl.SelectedTab == companionInfoTabPage)
            {
                JsonImporter.Import<CompanionInfo>();
            }
            else if (viewTabControl.SelectedTab == companionLevelTabPage)
            {
                JsonImporter.Import<CompanionLevelInfo>();
            }
            else if (viewTabControl.SelectedTab == companionSkillTabPage)
            {
                JsonImporter.Import<CompanionSkillInfo>();
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (viewTabControl.SelectedTab == companionInfoTabPage)
            {
                JsonExporter.Export<CompanionInfo>(CompanionInfoGrid);
            }
            else if (viewTabControl.SelectedTab == companionLevelTabPage)
            {
                JsonExporter.Export<CompanionLevelInfo>(CompanionLevelInfoGrid);
            }
            else if (viewTabControl.SelectedTab == companionSkillTabPage)
            {
                JsonExporter.Export<CompanionSkillInfo>(CompanionSkillInfoGrid);
            }
        }
    }
}
