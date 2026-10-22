# -*- coding: utf-8 -*-
import zipfile
import os
import html

def escape_xml(text):
    return html.escape(text).replace("\n", "&#10;")

def p(text="", bold=False, italic=False, size=24, color="000000", align="left", space_before=0, space_after=120, line_spacing=240, bg=None, code_font=False):
    align_xml = f'<w:jc w:val="{align}"/>' if align != "left" else ""
    shd_xml = f'<w:shd w:val="clear" w:color="auto" w:fill="{bg}"/>' if bg else ""
    rfont = '<w:rFonts w:ascii="Consolas" w:hAnsi="Consolas"/>' if code_font else '<w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>'
    b_xml = '<w:b/>' if bold else ''
    i_xml = '<w:i/>' if italic else ''
    
    # Handle newlines
    lines = text.split("\n")
    runs_xml = ""
    for idx, l in enumerate(lines):
        if idx > 0:
            runs_xml += '<w:r><w:br/></w:r>'
        escaped = html.escape(l)
        runs_xml += f'''<w:r>
            <w:rPr>
                {rfont}
                {b_xml}
                {i_xml}
                <w:sz w:val="{size}"/>
                <w:color w:val="{color}"/>
            </w:rPr>
            <w:t xml:space="preserve">{escaped}</w:t>
        </w:r>'''
        
    return f'''<w:p>
        <w:pPr>
            {align_xml}
            <w:spacing w:before="{space_before}" w:after="{space_after}" w:line="{line_spacing}" w:lineRule="auto"/>
            {shd_xml}
        </w:pPr>
        {runs_xml}
    </w:p>'''

def heading(text, level=1):
    if level == 1:
        return p(text, bold=True, size=32, color="1B365D", space_before=280, space_after=140)
    elif level == 2:
        return p(text, bold=True, size=26, color="0284C7", space_before=200, space_after=100)
    else:
        return p(text, bold=True, size=23, color="334155", space_before=140, space_after=60)

def code_block(code_text):
    return p(code_text, code_font=True, size=19, color="0F172A", bg="F1F5F9", space_before=80, space_after=160, line_spacing=220)

def bullet(bold_prefix, text):
    escaped_bold = html.escape(bold_prefix)
    escaped_text = html.escape(text)
    return f'''<w:p>
        <w:pPr>
            <w:pStyle w:val="ListParagraph"/>
            <w:spacing w:before="40" w:after="80"/>
            <w:ind w:left="360"/>
        </w:pPr>
        <w:r>
            <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:b/>
                <w:sz w:val="22"/>
                <w:color w:val="1E293B"/>
            </w:rPr>
            <w:t xml:space="preserve">• {escaped_bold} </w:t>
        </w:r>
        <w:r>
            <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:sz w:val="22"/>
                <w:color w:val="334155"/>
            </w:rPr>
            <w:t xml:space="preserve">{escaped_text}</w:t>
        </w:r>
    </w:p>'''

