using asb_tools.Classes;
using Microsoft.AspNetCore.Mvc;

namespace demo_api_asb_queue.Controllers;

[ApiController]
[Route("messages")]
public class SendMessageController : ControllerBase
{
    private ASBService _asbService;
    public SendMessageController(ASBService asbService)
    {
        _asbService = asbService;
    }
    [HttpPost]
    public IActionResult Post([FromForm]string message)
    {
        _asbService.SendStringMessage(message);
        return Ok();
    }
}