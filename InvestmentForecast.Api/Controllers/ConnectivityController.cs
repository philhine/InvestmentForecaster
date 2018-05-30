using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentForecast.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class ConnectivityController : Controller
    {
        // GET api/connectivity
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Service working as expected");
        }
    }
}
