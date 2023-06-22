using MongoDB.Driver;
using TelegramWebApi.Entities;

namespace TelegramWebApi.Services
{
    public class DataService
    {
        public IMongoCollection<User> _userCollection { get; set; }
        public IMongoCollection<Question> _questionCollection { get; set; }

        public DataService() 
        {
            var client = new MongoClient("mongodb://username:password@localhost:27000");
            var db = client.GetDatabase("question_db");
            _questionCollection = db.GetCollection<Question>("questions");
            _userCollection = db.GetCollection<User>("users");
        }

    }
}
