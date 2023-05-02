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
    public class MoviesController : ControllerBase
    {
        private readonly MoviesDbContext _movieContext;
        private readonly IMapper _mapper;

        public MoviesController(MoviesDbContext movieContext, IMapper mapper)
        {
            _movieContext = movieContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<MovieListItemResponseDTO>>> GetAll()
        {
            var movies = await _movieContext.Movies.ProjectTo<MovieListItemResponseDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieRespDTO>> GetAll(int id)
        {
            var movieDB = await _movieContext.Movies
                .Include( m => m.Genres)
                .Include( m => m.MoviesActors)
                    .ThenInclude(ma => ma.Actor)
                .Include ( m => m.MovieRooms)
                    .ThenInclude(mr => mr.MovieTheater)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movieDB == default)
                return NotFound();

            var movie = _mapper.Map<MovieRespDTO>(movieDB);
            movie.MovieTheaters = movie.MovieTheaters.DistinctBy(mt => mt.Id).ToHashSet();

            return Ok(movie);
        }

        [HttpGet("{id}/useProjectTo")]
        public async Task<ActionResult<MovieRespDTO>> GetAllProjectTo(int id)
        {
            var movieDB = await _movieContext.Movies.ProjectTo<MovieRespDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
            movieDB.MovieTheaters = movieDB.MovieTheaters.DistinctBy(mt => mt.Id).ToHashSet();

            return Ok(movieDB);
        }

        [HttpGet("{id}/useSelect")]
        public async Task<ActionResult<MovieRespDTO>> GetAllSelect(int id)
        {
            var movieDB = await _movieContext.Movies.ProjectTo<MovieRespDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
            movieDB.MovieTheaters = movieDB.MovieTheaters.DistinctBy(mt => mt.Id).ToHashSet();

            return Ok(movieDB);
        }

        [HttpGet("groupByOnBillboard")]
        public async Task<ActionResult<object>> GetByOnBillboard()
        {
            var moviesGroupedByOnBillboard = await _movieContext.Movies.GroupBy(m => m.OnBillboard == true)
                .Select( m => new
                {
                    OnBillBoard = m.Key,
                    Qty = m.Count(),
                    Movies = m.ToList()
                })
                .ToListAsync();

            return Ok(moviesGroupedByOnBillboard);
        }
    }
}
