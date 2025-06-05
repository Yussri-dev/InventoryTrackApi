using InventoryTrackApi.Models;
using System.ComponentModel.DataAnnotations;

namespace InventoryTrackApi.DTOs
{
    public class SaasClientDTO
    {
        [Key]
        public int SaasClientId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? SubscriptionType { get; set; }

        public DateTime? SubscriptionExpiration { get; set; }

    }

}
