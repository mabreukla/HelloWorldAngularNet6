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
        public DbSet<Hero> Heroes { get; set; }

        public HelloWorldContext(DbContextOptions<HelloWorldContext> options) : base(options)
        {
        }
    }
}