def make_table(headers, rows, col_widths, header_bg="1B365D"):
    grid_xml = "".join([f'<w:gridCol w:w="{w}"/>' for w in col_widths])
    
    header_tr = '<w:tr><w:trPr><w:tblHeader/></w:trPr>'
    for idx, h in enumerate(headers):
        w = col_widths[idx]
        header_tr += f'''<w:tc>
            <w:tcPr>
                <w:tcW w:w="{w}" w:type="dxa"/>
                <w:shd w:val="clear" w:color="auto" w:fill="{header_bg}"/>
                <w:tcMar>
                    <w:top w:w="120" w:type="dxa"/>
                    <w:bottom w:w="120" w:type="dxa"/>
                    <w:left w:w="140" w:type="dxa"/>
                    <w:right w:w="140" w:type="dxa"/>
                </w:tcMar>
            </w:tcPr>
            {p(h, bold=True, size=20, color="FFFFFF", space_before=40, space_after=40)}
        </w:tc>'''
    header_tr += '</w:tr>'
    
    rows_tr = ""
    for r_idx, r in enumerate(rows):
        bg = "F8FAFC" if r_idx % 2 == 1 else "FFFFFF"
        rows_tr += '<w:tr>'
        for c_idx, cell in enumerate(r):
            w = col_widths[c_idx]
            color = "16A34A" if "[x] Đạt" in cell or "Thành công" in cell else "1E293B"
            bold = ("[x]" in cell or c_idx == 0)
            rows_tr += f'''<w:tc>
                <w:tcPr>
                    <w:tcW w:w="{w}" w:type="dxa"/>
                    <w:shd w:val="clear" w:color="auto" w:fill="{bg}"/>
                    <w:tcMar>
                        <w:top w:w="100" w:type="dxa"/>
                        <w:bottom w:w="100" w:type="dxa"/>
                        <w:left w:w="140" w:type="dxa"/>
                        <w:right w:w="140" w:type="dxa"/>
                    </w:tcMar>
                </w:tcPr>
                {p(cell, bold=bold, size=19, color=color, space_before=40, space_after=40)}
            </w:tc>'''
        rows_tr += '</w:tr>'
        
    return f'''<w:tbl>
        <w:tblPr>
            <w:tblW w:w="0" w:type="auto"/>
            <w:tblBorders>
                <w:top w:val="single" w:sz="6" w:space="0" w:color="CBD5E1"/>
                <w:bottom w:val="single" w:sz="6" w:space="0" w:color="CBD5E1"/>
                <w:insideH w:val="single" w:sz="4" w:space="0" w:color="E2E8F0"/>
                <w:insideV w:val="single" w:sz="4" w:space="0" w:color="E2E8F0"/>
            </w:tblBorders>
        </w:tblPr>
        <w:tblGrid>{grid_xml}</w:tblGrid>
        {header_tr}
        {rows_tr}
    </w:tbl>'''

