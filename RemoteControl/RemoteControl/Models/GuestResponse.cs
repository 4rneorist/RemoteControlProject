using System.ComponentModel.DataAnnotations;

namespace RemoteControl.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Pleas enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pleas enter your email address")]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Pleas enter your phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Pleas specify wether you'll attend")]
        public bool? WillAttend { get; set; }
    }
}
