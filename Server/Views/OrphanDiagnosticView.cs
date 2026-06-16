using Server.Diagnostics;
using Server.Envir;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Server.Views
{
    public partial class OrphanDiagnosticView : UserControl
    {
        private readonly BindingList<OrphanDiagnostic.OrphanTypeResult> _results = new BindingList<OrphanDiagnostic.OrphanTypeResult>();

        public OrphanDiagnosticView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DiagnosticGrid.MultiSelect = true;
            DiagnosticGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DiagnosticGrid.DataSource = _results;
            DiagnosticGrid.ReadOnly = true;
            DiagnosticGrid.AllowUserToAddRows = false;
        }

        private void ScanOrphansButton_Click(object sender, EventArgs e)
        {
            RunScan(cleanRun: false);
        }

        private void CleanOrphansButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,
                "This will mark all cleanable orphan aggregate-child rows as temporary so they are skipped on the next database save. Continue?",
                "Clean DB orphans",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            RunScan(cleanRun: true);
        }

        private void RunScan(bool cleanRun)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                OrphanDiagnostic.ScanResult result = cleanRun
                    ? OrphanDiagnostic.MarkTemporaryOnCleanableOrphans()
                    : OrphanDiagnostic.Scan();

                _results.Clear();
                foreach (OrphanDiagnostic.OrphanTypeResult row in result.Results)
                    _results.Add(row);

                string log = OrphanDiagnostic.FormatLog(result, cleanRun);
                memoTextBox.Text = log;

                DiagnosticGrid.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                string message = cleanRun ? "DB orphan clean failed: " + ex.Message : "DB orphan scan failed: " + ex.Message;
                memoTextBox.Text = message;
                SEnvir.Log(message);
                MessageBox.Show(this, message, "DB Orphans", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
