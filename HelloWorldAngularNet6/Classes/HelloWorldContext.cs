using HelloWorldAngularNet6.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldAngularNet6.Classes
{
    public class HelloWorldContext : DbContext
    {
        // Tables
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Universe> Universes { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
                .HasOne(h => h.Universe)
                .WithMany()
                .HasForeignKey(h => h.UniverseId);
        }
        #endregion

        public HelloWorldContext(DbContextOptions<HelloWorldContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}