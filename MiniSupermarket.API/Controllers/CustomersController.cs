
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;
using Microsoft.AspNetCore.Authorization;


namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        // Dependency Injection
        public CustomersController(SupermarketDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // 1. GET: Lấy toàn bộ danh sách khách hàng
        // GET /api/customers
        // =========================================================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _context.Customers
                .AsNoTracking()
                .ToListAsync();

            return Ok(customers);
        }


        // =========================================================
        // BÀI TẬP MỞ RỘNG 6.1: GET /api/customers/paged
        // Phân trang danh sách khách hàng thân thiết, sắp xếp giảm dần theo RewardPoints
        // =========================================================
        [AllowAnonymous]
        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedCustomers(
            [FromQuery] string? keyword,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5)
        {
            try
            {
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1 || pageSize > 50) pageSize = 5;

                var query = _context.Customers
                    .AsNoTracking()
                    .OrderByDescending(c => c.RewardPoints)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    string search = keyword.Trim().ToLower();
                    query = query.Where(c => c.CustomerName.ToLower().Contains(search)
                                          || c.PhoneNumber.Contains(search));
                }

                int totalItems = await query.CountAsync();
                int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

                var items = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(c => new CustomerItemDto
                    {
                        CustomerId = c.CustomerId,
                        CustomerName = c.CustomerName,
                        PhoneNumber = c.PhoneNumber,
                        Address = c.Address,
                        RewardPoints = c.RewardPoints,
                        MembershipRank = c.MembershipRank
                    })
                    .ToListAsync();

                var response = new PagedResult<CustomerItemDto>
                {
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalItems = totalItems,
                    TotalPages = totalPages,
                    Items = items
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi phân trang khách hàng: " + ex.Message });
            }
        }

        // =========================================================
        // 2. GET: Lấy khách hàng theo ID
        // GET /api/customers/{id}
        // =========================================================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng!"
                });
            }

            return Ok(customer);
        }

        // =========================================================
        // 2.5. GET: Lấy khách hàng theo số điện thoại
        // GET /api/customers/phone/{phone}
        // =========================================================
        [HttpGet("phone/{phone}")]
        public async Task<IActionResult> GetByPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return BadRequest(new { message = "Số điện thoại không được để trống!" });
            }

            var customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.PhoneNumber == phone.Trim());

            if (customer == null)
            {
                return NotFound(new { message = "Không tìm thấy khách hàng với số điện thoại này!" });
            }

            return Ok(customer);
        }

        // =========================================================
        // 3. SEARCH: Tìm kiếm theo tên hoặc số điện thoại
        // GET /api/customers/search?keyword=Nguyen
        // =========================================================
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new
                {
                    message = "Vui lòng nhập từ khóa tìm kiếm!"
                });
            }

            var result = await _context.Customers
                .AsNoTracking()
                .Where(c =>
                    c.CustomerName.Contains(keyword) ||
                    c.PhoneNumber.Contains(keyword))
                .ToListAsync();

            return Ok(result);
        }


        // =========================================================
        // 4. POST: Thêm khách hàng mới
        // POST /api/customers
        // =========================================================
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Kiểm tra số điện thoại đã tồn tại chưa
            var existingCustomer = await _context.Customers
                .FirstOrDefaultAsync(c =>
                    c.PhoneNumber == newCustomer.PhoneNumber);

            if (existingCustomer != null)
            {
                return Conflict(new
                {
                    message = "Số điện thoại này đã được đăng ký!"
                });
            }

            // Giá trị mặc định
            newCustomer.RewardPoints = 0;
            newCustomer.MembershipRank = "Chuẩn";

            _context.Customers.Add(newCustomer);

            // Lưu vào SQL Server
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = newCustomer.CustomerId },
                newCustomer
            );
        }


        // =========================================================
        // 5. PUT: Cập nhật thông tin khách hàng
        // PUT /api/customers/{id}
        // =========================================================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] Customer updateCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng cần cập nhật!"
                });
            }

            // Kiểm tra số điện thoại có bị trùng với khách hàng khác
            var duplicatePhone = await _context.Customers
                .AnyAsync(c =>
                    c.PhoneNumber == updateCustomer.PhoneNumber &&
                    c.CustomerId != id);

            if (duplicatePhone)
            {
                return Conflict(new
                {
                    message = "Số điện thoại này đã được sử dụng bởi khách hàng khác!"
                });
            }

            // Cập nhật thông tin
            customer.CustomerName = updateCustomer.CustomerName;
            customer.PhoneNumber = updateCustomer.PhoneNumber;
            customer.Address = updateCustomer.Address;

            // Cập nhật hạng thành viên
            customer.MembershipRank = updateCustomer.MembershipRank;

            // Cập nhật điểm tích lũy
            customer.RewardPoints = updateCustomer.RewardPoints;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        // =========================================================
        // 6. DELETE: Xóa khách hàng
        // DELETE /api/customers/{id}
        // =========================================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng cần xóa!"
                });
            }

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
