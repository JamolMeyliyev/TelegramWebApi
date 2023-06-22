using MongoDB.Driver;
using TelegramWebApi.Entities;
using TelegramWebApi.Models;

namespace TelegramWebApi.Repisotories
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<bool> Login(LoginUserModel loginUserModel);

        Task<User> CheckName(LoginUserModel model);
        Task<User> CheckPassword(LoginUserModel model);
        Task<List<User>> GetUsers();
        


    }

    public class UserRepository
    {
        private readonly IMongoCollection<User> _userCollection;
        public UserRepository()
        {
            var client = new MongoClient("mongodb://username:password@localhost:27000");
            var db = client.GetDatabase("question_user_db");
            _userCollection = db.GetCollection<User>("users");

        }

        public async Task<List<User>> GetUsers()
        {
            return await( await _userCollection.FindAsync(_ => true)).ToListAsync();
        }
        public async Task AddUser(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }
        public async Task<bool> Login(LoginUserModel loginModel)
        {
            var filter1 = Builders<User>.Filter.Eq(c => c.Name, loginModel.Name );
            
            var filter2 = Builders<User>.Filter.Eq(c => c.Password, loginModel.Password);
            var user1 = await _userCollection.Find(filter1).FirstOrDefaultAsync();
            var user2 = await _userCollection.Find(filter2).FirstOrDefaultAsync();
            return (user1.Id == user2.Id || user1!=null);

        }


    }
}
