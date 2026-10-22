/*
 * Ho ten sinh vien: Tran Hoang Lin
 * Ma sinh vien: 2124110134
 * Mo ta: Chuong trinh thuc hanh ADO.NET Buoi 5 (Tiet 1 & Tiet 4)
 * Ghi chu: Toan bo thong bao xuat ra man hinh da duoc chuyen sang TIENG VIET KHONG DAU
 * giup tranh 100% loi font chu tren Visual Studio Package Manager Console (PM>) va CMD.
 */
using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using MySqlConnector;

namespace ThucHanhAdoNet
{
    internal class Program
    {
        // Tu dong lay chuoi ket noi tu appsettings.json cua MiniSupermarket.API
        private static string GetConnectionString(out bool isMySql)
        {
            string apiSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "MiniSupermarket.API", "appsettings.json");
            string conn = "Server=127.0.0.1;Port=3306;Database=tranhoanglin_minisupermarketdb;User=root;Password=;SslMode=None;CharSet=utf8mb4;";

            try
            {
                if (File.Exists(apiSettingsPath))
                {
                    string json = File.ReadAllText(apiSettingsPath);
                    var match = Regex.Match(json, @"""DefaultConnection""\s*:\s*""([^""]+)""");
                    if (match.Success)
                    {
                        conn = match.Groups[1].Value;
                    }
                }
            }
            catch { }

            isMySql = conn.Contains("Port=3306") || conn.Contains("User=") || conn.Contains("3306");
            return conn;
        }

        private static DbConnection CreateConnection(string connString, bool isMySql)
        {
            if (isMySql)
            {
                return new MySqlConnection(connString);
            }
            return new SqlConnection(connString);
        }

