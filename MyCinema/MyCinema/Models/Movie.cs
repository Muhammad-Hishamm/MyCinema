using MyCinema.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCinema.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageURL { get; set; }
        public MovieCategory Category { get; set; }


        //Relationships

        // Producer
        public int ProducerId { get; set; }


        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

        //Actors
        public List<Actor_Movie> Actors { get; set; }

        //Cinema
        public int CinemaId { get; set; }


        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }
    }
}
