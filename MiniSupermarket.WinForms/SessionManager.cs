using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace MiniSupermarket.WinForms
{
    public static class SessionManager
    {
        public static string JwtToken { get; set; } = string.Empty;
        public static string CurrentRole { get; set; } = string.Empty;
        public static string CurrentUsername { get; set; } = string.Empty;
    }

    public static class ApiClientService
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7167/api/")
        };

        // Cung cấp thuộc tính Client để tương thích với các form hiện tại
        public static HttpClient Client => _client;

        // Hàm tự động nạp Token vào HttpClient trước khi gọi API
        public static void SetupHeaderToken()
        {
            // Xóa header cũ trước khi gán để tránh chồng chéo
            _client.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(SessionManager.JwtToken))
            {
                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
        }

        // =========================================================================
        // BỔ SUNG CÁC HÀM TIỆN ÍCH TỰ ĐỘNG GẮN TOKEN (GIÚP KHÔNG BỊ LỖI 401)
        // =========================================================================

        public static async Task<T?> GetFromJsonWithAuthAsync<T>(string endpoint)
        {
            SetupHeaderToken(); // Luôn gắn token trước khi gọi
            return await _client.GetFromJsonAsync<T>(endpoint);
        }

        public static async Task<HttpResponseMessage> PostAsJsonWithAuthAsync<T>(string endpoint, T value)
        {
            SetupHeaderToken(); // Luôn gắn token trước khi gọi
            return await _client.PostAsJsonAsync(endpoint, value);
        }

        public static async Task<HttpResponseMessage> PutAsJsonWithAuthAsync<T>(string endpoint, T value)
        {
            SetupHeaderToken(); // Luôn gắn token trước khi gọi
            return await _client.PutAsJsonAsync(endpoint, value);
        }

        public static async Task<HttpResponseMessage> DeleteWithAuthAsync(string endpoint)
        {
            SetupHeaderToken(); // Luôn gắn token trước khi gọi
            return await _client.DeleteAsync(endpoint);
        }

        // =========================================================================
        // LOGIN (GIỮ NGUYÊN)
        // =========================================================================
        public static async Task<bool> LoginAsync(string username, string password)
        {
            var loginObj = new
            {
                Username = username,
                Password = password
            };

            var response = await _client.PostAsJsonAsync("auth/login", loginObj);

            if (!response.IsSuccessStatusCode)
                return false;

            var jsonString = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(jsonString);

            SessionManager.JwtToken = doc.RootElement.GetProperty("token").GetString() ?? "";
            SessionManager.CurrentRole = doc.RootElement.GetProperty("role").GetString() ?? "";
            SessionManager.CurrentUsername = username;

            // Ngay sau khi login thành công, cấu hình token vào client luôn
            SetupHeaderToken();

            return !string.IsNullOrEmpty(SessionManager.JwtToken);
        }

        // GET CÓ JWT (Dạng thủ công qua HttpRequestMessage - GIỮ NGUYÊN CỦA BẠN)
        public static async Task<string> GetDataWithTokenAsync(string endpoint)
        {
            if (string.IsNullOrWhiteSpace(SessionManager.JwtToken))
            {
                throw new Exception("Chưa đăng nhập hoặc chưa có Token!");
            }

            using var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            var error = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new Exception("401 Unauthorized - Token không hợp lệ!");
            }

            throw new Exception($"API lỗi {(int)response.StatusCode}: {error}");
        }
    }
}