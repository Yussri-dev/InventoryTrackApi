using System.ComponentModel.DataAnnotations;

namespace InventoryTrackApi.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SaasClientId { get; set; }
        public List<string> Roles { get; set; }

    }
}
