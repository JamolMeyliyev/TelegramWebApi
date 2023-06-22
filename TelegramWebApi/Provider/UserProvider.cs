using System.Security.Claims;

namespace TelegramWebApi.Provider
{
    public class UserProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        protected HttpContext? Context => _contextAccessor.HttpContext;

       
        public Guid UserId => Guid.Parse(Context.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
