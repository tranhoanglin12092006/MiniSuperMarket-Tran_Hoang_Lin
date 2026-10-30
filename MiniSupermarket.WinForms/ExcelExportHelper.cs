using ClosedXML.Excel;
using MiniSupermarket.WinForms.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MiniSupermarket.WinForms
{
    /// <summary>
    /// Helper tiện ích xuất báo cáo ra Excel (.xlsx) qua ClosedXML hoặc file .csv trực tiếp (Item 48)
    /// </summary>
    public static class ExcelExportHelper
    {
        public static void ExportProducts(IEnumerable<ProductItemViewDto> products, string filePath)
        {
            if (filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                ExportProductsToCsv(products, filePath);
            }
            else
            {
                ExportProductsToXlsx(products, filePath);
            }
        }

        public static void ExportOrders(IEnumerable<DayOrderDto> orders, decimal totalRevenue, string filePath)
        {
            if (filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                ExportOrdersToCsv(orders, totalRevenue, filePath);
            }
            else
            {
                ExportOrdersToXlsx(orders, totalRevenue, filePath);
            }
        }

        public static void ExportCategories(IEnumerable<CategoryDto> categories, string filePath)
        {
            if (filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                ExportCategoriesToCsv(categories, filePath);
            }
            else
            {
                ExportCategoriesToXlsx(categories, filePath);
            }
        }

        public static void ExportCustomers(IEnumerable<CustomerDto> customers, string filePath)
        {
            if (filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                ExportCustomersToCsv(customers, filePath);
            }
            else
            {
                ExportCustomersToXlsx(customers, filePath);
            }
        }

        private static void ExportCustomersToXlsx(IEnumerable<CustomerDto> customers, string filePath)
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Khách hàng thân thiết");

            // Tiêu đề báo cáo
            ws.Cell(1, 1).Value = "DANH SÁCH KHÁCH HÀNG THÂN THIẾT & TÍCH ĐIỂM";
            ws.Cell(1, 1).Style.Font.Bold = true;
            ws.Cell(1, 1).Style.Font.FontSize = 16;
            ws.Cell(1, 1).Style.Font.FontColor = XLColor.FromArgb(16, 42, 33);
            ws.Range(1, 1, 1, 6).Merge();

            ws.Cell(2, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss} | Tổng số: {customers.Count()} khách hàng";
            ws.Cell(2, 1).Style.Font.Italic = true;
            ws.Cell(2, 1).Style.Font.FontColor = XLColor.FromArgb(100, 116, 139);

            // Tiêu đề các cột
            string[] headers = { "Mã KH", "Họ và tên", "Số điện thoại", "Hạng thành viên", "Điểm tích lũy", "Địa chỉ liên hệ" };
            for (int i = 0; i < headers.Length; i++)
            {
                var cell = ws.Cell(4, i + 1);
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.Font.FontColor = XLColor.White;
                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(16, 42, 33); // Dark Green
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            int row = 5;
            foreach (var c in customers)
            {
                var idCell = ws.Cell(row, 1);
                idCell.Value = c.CustomerId;
                idCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Cell(row, 2).Value = c.CustomerName ?? string.Empty;

                var phoneCell = ws.Cell(row, 3);
                phoneCell.SetValue(c.PhoneNumber ?? string.Empty);
                phoneCell.Style.NumberFormat.Format = "@";
                phoneCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                var rankCell = ws.Cell(row, 4);
                rankCell.Value = c.MembershipRank ?? "Chuẩn";
                rankCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                var pointsCell = ws.Cell(row, 5);
                pointsCell.Value = c.RewardPoints;
                pointsCell.Style.NumberFormat.Format = "#,##0";
                pointsCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                ws.Cell(row, 6).Value = c.Address ?? string.Empty;
                row++;
            }

            var dataRange = ws.Range(4, 1, Math.Max(4, row - 1), 6);
            dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            dataRange.Style.Border.OutsideBorderColor = XLColor.FromArgb(203, 213, 225);
            dataRange.Style.Border.InsideBorderColor = XLColor.FromArgb(226, 232, 240);

            ws.Columns().AdjustToContents();
            workbook.SaveAs(filePath);
        }

        private static void ExportCustomersToCsv(IEnumerable<CustomerDto> customers, string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Mã KH,Họ và tên,Số điện thoại,Hạng thành viên,Điểm tích lũy,Địa chỉ liên hệ");

            foreach (var c in customers)
            {
                string safeName = $"\"{(c.CustomerName ?? string.Empty).Replace("\"", "\"\"")}\"";
                string safeAddress = $"\"{(c.Address ?? string.Empty).Replace("\"", "\"\"")}\"";
                string safePhone = $"\"{(c.PhoneNumber ?? string.Empty).Replace("\"", "\"\"")}\"";
                string rank = c.MembershipRank ?? "Chuẩn";
                sb.AppendLine($"{c.CustomerId},{safeName},{safePhone},{rank},{c.RewardPoints},{safeAddress}");
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        private static void ExportCategoriesToXlsx(IEnumerable<CategoryDto> categories, string filePath)
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Danh mục nhóm hàng");

            // Tiêu đề báo cáo
            ws.Cell(1, 1).Value = "DANH SÁCH NHÓM HÀNG & PHÂN LOẠI SIÊU THỊ";
            ws.Cell(1, 1).Style.Font.Bold = true;
            ws.Cell(1, 1).Style.Font.FontSize = 16;
            ws.Cell(1, 1).Style.Font.FontColor = XLColor.FromArgb(16, 42, 33);
            ws.Range(1, 1, 1, 3).Merge();

            ws.Cell(2, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
            ws.Cell(2, 1).Style.Font.Italic = true;
            ws.Cell(2, 1).Style.Font.FontColor = XLColor.FromArgb(100, 116, 139);

            // Tiêu đề các cột
            string[] headers = { "Mã nhóm", "Tên nhóm hàng", "Mô tả chi tiết" };
            for (int i = 0; i < headers.Length; i++)
            {
                var cell = ws.Cell(4, i + 1);
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.Font.FontColor = XLColor.White;
                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(16, 42, 33); // Dark Green
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            int row = 5;
            foreach (var c in categories)
            {
                var idCell = ws.Cell(row, 1);
                idCell.Value = c.CategoryId;
                idCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Cell(row, 2).Value = c.CategoryName;
                ws.Cell(row, 3).Value = c.Description ?? string.Empty;
                row++;
            }

            ws.Columns().AdjustToContents();
            workbook.SaveAs(filePath);
        }

        private static void ExportCategoriesToCsv(IEnumerable<CategoryDto> categories, string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Mã nhóm,Tên nhóm hàng,Mô tả chi tiết");

            foreach (var c in categories)
            {
                string safeName = $"\"{c.CategoryName.Replace("\"", "\"\"")}\"";
                string safeDesc = $"\"{(c.Description ?? string.Empty).Replace("\"", "\"\"")}\"";
                sb.AppendLine($"{c.CategoryId},{safeName},{safeDesc}");
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        private static void ExportProductsToXlsx(IEnumerable<ProductItemViewDto> products, string filePath)
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Danh mục sản phẩm");

            // Tiêu đề báo cáo
            ws.Cell(1, 1).Value = "DANH MỤC HÀNG HÓA & TỒN KHO SIÊU THỊ";
            ws.Cell(1, 1).Style.Font.Bold = true;
            ws.Cell(1, 1).Style.Font.FontSize = 16;
            ws.Cell(1, 1).Style.Font.FontColor = XLColor.FromArgb(15, 23, 42);
            ws.Range(1, 1, 1, 7).Merge();

            ws.Cell(2, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
            ws.Cell(2, 1).Style.Font.Italic = true;
            ws.Cell(2, 1).Style.Font.FontColor = XLColor.FromArgb(100, 116, 139);

            // Tiêu đề các cột
            string[] headers = { "Mã SP", "Mã vạch", "Tên sản phẩm", "Nhóm hàng", "Đơn giá (VNĐ)", "Tồn kho", "Cảnh báo tồn" };
            for (int i = 0; i < headers.Length; i++)
            {
                var cell = ws.Cell(4, i + 1);
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.Font.FontColor = XLColor.White;
                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(15, 23, 42); // Slate 900
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            int row = 5;
            foreach (var p in products)
            {
                ws.Cell(row, 1).Value = p.ProductId;
                ws.Cell(row, 2).Value = p.Barcode;
                ws.Cell(row, 3).Value = p.ProductName;
                ws.Cell(row, 4).Value = p.CategoryName;

                var priceCell = ws.Cell(row, 5);
                priceCell.Value = p.Price;
                priceCell.Style.NumberFormat.Format = "#,##0";
                priceCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                var stockCell = ws.Cell(row, 6);
                stockCell.Value = p.StockQuantity;
                stockCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                var alertCell = ws.Cell(row, 7);
                if (p.StockQuantity <= 10)
                {
                    stockCell.Style.Fill.BackgroundColor = XLColor.LightCoral;
                    stockCell.Style.Font.Bold = true;
                    stockCell.Style.Font.FontColor = XLColor.DarkRed;

                    alertCell.Value = "⚠️ SẮP HẾT HÀNG (<= 10)";
                    alertCell.Style.Font.Bold = true;
                    alertCell.Style.Font.FontColor = XLColor.DarkRed;
                    alertCell.Style.Fill.BackgroundColor = XLColor.FromArgb(254, 226, 226);
                }
                else
                {
                    alertCell.Value = "Ổn định";
                    alertCell.Style.Font.FontColor = XLColor.Green;
                }

                row++;
            }

            ws.Columns().AdjustToContents();
            workbook.SaveAs(filePath);
        }

        private static void ExportProductsToCsv(IEnumerable<ProductItemViewDto> products, string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Mã SP,Mã vạch,Tên sản phẩm,Nhóm hàng,Đơn giá (VNĐ),Tồn kho,Cảnh báo tồn");

            foreach (var p in products)
            {
                string alert = p.StockQuantity <= 10 ? "SAP HET HANG" : "ON DINH";
                string safeName = $"\"{p.ProductName.Replace("\"", "\"\"")}\"";
                string safeCat = $"\"{p.CategoryName.Replace("\"", "\"\"")}\"";
                sb.AppendLine($"{p.ProductId},{p.Barcode},{safeName},{safeCat},{p.Price:0},{p.StockQuantity},{alert}");
            }

            // Ghi file với UTF-8 BOM để Excel hiển thị đúng dấu tiếng Việt
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        private static void ExportOrdersToXlsx(IEnumerable<DayOrderDto> orders, decimal totalRevenue, string filePath)
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Danh sách hóa đơn");

            ws.Cell(1, 1).Value = "BÁO CÁO DOANH THU & HÓA ĐƠN BÁN HÀNG";
            ws.Cell(1, 1).Style.Font.Bold = true;
            ws.Cell(1, 1).Style.Font.FontSize = 16;
            ws.Cell(1, 1).Style.Font.FontColor = XLColor.FromArgb(15, 23, 42);
            ws.Range(1, 1, 1, 7).Merge();

            ws.Cell(2, 1).Value = $"Ngày lập báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm:ss} | Tổng doanh thu: {totalRevenue:N0} VNĐ";
            ws.Cell(2, 1).Style.Font.Italic = true;
            ws.Cell(2, 1).Style.Font.FontColor = XLColor.FromArgb(100, 116, 139);

            string[] headers = { "Mã HĐ", "Thời gian", "Khách hàng", "Thu ngân", "Số lượng món", "Tổng tiền (VNĐ)", "Điểm thưởng" };
            for (int i = 0; i < headers.Length; i++)
            {
                var cell = ws.Cell(4, i + 1);
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.Font.FontColor = XLColor.White;
                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(37, 99, 235); // Blue 600
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            int row = 5;
            foreach (var o in orders)
            {
                ws.Cell(row, 1).Value = o.OrderCode;
                ws.Cell(row, 2).Value = o.Time;
                ws.Cell(row, 3).Value = o.CustomerName;
                ws.Cell(row, 4).Value = o.Cashier;
                ws.Cell(row, 5).Value = o.TotalItems;

                var amountCell = ws.Cell(row, 6);
                amountCell.Value = o.FinalAmount;
                amountCell.Style.NumberFormat.Format = "#,##0";
                amountCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                ws.Cell(row, 7).Value = o.RewardPoints;
                row++;
            }

            // Dòng tổng kết
            ws.Cell(row, 1).Value = "TỔNG CỘNG";
            ws.Cell(row, 1).Style.Font.Bold = true;
            ws.Range(row, 1, row, 5).Merge();
            ws.Cell(row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            var sumCell = ws.Cell(row, 6);
            sumCell.Value = totalRevenue;
            sumCell.Style.NumberFormat.Format = "#,##0";
            sumCell.Style.Font.Bold = true;
            sumCell.Style.Font.FontColor = XLColor.FromArgb(16, 185, 129);
            sumCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

            ws.Columns().AdjustToContents();
            workbook.SaveAs(filePath);
        }

        private static void ExportOrdersToCsv(IEnumerable<DayOrderDto> orders, decimal totalRevenue, string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Mã HĐ,Thời gian,Khách hàng,Thu ngân,Số lượng món,Tổng tiền (VNĐ),Điểm thưởng");

            foreach (var o in orders)
            {
                string safeCode = $"\"{o.OrderCode}\"";
                string safeCust = $"\"{o.CustomerName.Replace("\"", "\"\"")}\"";
                sb.AppendLine($"{safeCode},{o.Time},{safeCust},{o.Cashier},{o.TotalItems},{o.FinalAmount:0},{o.RewardPoints}");
            }

            sb.AppendLine($"TỔNG CỘNG,,,,,{totalRevenue:0},");
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }
    }
}
