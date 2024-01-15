using Business.P_1.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace Business.P_1.Models
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
