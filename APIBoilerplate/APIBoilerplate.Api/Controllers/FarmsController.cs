using Microsoft.AspNetCore.Mvc;

namespace APIBoilerplate.Api.Controllers
{
    [Route("[controller]")]
    public class FarmsController: ApiController
    {
        [HttpGet]
        public IActionResult ListFarms()
        {
            return Ok(Array.Empty<string>());
        }
    }
}