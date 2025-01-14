using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryId { get; set; }
        
        [Required]
        public decimal Quantity { get; set; } = 0;
        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public string ModifiedBy { get; set; } = string.Empty;

        [DefaultValue("DateTime.Now")]
        public DateTime DateModified { get; set; } = DateTime.Now;

        [Required]
        public int LocationId { get; set; }
        [Required]
        public int ProductId { get; set; }

        [JsonIgnore]
        public virtual Product? Product { get; set; }
        [JsonIgnore]
        public virtual Location? Location { get; set; }

    }
}
