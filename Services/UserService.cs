using System.Collections.Generic;
using BookShelf.Models;
using MongoDB.Driver;

namespace BookShelf.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;
        public UserService(IBookShelfDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }
        public IEnumerable<User> Get() =>
                 _users.Find(user => true).ToList();

        public User Get(string id) =>
            _users.Find<User>(user => user.ID == id).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            _users.ReplaceOne(user => user.ID == id, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(user => user.ID == userIn.ID);

        public void Remove(string id) =>
            _users.DeleteOne(user => user.ID == id);
    }
}