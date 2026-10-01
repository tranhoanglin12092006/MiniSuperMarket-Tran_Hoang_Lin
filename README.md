# 🛒 Ăn Vặt Store System

<p align="center">
  <b>Hệ thống quản lý cửa hàng đồ ăn vặt toàn diện</b><br>
  <span>Xây dựng trên nền tảng .NET 8.0 với mô hình Client-Server (ASP.NET Core Web API & Windows Forms)</span>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET 8.0">
  <img src="https://img.shields.io/badge/ASP.NET%20Core-Web%20API-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt="ASP.NET Core">
  <img src="https://img.shields.io/badge/Entity%20Framework-Core-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt="EF Core">
  <img src="https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=white" alt="SQL Server">
  <img src="https://img.shields.io/badge/Windows%20Forms-Desktop%20Client-0078D4?style=flat-square&logo=windows&logoColor=white" alt="WinForms">
  <img src="https://img.shields.io/badge/JWT-Authentication-000000?style=flat-square&logo=json-web-tokens&logoColor=white" alt="JWT">
</p>

---

## 📌 1. Giới thiệu dự án

**Ăn Vặt Store System** là đồ án/bài tập thực hành môn **Lập trình Ứng dụng .NET Core**. Bắt đầu từ Buổi 3, hệ thống đã được nâng cấp chuyển đổi hoàn toàn từ lưu trữ tạm thời *(In-Memory)* sang sử dụng **Microsoft SQL Server** thông qua **Entity Framework Core (Code-First approach)**, đảm bảo tính toàn vẹn và lưu trữ dữ liệu vĩnh viễn ngay cả khi khởi động lại ứng dụng.

### ✨ Chức năng cốt lõi
* 🗄️ **Kết nối & Quản lý Cơ sở dữ liệu:** Tích hợp Microsoft SQL Server qua EF Core.
* 🏗️ **Code-First & Migration:** Tự động khởi tạo cấu trúc cơ sở dữ liệu và quản lý phiên bản migration.
* 🌱 **Data Seeding:** Khởi tạo sẵn dữ liệu mẫu (Danh mục, Sản phẩm, Khách hàng) ngay khi chạy ứng dụng.
* 🔍 **Truy vấn nâng cao:** Sử dụng LINQ kết hợp các câu lệnh bất đồng bộ (`Async/Await`) tối ưu hiệu năng.
* 📦 **Quản lý toàn diện:** Danh mục sản phẩm (Category), Sản phẩm (Product), và Khách hàng (Customer).
* 🔐 **Bảo mật phân quyền:** Xác thực người dùng bằng **JWT Bearer Token (JSON Web Token)**.
* 🖥️ **WinForms Client:** Giao diện desktop thân thiện kết nối trực tiếp với Web API qua `HttpClient`.

---

## 🏗️ 2. Kiến trúc hệ thống

```text
       👤 USER
          │
          ▼
┌─────────────────────┐
│   Windows Forms     │
│      Client         │
└──────────┬──────────┘
          │ HTTP / JSON (Bearer Token)
          ▼
┌─────────────────────┐
│   ASP.NET Core API  │
│                     │
│ JWT + Controllers   │
└──────────┬──────────┘
          │
          ▼
┌─────────────────────┐
│ Entity Framework    │
│ Core / LINQ         │
└──────────┬──────────┘
          │
          ▼
┌─────────────────────┐
│     SQL Server      │
│  MiniSupermarketDb  │
└─────────────────────┘
```

---

## 🛠️ 3. Công nghệ sử dụng

| Thành phần | Công nghệ |
| :--- | :--- |
| **Ngôn ngữ lập trình** | C# |
| **Framework** | .NET 8.0 |
| **Backend API** | ASP.NET Core Web API |
| **Frontend Client** | Windows Forms (WinForms) |
| **Database** | Microsoft SQL Server |
| **ORM** | Entity Framework Core (Code-First) |
| **Truy vấn** | LINQ & Async/Await |
| **Bảo mật** | JWT (JSON Web Token) Bearer Authentication |
| **Kiểm thử API** | Swagger / OpenAPI |
| **Giao tiếp mạng** | HttpClient |

---

## 📂 4. Cấu trúc Solution

```text
MiniSupermarketSystem/
│
├── MiniSupermarket.API/
│   ├── Controllers/
│   │   ├── AuthController.cs
│   │   ├── CategoriesController.cs
│   │   ├── ProductsController.cs
│   │   └── CustomersController.cs
│   │
│   ├── Models/
│   │   ├── Category.cs
│   │   ├── Product.cs
│   │   ├── Customer.cs
│   │   └── LoginRequestDto.cs
│   │
│   ├── Data/
│   │   └── SupermarketDbContext.cs
│   │
│   ├── Migrations/
│   ├── appsettings.json
│   └── Program.cs
│
└── MiniSupermarket.WinForms/
    ├── FormLogin.cs
    ├── FormCategoryManagement.cs
    ├── FormProductManagement.cs
    ├── FormCustomerManagement.cs
    ├── SessionManager.cs
    └── Program.cs
```

---

## 📦 5. Cài đặt các NuGet Packages

Chạy các lệnh sau tại thư mục project `MiniSupermarket.API`:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet add package System.IdentityModel.Tokens.Jwt
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

dotnet restore
```
*(Nếu gặp lỗi cache NuGet, chạy lệnh: `dotnet nuget locals all --clear` rồi chạy lại `dotnet restore`)*

---

## 🔌 6. Cấu hình kết nối cơ sở dữ liệu

Cấu hình chuỗi kết nối (`ConnectionStrings`) trong file `appsettings.json` của project `MiniSupermarket.API`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=MiniSupermarketDb;User Id=sa;Password=your_password;TrustServerCertificate=True"
  }
}
```
> ⚠️ **Lưu ý:** Thay đổi thông tin `User Id` và `Password` phù hợp với cấu hình SQL Server máy tính của bạn. Không lưu thông tin mật khẩu thật lên các kho lưu trữ công khai.

---

## 🔄 7. Chạy Migration & Khởi tạo Database

Mở **Package Manager Console** trong Visual Studio, chọn **Default project** là `MiniSupermarket.API` và chạy các lệnh:

```powershell
# Tạo các migration files từ Code-First Models
Add-Migration InitialCreateDatabase

# Cập nhật và khởi tạo Database trên SQL Server
Update-Database
```

---

## 🌐 8. Danh sách API Endpoints

* **📦 Categories (`/api/categories`)**: Quản lý danh mục sản phẩm (CRUD & Tìm kiếm theo từ khóa).
* **🛍️ Products (`/api/products`)**: Quản lý thông tin hàng hóa, giá cả, tồn kho.
* **👥 Customers (`/api/customers`)**: Quản lý thông tin khách hàng, điểm thưởng và hạng thành viên.
* **🔐 Auth (`/api/auth`)**: Xác thực đăng nhập hệ thống và cấp phát JWT Token.

---

## 🎓 9. Thông tin sinh viên

* **Họ và tên:** Trần Hoàng Lin
* **Mã sinh viên:** 2124110134
* **Lớp:** CCQ2411D
* **Môn học:** Lập trình Ứng dụng .NET Core
* **Mã môn học:** 229162
* **Nội dung thực hành:** Buổi 3 – SQL Server & Entity Framework Core Code-First

---

## 📄 License
Được phát triển bởi **Trần Hoàng Lin** phục vụ cho mục đích học tập.  
© 2026 – Ăn Vặt Store System. All rights reserved.
