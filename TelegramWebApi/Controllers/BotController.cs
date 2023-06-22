using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {

        
    [HttpPost]
    public async Task GetUpdate([FromBody] Update update)
    {
        var bot = new TelegramBotClient("5992354516:AAEdcw3Fi2ahUfMkom3IoLPEbdoSDusApTs");

        if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
        {
	        await bot.SendTextMessageAsync(update.Message.From.Id, "Sizga har soatda savol junatilib turiladi");

				
			}

			
		}

		[HttpGet]
    public string GetMe() => "Working...";
    }
}
