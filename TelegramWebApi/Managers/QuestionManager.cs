using MongoDB.Driver;
using TelegramWebApi.Entities;
using TelegramWebApi.Models;
using TelegramWebApi.Repisotories;

namespace TelegramWebApi.Managers
{
    public class QuestionManager
    {
        private readonly IQuestionRepository _question;

        public QuestionManager(IQuestionRepository question)
        {
                _question = question;
        }

        public async Task<List<Question>> GetQuestions()
        {
            return await _question.GetQuestions();
        }

        public async Task<QuestionModel> AddQuestion(CreateQuestionModel model)
        {
            var question = new Question()
            {
              QuestionText = model.QuestionText,
              CorrectAnswerId = model.CorrectAnswerId,
              Choices = model.Choices
        };
            await _question.AddQuestion(question!);
            return ToQuestionModel(question);

        }
        public async Task<QuestionModel> UpdateQuestionAsync(Guid questionId, UpdateQuestionModel model)
        {
            var question = await _question.GetQuestionById(questionId);

            if (question is null)
                throw new Exception("Question not found!");

            question.QuestionText = model.QuestionText ?? question.QuestionText;
            question.CorrectAnswerId = model.CorrectAnswerId;
            question.Choices = model.Choices;


            var question1=  await _question.UpdateQuestion(questionId, question);
            return ToQuestionModel(question1);

            
        }

        

        public QuestionModel ToQuestionModel(Question question)
        {
            var questionModel = new QuestionModel()
            {   Id = question.Id,
                QuestionText = question.QuestionText,
                Choises = question.Choices,
                CorrectAnswerId = question.CorrectAnswerId
            };
            return questionModel;

        }

    }
}
