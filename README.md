# 🛒 MiniSupermarket POS - Buổi 6: EF Core Nâng Cao, Phân Trang LINQ & Tích Hợp Client - Server

<p align="center">
  <img src="https://img.shields.io/badge/Buổi_6-EF_Core_Nâng_Cao-0078D7?style=for-the-badge&logo=dotnet&logoColor=white" alt="Buổi 6" />
  <img src="https://img.shields.io/badge/Server--side-Pagination_LINQ-10B981?style=for-the-badge&logo=databricks&logoColor=white" alt="Pagination" />
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 8" />
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/Windows_Forms-0078D7?style=for-the-badge&logo=windows&logoColor=white" alt="WinForms" />
  <img src="https://img.shields.io/badge/ASP.NET_Core_WebAPI-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="Web API" />
  <img src="https://img.shields.io/badge/JWT-Bearer_Auth-FF5722?style=for-the-badge&logo=jsonwebtokens&logoColor=white" alt="JWT" />
  <img src="https://img.shields.io/badge/Swagger-OpenAPI-85EA2D?style=for-the-badge&logo=swagger&logoColor=black" alt="Swagger" />
</p>

> **Hệ thống Quản lý Bán lẻ & Tồn kho Siêu thị Mini (MiniSupermarket)**  
> **Mã môn học:** 229162 – Lập trình Ứng dụng | **Thời lượng:** 5 tiết thực hành phòng máy  
> Dự án tích hợp hoàn chỉnh giữa **ASP.NET Core Web API (Backend)** và **Windows Forms Desktop Client**, áp dụng **Eager Loading**, **Phân trang LINQ Server-side**, **Tìm kiếm gần đúng**, kết nối an toàn qua **HttpClient** tập trung và **JWT Bearer Token**.

---

## 👨‍💻 Thông Tin Sinh Viên & Học Phần
* **Họ và tên sinh viên:** Trần Hoàng Lin
* **Mã số sinh viên (MSSV):** `2124110134`
* **Môn học:** Lập trình Ứng dụng
* **Mã môn học:** `229162`
* **Bài thực hành:** Buổi 6 - Entity Framework Core Nâng Cao, Phân Trang LINQ & Tích Hợp Toàn Diện Hệ Thống POS Client - Server

---

## 🏛 Cấu Trúc Solution Toàn Diện (`MiniSuperMarket-Tran_Hoang_Lin.sln`)

Solution gồm **3 Project** phân tách rõ rệt theo mô hình Client-Server hướng dịch vụ:

