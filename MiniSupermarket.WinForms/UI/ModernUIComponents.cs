using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms.UI
{
    public enum ButtonVariant
    {
        Primary,
        Secondary,
        Danger,
        Light,
        Accent,
        Ghost
    }

    public enum ToastType
    {
        Success,
        Warning,
        Error,
        Info
    }

    /// <summary>
    /// Nút bấm hiện đại bo góc, hiệu ứng hover/pressed tinh tế
    /// </summary>
    public class ModernButton : Button
    {
        private int _borderRadius = 10;
        private ButtonVariant _variant = ButtonVariant.Primary;
        private bool _isHovered = false;
        private bool _isPressed = false;

        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; Invalidate(); }
        }

        public ButtonVariant Variant
        {
            get => _variant;
            set { _variant = value; ApplyVariantColors(); Invalidate(); }
        }

        public ModernButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Font = UITheme.FontBodyBold;
            Cursor = Cursors.Hand;
            Size = new Size(130, 40);
            DoubleBuffered = true;
            ApplyVariantColors();
        }

        private void ApplyVariantColors()
        {
            switch (_variant)
            {
                case ButtonVariant.Primary:
                    BackColor = UITheme.Primary;
                    ForeColor = Color.White;
                    break;
                case ButtonVariant.Secondary:
                    BackColor = UITheme.Sidebar;
                    ForeColor = Color.White;
                    break;
                case ButtonVariant.Danger:
                    BackColor = UITheme.Danger;
                    ForeColor = Color.White;
                    break;
                case ButtonVariant.Light:
                    BackColor = UITheme.SurfaceMuted;
                    ForeColor = UITheme.TextPrimary;
                    break;
                case ButtonVariant.Accent:
                    BackColor = UITheme.AccentGreen;
                    ForeColor = UITheme.DarkGreen;
                    break;
                case ButtonVariant.Ghost:
                    BackColor = Color.Transparent;
                    ForeColor = UITheme.TextSecondary;
                    break;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            _isPressed = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            _isPressed = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            _isPressed = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color baseColor = BackColor;
            if (!Enabled)
            {
                baseColor = Color.FromArgb(226, 232, 240);
            }
            else if (_isPressed)
            {
                baseColor = ControlPaint.Dark(baseColor, 0.15f);
            }
            else if (_isHovered)
            {
                baseColor = ControlPaint.Light(baseColor, 0.10f);
            }

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (GraphicsPath path = UITheme.GetRoundedPath(rect, _borderRadius))
            {
                using (SolidBrush brush = new SolidBrush(baseColor))
                {
                    g.FillPath(brush, path);
                }

                // Viền nhẹ cho nút Light hoặc Ghost
                if (_variant == ButtonVariant.Light || _variant == ButtonVariant.Ghost)
                {
                    using Pen pen = new Pen(UITheme.Border, 1.2f);
                    g.DrawPath(pen, path);
                }
            }

            // Vẽ văn bản
            Color textColor = Enabled ? ForeColor : UITheme.TextMuted;
            TextRenderer.DrawText(g, Text, Font, rect, textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
        }
    }

    /// <summary>
    /// Thẻ Card nền trắng bo góc, viền nhẹ
    /// </summary>
    public class ModernCard : Panel
    {
        private int _borderRadius = 12;
        private Color _borderColor = UITheme.Border;
        private Color _topAccentColor = Color.Empty;

        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; Invalidate(); }
        }

        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        public Color TopAccentColor
        {
            get => _topAccentColor;
            set { _topAccentColor = value; Invalidate(); }
        }

        public ModernCard()
        {
            BackColor = UITheme.Surface;
            Padding = new Padding(16);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath path = UITheme.GetRoundedPath(rect, _borderRadius))
            {
                using (Pen pen = new Pen(_borderColor, 1.2f))
                {
                    g.DrawPath(pen, path);
                }

                if (_topAccentColor != Color.Empty)
                {
                    using Pen accentPen = new Pen(_topAccentColor, 4f);
                    g.DrawLine(accentPen, _borderRadius, 1, Width - _borderRadius, 1);
                }
            }
        }
    }

    /// <summary>
    /// Huy hiệu trạng thái dạng viên thuốc (Pill Badge)
    /// </summary>
    public class ModernBadge : Label
    {
        public ModernBadge()
        {
            AutoSize = false;
            Size = new Size(110, 26);
            TextAlign = ContentAlignment.MiddleCenter;
            Font = UITheme.FontSmallBold;
            BackColor = UITheme.SuccessLight;
            ForeColor = UITheme.Success;
            DoubleBuffered = true;
        }

        public void SetStatus(string text, ToastType type)
        {
            Text = text;
            switch (type)
            {
                case ToastType.Success:
                    BackColor = UITheme.SuccessLight;
                    ForeColor = UITheme.Success;
                    break;
                case ToastType.Warning:
                    BackColor = UITheme.WarningLight;
                    ForeColor = UITheme.Warning;
                    break;
                case ToastType.Error:
                    BackColor = UITheme.DangerLight;
                    ForeColor = UITheme.Danger;
                    break;
                case ToastType.Info:
                    BackColor = UITheme.InfoLight;
                    ForeColor = UITheme.Info;
                    break;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            int r = Height / 2;
            using (GraphicsPath path = UITheme.GetRoundedPath(rect, r))
            {
                using (SolidBrush b = new SolidBrush(BackColor))
                {
                    g.FillPath(b, path);
                }
            }

            TextRenderer.DrawText(g, Text, Font, rect, ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }

    /// <summary>
    /// Tiện ích nâng cấp giao diện toàn diện cho các Form WinForms sẵn có
    /// </summary>
    public static class UIStyler
    {
        /// <summary>
        /// Nâng cấp giao diện DataGridView thành chuẩn Retail POS cao cấp
        /// </summary>
        public static void StyleDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.BackgroundColor = UITheme.Surface;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = UITheme.Border;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowTemplate.Height = 40;
            dgv.Font = UITheme.FontBody;

            // Column Headers Style
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 44;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 249);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = UITheme.TextSecondary;
            dgv.ColumnHeadersDefaultCellStyle.Font = UITheme.FontBodyBold;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            // Rows Style
            dgv.RowsDefaultCellStyle.BackColor = UITheme.Surface;
            dgv.RowsDefaultCellStyle.ForeColor = UITheme.TextPrimary;
            dgv.RowsDefaultCellStyle.SelectionBackColor = UITheme.SuccessLight;
            dgv.RowsDefaultCellStyle.SelectionForeColor = UITheme.DarkGreen;
            dgv.RowsDefaultCellStyle.Padding = new Padding(8, 4, 8, 4);

            // Alternating Rows (Zebra striping)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 251);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = UITheme.TextPrimary;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = UITheme.SuccessLight;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = UITheme.DarkGreen;
        }

        /// <summary>
        /// Nâng cấp Button theo phong cách Flat bo góc đồng bộ
        /// </summary>
        public static void StyleButton(Button btn, ButtonVariant variant = ButtonVariant.Primary, int radius = 10)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = UITheme.FontBodyBold;

            Color baseColor;
            Color hoverColor;
            Color textColor;

            switch (variant)
            {
                case ButtonVariant.Primary:
                    baseColor = UITheme.Primary;
                    hoverColor = UITheme.PrimaryHover;
                    textColor = Color.White;
                    break;
                case ButtonVariant.Secondary:
                    baseColor = UITheme.Sidebar;
                    hoverColor = UITheme.SidebarHover;
                    textColor = Color.White;
                    break;
                case ButtonVariant.Danger:
                    baseColor = UITheme.Danger;
                    hoverColor = Color.FromArgb(220, 38, 38);
                    textColor = Color.White;
                    break;
                case ButtonVariant.Accent:
                    baseColor = UITheme.AccentGreen;
                    hoverColor = Color.FromArgb(16, 185, 129);
                    textColor = UITheme.DarkGreen;
                    break;
                case ButtonVariant.Light:
                default:
                    baseColor = UITheme.SurfaceMuted;
                    hoverColor = Color.FromArgb(226, 232, 240);
                    textColor = UITheme.TextPrimary;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = UITheme.Border;
                    break;
            }

            btn.BackColor = baseColor;
            btn.ForeColor = textColor;

            btn.MouseEnter -= Button_MouseEnter;
            btn.MouseLeave -= Button_MouseLeave;

            void Button_MouseEnter(object? s, EventArgs e)
            {
                if (btn.Enabled) btn.BackColor = hoverColor;
            }

            void Button_MouseLeave(object? s, EventArgs e)
            {
                if (btn.Enabled) btn.BackColor = baseColor;
            }

            btn.MouseEnter += Button_MouseEnter;
            btn.MouseLeave += Button_MouseLeave;
        }

        /// <summary>
        /// Nâng cấp ô nhập liệu TextBox hiện đại
        /// </summary>
        public static void StyleTextBox(TextBox txt)
        {
            if (txt == null) return;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = UITheme.FontBody;
            txt.BackColor = UITheme.Surface;
            txt.ForeColor = UITheme.TextPrimary;
        }

        /// <summary>
        /// Hiển thị thông báo Toast đẹp mắt, không gây nghẽn giao diện (Non-blocking)
        /// </summary>
        public static void ShowToast(Form parent, string message, ToastType type = ToastType.Success)
        {
            if (parent == null || parent.IsDisposed) return;

            try
            {
                var toast = new Form
                {
                    FormBorderStyle = FormBorderStyle.None,
                    StartPosition = FormStartPosition.Manual,
                    ShowInTaskbar = false,
                    TopMost = true,
                    Size = new Size(340, 54),
                    Opacity = 0.0,
                    BackColor = type switch
                    {
                        ToastType.Success => Color.FromArgb(22, 163, 74),
                        ToastType.Warning => Color.FromArgb(217, 119, 6),
                        ToastType.Error => Color.FromArgb(220, 38, 38),
                        _ => Color.FromArgb(37, 99, 235)
                    }
                };

                string icon = type switch
                {
                    ToastType.Success => "✅",
                    ToastType.Warning => "⚠️",
                    ToastType.Error => "❌",
                    _ => "ℹ️"
                };

                var lbl = new Label
                {
                    Dock = DockStyle.Fill,
                    Text = $"{icon}  {message}",
                    ForeColor = Color.White,
                    Font = UITheme.FontBodyBold,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(16, 0, 16, 0)
                };
                toast.Controls.Add(lbl);

                Point p = parent.PointToScreen(new Point(parent.Width - toast.Width - 25, parent.Height - toast.Height - 35));
                toast.Location = p;
                toast.Show(parent);

                // Hiệu ứng Fade In và Fade Out bằng Timer
                var timer = new System.Windows.Forms.Timer { Interval = 25 };
                int ticks = 0;
                timer.Tick += (s, e) =>
                {
                    ticks++;
                    if (ticks <= 10)
                    {
                        toast.Opacity = ticks * 0.1;
                    }
                    else if (ticks > 90) // sau ~2.5 giây thì fade out
                    {
                        toast.Opacity -= 0.1;
                        if (toast.Opacity <= 0)
                        {
                            timer.Stop();
                            timer.Dispose();
                            toast.Close();
                            toast.Dispose();
                        }
                    }
                };
                timer.Start();
            }
            catch { }
        }
    }
}
