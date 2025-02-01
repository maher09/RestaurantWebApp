using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModel
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }


        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
