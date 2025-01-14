using System.ComponentModel.DataAnnotations;

namespace InventoryTrackApi.DTOs
{
    public class TaxDTO
    {
        public int TaxId { get; set; }

        [Required]
        public decimal TaxRate { get; set; }

    }
}
