using Microsoft.EntityFrameworkCore;
using MyCinema.Data.Enums;
using MyCinema.Models;

namespace MyCinema.Data
{
    public class AppDbInitializer
    {
        public static void Seed (IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()){
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                // Cinema 
                if (! context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "Images/Cinemas/Cenima1.jpg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "Images/Cinemas/Cenima2.jpg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "Images/Cinemas/Cenima3.jpg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "Images/Cinemas/Cenima4.jpg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "Images/Cinemas/Cenima5.jpg",
                            Description = "This is the description of the first cinema"
                        },
                    });
                    context.SaveChanges();
                }
               
                // Producers 
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "Images/Producers/producer1.jpeg"

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "Images/Producers/producer2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "Images/Producers/producer3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "Images/Producers/producer4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "Images/Producers/producer5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                // Actors 
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Amer Khan",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "Images/Actors/amerKhan.png"

                        },
                        new Actor()
                        {
                            FullName = "Dwayne Johnson",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "Images/Actors/dwayneJohnson.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Emma Stone",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "Images/Actors/emastone.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Keanu Reeves",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "Images/Actors/johnweek.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Robert Downey",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL= "Images/Actors/robertDowney.jpg"
                        }
                    });
                    context.SaveChanges();

                }
                // Movie 
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "A Beautiful Mind",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "Images/movies/ABeautifulMind.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            Category = MovieCategory.Drama
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "Images/movies/ShawshankRedemption.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            Category = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Good Will Hunting",
                            Description = "This is the good will hunting movie description",
                            Price = 39.50,
                            ImageURL = "Images/movies/goodwillhunting.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            Category = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "The Green Mile",
                            Description = "This is the Green Mile movie description",
                            Price = 39.50,
                            ImageURL = "Images/movies/thegreenmile.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            Category = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Cruella",
                            Description = "This is the cruella movie description",
                            Price = 49.50,
                            ImageURL = "Images/movies/cruella.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            Category = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Forest Jump",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "Images/movies/forestjump.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            Category = MovieCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }

                // Actors_Movies 
                if (!context.Actor_Movies.Any())
                {
                    context.Actor_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();

                }
            } 
        }
    }
}