using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Entities.Movies;

namespace Movies.Entities.Movies.Configurations
{
    public class MovieRoomConfig : IEntityTypeConfiguration<MovieRoom>
    {
        public void Configure(EntityTypeBuilder<MovieRoom> builder)
        {
            builder.Property(c => c.Price).HasPrecision(precision: 9, scale: 2);
            builder.Property(c => c.Type).HasDefaultValue(MovieRoomEnumType.Type2D);
        }
    }
}
