namespace MovieDatabase.App.Models.Requests
{
    public class UpdateMoviesRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseYear { get; set; }
    }
}
