using System;
using System.Collections.Generic;
using System.IO;
using FileSystemVisitorLibrary.Arguments;
using FileSystemVisitorLibrary.Interfaces;

namespace FileSystemVisitorLibrary.Services
{
    public class FileSystemVisitor : IFileSystemVisitor, IEventSubscriber<IExecutionManager<ManagerEventArgs>>
    {
        private bool _shouldStop;
        private readonly Func<FileSystemInfo, bool> _filter;

        public FileSystemVisitor(Func<FileSystemInfo, bool> filter = null)
        {
            _filter = filter;
        }

        public event EventHandler Start;

        public event EventHandler Finish;

        public event EventHandler<VisitorEventArgs> FileFound;

        public event EventHandler<VisitorEventArgs> DirectoryFound;

        public event EventHandler<VisitorEventArgs> FilteredFileFound;

        public event EventHandler<VisitorEventArgs> FilteredDirectoryFound;

        public IEnumerable<FileSystemInfo> Tree { get; private set; }

        public IEnumerable<FileSystemInfo> Traverse(bool shouldRiseEvents, string directoryPath)
        {
            if(!string.IsNullOrEmpty(directoryPath))
            {
                var root = new DirectoryInfo(directoryPath);
                if (root.Exists)
                {
                    Tree = Traverse(root, shouldRiseEvents);
                    return Tree;
                }
            }
            throw new DirectoryNotFoundException();
        }

        private IEnumerable<FileSystemInfo> Traverse(DirectoryInfo root, bool shouldRiseEvents)
        {
            if (shouldRiseEvents)
            {
                Start?.Invoke(this, EventArgs.Empty);
            }

            try
            {
                var directories = new Stack<DirectoryInfo>();
                directories.Push(root);

                while (directories.Count > 0 && !_shouldStop)
                {
                    var currentDir = directories.Pop();
                    var subDirectories = currentDir.GetDirectories();
                    var files = currentDir.GetFiles();

                    foreach (FileInfo file in files)
                    {
                        if (_shouldStop)
                        {
                            break;
                        }

                        RiseFoundEvent(shouldRiseEvents, file, FileFound);
                        if (_filter == null)
                        {
                            yield return file;
                        }
                        else
                        {
                            if (_filter(file))
                            {
                                RiseFoundEvent(shouldRiseEvents, file, FilteredFileFound);
                                yield return file;
                            }
                        }
                    }

                    foreach (DirectoryInfo directory in subDirectories)
                    {
                        if (_shouldStop)
                        {
                            break;
                        }

                        directories.Push(directory);
                        RiseFoundEvent(shouldRiseEvents, directory, DirectoryFound);
                        if (_filter == null)
                        {
                            yield return directory;
                        }
                        else
                        {
                            if (_filter(directory))
                            {
                                RiseFoundEvent(shouldRiseEvents, directory, FilteredDirectoryFound);
                                yield return directory;
                            }
                        }
                    }
                }
            }
            finally
            {
                if (shouldRiseEvents)
                {
                    Finish?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void RiseFoundEvent(bool shouldRiseEvents, FileSystemInfo file, EventHandler<VisitorEventArgs> found)
        {
            if (shouldRiseEvents)
            {
                var args = new VisitorEventArgs(file.Name);
                found?.Invoke(this, args);
            }
        }

        public void Subscribe(IExecutionManager<ManagerEventArgs> executionManager)
        {
            executionManager.Start += ExecutionManager_Start;
            executionManager.Stop += ExecutionManager_Stop;
        }

        public void Unsubscribe(IExecutionManager<ManagerEventArgs> executionManager)
        {
            executionManager.Start -= ExecutionManager_Start;
            executionManager.Stop -= ExecutionManager_Stop;
        }

        private void ExecutionManager_Start(object sender, ManagerEventArgs e)
        {
            _shouldStop = e.ShouldStop;
            Traverse(e.RiseEvents, e.DirectoryPath);
        }

        private void ExecutionManager_Stop(object sender, ManagerEventArgs e)
        {
            _shouldStop = e.ShouldStop;
        }
    }
}
