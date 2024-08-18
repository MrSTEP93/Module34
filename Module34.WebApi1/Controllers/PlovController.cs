using Microsoft.AspNetCore.Mvc;

namespace Module34.WebApi1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlovController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "it's a plov!!!";
        }
    }
}
