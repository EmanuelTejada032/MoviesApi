using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Entities.Movies;

namespace Movies.Entities.Movies.Configurations
{
    public class MoviesActorsConfig : IEntityTypeConfiguration<MoviesActors>
    {
        public void Configure(EntityTypeBuilder<MoviesActors> builder)
        {
            builder.Property(ma => ma.CharacterName).HasMaxLength(150);
            builder.HasKey(prop => new { prop.MovieId, prop.ActorId });
        }
    }
}
