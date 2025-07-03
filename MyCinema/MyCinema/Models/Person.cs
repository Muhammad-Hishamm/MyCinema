using System.ComponentModel.DataAnnotations;

namespace MyCinema.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfirlePictureURL { get; set; }

    }

}
