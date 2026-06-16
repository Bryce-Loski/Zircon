using Library;
using Library.SystemModels;
using System;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class NPCPageView : UserControl
    {
        public NPCPageView()
        {
            InitializeComponent();

            NPCPageGrid.DataSource = SMain.Session.GetCollection<NPCPage>().Binding;

            // PageLookUpEdit.DataSource = SMain.Session.GetCollection<NPCPage>().Binding;
            // ItemInfoLookUpEdit.DataSource = SMain.Session.GetCollection<ItemInfo>().Binding;
            // MapLookUpEdit.DataSource = SMain.Session.GetCollection<MapInfo>().Binding;
            // InstanceLookUpEdit.DataSource = SMain.Session.GetCollection<InstanceInfo>().Binding;
            // CurrencyInfoLookUpEdit.DataSource = SMain.Session.GetCollection<CurrencyInfo>().Binding;

            DialogTypeImageComboBox.Items.AddEnumValues<NPCDialogType>();
            CheckTypeImageComboBox.Items.AddEnumValues<NPCCheckType>();
            ActionTypeImageComboBox.Items.AddEnumValues<NPCActionType>();
            ItemTypeImageComboBox.Items.AddEnumValues<ItemType>();
            DataTypeImageComboBox.Items.AddEnumValues<NPCDataType>();
            ValueTypeImageComboBox.Items.AddEnumValues<NPCValueType>();
            FieldTypeImageComboBox.Items.AddEnumValues<NPCFieldType>();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SMain.Session.Save(true);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SMain.SetUpView(NPCPageGrid);
            SMain.SetUpView(ChecksGrid);
            SMain.SetUpView(ActionsGrid);
            SMain.SetUpView(ButtonsGrid);
            SMain.SetUpView(TypesGrid);
            SMain.SetUpView(GoodsGrid);
            SMain.SetUpView(ValuesGrid);
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            JsonImporter.Import<NPCPage>();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            JsonExporter.Export<NPCPage>(NPCPageGrid);
        }

        private void InsertRowButton_Click(object sender, EventArgs e)
        {
            SMain.InsertRowAfterFocusedObject<NPCPage>(NPCPageGrid);
        }
    }
}
