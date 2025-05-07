using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public enum MouvementType
    {
        Purchase,
        Sale,
        Return
    }

    public class InventoryMouvement
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryMouvementId { get; set; }
        [Required]
        public int ProductId  { get; set; }
        [Required]
        public int LocationId { get; set; }
        //movement ("Purchase", "Sale", "Return")
        [Required]
        //public string MouvementType { get; set; } = string.Empty;
        public MouvementType MouvementType { get; set; } // Changed to Enum

        [Required]
        public decimal Quantity { get; set; }

        [DefaultValue("DateTime.Now")]
        public DateTime MouvementDate { get; set; } = DateTime.Now;

        [DefaultValue("DateTime.Now")]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// List of Mouvement Related To Products
        /// List of Mouvement Related To Locations
        /// </summary>
        //[JsonIgnore]
        //public virtual Product? Product { get; set; }
        [Required]
        public int SaasClientId { get; set; }

        [JsonIgnore]
        public virtual SaasClient SaasClient { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        [JsonIgnore]
        public virtual Location? Location { get; set; }
    }
}
