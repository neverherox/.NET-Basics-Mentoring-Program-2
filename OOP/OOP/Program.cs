using System;
using System.Collections.Generic;
using FileCab;
using FileCab.Documents;
using FileCab.Services;
using Microsoft.Extensions.Caching.Memory;
using OOP.JsonRepositories;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var initialBooks = GetBooks();
            var initialPatents = GetPatents();
            var initialLocalizedBooks = GetLocalizedBooks();
            var initialMagazines = GetMagazines();
            var genericRepository = new JsonRepository();

            var withExpiration = new MemoryCacheEntryOptions();
            withExpiration.SetAbsoluteExpiration(TimeSpan.FromSeconds(5));
            var withoutExpiration = new MemoryCacheEntryOptions();
            var cardsLifeTimes = new Dictionary<Type, MemoryCacheEntryOptions>
            {
                { typeof(Patent), withExpiration },
                { typeof(LocalizedBook), withExpiration },
                { typeof(Magazine), withoutExpiration }
            };
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var cardCacheService = new CardCacheService(memoryCache, cardsLifeTimes);
            var fileCabinet = new FileCabinet(genericRepository, cardCacheService);

            fileCabinet.AddCards(initialBooks);
            fileCabinet.AddCards(initialPatents);
            fileCabinet.AddCards(initialLocalizedBooks);
            fileCabinet.AddCards(initialMagazines);

            var book = fileCabinet.GetCard<Book>(1);
            var patent = fileCabinet.GetCard<Patent>(1);
            var localizedBook = fileCabinet.GetCard<LocalizedBook>(1);
            var magazine = fileCabinet.GetCard<Magazine>(1);

            var cachedPatent = fileCabinet.GetCard<Patent>(1);
            var cachedLocalizedBook = fileCabinet.GetCard<LocalizedBook>(1);
            var cachedMagazine = fileCabinet.GetCard<Magazine>(1);

            var books = new List<Book> { book };
            var patents = new List<Patent> { patent, cachedPatent };
            var localizedBooks = new List<LocalizedBook> { localizedBook, cachedLocalizedBook };
            var magazines = new List<Magazine> { magazine, cachedMagazine };

            PrintBooks(books);
            PrintPatents(patents);
            PrintLocalizedBooks(localizedBooks);
            PrintMagazines(magazines);
        }

        static IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>();
            var book = new Book
            {
                Id = 1,
                Title = "book",
                Authors = "author",
                DatePublished = DateTime.UtcNow,
                ISBN = "isbn",
                NumberOfPages = 300,
                Publisher = "publisher"
            };
            var book1 = new Book
            {
                Id = 2,
                Title = "book1",
                Authors = "author1",
                DatePublished = DateTime.UtcNow,
                ISBN = "isbn1",
                NumberOfPages = 301,
                Publisher = "publisher1"
            };

            books.Add(book);
            books.Add(book1);

            return books;
        }

        static IEnumerable<Patent> GetPatents()
        {
            var patents = new List<Patent>();
            var patent = new Patent
            {
                Id = 1,
                Title = "patent",
                Authors = "author",
                DatePublished = DateTime.UtcNow,
                UniqueId = 1,
                ExpirationDate = DateTime.UtcNow
            };
            var patent1 = new Patent
            {
                Id = 2,
                Title = "patent1",
                Authors = "author1",
                DatePublished = DateTime.UtcNow,
                UniqueId = 2,
                ExpirationDate = DateTime.UtcNow
            };

            patents.Add(patent);
            patents.Add(patent1);

            return patents;
        }

        static IEnumerable<LocalizedBook> GetLocalizedBooks()
        {
            var localizedBooks = new List<LocalizedBook>();
            var localizedBook = new LocalizedBook
            {
                Id = 1,
                Title = "localizedBook",
                Authors = "author",
                DatePublished = DateTime.UtcNow,
                ISBN = "isbn",
                NumberOfPages = 300,
                Publisher = "publisher",
                CountryOfLocalization = "country",
                LocalPublisher = "localPublisher"
            };
            var localizedBook1 = new LocalizedBook
            {
                Id = 2,
                Title = "localizedBook1",
                Authors = "author1",
                DatePublished = DateTime.UtcNow,
                ISBN = "isbn1",
                NumberOfPages = 301,
                Publisher = "publisher1",
                CountryOfLocalization = "country1",
                LocalPublisher = "localPublisher1"
            };

            localizedBooks.Add(localizedBook);
            localizedBooks.Add(localizedBook1);

            return localizedBooks;
        }

        static IEnumerable<Magazine> GetMagazines()
        {
            var magazines = new List<Magazine>();
            var magazine = new Magazine
            {
                Id = 1,
                Title = "magazine",
                DatePublished = DateTime.UtcNow,
                Publisher = "publisher",
                ReleaseNumber = 1
            };
            var magazine1 = new Magazine
            {
                Id = 2,
                Title = "magazine1",
                DatePublished = DateTime.UtcNow,
                Publisher = "publisher1",
                ReleaseNumber = 2
            };

            magazines.Add(magazine);
            magazines.Add(magazine1);

            return magazines;
        }

        static void PrintBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{nameof(Book)} {book.Title}");
            }
        }

        static void PrintPatents(IEnumerable<Patent> patents)
        {
            foreach (var patent in patents)
            {
                Console.WriteLine($"{nameof(Patent)} {patent.Title}");
            }
        }

        static void PrintLocalizedBooks(IEnumerable<LocalizedBook> localizedBooks)
        {
            foreach (var localizedBook in localizedBooks)
            {
                Console.WriteLine($"{nameof(LocalizedBook)} {localizedBook.Title}");
            }
        }

        static void PrintMagazines(IEnumerable<Magazine> magazines)
        {
            foreach (var magazine in magazines)
            {
                Console.WriteLine($"{nameof(Magazine)} {magazine.Title}");
            }
        }
    }
}
