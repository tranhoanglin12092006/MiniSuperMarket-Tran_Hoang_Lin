using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MiniSupermarket.API.Data;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// =========================================================
// 1. DATABASE - SQL SERVER + ENTITY FRAMEWORK CORE
// =========================================================

//var connectionString =
//    builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<SupermarketDbContext>(options =>
//    options.UseSqlServer(connectionString));

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Database=MiniSupermarketDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";

if (!string.IsNullOrEmpty(connectionString) && (connectionString.Contains("Port=3306") || connectionString.Contains("User=") || connectionString.Contains("uid=")))
{
    builder.Services.AddDbContext<SupermarketDbContext>(options =>
        options.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString)
        ));
}
else
{
    builder.Services.AddDbContext<SupermarketDbContext>(options =>
        options.UseSqlServer(connectionString));
}

// =========================================================
// 2. JWT AUTHENTICATION
// =========================================================

var jwtSecret = builder.Configuration["JwtSettings:Secret"]
    ?? "SupermarketSecretKeyDoAnMonHoc2026SecureString!!";

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(jwtSecret)
        ),

        ValidateIssuer = false,
        ValidateAudience = false,

        ValidateLifetime = true,

        ClockSkew = TimeSpan.Zero
    };
});


// =========================================================
// 3. AUTHORIZATION
// =========================================================

builder.Services.AddAuthorization();


// =========================================================
// 4. CONTROLLERS
// =========================================================

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();


// =========================================================
// 5. SWAGGER + JWT
// =========================================================

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",

            Type = SecuritySchemeType.Http,

            Scheme = "bearer",

            BearerFormat = "JWT",

            In = ParameterLocation.Header,

            Description =
                "Nhập JWT token theo dạng: Bearer {token}"
        });

    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },

                Array.Empty<string>()
            }
        });
});


// =========================================================
// 6. BUILD APP
// =========================================================

var app = builder.Build();


// =========================================================
// 7. SWAGGER
// =========================================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// =========================================================
// 8. HTTPS
// =========================================================

app.UseHttpsRedirection();


// =========================================================
// 9. AUTHENTICATION + AUTHORIZATION
// =========================================================

app.UseAuthentication();

app.UseAuthorization();


// =========================================================
// 10. CONTROLLERS
// =========================================================

app.MapControllers();


// =========================================================
// 10.5. TỰ ĐỘNG KHỞI TẠO VÀ CẬP NHẬT DATABASE (EF CORE MIGRATE)
// =========================================================

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SupermarketDbContext>();
    try
    {
        dbContext.Database.Migrate();

        // Đảm bảo có tài khoản "Khách hàng vãng lai" trong cơ sở dữ liệu
        var guestCustomer = dbContext.Customers.FirstOrDefault(c => c.CustomerName == "Khách hàng vãng lai");
        if (guestCustomer == null)
        {
            guestCustomer = new MiniSupermarket.API.Models.Customer
            {
                CustomerName = "Khách hàng vãng lai",
                PhoneNumber = "0000000000",
                MembershipRank = "Chuẩn",
                RewardPoints = 0,
                Address = "Khách mua lẻ trực tiếp tại quầy"
            };
            dbContext.Customers.Add(guestCustomer);
            dbContext.SaveChanges();
        }

        // Cập nhật lại các hóa đơn thử nghiệm hôm nay bị gán nhầm vào khách hàng ID 1 do chưa nhập SĐT
        var mistaggedOrders = dbContext.Orders
            .Where(o => o.CustomerId == 1 && o.CreatedDate >= DateTime.Today)
            .ToList();
        if (mistaggedOrders.Any())
        {
            foreach (var ord in mistaggedOrders)
            {
                ord.CustomerId = guestCustomer.CustomerId;
                ord.RewardPoints = 0;
            }
            dbContext.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Đã xảy ra lỗi khi tự động cập nhật cơ sở dữ liệu (Database Migration).");
    }
}

// =========================================================
// 11. RUN
// =========================================================

app.Run();
