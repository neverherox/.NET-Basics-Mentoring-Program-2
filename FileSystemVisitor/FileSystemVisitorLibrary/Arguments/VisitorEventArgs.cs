using System;

namespace FileSystemVisitorLibrary.Arguments
{
    public class VisitorEventArgs : EventArgs
    {
        public string FsInfoName { get; }

        public VisitorEventArgs(string fsInfoName)
        {
            FsInfoName = fsInfoName;
        }
    }
}
