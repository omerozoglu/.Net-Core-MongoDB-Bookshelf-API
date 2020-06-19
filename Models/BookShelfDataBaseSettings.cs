namespace BookShelf.Models
{
    public class BookShelfDataBaseSettings : IBookShelfDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string BookShelfCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IBookShelfDatabaseSettings
    {
        string BooksCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string BookShelfCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}