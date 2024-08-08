using Microsoft.AspNetCore.Identity;

namespace Movies.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }    
    }
}
