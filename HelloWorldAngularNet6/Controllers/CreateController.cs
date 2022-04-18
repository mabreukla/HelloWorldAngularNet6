using HelloWorldAngularNet6.Classes;
using HelloWorldAngularNet6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAngularNet6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CreateController : ControllerBase
    {
        [HttpGet]
        public IActionResult Create()
        {
            using (var db = new BloggingContext())
            {
                List<string> returnValue = new List<string>() { "Inserting a new blog" };
                db.Add(new Blog { Url = String.Format("http://blogs.msdn.com/adonet/{0:mm-dd-yyyy}", DateTime.Now) });
                
                db.SaveChanges();
                
                returnValue.Add("Finished adding a new blog");

                return Ok(returnValue);
            }
        }
    }
}
