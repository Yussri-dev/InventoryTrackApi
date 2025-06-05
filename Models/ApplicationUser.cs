using Microsoft.AspNetCore.Identity;

namespace InventoryTrackApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}
