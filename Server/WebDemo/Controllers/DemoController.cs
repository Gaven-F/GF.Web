using Microsoft.AspNetCore.Mvc;

namespace WebDemo.Controllers
{
    [Route("[controller]/[action]")]
    public class DemoController : ControllerBase
    {
        public ActionResult<string> Index()
        {
            return Ok("Hello");
        }
    }
}
