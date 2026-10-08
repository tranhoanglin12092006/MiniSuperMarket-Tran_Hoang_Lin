using BCrypt.Net;

namespace MiniSupermarket.API.Helpers
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Băm mật khẩu bằng thuật toán BCrypt với Salt ngẫu nhiên
        /// </summary>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return string.Empty;

            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 11);
        }

        /// <summary>
        /// Xác thực mật khẩu nhập vào so với chuỗi băm trong cơ sở dữ liệu.
        /// Hỗ trợ kiểm tra backward-compatible với mật khẩu dạng plain text cũ.
        /// </summary>
        public static bool VerifyPassword(string inputPassword, string storedPasswordHash)
        {
            if (string.IsNullOrEmpty(inputPassword) || string.IsNullOrEmpty(storedPasswordHash))
                return false;

            // Nếu mật khẩu trong DB trùng khớp plain text (chưa kịp băm)
            if (inputPassword == storedPasswordHash)
                return true;

            try
            {
                // Kiểm tra bằng BCrypt
                return BCrypt.Net.BCrypt.Verify(inputPassword, storedPasswordHash);
            }
            catch
            {
                // Nếu hash không đúng định dạng BCrypt, so sánh chuỗi
                return inputPassword == storedPasswordHash;
            }
        }

        /// <summary>
        /// Kiểm tra xem chuỗi có phải là định dạng BCrypt hash hợp lệ hay không
        /// </summary>
        public static bool IsHashed(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;
            // Chuỗi BCrypt hash thường dài 60 ký tự và bắt đầu bằng $2a$, $2b$, hoặc $2y$
            return (password.StartsWith("$2a$") || password.StartsWith("$2b$") || password.StartsWith("$2y$")) && password.Length == 60;
        }
    }
}
