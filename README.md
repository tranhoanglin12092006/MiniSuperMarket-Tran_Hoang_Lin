# 🛒 MiniSupermarket POS - Buổi 5: ADO.NET Nâng Cao, Stored Procedure & Giao Dịch POS Checkout

<p align="center">
  <img src="https://img.shields.io/badge/Buổi_5-ADO.NET_Nâng_Cao-FF5722?style=for-the-badge&logo=databricks&logoColor=white" alt="Buổi 5" />
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 8" />
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white" alt="MySQL" />
  <img src="https://img.shields.io/badge/Windows_Forms-0078D7?style=for-the-badge&logo=windows&logoColor=white" alt="WinForms" />
  <img src="https://img.shields.io/badge/ASP.NET_Core_WebAPI-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="Web API" />
  <img src="https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black" alt="Swagger" />
</p>

> **Hệ thống Quản lý Bán lẻ & Tồn kho Siêu thị Mini (MiniSupermarket POS) - Buổi 5**  
> Ứng dụng tích hợp đa nền tảng gồm **ASP.NET Core Web API**, **Windows Forms Desktop App (Single-Form Shell)** và **Console ADO.NET Benchmarking**, tập trung vào **ADO.NET thuần (Connected/Disconnected)**, **Stored Procedure** và **Kiểm soát giao dịch ACID POS Checkout**.

---

## 👨‍💻 Thông Tin Tác Giả & Đồ Án
* **Sinh viên thực hiện:** Trần Hoàng Lin
* **Mã số sinh viên (MSSV):** `2124110134`
* **Môn học / Chuyên đề:** Lập trình C# / .NET Nâng cao
* **Phiên bản:** v2.0 (Cập nhật Kiến trúc Single-Form Shell, RBAC & ADO.NET Nâng cao)

---

## 🏛 Cấu Trúc Solution (`MiniSuperMarket-Tran_Hoang_Lin.sln`)

Solution được thiết kế theo mô hình phân tầng hướng dịch vụ (Service-Oriented Tiered Architecture):

```text
MiniSuperMarket-Tran_Hoang_Lin/
├── 📁 MiniSupermarket.API/             # Backend RESTful Web API (.NET 8)
│   ├── 📁 Controllers/                # API Endpoints (EF Core & ADO.NET thuần)
│   │   ├── AdoProductController.cs    # Quét mã vạch (<100ms) & Disconnected Cache (DataTable)
│   │   ├── CheckoutController.cs      # POS Checkout đa bảng bọc kín trong DbTransaction
│   │   ├── ReportsController.cs       # Báo cáo Stored Procedure (Thu ngân, Top SP, Doanh thu)
│   │   ├── AuthController.cs          # Xác thực JWT Token & Kiểm tra mật khẩu BCrypt
│   │   ├── ProductsController.cs      # CRUD Sản phẩm qua Entity Framework Core
│   │   ├── CategoriesController.cs    # Quản lý Danh mục hàng hóa
│   │   ├── CustomersController.cs     # Quản lý Khách hàng & Tích điểm thành viên
│   │   ├── UsersController.cs         # Quản lý Nhân viên & Phân quyền hệ thống
│   │   └── OrdersController.cs        # Lịch sử đơn hàng & Hóa đơn
│   ├── 📁 Data/                       # Ngữ cảnh dữ liệu & Bộ hỗ trợ kết nối
│   │   ├── AdoDbHelper.cs             # Helper kết nối CSDL linh hoạt (MySQL / SQL Server)
│   │   └── SupermarketDbContext.cs    # EF Core DbContext với Fluent API cấu hình quan hệ
│   ├── 📁 Models/                     # DTOs, Entities & Enums dữ liệu
│   └── appsettings.json               # Chuỗi kết nối CSDL & Cấu hình JWT
│
├── 📁 MiniSupermarket.WinForms/        # Desktop Client - Giao diện người dùng (.NET 8 WinForms)
│   ├── FormLogin.cs                   # Màn hình Đăng nhập (Xác thực qua Web API / Session)
│   ├── FormMainShell.cs               # Khung điều hướng duy nhất (Single-Form Architecture)
│   ├── FormPOS.cs                     # Bàn thu ngân POS: Quét Barcode, Lưới giỏ hàng, Thanh toán
│   ├── FormProductManagement.cs       # Quản lý kho, tồn kho, tra cứu & lọc danh mục
│   ├── FormCategoryManagement.cs      # Quản lý danh mục ngành hàng
│   ├── FormCustomerManagement.cs      # Quản lý thành viên & tra cứu số điện thoại
│   ├── FormUserManagement.cs          # Quản trị tài khoản nhân viên & gán vai trò RBAC
│   ├── FormQuickReport.cs             # Dashboard báo cáo doanh thu nhanh cho Admin
│   └── SessionManager.cs              # Quản lý phiên làm việc & thông tin tài khoản đăng nhập
│
├── 📁 ThucHanhAdoNet/                  # Console App thực hành & kiểm chứng hiệu năng ADO.NET
│   └── Program.cs                     # Menu kiểm thử: ExecuteScalar, SqlParameter, DataReader, Rollback
│
├── 📄 Buoi5_Setup_MySql.sql           # Script khởi tạo Stored Procedure trên MySQL (XAMPP)
├── 📄 Buoi5_Setup_MiniSupermarketDb.sql# Script khởi tạo Database & Stored Procedure trên SQL Server
├── 📄 Huong_Dan_Chay_Va_Test_Buoi_5.docx # Tài liệu Word hướng dẫn chạy và kiểm thử chi tiết
└── 📄 README.md                       # Tài liệu hướng dẫn dự án
```

