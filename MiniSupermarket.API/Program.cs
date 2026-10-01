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

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SupermarketDbContext>(options =>
    options.UseSqlServer(connectionString));


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
// 11. RUN
// =========================================================

app.Run();
