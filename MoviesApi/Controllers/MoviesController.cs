using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        [HttpGet("useQueryable")]
        public async Task<ActionResult<MovieListItemResponseDTO>> GetAllUseQueryable([FromQuery] MovieFilterDTO movieFilterDTO)
        {
            var moviesQuery = _movieContext.Movies.AsQueryable();

            if (!movieFilterDTO.Title.IsNullOrEmpty())
                moviesQuery = moviesQuery.Where(m => m.Title.Contains(movieFilterDTO.Title));

            if (movieFilterDTO.OnBillBoard != null)
                moviesQuery = moviesQuery.Where(m => m.OnBillboard  == movieFilterDTO.OnBillBoard);

            var moviesDB = await moviesQuery.Include(m => m.Genres).ToListAsync();

            var movies = _mapper.Map<List<MovieListItemResponseDTO>>(moviesDB);

            return Ok(movies);
        }


        [HttpPost]
        public async Task<IActionResult> Create(MovieDataRequestDTO movieDataRequestDTO)
        {
            var movie = _mapper.Map<Movie>(movieDataRequestDTO);

            movie.Genres.ForEach(genre => _movieContext.Entry(genre).State = EntityState.Unchanged);
            movie.MovieRooms.ForEach(movieroom => _movieContext.Entry(movieroom).State = EntityState.Unchanged);

            _movieContext.Add(movie);
            await _movieContext.SaveChangesAsync();

            return StatusCode(201);

        }
    }
}
