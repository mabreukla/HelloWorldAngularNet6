using HelloWorldAngularNet6.Classes;
using HelloWorldAngularNet6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAngularNet6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        // Fields
        private HelloWorldContext _db;

        // Ctor
        public UpdateController(HelloWorldContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<string> returnValue = new List<string>() { "Updating the blog and adding a post" };

            Blog blog = _db.Blogs.OrderBy(b => b.BlogId).First();
            blog.Url = String.Format("https://devblogs.microsoft.com/dotnet{0:mm-dd-yyyy}", DateTime.Now);
            blog.Posts.Add(
                new Post {
                    Title = "Hello World!!",
                    Content = "I wrote an app using EF Core!"
                });
            _db.SaveChanges();

            returnValue.Add(String.Format("Blog {0} has been updated.", blog.BlogId));

            return Ok(returnValue);
        }
    }
}
