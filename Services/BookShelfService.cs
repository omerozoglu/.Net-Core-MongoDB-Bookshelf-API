using System.Collections.Generic;
using BookShelf.Models;
using MongoDB.Driver;

namespace BookShelf.Services
{
    public class BookShelfService
    {
        private readonly IMongoCollection<BookShelfm> _bookShelf;

        public BookShelfService(IBookShelfDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _bookShelf = database.GetCollection<BookShelfm>(settings.BookShelfCollectionName);
        }
        public IEnumerable<BookShelfm> Get() =>
                   _bookShelf.Find(bookShlf => true).ToList();

        public BookShelfm Get(string id) =>
            _bookShelf.Find<BookShelfm>(bookShlf => bookShlf.ID == id).FirstOrDefault();

        public BookShelfm Create(BookShelfm bookShlf)
        {
            _bookShelf.InsertOne(bookShlf);
            return bookShlf;
        }

        public void Update(string id, BookShelfm bookShlfIn) =>
            _bookShelf.ReplaceOne(bookShlf => bookShlf.ID == id, bookShlfIn);

        public void Remove(BookShelfm bookShlfIn) =>
            _bookShelf.DeleteOne(bookShlf => bookShlf.ID == bookShlfIn.ID);

        public void Remove(string id) =>
            _bookShelf.DeleteOne(bookShlf => bookShlf.ID == id);
    }
}