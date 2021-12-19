using System;
using System.Collections.Generic;
using System.IO;
using FileSystemVisitorLibrary.Arguments;

namespace FileSystemVisitorLibrary.Interfaces
{
    public interface IFileSystemVisitor
    {
        event EventHandler Start;

        event EventHandler Finish;

        event EventHandler<VisitorEventArgs> FileFound;

        event EventHandler<VisitorEventArgs> DirectoryFound;

        event EventHandler<VisitorEventArgs> FilteredFileFound;

        event EventHandler<VisitorEventArgs> FilteredDirectoryFound;

        IEnumerable<FileSystemInfo> Tree { get; }

        IEnumerable<FileSystemInfo> Traverse(bool riseEvents, string directoryPath);
    }
}
