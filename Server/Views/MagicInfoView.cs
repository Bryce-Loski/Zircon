using Library;
using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class MagicInfoView : UserControl
    {
        public MagicInfoView()
        {
            InitializeComponent();
            MainGrid.DataSource = SMain.Session.GetCollection<MagicInfo>().Binding;

            MagicImageComboBox.Items.AddEnumValues<MagicType>();
            SchoolImageComboBox.Items.AddEnumValues<MagicSchool>();
            PropertyImageComboBox.Items.AddEnumValues<MagicProperty>();
            ClassImageComboBox.Items.AddEnumValues<MirClass>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(MainGrid);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<MagicInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<MagicInfo>(MainGrid); }
    }
}
