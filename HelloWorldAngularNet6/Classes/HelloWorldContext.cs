using System;
using System.Collections.Generic;
using HelloWorldAngularNet6.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace HelloWorldAngularNet6.Classes
{
    public class HelloWorldContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        private string _connectionString = "";

        public HelloWorldContext()
        {
            _connectionString = "Data Source=127.0.0.1,1433;User ID=sa;Password=36x87#aj@84=4}j8;";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite($"Data Source={DbPath}");
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString);
        }
    }
}