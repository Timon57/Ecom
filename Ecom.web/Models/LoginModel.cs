using System.ComponentModel.DataAnnotations;

namespace Ecom.web.Models
{
    public class LoginModel
    {
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
