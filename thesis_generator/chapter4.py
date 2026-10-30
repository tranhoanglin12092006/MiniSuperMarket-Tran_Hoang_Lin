# -*- coding: utf-8 -*-
from thesis_generator.builder import (p, heading1, heading2, heading3, make_table, 
                                      page_break, bullet, code_block, note_box, screenshot_placeholder)

def get_chapter4_xml():
    parts = []
    
    parts.append(heading1("CHƯƠNG 4: TRIỂN KHAI PHẦN FRONTEND CLIENT (WINDOWS FORMS POS APP)", page_break_before=True))
    
    # ----------------------------------------------------
    # PHẦN ĐẶC BIỆT: GIẢI THÍCH DỄ HIỂU 3 ĐIỂM CỐT LÕI
    # ----------------------------------------------------
    parts.append(heading2("★ GIẢI THÍCH DỄ HIỂU 3 ĐIỂM CỐT LÕI CỦA HỆ THỐNG POS"))
    parts.append(p("Để bất kỳ ai, từ người quản lý đến lập trình viên mới, đều có thể nắm bắt bản chất vận hành của hệ thống một cách trực quan, dưới đây là lời giải thích dễ hiểu nhất về 3 trụ cột kỹ thuật cốt lõi:"))
    
    parts.append(bullet("1. Cơ chế Đăng nhập JWT (Chiếc 'Thẻ thông hành điện tử' bảo mật):", 
        "Hãy tưởng tượng khi nhân viên đến làm việc, họ đưa tài khoản và mật khẩu cho bảo vệ (API Server). Sau khi kiểm tra đúng, bảo vệ không giữ nhân viên lại mà trao cho họ một chiếc 'Thẻ thông hành điện tử' (chuỗi JWT Token) có đóng dấu mộc đỏ chống làm giả (chữ ký số HMAC SHA-256). Trên thẻ ghi rõ: 'Người này là Nguyễn Văn A, chức vụ: Thu ngân, có hiệu lực trong 7 ngày'. Ứng dụng WinForms cất chiếc thẻ này vào SessionManager. Kể từ đó, mỗi khi nhân viên muốn quét mã vạch hay thanh toán tiền, WinForms chỉ cần giơ chiếc thẻ này ra (đính kèm vào Header Authorization: Bearer). Máy chủ chỉ cần nhìn con dấu mộc trên thẻ là lập tức cho phép thao tác mà không cần phải truy vấn lại mật khẩu trong CSDL mỗi giây, giúp hệ thống chạy cực nhanh và bảo mật tuyệt đối."))
    
    parts.append(bullet("2. Cơ chế Trừ kho bằng Transaction (Chiếc 'Hộp bảo hiểm' toàn vẹn dữ liệu):", 
        "Một quy trình thanh toán tại quầy gồm 4 bước liên hoàn: (1) Tạo hóa đơn -> (2) Ghi chi tiết các món -> (3) Trừ số lượng tồn kho trên kệ -> (4) Cộng điểm thưởng cho khách. Nếu không có Transaction, điều gì xảy ra nếu sau khi in hóa đơn xong, hệ thống phát hiện món đồ đó đã bị khách khác mua hết sạch ở quầy bên cạnh? Kết quả là kho bị âm, tiền bị lệch và sinh ra 'đơn hàng rác'. Với SqlTransaction, 4 bước trên được đặt chung vào một chiếc 'Hộp bảo hiểm'. Hệ thống chỉ chốt giao dịch vĩnh viễn (Commit) khi cả 4 bước đều hoàn hảo 100%. Nếu có bất kỳ sự cố nào xảy ra (ví dụ: thiếu hàng, rớt mạng), hệ thống lập tức 'hoàn tác' (Rollback) – trả mọi thứ về trạng thái ban đầu như chưa từng xảy ra, bảo vệ CSDL luôn trong sạch."))
    
    parts.append(bullet("3. Cơ chế Entity Framework Core (Người 'Thông dịch viên' siêu tốc):", 
        "Thay vì lập trình viên phải tự viết hàng trăm câu lệnh SQL thủ công dễ nhầm lẫn, EF Core đóng vai trò như một người thông dịch viên cao cấp. Lập trình viên chỉ cần làm việc với các đối tượng C# quen thuộc (như Product, Category). Đặc biệt, khi cần hiển thị danh sách hàng hóa lên lưới, EF Core sử dụng thuật toán phân trang LINQ (.Skip() và .Take()): Nếu bảng có 10.000 mặt hàng, EF Core chỉ thông dịch và kéo đúng 5 mặt hàng của trang hiện tại về máy trạm, kèm theo tên nhóm hàng nhờ kỹ thuật Eager Loading (.Include()), giúp màn hình WinForms mở lên tức thì, hoàn toàn không bị đơ giật hay tràn bộ nhớ RAM."))
    
    parts.append(p("", space_after=140))
    
    # ----------------------------------------------------
    # BẢNG TỔNG HỢP TOÀN BỘ CÁC API
    # ----------------------------------------------------
    parts.append(heading2("★ BẢNG TỔNG HỢP DANH MỤC CÁC RESTFUL API GIAO TIẾP VỚI CLIENT"))
    parts.append(p("Dưới đây là bảng tổng hợp toàn bộ các Endpoint API mà ứng dụng WinForms Client gọi để tương tác với Backend Server:"))
    
    api_headers = ["Phương thức", "Đường dẫn Endpoint (URL)", "Quyền hạn (RBAC)", "Chức năng nghiệp vụ & Cấu trúc JSON mẫu"]
    api_rows = [
        ["POST", "/api/auth/login", "Public", "Đăng nhập hệ thống\nRequest: {\"username\":\"admin01\",\"password\":\"123456\"}\nResponse: {\"token\":\"eyJ...\",\"role\":\"ADMIN\"}"],
        ["GET", "/api/products/paged", "Tất cả", "Lấy sản phẩm phân trang LINQ\nParams: ?keyword=Coca&categoryId=2&pageNumber=1&pageSize=5\nResponse: {\"currentPage\":1,\"totalItems\":15,\"items\":[...]}"],
        ["GET", "/api/ado-products/barcode/{barcode}", "Tất cả", "Tra cứu mã vạch siêu tốc bằng ADO.NET SqlDataReader (<100ms)\nResponse: {\"productId\":1,\"barcode\":\"893456789001\",\"price\":12500}"],
        ["POST", "/api/products", "ADMIN, WAREHOUSE", "Thêm mặt hàng mới vào kho\nRequest: {\"barcode\":\"893...\",\"productName\":\"Snack...\",\"price\":15000,\"stockQuantity\":100,\"categoryId\":1}"],
        ["PUT", "/api/products/{id}", "ADMIN, WAREHOUSE", "Cập nhật giá và số lượng tồn kho theo ProductId\nRequest: {\"productId\":1,\"productName\":\"...\",\"price\":13000,\"stockQuantity\":200}"],
        ["DELETE", "/api/products/{id}", "ADMIN", "Xóa mặt hàng khỏi danh mục hệ thống theo ID"],
        ["GET", "/api/categories", "Tất cả", "Lấy toàn bộ danh mục nhóm hàng nạp ComboBox lọc"],
        ["POST", "/api/categories", "ADMIN", "Thêm nhóm hàng mới\nRequest: {\"categoryName\":\"Đồ khô\",\"description\":\"Snack gói\"}"],
        ["POST", "/api/checkout", "ADMIN, CASHIER", "Thanh toán giao dịch POS bọc kín SqlTransaction ACID\nRequest: {\"cashierUsername\":\"cashier01\",\"customerId\":1,\"items\":[{\"productId\":1,\"quantity\":2,\"unitPrice\":12500}]}"],
        ["DELETE", "/api/checkout/cancel/{orderId}", "ADMIN", "Hủy đơn hàng, hoàn trả tồn kho sản phẩm và trừ lại điểm thưởng"],
        ["GET", "/api/reports/revenue-by-cashier", "ADMIN, CASHIER", "Gọi Stored Procedure sp_GetRevenueByCashier lấy báo cáo doanh thu ca làm việc của từng nhân viên thu ngân"],
        ["GET", "/api/reports/top-selling-products", "ADMIN", "Gọi Stored Procedure sp_GetTop5SellingProducts lấy top 5 mặt hàng bán chạy nhất"]
    ]
    parts.append(make_table(api_headers, api_rows, [1400, 2760, 1800, 3400], header_bg="1B365D"))
    parts.append(p("Bảng 4.1: Bảng tổng hợp chi tiết các API giao tiếp giữa WinForms và Web API", bold=True, italic=True, size=24, color="334155", align="center", space_after=180))
    
    # ----------------------------------------------------
    # 4.1. KIẾN TRÚC TỔNG THỂ & GIAO TIẾP MẠNG WINFORMS
    # ----------------------------------------------------
    parts.append(heading2("4.1. Kiến trúc tổng thể và giao tiếp dịch vụ phía WinForms Client"))
    
    parts.append(heading3("4.1.1. Cấu trúc Solution dự án MiniSupermarket.WinForms"))
    parts.append(p("Ứng dụng máy trạm MiniSupermarket.WinForms được xây dựng trên nền tảng .NET 8.0 Windows Forms hiện đại, hỗ trợ hiển thị sắc nét trên các màn hình độ phân giải cao (High DPI Per-Monitor V2):"))
    parts.append(bullet("FormMainShell.cs:", "Khung giao diện bàn làm việc trung tâm áp dụng mô hình Single-Form Shell."))
    parts.append(bullet("FormPOS.cs:", "Giao diện quầy thu ngân bán lẻ, tối ưu hóa cho súng quét Barcode USB và phím tắt."))
    parts.append(bullet("FormProductManagement.cs:", "Giao diện quản lý hàng hóa: hiển thị DataGridView, ComboBox lọc danh mục và cụm nút điều hướng phân trang (Next/Prev)."))
    parts.append(bullet("FormCategoryManagement.cs, FormCustomerManagement.cs, FormUserManagement.cs:", "Các phân hệ quản lý danh mục, khách hàng và tài khoản."))
    parts.append(bullet("FormQuickReport.cs:", "Báo cáo doanh thu ca trực và xuất bảng dữ liệu sang tệp Excel."))
    parts.append(bullet("SessionManager.cs:", "Quản lý phiên đăng nhập và dịch vụ ApiClientService."))
    
    parts.append(heading3("4.1.2. Xây dựng lớp dịch vụ mạng tập trung ApiClientService.cs quản lý phiên bản static readonly HttpClient"))
    parts.append(p("Để ngăn chặn triệt để thảm họa cạn kiệt cổng kết nối (Socket Exhaustion) như đã phân tích ở Chương 1, toàn bộ các cuộc gọi API từ WinForms đều được định tuyến qua duy nhất một thể hiện HttpClient dùng chung:"))
    parts.append(code_block('''public static class ApiClientService
{
    private static readonly HttpClientHandler _handler;
    public static readonly HttpClient Client;

    static ApiClientService()
    {
        // Cấu hình bỏ qua lỗi kiểm tra chứng chỉ SSL tự ký trên môi trường phát triển localhost
        _handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        };

        // Khởi tạo duy nhất 1 thể hiện HttpClient xuyên suốt vòng đời ứng dụng
        Client = new HttpClient(_handler)
        {
            BaseAddress = new Uri("https://localhost:7167/"), // Hoặc http://localhost:5150/
            Timeout = TimeSpan.FromSeconds(30)
        };
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    // Tự động đính kèm Token xác thực Bearer vào Header của mọi request gửi đi
    public static void AttachToken(string token)
    {
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public static void ClearToken()
    {
        Client.DefaultRequestHeaders.Authorization = null;
    }
}'''))
    
    parts.append(heading3("4.1.3. Cơ chế tự động đính kèm Bearer Token vào Header trong các yêu cầu bất đồng bộ qua System.Net.Http.Json"))
    parts.append(p("Khi phương thức ApiClientService.AttachToken(token) được gọi ngay sau khi đăng nhập thành công, thuộc tính DefaultRequestHeaders.Authorization của HttpClient sẽ tự động dán chuỗi Bearer Token vào mọi gói tin HTTP GET, POST, PUT, DELETE tiếp theo. Nhờ đó, lập trình viên tại các Form con không cần phải đính kèm token thủ công trong từng dòng mã, giảm thiểu sai sót và đảm bảo an toàn tuyệt đối."))
    
    parts.append(heading3("4.1.4. Lớp tĩnh SessionManager.cs: Quản lý phiên làm việc, lưu trữ định danh tài khoản và vai trò người dùng"))
    parts.append(p("Lớp SessionManager đóng vai trò là kho lưu trữ trạng thái người dùng (In-Memory User Context) trên bộ nhớ RAM của máy trạm:"))
    parts.append(code_block('''public static class SessionManager
{
    public static string Token { get; set; } = string.Empty;
    public static string Username { get; set; } = string.Empty;
    public static string FullName { get; set; } = string.Empty;
    public static string Role { get; set; } = string.Empty; // ADMIN, CASHIER, WAREHOUSE
    public static bool IsLoggedIn => !string.IsNullOrEmpty(Token);

    public static void Login(string token, string username, string fullName, string role)
    {
        Token = token;
        Username = username;
        FullName = fullName;
        Role = role;
        ApiClientService.AttachToken(token); // Tự động gắn token vào HttpClient
    }

    public static void Logout()
    {
        Token = string.Empty;
        Username = string.Empty;
        FullName = string.Empty;
        Role = string.Empty;
        ApiClientService.ClearToken();
    }
}'''))
    
    # ----------------------------------------------------
    # 4.2. HIỆN THỰC SINGLE-FORM SHELL WORKSPACE
    # ----------------------------------------------------
    parts.append(heading2("4.2. Hiện thực kiến trúc bàn làm việc Shell Workspace (Single-Form Shell)"))
    
    parts.append(heading3("4.2.1. Phân chia bố cục phân vùng giao diện: Thanh điều hướng bên trái (Sidebar), Thanh tiêu đề (Top Header) và Vùng hiển thị (Main Workspace)"))
    parts.append(p("Giao diện FormMainShell được thiết kế hiện đại theo phong cách phẳng (Flat Modern UI), chia thành 3 phân vùng độc lập:"))
    parts.append(bullet("Panel Sidebar bên trái (Độ rộng cố định 240px, màu nền xanh Navy đậm #1E293B):", "Chứa logo Ăn Vặt Store, avatar nhân viên, tên người đăng nhập và các nút điều hướng chuyển đổi chức năng."))
    parts.append(bullet("Panel Header trên cùng (Chiều cao 60px, màu trắng trang nhã #FFFFFF):", "Hiển thị tiêu đề module chức năng đang mở, ngày giờ ca trực và nút Đăng xuất."))
    parts.append(bullet("Panel Main Workspace trung tâm (Dock = Fill, màu xám nhạt #F8FAFC):", "Khoảng không gian chính để nhúng và hiển thị nội dung các Form nghiệp vụ."))
    
    parts.append(heading3("4.2.2. Kỹ thuật nhúng Form con động (TopLevel = false, Dock = Fill) vào Panel trung tâm, ngăn chặn việc mở cửa sổ độc lập phân mảnh"))
    parts.append(p("Kỹ thuật nhúng Form động giúp toàn bộ ứng dụng vận hành trong một cửa sổ duy nhất, mượt mà và không bị chớp giật màn hình:"))
    parts.append(code_block('''private Form? _activeForm = null;

public void OpenChildForm(Form childForm)
{
    // Đóng và giải phóng Form đang mở trước đó
    if (_activeForm != null)
    {
        _activeForm.Close();
        _activeForm.Dispose();
    }

    _activeForm = childForm;
    childForm.TopLevel = false;                         // Bỏ thuộc tính cửa sổ cấp cao
    childForm.FormBorderStyle = FormBorderStyle.None;  // Xóa bỏ thanh tiêu đề và nút thu nhỏ/đóng
    childForm.Dock = DockStyle.Fill;                    // Giãn nở phủ kín Panel trung tâm
    panelWorkspace.Controls.Add(childForm);
    panelWorkspace.Tag = childForm;
    childForm.BringToFront();
    childForm.Show();                                   // Hiển thị Form con mượt mà
}'''))
    
    parts.append(heading3("4.2.3. Cơ chế điều khiển phân quyền giao diện: Tự động ẩn/hiện nút chức năng Sidebar theo quyền hạn đăng nhập thực tế (RBAC)"))
    parts.append(p("Ngay khi FormMainShell được kích hoạt, phương thức ApplyRolePermissions() sẽ đọc thông tin vai trò từ SessionManager.Role để điều khiển thuộc tính Visible của các nút trên Sidebar:"))
    parts.append(code_block('''private void ApplyRolePermissions()
{
    lblCurrentUserName.Text = SessionManager.FullName;
    lblCurrentUserRole.Text = $"Vai trò: {SessionManager.Role}";

    // Phân quyền theo vai trò thực tế
    if (SessionManager.Role == "CASHIER")
    {
        // Thu ngân: Chỉ thấy màn hình Quầy POS Bán lẻ và Báo cáo ca trực
        btnNavPOS.Visible = true;
        btnNavReports.Visible = true;
        btnNavProducts.Visible = false;
        btnNavCategories.Visible = false;
        btnNavUsers.Visible = false;
    }
    else if (SessionManager.Role == "WAREHOUSE")
    {
        // Thủ kho: Chỉ thấy Quản lý Sản phẩm, Tồn kho và Nhóm hàng
        btnNavPOS.Visible = false;
        btnNavProducts.Visible = true;
        btnNavCategories.Visible = true;
        btnNavReports.Visible = false;
        btnNavUsers.Visible = false;
    }
    else // ADMIN
    {
        // Quản trị viên: Toàn quyền truy cập mọi tính năng
        btnNavPOS.Visible = true;
        btnNavProducts.Visible = true;
        btnNavCategories.Visible = true;
        btnNavCustomers.Visible = true;
        btnNavReports.Visible = true;
        btnNavUsers.Visible = true;
    }
}'''))
    
    # ----------------------------------------------------
    # 4.3. XÂY DỰNG CÁC PHÂN HỆ MÀN HÌNH DESKTOP
    # ----------------------------------------------------
    parts.append(heading2("4.3. Xây dựng các phân hệ màn hình nghiệp vụ Desktop"))
    
    parts.append(heading3("4.3.1. Màn hình Xác thực đăng nhập (FormLogin.cs): Giao tiếp API xác thực, giải mã phản hồi và nạp phiên làm việc"))
    parts.append(p("FormLogin được thiết kế nhỏ gọn, hiện đại với hiệu ứng đổ bóng. Khi người dùng nhập thông tin và bấm Đăng nhập (hoặc Enter):"))
    parts.append(screenshot_placeholder("4.2", "Giao diện Form Đăng nhập hệ thống (FormLogin.cs) kết nối API xác thực",
                                       "Dán ảnh chụp màn hình Form đăng nhập với 2 ô Username, Password và nút Đăng nhập."))
    
    parts.append(heading3("4.3.2. Màn hình Quầy Bán lẻ POS (FormPOS.cs): Bắt sự kiện quét mã Barcode, quản lý bảng giỏ hàng, tự động tính tổng tiền, tính tiền thừa và kích hoạt Checkout qua API"))
    parts.append(p("FormPOS là linh hồn của hệ thống quầy thu ngân. Toàn bộ thao tác có thể thực hiện 100% bằng bàn phím và súng quét mã vạch:"))
    parts.append(bullet("Sự kiện txtBarcode_KeyDown:", "Bắt phím Keys.Enter khi súng quét bắn xong mã vạch, tự động gọi API ADO.NET /api/ado-products/barcode/{code} siêu tốc và cộng sản phẩm vào DataGridView giỏ hàng."))
    parts.append(bullet("Phím F2 (Tìm khách hàng):", "Nhập SĐT khách hàng để hiển thị điểm tích lũy thành viên."))
    parts.append(bullet("Phím F9 (Thanh toán):", "Tự động kiểm tra số tiền khách đưa, tính tiền thừa và kích hoạt gọi API /api/checkout bọc Transaction."))
    parts.append(screenshot_placeholder("4.3", "Giao diện Quầy Thu Ngân Bán Lẻ POS (FormPOS.cs) hiển thị giỏ hàng, tổng tiền và tính tiền thừa",
                                       "Dán ảnh chụp màn hình FormPOS khi quét nhiều sản phẩm đồ ăn vặt vào giỏ hàng."))
    
    parts.append(heading3("4.3.3. Màn hình Quản lý Sản phẩm & Tồn kho (FormProductManagement.cs): Nạp danh mục ComboBox, hiển thị lưới dữ liệu DataGridView và cụm nút điều hướng phân trang (Next/Prev)"))
    parts.append(p("Màn hình FormProductManagement tích hợp bộ công cụ phân trang LINQ hoàn chỉnh:"))
    parts.append(bullet("ComboBox lọc nhóm hàng (cboFilterCategory):", "Cho phép lọc nhanh sản phẩm theo nhóm."))
    parts.append(bullet("Thanh tìm kiếm (txtSearch):", "Tìm kiếm tức thời theo Tên mặt hàng hoặc Mã vạch."))
    parts.append(bullet("Cụm nút điều hướng phân trang:", "btnPrev (<< Trang trước), lblPaging ('Trang 1 / 3 (Tổng: 15 SP)'), btnNext (Trang sau >>). Tự động vô hiệu hóa nút Prev khi ở Trang 1 và nút Next khi ở trang cuối."))
    parts.append(screenshot_placeholder("4.4", "Giao diện Quản lý Sản phẩm (FormProductManagement.cs) tích hợp phân trang LINQ và tìm kiếm",
                                       "Dán ảnh chụp màn hình lưới sản phẩm hiển thị đúng 5 sản phẩm trang 1 kèm thanh phân trang bên dưới."))
    
    parts.append(heading3("4.3.4. Màn hình Quản lý Danh mục Nhóm hàng (FormCategoryManagement.cs): Thao tác Thêm, Sửa, Xóa và Tìm kiếm trực tiếp"))
    parts.append(p("Cho phép Quản trị viên phân loại các mặt hàng đồ ăn vặt vào các nhóm phù hợp, hỗ trợ tìm kiếm và cập nhật tức thời."))
    parts.append(screenshot_placeholder("4.5", "Giao diện Quản lý Danh mục Nhóm hàng (FormCategoryManagement.cs)",
                                       "Dán ảnh chụp màn hình Form quản lý nhóm hàng."))
    
    parts.append(heading3("4.3.5. Màn hình Dashboard Báo cáo Doanh thu (FormReports.cs): Trực quan hóa số liệu ca trực bằng bảng biểu và điều khiển biểu đồ đồ họa"))
    parts.append(p("FormQuickReport gọi Stored Procedure sp_GetRevenueByCashier để hiển thị bảng tổng kết doanh số của từng thu ngân trong ngày, đồng thời hỗ trợ xuất dữ liệu ra file Excel (.xlsx) thông qua thư viện ExcelExportHelper."))
    parts.append(screenshot_placeholder("4.7", "Giao diện Báo cáo Doanh thu Ca trực (FormQuickReport.cs) hiển thị số liệu doanh số từng thu ngân",
                                       "Dán ảnh chụp màn hình bảng báo cáo doanh số thu ngân."))
    
    # ----------------------------------------------------
    # 4.4. XỬ LÝ NGOẠI LỆ & TRẢI NGHIỆM NGƯỜI DÙNG
    # ----------------------------------------------------
    parts.append(heading2("4.4. Xử lý ngoại lệ và nâng cao trải nghiệm người dùng trên Desktop Client"))
    
    parts.append(heading3("4.4.1. Bọc kín các tiến trình mạng bằng cấu trúc xử lý lỗi ngoại lệ (try ... catch), chống treo hoặc sập ứng dụng"))
    parts.append(p("Mọi cuộc gọi API trên ứng dụng WinForms đều được bảo vệ trong khối try ... catch (HttpRequestException / Exception). Khi xảy ra sự cố đứt cáp mạng hoặc máy chủ Web API chưa được bật, ứng dụng hiển thị thông báo lỗi nhẹ nhàng thay vì bị sập ứng dụng (Crash / Unhandled Exception) đột ngột."))
    
    parts.append(heading3("4.4.2. Xử lý thông báo phản hồi thân thiện: Phân biệt các trạng thái lỗi mạng, hết hạn phiên làm việc (401) hoặc từ chối truy cập (403)"))
    parts.append(p("Khi nhận được mã phản hồi HTTP từ Web API, WinForms Client phân loại và thông báo chi tiết cho người dùng:"))
    parts.append(bullet("Mã 401 Unauthorized:", "Hiển thị thông báo: 'Phiên làm việc đã hết hạn. Vui lòng đăng nhập lại!' và tự động điều hướng về màn hình FormLogin."))
    parts.append(bullet("Mã 403 Forbidden:", "Hiển thị thông báo cảnh báo: 'Bạn không có quyền thực hiện chức năng này! Vui lòng liên hệ Quản trị viên (Admin).'"))
    parts.append(bullet("Mã 400 Bad Request:", "Trích xuất chuỗi errorDetail từ gói tin JSON để thông báo đúng lý do (ví dụ: 'Sản phẩm Bánh Danisa chỉ còn 40 cái trong kho, không đủ bán 999 cái!')."))
    
    return "".join(parts)
