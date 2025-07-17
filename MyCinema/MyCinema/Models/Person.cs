using System.ComponentModel.DataAnnotations;

namespace MyCinema.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }



        [Display(Name ="Full Name")]
        [Required(ErrorMessage ="The Full Name is Required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="The name length must be between 3 to 50 characters")]
        public string FullName { get; set; }



        [Display(Name = "Biography")]
        [Required(ErrorMessage = "The Biography is Required")]
        public string Bio { get; set; }




        [Display(Name ="Profile Picture URL")]
        [Required(ErrorMessage = "The Profile picture URL is Required")]

        public string ProfilePictureURL { get; set; }

    }

}
    