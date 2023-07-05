using Microsoft.EntityFrameworkCore;
using MovieDatabase.App.Db;
using MovieDatabase.App.Db.Entities;
using MovieDatabase.App.Models.Requests;

namespace MovieDatabase.App.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _db;

        public MovieRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<MovieEntity> AddMovieAsync(AddMovieRequest request)
        {
            var movie = new MovieEntity()
            {
                Title = request.Title,
                Description = request.Description,
                Director = request.Director,
                ReleaseYear = request.ReleaseYear
            };

            await _db.AddAsync(movie);
            await _db.SaveChangesAsync();

            return movie;
        }

        public async Task<MovieEntity> GetMovieByIdAsync(int id)
        {
            var movie = await _db.Movies.FirstOrDefaultAsync(x => x.Id == id);

            return movie!;
        }

        public async Task<List<MovieEntity>> SearchMovieAsync(SearchMovieRequest request)
        {
            var movies = _db.Movies
           .Skip(request.PageSize * request.PageIndex)
           .Take(request.PageSize)
           .AsQueryable();

            return await movies
            .Select(m => new MovieEntity()
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Status = m.Status,
                ReleaseYear = m.ReleaseYear
            }
            ).ToListAsync();
        }

        public async Task<MovieEntity> UpdateMovieAsync(UpdateMoviesRequest request)
        {
            var updatedMovie = await _db.Movies.FirstOrDefaultAsync(m => m.Id == request.Id);

            if (updatedMovie == null)
            {
                throw new ArgumentException("Can't find a movie");
            }

            updatedMovie.Title = request.Title;
            updatedMovie.Description = request.Description;
            updatedMovie.Director = request.Director;
            updatedMovie.ReleaseYear = request.ReleaseYear;

            _db.Movies.Update(updatedMovie);
            await _db.SaveChangesAsync();

            return updatedMovie;
        }

        public async Task RemoveMovieAsync(DeleteMovieRequest request)
        {
            var movie = await _db.Movies.FirstOrDefaultAsync(m => m.Id == request.Id);

            if (movie == null)
            {
                throw new ArgumentException("Can't find a movie");
            }

            movie.Status = Models.MovieStatus.Deleted;

            _db.Movies.Update(movie);
            await _db.SaveChangesAsync();
        }
    }
}
