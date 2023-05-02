using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.DTOS;
using Movies.Entities.Movies;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly MoviesDbContext _moviesDbContext;

        public GenresController(MoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Genre genre)
        {
            var status = _moviesDbContext.Entry(genre).State;
            _moviesDbContext.Add(genre);
            var status1 = _moviesDbContext.Entry(genre).State;
            await _moviesDbContext.SaveChangesAsync();
            var status2= _moviesDbContext.Entry(genre).State;
            genre.Name = "UpdatedName";
            var status3= _moviesDbContext.Entry(genre).State;

            return Ok();
        }
    }
}