---

## 🌟 Tính Năng Nổi Bật

### 1. Kiến Trúc WinForms Single-Form Shell & Dynamic Child Forms
* **Giao diện đơn khung đồng nhất:** Loại bỏ việc mở nhiều cửa sổ rời rạc (`MDI`), toàn bộ màn hình nghiệp vụ con được nhúng trực tiếp vào `panelMainContent` (`TopLevel = false`, `Dock = Fill`).
* **Trải nghiệm mượt mà:** Tự động tô sáng tab chức năng đang chọn (`HighlightActiveButton`) và cập nhật tiêu đề trên `panelTopHeader`.

### 2. Kiểm Soát Truy Cập Dựa Trên Vai Trò (Client-Side RBAC)
Hệ thống tự động kiểm tra vai trò người dùng ngay sau khi đăng nhập để cá nhân hóa giao diện và chặn truy cập trái phép:
* **`Admin` (Quản trị viên):** Toàn quyền truy cập tất cả chức năng (Bán hàng, Sản phẩm, Danh mục, Khách hàng, Báo cáo tài chính, Quản lý người dùng).
* **`Cashier` (Thu ngân):** Chỉ truy cập giao diện Bán hàng (`FormPOS`) và Quản lý khách hàng (`FormCustomerManagement`).
* **`Warehouse` (Thủ kho):** Chỉ truy cập Quản lý sản phẩm tồn kho (`FormProductManagement`) và Danh mục (`FormCategoryManagement`).
* **Bảo vệ 2 lớp:** Kết hợp ẩn nút trên Sidebar và chặn kiểm tra logic `SessionManager.Role` ngay tại sự kiện click.

### 3. Giao Dịch POS Checkout & Bảo Toàn Dữ Liệu ACID
* **Tra cứu mã vạch siêu tốc (<100ms):** Sử dụng `SqlDataReader` / `MySqlDataReader` trong chế độ Connected Mode để phản hồi kết quả quét barcode ngay tức thì.
* **Bộ nhớ đệm ngoại tuyến (Disconnected Mode):** Sử dụng `DataTable` và `DbDataAdapter` nạp dữ liệu danh mục/sản phẩm vào RAM giúp giảm tải cho cơ sở dữ liệu.
* **ACID Transactions:** Giao dịch thanh toán POS 4 bước (`CheckoutController` & `ThucHanhAdoNet`):
  1. Thêm hóa đơn mới (`INSERT INTO Orders`).
  2. Kiểm tra tồn kho từng sản phẩm trong giỏ hàng.
  3. Thêm chi tiết hóa đơn (`INSERT INTO OrderDetails`).
  4. Trừ tồn kho (`UPDATE Products SET StockQuantity = StockQuantity - @Qty`) và tích điểm khách hàng.
  5. Tự động `Rollback()` toàn phần nếu phát sinh bất kỳ lỗi thiếu hàng nào, đảm bảo tính toàn vẹn dữ liệu tuyệt đối.

