using System.ComponentModel.DataAnnotations;

namespace Business.P_1.ViewModels.Account
{
    public class LoginVm
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
