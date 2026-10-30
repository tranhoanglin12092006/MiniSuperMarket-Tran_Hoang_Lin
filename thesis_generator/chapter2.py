# -*- coding: utf-8 -*-
from thesis_generator.builder import (p, heading1, heading2, heading3, make_table, 
                                      page_break, bullet, code_block, note_box)

def get_chapter2_xml():
    parts = []
    
    parts.append(heading1("CHƯƠNG 2: PHÂN TÍCH YÊU CẦU VÀ THIẾT KẾ HỆ THỐNG", page_break_before=True))
    
    # ----------------------------------------------------
    # 2.1. PHÂN TÍCH YÊU CẦU CHỨC NĂNG & LUỒNG NGHIỆP VỤ
    # ----------------------------------------------------
    parts.append(heading2("2.1. Phân tích yêu cầu chức năng và luồng nghiệp vụ hệ thống siêu thị mini"))
    parts.append(p("Hệ thống quản lý bán lẻ và quầy thu ngân cho cửa hàng đồ ăn vặt Ăn Vặt Store được thiết kế xoay quanh 4 luồng nghiệp vụ trọng tâm, đảm bảo sự phối hợp nhịp nhàng giữa các bộ phận trong ca trực:"))
    
    parts.append(heading3("2.1.1. Luồng phân quyền và xác thực người dùng (Quản trị viên - Admin, Thu ngân - Cashier, Thủ kho - Warehouse)"))
    parts.append(p("Hệ thống phân định rạch ròi trách nhiệm của từng vị trí nhân sự thông qua mô hình phân quyền dựa trên vai trò (RBAC):"))
    
    rbac_headers = ["Nhóm vai trò (Role)", "Mô tả trách nhiệm vị trí", "Phạm vi quyền hạn chức năng được cấp phép"]
    rbac_rows = [
        ["ADMIN (Quản trị viên)", "Chủ cửa hàng hoặc Cửa hàng trưởng quản lý toàn diện.", "Toàn quyền hệ thống: Quản lý tài khoản nhân viên, thiết lập danh mục sản phẩm, xem toàn bộ báo cáo doanh thu tài chính, hủy đơn hàng."],
        ["CASHIER (Thu ngân)", "Nhân viên trực tiếp đứng tại quầy thanh toán POS.", "Thực hiện thanh toán giỏ hàng, tra cứu mã vạch, áp dụng điểm thưởng khách hàng, xem báo cáo doanh số trong ca trực của chính mình."],
        ["WAREHOUSE (Thủ kho)", "Nhân viên phụ trách kho hàng và kiểm kê hàng hóa.", "Quản lý danh sách sản phẩm, cập nhật số lượng tồn kho nhập/xuất, theo dõi nhóm hàng và mức cảnh báo tồn kho an toàn."]
    ]
    parts.append(make_table(rbac_headers, rbac_rows, [2200, 3160, 4000], header_bg="1B365D"))
    parts.append(p("Quy trình xác thực: Người dùng nhập Username và Password tại màn hình FormLogin. WinForms gửi yêu cầu POST /api/auth/login lên Web API. Máy chủ đối soát mật khẩu bằng thuật toán băm an toàn, nếu chính xác sẽ phát sinh chuỗi JWT Bearer Token chứa Claim Role tương ứng. WinForms lưu Token vào SessionManager và tự động hiển thị/ẩn các nút menu chức năng trên Sidebar."))
    
    parts.append(heading3("2.1.2. Luồng nghiệp vụ quản lý danh mục nhóm hàng và mặt hàng tồn kho"))
    parts.append(p("Hàng hóa tại Ăn Vặt Store được tổ chức theo cấu trúc phân cấp hai tầng: Nhóm hàng (Categories) và Sản phẩm (Products)."))
    parts.append(bullet("Quản lý nhóm hàng:", "Cho phép thêm mới, cập nhật tên và mô tả nhóm (ví dụ: Bánh kẹo & Snack, Nước giải khát, Mì gói & Ăn liền). Ràng buộc toàn vẹn: Không cho phép xóa nhóm hàng nếu đang có sản phẩm thuộc nhóm đó (RESTrict / Cascade kiểm soát)."))
    parts.append(bullet("Quản lý sản phẩm và tồn kho:", "Mỗi mặt hàng bắt buộc phải có một Mã vạch (Barcode) duy nhất trên toàn hệ thống (chuẩn EAN-13 hoặc Code-128), Tên sản phẩm, Đơn giá niêm yết, Số lượng tồn kho và Khóa ngoại liên kết tới Nhóm hàng."))
    parts.append(bullet("Tối ưu hóa hiển thị:", "Áp dụng thuật toán phân trang tầng máy chủ (Server-side Pagination). Khi danh mục lên tới hàng ngàn sản phẩm, mỗi trang chỉ tải đúng kích thước quy định (5 hoặc 10 sản phẩm/trang), kèm theo thanh tìm kiếm gần đúng theo tên hoặc mã vạch."))
    
    parts.append(heading3("2.1.3. Luồng nghiệp vụ quầy thu ngân bán lẻ (POS): Tra cứu mã vạch, tính tiền, trừ kho tự động và tích điểm"))
    parts.append(p("Đây là quy trình nghiệp vụ quan trọng nhất tại quầy thu ngân, đòi hỏi tốc độ xử lý tức thì và độ chính xác tuyệt đối:"))
    parts.append(p("Bước 1: Quét mã vạch (Barcode Scanning): Thu ngân dùng súng quét mã vạch quét vào bao bì sản phẩm (hoặc gõ mã và nhấn Enter). Hệ thống lập tức gọi API ADO.NET tra cứu siêu tốc (<100ms). Sản phẩm được tự động bổ sung vào DataGridView Giỏ hàng. Nếu sản phẩm đã có sẵn, số lượng tự động tăng lên 1."))
    parts.append(p("Bước 2: Hiển thị giỏ hàng và thành tiền: Ứng dụng tự động tính đơn giá * số lượng = thành tiền từng dòng, đồng thời cập nhật tổng tiền thanh toán hiển thị bằng font chữ lớn màu xanh lá trực quan."))
    parts.append(p("Bước 3: Nhập thông tin khách hàng thành viên: Thu ngân nhập Số điện thoại khách hàng. Hệ thống hiển thị Tên khách hàng và Số điểm tích lũy hiện có. Quy tắc tích điểm: 1% giá trị đơn hàng (Ví dụ: Đơn hàng 100.000 VNĐ được tích lũy 1 điểm thưởng quy đổi)."))
    parts.append(p("Bước 4: Nhận tiền khách đưa và tính tiền thối: Thu ngân nhập số tiền khách hàng đưa, hệ thống tự động tính ra số tiền thừa cần trả lại khách ngay lập tức."))
    parts.append(p("Bước 5: Kích hoạt Giao dịch Thanh toán (Checkout Transaction): Nhấn nút Thanh toán (hoặc phím tắt F9). WinForms đóng gói toàn bộ giỏ hàng thành gói tin JSON và gửi POST /api/checkout. Tầng máy chủ bọc kín chuỗi xử lý trong một SqlTransaction chuẩn ACID: Lưu hóa đơn Orders -> Lưu các dòng OrderDetails -> Trừ trực tiếp số lượng tồn kho Products -> Cộng điểm thưởng cho Customers. Nếu xảy ra bất kỳ lỗi logic nào (ví dụ: sản phẩm bị hết hàng bởi quầy khác), toàn bộ giao dịch được Rollback an toàn."))
    
    parts.append(heading3("2.1.4. Luồng nghiệp vụ báo cáo thống kê doanh thu và hiệu suất ca trực"))
    parts.append(p("Vào cuối mỗi ca làm việc hoặc cuối ngày kinh doanh, người quản lý và nhân viên thu ngân cần đối soát dòng tiền thực tế:"))
    parts.append(bullet("Báo cáo doanh thu theo thu ngân:", "Hệ thống gọi Stored Procedure sp_GetRevenueByCashier trên SQL Server, thống kê tổng số đơn hàng đã bán, tổng số tiền thu về và tổng số điểm thưởng đã phát hành của từng thu ngân."))
    parts.append(bullet("Báo cáo theo khoảng thời gian:", "Thực thi sp_GetRevenueByDateRange để lọc doanh thu từ ngày... đến ngày..."))
    parts.append(bullet("Báo cáo Top 5 sản phẩm bán chạy nhất:", "Thực thi sp_GetTop5SellingProducts để vinh danh các mặt hàng bán chạy nhất cửa hàng, giúp thủ kho có kế hoạch nhập hàng kịp thời."))
    
    # ----------------------------------------------------
    # 2.2. THIẾT KẾ MÔ HÌNH KIẾN TRÚC CLIENT - SERVER
    # ----------------------------------------------------
    parts.append(heading2("2.2. Thiết kế mô hình kiến trúc Client - Server tổng thể"))
    
    parts.append(heading3("2.2.1. Sơ đồ kiến trúc 3 lớp: Desktop WinForms Client – ASP.NET Core Web API – SQL Server Database"))
    parts.append(p("Hệ thống được tổ chức phân tầng rõ rệt theo mô hình 3 lớp phân tán (3-Tier Distributed Architecture):"))
    parts.append(code_block('''+-------------------------------------------------------------------------+
|                  TẦNG HIỂN THỊ (PRESENTATION TIER)                      |
|                  Desktop Client: Windows Forms (.NET 8)                 |
|  - FormMainShell (Khung Workspace đơn, thanh Sidebar điều hướng RBAC)   |
|  - FormPOS (Quầy thu ngân, bắt sự kiện Barcode Scanner, phím tắt F2/F9) |
|  - FormProductManagement (Lưới DataGridView, phân trang LINQ, tìm kiếm) |
|  - FormReports (Bảng biểu thống kê doanh số ca trực & xuất Excel)       |
|  - ApiClientService (Singleton HttpClient, tự động đính kèm JWT Bearer)  |
+------------------------------------▲------------------------------------+
                                     │ Giao thức HTTP/HTTPS
                                     │ Định dạng JSON Payload + Bearer Token
+------------------------------------▼------------------------------------+
|               TẦNG DỊCH VỤ NGHIỆP VỤ (BUSINESS API TIER)               |
|               Backend: ASP.NET Core Web API (.NET 8.0)                  |
|  - Controllers: AuthController, ProductsController, CheckoutController  |
|  - Middlewares: Authentication JWT, Authorization RBAC, Exception Filter|
|  - ORM Engine: Entity Framework Core 8 Code-First (SupermarketDbContext)|
|  - ADO.NET Engine: Microsoft.Data.SqlClient (SqlDataReader, SqlTrans)   |
+------------------------------------▲------------------------------------+
                                     │ Giao thức TDS (Tabular Data Stream)
                                     │ Cổng kết nối TCP 1433 / ADO.NET
+------------------------------------▼------------------------------------+
|                  TẦNG CƠ SỞ DỮ LIỆU (DATABASE TIER)                     |
|                  Hệ quản trị CSDL: Microsoft SQL Server                 |
|  - 6 Bảng quan hệ: Users, Categories, Products, Customers, Orders...     |
|  - Stored Procedures: sp_GetRevenueByCashier, sp_GetTop5SellingProducts |
|  - Kiểm soát giao dịch toàn vẹn ACID, Khóa ngoại PK/FK, Chỉ mục Index   |
+-------------------------------------------------------------------------+'''))
    parts.append(p("Hình 2.1: Sơ đồ kiến trúc 3 lớp tổng thể của hệ thống Ăn Vặt Store", bold=True, italic=True, size=24, color="334155", align="center", space_after=180))
    
    parts.append(heading3("2.2.2. Sơ đồ tuần hoàn dòng chảy dữ liệu (Data Flow Diagram) trong hệ thống"))
    parts.append(p("Sơ đồ luồng dữ liệu cấp 0 (Context Diagram) mô tả mối tương tác giữa 3 tác nhân bên ngoài (Admin, Thu ngân, Khách hàng) với Hệ thống Siêu thị mini Ăn Vặt Store:"))
    parts.append(bullet("Admin:", "Cung cấp thông tin tài khoản nhân sự, danh mục sản phẩm ➔ Nhận báo cáo thống kê doanh số tổng hợp."))
    parts.append(bullet("Thu ngân:", "Gửi thông tin đăng nhập, quét mã vạch sản phẩm, nhập tiền khách đưa ➔ Nhận thông tin mặt hàng, số tiền thối, hóa đơn hoàn tất."))
    parts.append(bullet("Khách hàng:", "Cung cấp số điện thoại thành viên ➔ Nhận điểm thưởng tích lũy và hóa đơn bán lẻ."))
    
    parts.append(p("Sơ đồ luồng dữ liệu cấp 1 (DFD Level 1) phân rã hệ thống thành 4 tiến trình nghiệp vụ chính:"))
    parts.append(bullet("Tiến trình 1.0 (Xác thực & Ủy quyền):", "Tiếp nhận thông tin đăng nhập, đối soát với Kho dữ liệu Users (D1), cấp phát JWT Token."))
    parts.append(bullet("Tiến trình 2.0 (Quản lý Danh mục & Kho hàng):", "Tiếp nhận thông tin cập nhật từ Admin/Thủ kho, lưu trữ vào Kho Categories (D2) và Kho Products (D3)."))
    parts.append(bullet("Tiến trình 3.0 (Thanh toán Giao dịch POS):", "Đọc dữ liệu từ Products (D3) và Customers (D4), ghi hóa đơn vào Orders (D5) và OrderDetails (D6), cập nhật trừ tồn kho D3 và tích điểm D4."))
    parts.append(bullet("Tiến trình 4.0 (Báo cáo Thống kê Doanh thu):", "Tổng hợp số liệu từ Orders (D5) và OrderDetails (D6) thông qua các Stored Procedure, kết xuất dữ liệu hiển thị."))
    
    # ----------------------------------------------------
    # 2.3. THIẾT KẾ CƠ SỞ DỮ LIỆU QUAN HỆ
    # ----------------------------------------------------
    parts.append(heading2("2.3. Thiết kế Cơ sở dữ liệu quan hệ (Database Schema)"))
    
    parts.append(heading3("2.3.1. Sơ đồ thực thể liên kết (ERD) hoàn chỉnh gồm 6 bảng thực thể nghiệp vụ cốt lõi"))
    parts.append(p("Lược đồ cơ sở dữ liệu quan hệ MiniSupermarketDb gồm 6 thực thể có mối quan hệ chặt chẽ:"))
    parts.append(bullet("Categories (1) ---- (N) Products:", "Một nhóm hàng chứa nhiều sản phẩm; mỗi sản phẩm bắt buộc thuộc về duy nhất một nhóm hàng (FK: CategoryId)."))
    parts.append(bullet("Customers (1) ---- (N) Orders:", "Một khách hàng có thể có nhiều đơn hàng trong lịch sử; mỗi đơn hàng thuộc về một khách hàng (FK: CustomerId)."))
    parts.append(bullet("Orders (1) ---- (N) OrderDetails:", "Một hóa đơn gồm nhiều dòng chi tiết sản phẩm; xóa hóa đơn sẽ tự động xóa các dòng chi tiết tương ứng (ON DELETE CASCADE, FK: OrderId)."))
    parts.append(bullet("Products (1) ---- (N) OrderDetails:", "Một sản phẩm có thể xuất hiện trên nhiều chi tiết hóa đơn khác nhau (FK: ProductId)."))
    parts.append(bullet("Users:", "Bảng thực thể độc lập quản lý tài khoản nhân viên và vai trò truy cập hệ thống."))
    
    parts.append(heading3("2.3.2. Phân hệ tài khoản và phân quyền: Chi tiết bảng Users"))
    user_cols = ["Tên trường", "Kiểu dữ liệu SQL", "Ràng buộc", "Diễn giải nghiệp vụ"]
    user_rows = [
        ["UserId", "INT", "PK, IDENTITY(1,1)", "Khóa chính tự động tăng định danh tài khoản người dùng"],
        ["Username", "VARCHAR(50)", "NOT NULL, UNIQUE", "Tên đăng nhập duy nhất không trùng lặp"],
        ["Password", "VARCHAR(255)", "NOT NULL", "Mật khẩu tài khoản (hỗ trợ lưu chuỗi mã hóa/băm)"],
        ["FullName", "NVARCHAR(100)", "NOT NULL", "Họ và tên đầy đủ của nhân sự"],
        ["Email", "VARCHAR(150)", "NOT NULL", "Địa chỉ hòm thư điện tử liên lạc"],
        ["Role", "VARCHAR(50)", "NOT NULL", "Vai trò hệ thống: ADMIN, CASHIER, WAREHOUSE"],
        ["IsActive", "BIT", "NOT NULL, DEFAULT 1", "Trạng thái tài khoản (1: Đang hoạt động, 0: Đã khóa)"],
        ["FunctionScope", "NVARCHAR(255)", "NOT NULL, DEFAULT N'All'", "Phạm vi các chức năng cho phép thao tác"]
    ]
    parts.append(make_table(user_cols, user_rows, [1800, 2200, 2200, 3160], header_bg="1B365D"))
    
    parts.append(heading3("2.3.3. Phân hệ hàng hóa và nhóm hàng: Chi tiết bảng Categories và Products"))
    parts.append(p("Bảng Categories (Nhóm hàng hóa):", bold=True, size=24, color="1B365D"))
    cat_cols = ["Tên trường", "Kiểu dữ liệu SQL", "Ràng buộc", "Diễn giải nghiệp vụ"]
    cat_rows = [
        ["CategoryId", "INT", "PK, IDENTITY(1,1)", "Khóa chính tự động tăng định danh nhóm hàng"],
        ["CategoryName", "NVARCHAR(100)", "NOT NULL", "Tên danh mục (ví dụ: Bánh kẹo & Đồ ăn vặt)"],
        ["Description", "NVARCHAR(255)", "NULL", "Mô tả chi tiết đặc tính của nhóm hàng"]
    ]
    parts.append(make_table(cat_cols, cat_rows, [1800, 2200, 2200, 3160], header_bg="0284C7"))
    
    parts.append(p("Bảng Products (Hàng hóa & Tồn kho quầy bán lẻ):", bold=True, size=24, color="1B365D", space_before=100))
    prod_cols = ["Tên trường", "Kiểu dữ liệu SQL", "Ràng buộc", "Diễn giải nghiệp vụ"]
    prod_rows = [
        ["ProductId", "INT", "PK, IDENTITY(1,1)", "Khóa chính tự động tăng định danh sản phẩm"],
        ["Barcode", "VARCHAR(50)", "NOT NULL, UNIQUE", "Mã vạch vạch vạch duy nhất (EAN-13, Code-128) để quét POS"],
        ["ProductName", "NVARCHAR(150)", "NOT NULL", "Tên thương mại đầy đủ của mặt hàng"],
        ["Price", "DECIMAL(18,2)", "NOT NULL", "Đơn giá bán lẻ niêm yết (VNĐ), bắt buộc > 0"],
        ["StockQuantity", "INT", "NOT NULL", "Số lượng tồn kho thực tế, không được âm (>= 0)"],
        ["CategoryId", "INT", "FK -> Categories", "Khóa ngoại liên kết tới nhóm hàng chứa sản phẩm"]
    ]
    parts.append(make_table(prod_cols, prod_rows, [1800, 2200, 2200, 3160], header_bg="1B365D"))
    
    parts.append(heading3("2.3.4. Phân hệ khách hàng thành viên: Chi tiết bảng Customers"))
    cust_cols = ["Tên trường", "Kiểu dữ liệu SQL", "Ràng buộc", "Diễn giải nghiệp vụ"]
    cust_rows = [
        ["CustomerId", "INT", "PK, IDENTITY(1,1)", "Khóa chính tự động tăng định danh khách hàng"],
        ["CustomerName", "NVARCHAR(100)", "NOT NULL", "Họ tên khách hàng thân thiết"],
        ["PhoneNumber", "VARCHAR(15)", "NOT NULL", "Số điện thoại liên lạc dùng để tra cứu tại quầy POS"],
        ["MembershipRank", "NVARCHAR(50)", "NOT NULL, DEFAULT N'Chuẩn'", "Hạng hội viên (Chuẩn, Bạc, Vàng, VIP)"],
        ["RewardPoints", "INT", "NOT NULL, DEFAULT 0", "Điểm thưởng tích lũy (cộng 1% giá trị mỗi đơn hàng)"],
        ["Address", "NVARCHAR(200)", "NULL", "Địa chỉ cư trú của khách hàng"]
    ]
    parts.append(make_table(cust_cols, cust_rows, [1800, 2200, 2200, 3160], header_bg="0284C7"))
    
    parts.append(heading3("2.3.5. Phân hệ hóa đơn và giao dịch bán lẻ: Chi tiết bảng Orders và OrderDetails"))
    parts.append(p("Bảng Orders (Hóa đơn bán hàng):", bold=True, size=24, color="1B365D"))
    ord_cols = ["Tên trường", "Kiểu dữ liệu SQL", "Ràng buộc", "Diễn giải nghiệp vụ"]
    ord_rows = [
        ["OrderId", "INT", "PK, IDENTITY(1,1)", "Khóa chính tự động tăng định danh hóa đơn"],
        ["OrderCode", "VARCHAR(50)", "NOT NULL", "Mã hóa đơn nghiệp vụ (HD-YYYYMMDD-XXXX)"],
        ["CreatedDate", "DATETIME", "NOT NULL, DEFAULT GETDATE()", "Thời điểm phát sinh giao dịch thanh toán"],
        ["CashierUsername", "VARCHAR(50)", "NOT NULL", "Tên tài khoản thu ngân trực tiếp thực hiện đơn"],
        ["CustomerId", "INT", "FK -> Customers", "Khóa ngoại liên kết khách hàng (1: Khách vãng lai)"],
        ["TotalItems", "INT", "NOT NULL", "Tổng số lượng món hàng trong giỏ hàng"],
        ["FinalAmount", "DECIMAL(18,2)", "NOT NULL", "Tổng số tiền thực tế khách hàng phải trả"],
        ["RewardPoints", "INT", "NOT NULL, DEFAULT 0", "Số điểm thưởng tích lũy được từ đơn hàng này"]
    ]
    parts.append(make_table(ord_cols, ord_rows, [1800, 2200, 2200, 3160], header_bg="1B365D"))
    
    parts.append(p("Bảng OrderDetails (Chi tiết các mặt hàng trong hóa đơn):", bold=True, size=24, color="1B365D", space_before=100))
    dtl_cols = ["Tên trường", "Kiểu dữ liệu SQL", "Ràng buộc", "Diễn giải nghiệp vụ"]
    dtl_rows = [
        ["OrderDetailId", "INT", "PK, IDENTITY(1,1)", "Khóa chính tự động tăng định danh dòng chi tiết"],
        ["OrderId", "INT", "FK -> Orders", "Khóa ngoại liên kết hóa đơn (ON DELETE CASCADE)"],
        ["ProductId", "INT", "FK -> Products", "Khóa ngoại liên kết sản phẩm được bán"],
        ["Quantity", "INT", "NOT NULL", "Số lượng mặt hàng cụ thể được xuất bán"],
        ["UnitPrice", "DECIMAL(18,2)", "NOT NULL", "Đơn giá bán tại thời điểm lập hóa đơn"],
        ["LineTotal", "DECIMAL(18,2)", "NOT NULL", "Thành tiền của dòng mặt hàng (Quantity * UnitPrice)"]
    ]
    parts.append(make_table(dtl_cols, dtl_rows, [1800, 2200, 2200, 3160], header_bg="0284C7"))
    
    parts.append(heading3("2.3.6. Bảng tổng hợp các ràng buộc toàn vẹn dữ liệu: Khóa chính (PK), Khóa ngoại (FK), Ràng buộc Duy nhất (Unique) và Giá trị mặc định"))
    constraint_cols = ["Bảng CSDL", "Tên ràng buộc", "Loại ràng buộc", "Cột áp dụng", "Quy tắc kiểm tra toàn vẹn"]
    constraint_rows = [
        ["Products", "UQ_Products_Barcode", "UNIQUE", "Barcode", "Ngăn chặn trùng lặp mã vạch giữa các mặt hàng."],
        ["Products", "FK_Products_Categories", "FOREIGN KEY", "CategoryId", "Sản phẩm phải thuộc một nhóm hàng hợp lệ."],
        ["Users", "UQ_Users_Username", "UNIQUE", "Username", "Tên đăng nhập không được trùng nhau."],
        ["Orders", "FK_Orders_Customers", "FOREIGN KEY", "CustomerId", "Hóa đơn phải thuộc về một khách hàng hợp lệ."],
        ["OrderDetails", "FK_Details_Orders", "FOREIGN KEY", "OrderId", "Tự động xóa chi tiết khi xóa đơn cha (Cascade)."],
        ["OrderDetails", "FK_Details_Products", "FOREIGN KEY", "ProductId", "Mặt hàng trong chi tiết phải tồn tại trong kho."]
    ]
    parts.append(make_table(constraint_cols, constraint_rows, [1400, 2200, 1600, 1600, 2560], header_bg="1B365D"))
    
    # ----------------------------------------------------
    # 2.4. THIẾT KẾ DANH MỤC VÀ ĐẶC TẢ RESTFUL WEB API
    # ----------------------------------------------------
    parts.append(heading2("2.4. Thiết kế danh mục và đặc tả chuẩn RESTful Web API"))
    
    parts.append(heading3("2.4.1. Quy chuẩn định dạng đường dẫn Endpoint, Header và cấu trúc gói tin JSON"))
    parts.append(p("Toàn bộ các API trong hệ thống đều tuân thủ nghiêm ngặt các quy chuẩn:"))
    parts.append(bullet("Định dạng gốc (Base URL):", "https://localhost:7167/api hoặc http://localhost:5150/api."))
    parts.append(bullet("Header chuẩn gửi đi:", "Content-Type: application/json; charset=utf-8."))
    parts.append(bullet("Header xác thực bảo mật:", "Authorization: Bearer <JWT_TOKEN_STRING> (đối với các endpoint yêu cầu xác thực)."))
    parts.append(bullet("Cấu trúc phản hồi JSON phân trang chuẩn:", "{ currentPage, pageSize, totalItems, totalPages, items: [...] }."))
    
    parts.append(heading3("2.4.2. Phân hệ API Xác thực và Cấp phát Token (/api/auth)"))
    parts.append(p("• POST /api/auth/login: Xác thực đăng nhập và nhận JWT Bearer Token.", bold=True))
    parts.append(bullet("Request Body JSON:", '{"username": "admin01", "password": "password123"}'))
    parts.append(bullet("Response 200 OK JSON:", '{"token": "eyJhbGciOiJIUzI1NiIsIn...", "username": "admin01", "fullName": "Quản Trị Viên 01", "role": "ADMIN", "expiresIn": 86400}'))
    
    parts.append(heading3("2.4.3. Phân hệ API Quản lý Nhóm hàng (/api/categories)"))
    parts.append(bullet("GET /api/categories:", "Lấy toàn bộ danh sách nhóm hàng (Không cần đăng nhập, phục vụ nạp ComboBox)."))
    parts.append(bullet("POST /api/categories:", "Thêm nhóm hàng mới. [Authorize(Roles = 'ADMIN')]. Request: {\"categoryName\": \"Snack & Đồ khô\", \"description\": \"Các loại hạt và bánh snack\"}."))
    parts.append(bullet("PUT /api/categories/{id}:", "Cập nhật thông tin nhóm hàng theo ID. [Authorize(Roles = 'ADMIN')]."))
    parts.append(bullet("DELETE /api/categories/{id}:", "Xóa nhóm hàng theo ID. [Authorize(Roles = 'ADMIN')]."))
    
    parts.append(heading3("2.4.4. Phân hệ API Quản lý Sản phẩm, Tra cứu Barcode và Phân trang (/api/products, /api/ado-products)"))
    parts.append(bullet("GET /api/products/paged?keyword=...&categoryId=...&pageNumber=1&pageSize=5:", "Phân trang LINQ Server-side kết hợp Eager Loading .Include(p => p.Category) và tối ưu .AsNoTracking()."))
    parts.append(bullet("GET /api/ado-products/barcode/{barcode}:", "Tra cứu siêu tốc bằng ADO.NET SqlDataReader thuần túy (<100ms) phục vụ quầy quét mã POS. Phản hồi 200 OK kèm thông tin sản phẩm hoặc 404 Not Found."))
    parts.append(bullet("GET /api/ado-products/disconnected-cache:", "Tải danh mục 20 sản phẩm lưu vào DataTable đệm thông qua SqlDataAdapter."))
    parts.append(bullet("POST /api/products:", "Thêm sản phẩm mới. [Authorize(Roles = 'ADMIN,WAREHOUSE')]."))
    parts.append(bullet("PUT /api/products/{id}:", "Cập nhật sản phẩm. [Authorize(Roles = 'ADMIN,WAREHOUSE')]."))
    parts.append(bullet("DELETE /api/products/{id}:", "Xóa sản phẩm. [Authorize(Roles = 'ADMIN')]."))
    
    parts.append(heading3("2.4.5. Phân hệ API Giao dịch Thanh toán POS (/api/checkout)"))
    parts.append(bullet("POST /api/checkout:", "Thanh toán giỏ hàng POS bọc kín trong SqlTransaction chuẩn ACID."))
    parts.append(bullet("Request Body JSON:", '{"cashierUsername": "cashier01", "customerId": 1, "items": [{"productId": 1, "quantity": 2, "unitPrice": 12500}, {"productId": 5, "quantity": 3, "unitPrice": 10000}]}'))
    parts.append(bullet("Response 200 OK JSON (COMMIT):", '{"success": true, "orderId": 16, "orderCode": "HD-20261027-0016", "finalAmount": 55000.00, "rewardPointsAwarded": 5, "message": "Giao dịch thanh toán thành công!"}'))
    parts.append(bullet("Response 400 BadRequest JSON (ROLLBACK):", '{"success": false, "message": "Giao dịch thanh toán bị hủy và đã được Rollback an toàn!", "errorDetail": "Sản phẩm Bánh Quy Danisa không đủ tồn kho!"}'))
    parts.append(bullet("DELETE /api/checkout/cancel/{orderId}:", "Hủy hóa đơn, tự động hoàn trả tồn kho sản phẩm và khấu trừ lại điểm thưởng trong 1 Transaction."))
    
    parts.append(heading3("2.4.6. Phân hệ API Báo cáo Doanh thu Stored Procedure (/api/reports)"))
    parts.append(bullet("GET /api/reports/revenue-by-cashier:", "Thực thi Stored Procedure sp_GetRevenueByCashier trả về doanh số từng thu ngân."))
    parts.append(bullet("GET /api/reports/revenue-by-date-range?fromDate=...&toDate=...:", "Thực thi sp_GetRevenueByDateRange."))
    parts.append(bullet("GET /api/reports/top-selling-products:", "Thực thi sp_GetTop5SellingProducts thống kê top 5 mặt hàng bán chạy nhất."))
    
    return "".join(parts)
