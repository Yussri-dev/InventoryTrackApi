using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;

namespace InventoryTrackApi.MappingProfiles.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Categories
            CreateMap<Category, CategoryDTO>().ReverseMap() ;
            //Shelfs
            CreateMap<Shelf, ShelfDTO>().ReverseMap() ;
            //Taxes
            CreateMap<Tax, TaxDTO>().ReverseMap() ;
            //Units
            CreateMap<Unit, UnitDTO>().ReverseMap() ;
            //Location
            CreateMap<Location, LocationDTO>().ReverseMap() ;
            //Lines
            CreateMap<Line, LineDTO>().ReverseMap() ;
            //Products
            CreateMap<Product, ProductDTO>().ReverseMap() ;
            //Product Batch
            CreateMap<ProductBatch, ProductBatchDTO>().ReverseMap() ;


            //CashRegister
            CreateMap<CashRegister, CashRegisterDTO>().ReverseMap() ;
            //CashShift
            CreateMap<CashShift, CashShiftDTO>().ReverseMap() ;
            //CashTransaction
            CreateMap<CashTransaction, CashTransactionDTO>().ReverseMap() ;

            //Customer
            CreateMap<Customer, CustomerDTO>().ReverseMap() ;
            //Employee
            CreateMap<Employee, EmployeeDTO>().ReverseMap() ;

            //Inventory
            CreateMap<Inventory, InventoryDTO>().ReverseMap() ;
            //Inventory Mouvement
            CreateMap<InventoryMouvement, InventoryMouvementDTO>().ReverseMap() ;

            //Purchase
            CreateMap<Purchase, PurchaseDTO>().ReverseMap() ;
            //Purchase Item
            CreateMap<PurchaseItem, PurchaseItemDTO>().ReverseMap() ;
            //Purchase Payement
            CreateMap<PurchasePayment, PurchasePaymentDTO>().ReverseMap() ;

            //Sale
            CreateMap<Sale, SaleDTO>().ReverseMap() ;
            //Sale Item
            CreateMap<SaleItem, SaleItemDTO>().ReverseMap() ;
            //Sale Payment
            CreateMap<SalePayment, SalePaymentDTO>().ReverseMap() ;

            //Supplier
            CreateMap<Supplier, SupplierDTO>().ReverseMap() ;

        }
    }
}
