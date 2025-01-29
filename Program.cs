using Microsoft.EntityFrameworkCore;
using MovieManagementAppServices.Core.Interfaces;
using MovieManagementAppServices.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("MovieDb"));
//builder.Services.AddScoped<IMovieRepository, MovieRepository>();
//builder.Services.AddScoped<IActorRepository, ActorRepository>();
//builder.Services.AddScoped<IMovieRatingRepository, MovieRatingRepository>();
builder.Services.AddControllers();

// Ensure API explorer is added for Swagger to work
builder.Services.AddEndpointsApiExplorer();  // This is crucial for Swagger to generate API documentation

// Add Swagger generation
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

// Enable Swagger middleware in Development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // This generates the Swagger JSON
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Management API v1");
        c.RoutePrefix = string.Empty;  // Set Swagger UI at the root of the app
    });
}

// Use CORS middleware (make sure it's properly configured if needed)
app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
