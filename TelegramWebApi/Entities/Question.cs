using MongoDB.Bson.Serialization.Attributes;

namespace TelegramWebApi.Entities
{
    public class Question
    {
        [BsonId]
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public List<string> Choices { get; set; }
        public int CorrectAnswerId { get; set; }
    }
}
