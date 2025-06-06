using System.ComponentModel.DataAnnotations;

namespace InventoryTrackApi.DTOs
{
    public class CashRegisterDTO
    {
        public int CashRegisterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int LocationId { get; set; }
        public string UserId { get; set; }
        public string? NameComplete { get; set; }
        public string? NameLocation { get; set; }
        public int SaasClientId { get; set; }
    }
}
