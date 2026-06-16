using Library;
using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class SetInfoView : UserControl
    {
        public SetInfoView()
        {
            InitializeComponent();
            SetInfoDataGridView.DataSource = SMain.Session.GetCollection<SetInfo>().Binding;
            RequiredClassImageComboBox.Items.AddEnumValues<RequiredClass>();
            StatImageComboBox.Items.AddEnumValues<Stat>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(SetInfoDataGridView);
            SMain.SetUpView(SetStatsDataGridView);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<SetInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<SetInfo>(SetInfoDataGridView); }
    }
}
