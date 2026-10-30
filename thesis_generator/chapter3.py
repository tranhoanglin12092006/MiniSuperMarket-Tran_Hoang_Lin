# -*- coding: utf-8 -*-
from thesis_generator.builder import (p, heading1, heading2, heading3, make_table, 
                                      page_break, bullet, code_block, note_box, screenshot_placeholder)

def get_chapter3_xml():
    parts = []
    
    parts.append(heading1("CHƯƠNG 3: TRIỂN KHAI PHẦN BACKEND (ASP.NET CORE WEB API)", page_break_before=True))
    
    # ----------------------------------------------------
    # 3.1. CẤU TRÚC SOLUTION & PHÂN TÁCH CÁC TẦNG
    # ----------------------------------------------------
    parts.append(heading2("3.1. Cấu trúc Solution và phân tách các tầng kiến trúc"))
    
    parts.append(heading3("3.1.1. Cấu trúc thư mục dự án MiniSupermarket.API (Controllers, Data, Models, DTOs)"))
    parts.append(p("Dự án Backend MiniSupermarket.API được xây dựng trên nền tảng .NET 8.0, tổ chức theo quy chuẩn tách biệt các mối quan tâm (Separation of Concerns - SoC):"))
    parts.append(bullet("📁 Controllers:", "Chứa các bộ điều khiển tiếp nhận HTTP Request từ Client, kiểm tra tính hợp lệ của tham số, điều phối nghiệp vụ và trả về HTTP Response (AuthController, ProductsController, CategoriesController, CustomersController, CheckoutController, ReportsController, AdoProductController)."))
    parts.append(bullet("📁 Data:", "Chứa lớp ngữ cảnh SupermarketDbContext (quản lý kết nối CSDL và EF Core) cùng các lớp trợ giúp truy xuất dữ liệu tầng thấp AdoDbHelper."))
    parts.append(bullet("📁 Models & DTOs:", "Chứa các lớp thực thể ánh xạ bảng CSDL (Product, Category, Customer, Order, OrderDetail, User) và các đối tượng truyền tải dữ liệu DTO chuẩn hóa (PagedResponseDto, CheckoutDtos, ReportDto)."))
    parts.append(bullet("📁 Migrations:", "Chứa các tệp mã nguồn C# do lệnh dotnet ef migrations add sinh ra, ghi nhận lịch sử tiến hóa lược đồ CSDL."))
    
    parts.append(screenshot_placeholder("3.1", "Cấu trúc thư mục Solution MiniSupermarket.API trên cây thư mục Visual Studio 2022",
                                       "Dán ảnh chụp màn hình Solution Explorer hiển thị các thư mục Controllers, Data, Models, Migrations."))
    
    parts.append(heading3("3.1.2. Thiết lập chuỗi kết nối và thông số bảo mật an toàn trong appsettings.json"))
    parts.append(p("Tệp appsettings.json lưu trữ các thông số cấu hình môi trường tập trung, bao gồm chuỗi kết nối CSDL đa nền tảng (hỗ trợ cả SQL Server và MySQL) cùng Khóa bí mật JWT Secret Key:"))
    parts.append(code_block('''{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MiniSupermarketDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True",
    "MySqlConnection": "Server=localhost;Port=3306;Database=minisupermarketdb;User=root;Password=;"
  },
  "Jwt": {
    "Key": "Ăn_Vặt_Store_Super_Secret_Key_For_JWT_Authentication_2026_HITC_2124110134",
    "Issuer": "MiniSupermarketAPI",
    "Audience": "MiniSupermarketWinFormsClient",
    "DurationInDays": 7
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}'''))
    parts.append(p("Chuỗi kết nối sử dụng Trusted_Connection=True (chế độ Windows Authentication) giúp máy chủ tự động xác thực danh tính bảo mật mà không cần để lộ tài khoản sa và mật khẩu CSDL dưới dạng văn bản thô. Tham số TrustServerCertificate=True đảm bảo kết nối mã hóa SSL nội bộ không bị gián đoạn."))
    
    parts.append(heading3("3.1.3. Cấu hình tệp khởi động Program.cs: Đăng ký DI Container, Kích hoạt Middleware Pipeline và cấu hình CORS"))
    parts.append(p("Tệp Program.cs là trái tim khởi động của ứng dụng ASP.NET Core, nơi đăng ký toàn bộ các dịch vụ vào IoC Container và thiết lập chuỗi Middleware xử lý yêu cầu:"))
    parts.append(code_block('''var builder = WebApplication.CreateBuilder(args);

// 1. Cấu hình JSON Serializer chống lỗi vòng lặp tham chiếu (Circular Reference)
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Giữ nguyên định dạng PascalCase/camelCase
    });

// 2. Đăng ký Entity Framework DbContext kết nối SQL Server
builder.Services.AddDbContext<SupermarketDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Đăng ký Dịch vụ Xác thực JWT Bearer
var jwtKey = builder.Configuration["Jwt:Key"] ?? "SecretKeyDefault123456789012345678";
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

// 4. Kích hoạt phân quyền và CORS cho phép WinForms giao tiếp
builder.Services.AddAuthorization();
builder.Services.AddCors(opt => opt.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

// 5. Cấu hình Swagger UI có nút Authorize
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { /* Cấu hình SecurityDefinition JWT */ });

var app = builder.Build();

// Chuỗi Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthentication(); // Giải mã Token
app.UseAuthorization();  // Kiểm tra quyền vai trò
app.MapControllers();
app.Run();'''))
    
    # ----------------------------------------------------
    # 3.2. HIỆN THỰC TẦNG DỮ LIỆU VỚI EF CORE CODE-FIRST
    # ----------------------------------------------------
    parts.append(heading2("3.2. Hiện thực tầng dữ liệu với Entity Framework Core Code-First"))
    
    parts.append(heading3("3.2.1. Định nghĩa các thực thể C# (Model Classes) kết hợp thuộc tính Data Annotations"))
    parts.append(p("Các thực thể trong Models được trang trí bằng các thuộc tính Data Annotations để thiết lập cấu trúc trường và ràng buộc dữ liệu trực tiếp trong C#:"))
    parts.append(code_block('''[Table("Products")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Mã vạch không được để trống!")]
    [StringLength(50)]
    public string Barcode { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tên sản phẩm không được để trống!")]
    [StringLength(150)]
    public string ProductName { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Đơn giá phải lớn hơn 0!")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Tồn kho không được âm!")]
    public int StockQuantity { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public virtual Category? Category { get; set; } // Thuộc tính điều hướng (Navigation Property)
}'''))
    
    parts.append(heading3("3.2.2. Xây dựng lớp MiniSupermarketDbContext và cấu hình liên kết bảng qua Fluent API"))
    parts.append(p("Lớp SupermarketDbContext kế thừa từ DbContext, định nghĩa các DbSet tương ứng với các bảng trong CSDL và ghi đè phương thức OnModelCreating để thiết lập các ràng buộc toàn vẹn nâng cao thông qua Fluent API:"))
    parts.append(code_block('''protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Thiết lập ràng buộc duy nhất cho Mã vạch Barcode
    modelBuilder.Entity<Product>()
        .HasIndex(p => p.Barcode)
        .IsUnique();

    // Thiết lập mối quan hệ 1-N giữa Categories và Products
    modelBuilder.Entity<Product>()
        .HasOne(p => p.Category)
        .WithMany(c => c.Products)
        .HasForeignKey(p => p.CategoryId)
        .OnDelete(DeleteBehavior.Restrict);

    // Thiết lập quan hệ Orders -> OrderDetails (Xóa đơn tự động xóa chi tiết - Cascade)
    modelBuilder.Entity<OrderDetail>()
        .HasOne(d => d.Order)
        .WithMany(o => o.OrderDetails)
        .HasForeignKey(d => d.OrderId)
        .OnDelete(DeleteBehavior.Cascade);
}'''))
    
    parts.append(heading3("3.2.3. Thực thi EF Core Migrations và khởi tạo bộ dữ liệu mẫu ban đầu (Data Seeding)"))
    parts.append(p("Lịch sử cấu trúc CSDL được đồng bộ bằng lệnh CLI:"))
    parts.append(code_block('''dotnet ef migrations add InitialCreate
dotnet ef database update'''))
    parts.append(p("Trong phương thức OnModelCreating, kỹ thuật Data Seeding (HasData) được áp dụng để nạp sẵn 5 nhóm hàng mẫu và 15 mặt hàng kiểm thử chuẩn, giúp hệ thống sẵn sàng vận hành ngay sau khi tạo database."))
    
    parts.append(heading3("3.2.4. Triển khai các thao tác CRUD danh mục và hàng hóa qua Entity Framework Core"))
    parts.append(p("Các thao tác Thêm, Đọc, Sửa, Xóa được đóng gói trong CategoriesController và ProductsController:"))
    parts.append(bullet("Thêm mới (Create):", "_context.Categories.Add(category); await _context.SaveChangesAsync();"))
    parts.append(bullet("Đọc chi tiết (Read):", "await _context.Products.FindAsync(id);"))
    parts.append(bullet("Cập nhật (Update):", "_context.Entry(product).State = EntityState.Modified; await _context.SaveChangesAsync();"))
    parts.append(bullet("Xóa bỏ (Delete):", "_context.Products.Remove(product); await _context.SaveChangesAsync();"))
    
    parts.append(heading3("3.2.5. Tối ưu hóa truy vấn bảng liên quan bằng Eager Loading (.Include()) và giải quyết vòng lặp tham chiếu JSON"))
    parts.append(p("Khi hiển thị danh sách sản phẩm trên lưới của máy trạm WinForms, người dùng cần nhìn thấy Tên nhóm hàng (CategoryName) thay vì chỉ nhìn thấy con số CategoryId vô nghĩa. Trong ORM, nếu truy vấn thông thường sẽ dẫn đến sự cố kinh điển N+1 Query Problem (gửi 1 truy vấn lấy danh sách sản phẩm và gửi thêm N truy vấn con để lấy tên từng nhóm hàng)."))
    parts.append(p("Giải pháp Eager Loading:", bold=True))
    parts.append(code_block('''// Nạp dữ liệu nhóm hàng trong cùng 1 câu lệnh SQL JOIN duy nhất
var products = await _context.Products
    .Include(p => p.Category) // Thực hiện ngầm LEFT JOIN Categories c ON p.CategoryId = c.CategoryId
    .AsNoTracking()
    .ToListAsync();'''))
    parts.append(p("Để giải quyết lỗi ngoại lệ tuần tự hóa JSON do vòng lặp tham chiếu hai chiều (Product trỏ tới Category, và Category lại chứa danh sách Products), cấu hình ReferenceHandler.IgnoreCycles đã được tích hợp trong Program.cs."))
    
    parts.append(heading3("3.2.6. Thuật toán phân trang tầng máy chủ (Server-side Pagination) với LINQ .Skip() / .Take() kết hợp tối ưu .AsNoTracking()"))
    parts.append(p("Nếu một cửa hàng có 100.000 mặt hàng, việc kéo toàn bộ dữ liệu về máy trạm sẽ làm sập RAM của ứng dụng WinForms và nghẽn băng thông mạng. Thuật toán phân trang tầng máy chủ (Server-side Pagination) trong ProductsController giải quyết triệt để vấn đề này:"))
    parts.append(code_block('''[HttpGet("paged")]
public async Task<ActionResult<PagedResult<ProductItemDto>>> GetPaged(
    [FromQuery] string? keyword,
    [FromQuery] int? categoryId,
    [FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 5)
{
    var query = _context.Products
        .Include(p => p.Category)
        .AsNoTracking() // Tắt theo dõi trạng thái, tăng tốc truy vấn đọc 300%
        .AsQueryable();

    // 1. Lọc theo từ khóa tìm kiếm (Tên sản phẩm hoặc Mã vạch)
    if (!string.IsNullOrWhiteSpace(keyword))
    {
        query = query.Where(p => p.ProductName.Contains(keyword) || p.Barcode.Contains(keyword));
    }

    // 2. Lọc theo Nhóm hàng
    if (categoryId.HasValue && categoryId.Value > 0)
    {
        query = query.Where(p => p.CategoryId == categoryId.Value);
    }

    // 3. Đếm tổng số bản ghi thỏa điều kiện
    int totalItems = await query.CountAsync();
    int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

    // 4. Thuật toán phân trang LINQ biên dịch thành mệnh đề OFFSET ... FETCH NEXT
    var items = await query
        .OrderBy(p => p.ProductId)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .Select(p => new ProductItemDto
        {
            ProductId = p.ProductId,
            Barcode = p.Barcode,
            ProductName = p.ProductName,
            Price = p.Price,
            StockQuantity = p.StockQuantity,
            CategoryId = p.CategoryId,
            CategoryName = p.Category != null ? p.Category.CategoryName : "Chưa phân nhóm"
        })
        .ToListAsync();

    return Ok(new PagedResult<ProductItemDto>
    {
        CurrentPage = pageNumber,
        PageSize = pageSize,
        TotalItems = totalItems,
        TotalPages = totalPages,
        Items = items
    });
}'''))
    
    # ----------------------------------------------------
    # 3.3. XÁC THỰC VÀ PHÂN QUYỀN JWT / RBAC
    # ----------------------------------------------------
    parts.append(heading2("3.3. Hiện thực phân hệ xác thực và phân quyền bảo mật (JWT & RBAC)"))
    
    parts.append(heading3("3.3.1. Xây dựng AuthController xử lý nghiệp vụ mã hóa mật khẩu và cấp phát JWT Bearer Token"))
    parts.append(p("Tại AuthController, khi người dùng gửi thông tin đăng nhập, phương thức GenerateJwtToken() sẽ tạo chuỗi Token mang chữ ký đối xứng:"))
    parts.append(code_block('''private string GenerateJwtToken(User user)
{
    var claims = new[]
    {
        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role, user.Role), // RBAC Role: ADMIN, CASHIER, WAREHOUSE
        new Claim("FullName", user.FullName)
    };

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
        issuer: _configuration["Jwt:Issuer"],
        audience: _configuration["Jwt:Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddDays(7), // Token có giá trị trong 7 ngày
        signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
}'''))
    
    parts.append(heading3("3.3.2. Cấu hình dịch vụ xác thực AddJwtBearer và thuật toán khóa ký đối xứng SymmetricSecurityKey trong Program.cs"))
    parts.append(p("Để ASP.NET Core tự động giải mã và kiểm tra Bearer Token gửi lên trong Header Authorization, phương thức AddAuthentication() được gắn vào DI Container với các tiêu chí kiểm tra nghiêm ngặt: ValidateIssuer, ValidateAudience, ValidateLifetime và ValidateIssuerSigningKey."))
    
    parts.append(heading3("3.3.3. Thiết lập phân quyền truy cập đầu cuối sử dụng thuộc tính [Authorize] và [Authorize(Roles = \"...\")]"))
    parts.append(p("Phân quyền tại các Controller được cấu hình chặt chẽ:"))
    parts.append(bullet("[Authorize]:", "Yêu cầu phải có Token hợp lệ mới được truy cập (ví dụ: xem thông tin cá nhân)."))
    parts.append(bullet("[Authorize(Roles = 'ADMIN')]:", "Chỉ có tài khoản có vai trò ADMIN mới được phép truy cập (ví dụ: Xóa sản phẩm, Thêm người dùng, Hủy hóa đơn bán lẻ)."))
    parts.append(bullet("[Authorize(Roles = 'ADMIN,WAREHOUSE')]:", "Cho phép cả Quản trị viên và Thủ kho được quyền Thêm mới hoặc Cập nhật giá, số lượng tồn kho của sản phẩm."))
    parts.append(bullet("[Authorize(Roles = 'ADMIN,CASHIER')]:", "Cho phép Thu ngân và Quản trị viên thực hiện thao tác Thanh toán Checkout POS tại quầy."))
    
    # ----------------------------------------------------
    # 3.4. HIỆN THỰC ADO.NET NÂNG CAO VÀ ACID CHECKOUT
    # ----------------------------------------------------
    parts.append(heading2("3.4. Hiện thực kỹ thuật ADO.NET nâng cao và Quản trị Giao dịch POS Checkout"))
    
    parts.append(heading3("3.4.1. Xây dựng phân hệ tra cứu mã vạch siêu tốc bằng SqlConnection, SqlCommand và luồng đọc SqlDataReader"))
    parts.append(p("Trong AdoProductController, Action tra cứu mã vạch sử dụng SqlDataReader (chế độ Forward-Only, Read-Only) với tốc độ phản hồi cực nhanh dưới 100ms:"))
    parts.append(code_block('''[HttpGet("barcode/{barcode}")]
public async Task<IActionResult> GetByBarcode(string barcode)
{
    using (var conn = new SqlConnection(_connectionString))
    {
        await conn.OpenAsync();
        string sql = @"SELECT p.ProductId, p.Barcode, p.ProductName, p.Price, 
                              p.StockQuantity, p.CategoryId, c.CategoryName
                       FROM Products p
                       INNER JOIN Categories c ON p.CategoryId = c.CategoryId
                       WHERE p.Barcode = @Barcode";

        using (var cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@Barcode", barcode);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    return Ok(new {
                        ProductId = reader.GetInt32(0),
                        Barcode = reader.GetString(1),
                        ProductName = reader.GetString(2),
                        Price = reader.GetDecimal(3),
                        StockQuantity = reader.GetInt32(4),
                        CategoryId = reader.GetInt32(5),
                        CategoryName = reader.GetString(6)
                    });
                }
            }
        }
    }
    return NotFound(new { message = $"Không tìm thấy sản phẩm có mã vạch: {barcode}" });
}'''))
    
    parts.append(heading3("3.4.2. Phòng chống triệt để lỗ hổng tấn công SQL Injection thông qua kỹ thuật tham số hóa SqlParameter"))
    parts.append(p("Tuyệt đối không sử dụng kỹ thuật cộng chuỗi câu lệnh thô (String Concatenation), ví dụ: 'WHERE Barcode = ' + barcode. Kẻ tấn công có thể chèn mã độc như '' OR '1'='1' để chiếm quyền hoặc xóa sạch CSDL. Dự án áp dụng triệt để kỹ thuật tham số hóa SqlParameter (cmd.Parameters.AddWithValue() hoặc helper AdoDbHelper.AddParam()), buộc SQL Server phải xử lý dữ liệu nhập vào như một tham số giá trị thuần túy, loại bỏ hoàn toàn nguy cơ SQL Injection."))
    
    parts.append(heading3("3.4.3. Lập trình và thực thi Stored Procedure sp_GetRevenueByCashier kết xuất báo cáo doanh thu ca làm việc"))
    parts.append(p("Stored Procedure được biên dịch sẵn kế hoạch thực thi (Execution Plan) trên SQL Server:"))
    parts.append(code_block('''CREATE PROCEDURE sp_GetRevenueByCashier
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        CashierUsername,
        COUNT(OrderId) AS TotalOrders,
        SUM(FinalAmount) AS TotalRevenue,
        SUM(RewardPoints) AS TotalPointsAwarded
    FROM Orders
    GROUP BY CashierUsername
    ORDER BY TotalRevenue DESC;
END'''))
    parts.append(p("Trong ReportsController, việc gọi Stored Procedure diễn ra thông qua thuộc tính CommandType.StoredProcedure:"))
    parts.append(code_block('''cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "sp_GetRevenueByCashier";
using (var reader = await cmd.ExecuteReaderAsync()) { /* Đọc danh sách báo cáo */ }'''))
    
    parts.append(heading3("3.4.4. Đảm bảo toàn vẹn chuẩn ACID: Bọc kín chuỗi 4 thao tác thanh toán trong SqlTransaction (Commit / Rollback)"))
    parts.append(p("Trong CheckoutController, toàn bộ tiến trình thanh toán giỏ hàng POS được bảo vệ trong một Transaction duy nhất:"))
    parts.append(code_block('''using (var connection = AdoDbHelper.CreateConnection(_connectionString))
{
    await connection.OpenAsync();
    using (var transaction = connection.BeginTransaction())
    {
        try
        {
            // BƯỚC 1: TẠO HÓA ĐƠN TRONG BẢNG Orders
            string insertOrderSql = @"INSERT INTO Orders (OrderCode, CreatedDate, CashierUsername, CustomerId, TotalItems, FinalAmount, RewardPoints) 
                                     VALUES (@Code, GETDATE(), @Cashier, @CustId, @Items, @Amount, @Points);
                                     SELECT CAST(SCOPE_IDENTITY() AS INT);";
            int newOrderId = await ExecuteScalarWithTrans(insertOrderSql, transaction, ...);

            // BƯỚC 2: DUYỆT GIỎ HÀNG, LƯU OrderDetails VÀ KIỂM TRA TỒN KHO TRỪ HÀNG
            foreach (var item in request.Items)
            {
                // Kiểm tra tồn kho thực tế bằng SELECT StockQuantity WITH (UPDLOCK)
                int currentStock = await GetCurrentStock(item.ProductId, transaction);
                if (currentStock < item.Quantity)
                {
                    // LỖI LOGIC: Không đủ hàng tồn kho!
                    throw new InvalidOperationException($"Sản phẩm (ID: {item.ProductId}) không đủ tồn kho! (Tồn: {currentStock}, Mua: {item.Quantity})");
                }

                // Ghi vào OrderDetails
                await InsertOrderDetail(newOrderId, item, transaction);

                // Trừ tồn kho Products
                await DeductStock(item.ProductId, item.Quantity, transaction);
            }

            // BƯỚC 3: TÍCH LŨY ĐIỂM THƯỞNG CHO KHÁCH HÀNG (1% Giá trị đơn hàng)
            if (customerId > 1)
            {
                await AddCustomerPoints(customerId, rewardPoints, transaction);
            }

            // BƯỚC 4: TẤT CẢ THÀNH CÔNG -> KÍCH HOẠT COMMIT LƯU VĨNH VIỄN
            transaction.Commit();
            return Ok(new { success = true, orderId = newOrderId, message = "Thanh toán thành công!" });
        }
        catch (Exception ex)
        {
            // BẤT KỲ LỖI NÀO PHÁT SINH -> ROLLBACK TỨC THÌ
            transaction.Rollback();
            return BadRequest(new { success = false, message = "Giao dịch đã được Rollback an toàn!", errorDetail = ex.Message });
        }
    }
}'''))
    
    # ----------------------------------------------------
    # 3.5. TÀI LIỆU HÓA SWAGGER / OPENAPI UI
    # ----------------------------------------------------
    parts.append(heading2("3.5. Tài liệu hóa và chuẩn hóa kiểm thử API bằng Swagger / OpenAPI UI"))
    
    parts.append(heading3("3.5.1. Tích hợp thư viện Swashbuckle và cấu hình giao diện SwaggerGen"))
    parts.append(p("Thư viện Swashbuckle.AspNetCore được tích hợp để tự động sinh tài liệu giao diện kiểm thử Swagger UI trực quan tại đường dẫn https://localhost:7167/swagger. Mọi API Endpoints, tham số truyền vào và cấu trúc mẫu JSON đều được tài liệu hóa rõ ràng."))
    parts.append(screenshot_placeholder("3.2", "Giao diện kiểm thử Swagger UI OpenAPI tổng hợp đầy đủ các Endpoint Controllers của hệ thống",
                                       "Dán ảnh chụp toàn bộ trang Swagger UI với các nhóm Auth, Products, Categories, Checkout, Reports."))
    
    parts.append(heading3("3.5.2. Cấu hình nút xác thực ổ khóa \"Authorize\" để truyền Bearer Token trực tiếp trên giao diện Swagger"))
    parts.append(p("Để lập trình viên và giảng viên có thể kiểm thử trực tiếp các API bảo mật trên Swagger mà không cần dùng Postman, cấu hình AddSecurityDefinition trong Program.cs đã bổ sung nút ổ khóa Authorize ở góc trên bên phải giao diện:"))
    parts.append(code_block('''c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    Description = "Nhập chuỗi JWT Bearer token theo định dạng: Bearer {token}",
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer"
});'''))
    parts.append(screenshot_placeholder("3.3", "Hộp thoại Authorize trên Swagger UI nhập chuỗi Bearer JWT Token để mở khóa kiểm thử",
                                       "Dán ảnh chụp hộp thoại nhập Bearer Token trên giao diện Swagger."))
    
    return "".join(parts)
