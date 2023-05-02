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

            CreateMap<Movie, MovieListItemResponseDTO>()
                .ForMember(dto => dto.Genres, entitie => entitie.MapFrom(prop => prop.Genres.Select(g => g.Name)))
                .ForMember(dto => dto.Actors, entitie => entitie.MapFrom(prop => prop.MoviesActors.Select(ma => ma.Actor).Select( a => a.Name)));

            // Movie mapping without Project to
            CreateMap<Movie, MovieRespDTO>()
                .ForMember(dto => dto.MovieTheaters, entitie => entitie.MapFrom(prop => prop.MovieRooms.Select(mr => mr.MovieTheater)))
                .ForMember(dto => dto.Actors, entitie => entitie.MapFrom(prop => prop.MoviesActors.Select(ma => ma.Actor)));


            /* Movie mapping With Project To
                CreateMap<Movie, MovieRespDTO>()
                    .ForMember(dto => dto.Genres, ent => ent.MapFrom( prop => prop.Genres.OrderByDescending( gen => gen.Name)))
                    .ForMember(dto => dto.MovieTheaters, entitie => entitie.MapFrom(prop => prop.MovieRooms.Select(mr => mr.MovieTheater)))
                    .ForMember(dto => dto.Actors, entitie => entitie.MapFrom(prop => prop.MoviesActors.Select(ma => ma.Actor)));
            */
        }
    }
}
