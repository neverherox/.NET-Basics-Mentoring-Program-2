using FileCab.Documents;

namespace FileCab.Interfaces
{
    public interface ICardCacheService
    {
        void AddCard<T>(string key, T card) where T : Document;

        T GetCard<T>(string key) where T : Document;
    }
}
