namespace MovieManagementAppServices.Data
{
    using Microsoft.EntityFrameworkCore;
    using MovieManagementApp.Core.Entities; // Assuming your entities are in the Core.Entities namespace

    namespace MovieManagementApp.Data
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            // Define DbSet properties for each entity type you want to store in the database
            public DbSet<Movie> Movies { get; set; }
            public DbSet<Actor> Actors { get; set; }
            public DbSet<MovieRating> MovieRatings { get; set; }

            // Configure relationships or additional configurations if needed
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // You can add additional configurations here if necessary (e.g., table names, constraints)
            }
        }
    }

}
