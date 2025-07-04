using Microsoft.EntityFrameworkCore;
using MyCinema.Models;
namespace MyCinema.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ Define the composite primary key for the join table using both ActorId and MovieId 
            // this is Fluent API style for data Configuring 
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            // 🎬 Set up relationship: each Actor_Movie entry is linked to one Movie
            // One Movie can appear in multiple Actor_Movie records
            modelBuilder.Entity<Actor_Movie>()
                .HasOne(am => am.Movie)                         // navigation property to Movie
                .WithMany(m => m.Actors)                // Movie has a collection of Actor_Movie
                .HasForeignKey(am => am.MovieId);              // foreign key pointing to MovieId

            // 🎭 Set up relationship: each Actor_Movie entry is linked to one Actor
            // One Actor can appear in multiple Actor_Movie records
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
