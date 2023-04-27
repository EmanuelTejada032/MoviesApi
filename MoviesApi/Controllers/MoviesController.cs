using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Entities.Movies;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesDbContext _movieContext;

        public MoviesController(MoviesDbContext movieContext)
        {
            _movieContext = movieContext;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Movie>>> GetAll()
        {
            var movies = await _movieContext.Movies.Include(movies => movies.Genres).ToListAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetAll(int id)
        {
            var movies = await _movieContext.Movies
                .Include( movie => movie.Genres)
                .Include(movie => movie.MovieRooms)
                .Include(movie => movie.MoviesActors)
                .FirstOrDefaultAsync(movie => movie.Id == id);
            return Ok(movies);
        }


    }
}
