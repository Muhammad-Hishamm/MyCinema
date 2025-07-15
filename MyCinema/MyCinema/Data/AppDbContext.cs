using Microsoft.EntityFrameworkCore;
using MyCinema.Models;
namespace MyCinema.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<Actor_Movie>()
                .HasOne(am => am.Movie)                         // navigation property to Movie
                .WithMany(m => m.Actors)                // Movie has a collection of Actor_Movie
                .HasForeignKey(am => am.MovieId);              // foreign key pointing to MovieId


            modelBuilder.Entity<Actor_Movie>()
                .HasOne(am => am.Actor)                         // navigation property to Actor
                .WithMany(a => a.Movies)                // Actor has a collection of Actor_Movie
                .HasForeignKey(am => am.ActorId);              // foreign key pointing to ActorId

            // 🔁 Always call base method to preserve EF Core conventions and inheritance behavior
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers {  get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie>Actor_Movies { get; set; }
    }
}
