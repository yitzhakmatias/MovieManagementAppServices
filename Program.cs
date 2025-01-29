using Microsoft.EntityFrameworkCore;
using MovieManagementAppServices.Core.Interfaces;
using MovieManagementAppServices.Data.MovieManagementApp.Data;
using MovieManagementAppServices.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MovieDb")); // Use an in-memory database

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IMovieRatingRepository, MovieRatingRepository>();
builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Movie Management API",
        Version = "v1",
        Description = "API for managing movies, actors, and movie ratings.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com"
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Management API v1");
        c.RoutePrefix = string.Empty;  // Set Swagger UI at the root of the app
    });
}

// Use CORS middleware
app.UseCors("AllowReactApp");  // Apply CORS policy

app.UseAuthorization();

app.MapControllers();

app.Run();