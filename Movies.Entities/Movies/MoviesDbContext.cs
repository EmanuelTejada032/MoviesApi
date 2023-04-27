using Microsoft.EntityFrameworkCore;
using Movies.Entities.Movies.Configurations;
using System.Reflection.Emit;


namespace Movies.Entities.Movies
{
    public class MoviesDbContext: DbContext
    {
        public MoviesDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<MovieTheater> MovieTheaters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieRoom> MovieRooms { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MoviesActors> MoviesActors { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Genre>(new GenreConfig());
            modelBuilder.ApplyConfiguration<MovieRoom>(new MovieRoomConfig());
            modelBuilder.ApplyConfiguration<MoviesActors>(new MoviesActorsConfig());

            modelBuilder.Entity<MovieTheater>().Property(c => c.Name).HasMaxLength(150).IsRequired();

            modelBuilder.Entity<Movie>().Property(c => c.Title)
                        .HasMaxLength(250)
                        .IsRequired();

            modelBuilder.Entity<Movie>().Property(c => c.PosterUrl)
                        .HasMaxLength(500)
                        .IsUnicode(false);

            modelBuilder.Entity<MovieTheaterOffer>().Property(mt => mt.DiscountPercentaje)
             .HasPrecision(precision: 5, scale: 2).IsRequired();

        }
    }
}
