using HelloWorldAngularNet6.Classes;
using HelloWorldAngularNet6.Repositories;
using HelloWorldAngularNet6.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IHeroesService, HeroesService>();

// Add repositories to the container
builder.Services.AddScoped<IHeroesRepository, HeroesRepository>();

// Add Contexts
builder.Services.AddDbContext<HelloWorldContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("crudAppDb"));
});

// Add the auto mapper to allow Dtos
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