def build_docx(filename):
    body_parts = []
    
    # 1. TIÊU ĐỀ BÌA
    body_parts.append(p("HỆ THỐNG QUẢN LÝ BÁN LẺ & QUẦY THU NGÂN MINISUPERMARKET POS", bold=True, size=24, color="0284C7", align="center", space_after=80))
    body_parts.append(p("HƯỚNG DẪN KHỞI CHẠY VÀ QUY TRÌNH KIỂM THỬ TOÀN DIỆN", bold=True, size=40, color="1B365D", align="center", space_after=120))
    body_parts.append(p("BUỔI 5: ADO.NET NÂNG CAO, STORED PROCEDURE & GIAO DỊCH POS CHECKOUT", bold=True, italic=True, size=24, color="475569", align="center", space_after=240))
    
    # Bảng thông tin sinh viên
    info_headers = ["Thông tin", "Chi tiết"]
    info_rows = [
        ["Họ và tên sinh viên:", "Trần Hoàng Lin"],
        ["Mã số sinh viên (MSSV):", "2124110134"],
        ["Cấu trúc Solution:", "Gồm 3 project: MiniSupermarket.API, MiniSupermarket.WinForms, ThucHanhAdoNet"],
        ["Công nghệ áp dụng:", "ADO.NET thuần (Microsoft.Data.SqlClient), Stored Procedure, SqlTransaction (ACID)"]
    ]
    body_parts.append(make_table(info_headers, info_rows, [2800, 6200], header_bg="0284C7"))
    body_parts.append(p("", space_after=200))
    
    # 2. PHẦN 1: TỔNG QUAN
    body_parts.append(heading("1. TỔNG QUAN KIẾN TRÚC & CÁC THÀNH PHẦN BUỔI 5", 1))
    body_parts.append(p("Hệ thống MiniSupermarket trong Buổi 5 được trang bị toàn diện các kỹ thuật dữ liệu tầng thấp với ADO.NET thuần túy nhằm tối ưu hóa hiệu năng quầy POS (phản hồi <100ms) và bảo vệ giao dịch thanh toán đa bảng theo tiêu chuẩn ACID:"))
    body_parts.append(bullet("5 Đối tượng cốt lõi:", "SqlConnection (quản lý kết nối vật lý), SqlCommand (đóng gói lệnh), SqlParameter (chống SQL Injection), SqlDataReader (luồng đọc siêu tốc Forward-Only), DataTable & SqlDataAdapter (mô hình Disconnected Cache trên RAM)."))
    body_parts.append(bullet("Mô hình Connected vs Disconnected:", "Connected (SqlDataReader) đòi hỏi mở kết nối liên tục, chiếm ít RAM, tối ưu cho quét mã vạch POS; Disconnected (DataTable) tự động đóng kết nối ngay sau khi Fill, lưu trữ bảng đệm trên RAM."))
    body_parts.append(bullet("Stored Procedure (Thủ tục lưu trữ):", "Biên dịch sẵn trên SQL Server giúp giảm tải băng thông mạng, tối ưu kế hoạch thực thi (Execution Plan) và bảo mật dữ liệu doanh thu."))
    body_parts.append(bullet("Chuẩn ACID & SqlTransaction:", "Đảm bảo tính nguyên tử (Atomicity), nhất quán (Consistency), cô lập (Isolation), và bền vững (Durability) cho chuỗi 4 thao tác thanh toán: Tạo hóa đơn -> Lưu chi tiết -> Trừ kho -> Tích điểm thưởng."))
    
    # 3. PHẦN 2: CHUẨN BỊ MÔI TRƯỜNG & CSDL
    body_parts.append(heading("2. CHUẨN BỊ MÔI TRƯỜNG & CƠ SỞ DỮ LIỆU", 1))
    body_parts.append(heading("2.1. Cấu hình Cơ sở dữ liệu SQL Server (MiniSupermarketDb)", 2))
    body_parts.append(p("Cơ sở dữ liệu được thiết kế hoàn chỉnh trong tệp Buoi5_Setup_MiniSupermarketDb.sql, bao gồm 6 bảng quan hệ, nạp sẵn 20 sản phẩm mẫu và 15 hóa đơn mẫu khớp chính xác theo giáo trình."))
    body_parts.append(p("Cách 1: Khởi tạo tự động bằng dòng lệnh sqlcmd (Khuyên dùng):", bold=True))
    body_parts.append(code_block("cd D:\\MiniSuperMarket-Tran_Hoang_Lin\nsqlcmd -S localhost -E -i \"Buoi5_Setup_MiniSupermarketDb.sql\""))
    body_parts.append(p("Cách 2: Thực thi trong SQL Server Management Studio (SSMS):", bold=True))
    body_parts.append(p("1. Đăng nhập SSMS (Server: localhost hoặc .\\SQLEXPRESS, chế độ Windows Authentication).\n2. Mở file Buoi5_Setup_MiniSupermarketDb.sql và bấm Execute (F5).\n3. Kiểm tra thông báo: Database MiniSupermarketDb và 3 Stored Procedure đã được biên dịch thành công."))
    
    body_parts.append(heading("2.2. Cấu hình chuỗi kết nối trong appsettings.json", 2))
    body_parts.append(p("Tệp MiniSupermarket.API/appsettings.json đã được cấu hình chuỗi kết nối DefaultConnection chuẩn:"))
    body_parts.append(code_block('{\n  "ConnectionStrings": {\n    "DefaultConnection": "Server=localhost;Database=MiniSupermarketDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"\n  }\n}'))
    
    # 4. PHẦN 3: DỰ ÁN CONSOLE
    body_parts.append(heading("3. HƯỚNG DẪN CHẠY & KIỂM THỬ CONSOLE (TIẾT 1 & TIẾT 4)", 1))
    body_parts.append(p("Dự án Console ThucHanhAdoNet chứa đầy đủ 3 bài tập nền tảng của Tiết 1 và bài kiểm chứng Rollback của Tiết 4:"))
    body_parts.append(code_block("# Cách 1: Khởi chạy menu tương tác lựa chọn từng bài (0 - 5)\ndotnet run --project ThucHanhAdoNet\n\n# Cách 2: Chạy kiểm thử tự động toàn bộ 4 bài tập\ndotnet run --project ThucHanhAdoNet -- 5"))
    
    console_headers = ["Bài tập", "Kỹ thuật áp dụng", "Kết quả hiển thị trên màn hình Console"]
    console_rows = [
        ["Bài 1\n(Tiết 1)", "ExecuteScalar()\nĐếm 1 ô duy nhất", "-> Đã kết nối thành công tới SQL Server!\n-> Tổng số mặt hàng hiện có trong kho siêu thị: 20 sản phẩm."],
        ["Bài 2\n(Tiết 1)", "ExecuteNonQuery()\n& SqlParameter", "-> THÀNH CÔNG: Đã cập nhật tồn kho cho Sản phẩm ID = 1 thành 250 đơn vị.\n-> Số dòng dữ liệu bị ảnh hưởng: 1 dòng."],
        ["Bài 3\n(Tiết 1)", "SqlDataReader\nForward-Only luồng đọc nhanh", "In bảng danh sách 20 sản phẩm căn lề chuẩn (MÃ SP, MÃ VẠCH, TÊN SẢN PHẨM, ĐƠN GIÁ, TỒN KHO).\n-> Tổng cộng đã đọc thành công: 20 mặt hàng từ SQL Server."],
        ["Tiết 4", "SqlTransaction\nKiểm chứng cơ chế Rollback", "-> Bước 1: Đã trừ tồn kho SP 1 (Số dòng tác động: 1).\n-> Bước 2: Ngoại lệ logic SP 2 hết kho thực tế!\n-> [HỆ THỐNG]: Đã kích hoạt transaction.Rollback()!\n-> [Đối soát SSMS]: Tồn kho SP 1 sau Rollback vẫn giữ nguyên 250."]
    ]
    body_parts.append(make_table(console_headers, console_rows, [1600, 2600, 4800], header_bg="1B365D"))
    body_parts.append(p("", space_after=140))
    
    # 5. PHẦN 4: WEB API & SWAGGER
    body_parts.append(heading("4. HƯỚNG DẪN KHỞI CHẠY WEB API & KIỂM THỬ TRÊN SWAGGER UI", 1))
    body_parts.append(p("Web API MiniSupermarket.API cung cấp đầy đủ các endpoint theo chuẩn kiến trúc ADO.NET thuần:"))
    body_parts.append(code_block("# Khởi chạy Web API từ thư mục gốc\ndotnet run --project MiniSupermarket.API\n\n# Truy cập Swagger UI trực tiếp trên trình duyệt:\nhttp://localhost:5150/swagger hoặc https://localhost:7167/swagger"))
    
    body_parts.append(heading("4.1. Nhóm Endpoint Tiết 2: Tra cứu Barcode & Disconnected Cache (AdoProduct)", 2))
    body_parts.append(bullet("Test Case 2.1 - Quét mã vạch có thật (200 OK):", "GET /api/ado-products/barcode/893456789001. Phản hồi thông tin 'Snack Khoai Tây O''Star Gói 60g', đơn giá 12,500 đ, tồn kho 250 bằng SqlDataReader (<100ms)."))
    body_parts.append(bullet("Test Case 2.2 - Quét mã vạch sai (404 Not Found):", "GET /api/ado-products/barcode/999999999999. Phản hồi thông báo: 'Không tìm thấy sản phẩm có mã vạch: 999999999999'."))
    body_parts.append(bullet("Test Case 2.3 - Tải danh sách lưu đệm RAM (200 OK):", "GET /api/ado-products/disconnected-cache. Trả về totalLoaded: 20, cachedAt và danh sách sản phẩm. Kết nối SQL Server được đóng ngay sau khi Fill() vào DataTable."))
    body_parts.append(bullet("Test Case 2.4 - Bài tập 2.1: Lọc theo ngưỡng tồn kho:", "GET /api/ado-products/filter-stock?minStock=60. Trả về danh sách các mặt hàng có tồn kho <= 60 để chuẩn bị nhập hàng."))
    body_parts.append(bullet("Test Case 2.5 - Bài tập 2.2: Đếm sản phẩm theo danh mục:", "GET /api/ado-products/category-summary. Sử dụng DataTable và SqlDataAdapter gom nhóm SELECT CategoryId, COUNT(*) AS Total."))
    
    body_parts.append(heading("4.2. Nhóm Endpoint Tiết 3: Báo cáo Doanh thu Stored Procedure (Reports)", 2))
    body_parts.append(bullet("Test Case 3.1 - Báo cáo ca bán theo thu ngân (200 OK):", "GET /api/reports/revenue-by-cashier. Thực thi sp_GetRevenueByCashier với CommandType.StoredProcedure. Kết quả khớp chính xác 5 thu ngân trong giáo trình:"))
    body_parts.append(code_block('{\n  "success": true,\n  "totalCashiers": 5,\n  "grandTotalRevenue": 4822000.00,\n  "data": [\n    { "cashierUsername": "cashier03", "totalOrders": 2, "totalRevenue": 1435000.00, "totalPointsAwarded": 143 },\n    { "cashierUsername": "cashier05", "totalOrders": 3, "totalRevenue": 1328000.00, "totalPointsAwarded": 132 },\n    { "cashierUsername": "cashier01", "totalOrders": 4, "totalRevenue": 1322000.00, "totalPointsAwarded": 131 },\n    { "cashierUsername": "cashier04", "totalOrders": 3, "totalRevenue": 484000.00, "totalPointsAwarded": 48 },\n    { "cashierUsername": "cashier02", "totalOrders": 3, "totalRevenue": 253000.00, "totalPointsAwarded": 24 }\n  ]\n}'))
    body_parts.append(bullet("Test Case 3.2 - Bài tập 3.1: Báo cáo theo khoảng ngày:", "GET /api/reports/revenue-by-date-range?fromDate=2026-08-01&toDate=2026-08-31. Gọi Stored Procedure sp_GetRevenueByDateRange truyền tham số an toàn."))
    body_parts.append(bullet("Test Case 3.3 - Bài tập 3.2: Top 5 sản phẩm bán chạy nhất:", "GET /api/reports/top-selling-products. Gọi Stored Procedure sp_GetTop5SellingProducts thống kê số lượng bán và doanh thu cao nhất."))
    
    body_parts.append(heading("4.3. Nhóm Endpoint Tiết 5: Giao dịch Thanh toán POS Đa Bảng (Checkout)", 2))
    body_parts.append(bullet("Test Case 5.1 - Thanh toán hợp lệ (COMMIT - 200 OK):", "POST /api/checkout với Request Body:"))
    body_parts.append(code_block('{\n  "cashierUsername": "cashier01",\n  "customerId": 1,\n  "items": [\n    { "productId": 1, "quantity": 2, "unitPrice": 12500 },\n    { "productId": 5, "quantity": 3, "unitPrice": 10000 }\n  ]\n}'))
    body_parts.append(p("- Kết quả phản hồi (200 OK): Sinh ra hóa đơn mới OrderId = 16, mã HD-..., tổng tiền 55,000 đ, tích lũy 5 điểm thưởng.\n- Đối soát SSMS: Bảng Orders có đơn 16, OrderDetails có 2 dòng, SP 1 bị trừ 2 đơn vị (còn 248), SP 5 bị trừ 3 đơn vị (còn 317), Khách hàng ID 1 được cộng 5 điểm thưởng."))
    
    body_parts.append(bullet("Test Case 5.2 - Mua quá tồn kho (ROLLBACK - 400 BadRequest):", "POST /api/checkout (Cố tình đặt mua 999 hộp bánh Danisa ID 2 trong khi tồn kho chỉ còn 40):"))
    body_parts.append(code_block('{\n  "cashierUsername": "cashier01",\n  "customerId": 1,\n  "items": [\n    { "productId": 1, "quantity": 1, "unitPrice": 12500 },\n    { "productId": 2, "quantity": 999, "unitPrice": 135000 }\n  ]\n}'))
    body_parts.append(p("- Kết quả phản hồi (400 BadRequest):\n  {\"success\":false,\"message\":\"Giao dịch thanh toán bị hủy và đã được Rollback an toàn!\",\"errorDetail\":\"Sản phẩm 'Bánh Quy Bơ Danisa Hộp Thiếc 454g' (ID: 2) không đủ tồn kho! (Tồn kho thực tế: 40, Số lượng yêu cầu mua: 999)\"}\n- Đối soát tính nguyên tử (Atomicity): Trên SQL Server hoàn toàn KHÔNG sinh ra hóa đơn rác nào; tồn kho SP 1 đứng trước trong giỏ hàng vẫn được bảo toàn nguyên vẹn 100%."))
    
    body_parts.append(bullet("Test Case 5.3 - Bài tập mở rộng: Hủy hóa đơn & Hoàn trả tồn kho:", "DELETE /api/checkout/cancel/16.\n- Kỹ thuật: Bọc chuỗi đọc chi tiết hóa đơn, hoàn trả tồn kho Products, khấu trừ lại điểm thưởng Customers, xóa OrderDetails và xóa Orders trong 1 SqlTransaction duy nhất.\n- Kết quả phản hồi (200 OK): 'Đã hủy thành công hóa đơn #16 và hoàn trả toàn bộ tồn kho vào CSDL!'. Tồn kho SP 1 được cộng trả lại đúng 250 đơn vị."))
    
    # 6. PHẦN 5: CHECKLIST
    body_parts.append(heading("5. BẢNG CHECKLIST NGHIỆM THU ĐẠT CHUẨN BUỔI 5", 1))
    rubric_headers = ["STT", "Hạng mục kiểm tra", "Tiêu chuẩn đánh giá", "Kết quả"]
    rubric_rows = [
        ["1", "Thành phần ADO.NET (Tiết 1)", "Bọc using an toàn, dùng SqlParameter chống SQL Injection, phân biệt ExecuteScalar, ExecuteNonQuery, ExecuteReader.", "[x] Đạt"],
        ["2", "Tra cứu Barcode (Tiết 2)", "GET /api/ado-products/barcode/{barcode} trả về nhanh <100ms bằng SqlDataReader, xử lý 404 thân thiện.", "[x] Đạt"],
        ["3", "Disconnected Cache (Tiết 2)", "GET /api/ado-products/disconnected-cache nạp 20 sản phẩm qua DataTable bằng SqlDataAdapter.", "[x] Đạt"],
        ["4", "Stored Procedure (Tiết 3)", "Tạo thành công sp_GetRevenueByCashier, API Reports trả về đủ 5 thu ngân, tổng 4,822,000 đ.", "[x] Đạt"],
        ["5", "Chuẩn ACID (Tiết 4)", "Mô phỏng Rollback an toàn khi có lỗi phát sinh, dữ liệu tồn kho được bảo toàn nguyên trạng.", "[x] Đạt"],
        ["6", "API Checkout POS (Tiết 5)", "POST /api/checkout thực hiện đồng thời tạo Order, thêm OrderDetails, trừ tồn kho và tích điểm trong 1 Transaction.", "[x] Đạt"],
        ["7", "Bài tập mở rộng (Tiết 5)", "DELETE /api/checkout/cancel/{orderId} hủy đơn, tự động hoàn trả tồn kho và khấu trừ điểm thưởng.", "[x] Đạt"]
    ]
    body_parts.append(make_table(rubric_headers, rubric_rows, [700, 2400, 4700, 1200], header_bg="1B365D"))
    
    # Ghép toàn bộ nội dung tài liệu
    content_xml = "".join(body_parts)
    
    document_xml = f'''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<w:document xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
    <w:body>
        {content_xml}
        <w:sectPr>
            <w:pgSz w:w="11906" w:h="16838"/>
            <w:pgMar w:top="1080" w:right="1080" w:bottom="1080" w:left="1080" w:header="720" w:footer="720" w:gutter="0"/>
        </w:sectPr>
    </w:body>
</w:document>'''

    content_types_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Types xmlns="http://schemas.openxmlformats.org/package/2006/content-types">
    <Default Extension="rels" ContentType="application/vnd.openxmlformats-package.relationships+xml"/>
    <Default Extension="xml" ContentType="application/xml"/>
    <Override PartName="/word/document.xml" ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml"/>
    <Override PartName="/word/styles.xml" ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.styles+xml"/>
