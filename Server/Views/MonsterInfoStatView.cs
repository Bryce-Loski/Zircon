using Library;
using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class MonsterInfoStatView : UserControl
    {
        public MonsterInfoStatView()
        {
            InitializeComponent();
            MonsterInfoStatDataGridView.DataSource = SMain.Session.GetCollection<MonsterInfoStat>().Binding;
            // MonsterLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            StatImageComboBox.Items.AddEnumValues<Stat>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(MonsterInfoStatDataGridView);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<MonsterInfoStat>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<MonsterInfoStat>(MonsterInfoStatDataGridView); }
    }
}
