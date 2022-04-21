using HelloWorldAngularNet6.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldAngularNet6.Classes
{
    public class HelloWorldContext : DbContext
    {
        // Tables
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Universe> Universes { get; set; }

        public HelloWorldContext(DbContextOptions<HelloWorldContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}