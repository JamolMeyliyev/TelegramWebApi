namespace TelegramWebApi.Models
{
    public class CreateQuestionModel
    {
        public string QuestionText { get; set; }
        public List<string> Choices { get; set; }
        public int CorrectAnswerId { get; set; }
    }
}
