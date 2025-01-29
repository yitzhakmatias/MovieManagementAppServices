using Microsoft.EntityFrameworkCore;
using MovieManagementAppServices.Core.Entities;
using MovieManagementAppServices.Core.Interfaces;
using MovieManagementAppServices.Data.MovieManagementApp.Data;
using System;

namespace MovieManagementAppServices.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllMovies() =>
            await _context.Movies.Include(m => m.Actors).Include(m => m.Ratings).ToListAsync();

        public async Task<Movie> GetMovieById(int id) =>
            await _context.Movies.Include(m => m.Actors).Include(m => m.Ratings)
                                 .FirstOrDefaultAsync(m => m.Id == id);

        public async Task AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovie(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovie(int id)
        {
            var movie = await GetMovieById(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }


}
