using MovieManagementAppServices.Core.Entities;

namespace MovieManagementAppServices.Core.Interfaces
{
    public interface IMovieRatingRepository
    {
        Task<List<MovieRating>> GetRatingsByMovieId(int movieId);
        Task AddRating(MovieRating rating);
    }
}
