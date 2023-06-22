namespace TelegramWebApi.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
       
    }

    public class UserResult
    {
        public int CorrectAnswerCount { get; set; }
        public int InCorrectAnswerCount { get; set; }
    }
}
