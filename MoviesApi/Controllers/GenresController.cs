using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.DTOS;
using Movies.Entities.Movies;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly MoviesDbContext _moviesDbContext;
        private readonly IMapper _mapper;

        public GenresController(MoviesDbContext moviesDbContext, IMapper mapper)
        {
            _moviesDbContext = moviesDbContext;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()=> Ok(await _moviesDbContext.Genres.ProjectTo<GenreRespDTO>(_mapper.ConfigurationProvider).ToListAsync());

        [HttpPost]
        public async Task<ActionResult> Create(GenreRequestDTO genreDTO)
        {
            var genre = _mapper.Map<Genre>(genreDTO);

            _moviesDbContext.Add(genre);
            await _moviesDbContext.SaveChangesAsync();

            return StatusCode(201);
        }

        [HttpPost("TrackingCreate")]
        public async Task<ActionResult> CreateWithTracking(Genre genre)
        {
            var status = _moviesDbContext.Entry(genre).State;
            _moviesDbContext.Add(genre);
            var status1 = _moviesDbContext.Entry(genre).State;
            await _moviesDbContext.SaveChangesAsync();
            var status2= _moviesDbContext.Entry(genre).State;
            genre.Name = "UpdatedName";
            var status3= _moviesDbContext.Entry(genre).State;

            return StatusCode(201);
        }
    }
}
