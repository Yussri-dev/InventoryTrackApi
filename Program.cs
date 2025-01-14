using InventoryTrackApi.Data;
using InventoryTrackApi.Middlewares;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductBatchService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<LineService>();
builder.Services.AddScoped<ShelfService>();
builder.Services.AddScoped<TaxService>();
builder.Services.AddScoped<UnitService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<CashRegisterService>();
builder.Services.AddScoped<CashShiftService>();
builder.Services.AddScoped<CashTransactionService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<InventoryMouvementService>();
builder.Services.AddScoped<PurchaseService>();
builder.Services.AddScoped<PurchaseItemService>();
builder.Services.AddScoped<PurchasePaymentService>();
builder.Services.AddScoped<SaleService>();
builder.Services.AddScoped<SaleItemService>();
builder.Services.AddScoped<SalePaymentService>();
builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<SaleItemProductService>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<InventoryDbContext>(options =>
//{
//    options.UseInMemoryDatabase("InventoryTrackApiDB");

//    //i've used Query No Tracking To Avoid the Problem In Updating Data Entries In Db Context
//    //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//});

builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

var app = builder.Build();

// Add the custom exception handling middleware
app.UseMiddleware<ExceptionHandler>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
