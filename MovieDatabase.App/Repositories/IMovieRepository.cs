using MovieDatabase.App.Db.Entities;
using MovieDatabase.App.Models.Requests;

namespace MovieDatabase.App.Repositories
{
    public interface IMovieRepository
    {
        Task<MovieEntity> AddMovieAsync(AddMovieRequest request);
        Task<MovieEntity> GetMovieByIdAsync(int id);
        Task<List<MovieEntity>> SearchMovieAsync(SearchMovieRequest request);
        Task<MovieEntity> UpdateMovieAsync(UpdateMoviesRequest request);
        Task RemoveMovieAsync(DeleteMovieRequest request);
    }
}
