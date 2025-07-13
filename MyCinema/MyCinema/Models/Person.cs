using System.ComponentModel.DataAnnotations;

namespace MyCinema.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        [Display(Name ="Profile Picture URL")]
         public string ProfirlePictureURL { get; set; }

    }

}
    