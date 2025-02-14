using AutoMapper;
using InventoryTrackApi.DTOs;
using InventoryTrackApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

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

            // //Customer
            CreateMap<CustomerDTO, Customer>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Customer, CustomerDTO>().ReverseMap();

            CreateMap<JsonPatchDocument<CustomerDTO>, JsonPatchDocument<Customer>>();

            CreateMap<Operation<CustomerDTO>, Operation<Customer>>();
            //CreateMap<CustomerDTO, Customer>().ReverseMap();

            //Employee
            CreateMap<Employee, EmployeeDTO>().ReverseMap() ;

            //Inventory
            CreateMap<Inventory, InventoryDTO>().ReverseMap() ;
            //Inventory Mouvement
            CreateMap<InventoryMouvement, InventoryMouvementDTO>().ReverseMap() ;

            //Purchase
            //CreateMap<Purchase, PurchaseDTO>().ReverseMap() ;
            CreateMap<PurchaseDTO, Purchase>().ReverseMap();
            // Map Customer.Name to CustomerName
            CreateMap<Purchase, PurchaseDTO>()
            .ForMember(supplier => supplier.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name));

            //Purchase Item
            CreateMap<PurchaseItem, PurchaseItemDTO>().ReverseMap() ;
           
            // Map Product.Name to ProductName
            CreateMap<PurchaseItem, PurchaseItemDTO>()
            .ForMember(supplier => supplier.ProductName, opt => opt.MapFrom(src => src.Product.Name)).ReverseMap();

            //Purchase Payement
            CreateMap<PurchasePayment, PurchasePaymentDTO>().ReverseMap() ;

            //Sale
            CreateMap<Sale, SaleDTO>().ReverseMap() ;

            // Map Customer.Name to CustomerName
            CreateMap<Sale, SaleDTO>()
            .ForMember(customer => customer.CustomerName, opt => opt.MapFrom(src => src.Customer.Name)).ReverseMap();

            
            //Sale Item
            CreateMap<SaleItem, SaleItemDTO>().ReverseMap() ;

            // Map SaleItem to SaleItemDTO
            CreateMap<SaleItem, SaleItemDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name)); // Map Product to ProductDTO

            //Sale Payment
            CreateMap<SalePayment, SalePaymentDTO>().ReverseMap() ;

            //Sale
            CreateMap<Return, ReturnDTO>().ReverseMap();
            //Sale Item
            CreateMap<ReturnItem, ReturnItemDTO>().ReverseMap();
            //Sale Payment
            CreateMap<ReturnPayment, ReturnPaymentDTO>().ReverseMap();

            //Supplier
            CreateMap<Supplier, SupplierDTO>().ReverseMap() ;

        }
    }
}
