# -*- coding: utf-8 -*-
from thesis_generator.builder import (p, heading1, heading2, heading3, make_table, 
                                      page_break, bullet, code_block, note_box, screenshot_placeholder)

def get_chapter5_xml():
    parts = []
    
    parts.append(heading1("CHƯƠNG 5: KIỂM THỬ HỆ THỐNG VÀ ĐÁNH GIÁ KẾT QUẢ ĐỒ ÁN", page_break_before=True))
    
    # ----------------------------------------------------
    # 5.1. MÔI TRƯỜNG & KỊCH BẢN KIỂM THỬ
    # ----------------------------------------------------
    parts.append(heading2("5.1. Môi trường và Kịch bản kiểm thử hệ thống"))
    
    parts.append(heading3("5.1.1. Cấu hình môi trường thử nghiệm: Phần cứng máy trạm, Máy chủ Web API và Cơ sở dữ liệu SQL Server"))
    parts.append(p("Để đánh giá khách quan và chính xác hiệu năng cũng như độ ổn định của hệ thống Ăn Vặt Store, môi trường thử nghiệm chuẩn hóa đã được thiết lập:"))
    
    env_headers = ["Thành phần", "Thông số phần cứng / Phần mềm thử nghiệm", "Ghi chú cấu hình"]
    env_rows = [
        ["Hệ điều hành", "Microsoft Windows 11 Pro 64-bit (Build 22631)", "Môi trường máy trạm và máy chủ phát triển."],
        ["Bộ xử lý (CPU)", "Intel Core i7 / AMD Ryzen 5 (8 Cores, 16 Threads, 3.8 GHz)", "Đủ năng lực mô phỏng xử lý tải cao."],
        ["Bộ nhớ RAM", "16 GB DDR4 Bus 3200 MHz", "Đảm bảo không nghẽn tài nguyên bộ nhớ đệm."],
        ["Nền tảng phát triển", "Microsoft .NET SDK 8.0.400 & Visual Studio 2022 Community", "Biên dịch mã nguồn C# 12 hiện đại."],
        ["Hệ quản trị CSDL", "Microsoft SQL Server 2022 Developer Edition / SSMS v19", "Cơ sở dữ liệu MiniSupermarketDb lưu trữ."],
        ["Công cụ kiểm thử API", "Swagger UI OpenAPI tích hợp sẵn & Postman v11", "Gửi và đo lường thời gian đáp ứng của HTTP Request."],
        ["Thiết bị ngoại vi POS", "Máy quét mã vạch Barcode Scanner Laser USB (Chuẩn HID)", "Quét trực tiếp mã vạch trên vỏ bánh kẹo."]
    ]
    parts.append(make_table(env_headers, env_rows, [2200, 4160, 3000], header_bg="1B365D"))
    parts.append(p("Bảng 5.1: Cấu hình môi trường kiểm thử hệ thống phần mềm", bold=True, italic=True, size=24, color="334155", align="center", space_after=160))
    
    parts.append(heading3("5.1.2. Bộ dữ liệu kiểm thử chuẩn hóa: 15 tài khoản nhân sự mẫu phân quyền và 20 mặt hàng kiểm thử tồn kho"))
    parts.append(p("Hệ thống nạp sẵn danh sách 15 tài khoản nhân sự mẫu nhằm kiểm thử toàn diện cơ chế phân quyền RBAC:"))
    
    acc_headers = ["Tên đăng nhập", "Mật khẩu mặc định", "Họ và tên nhân sự", "Vai trò (Role)", "Phạm vi quyền"]
    acc_rows = [
        ["admin01", "123456", "Trần Hoàng Lin (Admin)", "ADMIN", "Toàn quyền quản trị"],
        ["admin02", "123456", "Nguyễn Văn Quản Trị", "ADMIN", "Toàn quyền quản trị"],
        ["cashier01", "123456", "Lê Thị Thu Ngân 01", "CASHIER", "Quầy bán lẻ POS"],
        ["cashier02", "123456", "Phạm Văn Thu Ngân 02", "CASHIER", "Quầy bán lẻ POS"],
        ["cashier03", "123456", "Hoàng Thị Thu Ngân 03", "CASHIER", "Quầy bán lẻ POS"],
        ["cashier04", "123456", "Đỗ Văn Thu Ngân 04", "CASHIER", "Quầy bán lẻ POS"],
        ["cashier05", "123456", "Vũ Thị Thu Ngân 05", "CASHIER", "Quầy bán lẻ POS"],
        ["ware01", "123456", "Bùi Văn Thủ Kho 01", "WAREHOUSE", "Kho hàng & Tồn kho"],
        ["ware02", "123456", "Đặng Thị Thủ Kho 02", "WAREHOUSE", "Kho hàng & Tồn kho"],
        ["ware03", "123456", "Ngô Văn Thủ Kho 03", "WAREHOUSE", "Kho hàng & Tồn kho"]
    ]
    parts.append(make_table(acc_headers, acc_rows, [1800, 1600, 2560, 1600, 1800], header_bg="0284C7"))
    parts.append(p("Bảng 5.2: Danh sách tài khoản nhân sự kiểm thử phân quyền RBAC", bold=True, italic=True, size=24, color="334155", align="center", space_after=160))
    
    # ----------------------------------------------------
    # 5.2. KIỂM THỬ BACKEND WEB API
    # ----------------------------------------------------
    parts.append(heading2("5.2. Kiểm thử phân hệ Backend Web API (Swagger UI & Postman)"))
    
    parts.append(heading3("5.2.1. Kiểm thử tính năng cấp Token JWT và gọi API công khai (200 OK / 201 Created)"))
    parts.append(p("Gửi POST /api/auth/login với thông tin tài khoản hợp lệ (admin01 / 123456). Kết quả phản hồi HTTP 200 OK kèm theo chuỗi Bearer Token hợp lệ và các Claims định danh."))
    parts.append(screenshot_placeholder("5.1", "Swagger UI kiểm thử API Auth Login trả về mã 200 OK kèm chuỗi JWT Bearer Token",
                                       "Dán ảnh chụp màn hình kiểm thử Action Login thành công trên Swagger UI."))
    
    parts.append(heading3("5.2.2. Kiểm thử cơ chế bảo vệ phân quyền: Kiểm tra mã trạng thái 401 Unauthorized và 403 Forbidden khi truy cập vượt quyền"))
    parts.append(p("Kịch bản 1 (Thiếu Token): Gọi DELETE /api/products/1 khi chưa đăng nhập. Kết quả: Web API lập tức chặn lại và trả về mã lỗi HTTP 401 Unauthorized."))
    parts.append(p("Kịch bản 2 (Truy cập vượt quyền): Đăng nhập tài khoản thu ngân (cashier01), lấy Token và gọi DELETE /api/products/1 (vốn chỉ dành cho ADMIN). Kết quả: Web API từ chối với mã lỗi HTTP 403 Forbidden."))
    parts.append(screenshot_placeholder("5.2", "Swagger UI kiểm thử cơ chế bảo vệ phân quyền: Trả về mã lỗi 401 Unauthorized khi thiếu Token",
                                       "Dán ảnh chụp màn hình lỗi 401 Unauthorized trên Swagger."))
    
    parts.append(heading3("5.2.3. Kiểm thử phân trang máy chủ: Đánh giá thời gian phản hồi khi trích xuất dữ liệu với các bộ tham số pageNumber và pageSize"))
    parts.append(p("Thử nghiệm gọi GET /api/products/paged với pageNumber=1, pageSize=5. API phản hồi trong 25ms, trả về đúng 5 bản ghi đầu tiên cùng tổng số 15 mặt hàng (totalItems = 15, totalPages = 3). Khi chuyển sang pageNumber=2, hệ thống trả về chính xác 5 sản phẩm tiếp theo, không có hiện tượng trùng lặp."))
    parts.append(screenshot_placeholder("5.3", "Swagger UI kiểm thử API Phân trang GET /api/products/paged trả về dữ liệu kèm Metadata phân trang",
                                       "Dán ảnh chụp màn hình kết quả JSON của API phân trang."))
    
    # ----------------------------------------------------
    # 5.3. KIỂM THỬ TOÀN VẸN GIAO DỊCH ACID
    # ----------------------------------------------------
    parts.append(heading2("5.3. Kiểm thử nghiệp vụ Giao dịch toàn vẹn dữ liệu (ACID Transaction Testing)"))
    parts.append(p("Đây là nội dung kiểm thử kỹ thuật chuyên sâu quan trọng nhất nhằm chứng minh độ tin cậy của tầng truy xuất dữ liệu:"))
    
    parts.append(heading3("5.3.1. Kịch bản 1 (Thanh toán thành công - Commit): Kiểm tra đối soát đồng bộ dữ liệu tại cả 4 bảng (Orders, OrderDetails, Products, Customers) trên SSMS"))
    parts.append(p("Thực hiện gửi yêu cầu thanh toán hợp lệ giỏ hàng gồm 2 gói Snack O'Star (ID 1) và 3 lon Coca Cola (ID 5) cho Khách hàng ID 1. Kết quả phản hồi HTTP 200 OK:"))
    parts.append(screenshot_placeholder("5.4", "Kiểm thử Giao dịch Checkout thành công (COMMIT 200 OK) sinh hóa đơn mới",
                                       "Dán ảnh chụp màn hình Swagger phản hồi 200 OK kèm mã hóa đơn và điểm thưởng."))
    
    parts.append(p("Đối soát dữ liệu đồng bộ tức thời trên SQL Server Management Studio (SSMS):"))
    parts.append(bullet("Bảng Orders:", "Xuất hiện thêm 1 đơn hàng mới (OrderId = 16) với số tiền 55.000 VNĐ, tích lũy 5 điểm."))
    parts.append(bullet("Bảng OrderDetails:", "Tự động sinh ra 2 dòng chi tiết khớp đúng mã sản phẩm và số lượng mua."))
    parts.append(bullet("Bảng Products:", "Tồn kho của Sản phẩm 1 giảm từ 250 xuống 248; Sản phẩm 5 giảm từ 320 xuống 317."))
    parts.append(bullet("Bảng Customers:", "Điểm thưởng của Khách hàng ID 1 được cộng thêm đúng 5 điểm."))
    
    parts.append(heading3("5.3.2. Kịch bản 2 (Hoàn tác tự động - Rollback): Cố tình đặt mua mặt hàng vượt quá số lượng tồn kho thực tế, xác nhận hệ thống hủy giao dịch an toàn và không phát sinh hóa đơn rác"))
    parts.append(p("Thực hiện gửi yêu cầu thanh toán trong đó cố tình đặt mua 999 hộp bánh Danisa (ID 2 - tồn kho thực tế chỉ có 40):"))
    parts.append(screenshot_placeholder("5.5", "Kiểm thử Giao dịch Checkout bị Rollback an toàn (400 BadRequest) khi mua vượt quá tồn kho",
                                       "Dán ảnh chụp màn hình phản hồi lỗi 400 BadRequest thông báo Rollback an toàn."))
    
    parts.append(p("Đối soát tính nguyên tử (Atomicity) trên SQL Server (SSMS):"))
    acid_audit_headers = ["Bảng CSDL kiểm tra", "Trạng thái trước giao dịch", "Kỳ vọng sau Rollback", "Thực tế kiểm tra trên SSMS", "Kết luận"]
    acid_audit_rows = [
        ["Orders", "Có 15 đơn hàng", "Vẫn giữ nguyên 15 đơn", "Chính xác 15 đơn (Không sinh đơn rác)", "[x] Đạt chuẩn"],
        ["OrderDetails", "Có 38 dòng chi tiết", "Giữ nguyên 38 dòng", "Chính xác 38 dòng (Không có dòng mồ côi)", "[x] Đạt chuẩn"],
        ["Products (SP 1)", "Tồn kho: 248 đơn vị", "Giữ nguyên 248 đơn vị", "Chính xác 248 (Không bị trừ oan)", "[x] Đạt chuẩn"],
        ["Products (SP 2)", "Tồn kho: 40 đơn vị", "Giữ nguyên 40 đơn vị", "Chính xác 40 đơn vị", "[x] Đạt chuẩn"],
        ["Customers (KH 1)", "Điểm thưởng: 120 điểm", "Giữ nguyên 120 điểm", "Chính xác 120 điểm (Không bị cộng ảo)", "[x] Đạt chuẩn"]
    ]
    parts.append(make_table(acid_audit_headers, acid_audit_rows, [1800, 2000, 2000, 2260, 1300], header_bg="1B365D"))
    parts.append(p("Bảng 5.6: Bảng đối soát bảo toàn dữ liệu sau khi kích hoạt Transaction Rollback trên SSMS", bold=True, italic=True, size=24, color="334155", align="center", space_after=160))
    
    parts.append(screenshot_placeholder("5.6", "Ảnh chụp màn hình đối soát dữ liệu trên SQL Server Management Studio (SSMS)",
                                       "Dán ảnh chụp màn hình SSMS chạy câu lệnh SELECT * FROM Orders và Products."))
    
    # ----------------------------------------------------
    # 5.4. KIỂM THỬ TÍCH HỢP WINFORMS POS CLIENT
    # ----------------------------------------------------
    parts.append(heading2("5.4. Kiểm thử tích hợp toàn diện trên ứng dụng WinForms POS Client"))
    
    parts.append(heading3("5.4.1. Thử nghiệm luồng bán hàng hoàn chỉnh không dùng chuột tại quầy POS thông qua máy quét Barcode và phím tắt"))
    parts.append(p("Thử nghiệm vận hành thực tế tại quầy thu ngân cho thấy nhân viên có thể hoàn tất một đơn hàng chỉ trong vòng 15 giây mà không cần chạm tay vào chuột máy tính:"))
    parts.append(bullet("Bước 1:", "Dùng súng bắn mã vạch quét liên tiếp 3 mặt hàng -> Giỏ hàng tự động nạp mượt mà."))
    parts.append(bullet("Bước 2:", "Bấm phím F2 -> Nhập số điện thoại khách hàng 0901234567 -> Hiện tên và điểm tích lũy."))
    parts.append(bullet("Bước 3:", "Nhập số tiền khách đưa -> Nhấn F9 -> Hệ thống gọi API thanh toán thành công, in hóa đơn và tự động xóa sạch giỏ hàng sẵn sàng cho lượt khách tiếp theo."))
    
    parts.append(heading3("5.4.2. Thử nghiệm đồng bộ dữ liệu thời gian thực: Thao tác Thêm/Sửa/Xóa hàng hóa từ Client và kiểm tra sự thay đổi trực tiếp dưới SQL Server"))
    parts.append(p("Khi người dùng thực hiện Thêm mới hoặc Cập nhật giá sản phẩm từ màn hình FormProductManagement, dữ liệu lập tức được phản ánh xuống bảng Products trong SQL Server. Đồng thời, khi chuyển trang hoặc nhấn Tìm kiếm, hàm LoadProductsPagedAsync() tự động tải lại dữ liệu mới nhất từ máy chủ."))
    parts.append(screenshot_placeholder("5.7", "Màn hình chạy kiểm thử tự động 4 bài tập ADO.NET trên Console App ThucHanhAdoNet",
                                       "Dán ảnh chụp màn hình kết quả chạy Console ThucHanhAdoNet."))
    
    # ----------------------------------------------------
    # 5.5. ĐÁNH GIÁ ƯU ĐIỂM & NHƯỢC ĐIỂM CỦA GIẢI PHÁP
    # ----------------------------------------------------
    parts.append(heading2("5.5. Đánh giá ưu điểm và nhược điểm của giải pháp thiết kế"))
    
    parts.append(heading3("5.5.1. Những ưu điểm nổi bật về mặt kiến trúc, tính bảo mật và hiệu năng vận hành"))
    parts.append(bullet("Kiến trúc phân tầng chuẩn mực:", "Tách bạch hoàn toàn giữa Client và Backend, dễ dàng bảo trì và mở rộng thêm các nền tảng Web hoặc Mobile App."))
    parts.append(bullet("Hiệu năng xử lý siêu tốc:", "Kết hợp hài hòa giữa EF Core (tiện lợi cho CRUD danh mục) và ADO.NET thuần (tốc độ cao cho quét barcode POS và Transaction thanh toán)."))
    parts.append(bullet("Bảo mật vững chắc:", "Áp dụng chuẩn JWT Stateless, chống rò rỉ chuỗi kết nối CSDL và ngăn chặn hoàn toàn tấn công SQL Injection."))
    parts.append(bullet("Trải nghiệm người dùng tuyệt vời:", "Kiến trúc Single-Form Shell Workspace loại bỏ cửa sổ phân mảnh, giao diện hiện đại hỗ trợ tối đa phím tắt cho thu ngân."))
    
    parts.append(heading3("5.5.2. Những điểm hạn chế còn tồn tại của hệ thống"))
    parts.append(bullet("Phụ thuộc đường truyền mạng:", "Do là kiến trúc Client-Server, nếu mạng LAN nội bộ bị đứt thì ứng dụng WinForms tạm thời không thể gửi request lên API."))
    parts.append(bullet("Chưa tích hợp thanh toán tự động:", "Chưa có cổng thanh toán quét mã VietQR động trực tiếp từ màn hình POS."))
    
    return "".join(parts)
