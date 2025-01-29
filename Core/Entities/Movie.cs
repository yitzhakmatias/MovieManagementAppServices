namespace MovieManagementAppServices.Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Actor> Actors { get; set; } = new List<Actor>();
        public List<MovieRating> Ratings { get; set; } = new List<MovieRating>();
    }

}
