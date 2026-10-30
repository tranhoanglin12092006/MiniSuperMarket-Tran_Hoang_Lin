# -*- coding: utf-8 -*-
from thesis_generator.builder import p, heading1, heading2, heading3, make_table, page_break, bullet

def get_frontmatter_xml():
    parts = []
    
    # ==========================================
    # 1. TRANG BÌA CHÍNH (COVER 1)
    # ==========================================
    parts.append(p("BỘ CÔNG THƯƠNG", bold=True, size=28, color="1B365D", align="center", space_before=100, space_after=40))
    parts.append(p("TRƯỜNG CAO ĐẲNG CÔNG THƯƠNG TP. HỒ CHÍ MINH", bold=True, size=30, color="0284C7", align="center", space_before=0, space_after=40))
    parts.append(p("KHOA CÔNG NGHỆ THÔNG TIN", bold=True, size=26, color="1E293B", align="center", space_before=0, space_after=100))
    parts.append(p("------------------------- ★★★ -------------------------", bold=True, size=22, color="94A3B8", align="center", space_after=280))
    
    parts.append(p("ĐỒ ÁN MÔN HỌC", bold=True, size=36, color="DC2626", align="center", space_before=160, space_after=80))
    parts.append(p("LẬP TRÌNH ỨNG DỤNG C# .NET CORE", bold=True, size=32, color="1B365D", align="center", space_before=0, space_after=260))
    
    # Khung đề tài nổi bật
    title_box = [
        ["ĐỀ TÀI NGHIÊN CỨU & XÂY DỰNG HỆ THỐNG:"],
        ["XÂY DỰNG GIẢI PHÁP QUẢN LÝ KHO VÀ THANH TOÁN ĐIỆN TỬ CHO CỬA HÀNG MINI\nCỬA HÀNG ĐỒ ĂN VẶT \"ĂN VẶT STORE\""],
        ["Áp dụng kiến trúc 3 lớp: WinForms Desktop Client – ASP.NET Core Web API (.NET 8) – SQL Server RDBMS kết hợp ADO.NET thuần chuẩn ACID, Entity Framework Core và Cơ chế Bảo mật JWT/RBAC"]
    ]
    parts.append(make_table(["THÔNG TIN ĐỀ TÀI ĐỒ ÁN MÔN HỌC"], [
        ["XÂY DỰNG GIẢI PHÁP QUẢN LÝ KHO VÀ THANH TOÁN ĐIỆN TỬ CHO CỬA HÀNG MINI -- CỬA HÀNG ĐỒ ĂN VẶT \"ĂN VẶT STORE\"\n\nÁp dụng kiến trúc 3 lớp: Desktop WinForms Client – ASP.NET Core Web API – SQL Server Database"]
    ], [9360], header_bg="1B365D"))
    
    parts.append(p("", space_after=200))
    
    # Bảng thông tin sinh viên & giảng viên
    info_headers = ["Hạng mục", "Thông tin chi tiết"]
    info_rows = [
        ["Giảng viên hướng dẫn:", "ThS. NGUYỄN CAO THÁI"],
        ["Sinh viên thực hiện:", "TRẦN HOÀNG LIN"],
        ["Mã số sinh viên (MSSV):", "2124110134"],
        ["Lớp chuyên ngành:", "CCQ2411D"],
        ["Ngành đào tạo:", "Công nghệ Thông tin (Lập trình Ứng dụng .NET)"],
        ["Khóa đào tạo:", "Khóa 2024 - 2027"]
    ]
    parts.append(make_table(info_headers, info_rows, [3400, 5960], header_bg="0284C7"))
    
    parts.append(p("", space_after=400))
    parts.append(p("TP. HỒ CHÍ MINH, THÁNG 10 NĂM 2026", bold=True, size=24, color="475569", align="center", space_before=200, space_after=100))
    parts.append(page_break())
    
    # ==========================================
    # 2. TRANG BÌA PHỤ (COVER 2)
    # ==========================================
    parts.append(p("BỘ CÔNG THƯƠNG", bold=True, size=26, color="1B365D", align="center", space_before=100, space_after=40))
    parts.append(p("TRƯỜNG CAO ĐẲNG CÔNG THƯƠNG TP. HỒ CHÍ MINH", bold=True, size=28, color="0284C7", align="center", space_after=40))
    parts.append(p("KHOA CÔNG NGHỆ THÔNG TIN", bold=True, size=24, color="1E293B", align="center", space_after=100))
    parts.append(p("------------------------- ★★★ -------------------------", bold=True, size=20, color="94A3B8", align="center", space_after=200))
    
    parts.append(p("BÁO CÁO THUYẾT MINH ĐỒ ÁN MÔN HỌC", bold=True, size=32, color="1B365D", align="center", space_before=120, space_after=100))
    parts.append(p("ĐỀ TÀI: GIẢI PHÁP QUẢN LÝ BÁN LẺ & QUẦY THU NGÂN POS ĂN VẶT STORE", bold=True, size=26, color="0284C7", align="center", space_after=240))
    
    sec_info_headers = ["Tiêu chí", "Thông tin sinh viên và người hướng dẫn"]
    sec_info_rows = [
        ["Họ và tên tác giả:", "Trần Hoàng Lin"],
        ["Mã số sinh viên:", "2124110134"],
        ["Lớp học phần:", "CCQ2411D"],
        ["Cơ sở đào tạo:", "Khoa CNTT - Trường Cao Đẳng Công Thương TP.HCM"],
        ["Cán bộ / GV hướng dẫn:", "ThS. Nguyễn Cao Thái"],
        ["Điểm đánh giá GVHD:", "...................... / 10.0 điểm"],
        ["Chữ ký của GVHD:", "........................................................"]
    ]
    parts.append(make_table(sec_info_headers, sec_info_rows, [3200, 6160], header_bg="1B365D"))
    parts.append(page_break())
    
    # ==========================================
    # 3. LỜI CAM ĐOAN
    # ==========================================
    parts.append(heading1("LỜI CAM ĐOAN", page_break_before=False))
    parts.append(p("Tôi xin cam đoan rằng toàn bộ nội dung thuyết minh và mã nguồn được trình bày trong cuốn đồ án môn học \"Xây dựng Giải pháp Quản lý Kho và Thanh toán Điện tử cho Cửa hàng Mini -- Cửa hàng Đồ ăn vặt Ăn Vặt Store\" là công trình nghiên cứu và hiện thực nghiêm túc của cá nhân tôi dưới sự hướng dẫn trực tiếp của ThS. Nguyễn Cao Thái."))
    parts.append(p("Toàn bộ các số liệu khảo sát nghiệp vụ, kiến trúc thiết kế 3 lớp, sơ đồ dòng chảy dữ liệu DFD, sơ đồ thực thể liên kết ERD, cùng hệ thống mã nguồn Backend ASP.NET Core Web API, mã nguồn Frontend WinForms POS Desktop và kịch bản cơ sở dữ liệu SQL Server được triển khai hoàn toàn trung thực, không sao chép bất hợp pháp từ bất kỳ công trình hoặc sinh viên nào khác."))
    parts.append(p("Các đoạn mã mẫu, thư viện mã nguồn mở bên thứ ba (như Microsoft.Data.SqlClient, EntityFrameworkCore, Swashbuckle, BCrypt.Net, System.IdentityModel.Tokens.Jwt) và tài liệu học thuật được trích dẫn đều có nguồn gốc tham khảo rõ ràng tại danh mục Tài liệu tham khảo của báo cáo."))
    parts.append(p("Nếu có bất kỳ sự gian lận hoặc vi phạm quy chế học vụ nào về tính liêm chính học thuật, tôi xin chịu hoàn toàn mọi hình thức kỷ luật theo quy định hiện hành của Trường Cao đẳng Công Thương TP. Hồ Chí Minh."))
    
    parts.append(p("", space_after=200))
    parts.append(p("TP. Hồ Chí Minh, ngày 27 tháng 10 năm 2026", italic=True, size=24, color="334155", align="right", space_after=60))
    parts.append(p("Tác giả đồ án", bold=True, size=26, color="1E293B", align="right", space_after=200))
    parts.append(p("Trần Hoàng Lin", bold=True, size=26, color="0284C7", align="right", space_after=100))
    parts.append(page_break())
    
    # ==========================================
    # 4. LỜI CẢM ƠN
    # ==========================================
    parts.append(heading1("LỜI CẢM ƠN", page_break_before=False))
    parts.append(p("Để hoàn thành đồ án môn học Lập trình Ứng dụng C# .NET Core một cách trọn vẹn và đạt chất lượng chuyên môn cao, tôi đã nhận được sự quan tâm, chỉ dẫn tận tình và động viên quý báu từ quý Thầy Cô, gia đình cùng bạn bè đồng môn."))
    parts.append(p("Trước hết, tôi xin bày tỏ lòng biết ơn sâu sắc và chân thành nhất tới ThS. Nguyễn Cao Thái – Giảng viên trực tiếp giảng dạy và tận tâm hướng dẫn môn học. Thầy đã không ngừng truyền đạt những kiến thức chuyên môn cốt lõi về nền tảng Microsoft .NET Core hiện đại, phương pháp tiếp cận lập trình hướng đối tượng, tư duy thiết kế kiến trúc RESTful Web API, kỹ thuật tối ưu hóa ADO.NET thuần, kiểm soát toàn vẹn giao dịch ACID cũng như chuẩn mực tổ chức giao diện Desktop WinForms chuyên nghiệp. Những góp ý, phản biện và định hướng chi tiết của Thầy trong suốt các buổi học thực hành phòng máy là nền tảng quyết định giúp hệ thống phần mềm và cuốn thuyết minh đồ án này được hoàn thiện đúng quy chuẩn khoa học."))
    parts.append(p("Tôi cũng xin trân trọng gửi lời cảm ơn tới Ban Giám hiệu cùng toàn thể quý Thầy Cô Khoa Công nghệ Thông tin – Trường Cao đẳng Công Thương TP. Hồ Chí Minh (HITC) đã tận tình giảng dạy, trang bị cho chúng tôi những khối kiến thức nền tảng vững vàng về Cơ sở dữ liệu quan hệ, Lập trình ứng dụng, Kiến trúc phần mềm và Mạng máy tính trong suốt quá trình theo học tại trường."))
    parts.append(p("Mặc dù bản thân đã dành rất nhiều thời gian, tâm huyết và nỗ lực nghiên cứu để hoàn thiện hệ thống phần mềm và bản thuyết minh này, song do kiến thức và kinh nghiệm thực tiễn của một sinh viên còn giới hạn, đồ án chắc chắn khó tránh khỏi những thiếu sót nhất định. Tôi rất kính mong nhận được những ý kiến đóng góp, nhận xét và chỉ dẫn quý báu từ quý Thầy Cô trong Hội đồng chấm đồ án để hệ thống ngày càng hoàn thiện, có tính ứng dụng cao hơn trong thực tiễn bán lẻ."))
    parts.append(p("Kính chúc quý Thầy Cô luôn dồi dào sức khỏe, niềm vui, hạnh phúc và luôn gặt hái nhiều thành tựu rực rỡ trong sự nghiệp giáo dục cao quý!"))
    
    parts.append(p("", space_after=200))
    parts.append(p("TP. Hồ Chí Minh, ngày 27 tháng 10 năm 2026", italic=True, size=24, color="334155", align="right", space_after=60))
    parts.append(p("Sinh viên thực hiện", bold=True, size=26, color="1E293B", align="right", space_after=200))
    parts.append(p("Trần Hoàng Lin", bold=True, size=26, color="0284C7", align="right", space_after=100))
    parts.append(page_break())
    
    # ==========================================
    # 5. PHIẾU NHẬN XÉT VÀ ĐÁNH GIÁ CỦA GVHD
    # ==========================================
    parts.append(heading1("PHIẾU NHẬN XÉT VÀ ĐÁNH GIÁ CỦA GIẢNG VIÊN HƯỚNG DẪN", page_break_before=False))
    parts.append(p("Học phần: Lập trình Ứng dụng C# .NET Core | Lớp: CCQ2411D", italic=True, size=24, color="475569", space_after=100))
    parts.append(p("Giảng viên hướng dẫn: ThS. Nguyễn Cao Thái", bold=True, size=26, color="1B365D", space_after=40))
    parts.append(p("Sinh viên thực hiện: Trần Hoàng Lin - MSSV: 2124110134", bold=True, size=26, color="0284C7", space_after=140))
    parts.append(p("Đề tài: Xây dựng Giải pháp Quản lý Kho và Thanh toán Điện tử cho Cửa hàng Mini -- Cửa hàng Đồ ăn vặt Ăn Vặt Store", bold=True, size=24, color="1E293B", space_after=160))
    
    eval_headers = ["STT", "Tiêu chí đánh giá chất lượng đồ án", "Trọng số", "Điểm tối đa", "Điểm đánh giá"]
    eval_rows = [
        ["1", "Hình thức trình bày, bố cục và quy chuẩn văn bản (Định dạng Word chuẩn, bìa, lời cam đoan, mục lục, bảng biểu)", "10%", "1.0", "........."],
        ["2", "Tổng quan đề tài & Cơ sở lý thuyết nền tảng (C# .NET 8, CLR, async/await, RESTful, JSON, EF Core, ADO.NET, JWT)", "15%", "1.5", "........."],
        ["3", "Phân tích yêu cầu & Thiết kế hệ thống (Luồng nghiệp vụ, Sơ đồ 3 lớp, DFD, ERD, 6 bảng CSDL, Đặc tả danh mục API)", "20%", "2.0", "........."],
        ["4", "Hiện thực Tầng Backend ASP.NET Core Web API (DI, EF Core Code-First, Paging Skip/Take, ADO.NET ACID, JWT Bearer, Swagger)", "25%", "2.5", "........."],
        ["5", "Hiện thực Ứng dụng Máy trạm WinForms Client (Single-Form Shell, Nhúng Form động, POS Barcode, HttpClient tập trung)", "15%", "1.5", "........."],
        ["6", "Kịch bản và Kết quả kiểm thử (Kiểm thử API, Kiểm thử ACID Commit & Rollback khi hết hàng, Đối soát CSDL SSMS)", "10%", "1.0", "........."],
        ["7", "Đánh giá kết quả, Lịch sử Git commits, File README chuẩn và Định hướng phát triển hệ thống", "5%", "0.5", "........."],
        ["TỔNG", "ĐIỂM TỔNG CỘNG ĐỒ ÁN MÔN HỌC", "100%", "10.0", "........."]
    ]
    parts.append(make_table(eval_headers, eval_rows, [700, 4860, 1100, 1200, 1500], header_bg="1B365D"))
    
    parts.append(p("NHẬN XÉT CỤ THỂ CỦA GIẢNG VIÊN HƯỚNG DẪN:", bold=True, size=26, color="1B365D", space_before=160, space_after=80))
    parts.append(p("1. Về tinh thần, thái độ và tiến độ học tập thực hành: ........................................................................................................................................................................................................................................................................................................................"))
    parts.append(p("2. Về năng lực hiện thực mã nguồn Backend và Frontend: ........................................................................................................................................................................................................................................................................................................................"))
    parts.append(p("3. Về cấu trúc cơ sở dữ liệu và bảo toàn giao dịch ACID: ........................................................................................................................................................................................................................................................................................................................"))
    parts.append(p("4. Điểm mạnh và những điểm cần cải tiến thêm: ................................................................................................................................................................................................................................................................................................................................"))
    
    parts.append(p("", space_after=200))
    parts.append(p("TP. Hồ Chí Minh, ngày ...... tháng ...... năm 2026", italic=True, size=24, color="334155", align="right", space_after=60))
    parts.append(p("Giảng viên hướng dẫn chấm điểm", bold=True, size=26, color="1E293B", align="right", space_after=220))
    parts.append(p("ThS. NGUYỄN CAO THÁI", bold=True, size=26, color="0284C7", align="right", space_after=100))
    parts.append(page_break())
    
    # ==========================================
    # 6. MỤC LỤC CHI TIẾT
    # ==========================================
    parts.append(heading1("MỤC LỤC TỔNG HỢP", page_break_before=False))
    
    toc_headers = ["Mục", "Nội dung đề mục chi tiết trong đồ án", "Trang"]
    toc_rows = [
        ["", "LỜI CẢM ƠN & LỜI CAM ĐOAN", "2 - 3"],
        ["", "PHIẾU NHẬN XÉT VÀ ĐÁNH GIÁ CỦA GIẢNG VIÊN HƯỚNG DẪN", "4"],
        ["", "DANH MỤC THUẬT NGỮ & TỪ VIẾT TẮT", "8"],
        ["", "DANH MỤC HÌNH ẢNH & SƠ ĐỒ", "9"],
        ["", "DANH MỤC BẢNG BIỂU", "11"],
        ["CHƯƠNG 1", "TỔNG QUAN ĐỀ TÀI VÀ CƠ SỞ LÝ THUYẾT NỀN TẢNG", "12"],
        ["1.1", "Tổng quan đề tài nghiên cứu", "12"],
        ["1.1.1", "Bối cảnh chuyển đổi số trong quản lý bán lẻ và chuỗi cửa hàng tiện lợi / siêu thị mini", "12"],
        ["1.1.2", "Lý do chọn đề tài và tính cấp thiết của việc xây dựng hệ thống quản lý bán lẻ", "13"],
        ["1.1.3", "Mục tiêu nghiên cứu và chuẩn đầu ra của đồ án môn học", "14"],
        ["1.1.4", "Đối tượng và phạm vi nghiên cứu của đề tài", "15"],
        ["1.2", "Cơ sở lý thuyết về nền tảng Microsoft .NET Core và ngôn ngữ C#", "16"],
        ["1.2.1", "Quá trình tiến hóa từ .NET Framework sang Modern .NET (.NET Core / .NET 8)", "16"],
        ["1.2.2", "Cơ chế thực thi mã nguồn: Mã trung gian (CIL), Trình biên dịch JIT và Bộ máy thực thi CLR", "17"],
        ["1.2.3", "Cơ chế quản lý bộ nhớ tự động: Bộ nhớ Stack, Heap và Trình thu gom rác (Garbage Collector)", "18"],
        ["1.2.4", "Các cú pháp hiện đại trong C#: Auto-properties, Generics, Nullable types và async/await", "19"],
        ["1.3", "Lý thuyết về Kiến trúc hướng dịch vụ (SOA) và chuẩn RESTful Web API", "21"],
        ["1.3.1", "So sánh kiến trúc nguyên khối (Monolithic) và Kiến trúc hướng dịch vụ (SOA)", "21"],
        ["1.3.2", "Nguyên lý thiết kế RESTful: Định danh tài nguyên (URI), quy chuẩn số nhiều và Stateless", "22"],
        ["1.3.3", "Giao thức truyền tải HTTP: Phương thức (GET, POST, PUT, DELETE) và Mã phản hồi Status Code", "23"],
        ["1.3.4", "Định dạng trao đổi dữ liệu JSON: Kỹ thuật Serialization và Deserialization", "24"],
        ["1.3.5", "Kiến trúc xử lý yêu cầu trong ASP.NET Core: DI Container và Middleware Pipeline", "25"],
        ["1.4", "Cơ sở lý thuyết về Cơ sở dữ liệu và Tầng truy xuất dữ liệu", "26"],
        ["1.4.1", "Hệ quản trị cơ sở dữ liệu quan hệ (RDBMS) và chuẩn hóa dữ liệu 3NF trên SQL Server", "26"],
        ["1.4.2", "Khái niệm Object-Relational Mapping (ORM) và cơ chế vận hành của Entity Framework Core", "27"],
        ["1.4.3", "Phương pháp tiếp cận Code-First, DbContext và Quản lý tiến hóa lược đồ qua EF Core Migrations", "28"],
        ["1.4.4", "Ngôn ngữ truy vấn tích hợp LINQ (Language Integrated Query) và cơ chế Deferred Execution", "29"],
        ["1.4.5", "Công nghệ ADO.NET thuần: Kiến trúc kết nối/ngắt kết nối, Stored Procedure và chuẩn ACID", "30"],
        ["1.5", "Lý thuyết về Cơ chế Bảo mật và Xác thực không trạng thái (JWT)", "31"],
        ["1.5.1", "So sánh cơ chế xác thực dựa trên Session truyền thống và Xác thực không trạng thái (JWT)", "31"],
        ["1.5.2", "Cấu trúc chuẩn của chuỗi JSON Web Token: Header, Payload (Claims), và Signature", "32"],
        ["1.5.3", "Thuật toán ký đối xứng (HMAC SHA-256) và Quy trình ủy quyền theo vai trò (RBAC)", "33"],
        ["1.6", "Kiến trúc Desktop Client trên nền tảng Windows Forms", "34"],
        ["1.6.1", "Nguyên lý giao tiếp giữa ứng dụng máy trạm và Backend API thông qua lớp HttpClient", "34"],
        ["1.6.2", "Kỹ thuật quản trị tài nguyên mạng: Khắc phục sự cố cạn kiệt cổng kết nối (Socket Exhaustion)", "35"],
        ["1.6.3", "Kiến trúc giao diện bàn làm việc đơn (Single-Form Shell Workspace) và cơ chế nhúng Form động", "36"],
        ["CHƯƠNG 2", "PHÂN TÍCH YÊU CẦU VÀ THIẾT KẾ HỆ THỐNG", "38"],
        ["2.1", "Phân tích yêu cầu chức năng và luồng nghiệp vụ hệ thống siêu thị mini", "38"],
        ["2.1.1", "Luồng phân quyền và xác thực người dùng (Quản trị viên, Thu ngân, Thủ kho)", "38"],
        ["2.1.2", "Luồng nghiệp vụ quản lý danh mục nhóm hàng và mặt hàng tồn kho", "39"],
        ["2.1.3", "Luồng nghiệp vụ quầy thu ngân bán lẻ (POS): Tra cứu mã vạch, tính tiền, trừ kho và tích điểm", "40"],
        ["2.1.4", "Luồng nghiệp vụ báo cáo thống kê doanh thu và hiệu suất ca trực", "41"],
        ["2.2", "Thiết kế mô hình kiến trúc Client - Server tổng thể", "42"],
        ["2.2.1", "Sơ đồ kiến trúc 3 lớp: Desktop WinForms Client – ASP.NET Core Web API – SQL Server", "42"],
        ["2.2.2", "Sơ đồ tuần hoàn dòng chảy dữ liệu (Data Flow Diagram - DFD mức 0 và mức 1)", "43"],
        ["2.3", "Thiết kế Cơ sở dữ liệu quan hệ (Database Schema)", "44"],
        ["2.3.1", "Sơ đồ thực thể liên kết (ERD) hoàn chỉnh gồm 6 bảng thực thể cốt lõi", "44"],
        ["2.3.2 - 2.3.6", "Chi tiết các bảng: Users, Categories, Products, Customers, Orders, OrderDetails và Ràng buộc", "45 - 48"],
        ["2.4", "Thiết kế danh mục và đặc tả chuẩn RESTful Web API", "49"],
        ["2.4.1 - 2.4.6", "Đặc tả các phân hệ API: Auth, Categories, Products & Paged, POS Checkout, Reports", "49 - 52"],
        ["CHƯƠNG 3", "TRIỂN KHAI PHẦN BACKEND (ASP.NET CORE WEB API)", "53"],
        ["3.1", "Cấu trúc Solution và phân tách các tầng kiến trúc (Controllers, Data, Models, Program.cs)", "53"],
        ["3.2", "Hiện thực tầng dữ liệu với Entity Framework Core Code-First (Fluent API, Paging Skip/Take)", "55"],
        ["3.3", "Hiện thực phân hệ xác thực và phân quyền bảo mật (JWT & RBAC [Authorize])", "58"],
        ["3.4", "Hiện thực kỹ thuật ADO.NET nâng cao và Quản trị Giao dịch POS Checkout ACID", "60"],
        ["3.5", "Tài liệu hóa và chuẩn hóa kiểm thử API bằng Swagger / OpenAPI UI", "64"],
        ["CHƯƠNG 4", "TRIỂN KHAI PHẦN FRONTEND CLIENT (WINDOWS FORMS POS APP)", "66"],
        ["4.1", "Kiến trúc tổng thể, ApiClientService static HttpClient và SessionManager", "66"],
        ["4.2", "Hiện thực kiến trúc Single-Form Shell Workspace và kỹ thuật nhúng Form động", "68"],
        ["4.3", "Xây dựng các phân hệ màn hình nghiệp vụ Desktop (Login, POS, Products, Categories, Reports)", "70 - 74"],
        ["4.4", "Xử lý ngoại lệ, bọc try-catch mạng và thông báo lỗi HTTP 401/403 thân thiện", "75"],
        ["CHƯƠNG 5", "KIỂM THỬ HỆ THỐNG VÀ ĐÁNH GIÁ KẾT QUẢ ĐỒ ÁN", "76"],
        ["5.1 - 5.4", "Kiểm thử API Swagger, Kiểm thử ACID (Commit & Rollback hết kho), Thử nghiệm quầy POS", "76 - 81"],
        ["5.5", "Đánh giá ưu điểm và những điểm hạn chế còn tồn tại của hệ thống", "82"],
        ["CHƯƠNG 6", "KẾT LUẬN VÀ HƯỚNG PHÁT TRIỂN NÂNG CẤP", "83"],
        ["6.1 - 6.2", "Kết quả đạt được, Kiến thức tích lũy, Hướng tích hợp VietQR và AI dự báo", "83 - 85"],
        ["", "TÀI LIỆU THAM KHẢO & PHỤ LỤC KỸ THUẬT A, B, C, D", "86 - 90"]
    ]
    parts.append(make_table(toc_headers, toc_rows, [1400, 6760, 1200], header_bg="1B365D"))
    parts.append(page_break())
    
    # ==========================================
    # 7. DANH MỤC THUẬT NGỮ & TỪ VIẾT TẮT
    # ==========================================
    parts.append(heading1("DANH MỤC THUẬT NGỮ & TỪ VIẾT TẮT", page_break_before=False))
    parts.append(p("Dưới đây là bảng giải nghĩa các thuật ngữ kỹ thuật chuyên ngành và từ viết tắt được sử dụng xuyên suốt trong toàn bộ nội dung thuyết minh đồ án:"))
    
    abbr_headers = ["Từ viết tắt", "Tên tiếng Anh đầy đủ", "Ý nghĩa / Giải thích ngữ cảnh kỹ thuật trong đồ án"]
    abbr_rows = [
        ["ACID", "Atomicity, Consistency, Isolation, Durability", "Tiêu chuẩn 4 thuộc tính đảm bảo tính toàn vẹn tuyệt đối cho giao dịch CSDL (Tính nguyên tử, Tính nhất quán, Tính cô lập, Tính bền vững)."],
        ["ADO.NET", "ActiveX Data Objects .NET", "Bộ thư viện truy xuất dữ liệu tầng thấp hướng hiệu năng cao của Microsoft, sử dụng SqlConnection, SqlCommand, SqlDataReader."],
        ["API", "Application Programming Interface", "Giao diện lập trình ứng dụng, cầu nối cho phép các phần mềm độc lập trao đổi dữ liệu với nhau."],
        ["CIL / MSIL", "Common Intermediate Language", "Ngôn ngữ mã trung gian độc lập phần cứng được trình biên dịch C# sinh ra trước khi JIT dịch sang mã máy."],
        ["CLR", "Common Language Runtime", "Bộ máy thực thi ảo của .NET chịu trách nhiệm nạp mã, quản lý luồng, cấp phát bộ nhớ và kích hoạt GC."],
        ["CRUD", "Create, Read, Update, Delete", "Bộ 4 thao tác cơ bản trên bất kỳ hệ thống quản lý dữ liệu nào: Thêm, Đọc, Sửa, Xóa."],
        ["DFD", "Data Flow Diagram", "Sơ đồ dòng chảy dữ liệu biểu diễn trực quan luồng thông tin luân chuyển giữa các tiến trình và kho dữ liệu."],
        ["DI", "Dependency Injection", "Kỹ thuật thiết kế phần mềm (Design Pattern) đảo ngược điều khiển (IoC), tự động nạp thể hiện đối tượng dịch vụ qua constructor."],
        ["DTO", "Data Transfer Object", "Lớp đối tượng truyền tải dữ liệu giữa Client và Server, che giấu các trường bảo mật và tránh vòng lặp JSON."],
        ["EF Core", "Entity Framework Core", "Bộ ánh xạ đối tượng - quan hệ (ORM) hiện đại, đa nền tảng và mã nguồn mở hàng đầu của Microsoft."],
        ["ERD", "Entity Relationship Diagram", "Sơ đồ thực thể liên kết mô tả mối quan hệ 1-N, N-N giữa các bảng dữ liệu trong CSDL quan hệ."],
        ["GC", "Garbage Collector", "Trình thu gom rác tự động của CLR, dọn dẹp các đối tượng không còn tham chiếu trên bộ nhớ Heap."],
        ["HTTP", "Hypertext Transfer Protocol", "Giao thức truyền tải siêu văn bản nền tảng trên mạng máy tính và môi trường Web."],
        ["JIT", "Just-In-Time Compiler", "Trình biên dịch tức thời của .NET biên dịch mã trung gian CIL thành mã máy nhị phân lúc ứng dụng thực thi."],
        ["JSON", "JavaScript Object Notation", "Định dạng trao đổi dữ liệu văn bản gọn nhẹ, cấu trúc cặp khóa - giá trị (Key-Value) chuẩn RESTful."],
        ["JWT", "JSON Web Token", "Chuẩn mã xác thực không trạng thái (Stateless), đóng gói thông tin định danh và quyền hạn được ký số SHA-256."],
        ["LINQ", "Language Integrated Query", "Ngôn ngữ truy vấn tích hợp trực tiếp vào cú pháp C#, chuyển đổi biểu thức C# thành câu lệnh SQL."],
        ["ORM", "Object-Relational Mapping", "Kỹ thuật ánh xạ các bảng quan hệ trong CSDL thành các lớp đối tượng thực thể trong mã nguồn lập trình."],
        ["PK / FK", "Primary Key / Foreign Key", "Khóa chính (xác định duy nhất bản ghi) / Khóa ngoại (thiết lập mối liên kết toàn vẹn tham chiếu giữa 2 bảng)."],
        ["POS", "Point of Sale", "Hệ thống điểm bán lẻ tại quầy, phục vụ quét mã vạch, thanh toán tiền và in hóa đơn bán lẻ trực tiếp."],
        ["RBAC", "Role-Based Access Control", "Mô hình bảo mật kiểm soát và ủy quyền truy cập hệ thống dựa trên vai trò thực tế của người dùng."],
        ["RDBMS", "Relational Database Management System", "Hệ quản trị cơ sở dữ liệu quan hệ tổ chức dữ liệu theo bảng, hàng và cột (như Microsoft SQL Server)."],
        ["REST", "Representational State Transfer", "Kiến trúc thiết kế dịch vụ Web phi trạng thái, coi mọi thực thể là tài nguyên định danh qua URI."],
        ["SOA", "Service-Oriented Architecture", "Kiến trúc hướng dịch vụ, chia nhỏ hệ thống thành các thành phần dịch vụ độc lập giao tiếp qua mạng."],
        ["SSMS", "SQL Server Management Studio", "Công cụ phần mềm đồ họa quản trị toàn diện hệ quản trị cơ sở dữ liệu Microsoft SQL Server."]
    ]
    parts.append(make_table(abbr_headers, abbr_rows, [1600, 3160, 4600], header_bg="0284C7"))
    parts.append(page_break())
    
    # ==========================================
    # 8. DANH MỤC HÌNH ẢNH & SƠ ĐỒ
    # ==========================================
    parts.append(heading1("DANH MỤC HÌNH ẢNH & SƠ ĐỒ", page_break_before=False))
    
    fig_headers = ["Ký hiệu hình", "Tên nội dung sơ đồ / Ảnh chụp màn hình chức năng", "Vị trí trang"]
    fig_rows = [
        ["Hình 1.1", "Sơ đồ kiến trúc thực thi .NET: Mã C# -> CIL Compiler -> JIT -> Mã máy CPU", "Trang 17"],
        ["Hình 1.2", "Mô hình quản lý bộ nhớ CLR: Stack (Value Type) và Quản lý 3 thế hệ trên Heap (GC)", "Trang 18"],
        ["Hình 1.3", "So sánh chu trình yêu cầu giữa Kiến trúc Monolithic và Kiến trúc hướng dịch vụ RESTful API", "Trang 21"],
        ["Hình 1.4", "Cấu trúc 3 phần chuẩn của chuỗi JWT Bearer Token (Header.Payload.Signature)", "Trang 32"],
        ["Hình 1.5", "Sự cố cạn kiệt cổng kết nối (Socket Exhaustion) và Giải pháp static HttpClient", "Trang 35"],
        ["Hình 2.1", "Sơ đồ kiến trúc 3 lớp tổng thể: WinForms Client - ASP.NET Core API - SQL Server", "Trang 42"],
        ["Hình 2.2", "Sơ đồ luồng dữ liệu DFD Mức 0 (Context Diagram) hệ thống bán lẻ Ăn Vặt Store", "Trang 43"],
        ["Hình 2.3", "Sơ đồ luồng dữ liệu DFD Mức 1 phân rã chi tiết 4 phân hệ chức năng nghiệp vụ", "Trang 44"],
        ["Hình 2.4", "Sơ đồ thực thể liên kết (ERD) hoàn chỉnh gồm 6 bảng CSDL cốt lõi", "Trang 45"],
        ["Hình 3.1", "Ảnh chụp màn hình: Cây cấu trúc Solution MiniSupermarket.API trong Visual Studio", "Trang 54"],
        ["Hình 3.2", "Ảnh chụp màn hình: Giao diện tài liệu Swagger UI OpenAPI tổng hợp đầy đủ các Controller", "Trang 64"],
        ["Hình 3.3", "Ảnh chụp màn hình: Hộp thoại Authorize trên Swagger UI nhập Bearer JWT Token", "Trang 65"],
        ["Hình 4.1", "Sơ đồ kiến trúc giao diện Single-Form Shell Workspace (Sidebar, Header, Main Panel)", "Trang 68"],
        ["Hình 4.2", "Ảnh chụp màn hình: Giao diện Đăng nhập hệ thống (FormLogin.cs)", "Trang 70"],
        ["Hình 4.3", "Ảnh chụp màn hình: Giao diện Quầy Thu Ngân Bán Lẻ POS (FormPOS.cs) khi quét mã vạch", "Trang 71"],
        ["Hình 4.4", "Ảnh chụp màn hình: Giao diện Quản lý Sản phẩm (FormProductManagement.cs) phân trang LINQ", "Trang 72"],
        ["Hình 4.5", "Ảnh chụp màn hình: Giao diện Quản lý Danh mục Nhóm hàng (FormCategoryManagement.cs)", "Trang 73"],
        ["Hình 4.6", "Ảnh chụp màn hình: Giao diện Quản lý Khách hàng & Tích điểm thưởng (FormCustomerManagement.cs)", "Trang 74"],
        ["Hình 4.7", "Ảnh chụp màn hình: Giao diện Dashboard Báo cáo Doanh thu Thu ngân (FormQuickReport.cs)", "Trang 75"],
        ["Hình 5.1", "Ảnh chụp màn hình: Swagger UI kiểm thử API Auth Login trả về mã 200 OK kèm Bearer Token", "Trang 77"],
        ["Hình 5.2", "Ảnh chụp màn hình: Swagger UI kiểm thử chặn truy cập mã 401 Unauthorized khi không có Token", "Trang 78"],
        ["Hình 5.3", "Ảnh chụp màn hình: Swagger UI kiểm thử API Phân trang GET /api/products/paged với metadata", "Trang 79"],
        ["Hình 5.4", "Ảnh chụp màn hình: Kiểm thử Checkout thành công (COMMIT 200 OK) sinh hóa đơn mới", "Trang 80"],
        ["Hình 5.5", "Ảnh chụp màn hình: Kiểm thử Checkout mua vượt kho (ROLLBACK 400 BadRequest) an toàn", "Trang 81"],
        ["Hình 5.6", "Ảnh chụp màn hình: Đối soát dữ liệu 4 bảng trên SQL Server Management Studio (SSMS)", "Trang 82"],
        ["Hình 5.7", "Ảnh chụp màn hình: Chạy kiểm thử tự động 4 bài tập ADO.NET trên Console ThucHanhAdoNet", "Trang 83"]
    ]
    parts.append(make_table(fig_headers, fig_rows, [1600, 6560, 1200], header_bg="1B365D"))
    parts.append(page_break())
    
    # ==========================================
    # 9. DANH MỤC BẢNG BIỂU
    # ==========================================
    parts.append(heading1("DANH MỤC BẢNG BIỂU", page_break_before=False))
    
    tab_headers = ["Ký hiệu bảng", "Tên nội dung bảng biểu thống kê / Đặc tả kỹ thuật", "Vị trí trang"]
    tab_rows = [
        ["Bảng 1.1", "So sánh đặc tính kỹ thuật giữa Kiến trúc Monolithic và Kiến trúc hướng dịch vụ SOA", "Trang 21"],
        ["Bảng 1.2", "Danh mục các mã phản hồi HTTP Status Codes chuẩn và ý nghĩa trong Web API", "Trang 23"],
        ["Bảng 1.3", "So sánh phương pháp truy xuất dữ liệu ORM (EF Core) và ADO.NET thuần", "Trang 27"],
        ["Bảng 1.4", "So sánh cơ chế xác thực Session Stateful truyền thống và JSON Web Token (JWT) Stateless", "Trang 31"],
        ["Bảng 2.1", "Ma trận phân quyền hạn truy cập chức năng (RBAC) theo 3 vai trò người dùng", "Trang 39"],
        ["Bảng 2.2", "Bảng đặc tả cấu trúc dữ liệu thực thể Users (Tài khoản nhân sự)", "Trang 45"],
        ["Bảng 2.3", "Bảng đặc tả cấu trúc dữ liệu thực thể Categories (Nhóm hàng hóa)", "Trang 46"],
        ["Bảng 2.4", "Bảng đặc tả cấu trúc dữ liệu thực thể Products (Hàng hóa & Tồn kho)", "Trang 46"],
        ["Bảng 2.5", "Bảng đặc tả cấu trúc dữ liệu thực thể Customers (Khách hàng thân thiết)", "Trang 47"],
        ["Bảng 2.6", "Bảng đặc tả cấu trúc dữ liệu thực thể Orders (Hóa đơn bán hàng)", "Trang 47"],
        ["Bảng 2.7", "Bảng đặc tả cấu trúc dữ liệu thực thể OrderDetails (Chi tiết hóa đơn bán buôn/lẻ)", "Trang 48"],
        ["Bảng 2.8", "Bảng tổng hợp các ràng buộc toàn vẹn dữ liệu (PK, FK, Unique, Check, Default) trên CSDL", "Trang 48"],
        ["Bảng 2.9", "Bảng danh mục và đặc tả toàn bộ các RESTful API Endpoints trong hệ thống", "Trang 49 - 52"],
        ["Bảng 4.1", "Bảng tổng hợp đặc tả các API gọi từ WinForms Client kèm URL, Phương thức và JSON mẫu", "Trang 67"],
        ["Bảng 5.1", "Cấu hình phần cứng và phần mềm môi trường thử nghiệm hệ thống", "Trang 76"],
        ["Bảng 5.2", "Danh sách 15 tài khoản nhân sự mẫu nạp sẵn phân quyền kiểm thử", "Trang 76"],
        ["Bảng 5.3", "Danh sách 20 mặt hàng mẫu kiểm thử kho quầy đồ ăn vặt Ăn Vặt Store", "Trang 77"],
        ["Bảng 5.4", "Kết quả kiểm thử tính năng API và bảo vệ phân quyền trên Swagger UI", "Trang 78"],
        ["Bảng 5.5", "Kết quả kiểm thử giao dịch ACID: Kịch bản 1 (Commit) và Kịch bản 2 (Rollback)", "Trang 80"],
        ["Bảng 5.6", "Bảng đối soát dữ liệu tồn kho trước và sau Rollback trên CSDL SQL Server", "Trang 81"],
        ["Bảng 5.7", "Bảng đối soát Rubric các tiêu chí nghiệm thu hoàn thành đồ án môn học", "Trang 84"]
    ]
    parts.append(make_table(tab_headers, tab_rows, [1600, 6560, 1200], header_bg="0284C7"))
    parts.append(page_break())
    
    return "".join(parts)
