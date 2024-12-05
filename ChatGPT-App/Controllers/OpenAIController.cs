using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;

namespace ChatGPT_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        [HttpGet]
        [Route("UseChatGPT")]
        public async Task<IActionResult> UseChatGPT(string query)
        {
            string outputResult = "";

            ChatClient client = new(model: "gpt-4o-mini", apiKey: "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");

            var chatCompletion = client.CompleteChat("Say 'this is a test.'").Value.Content;

            foreach (var chat in chatCompletion)
            {
                outputResult += chat.Text;
            }

            return Ok(outputResult);

        }
    }
}
