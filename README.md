# 🛒 MiniSupermarket POS – Buổi 6
### EF Core nâng cao · LINQ phân trang · Tích hợp Client–Server

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" />
  <img src="https://img.shields.io/badge/WinForms-0078D7?style=for-the-badge&logo=windows&logoColor=white" />
  <img src="https://img.shields.io/badge/ASP.NET_Core_Web_API-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/EF_Core-8.0-68217A?style=for-the-badge" />
  <img src="https://img.shields.io/badge/JWT-Authentication-FF5722?style=for-the-badge" />
</p>

**MiniSupermarket POS** là hệ thống quản lý bán hàng và tồn kho siêu thị mini, được xây dựng bằng C# và .NET 8. Dự án tích hợp ứng dụng Windows Forms với ASP.NET Core Web API, sử dụng Entity Framework Core, LINQ, phân trang dữ liệu và xác thực JWT.

---

## 1. Thông tin sinh viên

| Nội dung | Thông tin |
|---|---|
| Họ và tên | Trần Hoàng Lin |
| MSSV | `2124110134` |
| Môn học | Lập trình Ứng dụng |
| Mã môn học | `229162` |
| Bài thực hành | Buổi 6 – EF Core nâng cao và tích hợp Client–Server |

## 2. Công nghệ sử dụng

- **Ngôn ngữ:** C#, .NET 8.
- **Backend:** ASP.NET Core Web API.
- **Frontend:** Windows Forms.
- **ORM:** Entity Framework Core 8.
- **Truy vấn:** LINQ, Eager Loading, AsNoTracking.
- **Xác thực:** JWT Bearer Token.
- **Kiểm thử API:** Swagger / OpenAPI.
- **Database:** SQL Server hoặc MySQL tùy cấu hình kết nối của dự án.

## 3. Cấu trúc Solution

Solution gồm 3 project:

```text
MiniSuperMarket-Tran_Hoang_Lin/
│
├── MiniSupermarket.API/
│   ├── Controllers/
│   │   ├── ProductsController.cs
│   │   ├── CustomersController.cs
│   │   ├── CategoriesController.cs
│   │   ├── CheckoutController.cs
│   │   ├── AuthController.cs
│   │   ├── UsersController.cs
│   │   ├── OrdersController.cs
│   │   ├── ReportsController.cs
│   │   └── AdoProductController.cs
│   ├── Data/
│   │   ├── SupermarketDbContext.cs
│   │   └── AdoDbHelper.cs
│   ├── Models/
│   │   ├── Product.cs
│   │   ├── Category.cs
│   │   ├── Customer.cs
│   │   ├── Order.cs
│   │   ├── OrderDetail.cs
│   │   ├── User.cs
│   │   ├── Role.cs
│   │   ├── CheckoutDtos.cs
│   │   └── PagedResponseDto.cs
│   ├── Migrations/
│   ├── appsettings.json
│   └── Program.cs
│
├── MiniSupermarket.WinForms/
│   ├── Models/
│   ├── FormLogin.cs
│   ├── FormMainShell.cs
│   ├── FormPOS.cs
│   ├── FormProductManagement.cs
│   ├── FormCategoryManagement.cs
│   ├── FormCustomerManagement.cs
│   ├── FormUserManagement.cs
│   ├── FormQuickReport.cs
│   └── SessionManager.cs
│
├── ThucHanhAdoNet/
│   └── Program.cs
│
├── Buoi5_Setup_MySql.sql
├── Buoi5_Setup_MiniSupermarketDb.sql
├── MiniSuperMarket-Tran_Hoang_Lin.sln
└── README.md
```

*Lưu ý: Đây là cấu trúc tổng quan; tên file và thư mục cần khớp với source code thực tế.*

## 4. Kiến trúc hệ thống

Dự án tổ chức theo mô hình 3 tầng logic:

```text
┌──────────────────────────────┐
│       PRESENTATION           │
│   Windows Forms (.NET 8)     │
│   Giao diện người sử dụng    │
└──────────────┬───────────────┘
               │ HTTP / JSON / JWT
               ▼
┌──────────────────────────────┐
│       APPLICATION            │
│   ASP.NET Core Web API       │
│   Xử lý nghiệp vụ và API     │
└──────────────┬───────────────┘
               │ EF Core / ADO.NET
               ▼
┌──────────────────────────────┐
│          DATABASE            │
│       SQL Server / MySQL     │
│   Lưu trữ dữ liệu hệ thống   │
└──────────────────────────────┘
```

**Luồng hoạt động:** WinForms gửi HTTP Request đến Web API. Backend xử lý nghiệp vụ, truy vấn cơ sở dữ liệu và trả kết quả JSON về Client.

