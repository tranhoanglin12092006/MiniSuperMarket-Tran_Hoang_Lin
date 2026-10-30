using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms.UI
{
    /// <summary>
    /// DESIGN SYSTEM: PREMIUM SUPERMARKET POS
    /// Hệ màu, Typography và tiện ích đồ họa dùng chung cho toàn bộ hệ thống
    /// </summary>
    public static class UITheme
    {
        // =========================================================
        // 1. PALETTE MÀU SẮC CHỦ ĐẠO (PREMIUM RETAIL PALETTE)
        // =========================================================
        public static readonly Color Primary = Color.FromArgb(22, 163, 74);       // #16A34A - Emerald Green chính
        public static readonly Color PrimaryHover = Color.FromArgb(21, 128, 61);  // #15803D - Hover
        public static readonly Color PrimaryActive = Color.FromArgb(20, 83, 45);  // #14532D - Active/Dark Green
        public static readonly Color DarkGreen = Color.FromArgb(20, 83, 45);      // #14532D
        public static readonly Color AccentGreen = Color.FromArgb(34, 197, 94);   // #22C55E - Light Accent

        public static readonly Color Background = Color.FromArgb(244, 247, 245);  // #F4F7F5 - Nền ứng dụng mát dịu
        public static readonly Color Surface = Color.FromArgb(255, 255, 255);     // #FFFFFF - Mặt thẻ/Card
        public static readonly Color SurfaceMuted = Color.FromArgb(248, 250, 249);// #F8FAF9 - Mặt phụ / Thẻ nhẹ
        public static readonly Color Sidebar = Color.FromArgb(16, 42, 33);        // #102A21 - Sidebar tối sang trọng
        public static readonly Color SidebarHover = Color.FromArgb(26, 61, 49);   // #1A3D31 - Hover menu
        public static readonly Color SidebarActive = Color.FromArgb(22, 163, 74); // #16A34A - Active menu

        public static readonly Color TextPrimary = Color.FromArgb(23, 33, 27);    // #17211B - Chữ đậm chính
        public static readonly Color TextSecondary = Color.FromArgb(100, 116, 139);// #64748B - Chữ phụ/Slate
        public static readonly Color TextMuted = Color.FromArgb(148, 163, 184);   // #94A3B8 - Chữ mờ
        public static readonly Color Border = Color.FromArgb(229, 234, 231);      // #E5EAE7 - Viền nhẹ tinh tế
        public static readonly Color BorderDark = Color.FromArgb(203, 213, 225);  // #CBD5E1 - Viền phân cách

        // Màu trạng thái & phản hồi
        public static readonly Color Success = Color.FromArgb(22, 163, 74);      // #16A34A
        public static readonly Color SuccessLight = Color.FromArgb(220, 252, 231);// #DCFCE7
        public static readonly Color Warning = Color.FromArgb(245, 158, 11);      // #F59E0B
        public static readonly Color WarningLight = Color.FromArgb(254, 243, 199);// #FEF3C7
        public static readonly Color Danger = Color.FromArgb(239, 68, 68);        // #EF4444
        public static readonly Color DangerLight = Color.FromArgb(254, 226, 226); // #FEE2E2
        public static readonly Color Info = Color.FromArgb(59, 130, 246);         // #3B82F6
        public static readonly Color InfoLight = Color.FromArgb(219, 234, 254);   // #DBEAFE

        // =========================================================
        // 2. TYPOGRAPHY (Segoe UI Hierarchy)
        // =========================================================
        public static readonly Font FontDisplay = new Font("Segoe UI", 18f, FontStyle.Bold);
        public static readonly Font FontHeader = new Font("Segoe UI", 14f, FontStyle.Bold);
        public static readonly Font FontSubHeader = new Font("Segoe UI", 11.5f, FontStyle.Bold);
        public static readonly Font FontTitle = new Font("Segoe UI", 10.5f, FontStyle.Bold);
        public static readonly Font FontBody = new Font("Segoe UI", 9.5f, FontStyle.Regular);
        public static readonly Font FontBodyBold = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        public static readonly Font FontSmall = new Font("Segoe UI", 8.5f, FontStyle.Regular);
        public static readonly Font FontSmallBold = new Font("Segoe UI", 8.5f, FontStyle.Bold);

        // =========================================================
        // 3. TIỆN ÍCH ĐỒ HỌA GDI+ (GRAPHICS PATHS)
        // =========================================================
        public static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r = radius;
            if (r <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            float d = r * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        public static void DrawRoundedRectangle(Graphics g, Pen pen, Rectangle rect, int radius)
        {
            using GraphicsPath path = GetRoundedPath(rect, radius);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawPath(pen, path);
        }

        public static void FillRoundedRectangle(Graphics g, Brush brush, Rectangle rect, int radius)
        {
            using GraphicsPath path = GetRoundedPath(rect, radius);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillPath(brush, path);
        }

        public static string FormatCurrency(decimal amount)
        {
            return $"{amount:N0} đ";
        }
    }
}
