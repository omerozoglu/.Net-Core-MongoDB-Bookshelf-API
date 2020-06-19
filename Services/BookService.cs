using System.Collections.Generic;
using BookShelf.Models;
using MongoDB.Driver;

namespace BookShelf.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IBookShelfDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }
        public List<Book> Get() =>
                   _books.Find(book => true).ToList();

        public Book Get(string id) =>
            _books.Find<Book>(book => book.ID == id).FirstOrDefault();

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Book bookIn) =>
            _books.ReplaceOne(book => book.ID == id, bookIn);

        public void Remove(Book bookIn) =>
            _books.DeleteOne(book => book.ID == bookIn.ID);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.ID == id);
    }
}