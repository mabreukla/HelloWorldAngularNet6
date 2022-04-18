using HelloWorldAngularNet6.Classes;
using HelloWorldAngularNet6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAngularNet6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<string> returnValue = new List<string>() { "Deleting the first blog"};

            using (HelloWorldContext db = new HelloWorldContext())
            {
                Blog blog = new Blog();
                blog = db.Blogs.OrderBy(b => b.BlogId).FirstOrDefault();

                if (blog != null)
                {
                    db.Remove(blog);
                    db.SaveChanges();
                    returnValue.Add("Successfully removed the first blog.");
                }
                else
                {
                    returnValue.Add("Unable to remove the first blog.");
                }

                return Ok(returnValue);
            }
        }
    }
}
