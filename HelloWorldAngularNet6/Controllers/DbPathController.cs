using HelloWorldAngularNet6.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAngularNet6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DbPathController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (var db = new HelloWorldContext())
            {
                string returnValue = String.Format("Database path: {0}.", db.DbPath);

                return Ok(returnValue);
            }
        }
    }
}
