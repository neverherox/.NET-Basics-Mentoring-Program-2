using System.Collections.Generic;
using FileCab.Documents;

namespace FileCab.Interfaces
{
    public interface IRepository
    {
        void Write<T>(IEnumerable<T> documents) where T : Document;

        IEnumerable<T> Read<T>() where T : Document;
    }
}
