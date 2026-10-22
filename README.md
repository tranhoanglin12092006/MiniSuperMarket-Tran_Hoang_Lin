# 🛒 MiniSupermarket POS - Buổi 4: Kiến Trúc Giao Diện WinForms Shell & Phân Quyền RBAC

> **Nền tảng:** `.NET Core WinForms` | **Ngôn ngữ:** `C#` | **Kiến trúc:** `Single-Form Shell` | **Bảo mật:** `Client-side RBAC`
>
> **Tóm tắt Buổi 4:** Thiết kế kiến trúc giao diện đơn khung (**Single-Form Architecture**) kết hợp nhúng động các Form nghiệp vụ (**Dynamic Child Forms**) và kiểm soát truy cập theo vai trò (**Role-Based Access Control - RBAC**) cho hệ thống Quản lý Bán lẻ & Tồn kho Siêu thị Mini.

---

## 🎯 1. Mục Tiêu Trọng Tâm
* **Single-Form Architecture:** Thiết kế giao diện đơn khung (`FormMainShell`) gồm thanh điều hướng trái (**Left Sidebar**) và vùng làm việc trung tâm (**Main Content**).
* **Dynamic Child Forms:** Nhúng động các Form con vào vùng chứa trung tâm (`TopLevel = false`, `Dock = Fill`), không mở nhiều cửa sổ rời rạc.
* **Phân quyền RBAC trên Client:** Tự động ẩn/hiện menu, điều hướng màn hình mặc định và chặn truy cập trái phép theo 3 vai trò: `Admin`, `Cashier` (Thu ngân), và `Warehouse` (Thủ kho).

---

## 🏗 2. Kiến Trúc Giao Diện (UI Layout)

Bố cục màn hình điều khiển trung tâm `FormMainShell` (Độ phân giải chuẩn `1280x720`):

```text
┌─────────────────────────────────────────────────────────────────────────────┐
│                               FormMainShell                                 │
├────────────────────┬────────────────────────────────────────────────────────┤
│  panelSidebar      │  panelTopHeader (Tiêu đề màn hình & Thông tin User)    │
│  (Width = 230)     ├────────────────────────────────────────────────────────┤
│  - Logo MiniMart   │                                                        │
│  - btnPOS          │  panelMainContent (Dock = Fill)                        │
│  - btnCategory     │                                                        │
│  - btnProduct      │     [ VÙNG NHÚNG ĐỘNG CÁC FORM NGHIỆP VỤ CON ]         │
│  - btnCustomer     │     • FormPOS                • FormCustomerManagement  │
│  - btnReports      │     • FormCategoryManagement • FormQuickReport         │
│  - btnUserManage   │     • FormProductManagement  • FormUserManagement      │
│  ───────────────   │                                                        │
│  - btnLogout       │                                                        │
└────────────────────┴────────────────────────────────────────────────────────┘
```

---

## 🔐 3. Ma Trận Phân Quyền (RBAC Matrix)

| Vai trò (`Role`) | Màn hình mặc định khi vào | Các màn hình được phép truy cập | Quyền hạn bị chặn |
| :--- | :--- | :--- | :--- |
| **`Admin`** | Quản lý Danh mục (`FormCategoryManagement`) | `FormPOS`, `FormCategoryManagement`, `FormProductManagement`, `FormCustomerManagement`, `FormQuickReport`, `FormUserManagement` | *Không bị chặn (Toàn quyền hệ thống)* |
| **`Cashier`** | Bán hàng (`FormPOS`) / Khách hàng (`FormCustomerManagement`) | `FormPOS`, `FormCustomerManagement` | Quản lý kho, Sửa giá sản phẩm, Xem báo cáo doanh thu, Quản lý tài khoản |
| **`Warehouse`** | Sản phẩm (`FormProductManagement`) / Danh mục (`FormCategoryManagement`) | `FormProductManagement`, `FormCategoryManagement` | Bán hàng POS, Xem doanh thu, Tạo tài khoản, Quản lý khách hàng |

---

## 👥 4. Bộ Dữ Liệu 15 Tài Khoản Kiểm Thử

