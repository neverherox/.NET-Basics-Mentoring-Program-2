using System;
using FileSystemVisitorLibrary.Arguments;
using FileSystemVisitorLibrary.Interfaces;

namespace FileSystemVisitorLibrary.Services
{
    public class ExecutionManager: IExecutionManager<ManagerEventArgs>
    {
        private readonly bool _shouldRiseEvents;
        private readonly string _directoryPath;

        public ExecutionManager(bool shouldRiseEvents, string directoryPath)
        {
            _shouldRiseEvents = shouldRiseEvents;
            _directoryPath = directoryPath;
        }

        public event EventHandler<ManagerEventArgs> Start;

        public event EventHandler<ManagerEventArgs> Stop;

        public void StartExecution()
        {
            var args = new ManagerEventArgs(false, _directoryPath, _shouldRiseEvents);
            Start?.Invoke(this, args);
        }

        public void StopExecution()
        {
            var args = new ManagerEventArgs(true);
            Stop?.Invoke(this, args);
        }
    }
}
