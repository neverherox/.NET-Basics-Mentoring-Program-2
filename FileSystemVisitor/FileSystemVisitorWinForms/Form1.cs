using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSystemVisitorLibrary.Services;

namespace FileSystemVisitorWinForms
{
    public partial class Form1 : Form
    {
        private Task _executionTask;
        private ExecutionManager _manager;
        private FileSystemVisitor _visitor;
        private readonly VisitorSubscriber _visitorSubscriber;
        private delegate void SafeCallDelegate(DataGridView table, DataRow row);

        public Form1()
        {
            InitializeComponent();
            _visitorSubscriber = new VisitorSubscriber(this);
            dataGridView1.DataSource = new DataTable();
            Files.Columns.Add("Name", typeof(string));
            Files.Columns.Add("Type", typeof(string));
            Files.Columns.Add("Date modified", typeof(DateTime));
            Files.Columns.Add("Size KB", typeof(int));
            Files.Columns.Add("Path", typeof(string));
            dataGridView2.DataSource = new DataTable();
            Events.Columns.Add("Event", typeof(string));
        }

        private DataTable Files => dataGridView1.DataSource as DataTable;

        public new DataTable Events => dataGridView2.DataSource as DataTable;

        public DataGridView EventsGridView => dataGridView2;

        public void AddRowSafe(DataGridView table, DataRow row)
        {
            if (table.InvokeRequired)
            {
                var d = new SafeCallDelegate(AddRowSafe);
                table.Invoke(d, table, row);
            }
            else
            {
                ((DataTable)table.DataSource).Rows.Add(row);
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Files.Rows.Clear();
            Events.Rows.Clear();
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _visitor = new FileSystemVisitor();
                if (!string.IsNullOrEmpty(Filter.Text))
                {
                    var filter = BuildFilter();
                    _visitor = new FileSystemVisitor(filter);
                }
                var path = dialog.SelectedPath;
                _manager = new ExecutionManager(ShouldRiseEvents.Checked, path);
                _visitorSubscriber.Subscribe(_visitor);
                _visitor.Subscribe(_manager);
                _manager.StartExecution();
                _executionTask = new Task(() =>
                {
                    try
                    {
                        foreach (var item in _visitor.Tree)
                        {
                            var row = Files.NewRow();
                            row["Name"] = item.Name;
                            row["Date modified"] = item.LastWriteTime;
                            row["Type"] = "Directory";
                            row["Path"] = item.FullName;
                            if (item is FileInfo)
                            {
                                row["Type"] = "File";
                                row["Size KB"] = ((FileInfo) item).Length / 1024;
                            }
                            AddRowSafe(dataGridView1, row);
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
                _executionTask.Start();
                _executionTask.ContinueWith(t1 =>
                {
                    _visitorSubscriber.Unsubscribe(_visitor);
                    _visitor.Unsubscribe(_manager);
                });
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            _manager.StopExecution();
            if (_executionTask != null)
            {
                _executionTask.ContinueWith(t1 =>
                {
                    _visitorSubscriber.Unsubscribe(_visitor);
                    _visitor.Unsubscribe(_manager);
                });
            }
        }

        private Func<FileSystemInfo, bool> BuildFilter()
        {
            if (Contains.Checked)
            {
                return x => x.Name.Contains(Filter.Text);
            }
            if (Starts.Checked)
            {
                return x => x.Name.StartsWith(Filter.Text);
            }
            return x => x.Name.EndsWith(Filter.Text);
        }
    }
}
