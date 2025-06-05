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
            #region Cash Register
            //-------------CashRegister----------------

            CreateMap<CashRegister, CashRegisterDTO>().ReverseMap();

            CreateMap<CashRegister, CashRegisterDTO>()
             .ForMember(emp => emp.NameComplete, opt => opt.MapFrom(src => src.Employee.NameComplete))
             .ForMember(loc => loc.NameLocation, opt => opt.MapFrom(src => src.Location.Name));

            CreateMap<CashRegisterDTO, CashRegister>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #endregion

            #region CashShift
            //-------------CashShift----------------

            CreateMap<CashShift, CashShiftDTO>().ReverseMap();

            CreateMap<CashShift, CashShiftDTO>()
            .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
            .ForMember(dest => dest.NameComplete, opt => opt.MapFrom(src => src.Employee != null ? src.Employee.NameComplete : string.Empty))
            .ReverseMap();

            CreateMap<CashShiftDTO, CashShift>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #endregion


            //-------------CashTransaction----------------
            #region CashTransaction
            CreateMap<CashTransaction, CashTransactionDTO>().ReverseMap();

            CreateMap<CashTransactionDTO, CashTransaction>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #endregion


            #region Category

            //-------------Category----------------
            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<CategoryDTO, Category>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #endregion

            #region Customer
            //-------------Customer----------------
            CreateMap<Customer, CustomerDTO>().ReverseMap();

            CreateMap<CustomerDTO, Customer>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CustomerDTO, Customer>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<JsonPatchDocument<CustomerDTO>, JsonPatchDocument<Customer>>();
            CreateMap<Operation<CustomerDTO>, Operation<Customer>>();

            #endregion

            #region Taxes
            //-------------Customer----------------
            CreateMap<Tax, TaxDTO>().ReverseMap();

            CreateMap<TaxDTO, Tax>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #endregion



            #region Employee
            //-------------Employee----------------
            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            CreateMap<EmployeeDTO, Employee>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<EmployeeDTO, Employee>()
           .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
           .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #endregion

            #region Inventory
            //Inventory
            CreateMap<Inventory, InventoryDTO>().ReverseMap();

            // CreateMap<Inventory, InventoryDTO>()
            //.ForMember(location => location.LocationName, opt => opt.MapFrom(src => src.Location.Name));

            CreateMap<InventoryDTO, Inventory>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #endregion


            #region Inventory Mouvement
            //Inventory Mouvement
            CreateMap<InventoryMouvement, InventoryMouvementDTO>().ReverseMap();

            CreateMap<InventoryMouvement, InventoryMouvementDTO>()
           .ForMember(location => location.LocationName, opt => opt.MapFrom(src => src.Location.Name));

            CreateMap<InventoryMouvementDTO, InventoryMouvement>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #endregion


            #region SaasClient
            //-------------SaasClient----------------
            CreateMap<SaasClient, SaasClientDTO>().ReverseMap();

            CreateMap<SaasClientDTO, SaasClient>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion


            #region Location

            //-------------Location----------------
            CreateMap<Location, LocationDTO>().ReverseMap();

            CreateMap<LocationDTO, Location>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<LocationDTO, Location>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #endregion

            #region Lines
            //Lines
            CreateMap<Line, LineDTO>().ReverseMap();
            #endregion


            #region Supplier
            //-------------Supplier----------------

            CreateMap<Supplier, SupplierDTO>().ReverseMap();

            CreateMap<SupplierDTO, Supplier>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<SupplierDTO, Supplier>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<JsonPatchDocument<SupplierDTO>, JsonPatchDocument<Supplier>>();
            CreateMap<Operation<SupplierDTO>, Operation<Supplier>>();

            #endregion


            #region Shelfs
            //Shelfs
            CreateMap<Shelf, ShelfDTO>().ReverseMap();
            #endregion




            #region Products

            //Products
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.ShelfId, opt => opt.MapFrom(src => src.ShelfId))
                .ForMember(dest => dest.ShelfName, opt => opt.MapFrom(src => src.Shelf.Name))
                .ForMember(dest => dest.UnitId, opt => opt.MapFrom(src => src.UnitId))
                .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src => src.Unit.Name))
                .ForMember(dest => dest.TaxId, opt => opt.MapFrom(src => src.TaxId))
                .ForMember(dest => dest.TaxRate, opt => opt.MapFrom(src => src.Tax.TaxRate))
                .ForMember(dest => dest.LineId, opt => opt.MapFrom(src => src.LineId))
                .ForMember(dest => dest.LineName, opt => opt.MapFrom(src => src.Line.Name))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Shelf, opt => opt.Ignore())
                .ForMember(dest => dest.ShelfId, opt => opt.MapFrom(src => src.ShelfId))
                .ForMember(dest => dest.Unit, opt => opt.Ignore())
                .ForMember(dest => dest.UnitId, opt => opt.MapFrom(src => src.UnitId))
                .ForMember(dest => dest.Tax, opt => opt.Ignore())
                .ForMember(dest => dest.TaxId, opt => opt.MapFrom(src => src.TaxId))
                .ForMember(dest => dest.Line, opt => opt.Ignore())
                .ForMember(dest => dest.LineId, opt => opt.MapFrom(src => src.LineId));


            #endregion

            #region ProductBatch

            //Product Batch
            CreateMap<ProductBatch, ProductBatchDTO>().ReverseMap();

            #endregion

            #region Purchase
            //-------------Sale----------------
            CreateMap<PurchaseDTO, Purchase>().ReverseMap();

            CreateMap<Purchase, PurchaseDTO>()
            .ForMember(dest => dest.SupplierId, opt => opt.Ignore())  // Prevents creating a new Customer
            .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.SupplierId))
            .ForMember(supplier => supplier.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name)).ReverseMap();

            CreateMap<PurchaseDTO, Purchase>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion

            #region PurchaseItem
            //Inventory
            CreateMap<PurchaseItem, PurchaseItemDTO>().ReverseMap();

            CreateMap<PurchaseItem, PurchaseItemDTO>()
           .ForMember(prd => prd.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<PurchaseItemDTO, PurchaseItem>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #endregion


            #region PurchasePayement
            CreateMap<PurchasePaymentDTO, PurchasePayment>().ReverseMap();

            CreateMap<PurchasePaymentDTO, PurchasePayment>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion

            #region Return
            //-------------Return----------------
            CreateMap<ReturnDTO, Return>().ReverseMap();

            CreateMap<Return, ReturnDTO>()
            .ForMember(dest => dest.CustomerId, opt => opt.Ignore())  // Prevents creating a new Customer
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(supplier => supplier.CustomerName, opt => opt.MapFrom(src => src.Customer.Name)).ReverseMap();

            CreateMap<ReturnDTO, Return>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion


            #region ReturnItem
            //Inventory
            CreateMap<ReturnItem, ReturnItemDTO>().ReverseMap();

            CreateMap<ReturnItem, ReturnItemDTO>()
           .ForMember(prd => prd.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<ReturnItemDTO, ReturnItem>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #endregion

            #region ReturnPayment
            CreateMap<ReturnPaymentDTO, ReturnPayment>().ReverseMap();

            CreateMap<ReturnPaymentDTO, ReturnPayment>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion

            #region Sale
            //-------------Sale----------------
            CreateMap<SaleDTO, Sale>().ReverseMap();

            CreateMap<Sale, SaleDTO>()
            .ForMember(dest => dest.CustomerId, opt => opt.Ignore())  // Prevents creating a new Customer
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(supplier => supplier.CustomerName, opt => opt.MapFrom(src => src.Customer.Name)).ReverseMap();

            CreateMap<SaleDTO, Sale>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion

            #region SaleItem
            //Inventory
            CreateMap<SaleItem, SaleItemDTO>().ReverseMap();

            CreateMap<SaleItem, SaleItemDTO>()
           .ForMember(prd => prd.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<SaleItemDTO, SaleItem>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #endregion

            #region SalePayment
            CreateMap<SalePayment, SalePaymentDTO>()
                .ForMember(dest => dest.SaleId, opt => opt.MapFrom(src => src.SaleId))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<SalePaymentDTO, SalePayment>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForMember(dest => dest.SaleId, opt => opt.Ignore()) // <--- Prevent update
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            #endregion





            #region User
            //-------------User----------------

            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<UserDTO, User>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UserDTO, User>()
            .ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            .ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #endregion

            #region Units

            //-------------Category----------------
            CreateMap<Unit, UnitDTO>().ReverseMap();

            CreateMap<UnitDTO, Unit>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #endregion

            #region SaasClient
            //-------------SaasClient----------------

            CreateMap<SaasClient, SaasClientDTO>().ReverseMap();

            CreateMap<SaasClientDTO, SaasClient>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            //CreateMap<UserDTO, User>()
            //.ForMember(dest => dest.SaasClient, opt => opt.Ignore())
            //.ForMember(dest => dest.SaasClientId, opt => opt.MapFrom(src => src.SaasClientId))
            //.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #endregion


        }
    }
}
