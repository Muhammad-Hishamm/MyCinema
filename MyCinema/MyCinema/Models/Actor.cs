using System.ComponentModel.DataAnnotations;

namespace MyCinema.Models
{
    public class Actor:Person
    {
        public List<Actor_Movie>? Movies { get; set; }

    }
}
