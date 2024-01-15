using Microsoft.AspNetCore.Identity;

namespace MVC_Trial_Exam.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
