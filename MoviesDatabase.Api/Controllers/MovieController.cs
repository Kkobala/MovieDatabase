using Microsoft.AspNetCore.Mvc;
using MovieDatabase.App.Models.Requests;
using MovieDatabase.App.Repositories;

namespace MoviesDatabase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        private const int pagemaxsize = 100;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpPost("add-movie")]
        public async Task<IActionResult> AddMovies(AddMovieRequest request)
        {
            var movie = await _movieRepository.AddMovieAsync(request);
            return Ok(movie);
        }

        [HttpGet("get-movie")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);

            return Ok(movie);
        }

        [HttpPost("search-movie")]
        public async Task<IActionResult> SearchMovie(SearchMovieRequest request)
        {
            if (request.PageSize > 100)
            {
                return BadRequest("Page size exceed its limit");
            }

            var searchedMovie = await _movieRepository.SearchMovieAsync(request);

            return Ok(searchedMovie);
        }

        [HttpPost("update-movie")]
        public async Task<IActionResult> UpdateMovie(UpdateMoviesRequest request)
        {
            var updatedMovie = await _movieRepository.UpdateMovieAsync(request);
            return Ok(updatedMovie);
        }

        [HttpDelete("delete-movie")]
        public async Task<IActionResult> DeleteMovie(DeleteMovieRequest request)
        {
            await _movieRepository.RemoveMovieAsync(request);
            return Ok("Succesfully deleted movie");
        }
    }
}
