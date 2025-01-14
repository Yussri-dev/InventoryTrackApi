using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InventoryTrackApi.DTOs
{
    public class SupplierDTO
    {
        public int SupplierId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber1 { get; set; } = string.Empty;
        public string PhoneNumber2 { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Land { get; set; } = string.Empty;
        public bool IsActivate { get; set; } = true;
    }
}
