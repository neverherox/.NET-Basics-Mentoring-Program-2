using System.Collections.Generic;
using FileCab.Documents;

namespace FileCab.Interfaces
{
    public interface IFileCabinet
    {
        T GetCard<T>(int id) where T : Document;

        IEnumerable<T> GetCards<T>() where T : Document;

        void AddCards<T>(IEnumerable<T> cards) where T : Document;
    }
}
