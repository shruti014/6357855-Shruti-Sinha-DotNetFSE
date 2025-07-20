using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IProducerService _producer;

    public ChatController(IProducerService producer)
    {
        _producer = producer;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] ChatMessageDto chatDto)
    {
        var message = new ChatMessage
        {
            User = chatDto.User,
            Message = chatDto.Message
        };

        await _producer.SendMessageAsync(message);
        return Ok("Message sent!");
    }
}