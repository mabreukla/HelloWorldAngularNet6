using HelloWorldAngularNet6.Classes;
using HelloWorldAngularNet6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAngularNet6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReadController : ControllerBase
    {
        // Fields
        private HelloWorldContext _db;

        // Ctor
        public ReadController(HelloWorldContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<string> returnValue = new List<string>() { "Querying for a blog" };
            List<Blog> blogs = new List<Blog>();

            blogs = _db.Blogs
                .OrderBy(b => b.BlogId)
                .ToList();

            foreach (Blog blog in blogs)
            {
                returnValue.Add(blog.Url);
            }

            return Ok(blogs);
        }
    }
}
