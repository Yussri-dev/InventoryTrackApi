using System.ComponentModel.DataAnnotations;

namespace InventoryTrackApi.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int IdUser { get; set; }
        public int SaasClientId { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