</Types>'''

    rels_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
    <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument" Target="word/document.xml"/>
</Relationships>'''

    doc_rels_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
    <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles" Target="styles.xml"/>
</Relationships>'''

    styles_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<w:styles xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
    <w:docDefaults>
        <w:rPrDefault>
            <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri" w:eastAsia="Calibri" w:cs="Calibri"/>
                <w:sz w:val="22"/>
                <w:szCs w:val="22"/>
                <w:lang w:val="vi-VN"/>
            </w:rPr>
        </w:rPrDefault>
    </w:docDefaults>
    <w:style w:type="paragraph" w:default="1" w:styleId="Normal">
        <w:name w:val="Normal"/>
        <w:qFormat/>
    </w:style>
    <w:style w:type="paragraph" w:styleId="ListParagraph">
        <w:name w:val="List Paragraph"/>
        <w:basedOn w:val="Normal"/>
        <w:qFormat/>
    </w:style>
</w:styles>'''

    # Đóng gói file .docx bằng zipfile
    with zipfile.ZipFile(filename, 'w', zipfile.ZIP_DEFLATED) as zf:
        zf.writestr('[Content_Types].xml', content_types_xml)
        zf.writestr('_rels/.rels', rels_xml)
        zf.writestr('word/_rels/document.xml.rels', doc_rels_xml)
        zf.writestr('word/document.xml', document_xml)
        zf.writestr('word/styles.xml', styles_xml)

    print(f"Xuat thanh cong file Word: {filename}")

if __name__ == "__main__":
    out_path = r"D:\MiniSuperMarket-Tran_Hoang_Lin\Huong_Dan_Chay_Va_Test_Buoi_5.docx"
    build_docx(out_path)
