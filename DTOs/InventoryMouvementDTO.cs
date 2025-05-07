using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using InventoryTrackApi.Models;

namespace InventoryTrackApi.DTOs
{
    public class InventoryMouvementDTO
    {
        public int InventoryMouvementId { get; set; }
        public int ProductId { get; set; }
        public int LocationId { get; set; }
        //movement ("Purchase", "Sale", "Return")
        //public string MouvementType { get; set; } = string.Empty;
        public MouvementType MouvementType { get; set; } 
        public decimal Quantity { get; set; }
        public DateTime MouvementDate { get; set; } = DateTime.Now;

        //public string ProductName { get; set; }
        public string LocationName { get; set; }

        public int SaasClientId { get; set; }

    }
}
