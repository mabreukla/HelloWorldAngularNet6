using HelloWorldAngularNet6.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldAngularNet6.Classes
{
    public class HelloWorldContext : DbContext
    {
        // Tables
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Universe> Universes { get; set; }

        /// <summary>
        /// Fluent API code changes
        /// </summary>
        /// <param name="modelBuilder"></param>
        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
                .HasOne(h => h.Universe)
                .WithMany()
                .HasForeignKey(h => h.UniverseId);
        }
        #endregion

        /// <summary>
        /// Setting options for the hello world context
        /// </summary>
        /// <param name="options"></param>
        public HelloWorldContext(DbContextOptions<HelloWorldContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}