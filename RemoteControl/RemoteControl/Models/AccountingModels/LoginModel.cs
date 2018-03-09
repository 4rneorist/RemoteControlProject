using System.ComponentModel.DataAnnotations;

namespace RemoteControl.Models.AccountingModels
{
    public class LoginModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is empty")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is empty")]
        public string Password { get; set; }
    }
}
