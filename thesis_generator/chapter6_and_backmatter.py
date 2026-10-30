# -*- coding: utf-8 -*-
from thesis_generator.builder import (p, heading1, heading2, heading3, make_table, 
                                      page_break, bullet, code_block, note_box)

def get_chapter6_xml():
    parts = []
    
    parts.append(heading1("CHƯƠNG 6: KẾT LUẬN VÀ HƯỚNG PHÁT TRIỂN NÂNG CẤP", page_break_before=True))
    
    # ----------------------------------------------------
    # 6.1. KẾT QUẢ ĐẠT ĐƯỢC CỦA ĐỒ ÁN
    # ----------------------------------------------------
    parts.append(heading2("6.1. Kết quả đạt được của đồ án đối với sinh viên"))
    
    parts.append(heading3("6.1.1. Mức độ hoàn thành các chức năng so với yêu cầu và đề cương môn học"))
    parts.append(p("Sau quá trình nỗ lực nghiên cứu lý thuyết và thực hành lập trình trong suốt 6 buổi học thực hành phòng máy, đồ án \"Xây dựng Giải pháp Quản lý Kho và Thanh toán Điện tử cho Cửa hàng Mini -- Cửa hàng Đồ ăn vặt Ăn Vặt Store\" đã hoàn thành 100% tất cả các mục tiêu chức năng và phi chức năng được đề ra trong đề cương môn học:"))
    
    rubric_headers = ["STT", "Hạng mục tiêu chí đánh giá", "Mức độ hoàn thành", "Đánh giá chi tiết kết quả thực tế"]
    rubric_rows = [
        ["1", "Kiến trúc hệ thống 3 lớp", "100% ĐẠT", "Tách bạch hoàn toàn WinForms Desktop Client, ASP.NET Core Web API 8 và SQL Server Database."],
        ["2", "Tầng dữ liệu EF Core Code-First", "100% ĐẠT", "Thiết lập SupermarketDbContext, Fluent API, Migrations, Eager Loading .Include() và Phân trang LINQ Skip/Take."],
        ["3", "Tầng dữ liệu ADO.NET thuần túy", "100% ĐẠT", "Sử dụng SqlDataReader tra cứu Barcode <100ms, chống SQL Injection với SqlParameter, gọi Stored Procedure."],
        ["4", "Toàn vẹn giao dịch ACID", "100% ĐẠT", "Bọc kín chuỗi 4 thao tác thanh toán trong SqlTransaction; Rollback an toàn khi vượt tồn kho, Commit chuẩn."],
        ["5", "Bảo mật & Phân quyền JWT / RBAC", "100% ĐẠT", "Cấp phát Bearer Token mã hóa HMAC SHA-256, kiểm soát phân quyền đa tầng [Authorize(Roles = '...')] và UI Sidebar."],
        ["6", "Giao diện Desktop WinForms POS", "100% ĐẠT", "Kiến trúc Single-Form Shell Workspace, nhúng Form động, thao tác phím tắt F2/F9, hỗ trợ máy quét Barcode USB."],
        ["7", "Tài liệu hóa Swagger & Báo cáo", "100% ĐẠT", "Tích hợp giao diện Swagger UI có nút Authorize, xuất báo cáo doanh số Stored Procedure và xuất Excel."],
        ["8", "Quy chuẩn Git & Tài liệu", "100% ĐẠT", "Đầy đủ lịch sử commit tương ứng từng buổi học, file README.md chi tiết và thuyết minh đồ án chuẩn khoa học."]
    ]
    parts.append(make_table(rubric_headers, rubric_rows, [700, 3160, 1700, 3800], header_bg="1B365D"))
    parts.append(p("Bảng 6.1: Bảng tổng kết mức độ hoàn thành các tiêu chí đồ án môn học", bold=True, italic=True, size=24, color="334155", align="center", space_after=180))
    
    parts.append(heading3("6.1.2. Những kiến thức học thuật và kỹ năng kỹ thuật phần mềm tích lũy được qua đồ án"))
    parts.append(p("Thông qua quá trình hiện thực đồ án môn học này, bản thân sinh viên đã tích lũy được những hành trang kiến thức và kỹ năng nghề nghiệp vô cùng quý giá:"))
    parts.append(bullet("Làm chủ ngôn ngữ C# và Modern .NET:", "Nắm vững cơ chế vận hành bên dưới của CLR, JIT Compiler, cơ chế quản lý bộ nhớ Stack/Heap, chu kỳ thu gom rác Garbage Collector và phong cách lập trình bất đồng bộ tối ưu async/await."))
    parts.append(bullet("Tư duy thiết kế kiến trúc chuẩn mực:", "Hiểu rõ sự khác biệt giữa kiến trúc Monolithic và hướng dịch vụ SOA, biết cách thiết kế các RESTful API chuẩn quốc tế với các quy chuẩn danh từ số nhiều, mã trạng thái HTTP Codes và định dạng trao đổi dữ liệu JSON."))
    parts.append(bullet("Kỹ năng xử lý dữ liệu cấp cao và cấp thấp:", "Biết cách dung hòa sức mạnh của cả hai trường phái: dùng EF Core cho tính linh hoạt và năng suất lập trình cao; dùng ADO.NET thuần cho hiệu năng xử lý dữ liệu thời gian thực và kiểm soát toàn vẹn giao dịch tài chính ACID."))
    parts.append(bullet("Kỹ năng bảo mật ứng dụng doanh nghiệp:", "Thành thạo cơ chế xác thực không trạng thái JWT, kỹ thuật ký số HMAC SHA-256 và mô hình phân quyền RBAC."))
    parts.append(bullet("Kỹ năng tổ chức giao diện Desktop hiện đại:", "Áp dụng thành công kiến trúc Shell Workspace cho Windows Forms, quản lý vòng đời socket mạng bằng Singleton HttpClient, ngăn chặn triệt để sự cố Socket Exhaustion."))
    
    # ----------------------------------------------------
    # 6.2. HƯỚNG PHÁT TRIỂN VÀ NÂNG CẤP
    # ----------------------------------------------------
    parts.append(heading2("6.2. Hướng phát triển và nâng cấp hệ thống trong tương lai"))
    parts.append(p("Mặc dù hệ thống đã đáp ứng hoàn hảo các yêu cầu cốt lõi của một phần mềm quản lý bán lẻ tại quầy, song nhằm bắt kịp xu hướng phát triển của ngành thương mại điện tử và công nghệ số, đồ án đề xuất 3 định hướng nâng cấp trong tương lai gần:"))
    
    parts.append(heading3("6.2.1. Tích hợp thanh toán trực tuyến thông qua chuẩn mã VietQR động hoặc Cổng thanh toán điện tử (VNPay, MoMo)"))
    parts.append(p("Xu hướng thanh toán không tiền mặt (Cashless Payment) tại Việt Nam đang bùng nổ mạnh mẽ. Hệ thống có thể mở rộng tích hợp API tạo mã VietQR động:"))
    parts.append(bullet("Cơ chế vận hành VietQR động:", "Khi thu ngân bấm phím F9 Thanh toán, ứng dụng WinForms gọi API ngân hàng (theo chuẩn NAPAS 247) để sinh ra một mã QR Code động hiển thị lên màn hình phụ hướng về phía khách hàng. Mã QR này chứa sẵn chính xác số tiền cần thanh toán và nội dung chuyển khoản là OrderCode (ví dụ: HD-20261027-0016)."))
    parts.append(bullet("Tự động xác nhận qua Webhook:", "Khi khách hàng quét mã thanh toán bằng app ngân hàng thành công, cổng thanh toán sẽ tự động bắn một tín hiệu Webhook về Web API của cửa hàng, kích hoạt lưu đơn hàng tức thì mà thu ngân không cần phải kiểm tra sao kê tài khoản thủ công."))
    
    parts.append(heading3("6.2.2. Mở rộng ứng dụng Web dành cho khách hàng tự đặt hàng (E-Commerce) và Ứng dụng Di động dành cho nhân viên kho kiểm kê hàng hóa qua camera"))
    parts.append(p("Nhờ ưu thế vượt trội của kiến trúc RESTful Web API tách bạch tầng Backend, việc mở rộng thêm các nền tảng người dùng mới trở nên vô cùng dễ dàng mà không cần viết lại bất kỳ dòng mã logic CSDL nào:"))
    parts.append(bullet("Ứng dụng Web E-Commerce (React / Next.js):", "Cho phép khách hàng ngồi tại nhà có thể lướt xem danh mục đồ ăn vặt, đặt mua online và chọn giao hàng tận nơi."))
    parts.append(bullet("Ứng dụng Di động kiểm kho (Flutter / .NET MAUI):", "Cung cấp cho nhân viên thủ kho ứng dụng chạy trên điện thoại thông minh (Android/iOS). Nhân viên có thể sử dụng chính camera của điện thoại để quét mã vạch kiểm kê hàng tồn trực tiếp trên từng kệ hàng, tự động đối soát với số lượng trên CSDL."))
    
    parts.append(heading3("6.2.3. Tích hợp thuật toán trí tuệ nhân tạo (AI/Machine Learning) dự báo nhu cầu nhập hàng và gợi ý sản phẩm bán kèm tại quầy thu ngân"))
    parts.append(p("Ứng dụng công nghệ phân tích dữ liệu lớn và học máy (ML.NET) vào dữ liệu lịch sử bán hàng:"))
    parts.append(bullet("Dự báo nhu cầu tồn kho (Demand Forecasting):", "Phân tích xu hướng tiêu thụ của từng mặt hàng theo ngày trong tuần, thời tiết và các dịp lễ tết để tự động đưa ra khuyến nghị số lượng cần nhập về cho thủ kho, tránh đọng vốn hoặc thiếu hàng."))
    parts.append(bullet("Gợi ý bán kèm (Cross-Selling Recommender):", "Áp dụng thuật toán khai phá luật kết hợp (Association Rules - Apriori) để nhận diện các mặt hàng thường được mua cùng nhau (ví dụ: Khách mua Bánh que thường mua kèm Trà đào). Khi thu ngân quét bánh que, màn hình POS sẽ tự động nhắc nhở thu ngân mời khách dùng thêm nước uống giải khát, giúp gia tăng doanh số bán hàng."))
    
    # ----------------------------------------------------
    # TÀI LIỆU THAM KHẢO
    # ----------------------------------------------------
    parts.append(heading1("TÀI LIỆU THAM KHẢO", page_break_before=True))
    parts.append(p("Các giáo trình chuyên ngành, tài liệu học thuật chính thống và tiêu chuẩn kỹ thuật được tham khảo trong quá trình nghiên cứu và thực hiện đồ án bao gồm:"))
    
    ref_list = [
        ["[1]", "Microsoft Learn (2024), \"ASP.NET Core Documentation & Modern .NET 8 Guide\", Microsoft Corporation. Truy cập tại: https://learn.microsoft.com/aspnet/core/"],
        ["[2]", "Microsoft Learn (2024), \"Entity Framework Core Documentation\", Microsoft Corporation. Truy cập tại: https://learn.microsoft.com/ef/core/"],
        ["[3]", "Microsoft Learn (2024), \"ADO.NET Architecture & SqlClient Overview\", Microsoft Corporation. Truy cập tại: https://learn.microsoft.com/dotnet/framework/data/adonet/"],
        ["[4]", "Andrew Troelsen, Philip Japikse (2022), \"Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming\", 11th Edition, Apress Publishing."],
        ["[5]", "Christian Nagel (2021), \"Professional C# and .NET 2021 Edition\", Wiley Publishing."],
        ["[6]", "Roy Thomas Fielding (2000), \"Architectural Styles and the Design of Network-based Software Architectures\", Doctoral dissertation, University of California, Irvine."],
        ["[7]", "IETF RFC 7519 (2015), \"JSON Web Token (JWT)\", Internet Engineering Task Force. Truy cập tại: https://tools.ietf.org/html/rfc7519"],
        ["[8]", "Khoa Công nghệ Thông tin - Trường Cao đẳng Công Thương TP.HCM (2024), \"Đề cương chi tiết học phần Lập trình Ứng dụng C# .NET Core\", HITC."]
    ]
    parts.append(make_table(["Mã số", "Thông tin tác giả, Tên tài liệu, Nhà xuất bản / Đường dẫn truy cập"], ref_list, [1200, 8160], header_bg="1B365D"))
    parts.append(p("", space_after=200))
    
    # ----------------------------------------------------
    # PHỤ LỤC HƯỚNG DẪN CÀI ĐẶT & VẬN HÀNH
    # ----------------------------------------------------
    parts.append(heading1("PHỤ LỤC: HƯỚNG DẪN CÀI ĐẶT & VẬN HÀNH HỆ THỐNG", page_break_before=True))
    
    parts.append(heading2("Phụ lục A: Hướng dẫn cấu hình kết nối SQL Server và các lệnh thực thi EF Core Migrations"))
    parts.append(p("Bước 1: Khởi tạo Cơ sở dữ liệu và nạp dữ liệu mẫu bằng tệp SQL script có sẵn:"))
    parts.append(code_block("sqlcmd -S localhost -E -i \"Buoi5_Setup_MiniSupermarketDb.sql\""))
    parts.append(p("Bước 2: Kiểm tra chuỗi kết nối trong tệp MiniSupermarket.API/appsettings.json, đảm bảo Server trỏ tới đúng tên máy chủ SQL Server nội bộ."))
    parts.append(p("Bước 3: Thực thi cập nhật Migration (nếu phát triển thêm thực thể mới):"))
    parts.append(code_block("dotnet ef database update --project MiniSupermarket.API"))
    
    parts.append(heading2("Phụ lục B: Danh sách bảng tài khoản người dùng mẫu và phân quyền truy cập hệ thống"))
    parts.append(p("Bảng tài khoản mẫu phục vụ chấm thi và nghiệm thu chức năng phân quyền:"))
    demo_acc_headers = ["STT", "Tên tài khoản", "Mật khẩu", "Họ và tên nhân sự", "Vai trò (Role)", "Chức năng cho phép"]
    demo_acc_rows = [
        ["1", "admin01", "123456", "Trần Hoàng Lin", "ADMIN", "Toàn quyền quản trị toàn bộ hệ thống"],
        ["2", "cashier01", "123456", "Lê Thị Thu Ngân 01", "CASHIER", "Bán hàng quầy POS, tra barcode, báo cáo ca"],
        ["3", "ware01", "123456", "Bùi Văn Thủ Kho 01", "WAREHOUSE", "Quản lý danh mục hàng hóa, phân trang, tồn kho"]
    ]
    parts.append(make_table(demo_acc_headers, demo_acc_rows, [700, 1600, 1400, 2460, 1600, 1600], header_bg="0284C7"))
    
    parts.append(heading2("Phụ lục C: Bảng thống kê chi tiết mã nguồn các Controller và Form giao diện chính"))
    code_stat_headers = ["Project", "Tên tệp mã nguồn", "Dòng mã (LOC)", "Nhiệm vụ kỹ thuật chính"]
    code_stat_rows = [
        ["API", "Controllers/CheckoutController.cs", "340 dòng", "Xử lý giao dịch thanh toán POS chuẩn ACID bọc SqlTransaction."],
        ["API", "Controllers/ProductsController.cs", "280 dòng", "Phân trang Server-side với LINQ Skip/Take và CRUD EF Core."],
        ["API", "Controllers/AdoProductController.cs", "210 dòng", "Tra cứu Barcode siêu tốc bằng SqlDataReader và Disconnected Cache."],
        ["API", "Controllers/ReportsController.cs", "260 dòng", "Thực thi Stored Procedure sp_GetRevenueByCashier kết xuất doanh thu."],
        ["API", "Controllers/AuthController.cs", "160 dòng", "Xác thực đăng nhập và cấp phát JWT Bearer Token đối xứng."],
        ["WinForms", "FormPOS.cs", "480 dòng", "Giao diện thu ngân POS, bắt sự kiện Barcode, tính tiền thối, gọi Checkout."],
        ["WinForms", "FormProductManagement.cs", "420 dòng", "Lưới hiển thị sản phẩm, ComboBox lọc nhóm, cụm nút phân trang Prev/Next."],
        ["WinForms", "FormMainShell.cs", "260 dòng", "Khung Single-Form Shell Workspace, điều khiển nhúng form động và RBAC."],
        ["WinForms", "SessionManager.cs", "180 dòng", "Lưu trữ phiên làm việc và ApiClientService quản lý static HttpClient."]
    ]
    parts.append(make_table(code_stat_headers, code_stat_rows, [1400, 3160, 1400, 3400], header_bg="1B365D"))
    
    parts.append(heading2("Phụ lục D: Đường link GitHub, Tài khoản demo và Hướng dẫn khởi chạy nhanh"))
    parts.append(bullet("Đường link kho mã nguồn GitHub:", "https://github.com/tranhoanglin12092006/MiniSuperMarket-Tran_Hoang_Lin"))
    parts.append(bullet("Lịch sử Commit:", "Hơn 15 lần Commit chi tiết, tuân thủ nghiêm ngặt tiến độ thực hành từ Buổi 1 đến Buổi 6."))
    parts.append(bullet("Lệnh khởi chạy nhanh Backend Web API:", "dotnet run --project MiniSupermarket.API"))
    parts.append(bullet("Đường dẫn kiểm thử Swagger UI:", "https://localhost:7167/swagger"))
    parts.append(bullet("Lệnh khởi chạy nhanh Desktop WinForms Client:", "dotnet run --project MiniSupermarket.WinForms"))
    
    return "".join(parts)