```text
MiniSuperMarket-Tran_Hoang_Lin/
├── 📁 MiniSupermarket.API/                   # [BACKEND] ASP.NET Core Web API (.NET 8)
│   ├── 📁 Controllers/                      # Bộ điều khiển RESTful API
│   │   ├── ProductsController.cs            # ★ API Phân trang GET /api/products/paged & CRUD EF Core
│   │   ├── CustomersController.cs           # ★ Bài 6.1: Phân trang khách hàng theo điểm thưởng
│   │   ├── CategoriesController.cs          # Quản lý danh mục nhóm hàng hóa
│   │   ├── CheckoutController.cs            # POS Checkout bọc ACID DbTransaction
│   │   ├── AdoProductController.cs          # Tra cứu mã vạch & Cache DataTable thuần ADO.NET
│   │   ├── ReportsController.cs             # Báo cáo Stored Procedure (Doanh thu thu ngân)
│   │   ├── AuthController.cs                # Xác thực đăng nhập & Cấp phát JWT Bearer Token
│   │   ├── UsersController.cs               # Quản trị người dùng & Phân quyền RBAC
│   │   └── OrdersController.cs              # Quản lý hóa đơn & lịch sử đơn hàng
│   ├── 📁 Data/                             # Ngữ cảnh dữ liệu CSDL
│   │   ├── SupermarketDbContext.cs          # EF Core DbContext, Fluent API & Eager Loading
│   │   └── AdoDbHelper.cs                   # Helper mở kết nối ADO.NET đa nền tảng
│   ├── 📁 Models/                           # Thực thể & Data Transfer Objects (DTO)
│   │   ├── PagedResponseDto.cs              # ★ DTO Generic PagedResult<T>, ProductItemDto, CustomerItemDto
│   │   ├── Product.cs                       # Entity Sản phẩm (Barcode, Price, StockQuantity...)
│   │   ├── Category.cs                      # Entity Nhóm hàng (CategoryName...)
│   │   ├── Customer.cs                      # Entity Khách hàng (RewardPoints, MembershipRank...)
│   │   ├── Order.cs & OrderDetail.cs        # Entity Hóa đơn & Chi tiết hóa đơn
│   │   ├── User.cs & Role.cs                # Entity Tài khoản & Vai trò người dùng
│   │   └── CheckoutDtos.cs                  # DTO Thanh toán giỏ hàng POS
│   ├── 📁 Migrations/                       # Lịch sử lược đồ CSDL Code-First
│   ├── appsettings.json                     # Chuỗi kết nối CSDL (MySQL / SQL Server) & Khóa JWT
│   └── Program.cs                           # Cấu hình DI, Authentication JWT, Swagger & Middleware
│
├── 📁 MiniSupermarket.WinForms/              # [CLIENT] Desktop App Windows Forms (.NET 8)
│   ├── 📁 Models/                           # DTOs nhận dữ liệu JSON từ API về Client
│   │   └── ReportDto.cs                     # DTO báo cáo doanh thu
│   ├── FormProductManagement.cs             # ★ Màn hình Quản lý Hàng hóa: Phân trang, Tìm kiếm, Lọc nhóm, CRUD
│   ├── FormProductManagement.Designer.cs    # ★ Giao diện Form: Thanh điều hướng trang (btnPrev, lblPaging, btnNext)
│   ├── FormPOS.cs                           # Quầy thu ngân POS: Quét Barcode phím Enter, Giỏ hàng, Tính tiền
│   ├── FormMainShell.cs                     # Single-Form Shell Architecture: Điều hướng menu mượt mà
│   ├── FormLogin.cs                         # Đăng nhập hệ thống, lưu JWT vào SessionManager
│   ├── FormCategoryManagement.cs            # Quản lý nhóm hàng hóa
│   ├── FormCustomerManagement.cs            # Quản lý danh sách khách hàng & tra cứu SĐT
│   ├── FormUserManagement.cs                # Phân quyền nhân viên (Admin / Cashier / Warehouse)
│   ├── FormQuickReport.cs                   # Báo cáo thống kê doanh thu ca thu ngân
│   └── SessionManager.cs                    # ★ Quản lý phiên làm việc & ApiClientService (AttachToken JWT)
│
├── 📁 ThucHanhAdoNet/                        # [BENCHMARK] Console App thực hành độc lập ADO.NET
│   └── Program.cs                           # Kiểm thử hiệu năng Connected Mode & Disconnected Mode
│
├── 📄 MiniSuperMarket-Tran_Hoang_Lin.sln    # Solution file quản lý toàn bộ 3 projects
├── 📄 Buoi5_Setup_MySql.sql                 # Script Database & Stored Procedures MySQL
├── 📄 Buoi5_Setup_MiniSupermarketDb.sql      # Script Database SQL Server
└── 📄 README.md                             # Tài liệu hướng dẫn đồ án Buổi 6
```

---

## 🔄 Kiến Trúc Tích Hợp Client - Server (Architecture Flow)

```
┌────────────────────────────────────────────────────────────────────────┐
│                   WINDOWS FORMS CLIENT (.NET 8)                        │
│  [FormProductManagement]                   [FormPOS Thu Ngân]          │
│    - Ô tìm kiếm gần đúng (txtSearch)         - Súng quét mã vạch USB   │
│    - ComboBox lọc nhóm (cboFilterCategory)   - Bắt phím nóng F2, F9    │
│    - Phân trang: [<< Prev] Trang 1/3 [Next >>]                         │
└───────────────────────────────────┬────────────────────────────────────┘
                                    │ HTTP Requests (JSON + Bearer Token)
                                    ▼
┌────────────────────────────────────────────────────────────────────────┐
│               ApiClientService (Quản lý HttpClient tập trung)          │
│       - Tự động đính kèm Header: Authorization: Bearer <JWT_Token>     │
│       - Bỏ qua lỗi SSL localhost (Custom Certificate Handler)          │
└───────────────────────────────────┬────────────────────────────────────┘
                                    │ RESTful API Calls
                                    ▼
┌────────────────────────────────────────────────────────────────────────┐
│                BACKEND ASP.NET CORE WEB API (.NET 8)                   │
│   GET /api/products/paged?keyword=...&categoryId=...&page=1&size=5     │
│   GET /api/customers/paged?pageNumber=1&pageSize=5                     │
└───────────────────────────────────┬────────────────────────────────────┘
                                    │ LINQ Query với Eager Loading
                                    ▼
┌────────────────────────────────────────────────────────────────────────┐
│                   ENTITY FRAMEWORK CORE 8 (ORM)                        │
│    .Include(p => p.Category)               --> Tránh lỗi N+1 Query     │
│    .AsNoTracking()                         --> Tối ưu bộ nhớ RAM       │
│    .Where(...)                             --> Lọc theo từ khóa & nhóm │
│    .OrderBy(p => p.ProductId)              --> Sắp xếp ổn định         │
│    .Skip((page - 1) * size).Take(size)     --> Phân trang ở SQL Server │
└───────────────────────────────────┬────────────────────────────────────┘
                                    │ T-SQL: OFFSET ... ROWS FETCH NEXT
                                    ▼
┌────────────────────────────────────────────────────────────────────────┐
│              CƠ SỞ DỮ LIỆU (SQL Server / MySQL Community)             │
│   - Bảng Products (15 sản phẩm mẫu đã nạp)                             │
│   - Bảng Categories (5 nhóm hàng phân loại chuẩn)                      │
│   - Bảng Customers (Điểm tích lũy RewardPoints)                        │
└────────────────────────────────────────────────────────────────────────┘
```

