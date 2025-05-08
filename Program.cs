using InventoryTrackApi.Data;
using InventoryTrackApi.Middlewares;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



var key = Encoding.UTF8.GetBytes("My_Secret_Key_For_Inventory_Track_Api_My_Secret_Key_For_Inventory_Track_Api");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });

//-------------------------------------------
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
builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<SaasClientService>();

builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<InventoryMouvementService>();

builder.Services.AddScoped<PurchaseService>();
builder.Services.AddScoped<PurchaseItemService>();
builder.Services.AddScoped<PurchasePaymentService>();

builder.Services.AddScoped<SaleService>();
builder.Services.AddScoped<SaleItemService>();
builder.Services.AddScoped<SalePaymentService>();

builder.Services.AddScoped<ReturnService>();
builder.Services.AddScoped<ReturnItemService>();




//builder.Services.AddScoped<ReturnPaymentService>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddLogging();

builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.AllowAnyOrigin() // Blazor WebAssembly app URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//enabling Authorization
builder.Services.AddAuthorization();

//builder.Services.AddDbContext<InventoryDbContext>(options =>
//{
//    options.UseInMemoryDatabase("InventoryTrackApiDB");

//    //i ve used Query No Tracking To Avoid the Problem In Updating Data Entries In Db Context
//    //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//});

//builder.Services.AddDbContext<InventoryDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
    ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));
//// Explicitly configure Kestrel to listen on all network interfaces
//builder.WebHost.ConfigureKestrel(serverOptions =>
//{
//    serverOptions.ListenAnyIP(5000); // HTTP
//    //serverOptions.ListenAnyIP(5001, listenOptions => listenOptions.UseHttps()); // HTTPS
//});

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5000); // HTTP
    serverOptions.ListenAnyIP(5001, listenOptions => listenOptions.UseHttps()); // Uses dev cert
});

var app = builder.Build();

if (app.Environment.IsProduction())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<InventoryDbContext>();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Une erreur s'est produite lors de la migration de la base de données.");

            if (app.Environment.IsDevelopment())
                throw;
        }
    }
}

// Add the custom exception handling middleware
app.UseMiddleware<ExceptionHandler>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