| STT | Username | Mật khẩu | Họ và tên nhân viên | Vai trò (`Role`) | Phạm vi chức năng cho phép |
| :-: | :--- | :--- | :--- | :---: | :--- |
| 1 | `admin01` | `123456` | Nguyễn Quản Trị | **Admin** | Toàn quyền toàn bộ hệ thống |
| 2 | `admin02` | `123456` | Trần Giám Đốc | **Admin** | Toàn quyền toàn bộ hệ thống |
| 3 | `cashier01` | `123456` | Lê Thu Ngân | **Cashier** | Màn hình POS, Khách hàng thành viên |
| 4 | `cashier02` | `123456` | Phạm Bán Hàng | **Cashier** | Màn hình POS, Khách hàng thành viên |
| 5 | `cashier03` | `123456` | Hoàng Thu Ngân | **Cashier** | Màn hình POS, Khách hàng thành viên |
| 6 | `cashier04` | `123456` | Vũ Thị Quầy | **Cashier** | Màn hình POS, Khách hàng thành viên |
| 7 | `cashier05` | `123456` | Đỗ Bán Lẻ | **Cashier** | Màn hình POS, Khách hàng thành viên |
| 8 | `ware01` | `123456` | Ngô Quản Kho | **Warehouse** | Sản phẩm, Nhóm hàng, Nhập xuất kho |
| 9 | `ware02` | `123456` | Bùi Kiểm Kê | **Warehouse** | Sản phẩm, Nhóm hàng, Nhập xuất kho |
| 10 | `ware03` | `123456` | Dương Thủ Kho | **Warehouse** | Sản phẩm, Nhóm hàng, Nhập xuất kho |
| 11 | `ware04` | `123456` | Lý Nhập Hàng | **Warehouse** | Sản phẩm, Nhóm hàng, Nhập xuất kho |
| 12 | `admin_backup`| `123456` | Đặng Hỗ Trợ | **Admin** | Toàn quyền toàn bộ hệ thống |
| 13 | `cashier06` | `123456` | Hồ Ca Chiều | **Cashier** | Màn hình POS, Khách hàng thành viên |
| 14 | `ware05` | `123456` | Trương Vận Chuyển | **Warehouse** | Sản phẩm, Nhóm hàng, Nhập xuất kho |
| 15 | `supervisor` | `123456` | Mai Giám Sát | **Admin** | Toàn quyền toàn bộ hệ thống |

---

## 🧩 5. Quy Trình Thực Hành & Mô Tả Các Form Nghiệp Vụ

### 5.1. Khung điều hướng trung tâm (`FormMainShell`)
* **Thiết kế phân vùng:**
  * `panelSidebar` (Trái, rộng 230px, nền xanh đen đậm `RGB(24, 30, 48)`): Chứa Logo MiniMart POS, 6 nút điều hướng chức năng và `panelUserFooter` ở đáy chứa nút Đăng xuất (`btnLogout`).
  * `panelTopHeader` (Trên, cao 60px, nền trắng): Hiển thị tiêu đề màn hình hiện tại (`lblTitle`) và thông tin nhân viên/vai trò đăng nhập (`lblUserInfo`).
  * `panelMainContent` (Giữa, `Dock = Fill`, nền xám sáng `RGB(244, 245, 247)`): Vùng chứa trung tâm để nhúng động các Form con.
* **Cơ chế hoạt động:**
  * Khi tải Form (`FormMainShell_Load`): Hiển thị thông tin phiên từ `SessionManager`, kích hoạt phân quyền hiển thị nút (`ApplyRolePermissions`) và mở màn hình mặc định theo vai trò (`OpenDefaultScreenByRole`).
  * Khi nhúng Form con (`OpenChildForm`): Đóng Form con cũ (nếu có), tô sáng nút đang chọn (`HighlightActiveButton`), bỏ thuộc tính cửa sổ độc lập của Form mới (`TopLevel = false`, `FormBorderStyle = None`, `Dock = Fill`), nạp vào `panelMainContent` và đồng bộ tên màn hình lên `lblTitle`.
  * Khi đăng xuất (`btnLogout_Click`): Xác nhận người dùng, xóa dữ liệu trong `SessionManager` và điều hướng về `FormLogin`.

