# 🛒 MINI SUPERMARKET SYSTEM

### Hệ thống quản lý siêu thị mini – Bảo mật & Phân quyền JWT

> **Môn học:** Lập trình Ứng dụng .NET Core
> **Mã môn:** `229162`
> **Buổi thực hành:** Buổi 2 – Bảo mật & Phân quyền JWT
> **Ngôn ngữ:** C# / .NET 8.0

---

## 📌 1. GIỚI THIỆU

**MiniSupermarket System** là hệ thống quản lý siêu thị mini được xây dựng theo mô hình **Web API + Windows Forms Client**.

Ở **Buổi 2**, hệ thống được nâng cấp từ chức năng CRUD cơ bản sang mô hình **Stateless Authentication** sử dụng **JWT (JSON Web Token)**.

Hệ thống tập trung vào:

* 🔐 Xác thực người dùng bằng JWT
* 👥 Phân quyền theo vai trò
* 🛡️ Bảo vệ các API Endpoint
* 🔑 Quản lý phiên đăng nhập trên WinForms
* 📡 Tự động gửi Bearer Token trong HTTP Request
* 🚫 Ngăn chặn truy cập trái phép

---

# 🏗️ 2. KIẾN TRÚC HỆ THỐNG

Hệ thống gồm 2 thành phần chính:

```text
┌─────────────────────────────────────────────┐
│           MINI SUPERMARKET SYSTEM           │
└─────────────────────────────────────────────┘

             🔐 LOGIN
                 │
                 ▼
┌──────────────────────┐
│ MiniSupermarket      │
│ WinForms             │
│                      │
│ • FormLogin          │
│ • SessionManager     │
│ • CategoryManagement │
└──────────┬───────────┘
           │
           │ HTTP Request
           │ Authorization: Bearer JWT
           ▼
┌──────────────────────┐
│ MiniSupermarket.API  │
│                      │
│ • AuthController     │
│ • CategoriesController│
│ • JWT Authentication │
│ • Role Authorization │
└──────────┬───────────┘
           │
           ▼
      🗄️ Database
```

### 🔐 Luồng xác thực

```text
Người dùng
    │
    ▼
FormLogin
    │
    │ username + password
    ▼
POST /api/auth/login
    │
    ▼
AuthController
    │
    │ Kiểm tra tài khoản
    ▼
JWT Token
    │
    ▼
SessionManager
    │
    │ Lưu Token + Role
    ▼
Các API được bảo vệ
    │
    ▼
Authorization: Bearer <token>
```

---

# 🔐 3. CƠ CHẾ BẢO MẬT JWT

Backend sử dụng:

* `ASP.NET Core Authentication`
* `JWT Bearer Authentication`
* `Authorize`
* `Authorize(Roles = "...")`

Ví dụ:

```csharp
[Authorize]
[HttpGet]
public IActionResult GetCategories()
{
    // ...
}
```

Endpoint chỉ cho phép người dùng đã đăng nhập truy cập.

### Phân quyền theo Role

```csharp
[Authorize(Roles = "Admin")]
```

Chỉ tài khoản có Role:

```text
Admin
```

mới có quyền truy cập.

Đối với thu ngân:

```csharp
[Authorize(Roles = "Cashier")]
```

chỉ tài khoản có Role:

```text
Cashier
```

mới được phép truy cập.

---

# 👥 4. HỆ THỐNG PHÂN QUYỀN

| Role         | Quyền                        |
| ------------ | ---------------------------- |
| 👑 `Admin`   | Quản trị hệ thống            |
| 💰 `Cashier` | Thực hiện nghiệp vụ thu ngân |

Ví dụ kiểm tra quyền:

```text
Admin
  │
  ├── /admin-dashboard     → ✅ 200 OK
  └── /staff-pos           → Có thể truy cập nếu được cấp quyền
  

Cashier
  │
  ├── /staff-pos           → ✅ 200 OK
  └── /admin-dashboard     → ❌ 403 Forbidden
```

> **401 Unauthorized:** Chưa xác thực hoặc Token không hợp lệ.
> **403 Forbidden:** Đã xác thực nhưng không có quyền truy cập.

---

# 🛠️ 5. CÔNG NGHỆ SỬ DỤNG

