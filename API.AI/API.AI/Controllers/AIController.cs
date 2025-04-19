using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace SeuProjeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IAController : ControllerBase
    {
        private readonly Kernel _kernel;
        private readonly IChatCompletionService _chat;

        public IAController(Kernel kernel)
        {
            _kernel = kernel;
            _chat = _kernel.GetRequiredService<IChatCompletionService>();
        }

        [HttpGet("ask")]
        public async Task<IActionResult> Ask([FromQuery] string question)
        {
            if (string.IsNullOrWhiteSpace(question))
                return BadRequest("A pergunta não pode ser vazia.");

            // Cria histórico e adiciona pergunta
            var history = new ChatHistory();
            history.AddUserMessage(question);

            // Executa a IA
            var result = await _chat.GetChatMessageContentAsync(
                history,
                executionSettings: new OpenAIPromptExecutionSettings
                {
                    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
                },
                kernel: _kernel
            );

            return Ok(result?.Content ?? "Sem resposta.");
        }
    }
}
