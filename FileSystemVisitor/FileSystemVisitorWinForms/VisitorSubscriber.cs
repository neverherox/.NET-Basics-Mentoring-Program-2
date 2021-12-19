using System;
using System.Drawing;
using FileSystemVisitorLibrary.Arguments;
using FileSystemVisitorLibrary.Interfaces;

namespace FileSystemVisitorWinForms
{
    public class VisitorSubscriber : IEventSubscriber<IFileSystemVisitor>
    {
        private readonly Form1 _mainForm;

        public VisitorSubscriber(Form1 mainForm)
        {
            _mainForm = mainForm;
        }

        private void Publisher_Start(object sender, EventArgs e)
        {
            var row = _mainForm.Events.NewRow();
            row["Event"] = "Start searching";
            _mainForm.AddRowSafe(_mainForm.EventsGridView, row);
        }

        private void Publisher_Finish(object sender, EventArgs e)
        {
            var row = _mainForm.Events.NewRow();
            row["Event"] = "Stop searching";
            _mainForm.AddRowSafe(_mainForm.EventsGridView, row);
        }

        private void Publisher_FileFound(object sender, VisitorEventArgs e)
        {
            var row = _mainForm.Events.NewRow();
            row["Event"] = e.FsInfoName + " file found";
            _mainForm.AddRowSafe(_mainForm.EventsGridView, row);
        }

        private void Publisher_DirectoryFound(object sender, VisitorEventArgs e)
        {
            var row = _mainForm.Events.NewRow();
            row["Event"] = e.FsInfoName + " directory found";
            _mainForm.AddRowSafe(_mainForm.EventsGridView, row);
        }

        private void Publisher_FilteredFileFound(object sender, VisitorEventArgs e)
        {
            var row = _mainForm.Events.NewRow();
            row["Event"] = e.FsInfoName + " filtered file found";
            _mainForm.AddRowSafe(_mainForm.EventsGridView, row);
            _mainForm
                .EventsGridView.Rows[row.Table.Rows.IndexOf(row)]
                .DefaultCellStyle.BackColor = Color.Green;
        }

        private void Publisher_FilteredDirectoryFound(object sender, VisitorEventArgs e)
        {
            var row = _mainForm.Events.NewRow();
            row["Event"] = e.FsInfoName + " filtered directory found";
            _mainForm.AddRowSafe(_mainForm.EventsGridView, row);
            _mainForm
                .EventsGridView.Rows[row.Table.Rows.IndexOf(row)]
                .DefaultCellStyle.BackColor = Color.Green;
        }

        public void Subscribe(IFileSystemVisitor publisher)
        {
            publisher.Start += Publisher_Start;
            publisher.Finish += Publisher_Finish;
            publisher.FileFound += Publisher_FileFound;
            publisher.DirectoryFound += Publisher_DirectoryFound;
            publisher.FilteredFileFound += Publisher_FilteredFileFound;
            publisher.FilteredDirectoryFound += Publisher_FilteredDirectoryFound;
        }

        public void Unsubscribe(IFileSystemVisitor publisher)
        {
            publisher.Start -= Publisher_Start;
            publisher.Finish -= Publisher_Finish;
            publisher.FileFound -= Publisher_FileFound;
            publisher.DirectoryFound -= Publisher_DirectoryFound;
            publisher.FilteredFileFound -= Publisher_FilteredFileFound;
            publisher.FilteredDirectoryFound -= Publisher_FilteredDirectoryFound;
        }
    }
}