### 4. Báo Cáo Hiệu Năng Cao Với Stored Procedure
Hệ thống tích hợp các thủ tục lưu trữ tối ưu sẵn trong CSDL:
* `sp_GetRevenueByCashier`: Báo cáo tổng doanh số và số hóa đơn theo từng nhân viên thu ngân.
* `sp_GetRevenueByDateRange`: Thống kê doanh thu theo khoảng ngày tùy chọn.
* `sp_GetTop5SellingProducts`: Phân tích 5 mặt hàng bán chạy nhất hệ thống.

---

## 🔐 Bảng Tài Khoản Kiểm Thử Hệ Thống

| Username | Mật khẩu mặc định | Họ và tên nhân viên | Vai trò (`Role`) | Màn hình mặc định |
| :--- | :---: | :--- | :---: | :--- |
| `admin01` | `123456` | Nguyễn Quản Trị | **Admin** | Quản lý Danh mục hàng |
| `admin02` | `123456` | Trần Giám Đốc | **Admin** | Quản lý Danh mục hàng |
| `cashier01` | `123456` | Lê Thu Ngân | **Cashier** | Quầy thu ngân POS |
| `cashier02` | `123456` | Phạm Bán Hàng | **Cashier** | Quầy thu ngân POS |
| `cashier03` | `123456` | Hoàng Thu Ngân | **Cashier** | Quầy thu ngân POS |
| `ware01` | `123456` | Ngô Quản Kho | **Warehouse** | Quản lý Kho sản phẩm |
| `ware02` | `123456` | Bùi Kiểm Kê | **Warehouse** | Quản lý Kho sản phẩm |
| `ware03` | `123456` | Dương Thủ Kho | **Warehouse** | Quản lý Kho sản phẩm |

*(Mật khẩu đã được băm an toàn bằng thuật toán `BCrypt` trong cơ sở dữ liệu).*

---

## 🛠 Yêu Cầu Cài Đặt (Prerequisites)

1. **.NET SDK:** Phiên bản `.NET 8.0 SDK` trở lên.
2. **Cơ sở dữ liệu (chọn 1 trong 2):**
   * **MySQL (Khuyên dùng):** XAMPP / MySQL Community Server (Cổng mặc định `3306`).
   * **SQL Server:** Microsoft SQL Server 2019/2022 hoặc LocalDB.
3. **IDE đề xuất:** Visual Studio 2022 (v17.8 trở lên) có cài workload *.NET desktop development* và *ASP.NET and web development*, hoặc Visual Studio Code.

---

## 🚀 Hướng Dẫn Chạy Dự Án

### Bước 1: Khởi tạo Cơ sở Dữ liệu

