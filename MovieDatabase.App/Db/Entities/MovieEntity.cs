using MovieDatabase.App.Models;

namespace MovieDatabase.App.Db.Entities
{
    public class MovieEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public MovieStatus Status { get; set; }
        public DateTime ReleaseYear { get; set; }
    }
}
