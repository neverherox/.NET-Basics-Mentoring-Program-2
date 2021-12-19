using System;

namespace FileSystemVisitorLibrary.Interfaces
{
    public interface IExecutionManager<T> where T : EventArgs
    {
        event EventHandler<T> Start;

        event EventHandler<T> Stop;

        void StartExecution();

        void StopExecution();
    }
}
