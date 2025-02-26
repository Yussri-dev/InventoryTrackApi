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
            #region Mapping Finished
            //-------------Employee----------------
            CreateMap<EmployeeDTO, Employee>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            //-------------Location----------------
            CreateMap<LocationDTO, Location>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Location, LocationDTO>().ReverseMap();
            #endregion

            //Categories
            CreateMap<Category, CategoryDTO>().ReverseMap();
            //Shelfs
            CreateMap<Shelf, ShelfDTO>().ReverseMap();
            //Taxes
            CreateMap<Tax, TaxDTO>().ReverseMap();

            ////Units
            CreateMap<UnitDTO, Unit>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Unit, UnitDTO>().ReverseMap();

            
            //Lines
            CreateMap<Line, LineDTO>().ReverseMap();

            #region

            //Products
            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>()
           .ForMember(shelf => shelf.ShelfName, opt => opt.MapFrom(src => src.Shelf.Name))
           .ForMember(category => category.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
           .ForMember(unit => unit.UnitName, opt => opt.MapFrom(src => src.Unit.Name))
           .ForMember(tax => tax.TaxRate, opt => opt.MapFrom(src => src.Tax.TaxRate))
           .ForMember(line => line.LineName, opt => opt.MapFrom(src => src.Line.Name));

            //Product Batch
            CreateMap<ProductBatch, ProductBatchDTO>().ReverseMap();

            #endregion

            //CashRegister
            CreateMap<CashRegister, CashRegisterDTO>().ReverseMap();
            //CashShift
            CreateMap<CashShift, CashShiftDTO>().ReverseMap();
            //CashTransaction
            CreateMap<CashTransaction, CashTransactionDTO>().ReverseMap();

            // //Customer
            CreateMap<CustomerDTO, Customer>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Customer, CustomerDTO>().ReverseMap();

            CreateMap<JsonPatchDocument<CustomerDTO>, JsonPatchDocument<Customer>>();

            CreateMap<Operation<CustomerDTO>, Operation<Customer>>();
            //CreateMap<CustomerDTO, Customer>().ReverseMap();



            //Inventory
            CreateMap<Inventory, InventoryDTO>().ReverseMap();
            //Inventory Mouvement
            CreateMap<InventoryMouvement, InventoryMouvementDTO>().ReverseMap();

            //Purchase
            //CreateMap<Purchase, PurchaseDTO>().ReverseMap() ;
            CreateMap<PurchaseDTO, Purchase>().ReverseMap();
            // Map Customer.Name to CustomerName

            CreateMap<Purchase, PurchaseDTO>()
            .ForMember(dest => dest.SupplierId, opt => opt.Ignore())  // Prevents creating a new Customer
            .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.SupplierId))
            .ForMember(supplier => supplier.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name)).ReverseMap();

            //Purchase Item
            CreateMap<PurchaseItem, PurchaseItemDTO>().ReverseMap();

            // Map Product.Name to ProductName
            CreateMap<PurchaseItem, PurchaseItemDTO>()
            .ForMember(product => product.ProductName, opt => opt.MapFrom(src => src.Product.Name)).ReverseMap();

            //Purchase Payement
            CreateMap<PurchasePayment, PurchasePaymentDTO>().ReverseMap();

            //Sale
            //CreateMap<Sale, SaleDTO>().ReverseMap() ;

            CreateMap<Sale, SaleDTO>()
            .ForMember(dest => dest.CustomerId, opt => opt.Ignore())  // Prevents creating a new Customer
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(customer => customer.CustomerName, opt => opt.MapFrom(src => src.Customer.Name)).ReverseMap();

            //Sale Item
            CreateMap<SaleItem, SaleItemDTO>().ReverseMap();

            // Map SaleItem to SaleItemDTO
            CreateMap<SaleItem, SaleItemDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name)); // Map Product to ProductDTO

            //Sale Payment
            CreateMap<SalePayment, SalePaymentDTO>().ReverseMap();

            //Sale
            CreateMap<Return, ReturnDTO>().ReverseMap();
            //Sale Item
            CreateMap<ReturnItem, ReturnItemDTO>().ReverseMap();
            //Sale Payment
            CreateMap<ReturnPayment, ReturnPaymentDTO>().ReverseMap();

            //Supplier
            CreateMap<Supplier, SupplierDTO>().ReverseMap();

            //User
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
