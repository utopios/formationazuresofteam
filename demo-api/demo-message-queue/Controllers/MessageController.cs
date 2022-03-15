using demo_message_queue.Services;
using Microsoft.AspNetCore.Mvc;

namespace demo_message_queue.Controllers;

[ApiController]
[Route("/message")]
public class MessageController : ControllerBase
{
    private MessageQueueService _messageQueueService;

    public MessageController(MessageQueueService messageQueueService)
    {
        _messageQueueService = messageQueueService;
    }
    [HttpPost]
    public IActionResult Post([FromForm] string message, [FromForm] string nameQueue)
    {
        return Ok(new { result = _messageQueueService.SendMessage(nameQueue, message)});
    }
}