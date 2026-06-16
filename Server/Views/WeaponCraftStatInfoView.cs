using Library;
using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class WeaponCraftStatInfoView : UserControl
    {
        public WeaponCraftStatInfoView()
        {
            InitializeComponent();
            WeaponCraftStatInfoDataGridView.DataSource = SMain.Session.GetCollection<WeaponCraftStatInfo>().Binding;
            // ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            StatImageComboBox.Items.AddEnumValues<Stat>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(WeaponCraftStatInfoDataGridView);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<WeaponCraftStatInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<WeaponCraftStatInfo>(WeaponCraftStatInfoDataGridView); }
    }
}
