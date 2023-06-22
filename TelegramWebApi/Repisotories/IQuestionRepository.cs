using MongoDB.Driver;
using TelegramWebApi.Entities;

namespace TelegramWebApi.Repisotories
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetQuestions();
        Task AddQuestion(Question question);
        Task<Question> GetQuestionById(Guid id);

        Task<Question> UpdateQuestion(Guid questionId,Question question);
       


    }
    public class QuestionRepository 
    {
        private readonly IMongoCollection<Question> _questionCollection;
        public QuestionRepository() 
        {
            var client = new MongoClient("mongodb://username:password@localhost:27000");
            var db = client.GetDatabase("question_user_db");
            _questionCollection = db.GetCollection<Question>("questions");
            
        }
        public async Task<List<Question>> GetQuestions()
        {
            return await (await _questionCollection.FindAsync(_ => true)).ToListAsync();
        }
        public async Task AddQuestion(Question question)
        {
            await _questionCollection.InsertOneAsync(question);
        }

        public async Task<Question> GetQuestionById(Guid id)
        {
            return await (await _questionCollection.FindAsync(qs => qs.Id == id)).FirstOrDefaultAsync();
            


        }
        public async Task<Question> UpdateQuestion(Guid id,Question model)
        {
            var filter = Builders<Question>.Filter.Eq(i => i.Id, id);
             await _questionCollection.ReplaceOneAsync(filter, model);
            return await (await _questionCollection.FindAsync(qs => qs.Id == id)).FirstOrDefaultAsync();
        }


    }
}
