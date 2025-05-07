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


        //public virtual List<User> Users { get; set; }
        //public virtual List<CashRegister> CashRegisters { get; set; }
        //public virtual List<CashShift> CashShifts { get; set; }
        //public virtual List<CashTransaction> CashTransactions { get; set; }
        //public virtual List<Customer> Customers { get; set; }
        //public virtual List<Employee> Employees { get; set; }
        //public virtual List<Inventory> Inventories { get; set; }
        //public virtual List<InventoryMouvement> InventoryMouvements { get; set; }
        //public virtual List<Location> Locations { get; set; }
        //public virtual List<Purchase> Purchases { get; set; }
        //public virtual List<PurchaseItem> PurchaseItems { get; set; }
        //public virtual List<PurchasePayment> PurchasePayments { get; set; }
        //public virtual List<Return> Returns { get; set; }
        //public virtual List<ReturnItem> ReturnItems { get; set; }
        //public virtual List<ReturnPayment> ReturnPayments { get; set; }
        //public virtual List<Sale> Sales { get; set; }
        //public virtual List<SaleItem> SaleItems { get; set; }
        //public virtual List<SalePayment> SalePayments { get; set; }
        //public virtual List<Supplier> Suppliers { get; set; } 
    }

}
