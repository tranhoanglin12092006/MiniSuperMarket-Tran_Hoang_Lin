🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)
Môn học: Lập trình Ứng dụng .NET Core (Mã môn: 229162)
Buổi thực hành: Buổi 2 - Bảo mật & Phân quyền JWT cho Web API (Backend & WinForms Client)
🏗️ 1. Mô hình Kiến trúc & Bảo mật Buổi 2
Tiếp nối buổi thực hành CRUD cơ bản, hệ thống được nâng cấp toàn diện về mặt bảo mật với mô hình Stateless Authentication:
MiniSupermarket.API (Backend): Tích hợp JwtBearer Authentication, xây dựng AuthController cấp phát token, phân quyền chi tiết bằng thuộc tính [Authorize(Roles = "...")] (Phân biệt quyền Admin và Cashier).
MiniSupermarket.WinForms (Frontend Client): Bổ sung giao diện đăng nhập (FormLogin), quản lý phiên làm việc thông qua lớp tĩnh SessionManager và tự động đính kèm Bearer Token vào Header trong mỗi gói tin HTTP.
🛠️ 2. Công nghệ & Thư viện Sử dụng
Ngôn ngữ: C# (.NET 8.0)
Bảo mật Backend: ASP.NET Core Authentication, JWT (System.IdentityModel.Tokens.Jwt, Microsoft.AspNetCore.Authentication.JwtBearer)
Kiểm thử API: Swagger UI (Hỗ trợ cấu hình Authorize Bearer Token)
Frontend Client: Windows Forms (.NET 8.0), System.Net.Http.Json, JsonDocument
📂 3. Cấu trúc Solution cập nhật
MiniSupermarketSystem/
│
├── MiniSupermarket.API/          # Dự án Web API (Backend)
│   ├── Controllers/             
│   │   ├── AuthController.cs     # Xử lý đăng nhập và sinh JWT Token
│   │   └── CategoriesController.cs # Được bảo vệ bằng [Authorize] & phân quyền Role
│   ├── Models/                   # Chứa Category.cs, LoginRequestDto.cs
│   └── Program.cs                # Cấu hình dịch vụ JWT Bearer & Middleware bảo mật
│
└── MiniSupermarket.WinForms/     # Dự án Windows Forms (Frontend Client)
    ├── FormLogin.cs              # Giao diện đăng nhập hệ thống
    ├── FormCategoryManagement.cs # Giao diện CRUD danh mục (Đính kèm Bearer Token)
    ├── SessionManager.cs         # Quản lý Token và Vai trò người dùng tạm thời
    └── Program.cs                # Đặt FormLogin làm điểm khởi chạy đầu tiên


🚀 4. Hướng dẫn Cấu hình, Chạy và Kiểm thử Bảo mật
Bước 1: Cài đặt thư viện NuGet cho Backend
Tại project MiniSupermarket.API, cài đặt 2 gói NuGet sau:
System.IdentityModel.Tokens.Jwt
Microsoft.AspNetCore.Authentication.JwtBearer
(Nếu gặp lỗi cache, chạy lệnh dotnet nuget locals all --clear trên CMD/PowerShell).
Bước 2: Chạy và Kiểm thử trên Swagger UI (Backend)
Nhấn F5 để chạy dự án MiniSupermarket.API. Trình duyệt sẽ mở giao diện Swagger.
Kiểm tra chặn bảo mật: Thử gọi GET /api/categories mà không có token -> Nhận mã lỗi 401 Unauthorized.
Đăng nhập lấy Token:
Gọi POST /api/auth/login với tài khoản mẫu:
Admin: admin / 123456 (Quyền quản trị toàn hệ thống)
Cashier: cashier / 123456 (Quyền thu ngân POS)
Copy chuỗi token trả về từ Response Body.
Xác thực trên Swagger: Click nút Authorize ở góc trên bên phải, nhập định dạng: Bearer <chuỗi_token_vừa_copy>.
Kiểm tra phân quyền: Thử gọi các endpoint kiểm tra quyền riêng biệt (admin-dashboard và staff-pos) để quan sát cơ chế phân quyền 200 OK / 403 Forbidden.
Bước 3: Chạy và Trải nghiệm WinForms Client
Đảm bảo cấu hình BaseAddress trong ứng dụng WinForms khớp với cổng https://localhost:XXXXX/api/ của Web API.
Đặt FormLogin làm Startup trong Program.cs của project MiniSupermarket.WinForms.
Nhấn F5 chạy ứng dụng WinForms, nhập tài khoản đăng nhập để hệ thống tự động lưu trữ token vào SessionManager và điều hướng sang màn hình quản lý danh mục an toàn.
👨‍💻 5. Tác giả
Họ tên sinh viên: Trần Hoàng Lin
Mã sinh viên: 2124110134
Lớp học phần: CCQ2411D