### 5.2. Các Form nghiệp vụ con (Dynamic Child Forms)
1. **`FormPOS` – Màn hình Bán hàng Quầy POS (*Cashier, Admin*):**
   * **Khu vực Trái (65%):** Ô quét mã vạch (`txtBarcode`) bắt phím `Enter` để tự động tra cứu sản phẩm qua API và thêm vào lưới giỏ hàng (`dgvCart`: Mã SP, Tên SP, Đơn giá, SL, Thành tiền).
   * **Khu vực Phải (35%):** Nhập SĐT tích điểm (`txtCustomerPhone`), hiển thị tên/hạng thẻ (`lblCustomerName`), tổng tiền thanh toán (`lblTotalAmount`), tiền khách đưa (`txtCashReceived`), tự động tính tiền thừa trả khách (`lblChange`), nút Thanh toán (`btnCheckout` - gọi API `orders/checkout`) và Hủy giỏ hàng (`btnClearCart`).
2. **`FormProductManagement` – Quản lý Sản phẩm & Kho hàng (*Warehouse, Admin*):**
   * **Thanh công cụ:** Tìm kiếm theo mã vạch (`txtSearchBarcode`) và lọc theo danh mục nhóm hàng (`cboFilterCategory`).
   * **Khu vực Trái (68%):** Bảng danh sách sản phẩm (`dgvProducts`).
   * **Khu vực Phải (32%):** Biểu mẫu chi tiết sản phẩm (ID, Mã vạch, Tên SP, Đơn giá, Tồn kho, Danh mục) kèm các nút thao tác Thêm mới, Cập nhật, Xóa và Làm mới dữ liệu qua API.
3. **`FormUserManagement` – Quản lý Tài khoản & Phân quyền (*Chỉ Admin*):**
   * Hiển thị danh sách nhân viên (`dgvUsers`: Username, Họ tên, Vai trò, Trạng thái hoạt động).
   * Cung cấp biểu mẫu tạo tài khoản nhân viên mới, gán vai trò (`Admin`, `Cashier`, `Warehouse`), đặt lại mật khẩu và khóa/mở khóa tài khoản.
4. **`FormQuickReport` – Báo cáo Doanh thu Nhanh (*Bài tập mở rộng cho Admin*):**
   * Chọn ngày báo cáo (`DateTimePicker`), nút chạy báo cáo (`btnRunReport`) và 3 thẻ thống kê trực quan: Tổng số hóa đơn (`lblTotalOrders`), Tổng doanh thu (`lblTotalRevenue`), Mặt hàng bán chạy nhất (`lblBestSeller`).
   * Áp dụng cơ chế **bảo vệ phân quyền 2 lớp**: Vừa ẩn nút Báo cáo trên Sidebar đối với `Cashier`/`Warehouse`, vừa kiểm tra điều kiện `Role == "Admin"` ngay trong sự kiện bấm nút trước khi cho phép mở Form.

---

## ✅ 6. Checklist Đánh Giá Kết Quả

- [ ] **Bố cục Single-Form chuẩn:** Ứng dụng không mở hàng loạt cửa sổ rời rạc; toàn bộ thao tác nghiệp vụ chạy trực tiếp trong `panelMainContent`.
- [ ] **Phân quyền chính xác theo bảng kiểm thử:**
  - [ ] Đăng nhập `cashier01` ➔ Sidebar chỉ hiển thị nút **Bán hàng (POS)** và **Khách hàng**.
  - [ ] Đăng nhập `ware01` ➔ Sidebar chỉ hiển thị nút **Danh mục** và **Sản phẩm**.
  - [ ] Đăng nhập `admin01` ➔ Hiển thị đầy đủ tất cả 6 nút chức năng.
- [ ] **Trải nghiệm người dùng (UX):** Nhấp vào nút nào thì nút đó đổi màu nổi bật (`HighlightActiveButton`), tiêu đề trên `lblTitle` đồng bộ đúng tên nghiệp vụ.
- [ ] **Bảo mật 2 lớp (Bài tập mở rộng):** Tài khoản `cashier01` và `ware01` bị chặn hoàn toàn quyền xem báo cáo tài chính cả ở giao diện lẫn tầng sự kiện.


---

# 🛒 MiniSupermarket POS - Buổi 5: ADO.NET Nâng Cao, Stored Procedure & Giao Dịch POS Checkout

> **Họ và tên:** Trần Hoàng Lin | **MSSV:** 2124110134  
> **Chủ đề:** ADO.NET thuần, Mô hình Connected & Disconnected, Stored Procedure và Kiểm soát Giao dịch ACID với `SqlTransaction`.

---

## 🎯 1. Cấu Trúc Thành Phần Đã Hoàn Thiện

