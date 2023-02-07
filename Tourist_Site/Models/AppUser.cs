using Microsoft.AspNetCore.Identity;

namespace Tourist_Site.Models
{
    public enum TypeUserEnum
    {
        user = 0,
        Resturant = 1,
        Hotel = 2
    }
    public class AppUser : IdentityUser
    {
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? ImagePath { get; set; }
        public string? Price { get; set; }
        public TypeUserEnum TypeUser { get; set; }
    }
}
