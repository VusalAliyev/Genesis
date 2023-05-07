using Microsoft.AspNetCore.Mvc;

namespace Genesis.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUser(string finCode)
        {


            return Ok();
        }
    }
}
