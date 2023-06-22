using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelegramWebApi.Managers;
using TelegramWebApi.Models;

namespace TelegramWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionManager _questionManager;

        public QuestionController(QuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            return Ok(await _questionManager.GetQuestions());
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddQuestion(CreateQuestionModel model)
        {
            if(!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
           return Ok(await _questionManager.AddQuestion(model));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateQuestion(Guid id,UpdateQuestionModel model)
        {
            if(!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            return Ok( await _questionManager.UpdateQuestionAsync(id, model));
        }
    }
}
