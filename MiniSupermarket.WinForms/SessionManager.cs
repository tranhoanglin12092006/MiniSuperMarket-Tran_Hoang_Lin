using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace MiniSupermarket.WinForms
{
    public static class SessionManager
    {
        public static string JwtToken { get; set; } = string.Empty;
        public static string CurrentRole { get; set; } = string.Empty;
    }

    public static class ApiClientService
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7167/api/")
        };

        // LOGIN
        public static async Task<bool> LoginAsync(
            string username,
            string password)
        {
            var loginObj = new
            {
                Username = username,
                Password = password
            };

            var response = await _client.PostAsJsonAsync(
                "auth/login",
                loginObj);

            if (!response.IsSuccessStatusCode)
                return false;

            var jsonString =
                await response.Content.ReadAsStringAsync();

            using var doc =
                JsonDocument.Parse(jsonString);

            SessionManager.JwtToken =
                doc.RootElement
                    .GetProperty("token")
                    .GetString() ?? "";

            SessionManager.CurrentRole =
                doc.RootElement
                    .GetProperty("role")
                    .GetString() ?? "";

            return !string.IsNullOrEmpty(
                SessionManager.JwtToken);
        }

        // GET CÓ JWT
        public static async Task<string> GetDataWithTokenAsync(
            string endpoint)
        {
            if (string.IsNullOrWhiteSpace(
                SessionManager.JwtToken))
            {
                throw new Exception(
                    "Chưa đăng nhập hoặc chưa có Token!");
            }

            using var request = new HttpRequestMessage(
                HttpMethod.Get,
                endpoint);

            // QUAN TRỌNG: gửi JWT
            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    SessionManager.JwtToken);

            var response =
                await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content
                    .ReadAsStringAsync();
            }

            var error =
                await response.Content
                    .ReadAsStringAsync();

            if (response.StatusCode ==
                System.Net.HttpStatusCode.Unauthorized)
            {
                throw new Exception(
                    "401 Unauthorized - Token không hợp lệ!");
            }

            throw new Exception(
                $"API lỗi {(int)response.StatusCode}: {error}");
        }
    }
}