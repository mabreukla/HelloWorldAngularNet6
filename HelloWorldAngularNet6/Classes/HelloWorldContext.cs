using HelloWorldAngularNet6.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldAngularNet6.Classes
{
    public class HelloWorldContext : DbContext
    {
        // Angular tutorial object
        public DbSet<Hero> Heroes { get; set; }

        public HelloWorldContext(DbContextOptions<HelloWorldContext> options) : base(options)
        {
        }
    }
}