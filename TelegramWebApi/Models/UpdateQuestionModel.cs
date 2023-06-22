namespace TelegramWebApi.Models
{
    public class UpdateQuestionModel
    {
        public string QuestionText { get; set; }
        public List<string> Choices { get; set; }
        public int CorrectAnswerId { get; set; }
    }
}
