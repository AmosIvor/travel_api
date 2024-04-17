using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Identity;

namespace travel_api.Models.EF
{
    public class User : IdentityUser
    {
        public bool? Male { get; set; }

        public DateTime? DateBirth { get; set; }

        public string? Avatar { get; set; }
    }
}
