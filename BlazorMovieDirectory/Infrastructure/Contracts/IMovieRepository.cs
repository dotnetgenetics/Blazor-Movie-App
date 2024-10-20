using BlazorMovieDirectory.Domain;

namespace BlazorMovieDirectory.Infrastructure.Contracts
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<List<string>> GetGenres();
        Task<Movie> GetMovieById(int id);
        Task AddMovie(Movie movie);
        Task<Movie> UpdateMovie(Movie movie);
        Task DeleteMovie(int id);
    }
}
