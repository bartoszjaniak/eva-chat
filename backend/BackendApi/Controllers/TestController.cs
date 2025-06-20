using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("")]
public class ChatController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("Hello from controller!");
}
