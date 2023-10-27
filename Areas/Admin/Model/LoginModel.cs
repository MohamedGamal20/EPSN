using System.ComponentModel.DataAnnotations;

namespace EPSN.Areas.Admin.Model
{
    public class LoginModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public string Message { get; set; }
    }
}