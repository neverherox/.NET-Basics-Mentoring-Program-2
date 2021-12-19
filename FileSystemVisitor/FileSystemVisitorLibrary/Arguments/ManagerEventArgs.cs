using System;

namespace FileSystemVisitorLibrary.Arguments
{
    public class ManagerEventArgs : EventArgs
    {
        public string DirectoryPath { get; }

        public bool ShouldStop { get; }

        public bool RiseEvents { get; }

        public ManagerEventArgs(bool shouldStop, string directoryPath, bool riseEvents)
        {
            ShouldStop = shouldStop;
            DirectoryPath = directoryPath;
            RiseEvents = riseEvents;
        }

        public ManagerEventArgs(bool shouldStop)
        {
            ShouldStop = shouldStop;
        }
    }
}
