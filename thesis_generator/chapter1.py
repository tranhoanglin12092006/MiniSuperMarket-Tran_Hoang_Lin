# -*- coding: utf-8 -*-
from thesis_generator.builder import (p, heading1, heading2, heading3, make_table, 
                                      page_break, bullet, code_block, note_box)

def get_chapter1_xml():
    parts = []
    
    parts.append(heading1("CHƯƠNG 1: TỔNG QUAN ĐỀ TÀI VÀ CƠ SỞ LÝ THUYẾT NỀN TẢNG", page_break_before=True))
    
    # ----------------------------------------------------
    # 1.1. TỔNG QUAN ĐỀ TÀI NGHIÊN CỨU
    # ----------------------------------------------------
    parts.append(heading2("1.1. Tổng quan đề tài nghiên cứu"))
    
    parts.append(heading3("1.1.1. Bối cảnh chuyển đổi số trong quản lý bán lẻ và chuỗi cửa hàng tiện lợi / siêu thị mini"))
    parts.append(p("Trong kỷ nguyên công nghiệp 4.0 và chuyển đổi số quốc gia, ngành thương mại bán lẻ (Retail Industry) tại Việt Nam đang trải qua những bước chuyển mình mạnh mẽ. Mô hình tạp hóa truyền thống và quầy hàng tự phát đang dần được thay thế bởi các mô hình siêu thị mini (Mini-mart), cửa hàng tiện lợi (Convenience Store) và chuỗi cửa hàng chuyên doanh đồ ăn vặt, thực phẩm đóng gói. Đặc thù của mô hình bán lẻ hiện đại là danh mục mặt hàng vô cùng phong phú, số lượng giao dịch diễn ra liên tục với tần suất cao, vòng quay tồn kho nhanh và đòi hỏi độ chính xác tuyệt đối tại quầy thu ngân."))
    parts.append(p("Trước đây, việc quản lý tại các cửa hàng vừa và nhỏ chủ yếu dựa vào sổ sách ghi chép thủ công hoặc các bảng tính Excel rời rạc. Phương thức truyền thống này bộc lộ hàng loạt rủi ro nghiêm trọng:"))
    parts.append(bullet("Thất thoát hàng hóa và sai lệch tồn kho:", "Không thể kiểm soát chính xác lượng hàng tồn thực tế trên kệ so với số lượng xuất bán, dẫn đến tình trạng hết hàng đột ngột hoặc tồn đọng hàng quá hạn sử dụng."))
    parts.append(bullet("Ùn tắc tại quầy thanh toán (POS):", "Nhân viên thu ngân phải nhớ giá thủ công hoặc tìm kiếm bằng tay từng món hàng, kéo dài thời gian chờ đợi của khách hàng, dễ gây nhầm lẫn và thất thoát doanh thu."))
    parts.append(bullet("Gian lận và thiếu minh bạch ca trực:", "Khó phân định trách nhiệm doanh thu của từng thu ngân khi giao ca, thiếu công cụ kiểm soát dòng tiền và lịch sử giao dịch tức thời."))
    parts.append(bullet("Dữ liệu phân mảnh:", "Các máy tính thu ngân hoạt động độc lập, không đồng bộ dữ liệu tập trung, khiến người quản lý không thể nắm bắt báo cáo doanh thu theo thời gian thực (Real-time Analytics)."))
    parts.append(p("Chính vì vậy, việc ứng dụng công nghệ thông tin, xây dựng một phần mềm quản lý bán lẻ và quầy thu ngân POS chuyên nghiệp, vận hành trên mô hình Client-Server hiện đại, có khả năng quét mã vạch siêu tốc, quản lý kho tự động và bảo vệ giao dịch toàn vẹn là một yêu cầu cấp thiết mang tính sống còn đối với mọi doanh nghiệp bán lẻ."))
    
    parts.append(heading3("1.1.2. Lý do chọn đề tài và tính cấp thiết của việc xây dựng hệ thống quản lý bán lẻ"))
    parts.append(p("Xuất phát từ khảo sát thực tế tại mô hình cửa hàng đồ ăn vặt đóng gói và nước giải khát \"Ăn Vặt Store\" – một phân khúc bán lẻ đang phát triển bùng nổ phục vụ giới trẻ và sinh viên – nhu cầu về một hệ thống bán lẻ tinh gọn nhưng bảo mật, ổn định và tốc độ cao là vô cùng bức thiết. Cửa hàng cần xử lý hàng trăm đơn hàng mỗi ngày, các mặt hàng có giá trị nhỏ nhưng tần suất mua lớn (snack khoai tây, bánh que, kẹo dẻo, trà lon, nước ngọt)."))
    parts.append(p("Đề tài \"Xây dựng Giải pháp Quản lý Kho và Thanh toán Điện tử cho Cửa hàng Mini -- Cửa hàng Đồ ăn vặt Ăn Vặt Store\" được lựa chọn nhằm hiện thực hóa một giải pháp phần mềm toàn diện, giải quyết triệt để các bài toán vận hành:"))
    parts.append(bullet("Tối ưu hóa thời gian thanh toán quầy POS:", "Ứng dụng máy trạm Windows Forms Client kết nối trực tiếp với máy quét mã vạch USB (Barcode Scanner), tra cứu sản phẩm và hiển thị thông tin giá, khuyến mãi trong thời gian dưới 100 mili-giây."))
    parts.append(bullet("Bảo đảm toàn vẹn dữ liệu giao dịch chuẩn ACID:", "Áp dụng cơ chế Transaction ở tầng cơ sở dữ liệu để đảm bảo chuỗi 4 thao tác (Tạo hóa đơn -> Lưu chi tiết -> Trừ tồn kho -> Tích điểm) phải thành công đồng thời, loại bỏ hoàn toàn hiện tượng 'đơn hàng ma' hoặc hàng bị bán âm khi đã hết kho."))
    parts.append(bullet("Bảo mật và phân quyền vai trò (RBAC):", "Bảo vệ hệ thống bằng giao thức xác thực không trạng thái JWT (JSON Web Token), phân định quyền hạn minh bạch giữa Ban Giám đốc (Admin), Nhân viên Thu ngân (Cashier) và Thủ kho (Warehouse)."))
    parts.append(bullet("Báo cáo ca làm việc tự động:", "Tích hợp Stored Procedure trên Microsoft SQL Server để kết xuất thống kê doanh số từng thu ngân ngay khi hết ca, giúp đối soát dòng tiền minh bạch, chính xác."))
    
    parts.append(heading3("1.1.3. Mục tiêu nghiên cứu và chuẩn đầu ra của đồ án môn học"))
    parts.append(p("Mục tiêu tổng quát của đồ án môn học là giúp sinh viên củng cố, làm chủ và tích hợp toàn diện các khối kiến thức chuyên sâu trong chương trình đào tạo ngành Công nghệ Thông tin, đặc biệt là học phần Lập trình Ứng dụng C# .NET Core. Cụ thể, đề tài hướng tới các mục tiêu kỹ thuật rõ ràng:"))
    parts.append(bullet("Về mặt kiến trúc phần mềm:", "Hiện thực hóa chuẩn mực kiến trúc 3 lớp phân tán: Tầng hiển thị giao diện người dùng (Desktop WinForms Client), Tầng dịch vụ nghiệp vụ tập trung (ASP.NET Core Web API 8.0) và Tầng lưu trữ dữ liệu quan hệ (Microsoft SQL Server)."))
    parts.append(bullet("Về tầng dữ liệu ORM & ADO.NET:", "Kết hợp nhuần nhuyễn cả hai công nghệ truy xuất dữ liệu: Entity Framework Core 8 Code-First (quản lý quan hệ bảng, Migrations, Eager Loading, phân trang Server-side với LINQ) và ADO.NET thuần (SqlDataReader, SqlCommand, SqlParameter, SqlTransaction) cho các tác vụ đòi hỏi tốc độ cao và kiểm soát giao dịch chuẩn ACID."))
    parts.append(bullet("Về an toàn và bảo mật hệ thống:", "Triển khai cơ chế cấp phát, xác thực Bearer Token JWT và ủy quyền đa tầng dựa trên vai trò [Authorize(Roles = '...')]."))
    parts.append(bullet("Về chuẩn đầu ra của sinh viên:", "Sinh viên rèn luyện tác phong lập trình chuyên nghiệp, tổ chức mã nguồn chuẩn Clean Architecture, tuân thủ quy chuẩn quản lý phiên bản với Git (tối thiểu 5 mốc commit theo tiến độ thực hành), xây dựng tài liệu kỹ thuật README.md và thuyết minh đồ án chuẩn khoa học."))
    
    parts.append(heading3("1.1.4. Đối tượng và phạm vi nghiên cứu của đề tài"))
    parts.append(bullet("Đối tượng nghiên cứu:", "Quy trình nghiệp vụ bán hàng bán lẻ tại quầy (POS), quy trình nhập - xuất - kiểm kê hàng hóa tồn kho, quy trình chăm sóc và tích điểm thưởng cho khách hàng thành viên, kỹ thuật lập trình C# hiện đại, công nghệ ASP.NET Core Web API và cơ sở dữ liệu quan hệ SQL Server."))
    parts.append(bullet("Phạm vi nghiên cứu chức năng:", "Hệ thống tập trung giải quyết trọn vẹn 5 phân hệ cốt lõi: Phân hệ Xác thực & Phân quyền tài khoản; Phân hệ Quản lý Nhóm hàng & Sản phẩm; Phân hệ Quản lý Khách hàng thân thiết; Phân hệ Quầy Bán lẻ POS & Thanh toán giao dịch; Phân hệ Báo cáo Doanh thu Stored Procedure."))
    bullet("Phạm vi môi trường triển khai:", "Hệ thống hoạt động trên môi trường mạng cục bộ (LAN) hoặc Intranet doanh nghiệp, giao tiếp thông qua giao thức bảo mật HTTP/HTTPS và gói tin định dạng JSON.")
    
    # ----------------------------------------------------
    # 1.2. CƠ SỞ LÝ THUYẾT VỀ .NET CORE VÀ C#
    # ----------------------------------------------------
    parts.append(heading2("1.2. Cơ sở lý thuyết về nền tảng Microsoft .NET Core và ngôn ngữ C#"))
    
    parts.append(heading3("1.2.1. Quá trình tiến hóa từ .NET Framework sang Modern .NET (.NET Core / .NET 8)"))
    parts.append(p(".NET Framework truyền thống (phiên bản 1.0 đến 4.8) ra đời từ năm 2002, vốn được thiết kế gắn liền với hệ điều hành Microsoft Windows và máy chủ web IIS. Mặc dù rất thành công, .NET Framework bộc lộ hạn chế lớn là cấu trúc cồng kềnh, tiêu tốn tài nguyên và không thể chạy trên các nền tảng khác như Linux, macOS hoặc các môi trường đám mây (Cloud Native, Docker Containers)."))
    parts.append(p("Nhận thấy xu thế phát triển phần mềm hiện đại, Microsoft đã tái cấu trúc toàn diện và cho ra đời .NET Core vào năm 2016, và hiện nay được thống nhất dưới tên gọi Modern .NET (.NET 6, .NET 7 và mới nhất là .NET 8 LTS được áp dụng trong đồ án này). Những cải tiến mang tính bước ngoặt bao gồm:"))
    parts.append(bullet("Đa nền tảng thực sự (Cross-Platform):", "Cho phép lập trình viên phát triển và vận hành ứng dụng đồng nhất trên Windows, Linux và macOS."))
    parts.append(bullet("Hiệu năng vượt trội (High Performance):", "Được xếp hạng trong nhóm các Web Framework nhanh nhất thế giới theo chuẩn TechEmpower Benchmarks, nhờ tối ưu hóa bộ nhớ đệm, Span<T>, Memory<T> và thu gọn nhân runtime."))
    parts.append(bullet("Tích hợp sẵn Dependency Injection (DI):", "Cơ chế quản lý vòng đời đối tượng được nhúng sâu vào nhân lõi của hệ thống, giúp mã nguồn tách bạch, dễ mở rộng và dễ kiểm thử đơn vị (Unit Testing)."))
    parts.append(bullet("Triển khai độc lập (Self-Contained Deployment):", "Ứng dụng có thể đóng gói kèm toàn bộ runtime, giúp triển khai lên máy chủ khách hàng mà không cần cài đặt trước .NET SDK."))
    
    parts.append(heading3("1.2.2. Cơ chế thực thi mã nguồn: Mã trung gian (CIL), Trình biên dịch JIT và Bộ máy thực thi CLR"))
    parts.append(p("Không giống như các ngôn ngữ biên dịch trực tiếp sang mã máy như C/C++ hay các ngôn ngữ thông dịch từng dòng như Python, C# là ngôn ngữ được quản lý (Managed Code), trải qua quy trình biên dịch hai giai đoạn:"))
    parts.append(p("1. Giai đoạn biên dịch trước (Build Time): Trình biên dịch C# (Roslyn Compiler) phân tích cú pháp mã nguồn C# (.cs) và chuyển đổi thành ngôn ngữ mã trung gian chung CIL (Common Intermediate Language, hay MSIL). Mã CIL hoàn toàn độc lập với kiến trúc phần cứng CPU."))
    parts.append(p("2. Giai đoạn thực thi (Run Time): Khi chương trình được kích hoạt, Bộ máy thực thi ngôn ngữ chung CLR (Common Language Runtime) sẽ nạp tệp thực thi. Tại đây, Trình biên dịch tức thời JIT (Just-In-Time Compiler) sẽ đọc từng khối lệnh CIL khi cần thiết và biên dịch chúng sang tập lệnh máy nhị phân bản địa (Native Machine Code) tương ứng với CPU hiện tại (x86, x64, hoặc ARM64)."))
    parts.append(note_box("Mô hình thực thi mã nguồn C# trong .NET 8", 
        "Mã nguồn C# (.cs) ➔ Roslyn Compiler ➔ Mã trung gian CIL (.dll / .exe) ➔ CLR Nạp mã ➔ JIT Compiler (RyuJIT) ➔ Mã máy nhị phân CPU (Native Machine Code)"))
    
    parts.append(heading3("1.2.3. Cơ chế quản lý bộ nhớ tự động: Bộ nhớ Stack, Heap và Trình thu gom rác (Garbage Collector)"))
    parts.append(p("Trong .NET Core, bộ nhớ của ứng dụng được chia thành hai phân vùng chính: Stack (Ngăn xếp) và Managed Heap (Đống quản lý):"))
    parts.append(bullet("Bộ nhớ Stack:", "Lưu trữ các biến kiểu giá trị (Value Types: int, double, bool, struct) và con trỏ địa chỉ tham chiếu. Stack hoạt động theo nguyên tắc LIFO (Last-In-First-Out), việc cấp phát và giải phóng diễn ra tức thì khi khối lệnh (scope) kết thúc, tốc độ truy cập cực kỳ nhanh."))
    parts.append(bullet("Bộ nhớ Managed Heap:", "Lưu trữ nội dung dữ liệu thực tế của các kiểu tham chiếu (Reference Types: class, string, array, đối tượng Entity). Việc cấp phát trên Heap đòi hỏi tìm kiếm khoảng trống bộ nhớ phù hợp."))
    parts.append(p("Trình thu gom rác tự động GC (Garbage Collector) là thành phần then chốt của CLR, giúp loại bỏ nguy cơ rò rỉ bộ nhớ (Memory Leak) mà lập trình viên C++ thường gặp phải. GC quản lý bộ nhớ Heap theo mô hình 3 thế hệ (Generations):"))
    parts.append(bullet("Generation 0 (Gen 0):", "Chứa các đối tượng mới được khởi tạo và có tuổi thọ ngắn (ví dụ: các biến tạm thời trong hàm, đối tượng DTO trong một request API). Chu kỳ dọn dẹp Gen 0 diễn ra rất nhanh và thường xuyên."))
    parts.append(bullet("Generation 1 (Gen 1):", "Đóng vai trò vùng đệm giữa các đối tượng ngắn hạn và dài hạn. Nếu một đối tượng sống sót qua lần thu gom của Gen 0, nó sẽ được nâng cấp lên Gen 1."))
    parts.append(bullet("Generation 2 (Gen 2):", "Chứa các đối tượng có vòng đời dài hạn (ví dụ: DbContext dạng Scoped/Singleton, đối tượng HttpClient static, bộ đệm cache toàn hệ thống). Chu kỳ thu gom Gen 2 (Full GC) tiêu tốn nhiều tài nguyên hơn."))
    parts.append(bullet("Large Object Heap (LOH):", "Dành riêng cho các đối tượng có kích thước lớn hơn 85.000 bytes (ví dụ: mảng byte ảnh, chuỗi dữ liệu lớn). LOH được thu gom cùng Gen 2."))
    
    parts.append(heading3("1.2.4. Các cú pháp hiện đại trong C#: Auto-properties, Generics, Nullable types và Lập trình bất đồng bộ (async/await)"))
    parts.append(p("Dự án áp dụng triệt để các tính năng ngôn ngữ hiện đại trong C# 12 / .NET 8:"))
    parts.append(bullet("Generics (Kiểu dữ liệu chung):", "Cho phép định nghĩa các lớp và hàm tái sử dụng cao mà vẫn giữ an toàn kiểu (Type Safety). Dự án đã xây dựng lớp bao bọc kết quả phân trang dùng chung: PagedResult<T>."))
    parts.append(bullet("Nullable Reference Types (string?):", "Ngăn chặn triệt để lỗi 'chết người' NullReferenceException ngay từ lúc viết mã bằng cách cảnh báo rõ ràng trường nào có thể mang giá trị null."))
    parts.append(bullet("Lập trình bất đồng bộ (Asynchronous Programming với async/await):", "Đây là kỹ thuật cốt lõi giúp ứng dụng Web API và Desktop WinForms vận hành mượt mà, không bị treo giao diện (UI Freezing) khi thực hiện các tác vụ nặng về I/O mạng hoặc truy vấn CSDL:"))
    parts.append(code_block('''// Minh họa hàm bất đồng bộ truy vấn dữ liệu không chặn luồng giao diện chính (UI Thread)
public async Task<List<Product>> GetAllProductsAsync()
{
    // Luồng giao diện được giải phóng để tiếp nhận thao tác người dùng
    using (var context = new SupermarketDbContext())
    {
        return await context.Products
            .AsNoTracking()
            .ToListAsync(); // Tác vụ đọc I/O diễn ra bất đồng bộ ngầm
    }
}'''))
    parts.append(p("Khi gặp từ khóa await, luồng hiện tại được giải phóng trở lại ThreadPool để phục vụ các yêu cầu khác. Khi thao tác I/O ở CSDL hoàn tất, hệ thống tự động nối lại việc thực thi hàm bằng một luồng sẵn có, giúp hệ thống phục vụ được hàng ngàn kết nối đồng thời với lượng tài nguyên CPU và RAM tối thiểu."))
    
    # ----------------------------------------------------
    # 1.3. KIẾN TRÚC SOA VÀ RESTFUL WEB API
    # ----------------------------------------------------
    parts.append(heading2("1.3. Lý thuyết về Kiến trúc hướng dịch vụ (SOA) và chuẩn RESTful Web API"))
    
    parts.append(heading3("1.3.1. So sánh kiến trúc nguyên khối (Monolithic) và Kiến trúc hướng dịch vụ (Service-Oriented Architecture - SOA)"))
    parts.append(p("Kiến trúc phần mềm đóng vai trò quyết định đến khả năng bảo trì, mở rộng và độ ổn định lâu dài của hệ thống. Trong lịch sử phát triển ứng dụng quản lý bán lẻ, hai mô hình kiến trúc phổ biến nhất là Monolithic và SOA:"))
    
    soa_headers = ["Tiêu chí so sánh", "Kiến trúc Nguyên khối (Monolithic)", "Kiến trúc Hướng dịch vụ (SOA / REST API)"]
    soa_rows = [
        ["Cấu trúc ứng dụng", "Giao diện WinForms kết nối trực tiếp với CSDL SQL Server trong cùng 1 dự án.", "Tách biệt hoàn toàn Client (WinForms) và Backend (ASP.NET Core Web API)."],
        ["Độ kết dính (Coupling)", "Rất chặt chẽ (Tight Coupling). Thay đổi logic CSDL đòi hỏi cài lại toàn bộ máy trạm.", "Lỏng lẻo (Loose Coupling). Backend và Frontend chỉ giao tiếp qua giao ước JSON."],
        ["Khả năng đa nền tảng", "Chỉ chạy được trên Windows Desktop có cài đặt Driver CSDL.", "Dễ dàng mở rộng thêm ứng dụng Web React/Vue hoặc Mobile App iOS/Android."],
        ["Bảo mật chuỗi kết nối", "Nguy hiểm: Chuỗi kết nối và mật khẩu CSDL nằm trực tiếp trên máy trạm của thu ngân.", "Tuyệt đối an toàn: Client chỉ có JWT Token; chuỗi kết nối nằm an toàn tại Server."],
        ["Khả năng mở rộng (Scale)", "Khó mở rộng ngang (Horizontal Scaling), tải nặng trực tiếp lên SQL Server.", "Dễ dàng triển khai nhiều máy chủ API phía sau bộ cân bằng tải (Load Balancer)."]
    ]
    parts.append(make_table(soa_headers, soa_rows, [2200, 3580, 3580], header_bg="1B365D"))
    parts.append(p("Đồ án đã lựa chọn mô hình kiến trúc hướng dịch vụ SOA kết hợp RESTful Web API làm xương sống, khắc phục hoàn toàn các nhược điểm của kiến trúc Monolithic truyền thống."))
    
    parts.append(heading3("1.3.2. Nguyên lý thiết kế RESTful: Định danh tài nguyên (URI), quy chuẩn danh từ số nhiều và tính phi trạng thái (Stateless)"))
    parts.append(p("REST (Representational State Transfer) là phong cách kiến trúc phần mềm do Roy Fielding đề xuất trong luận án tiến sĩ năm 2000. Để một Web API được công nhận đạt chuẩn RESTful, hệ thống phải tuân thủ nghiêm ngặt các nguyên tắc:"))
    parts.append(bullet("Định danh tài nguyên bằng URI:", "Mọi đối tượng dữ liệu trong hệ thống (như hàng hóa, đơn hàng, khách hàng) được coi là một 'Tài nguyên' (Resource) và được xác định bằng một định danh duy nhất (URI - Uniform Resource Identifier)."))
    parts.append(bullet("Quy chuẩn sử dụng Danh từ số nhiều (Plural Nouns):", "Đường dẫn tuyệt đối không chứa động từ chỉ hành động (như /getProducts hay /deleteProduct). Thay vào đó, đường dẫn luôn là danh từ số nhiều: /api/products, /api/categories, /api/customers."))
    parts.append(bullet("Tính phi trạng thái (Statelessness):", "Server không lưu giữ bất kỳ ngữ cảnh phiên làm việc nào của Client giữa các request. Mỗi yêu cầu từ máy trạm gửi lên phải chứa đầy đủ mọi thông tin cần thiết để Server xử lý (bao gồm định danh xác thực Bearer Token)."))
    
    parts.append(heading3("1.3.3. Giao thức truyền tải HTTP: Phương thức (GET, POST, PUT, DELETE) và Quy chuẩn mã phản hồi (HTTP Status Codes)"))
    parts.append(p("Hành động thực thi trên tài nguyên được quy định chuẩn hóa thông qua 4 phương thức HTTP Methods chính:"))
    parts.append(bullet("GET:", "Truy xuất danh sách hoặc thông tin chi tiết một tài nguyên (An toàn - Safe và Có tính lũy biến - Idempotent, không làm thay đổi trạng thái CSDL)."))
    parts.append(bullet("POST:", "Tạo mới một tài nguyên trong hệ thống (Không có tính lũy biến)."))
    parts.append(bullet("PUT:", "Cập nhật hoặc thay thế toàn bộ thông tin của một tài nguyên hiện hữu."))
    parts.append(bullet("DELETE:", "Xóa bỏ vĩnh viễn hoặc vô hiệu hóa một tài nguyên khỏi hệ thống."))
    
    parts.append(p("Máy chủ Web API phản hồi kết quả về Client thông qua các mã trạng thái chuẩn hóa (HTTP Status Codes):"))
    http_headers = ["Mã trạng thái", "Tên chuẩn tiếng Anh", "Ý nghĩa và Ngữ cảnh ứng dụng trong đồ án Ăn Vặt Store"]
    http_rows = [
        ["200 OK", "Success", "Yêu cầu thành công, trả về dữ liệu danh sách sản phẩm hoặc chi tiết hóa đơn."],
        ["201 Created", "Resource Created", "Thêm mới thành công nhóm hàng hoặc hóa đơn bán lẻ mới vào CSDL."],
        ["400 Bad Request", "Client Data Error", "Dữ liệu gửi lên không hợp lệ (ví dụ: mã vạch bị rỗng, mua quá tồn kho)."],
        ["401 Unauthorized", "Authentication Required", "Client chưa gửi JWT Token hoặc Token đã hết hạn, yêu cầu đăng nhập lại."],
        ["403 Forbidden", "Access Denied", "Đã xác thực danh tính nhưng không đủ quyền hạn vai trò (ví dụ: Thu ngân cố xóa sản phẩm)."],
        ["404 Not Found", "Resource Not Found", "Không tìm thấy mã vạch sản phẩm hoặc mã đơn hàng yêu cầu trong CSDL."],
        ["500 Internal Error", "Server Exception", "Lỗi ngoại lệ phát sinh không mong muốn ở tầng máy chủ (được bọc try-catch)."]
    ]
    parts.append(make_table(http_headers, http_rows, [1800, 2560, 5000], header_bg="0284C7"))
    
    parts.append(heading3("1.3.4. Định dạng trao đổi dữ liệu JSON: Kỹ thuật tuần tự hóa (Serialization) và giải tuần tự hóa (Deserialization)"))
    parts.append(p("JSON (JavaScript Object Notation) là định dạng trao đổi dữ liệu văn bản thuần túy, có cấu trúc gọn nhẹ và tương thích 100% với hầu hết mọi ngôn ngữ lập trình hiện đại. Trong dự án .NET 8, thư viện System.Text.Json được cấu hình mặc định:"))
    parts.append(bullet("Serialization (Tuần tự hóa):", "Chuyển đổi đối tượng C# (Model / DTO) thành chuỗi văn bản JSON để truyền qua mạng Internet về cho ứng dụng WinForms."))
    parts.append(bullet("Deserialization (Giải tuần tự hóa):", "Tiếp nhận chuỗi văn bản JSON gửi từ WinForms Client qua gói tin HTTP POST/PUT và phân tích ngược thành các đối tượng đối tượng C# để xử lý nghiệp vụ."))
    
    parts.append(heading3("1.3.5. Kiến trúc xử lý yêu cầu trong ASP.NET Core: Bộ chứa phụ thuộc (DI Container) và Chuỗi xử lý trung gian (Middleware Pipeline)"))
    parts.append(p("ASP.NET Core vận hành dựa trên hai khái niệm kiến trúc mang tính trụ cột:"))
    parts.append(bullet("Dependency Injection Container (IoC Container):", "Tự động quản lý vòng đời và tiêm các phụ thuộc (Dependencies) vào Controller thông qua 3 chế độ vòng đời:"))
    parts.append(p("  + Transient (AddTransient): Tạo thể hiện mới mỗi lần được yêu cầu (thích hợp cho các dịch vụ nhẹ, không lưu trạng thái).\n  + Scoped (AddScoped): Tạo một thể hiện duy nhất cho mỗi vòng đời HTTP Request (chuẩn mặc định cho Entity Framework DbContext).\n  + Singleton (AddSingleton): Tạo một thể hiện duy nhất và dùng chung cho toàn bộ thời gian sống của ứng dụng (thích hợp cho bộ nhớ đệm Cache, đối tượng cấu hình)."))
    parts.append(bullet("Middleware Pipeline (Chuỗi xử lý trung gian):", "Tập hợp các module phần mềm được sắp xếp theo trình tự trong hàm Main của Program.cs để xử lý yêu cầu HTTP Request đi vào và phản hồi HTTP Response đi ra. Thứ tự kích hoạt Middleware đóng vai trò sống còn đối với an ninh hệ thống:"))
    parts.append(code_block('''app.UseRouting();          // 1. Phân tích định tuyến Endpoint
app.UseCors("AllowAll");    // 2. Kiểm soát chia sẻ tài nguyên nguồn gốc chéo
app.UseAuthentication();    // 3. Giải mã và kiểm tra tính hợp lệ của JWT Token (Ai?)
app.UseAuthorization();     // 4. Kiểm tra quyền hạn vai trò RBAC (Được làm gì?)
app.MapControllers();       // 5. Điều hướng vào Action cụ thể trong Controller'''))
    
    # ----------------------------------------------------
    # 1.4. CƠ SỞ CƠ SỞ DỮ LIỆU VÀ TẦNG TRUY XUẤT
    # ----------------------------------------------------
    parts.append(heading2("1.4. Cơ sở lý thuyết về Cơ sở dữ liệu và Tầng truy xuất dữ liệu"))
    
    parts.append(heading3("1.4.1. Hệ quản trị cơ sở dữ liệu quan hệ (RDBMS) và chuẩn hóa dữ liệu 3NF trên Microsoft SQL Server"))
    parts.append(p("Microsoft SQL Server là hệ quản trị cơ sở dữ liệu quan hệ (RDBMS) cấp doanh nghiệp hàng đầu, hỗ trợ ngôn ngữ truy vấn T-SQL (Transact-SQL) mạnh mẽ, khả năng xử lý đồng thời cực cao và tính an toàn bảo mật nghiêm ngặt. Để loại bỏ hiện tượng dư thừa dữ liệu (Data Redundancy) và các dị thường khi Thêm/Sửa/Xóa (Anomalies), lược đồ cơ sở dữ liệu MiniSupermarketDb được thiết kế tuân thủ nghiêm ngặt 3 dạng chuẩn hóa dữ liệu:"))
    parts.append(bullet("Dạng chuẩn 1 (1NF - First Normal Form):", "Tất cả các thuộc tính trong bảng đều là giá trị nguyên tử (Atomic Values), không chứa danh sách lặp hoặc thuộc tính đa trị."))
    parts.append(bullet("Dạng chuẩn 2 (2NF - Second Normal Form):", "Đạt chuẩn 1NF và mọi thuộc tính không khóa đều phụ thuộc hàm toàn phần vào toàn bộ khóa chính (loại bỏ phụ thuộc một phần khi dùng khóa chính phức hợp)."))
    parts.append(bullet("Dạng chuẩn 3 (3NF - Third Normal Form):", "Đạt chuẩn 2NF và không tồn tại phụ thuộc hàm bắc cầu (Transitive Dependency) giữa các thuộc tính không khóa. Ví dụ: Bảng Orders chỉ lưu CustomerId, các thông tin Họ tên, SĐT khách hàng được tách riêng sang bảng Customers."))
    
    parts.append(heading3("1.4.2. Khái niệm Object-Relational Mapping (ORM) và cơ chế vận hành của Entity Framework Core"))
    parts.append(p("Object-Relational Mapping (ORM) là kỹ thuật lập trình cho phép ánh xạ giữa hệ thống các đối tượng hướng đối tượng (OOP) trong mã nguồn C# và các bảng dữ liệu trong CSDL quan hệ. Entity Framework Core (EF Core 8) là bộ ORM chính thống của Microsoft, đóng vai trò cầu nối trung gian, tự động chuyển đổi các thao tác thêm sửa xóa đối tượng C# thành các câu lệnh SQL tương ứng."))
    
    parts.append(heading3("1.4.3. Phương pháp tiếp cận Code-First, DbContext và Quản lý tiến hóa lược đồ qua EF Core Migrations"))
    parts.append(p("Dự án áp dụng phương pháp tiếp cận Code-First hiện đại: Lập trình viên định nghĩa cấu trúc dữ liệu bằng các lớp C# thông thường (POCO Classes), sau đó sử dụng công cụ EF Core Migrations để tự động phát sinh và cập nhật cấu trúc bảng xuống SQL Server:"))
    parts.append(bullet("SupermarketDbContext:", "Lớp ngữ cảnh quản lý phiên làm việc với CSDL, khai báo các tập hợp DbSet<Product>, DbSet<Category>, DbSet<Customer>... và cấu hình mối quan hệ qua Fluent API."))
    parts.append(bullet("Migrations:", "Ghi nhận lịch sử thay đổi của cấu trúc CSDL theo từng mốc phát triển. Cho phép đồng bộ cấu trúc database trên mọi máy tính phát triển thông qua các câu lệnh dotnet ef migrations add và dotnet ef database update."))
    
    parts.append(heading3("1.4.4. Ngôn ngữ truy vấn tích hợp LINQ (Language Integrated Query) và cơ chế Deferred Execution"))
    parts.append(p("LINQ cho phép viết các câu lệnh truy vấn dữ liệu trực tiếp trong C# với cú pháp ngắn gọn, kiểm tra lỗi kiểu dữ liệu ngay khi biên dịch (Compile-time Type Checking). Đặc biệt, LINQ to Entities hoạt động theo cơ chế Thực thi trì hoãn (Deferred Execution): Truy vấn chỉ thực sự được biên dịch sang câu lệnh SQL và gửi xuống máy chủ cơ sở dữ liệu khi kết quả được duyệt qua các hàm như .ToListAsync(), .FirstOrDefaultAsync(), hoặc vòng lặp foreach."))
    
    parts.append(heading3("1.4.5. Công nghệ ADO.NET thuần: Kiến trúc hướng kết nối/ngắt kết nối, Stored Procedure và Tiêu chuẩn giao dịch ACID (SqlTransaction)"))
    parts.append(p("Mặc dù ORM như EF Core rất tiện lợi cho các thao tác CRUD danh mục, nhưng đối với các thao tác đòi hỏi hiệu năng cực hạn (quét mã vạch <100ms) hoặc các giao dịch tài chính phức tạp đụng chạm đồng thời 4 bảng, ADO.NET thuần túy (Microsoft.Data.SqlClient) là giải pháp không thể thay thế:"))
    
    ado_headers = ["Đặc tính kỹ thuật", "Entity Framework Core 8 (ORM)", "ADO.NET Thuần túy (Data Client)"]
    ado_rows = [
        ["Cơ chế hoạt động", "Mô hình trừu tượng cấp cao, quản lý đối tượng qua Change Tracker.", "Truy xuất trực tiếp tầng mạng TDS (Tabular Data Stream) của SQL Server."],
        ["Tốc độ thực thi", "Nhanh, nhưng tốn chi phí ánh xạ đối tượng và theo dõi trạng thái.", "Cực nhanh, chiếm ít tài nguyên CPU và RAM nhất."],
        ["Mô hình dữ liệu", "Hướng đối tượng hoàn toàn (Domain Models & Navigation Properties).", "Hỗ trợ 2 chế độ: Connected (SqlDataReader) và Disconnected (DataTable)."],
        ["Kiểm soát giao dịch", "SaveChanges() tự động mở transaction ngầm.", "SqlTransaction bọc thủ công rõ ràng theo chuẩn ACID từng dòng lệnh."],
        ["Ngữ cảnh áp dụng", "Quản lý danh mục hàng hóa, phân trang sản phẩm, CRUD khách hàng.", "Tra cứu Barcode siêu tốc POS, Báo cáo Stored Procedure, Checkout trừ kho."]
    ]
    parts.append(make_table(ado_headers, ado_rows, [2000, 3680, 3680], header_bg="1B365D"))
    
    parts.append(p("Tiêu chuẩn ACID trong giao dịch POS Checkout:", bold=True, size=26, color="1B365D"))
    parts.append(bullet("Atomicity (Tính nguyên tử):", "Toàn bộ chuỗi 4 thao tác (Tạo đơn -> Thêm chi tiết -> Trừ tồn kho -> Tích điểm) được coi là một đơn vị công việc duy nhất. Hoặc là tất cả cùng thành công (Commit), hoặc là không có thao tác nào được lưu lại (Rollback)."))
    parts.append(bullet("Consistency (Tính nhất quán):", "Dữ liệu chuyển từ trạng thái hợp lệ này sang trạng thái hợp lệ khác. Tồn kho không bao giờ bị âm, điểm thưởng luôn tăng đúng tỷ lệ quy định."))
    parts.append(bullet("Isolation (Tính cô lập):", "Các giao dịch thanh toán diễn ra đồng thời ở nhiều quầy thu ngân không được can thiệp lẫn nhau. Mức độ cô lập Read Committed đảm bảo không đọc dữ liệu rác (Dirty Read)."))
    parts.append(bullet("Durability (Tính bền vững):", "Một khi giao dịch đã Commit thành công, dữ liệu được ghi bền vững vào tệp nhật ký giao dịch (.ldf) và tệp dữ liệu (.mdf) của SQL Server, không bị mất ngay cả khi mất điện đột ngột."))
    
    # ----------------------------------------------------
    # 1.5. BẢO MẬT VÀ XÁC THỰC JWT
    # ----------------------------------------------------
    parts.append(heading2("1.5. Lý thuyết về Cơ chế Bảo mật và Xác thực không trạng thái (JWT)"))
    
    parts.append(heading3("1.5.1. So sánh cơ chế xác thực dựa trên Session truyền thống và Xác thực không trạng thái (Stateless Authentication)"))
    jwt_headers = ["Đặc tính", "Xác thực Session Stateful (Truyền thống)", "Xác thực JWT Bearer Stateless (Hiện đại)"]
    jwt_rows = [
        ["Lưu trữ trạng thái", "Lưu trữ phiên đăng nhập trên bộ nhớ RAM của Server (Session State).", "Server hoàn toàn không lưu trạng thái; Token do Client tự lưu giữ."],
        ["Khả năng mở rộng", "Rất kém khi hệ thống mở rộng nhiều cụm máy chủ (cần Sticky Session).", "Tuyệt vời: Mọi máy chủ API độc lập đều có thể xác thực Token bằng khóa bí mật."],
        ["Giao tiếp đa nền tảng", "Gắn liền với cơ chế Cookie của trình duyệt Web, khó dùng cho WinForms/Mobile.", "Hoạt động hoàn hảo trên mọi nền tảng thông qua HTTP Header: Authorization."],
        ["Tài nguyên máy chủ", "Chiếm dụng bộ nhớ RAM tăng dần theo số lượng người dùng đồng thời.", "Không chiếm dụng RAM của máy chủ, giảm tải tối đa cho hệ thống."]
    ]
    parts.append(make_table(jwt_headers, jwt_rows, [2200, 3580, 3580], header_bg="0284C7"))
    
    parts.append(heading3("1.5.2. Cấu trúc chuẩn của chuỗi JSON Web Token: Header, Payload (Claims), và Signature"))
    parts.append(p("Chuỗi JSON Web Token là một chuỗi văn bản mã hóa Base64Url gồm 3 phần tách biệt bởi dấu chấm (.): Header.Payload.Signature:"))
    parts.append(bullet("Header (Tiêu đề):", "Chứa kiểu token (typ: 'JWT') và thuật toán ký mã hóa được áp dụng (alg: 'HS256')."))
    parts.append(bullet("Payload (Phần thân chứa các Claims):", "Chứa các thông tin định danh và quyền hạn của người dùng được đóng gói thành các cặp Claim (ví dụ: ClaimTypes.NameIdentifier = '1', ClaimTypes.Name = 'admin01', ClaimTypes.Role = 'ADMIN', exp: thời gian hết hạn)."))
    parts.append(bullet("Signature (Chữ ký số bảo mật):", "Được tạo ra bằng cách lấy chuỗi (Base64(Header) + '.' + Base64(Payload)) kết hợp với một Khóa bí mật (Secret Key) tại máy chủ, sau đó băm qua thuật toán HMAC-SHA256. Chữ ký này đảm bảo không một ai có thể sửa đổi nội dung Payload mà không bị Server phát hiện."))
    
    parts.append(heading3("1.5.3. Thuật toán ký mã hóa đối xứng (HMAC SHA-256) và Quy trình ủy quyền truy cập theo vai trò (Role-Based Access Control - RBAC)"))
    parts.append(p("Hệ thống áp dụng mô hình phân quyền dựa trên vai trò RBAC (Role-Based Access Control). Khi một yêu cầu gửi tới Web API kèm Bearer Token trong Header, Middleware UseAuthentication sẽ giải mã chữ ký bằng SymmetricSecurityKey. Nếu chữ ký hợp lệ và Token chưa hết hạn, đối tượng ClaimsPrincipal được nạp vào HttpContext.User. Middleware UseAuthorization tiếp theo sẽ đối soát thuộc tính [Authorize(Roles = 'ADMIN,CASHIER')] để quyết định cho phép thực thi hoặc từ chối bằng mã lỗi HTTP 403 Forbidden."))
    
    # ----------------------------------------------------
    # 1.6. KIẾN TRÚC DESKTOP WINFORMS CLIENT
    # ----------------------------------------------------
    parts.append(heading2("1.6. Kiến trúc Desktop Client trên nền tảng Windows Forms"))
    
    parts.append(heading3("1.6.1. Nguyên lý giao tiếp giữa ứng dụng máy trạm và Backend API thông qua lớp HttpClient"))
    parts.append(p("Ứng dụng máy trạm Windows Forms sử dụng thư viện System.Net.Http và gói mở rộng System.Net.Http.Json để gửi các yêu cầu bất đồng bộ (GetFromJsonAsync, PostAsJsonAsync, PutAsJsonAsync, DeleteAsync) lên Web API. Toàn bộ các tiến trình mạng đều chạy trên luồng ngầm (Background Worker Thread), sau đó tự động đồng bộ kết quả về luồng giao diện chính (UI Thread) để nạp vào DataGridView hoặc ComboBox mà không gây hiện tượng giật, lag hay treo chuột của nhân viên bán hàng."))
    
    parts.append(heading3("1.6.2. Kỹ thuật quản trị tài nguyên mạng: Khắc phục sự cố cạn kiệt cổng kết nối (Socket Exhaustion)"))
    parts.append(p("Một sai lầm kinh điển mà nhiều lập trình viên C# mắc phải là bọc HttpClient trong khối using mỗi khi gọi API:"))
    parts.append(code_block('''// SAI LẦM: Gây ra sự cố cạn kiệt cổng mạng (Socket Exhaustion)!
using (var client = new HttpClient())
{
    var result = await client.GetAsync("https://api.example.com/products");
}'''))
    parts.append(p("Khi khối using kết thúc, phương thức Dispose() được gọi nhưng socket mạng bên dưới hệ điều hành không đóng lại ngay lập tức mà rơi vào trạng thái TIME_WAIT (kéo dài tới 240 giây theo cấu hình TCP mặc định của Windows). Khi nhân viên thu ngân quét mã vạch liên tục hàng trăm lần, toàn bộ các cổng mạng TCP (khoảng 65.535 cổng) sẽ bị cạn kiệt, dẫn đến lỗi mạng System.Net.Sockets.SocketException: No connection could be made."))
    parts.append(note_box("Giải pháp thiết kế Singleton HttpClient", 
        "Dự án đã giải quyết triệt để sự cố trên bằng cách khởi tạo duy nhất một thể hiện static readonly HttpClient trong lớp ApiClientService (nằm trong SessionManager.cs). Thể hiện này được tái sử dụng xuyên suốt toàn bộ vòng đời ứng dụng WinForms, tự động pooling các socket kết nối, mang lại hiệu năng cao nhất."))
    
    parts.append(heading3("1.6.3. Kiến trúc giao diện bàn làm việc đơn (Single-Form Shell Workspace) và cơ chế nhúng Form động"))
    parts.append(p("Để mang lại trải nghiệm chuyên nghiệp tương tự các phần mềm ERP và POS hàng đầu, đồ án không mở các cửa sổ Form con phân mảnh, chồng chéo lên nhau (MDI hay Form.Show() truyền thống). Thay vào đó, hệ thống áp dụng kiến trúc Single-Form Shell Workspace với FormMainShell đóng vai trò khung vỏ:"))
    parts.append(bullet("Thanh điều hướng bên trái (Sidebar Navigation):", "Chứa logo Ăn Vặt Store, thông tin người dùng đăng nhập và danh mục các nút bấm chức năng (Bán hàng POS, Quản lý Sản phẩm, Danh mục, Khách hàng, Báo cáo Doanh thu)."))
    parts.append(bullet("Thanh tiêu đề trên cùng (Top Header):", "Hiển thị tiêu đề màn hình đang làm việc, ngày giờ hệ thống và nút Đăng xuất an toàn."))
    bullet("Vùng làm việc trung tâm (Main Workspace Panel):", "Một Panel duy nhất có Dock = Fill. Khi người dùng nhấp chọn menu, Form con tương ứng được nạp động vào Panel này thông qua kỹ thuật nhúng form:")
    parts.append(code_block('''// Kỹ thuật nhúng Form con động vào Panel trung tâm của WinForms Shell
private void OpenChildForm(Form childForm)
{
    if (_activeForm != null)
    {
        _activeForm.Close(); // Đóng form trước đó
    }
    _activeForm = childForm;
    childForm.TopLevel = false;             // Bỏ tính chất cửa sổ độc lập cấp cao
    childForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền cửa sổ
    childForm.Dock = DockStyle.Fill;        // Giãn kín Panel trung tâm
    panelWorkspace.Controls.Add(childForm); // Nạp Form vào Panel
    panelWorkspace.Tag = childForm;
    childForm.BringToFront();
    childForm.Show();                       // Hiển thị mượt mà
}'''))
    
    return "".join(parts)
