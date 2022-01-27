using Microsoft.AspNetCore.Identity;

namespace EmployeeManangement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