## 5. Chức năng chính

### Backend – ASP.NET Core Web API

- Quản lý sản phẩm, danh mục và khách hàng.
- Quản lý tài khoản và phân quyền người dùng.
- Đăng nhập và xác thực bằng JWT.
- Xử lý thanh toán và lưu hóa đơn.
- Báo cáo doanh thu.
- Phân trang, tìm kiếm và lọc dữ liệu.
- Hỗ trợ truy vấn bằng EF Core và ADO.NET.

### Frontend – Windows Forms

- Đăng nhập hệ thống.
- Giao diện quản lý tập trung.
- Quản lý sản phẩm và danh mục.
- Quản lý khách hàng và nhân viên.
- Bán hàng POS, quét mã vạch.
- Quản lý giỏ hàng và thanh toán.
- Báo cáo thống kê doanh thu.

## 6. Nội dung thực hiện Buổi 6

### 6.1. Phân trang dữ liệu bằng LINQ

Sử dụng `Skip()` và `Take()` để phân trang ngay tại Backend, tránh tải toàn bộ dữ liệu về Client.

```csharp
var products = await query
    .OrderBy(p => p.ProductId)
    .Skip((pageNumber - 1) * pageSize)
    .Take(pageSize)
    .ToListAsync();
```

### 6.2. Eager Loading

Sử dụng `.Include(p => p.Category)` để tải thông tin danh mục cùng sản phẩm.

```csharp
var query = _context.Products
    .Include(p => p.Category)
    .AsNoTracking();
```

### 6.3. Tìm kiếm và lọc dữ liệu

Sử dụng `.Contains()` để tìm kiếm gần đúng theo tên sản phẩm hoặc mã vạch.

```csharp
query = query.Where(p =>
    p.ProductName.Contains(keyword) ||
    p.Barcode.Contains(keyword));
```

Có thể kết hợp `categoryId` để lọc sản phẩm theo nhóm hàng.

### 6.4. Phân trang khách hàng

Sắp xếp khách hàng theo điểm thưởng giảm dần:

```csharp
var query = _context.Customers
    .AsNoTracking()
    .OrderByDescending(c => c.RewardPoints);
```

### 6.5. Tích hợp WinForms với Web API

- Sử dụng `HttpClient` để gửi và nhận dữ liệu.
- Đính kèm JWT Bearer Token khi gọi API cần xác thực.
- Sử dụng `async/await` để tránh treo giao diện.
- Hiển thị dữ liệu bằng `DataGridView`.
- Điều khiển phân trang bằng nút Trang trước và Trang sau.
- Tải lại dữ liệu sau khi thêm, sửa hoặc xóa.

## 7. API phân trang tiêu biểu

| Phương thức | Endpoint | Chức năng |
|---|---|---|
| GET | `/api/products/paged` | Phân trang sản phẩm |
| GET | `/api/customers/paged` | Phân trang khách hàng |
| POST | `/api/products` | Thêm sản phẩm |
| PUT | `/api/products/{id}` | Cập nhật sản phẩm |
| DELETE | `/api/products/{id}` | Xóa sản phẩm |

Ví dụ truy vấn:

```http
GET /api/products/paged?pageNumber=1&pageSize=5
```

Các tham số tìm kiếm và lọc như `keyword`, `categoryId` được sử dụng nếu API hỗ trợ.

Thông tin phân trang gồm:

- `CurrentPage`: Trang hiện tại.
- `PageSize`: Số bản ghi mỗi trang.
- `TotalItems`: Tổng số bản ghi.
- `TotalPages`: Tổng số trang.
- `Items`: Danh sách dữ liệu.

## 8. Hướng dẫn cài đặt và chạy dự án

### Yêu cầu môi trường

- Windows 10/11.
- Visual Studio 2022.
- .NET 8 SDK.
- SQL Server hoặc MySQL theo cấu hình dự án.

### Bước 1: Tải source code

```bash
git clone https://github.com/tranhoanglin12092006/MiniSuperMarket-Tran_Hoang_Lin.git
cd MiniSuperMarket-Tran_Hoang_Lin
```

### Bước 2: Cấu hình Database

1. Mở project `MiniSupermarket.API`.
2. Kiểm tra chuỗi kết nối trong `appsettings.json`.
3. Khởi động hệ quản trị cơ sở dữ liệu tương ứng.
4. Tạo database và chạy file SQL phù hợp với hệ quản trị đang sử dụng.
5. Kiểm tra cấu hình EF Core trong `Program.cs`.

**Lưu ý:** Không chạy lẫn script SQL Server và MySQL. Cần chọn đúng script tương ứng với provider đang cấu hình trong Backend.

