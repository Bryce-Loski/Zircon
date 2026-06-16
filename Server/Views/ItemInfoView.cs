using Library;
using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class ItemInfoView : UserControl
    {
        public ItemInfoView()
        {
            InitializeComponent();

            ItemInfoGrid.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            // MonsterLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            // SetLookUpEdit.DataSource = SMain.Session.GetCollection<SetInfo>().Binding;

            ItemTypeImageComboBox.Items.AddEnumValues<ItemType>();
            RequiredClassImageComboBox.Items.AddEnumValues<RequiredClass>();
            RequiredGenderImageComboBox.Items.AddEnumValues<RequiredGender>();
            StatImageComboBox.Items.AddEnumValues<Stat>();
            RequiredTypeImageComboBox.Items.AddEnumValues<RequiredType>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(ItemInfoGrid);
            SMain.SetUpView(ItemStatsGrid);
            SMain.SetUpView(DropsGrid);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SMain.Session.Save(true);
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            JsonImporter.Import<ItemInfo>();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            JsonExporter.Export<ItemInfo>(ItemInfoGrid);
        }
    }
}
