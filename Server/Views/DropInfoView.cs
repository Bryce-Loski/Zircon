using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class DropInfoView : UserControl
    {
        public DropInfoView()
        {
            InitializeComponent();
            DropInfoDataGridView.DataSource = SMain.Session.GetCollection<DropInfo>().Binding;
            // MonsterLookUpEdit.DataSource = SMain.Session.GetCollection<MonsterInfo>().Binding;
            // ItemLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SMain.SetUpView(DropInfoDataGridView);
        }

        private void SaveButton_Click(object sender, EventArgs e) { SMain.Session.Save(true); }
        private void ImportButton_Click(object sender, EventArgs e) { JsonImporter.Import<DropInfo>(); }
        private void ExportButton_Click(object sender, EventArgs e) { JsonExporter.Export<DropInfo>(DropInfoDataGridView); }
    }
}
