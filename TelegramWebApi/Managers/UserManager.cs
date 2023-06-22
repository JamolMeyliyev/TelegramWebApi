using TelegramWebApi.Entities;
using TelegramWebApi.Models;
using TelegramWebApi.Provider;
using TelegramWebApi.Repisotories;

namespace TelegramWebApi.Managers
{
    public class UserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly UserProvider _userProvider;

        public UserManager(IUserRepository userRepository, UserProvider userProvider)
        {
            _userRepository = userRepository;
            _userProvider = userProvider;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<UserModel> AddUser(CreateUserModel model)
        {
            var user = new User
            {
                Name= model.Name,
                Password= model.Password,
            };
            await _userRepository.AddUser(user!);
            return  ToUserModel(user);

        }
        public async Task<UserModel> Login(LoginUserModel model)
        {
            var result = await _userRepository.Login(model);
            if (!result)
            {
                throw new Exception("Name or Password is Incorrect");
            }
            return new UserModel { Name = model.Name, Password = model.Password };
        }

        public  UserModel ToUserModel(User user)
        {
            var userModel = new UserModel()
            {
                Name = user.Name,
                Password = user.Password,
            };
            return userModel;
        }
    }
}