#### Trường hợp sử dụng MySQL (XAMPP):
1. Mở **XAMPP Control Panel** và bật dịch vụ **MySQL** (Port 3306).
2. Mở trình duyệt vào `http://localhost/phpmyadmin`.
3. Nhập kịch bản tạo thủ tục lưu trữ:
   * Mở file [`Buoi5_Setup_MySql.sql`](file:///d:/MiniSuperMarket-Tran_Hoang_Lin/Buoi5_Setup_MySql.sql) và thực thi trên database `tranhoanglin_minisupermarketdb`.

#### Trường hợp sử dụng SQL Server:
1. Mở SQL Server Management Studio (SSMS).
2. Mở file [`Buoi5_Setup_MiniSupermarketDb.sql`](file:///d:/MiniSuperMarket-Tran_Hoang_Lin/Buoi5_Setup_MiniSupermarketDb.sql) và nhấn **Execute (F5)** để tạo trọn gói bảng, dữ liệu mẫu và Stored Procedures.

---

### Bước 2: Cấu hình chuỗi kết nối (`appsettings.json`)

Mở file [`MiniSupermarket.API/appsettings.json`](file:///d:/MiniSuperMarket-Tran_Hoang_Lin/MiniSupermarket.API/appsettings.json) và kiểm tra chuỗi kết nối phù hợp:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=127.0.0.1;Port=3306;Database=tranhoanglin_minisupermarketdb;User=root;Password=;SslMode=None;CharSet=utf8mb4;"
  }
}
```

---

### Bước 3: Chạy Backend Web API & Kiểm thử Swagger

Mở terminal tại thư mục gốc và chạy:

```powershell
dotnet run --project MiniSupermarket.API
```

Sau khi API khởi động, truy cập Swagger UI để kiểm thử:
* **Swagger UI:** [https://localhost:7167/swagger](https://localhost:7167/swagger) hoặc [http://localhost:5150/swagger](http://localhost:5150/swagger)

---

### Bước 4: Chạy ứng dụng WinForms Desktop

Mở một cửa sổ terminal mới và khởi chạy ứng dụng WinForms:

```powershell
dotnet run --project MiniSupermarket.WinForms
```

* Đăng nhập với tài khoản `admin01` (pass: `123456`) để kiểm tra toàn bộ menu.
* Đăng nhập với tài khoản `cashier01` (pass: `123456`) để kiểm tra màn hình POS và phân quyền.
* Thử quét mã vạch mẫu tại POS: `893456789001` (Snack khoai tây), `893456789005` (Coca Cola).

---

### Bước 5: Chạy ứng dụng Console ADO.NET Benchmarking

Dự án Console hỗ trợ kiểm chứng trực tiếp các kỹ thuật ADO.NET cốt lõi:

```powershell
# Chạy tương tác theo menu
dotnet run --project ThucHanhAdoNet

# Hoặc chạy nhanh toàn bộ 4 bài tập thực hành
dotnet run --project ThucHanhAdoNet -- 5
```

**Nội dung kiểm chứng:**
* **Bài 1:** Truy vấn giá trị vô hướng bằng `ExecuteScalar()`.
* **Bài 2:** Cập nhật tồn kho có tham số bằng `ExecuteNonQuery()` + `SqlParameter` (Chống SQL Injection).
* **Bài 3:** Duyệt luồng dữ liệu 1 chiều siêu tốc bằng `SqlDataReader`.
* **Thử nghiệm:** Mô phỏng lỗi gián đoạn để kiểm tra tính năng `Rollback()` tự động của Transaction.

---

## 📡 Danh Sách API Endpoints Chính

| Phương thức | Đường dẫn Endpoint | Công nghệ xử lý | Mô tả nghiệp vụ |
| :---: | :--- | :---: | :--- |
| `POST` | `/api/auth/login` | EF Core + BCrypt | Đăng nhập hệ thống & cấp thông tin phiên |
| `GET` | `/api/ado-products/barcode/{barcode}` | ADO.NET DataReader | Tra cứu sản phẩm bằng mã vạch (<100ms) |
| `GET` | `/api/ado-products/disconnected-cache`| ADO.NET DataTable | Tải dữ liệu đệm ngoại tuyến (Disconnected Mode) |
| `GET` | `/api/ado-products/filter-stock` | ADO.NET DataAdapter | Lọc danh sách sản phẩm theo ngưỡng tồn kho |
| `GET` | `/api/ado-products/category-summary` | ADO.NET DataTable | Thống kê số lượng mặt hàng theo danh mục |
| `GET` | `/api/reports/revenue-by-cashier` | Stored Procedure | Báo cáo doanh số theo từng nhân viên thu ngân |
| `GET` | `/api/reports/revenue-by-date-range` | Stored Procedure | Báo cáo doanh thu theo khoảng thời gian |
| `GET` | `/api/reports/top-selling-products` | Stored Procedure | Thống kê Top 5 sản phẩm bán chạy nhất |
| `POST` | `/api/checkout` | ADO.NET DbTransaction | Giao dịch POS Checkout đa bảng an toàn |
| `DELETE`| `/api/checkout/cancel/{orderId}` | ADO.NET DbTransaction | Hủy đơn hàng và hoàn trả tồn kho tự động |

---

## 📜 Giấy Phép & Bản Quyền
Dự án được xây dựng phục vụ mục đích học tập và nghiên cứu trong khuôn khổ môn học Lập trình .NET.  
Mọi đóng góp và mã nguồn được chia sẻ theo giấy phép [MIT License](LICENSE).