Nếu dự án sử dụng EF Core Code-First, có thể cập nhật database bằng lệnh:

```bash
dotnet ef database update
```

Lệnh này cần được thực hiện trong đúng project và khi đã cấu hình provider, connection string và migrations phù hợp.

### Bước 3: Chạy Backend API

Mở Terminal tại thư mục chứa Solution:

```bash
dotnet restore
dotnet run --project MiniSupermarket.API
```

Truy cập địa chỉ Swagger theo URL HTTPS/HTTP được hiển thị trong Terminal.

Ví dụ:

```text
https://localhost:7167/swagger
```

*Port có thể thay đổi theo cấu hình `launchSettings.json`.*

### Bước 4: Chạy WinForms Client

Mở Terminal:

```bash
dotnet run --project MiniSupermarket.WinForms
```

Hoặc mở file Solution bằng Visual Studio 2022 và chọn project WinForms làm Startup Project.

**Lưu ý:** Cần kiểm tra `BaseAddress` trong Client để bảo đảm trùng với địa chỉ Backend đang chạy.

### Bước 5: Đăng nhập kiểm thử

Tài khoản demo (nếu đã được tạo trong database):

| Tài khoản | Mật khẩu |
|---|---|
| admin01 | 123456 |
| ware01 | 123456 |

## 9. Kiểm thử và nghiệm thu

| STT | Nội dung kiểm thử | Kết quả mong đợi |
|---|---|---|
| 1 | Gọi API phân trang sản phẩm | HTTP 200 và có metadata |
| 2 | Phân trang 5 sản phẩm mỗi trang | Dữ liệu đúng số lượng |
| 3 | Eager Loading danh mục | Có thông tin tên danh mục |
| 4 | Tìm kiếm bằng Contains | Trả về kết quả phù hợp |
| 5 | Lọc sản phẩm theo danh mục | Hiển thị đúng nhóm hàng |
| 6 | Chuyển trang trên WinForms | Không treo giao diện |
| 7 | Thêm, sửa, xóa sản phẩm | Dữ liệu được cập nhật |
| 8 | Phân trang khách hàng | Sắp xếp theo điểm thưởng |

*Chỉ đánh dấu Đạt sau khi đã chạy thử và đối chiếu kết quả thực tế.*

## 10. Cấu trúc `.gitignore`

Đặt file `.gitignore` tại thư mục gốc, cùng cấp với file `.sln`.

```gitignore
# Visual Studio
.vs/
*.user
*.suo

# .NET
**/bin/
**/obj/

# NuGet
packages/
*.nupkg

# Node.js
node_modules/

# Environment
.env
.env.*

# IDE
.idea/

# Logs
*.log

# Windows
Thumbs.db
Desktop.ini
```

Không đưa các thư mục build, file cấu hình bí mật hoặc thông tin tài khoản thật lên GitHub.

## 11. Xử lý lỗi thường gặp

| Lỗi | Cách xử lý |
|---|---|
| Không kết nối được Database | Kiểm tra dịch vụ DB và connection string |
| Swagger không truy cập được | Kiểm tra Backend và URL/port |
| HTTP 401 Unauthorized | Kiểm tra JWT Token và đăng nhập |
| HTTP 403 Forbidden | Kiểm tra quyền tài khoản |
| Không tìm thấy bảng | Kiểm tra database và migrations |
| WinForms không gọi được API | Kiểm tra `BaseAddress` và trạng thái Backend |

## 12. Tài liệu tham khảo

- [Microsoft – ASP.NET Core](https://learn.microsoft.com/aspnet/core)
- [Microsoft – Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [Microsoft – LINQ](https://learn.microsoft.com/dotnet/csharp/linq/)
- [Microsoft – Windows Forms](https://learn.microsoft.com/dotnet/desktop/winforms/)
- [Microsoft – HttpClient](https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient)

## 13. Kết luận

Dự án MiniSupermarket POS giúp vận dụng kiến thức C# và .NET 8 vào xây dựng hệ thống quản lý bán hàng thực tế. Qua bài thực hành, sinh viên đã tìm hiểu cách xây dựng Web API, sử dụng Entity Framework Core, truy vấn LINQ, phân trang dữ liệu, xác thực JWT và tích hợp ứng dụng Windows Forms với Backend.

**GitHub Repository:**  
https://github.com/tranhoanglin12092006/MiniSuperMarket-Tran_Hoang_Lin

---

<p align="center">
  <b>MINISUPERMARKET POS – BUỔI 6</b><br/>
  <i>ASP.NET Core Web API · Windows Forms · Entity Framework Core</i>
</p>