1. **`ThucHanhAdoNet` (Console Project):**
   - **Bài tập 1:** Đếm tổng số mặt hàng bằng `ExecuteScalar()` (`SELECT COUNT(*) FROM Products`).
   - **Bài tập 2:** Cập nhật tồn kho an toàn bằng `ExecuteNonQuery()` và `SqlParameter` (Chống SQL Injection).
   - **Bài tập 3:** Duyệt danh sách sản phẩm tốc độ cao bằng `SqlDataReader` (Forward-Only, hiển thị bảng chuẩn định dạng).
   - **Tiết 4:** Kiểm chứng cơ chế Rollback của `SqlTransaction` mô phỏng lỗi gián đoạn nghiệp vụ.
2. **`MiniSupermarket.API` (Web API Controllers & DTOs):**
   - **`AdoProductController.cs` (Tiết 2):**
     - `GET /api/ado-products/barcode/{barcode}`: Tra cứu mã vạch siêu tốc bằng `SqlDataReader` (Connected mode, <100ms).
     - `GET /api/ado-products/disconnected-cache`: Tải bộ nhớ đệm ngoại tuyến bằng `DataTable` & `SqlDataAdapter` (Disconnected mode).
     - `GET /api/ado-products/filter-stock?minStock=50`: Tra cứu danh sách sản phẩm theo ngưỡng tồn kho (Bài tập 2.1).
     - `GET /api/ado-products/category-summary`: Tổng hợp số lượng mặt hàng theo nhóm danh mục bằng `DataTable` (Bài tập 2.2).
   - **`ReportsController.cs` (Tiết 3):**
     - `GET /api/reports/revenue-by-cashier`: Gọi Stored Procedure `sp_GetRevenueByCashier` qua `SqlDataReader`.
     - `GET /api/reports/revenue-by-date-range?fromDate=...&toDate=...`: Báo cáo doanh thu theo khoảng ngày (Bài tập 3.1).
     - `GET /api/reports/top-selling-products`: Thống kê Top 5 sản phẩm bán chạy nhất bằng Stored Procedure (Bài tập 3.2).
   - **`CheckoutController.cs` (Tiết 5):**
     - `POST /api/checkout`: Thực thi giao dịch thanh toán 4 bước liên hoàn bọc kín trong `SqlTransaction` (`OUTPUT INSERTED.OrderId`, kiểm tra tồn kho, lưu chi tiết, trừ kho, tích điểm, tự động `Rollback` nếu thiếu hàng).
     - `DELETE /api/checkout/cancel/{orderId}`: Nghiệp vụ Hủy đơn hàng và hoàn trả tồn kho đa bảng an toàn (Bài tập mở rộng).
3. **Kịch bản CSDL SQL Server (`Buoi5_Setup_MiniSupermarketDb.sql`):**
   - Khởi tạo đầy đủ cấu trúc bảng `Categories`, `Products`, `Customers`, `Users`, `Orders`, `OrderDetails`.
   - Nạp đủ 20 sản phẩm mẫu và 15 hóa đơn mẫu chuẩn theo giáo trình.
   - Biên dịch 3 Stored Procedure: `sp_GetRevenueByCashier`, `sp_GetRevenueByDateRange`, `sp_GetTop5SellingProducts`.

---

## 🚀 2. Hướng Dẫn Chạy & Kiểm Thử

### 2.1. Chạy Console Thực Hành Tiết 1 & Tiết 4
```powershell
# Chạy menu tương tác
dotnet run --project ThucHanhAdoNet

# Hoặc chạy trực tiếp tất cả 4 bài tập
dotnet run --project ThucHanhAdoNet -- 5
```

### 2.2. Chạy Web API và Kiểm Thử Swagger UI
```powershell
dotnet run --project MiniSupermarket.API
```
Truy cập Swagger tại `http://localhost:5150/swagger` hoặc `https://localhost:7167/swagger` để kiểm thử:
- Nhóm `AdoProduct`: Quét mã `893456789001` (200 OK) hoặc `999999999999` (404 Not Found).
- Nhóm `Reports`: Gọi `/api/reports/revenue-by-cashier` (Đủ 5 nhân viên thu ngân, doanh thu 4,822,000 đ).
- Nhóm `Checkout`: Gọi `POST /api/checkout` (Kịch bản thành công và kịch bản Rollback khi mua quá tồn kho).
- Nhóm `Checkout`: Gọi `DELETE /api/checkout/cancel/{orderId}` (Hủy đơn và hoàn tồn kho).
