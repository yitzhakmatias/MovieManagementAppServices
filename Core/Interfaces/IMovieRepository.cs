using MovieManagementAppServices.Core.Entities;

namespace MovieManagementAppServices.Core.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
        Task AddMovie(Movie movie);
        Task UpdateMovie(Movie movie);
        Task DeleteMovie(int id);
    }
}
