using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers;

[ApiController]
[Route("api/cmdsvc/[controller]")]
public class PlatformController : ControllerBase
{
    public PlatformController()
    {
        
    }

    public ActionResult InboundTest()
    {
        Console.WriteLine("CmdService/Platforms POST api Inbound Test succeeded");

        return Ok("CmdService/Platforms POST api Inbound Test succeeded");
    }
}