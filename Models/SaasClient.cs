using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventoryTrackApi.Models
{
    public class SaasClient
    {
        [Key]
        public int SaasClientId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Example: "Free", "Paid"
        public string? SubscriptionType { get; set; }

        // Date when the subscription expires.
        // Nullable: For example, a free plan may have no expiration.
        public DateTime? SubscriptionExpiration { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; } = new List<User>();

        [JsonIgnore]
        public virtual ICollection<CashRegister> CashRegisters { get; set; } = new List<CashRegister>();

        [JsonIgnore]
        public virtual ICollection<CashShift> CashShifts { get; set; } = new List<CashShift>();

        [JsonIgnore]
        public virtual ICollection<CashTransaction> CashTransactions { get; set; } = new List<CashTransaction>();

        [JsonIgnore]
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        [JsonIgnore]
        public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

        [JsonIgnore]
        public virtual ICollection<InventoryMouvement> InventoryMouvements { get; set; } = new List<InventoryMouvement>();

        [JsonIgnore]
        public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

        [JsonIgnore]
        public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

        [JsonIgnore]
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

        [JsonIgnore]
        public virtual ICollection<PurchasePayment> PurchasePayments { get; set; } = new List<PurchasePayment>();

        [JsonIgnore]
        public virtual ICollection<Return> Returns { get; set; } = new List<Return>();

        [JsonIgnore]
        public virtual ICollection<ReturnItem> ReturnItems { get; set; } = new List<ReturnItem>();

        [JsonIgnore]
        public virtual ICollection<ReturnPayment> ReturnPayments { get; set; } = new List<ReturnPayment>();

        [JsonIgnore]
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

        [JsonIgnore]
        public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

        [JsonIgnore]
        public virtual ICollection<SalePayment> SalePayments { get; set; } = new List<SalePayment>();

        [JsonIgnore]
        public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}
