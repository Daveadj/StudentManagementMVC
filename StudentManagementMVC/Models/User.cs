using Microsoft.AspNetCore.Identity;

namespace StudentManagementMVC.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}