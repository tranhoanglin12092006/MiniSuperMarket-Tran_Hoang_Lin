/*
 * Ho ten sinh vien: Tran Hoang Lin
 * Ma sinh vien: 2124110134
 * Ngay tao: 22/10/2026
 * Mo ta: API Thanh toan POS da bang duoc bao ve boi DbTransaction (ACID) - Tuong thich ca MySQL & SQL Server
 */
using Microsoft.AspNetCore.Mvc;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;
using System.Data.Common;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CheckoutController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection") 
                ?? "Server=127.0.0.1;Port=3306;Database=tranhoanglin_minisupermarketdb;User=root;Password=;SslMode=None;CharSet=utf8mb4;";
        }

        // =========================================================================
        // POST: api/checkout
        // Chuc nang: Thanh toan hoa don, tru ton kho va tich diem trong 1 Transaction
        // =========================================================================
        [HttpPost]
        public IActionResult ProcessCheckout([FromBody] CheckoutRequestDto request)
        {
            if (request == null || request.Items == null || request.Items.Count == 0)
            {
                return BadRequest(new { message = "Giỏ hàng rỗng, không thể tiến hành thanh toán!" });
            }

            if (string.IsNullOrWhiteSpace(request.CashierUsername))
            {
                return BadRequest(new { message = "Thiếu thông tin tài khoản thu ngân lập hóa đơn!" });
            }

            string connectionString = GetConnectionString();
            bool isMySql = AdoDbHelper.IsMySql(connectionString);

            using (DbConnection connection = AdoDbHelper.CreateConnection(connectionString))
            {
                connection.Open();

                // KHOI TAO TRANSACTION
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    decimal finalAmount = request.Items.Sum(i => i.Quantity * i.UnitPrice);
                    int totalItems = request.Items.Sum(i => i.Quantity);
                    int rewardPoints = (int)(finalAmount / 10000);
                    string orderCode = $"HD-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}";

                    // =====================================================================
                    // BƯỚC 1: TAO HOA DON TONG THE
                    // =====================================================================
                    string insertOrderSql = isMySql
                        ? @"INSERT INTO orders (OrderCode, CreatedDate, CashierUsername, CustomerId, TotalItems, FinalAmount, RewardPoints)
                            VALUES (@OrderCode, NOW(), @CashierUsername, @CustomerId, @TotalItems, @FinalAmount, @RewardPoints);
                            SELECT LAST_INSERT_ID();"
                        : @"INSERT INTO Orders (OrderCode, CreatedDate, CashierUsername, CustomerId, TotalItems, FinalAmount, RewardPoints)
                            OUTPUT INSERTED.OrderId
                            VALUES (@OrderCode, GETDATE(), @CashierUsername, @CustomerId, @TotalItems, @FinalAmount, @RewardPoints)";

                    int orderId = 0;
                    using (DbCommand cmdOrder = connection.CreateCommand())
                    {
                        cmdOrder.Transaction = transaction;
                        cmdOrder.CommandText = insertOrderSql;
                        AdoDbHelper.AddParam(cmdOrder, "@OrderCode", orderCode);
                        AdoDbHelper.AddParam(cmdOrder, "@CashierUsername", request.CashierUsername.Trim());
                        AdoDbHelper.AddParam(cmdOrder, "@CustomerId", request.CustomerId > 0 ? request.CustomerId : 1);
                        AdoDbHelper.AddParam(cmdOrder, "@TotalItems", totalItems);
                        AdoDbHelper.AddParam(cmdOrder, "@FinalAmount", finalAmount);
                        AdoDbHelper.AddParam(cmdOrder, "@RewardPoints", rewardPoints);

                        orderId = Convert.ToInt32(cmdOrder.ExecuteScalar());
                    }

                    // =====================================================================
                    // BƯỚC 2 & 3: KIEM TRA TON KHO, LUU CHI TIET VA TRU TON KHO
                    // =====================================================================
                    foreach (var item in request.Items)
                    {
                        string checkStockSql = "SELECT StockQuantity, ProductName FROM products WHERE ProductId = @ProductId";
                        int currentStock = 0;
                        string productName = string.Empty;

                        using (DbCommand cmdCheck = connection.CreateCommand())
                        {
                            cmdCheck.Transaction = transaction;
                            cmdCheck.CommandText = checkStockSql;
                            AdoDbHelper.AddParam(cmdCheck, "@ProductId", item.ProductId);

                            using (DbDataReader reader = cmdCheck.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    throw new InvalidOperationException($"Không tìm thấy sản phẩm có ID: {item.ProductId}");
                                }
                                currentStock = Convert.ToInt32(reader["StockQuantity"]);
                                productName = reader["ProductName"].ToString() ?? string.Empty;
                            }
                        }

                        if (currentStock < item.Quantity)
                        {
                            throw new InvalidOperationException(
                                $"Sản phẩm '{productName}' (ID: {item.ProductId}) không đủ tồn kho! " +
                                $"(Tồn kho thực tế: {currentStock}, Số lượng yêu cầu mua: {item.Quantity})");
                        }

                        string insertDetailSql = @"
                            INSERT INTO orderdetails (OrderId, ProductId, Quantity, UnitPrice, LineTotal)
                            VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice, @LineTotal)";

                        using (DbCommand cmdDetail = connection.CreateCommand())
                        {
                            cmdDetail.Transaction = transaction;
                            cmdDetail.CommandText = insertDetailSql;
                            AdoDbHelper.AddParam(cmdDetail, "@OrderId", orderId);
                            AdoDbHelper.AddParam(cmdDetail, "@ProductId", item.ProductId);
                            AdoDbHelper.AddParam(cmdDetail, "@Quantity", item.Quantity);
                            AdoDbHelper.AddParam(cmdDetail, "@UnitPrice", item.UnitPrice);
                            AdoDbHelper.AddParam(cmdDetail, "@LineTotal", item.Quantity * item.UnitPrice);
                            cmdDetail.ExecuteNonQuery();
                        }

                        string updateStockSql = @"
                            UPDATE products 
                            SET StockQuantity = StockQuantity - @Qty 
                            WHERE ProductId = @ProductId";

                        using (DbCommand cmdStock = connection.CreateCommand())
                        {
                            cmdStock.Transaction = transaction;
                            cmdStock.CommandText = updateStockSql;
                            AdoDbHelper.AddParam(cmdStock, "@Qty", item.Quantity);
                            AdoDbHelper.AddParam(cmdStock, "@ProductId", item.ProductId);
                            cmdStock.ExecuteNonQuery();
                        }
                    }

                    // =====================================================================
                    // BƯỚC 4: CONG DIEM TICH LUY CHO KHACH HANG
                    // =====================================================================
                    int customerId = request.CustomerId > 0 ? request.CustomerId : 1;
                    if (rewardPoints > 0)
                    {
                        string updatePointsSql = @"
                            UPDATE customers 
                            SET RewardPoints = RewardPoints + @Points 
                            WHERE CustomerId = @CustomerId";

                        using (DbCommand cmdCustomer = connection.CreateCommand())
                        {
                            cmdCustomer.Transaction = transaction;
                            cmdCustomer.CommandText = updatePointsSql;
                            AdoDbHelper.AddParam(cmdCustomer, "@Points", rewardPoints);
                            AdoDbHelper.AddParam(cmdCustomer, "@CustomerId", customerId);
                            cmdCustomer.ExecuteNonQuery();
                        }
                    }

                    // XAC NHAN LUU VINH VIEN
                    transaction.Commit();

                    return Ok(new
                    {
                        success = true,
                        message = "Thanh toán hóa đơn POS thành công!",
                        orderId = orderId,
                        orderCode = orderCode,
                        totalItems = totalItems,
                        finalAmount = finalAmount,
                        rewardPointsAdded = rewardPoints
                    });
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {
                        return StatusCode(500, new
                        {
                            success = false,
                            message = "Lỗi nghiêm trọng khi thực thi Rollback: " + rollbackEx.Message
                        });
                    }

                    return BadRequest(new
                    {
                        success = false,
                        message = "Giao dịch thanh toán bị hủy và đã được Rollback an toàn!",
                        errorDetail = ex.Message
                    });
                }
            }
        }

        // =========================================================================
        // BÀI TẬP MỞ RỘNG (TIẾT 5): HỦY ĐƠN HÀNG VÀ HOÀN TRẢ TỒN KHO
        // =========================================================================
        // DELETE: api/checkout/cancel/{orderId}
        [HttpDelete("cancel/{orderId}")]
        public IActionResult CancelOrder(int orderId)
        {
            string connectionString = GetConnectionString();

            using (DbConnection connection = AdoDbHelper.CreateConnection(connectionString))
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    string getOrderSql = "SELECT CustomerId, RewardPoints FROM orders WHERE OrderId = @OrderId";
                    int customerId = 0;
                    int pointsToDeduct = 0;

                    using (DbCommand cmdGet = connection.CreateCommand())
                    {
                        cmdGet.Transaction = transaction;
                        cmdGet.CommandText = getOrderSql;
                        AdoDbHelper.AddParam(cmdGet, "@OrderId", orderId);
                        using (DbDataReader reader = cmdGet.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                throw new InvalidOperationException($"Không tìm thấy hóa đơn ID = {orderId} để hủy!");
                            }
                            customerId = Convert.ToInt32(reader["CustomerId"]);
                            pointsToDeduct = Convert.ToInt32(reader["RewardPoints"]);
                        }
                    }

                    var itemsToRestore = new List<(int ProductId, int Quantity)>();
                    string getDetailsSql = "SELECT ProductId, Quantity FROM orderdetails WHERE OrderId = @OrderId";

                    using (DbCommand cmdDetails = connection.CreateCommand())
                    {
                        cmdDetails.Transaction = transaction;
                        cmdDetails.CommandText = getDetailsSql;
                        AdoDbHelper.AddParam(cmdDetails, "@OrderId", orderId);
                        using (DbDataReader reader = cmdDetails.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                itemsToRestore.Add((
                                    Convert.ToInt32(reader["ProductId"]),
                                    Convert.ToInt32(reader["Quantity"])
                                ));
                            }
                        }
                    }

                    foreach (var item in itemsToRestore)
                    {
                        string restoreStockSql = @"
                            UPDATE products 
                            SET StockQuantity = StockQuantity + @Qty 
                            WHERE ProductId = @ProductId";

                        using (DbCommand cmdRestore = connection.CreateCommand())
                        {
                            cmdRestore.Transaction = transaction;
                            cmdRestore.CommandText = restoreStockSql;
                            AdoDbHelper.AddParam(cmdRestore, "@Qty", item.Quantity);
                            AdoDbHelper.AddParam(cmdRestore, "@ProductId", item.ProductId);
                            cmdRestore.ExecuteNonQuery();
                        }
                    }

                    if (pointsToDeduct > 0)
                    {
                        string deductPointsSql = @"
                            UPDATE customers 
                            SET RewardPoints = CASE 
                                WHEN RewardPoints >= @Pts THEN RewardPoints - @Pts 
                                ELSE 0 
                            END 
                            WHERE CustomerId = @CustomerId";

                        using (DbCommand cmdDeduct = connection.CreateCommand())
                        {
                            cmdDeduct.Transaction = transaction;
                            cmdDeduct.CommandText = deductPointsSql;
                            AdoDbHelper.AddParam(cmdDeduct, "@Pts", pointsToDeduct);
                            AdoDbHelper.AddParam(cmdDeduct, "@CustomerId", customerId);
                            cmdDeduct.ExecuteNonQuery();
                        }
                    }

                    string deleteDetailsSql = "DELETE FROM orderdetails WHERE OrderId = @OrderId";
                    using (DbCommand cmdDelDetails = connection.CreateCommand())
                    {
                        cmdDelDetails.Transaction = transaction;
                        cmdDelText(cmdDelDetails, deleteDetailsSql, orderId);
                    }

                    string deleteOrderSql = "DELETE FROM orders WHERE OrderId = @OrderId";
                    using (DbCommand cmdDelOrder = connection.CreateCommand())
                    {
                        cmdDelOrder.Transaction = transaction;
                        cmdDelText(cmdDelOrder, deleteOrderSql, orderId);
                    }

                    transaction.Commit();

                    return Ok(new
                    {
                        success = true,
                        message = $"Đã hủy thành công hóa đơn #{orderId} và hoàn trả toàn bộ tồn kho vào CSDL!"
                    });
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch { }

                    return BadRequest(new
                    {
                        success = false,
                        message = "Hủy hóa đơn thất bại, giao dịch đã được Rollback!",
                        errorDetail = ex.Message
                    });
                }
            }
        }

        private static void cmdDelText(DbCommand cmd, string sql, int orderId)
        {
            cmd.CommandText = sql;
            AdoDbHelper.AddParam(cmd, "@OrderId", orderId);
            cmd.ExecuteNonQuery();
        }
    }
}
