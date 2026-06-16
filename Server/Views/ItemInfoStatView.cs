using Library;
using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class ItemInfoStatView : UserControl
    {
        public ItemInfoStatView()
        {
            InitializeComponent();
            ItemInfoStatDataGridView.DataSource = SMain.Session.GetCollection<ItemInfoStat>().Binding;
            // ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            StatImageComboBox.Items.AddEnumValues<Stat>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(ItemInfoStatDataGridView);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<ItemInfoStat>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<ItemInfoStat>(ItemInfoStatDataGridView); }
    }
}
