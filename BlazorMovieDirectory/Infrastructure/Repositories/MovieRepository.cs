using BlazorMovieDirectory.Data;
using BlazorMovieDirectory.Domain;
using BlazorMovieDirectory.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BlazorMovieDirectory.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MvcMovieContext _movieContext;

        public MovieRepository(IDbContextFactory<MvcMovieContext> DbFactory)
        {
            _movieContext = DbFactory.CreateDbContext();
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _movieContext.Movie.ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _movieContext.Movie.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<string>> GetGenres()
        {
            List<string> lstGenre = new List<string>();

            lstGenre = _movieContext.Movie.Select(x => x.Genre).Distinct().ToList();
            lstGenre.Insert(0, string.Empty);
            return Task.Run(() => lstGenre);
        }

        public async Task AddMovie(Movie movie)
        {
            await _movieContext.Movie.AddAsync(movie);
            await _movieContext.SaveChangesAsync();
        }

        public async Task DeleteMovie(int id)
        {
            var movie = await _movieContext.Movie.FirstOrDefaultAsync(e => e.Id == id);
            if (movie == null)
                return;

            _movieContext.Movie.Remove(movie);
            await _movieContext.SaveChangesAsync();
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var movieToUpdate = await _movieContext.Movie.FirstOrDefaultAsync(x => x.Id == movie.Id);

            if (movieToUpdate != null)
            {
                movieToUpdate.Id = movie.Id;
                movieToUpdate.Title = movie.Title;
                movieToUpdate.Price = movie.Price;
                movieToUpdate.Rating = movie.Rating;
                movieToUpdate.Genre = movie.Genre;
                movieToUpdate.ReleaseDate = movie.ReleaseDate;

                await _movieContext.SaveChangesAsync();
                return movieToUpdate;
            }

            return null;
        }
    }
}
