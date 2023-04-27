using AutoMapper;
using Movies.DTOS;
using Movies.Entities.Movies;

namespace Movies.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Actor, ActorRespDTO>();

            CreateMap<MovieRoom, MovieRoomRespDTO>();

            CreateMap<MovieTheater, MovieTheaterRespDTO>();

            CreateMap<Genre, GenreRespDTO>();

            CreateMap<Movie, MovieRespDTO>()
                .ForMember(dto => dto.MovieTheaters, entitie => entitie.MapFrom(prop => prop.MovieRooms.Select(mr => mr.MovieTheater)))
                .ForMember(dto => dto.Actors, entitie => entitie.MapFrom(prop => prop.MoviesActors.Select(ma => ma.Actor)));

        }
    }
}
