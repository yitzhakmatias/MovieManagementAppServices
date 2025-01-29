namespace MovieManagementAppServices.Core.Entities
{
    public class MovieRating
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Reviewer { get; set; }
        public Movie Movie { get; set; }
    }

}