        private static void AddParam(DbCommand cmd, string name, object value)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            cmd.Parameters.Add(p);
        }

        // Ham khu dau tieng Viet de hien thi khong bao gio bi loi font tren bat ky console nao
        public static string BoDau(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";
            string[] vietnameseSigns = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };

            for (int i = 1; i < vietnameseSigns.Length; i++)
            {
                for (int j = 0; j < vietnameseSigns[i].Length; j++)
                    str = str.Replace(vietnameseSigns[i][j], vietnameseSigns[0][i - 1]);
            }
            return str;
        }

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                ExecuteChoice(args[0]);
                return;
            }

            while (true)
            {
                try { Console.Clear(); } catch { }
                Console.WriteLine("=========================================================================");
                Console.WriteLine("      BUOI 5: ADO.NET NANG CAO, STORED PROCEDURE & GIAO DICH POS CHECKOUT");
                Console.WriteLine("=========================================================================");
                Console.WriteLine("1. [Tiet 1 - Bai 1] Dem tong so mat hang bang ExecuteScalar()");
                Console.WriteLine("2. [Tiet 1 - Bai 2] Cap nhat ton kho an toan bang ExecuteNonQuery() & Parameter");
                Console.WriteLine("3. [Tiet 1 - Bai 3] Duyet danh sach san pham bang DataReader");
                Console.WriteLine("4. [Tiet 4] Mo phong dieu khien giao dich ACID bang Transaction (Test Rollback)");
                Console.WriteLine("5. Chay tuan tu tat ca cac bai tap");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.WriteLine("=========================================================================");
                Console.Write("Vui long chon bai tap muon thuc thi (0 - 5): ");

                string? choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "0" || (string.IsNullOrWhiteSpace(choice) && Console.IsInputRedirected))
                {
                    Console.WriteLine("Ket thuc chuong trinh.");
                    break;
                }

                ExecuteChoice(choice?.Trim() ?? "5");

                if (Console.IsInputRedirected)
                {
                    break;
                }

                Console.WriteLine("\n-> Nhan phim bat ky de quay lai menu chinh...");
                try { Console.ReadKey(); } catch { }
            }
        }

        private static void ExecuteChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    ChayBaiTap1_ExecuteScalar();
                    break;
                case "2":
                    ChayBaiTap2_ExecuteNonQuery();
                    break;
                case "3":
                    ChayBaiTap3_SqlDataReader();
                    break;
                case "4":
                    ChayTiet4_SqlTransaction();
                    break;
                case "5":
                    ChayBaiTap1_ExecuteScalar();
                    Console.WriteLine("\n-------------------------------------------------------------------------\n");
                    ChayBaiTap2_ExecuteNonQuery();
                    Console.WriteLine("\n-------------------------------------------------------------------------\n");
                    ChayBaiTap3_SqlDataReader();
                    Console.WriteLine("\n-------------------------------------------------------------------------\n");
                    ChayTiet4_SqlTransaction();
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }
        }

        // =========================================================================
        // BAI TAP THUC HANH 1: Dem tong so mat hang bang ExecuteScalar()
        // =========================================================================
        public static void ChayBaiTap1_ExecuteScalar()
        {
            Console.WriteLine("=== BAI TAP 1: DEM TONG SO LUONG MAT HANG ===");

            string connStr = GetConnectionString(out bool isMySql);
            string dbType = isMySql ? "MySQL" : "SQL Server";

            using (DbConnection connection = CreateConnection(connStr, isMySql))
            {
                try
                {
                    string query = isMySql ? "SELECT COUNT(*) FROM products" : "SELECT COUNT(*) FROM Products";

                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        connection.Open();
                        Console.WriteLine($"-> Da ket noi thanh cong toi CSDL {dbType}!");

                        object? result = command.ExecuteScalar();
                        int totalCount = Convert.ToInt32(result);

                        Console.WriteLine($"-> Tong so mat hang hien co trong kho sieu thi: {totalCount} san pham.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[LOI TRUY VAN]: {BoDau(ex.Message)}");
                }
            }
        }

        // =========================================================================
        // BAI TAP THUC HANH 2: Cap nhat ton kho san pham bang ExecuteNonQuery() & Parameter
        // =========================================================================
        public static void ChayBaiTap2_ExecuteNonQuery()
        {
            Console.WriteLine("=== BAI TAP 2: CAP NHAT TON KHO AN TOAN VOI PARAMETER ===");

            int maSanPhamCanSua = 1;
            int soLuongTonKhoMoi = 250;

            string connStr = GetConnectionString(out bool isMySql);

            using (DbConnection connection = CreateConnection(connStr, isMySql))
            {
                try
                {
                    string updateSql = isMySql 
                        ? "UPDATE products SET StockQuantity = @Stock WHERE ProductId = @Id"
                        : "UPDATE Products SET StockQuantity = @Stock WHERE ProductId = @Id";

                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = updateSql;
                        AddParam(command, "@Stock", soLuongTonKhoMoi);
                        AddParam(command, "@Id", maSanPhamCanSua);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"-> THANH CONG: Da cap nhat ton kho cho San pham ID = {maSanPhamCanSua} thanh {soLuongTonKhoMoi} don vi.");
                            Console.WriteLine($"-> So dong du lieu bi anh huong: {rowsAffected} dong.");
                        }
                        else
                        {
                            Console.WriteLine($"-> CANH BAO: Khong tim thay san pham co ID = {maSanPhamCanSua} de cap nhat.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[LOI TRUY VAN]: {BoDau(ex.Message)}");
                }
            }
        }

        // =========================================================================
        // BAI TAP THUC HANH 3: Doc danh sach san pham bang DataReader
        // =========================================================================
        public static void ChayBaiTap3_SqlDataReader()
        {
            Console.WriteLine("=== BAI TAP 3: DUYET DANH SACH BANG DATAREADER ===");

            string connStr = GetConnectionString(out bool isMySql);
            string dbType = isMySql ? "MySQL" : "SQL Server";

            using (DbConnection connection = CreateConnection(connStr, isMySql))
            {
                try
                {
                    string query = isMySql
                        ? "SELECT ProductId, Barcode, ProductName, Price, StockQuantity FROM products ORDER BY ProductId ASC"
                        : "SELECT ProductId, Barcode, ProductName, Price, StockQuantity FROM Products ORDER BY ProductId ASC";

                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        connection.Open();

                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("-----------------------------------------------------------------------------------------");
                            Console.WriteLine(string.Format("{0,-6} | {1,-14} | {2,-35} | {3,12} | {4,8}",
                                "MA SP", "MA VACH", "TEN SAN PHAM", "DON GIA", "TON KHO"));
                            Console.WriteLine("-----------------------------------------------------------------------------------------");

                            int stt = 0;
                            while (reader.Read())
                            {
                                stt++;
                                int id = Convert.ToInt32(reader["ProductId"]);
                                string barcode = reader["Barcode"].ToString() ?? "";
                                string rawName = reader["ProductName"].ToString() ?? "";
                                string name = BoDau(rawName); // Khu dau tieng Viet tranh loi font
                                decimal price = Convert.ToDecimal(reader["Price"]);
                                int stock = Convert.ToInt32(reader["StockQuantity"]);

                                Console.WriteLine(string.Format("{0,-6} | {1,-14} | {2,-35} | {3,12:N0} d | {4,8}",
                                    id, barcode, name, price, stock));
                            }

                            Console.WriteLine("-----------------------------------------------------------------------------------------");
                            Console.WriteLine($"-> Tong cong da doc thanh cong: {stt} mat hang tu {dbType}.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[LOI TRUY VAN]: {BoDau(ex.Message)}");
                }
            }
        }

        // =========================================================================
        // TIET 4: THU NGHIEM DIEU KHIEN TRANSACTION & KIEM CHUNG ROLLBACK
        // =========================================================================
        public static void ChayTiet4_SqlTransaction()
        {
            Console.WriteLine("=== THU NGHIEM DIEU KHIEN TRANSACTION ===");

            string connStr = GetConnectionString(out bool isMySql);

            using (DbConnection connection = CreateConnection(connStr, isMySql))
            {
                connection.Open();

                int stockBefore = 0;
                string checkSql = isMySql ? "SELECT StockQuantity FROM products WHERE ProductId = 1" : "SELECT StockQuantity FROM Products WHERE ProductId = 1";
                using (DbCommand cmdGet = connection.CreateCommand())
                {
                    cmdGet.CommandText = checkSql;
                    stockBefore = Convert.ToInt32(cmdGet.ExecuteScalar());
                }
                Console.WriteLine($"-> [Kiem chung] Ton kho hien tai cua SP ID = 1 truoc giao dich: {stockBefore}");

                DbTransaction transaction = connection.BeginTransaction();

                try
                {
                    Console.WriteLine("-> Bat dau phien giao dich...");

                    string sqlStep1 = isMySql 
                        ? "UPDATE products SET StockQuantity = StockQuantity - @Qty WHERE ProductId = @Id"
                        : "UPDATE Products SET StockQuantity = StockQuantity - @Qty WHERE ProductId = @Id";

                    using (DbCommand cmd1 = connection.CreateCommand())
                    {
                        cmd1.Transaction = transaction;
                        cmd1.CommandText = sqlStep1;
                        AddParam(cmd1, "@Qty", 5);
                        AddParam(cmd1, "@Id", 1);
                        int r1 = cmd1.ExecuteNonQuery();
                        Console.WriteLine($"-> Buoc 1: Da tru ton kho SP 1 (So dong tac dong: {r1}).");
                    }

                    Console.WriteLine("-> Buoc 2: Chuan bi thuc thi thao tac loi gia lap...");

                    bool isInventoryShortage = true;
                    if (isInventoryShortage)
                    {
                        throw new InvalidOperationException("Mat hang thu hai da het ton kho thuc te!");
                    }

                    transaction.Commit();
                    Console.WriteLine("-> GIAO DICH COMMIT THANH CONG!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[PHAT SINH LOI]: {BoDau(ex.Message)}");
                    transaction.Rollback();
                    Console.WriteLine("-> [HE THONG]: Da kich hoat transaction.Rollback()!");
                    Console.WriteLine("-> Toan bo thay doi cua Buoc 1 da duoc hoan tra, ton kho SP 1 khong bi tru!");

                    using (DbCommand cmdCheck = connection.CreateCommand())
                    {
                        cmdCheck.CommandText = checkSql;
                        int stockAfter = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        Console.WriteLine($"-> [Doi soat] Ton kho SP 1 sau Rollback: {stockAfter} (Bang dung so luong ban dau {stockBefore})");
                    }
                }
            }
        }
    }
}