| Thành phần     | Công nghệ                              |
| -------------- | -------------------------------------- |
| Ngôn ngữ       | C#                                     |
| Framework      | .NET 8.0                               |
| Backend        | ASP.NET Core Web API                   |
| Authentication | JWT Bearer                             |
| Authorization  | Role-based Authorization               |
| API Testing    | Swagger UI                             |
| Frontend       | Windows Forms                          |
| HTTP Client    | `HttpClient`                           |
| JSON           | `System.Net.Http.Json`, `JsonDocument` |
| JWT            | `System.IdentityModel.Tokens.Jwt`      |

---

# 📂 6. CẤU TRÚC SOLUTION

```text
MiniSupermarketSystem/
│
├── 📁 MiniSupermarket.API/
│   │
│   ├── 📁 Controllers/
│   │   ├── AuthController.cs
│   │   └── CategoriesController.cs
│   │
│   ├── 📁 Models/
│   │   ├── Category.cs
│   │   └── LoginRequestDto.cs
│   │
│   └── Program.cs
│
└── 📁 MiniSupermarket.WinForms/
    │
    ├── FormLogin.cs
    ├── FormCategoryManagement.cs
    ├── SessionManager.cs
    └── Program.cs
```

### Backend

**`AuthController.cs`**

Chịu trách nhiệm:

* Tiếp nhận thông tin đăng nhập
* Kiểm tra tài khoản
* Xác định Role
* Tạo JWT Token
* Trả Token về Client

**`CategoriesController.cs`**

Chịu trách nhiệm:

* CRUD danh mục
* Kiểm tra JWT
* Kiểm tra quyền truy cập

**`Program.cs`**

Chịu trách nhiệm:

* Cấu hình JWT Authentication
* Cấu hình Authorization
* Đăng ký Middleware
* Cấu hình Swagger

### WinForms

**`FormLogin.cs`**

* Nhập username/password
* Gửi request đăng nhập
* Nhận JWT Token
* Lưu phiên đăng nhập
* Chuyển sang màn hình chính

**`SessionManager.cs`**

Quản lý:

```text
Token
Username
Role
```

**`FormCategoryManagement.cs`**

Thực hiện:

* Hiển thị danh mục
* Thêm danh mục
* Sửa danh mục
* Xóa danh mục
* Tìm kiếm
* Gửi JWT Token khi gọi API

---

# 📦 7. CÀI ĐẶT NUGET PACKAGE

Mở Terminal tại project:

```bash
cd MiniSupermarket.API
```

Cài đặt:

```bash
dotnet add package System.IdentityModel.Tokens.Jwt
```

```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```

Sau đó:

```bash
dotnet restore
```

### 🧹 Nếu gặp lỗi NuGet Cache

Chạy:

```bash
dotnet nuget locals all --clear
```

Sau đó:

```bash
dotnet restore
```

---

# 🚀 8. CHẠY BACKEND

Mở project:

```text
MiniSupermarket.API
```

Sau đó nhấn:

```text
F5
```

hoặc:

```bash
dotnet run
```

Swagger UI sẽ được mở tại địa chỉ tương ứng với cấu hình của project.

Ví dụ:

```text
https://localhost:7123/swagger
```

> Port `7123` chỉ là ví dụ. Hãy sử dụng đúng port được hiển thị khi chạy API.

---

# 🧪 9. KIỂM THỬ JWT TRÊN SWAGGER

## Bước 1 – Kiểm tra khi chưa đăng nhập

Gọi:

```http
GET /api/categories
```

Không gửi Token.

Kết quả mong đợi:

```http
401 Unauthorized
```

Điều này chứng minh API đã được bảo vệ bằng JWT.

---

## Bước 2 – Đăng nhập

Gọi:

```http
POST /api/auth/login
```

### 👑 Tài khoản Admin

```text
Username: admin
Password: 123456
Role: Admin
```

### 💰 Tài khoản Cashier

```text
Username: cashier
Password: 123456
Role: Cashier
```

Sau khi đăng nhập thành công, API trả về JWT Token.

Ví dụ:

```json
{
  "token": "eyJhbGciOiJIUzI1NiIs..."
}
```

---

# 🔑 10. AUTHORIZE TRÊN SWAGGER

Sau khi nhận được Token:

### Bước 1

Nhấn:

```text
Authorize 🔒
```

### Bước 2

Nhập:

```text
Bearer <JWT_TOKEN>
```

Ví dụ:

```text
Bearer eyJhbGciOiJIUzI1NiIs...
```

### Bước 3

Nhấn:

```text
Authorize
```

Sau đó Swagger sẽ tự động gửi Token khi gọi các API yêu cầu xác thực.

---

# 🛡️ 11. KIỂM TRA PHÂN QUYỀN

