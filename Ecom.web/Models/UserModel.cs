using System.ComponentModel.DataAnnotations;

namespace Ecom.web.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Passwrod and ConfirmPassword must match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string Role { get; set; }

    }
}