---

## 🎯 Chi Tiết Triển Khai Theo Từng Tiết Học (Buổi 6)

### 📌 Tiết 1 & 2: Xây Dựng API Phân Trang LINQ & Eager Loading
* **Tạo DTO chuẩn hóa Metadata:** Trong [PagedResponseDto.cs](file:///D:/MiniSuperMarket-Tran_Hoang_Lin/MiniSupermarket.API/Models/PagedResponseDto.cs), định nghĩa `PagedResult<T>` đóng gói dữ liệu gồm: `CurrentPage`, `PageSize`, `TotalItems`, `TotalPages`, `Items`.
* **Tránh lỗi N+1 Query bằng Eager Loading:** Sử dụng `.Include(p => p.Category)` để tải kèm dữ liệu `CategoryName` trong cùng một truy vấn duy nhất.
* **Tối ưu bộ nhớ:** Áp dụng `.AsNoTracking()` cho truy vấn chỉ đọc (read-only), giảm tải tài nguyên Change Tracker của EF Core.
* **Thuật toán phân trang tầng máy chủ:**
  $$\text{TotalPages} = \lceil \frac{\text{TotalItems}}{\text{PageSize}} \rceil$$
  $$\text{SkipRows} = (\text{PageNumber} - 1) \times \text{PageSize}$$
  $$\text{TakeRows} = \text{PageSize}$$

### 📌 Tiết 3: Kiểm Thử Swagger UI & Đối Soát Câu Lệnh SQL Sinh Ra
* Endpoint: `GET /api/Products/paged?pageNumber=1&pageSize=5`
* Mệnh đề SQL T-SQL được EF Core biên dịch ngầm:
  ```sql
  SELECT [p].[ProductId], [p].[Barcode], [p].[ProductName], [p].[Price], 
         [p].[StockQuantity], [p].[CategoryId], [c].[CategoryName]
  FROM [Products] AS [p]
  LEFT JOIN [Categories] AS [c] ON [p].[CategoryId] = [c].[CategoryId]
  ORDER BY [p].[ProductId]
  OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY;
  ```
  *(Truy xuất chính xác 5 bản ghi cần thiết, không kéo toàn bộ bảng về máy trạm, giúp ứng dụng không bị tràn RAM khi CSDL có hàng chục ngàn dòng).*

### 📌 Tiết 4 & 5: Kết Nối Toàn Diện Với WinForms Client
* **Quản lý HttpClient tập trung:** Trong [SessionManager.cs](file:///D:/MiniSuperMarket-Tran_Hoang_Lin/MiniSupermarket.WinForms/SessionManager.cs), triển khai `ApiClientService.AttachToken(token)` để tự động đính kèm token vào mọi request:
  ```csharp
  Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
  ```
* **Giao diện Quản lý Hàng hóa [FormProductManagement.cs](file:///D:/MiniSuperMarket-Tran_Hoang_Lin/MiniSupermarket.WinForms/FormProductManagement.cs):**
  * Nạp dữ liệu vào ComboBox: `cboCategory` (form chi tiết) và `cboFilterCategory` (thanh lọc).
  * Hàm bất đồng bộ `LoadProductsPagedAsync()` tải dữ liệu hiển thị lên `dgvProducts`.
  * Tự động vô hiệu hóa `btnPrev` khi ở Trang 1 và `btnNext` khi ở Trang cuối cùng.
  * Hiển thị trạng thái phân trang trực quan: `Trang 1 / 3 (Tổng: 15 SP)`.
  * Đồng bộ CRUD: Sau khi Thêm mới, Cập nhật hoặc Xóa, tự động gọi lại hàm tải trang hiện hành từ API.

---

## 🚀 Bài Tập Thực Hành Mở Rộng Đã Hoàn Thành (Trang 14)

### 1. Bài tập 6.1: Phân trang Khách hàng thân thiết (`Customers`)
* **Endpoint:** `GET /api/customers/paged?keyword=...&pageNumber=1&pageSize=5`
* **Vị trí code:** [CustomersController.cs](file:///D:/MiniSuperMarket-Tran_Hoang_Lin/MiniSupermarket.API/Controllers/CustomersController.cs)
* **Xử lý LINQ:** Sắp xếp giảm dần theo điểm thưởng `RewardPoints` để ưu tiên khách hàng VIP:
  ```csharp
  var query = _context.Customers
      .AsNoTracking()
      .OrderByDescending(c => c.RewardPoints)
      .AsQueryable();
  ```

### 2. Bài tập 6.2: Bộ lọc Sản phẩm theo Nhóm hàng (ComboBox Filter trên WinForms)
* **Backend:** Tiếp nhận thêm tham số `int? categoryId` trong Action `GetPagedProducts`.
* **Frontend WinForms:** Tích hợp sự kiện `cboFilterCategory_SelectedIndexChanged` và phím `Enter` trên ô tìm kiếm, tự động đặt `_currentPage = 1` và gọi lại API lọc theo danh mục đã chọn.

---

## 📋 Bảng Đối Soát Rubric Nghiệm Thu (Trang 14 PDF)

| Tiêu chí | Nội dung nghiệm thu | Kết quả thực tế | Trạng thái |
| :---: | :--- | :--- | :---: |
| **Tiêu chí 1** | **Backend Paging:** Gọi `GET /api/products/paged?pageNumber=1&pageSize=5` trên Swagger trả về HTTP 200 OK kèm Metadata (`CurrentPage`, `TotalItems`, `TotalPages`). | Trả về `200 OK`, `totalItems: 15`, `totalPages: 3`, `pageSize: 5`. | ✅ **ĐẠT 100%** |
| **Tiêu chí 2** | **Eager Loading:** Dữ liệu trả về có chứa trường `categoryName` (tên nhóm hàng) không bị null. | `.Include(p => p.Category)` trả về đầy đủ tên nhóm hàng. | ✅ **ĐẠT 100%** |
| **Tiêu chí 3** | **Tìm kiếm:** Nhập từ khóa tìm kiếm (ví dụ: `Coca`) lọc đúng kết quả và tự động tính lại tổng số trang. | Lọc theo `ProductName` và `Barcode` qua `.Contains()`, tự động tính lại `totalPages`. | ✅ **ĐẠT 100%** |
| **Tiêu chí 4** | **WinForms Paging:** Bấm nút `<< Trang trước` và `Trang sau >>` mượt mà, không bị treo ứng dụng. | Xử lý hoàn toàn bằng `async/await`, `lblPaging` và trạng thái `Enabled` của nút cập nhật tức thì. | ✅ **ĐẠT 100%** |
| **Tiêu chí 5** | **CRUD Hoàn chỉnh:** Thao tác Thêm, Sửa, Xóa từ WinForms cập nhật trực tiếp xuống CSDL. | Gọi API POST, PUT, DELETE đồng bộ và reload trang tự động. | ✅ **ĐẠT 100%** |
| **Mở rộng 6.1** | Phân trang danh sách khách hàng thân thiết theo `RewardPoints` giảm dần. | Đã viết `GET /api/customers/paged` kèm tìm kiếm theo tên / số điện thoại. | ✅ **ĐẠT 100%** |
| **Mở rộng 6.2** | Bổ sung bộ lọc Sản phẩm theo Nhóm hàng (ComboBox Filter). | Đã tích hợp `cboFilterCategory` trên WinForms và `categoryId` trên API. | ✅ **ĐẠT 100%** |

---

## 📦 Dữ Liệu Mẫu Kiểm Thử (15 Sản Phẩm Phân Nhóm)

Hệ thống đã có sẵn 15 sản phẩm mẫu đối soát trực tiếp từ CSDL:

| ID | Mã vạch | Tên sản phẩm | Đơn giá | Tồn kho | Mã nhóm | Tên nhóm hàng |
| :-: | :---: | :--- | :-: | :-: | :-: | :--- |
| **1** | `893456789001` | Snack Khoai Tây O'Star Gói 60g | 12,500 đ | 150 | 1 | Bánh kẹo & Đồ ăn vặt |
| **2** | `893456789002` | Bánh Quy Bơ Danisa Hộp Thiếc 454g | 135,000 đ | 40 | 1 | Bánh kẹo & Đồ ăn vặt |
| **3** | `893456789003` | Kẹo Dẻo Chupa Chups Trái Cây 90g | 15,000 đ | 120 | 1 | Bánh kẹo & Đồ ăn vặt |
| **4** | `893456789004` | Bánh Chocopie Orion Hộp 12 Cái | 54,000 đ | 60 | 1 | Bánh kẹo & Đồ ăn vặt |
| **5** | `893456789005` | Nước Ngọt Coca Cola Lon 320ml | 10,000 đ | 320 | 2 | Nước giải khát & Trà |
| **6** | `893456789006` | Nước Khoáng Lavie Chai 500ml | 6,000 đ | 200 | 2 | Nước giải khát & Trà |
| **7** | `893456789007` | Trà Xanh Không Độ Chai 455ml | 11,000 đ | 180 | 2 | Nước giải khát & Trà |
| **8** | `893456789008` | Nước Tăng Lực Red Bull Lon 250ml | 14,500 đ | 150 | 2 | Nước giải khát & Trà |
| **9** | `893456789009` | Sữa Tươi Tiệt Trùng Vinamilk 1L | 34,500 đ | 85 | 3 | Sữa & Sản phẩm từ sữa |
| **10** | `893456789010` | Phô Mai Con Bò Cười Hộp 8 Miếng | 39,000 đ | 60 | 3 | Sữa & Sản phẩm từ sữa |
| **11** | `893456789011` | Sữa Chua Vinamilk Có Đường Lốc 4 | 28,000 đ | 95 | 3 | Sữa & Sản phẩm từ sữa |
| **12** | `893456789012` | Sữa Đặc Có Đường Ông Thọ Lon 380g | 26,000 đ | 110 | 3 | Sữa & Sản phẩm từ sữa |
| **13** | `893456789013` | Mì Tôm Hảo Hảo Chua Cay Gói 75g | 4,500 đ | 500 | 4 | Mì gói & Ăn liền |
| **14** | `893456789014` | Phở Bò Đệ Nhất Gói 68g | 8,500 đ | 140 | 4 | Mì gói & Ăn liền |
| **15** | `893456789015` | Dầu Ăn Simply Nguyên Chất Can 2L | 125,000 đ | 45 | 5 | Gia vị & Dầu ăn |

---

## 🛠 Hướng Dẫn Cài Đặt & Chạy Kiểm Thử

### Bước 1: Khởi động Backend Web API
1. Mở Visual Studio, đặt **`MiniSupermarket.API`** làm Startup Project (hoặc dùng lệnh Terminal):
   ```bash
   dotnet run --project MiniSupermarket.API
   ```
2. Mở trình duyệt truy cập: `https://localhost:7167/swagger`
3. Tìm đến mục **`GET /api/Products/paged`**, bấm **Try it out**:
   * Để trống ô `keyword` và `categoryId`.
   * Nhập `pageNumber: 1`, `pageSize: 5`.
   * Bấm **Execute** -> Nhận kết quả `200 OK` với 5 sản phẩm đầu tiên và `totalItems: 15`.

### Bước 2: Khởi động WinForms Desktop Client
1. Đặt **`MiniSupermarket.WinForms`** làm Startup Project (hoặc chạy qua Terminal):
   ```bash
   dotnet run --project MiniSupermarket.WinForms
   ```
2. Đăng nhập tài khoản kiểm thử:
   * **Username:** `admin01` (hoặc `ware01`)
   * **Password:** `123456`
3. Nhấp chọn menu **Quản lý sản phẩm**:
   * Kiểm tra lưới hiển thị đúng 5 sản phẩm của trang 1.
   * Nhấp nút **`Trang sau >>`** để chuyển mượt sang trang 2 và trang 3.
   * Thử chọn lọc nhóm **"Nước giải khát & Trà"** từ ComboBox hoặc gõ từ khóa `Coca` để xem dữ liệu cập nhật theo thời gian thực.

---

> [!NOTE]
> Dự án được xây dựng và kiểm nghiệm tương thích hoàn hảo trên nền tảng **.NET 8.0 SDK**, **C# 12**, **Entity Framework Core 8**, **Visual Studio 2022** và **Windows Forms**.
