using Library;
using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class FameInfoView : UserControl
    {
        public FameInfoView()
        {
            InitializeComponent();
            MainGrid.DataSource = SMain.Session.GetCollection<FameInfo>().Binding;

            StatComboBox.Items.AddEnumValues<Stat>();
            // ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(MainGrid);
            SMain.SetUpView(FameInfoStatGrid);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<FameInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<FameInfo>(MainGrid); }
    }
}
