using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[ApiController]
[Route("BS/[action]")]
[EndpointGroupName("Default")]
public class BackstageController : ControllerBase
{
    public ActionResult Index()
    {
        return Ok("ok");
    }
}
