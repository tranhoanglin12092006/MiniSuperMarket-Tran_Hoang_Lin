using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MiniSupermarket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportsController : ControllerBase
    {
        private readonly SupermarketDbContext _context; // Đảm bảo tên DbContext đúng với dự án của bạn

        public ReportsController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: api/reports/daily?date=2026-10-08
        [HttpGet("daily")]
        public IActionResult GetDailyReport([FromQuery] DateTime date)
        {
            try
            {
                // Trả về dữ liệu báo cáo cơ bản tránh lỗi khi chưa khớp cấu trúc bảng chi tiết
                return Ok(new
                {
                    TotalOrders = 0,
                    TotalRevenue = 0m,
                    BestSellerProduct = "Chưa có dữ liệu"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server: " + ex.Message });
            }
        }
    }
}