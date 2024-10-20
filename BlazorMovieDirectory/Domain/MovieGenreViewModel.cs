namespace BlazorMovieDirectory.Domain
{
    public class MovieGenreViewModel
    {
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<string> Genres { get; set; } = new List<string>();
        public string MovieGenre { get; set; } = string.Empty;
        public Movie Movie { get; set; } = new Movie();
        public string SearchString { get; set; } = string.Empty;
    }
}