Có thể sử dụng các Endpoint kiểm tra quyền:

```text
GET /api/auth/admin-dashboard
GET /api/auth/staff-pos
```

### Admin

```text
Admin
  │
  └── admin-dashboard
          │
          └── ✅ 200 OK
```

### Cashier

```text
Cashier
  │
  └── admin-dashboard
          │
          └── ❌ 403 Forbidden
```

Điều này chứng minh hệ thống không chỉ kiểm tra **đăng nhập**, mà còn kiểm tra **vai trò người dùng**.

---

# 🖥️ 12. CHẠY WINFORMS CLIENT

Trước tiên kiểm tra:

```text
BaseAddress
```

Trong WinForms phải trùng với địa chỉ Web API.

Ví dụ:

```csharp
private static readonly HttpClient _client = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7123/api/")
};
```

Nếu API chạy tại:

```text
https://localhost:7123
```

thì WinForms phải sử dụng:

```text
https://localhost:7123/api/
```

---

# 🔐 13. SESSION MANAGER

Sau khi đăng nhập thành công:

```text
FormLogin
    │
    ▼
POST /api/auth/login
    │
    ▼
JWT Token
    │
    ▼
SessionManager
    │
    ├── Token
    ├── Username
    └── Role
```

Các Form tiếp theo có thể sử dụng Token để gọi API.

Header HTTP:

```http
Authorization: Bearer <JWT_TOKEN>
```

---

# ▶️ 14. FORM KHỞI CHẠY

Trong:

```text
MiniSupermarket.WinForms
    └── Program.cs
```

Đặt:

```csharp
Application.Run(new FormLogin());
```

Khi chạy ứng dụng:

```text
Application
     │
     ▼
FormLogin
     │
     ▼
Đăng nhập
     │
     ▼
SessionManager
     │
     ▼
FormCategoryManagement
```

---

# 🧑‍💻 15. TÀI KHOẢN KIỂM THỬ

| Username  | Password | Role      |
| --------- | -------- | --------- |
| `admin`   | `123456` | `Admin`   |
| `cashier` | `123456` | `Cashier` |

> ⚠️ Đây là tài khoản phục vụ mục đích thực hành. Khi triển khai thực tế, không nên sử dụng mật khẩu mẫu hoặc lưu mật khẩu dạng plain text.

---

# ✅ 16. KẾT QUẢ ĐẠT ĐƯỢC

Sau khi hoàn thành Buổi 2, hệ thống có:

* [x] JWT Authentication
* [x] Login API
* [x] Bearer Token
* [x] Role-based Authorization
* [x] Phân quyền `Admin`
* [x] Phân quyền `Cashier`
* [x] Bảo vệ API bằng `[Authorize]`
* [x] Kiểm tra `401 Unauthorized`
* [x] Kiểm tra `403 Forbidden`
* [x] Swagger Authorize
* [x] WinForms Login
* [x] SessionManager
* [x] Tự động gửi JWT Token
* [x] CRUD Category có xác thực

---

# 📊 17. TỔNG QUAN BẢO MẬT

```text
                    USER
                      │
                      ▼
                ┌───────────┐
                │ FormLogin │
                └─────┬─────┘
                      │
               Username + Password
                      │
                      ▼
              ┌───────────────┐
              │ AuthController│
              └───────┬───────┘
                      │
                Verify Account
                      │
                      ▼
                ┌───────────┐
                │ JWT Token │
                └─────┬─────┘
                      │
                      ▼
              ┌───────────────┐
              │SessionManager │
              └───────┬───────┘
                      │
             Bearer Token
                      │
                      ▼
              ┌───────────────┐
              │   Web API     │
              └───────┬───────┘
                      │
              ┌───────┴────────┐
              ▼                ▼
           [Authorize]    [Role Check]
              │                │
              ▼                ▼
          401 / OK          403 / OK
```

---

# 🎓 18. THÔNG TIN SINH VIÊN

**Họ và tên:** Trần Hoàng Lin
**Mã sinh viên:** 2124110134
**Lớp:** CCQ2411D
**Môn học:** Lập trình Ứng dụng .NET Core
**Mã môn:** `229162`
**Buổi thực hành:** Buổi 2 – Bảo mật & Phân quyền JWT

---

## ⭐ MINI SUPERMARKET SYSTEM

> **ASP.NET Core Web API + JWT Authentication + Role-based Authorization + WinForms Client**

**© 2026 – Trần Hoàng Lin**
