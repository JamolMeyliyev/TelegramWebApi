using MongoDB.Bson.Serialization.Attributes;

namespace TelegramWebApi.Models
{
    public class QuestionModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public List<string> Choises { get; set; }
        public int CorrectAnswerId { get; set; }
    }
}
