using InventoryTrackApi.Data;
using InventoryTrackApi.Identity;
using InventoryTrackApi.Middlewares;
using InventoryTrackApi.Models;
using InventoryTrackApi.Repositories;
using InventoryTrackApi.Services;
using InventoryTrackApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

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
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Configuration de la session
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//enabling Authorization
builder.Services.AddAuthorization();


var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
    ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

// Configuration de Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Options de configuration...
})
.AddEntityFrameworkStores<InventoryDbContext>()
.AddDefaultTokenProviders();

// Check if JWT configuration exists
Console.WriteLine($"JWT Key: {builder.Configuration["Jwt:Key"]}");
Console.WriteLine($"JWT Issuer: {builder.Configuration["Jwt:Issuer"]}");
Console.WriteLine($"JWT Audience: {builder.Configuration["Jwt:Audience"]}");

try
{
    // Configuration JWT using safe approach with hardcoded fallback
    var jwtKey = builder.Configuration["Jwt:Key"] ?? "DefaultSecurityKeyWith32Characters!!!";
    var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "DefaultIssuer";
    var jwtAudience = builder.Configuration["Jwt:Audience"] ?? "DefaultAudience";

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    })
    .AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    });

}
catch (Exception ex)
{
    Console.WriteLine($"Error configuring JWT: {ex.Message}");
    throw;
}

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

// Injection des dépendances
builder.Services.AddScoped<ITokenService, JwtTokenService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();

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

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5000);
    serverOptions.ListenAnyIP(5001, listenOptions => listenOptions.UseHttps());
});

builder.Services.AddMemoryCache();
builder.Services.AddScoped<ICacheService, CacheService>();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddUserSecrets<Program>();

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

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roles = new[] { "Admin", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
app.UseSession();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
