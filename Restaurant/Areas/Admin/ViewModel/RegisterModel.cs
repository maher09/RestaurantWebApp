using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModel
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }


        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }


        [DataType(DataType.Password)]
        [Required]
        [Compare("Password", ErrorMessage = "Password Not Match Batata")]
        public string? ConfirmPassword { get; set; }
    }
}
