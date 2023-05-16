using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.DTOS;
using Movies.Entities.Movies;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieTheaterController : ControllerBase
    {
        private readonly MoviesDbContext _moviesContext;
        private readonly IMapper _mapper;

        public MovieTheaterController(MoviesDbContext moviesContext ,IMapper mapper)
        {
            _moviesContext = moviesContext;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Create(MovieTheaterRequestDTO movieTheaterRequest)
        {
            var movieTheater = _mapper.Map<MovieTheater>(movieTheaterRequest);
            await _moviesContext.AddAsync(movieTheater);

            await _moviesContext.SaveChangesAsync();

            return StatusCode(201);
        }
    }
}
