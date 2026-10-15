//Ho va Ten: Tran Hoang Lin
//MSSV: 2124110134

using System;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Data
{
    // DbContext đại diện cho phiên làm việc với cơ sở dữ liệu SQL Server
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options)
            : base(options)
        {
        }

        // =========================================================
        // KHAI BÁO CÁC BẢNG DỮ LIỆU
        // =========================================================

        // Bảng Categories
        public DbSet<Category> Categories { get; set; }

        // Bảng Products
        public DbSet<Product> Products { get; set; }

        // Bảng Customers
        public DbSet<Customer> Customers { get; set; }

        // Bảng Users (Nhân viên / Tài khoản hệ thống)
        public DbSet<User> Users { get; set; }

        // Bảng Orders (Hóa đơn thanh toán)
        public DbSet<Order> Orders { get; set; }

        // Bảng OrderDetails (Chi tiết hóa đơn)
        public DbSet<OrderDetail> OrderDetails { get; set; }


        // =========================================================
        // DATA SEEDING
        // =========================================================
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =====================================================
            // CẤU HÌNH TỰ ĐỘNG TĂNG (IDENTITY / AUTO-INCREMENT)
            // =====================================================
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.CategoryId);
                entity.Property(c => c.CategoryId)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn(1, 1);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.ProductId)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn(1, 1);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);
                entity.Property(c => c.CustomerId)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn(1, 1);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserId)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn(1, 1);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.OrderId);
                entity.Property(o => o.OrderId)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn(1, 1);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(od => od.OrderDetailId);
                entity.Property(od => od.OrderDetailId)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn(1, 1);
            });

            // =====================================================
            // 1. DỮ LIỆU MẪU CHO CATEGORY
            // =====================================================

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Bánh kẹo & Đồ ăn vặt",
                    Description = "Snack, bánh quy, kẹo dẻo"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Nước giải khát & Trà",
                    Description = "Nước ngọt, nước khoáng, trà đóng chai"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Sữa & Sản phẩm từ sữa",
                    Description = "Sữa tươi, sữa chua, phô mai"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Mì gói & Thực phẩm ăn liền",
                    Description = "Mì ăn liền, phở khô, cháo gói"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Gia vị & Dầu ăn",
                    Description = "Nước mắm, tương ớt, sốt mayonnaise"
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Khô & Đồ ăn vặt mặn",
                    Description = "Khô gà, khô bò, mực khô, cá khô"
                },
                new Category
                {
                    CategoryId = 7,
                    CategoryName = "Hạt & Đồ ăn vặt dinh dưỡng",
                    Description = "Hạt điều, hạnh nhân, đậu phộng, hạt hướng dương"
                },
                new Category
                {
                    CategoryId = 8,
                    CategoryName = "Đồ ăn vặt cay",
                    Description = "Snack cay, bánh tráng cay, mì cay"
                },
                new Category
                {
                    CategoryId = 9,
                    CategoryName = "Bánh tráng",
                    Description = "Bánh tráng trộn, bánh tráng cuộn, bánh tráng sa tế"
                },
                new Category
                {
                    CategoryId = 10,
                    CategoryName = "Đồ ăn vặt ngọt",
                    Description = "Bánh ngọt, kẹo, thạch, socola"
                },
                new Category
                {
                    CategoryId = 11,
                    CategoryName = "Trái cây sấy",
                    Description = "Xoài sấy, mít sấy, chuối sấy, khoai lang sấy"
                },
                new Category
                {
                    CategoryId = 12,
                    CategoryName = "Đồ ăn vặt đông lạnh",
                    Description = "Xúc xích, cá viên, bò viên, nem chua"
                },
                new Category
                {
                    CategoryId = 13,
                    CategoryName = "Cà phê & Thức uống pha sẵn",
                    Description = "Cà phê lon, cà phê hòa tan, cacao"
                },
                new Category
                {
                    CategoryId = 14,
                    CategoryName = "Kem & Đồ ăn lạnh",
                    Description = "Kem que, kem hộp, pudding, thạch lạnh"
                },
                new Category
                {
                    CategoryId = 15,
                    CategoryName = "Combo đồ ăn vặt",
                    Description = "Combo snack, combo bánh kẹo, combo ăn vặt"
                }
            );

            // =====================================================
            // 2. DỮ LIỆU MẪU CHO PRODUCT
            // =====================================================

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Barcode = "893456789001",
                    ProductName = "Snack khoai tây vị phô mai",
                    Price = 15000,
                    StockQuantity = 100,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Barcode = "893456789002",
                    ProductName = "Bánh quy socola",
                    Price = 25000,
                    StockQuantity = 80,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 3,
                    Barcode = "893456789003",
                    ProductName = "Kẹo dẻo trái cây",
                    Price = 20000,
                    StockQuantity = 120,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 4,
                    Barcode = "893456789004",
                    ProductName = "Trà đào đóng chai",
                    Price = 12000,
                    StockQuantity = 100,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 5,
                    Barcode = "893456789005",
                    ProductName = "Nước ngọt Coca Cola",
                    Price = 10000,
                    StockQuantity = 150,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 6,
                    Barcode = "893456789006",
                    ProductName = "Sữa tươi có đường",
                    Price = 15000,
                    StockQuantity = 90,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 7,
                    Barcode = "893456789007",
                    ProductName = "Sữa chua vị dâu",
                    Price = 10000,
                    StockQuantity = 100,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 8,
                    Barcode = "893456789008",
                    ProductName = "Mì cay hải sản",
                    Price = 15000,
                    StockQuantity = 80,
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 9,
                    Barcode = "893456789009",
                    ProductName = "Phở bò ăn liền",
                    Price = 12000,
                    StockQuantity = 90,
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 10,
                    Barcode = "893456789010",
                    ProductName = "Khô gà lá chanh",
                    Price = 35000,
                    StockQuantity = 70,
                    CategoryId = 6
                },
                new Product
                {
                    ProductId = 11,
                    Barcode = "893456789011",
                    ProductName = "Khô bò miếng",
                    Price = 55000,
                    StockQuantity = 60,
                    CategoryId = 6
                },
                new Product
                {
                    ProductId = 12,
                    Barcode = "893456789012",
                    ProductName = "Hạt hướng dương",
                    Price = 20000,
                    StockQuantity = 80,
                    CategoryId = 7
                },
                new Product
                {
                    ProductId = 13,
                    Barcode = "893456789013",
                    ProductName = "Bánh tráng trộn đặc biệt",
                    Price = 25000,
                    StockQuantity = 100,
                    CategoryId = 9
                },
                new Product
                {
                    ProductId = 14,
                    Barcode = "893456789014",
                    ProductName = "Xoài sấy dẻo",
                    Price = 40000,
                    StockQuantity = 60,
                    CategoryId = 11
                },
                new Product
                {
                    ProductId = 15,
                    Barcode = "893456789015",
                    ProductName = "Combo Ăn Vặt Siêu Cay",
                    Price = 99000,
                    StockQuantity = 50,
                    CategoryId = 15
                }
            );

            // =====================================================
            // 3. DỮ LIỆU MẪU CHO CUSTOMER
            // =====================================================

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Nguyễn Văn An",
                    PhoneNumber = "0901234567",
                    MembershipRank = "Vàng",
                    RewardPoints = 150,
                    Address = "123 Nguyễn Huệ, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh"
                },
                new Customer
                {
                    CustomerId = 2,
                    CustomerName = "Trần Thị Bình",
                    PhoneNumber = "0912345678",
                    MembershipRank = "Bạc",
                    RewardPoints = 80,
                    Address = "45 Lê Văn Việt, Phường Hiệp Phú, Thành phố Thủ Đức, TP. Hồ Chí Minh"
                },
                new Customer
                {
                    CustomerId = 3,
                    CustomerName = "Lê Văn Cường",
                    PhoneNumber = "0983456789",
                    MembershipRank = "Chuẩn",
                    RewardPoints = 20,
                    Address = "78 Cách Mạng Tháng 8, Phường 6, Quận 3, TP. Hồ Chí Minh"
                },
                new Customer
                {
                    CustomerId = 4,
                    CustomerName = "Phạm Thị Dung",
                    PhoneNumber = "0904567891",
                    MembershipRank = "Vàng",
                    RewardPoints = 200,
                    Address = "12 Phan Xích Long, Phường 2, Quận Phú Nhuận, TP. Hồ Chí Minh"
                },
                new Customer
                {
                    CustomerId = 5,
                    CustomerName = "Hoàng Văn Đức",
                    PhoneNumber = "0915678902",
                    MembershipRank = "Bạc",
                    RewardPoints = 65,
                    Address = "56 Đinh Tiên Hoàng, Phường Đa Kao, Quận 1, TP. Hồ Chí Minh"
                },
                new Customer
                {
                    CustomerId = 6,
                    CustomerName = "Võ Thị Hà",
                    PhoneNumber = "0986789013",
                    MembershipRank = "Chuẩn",
                    RewardPoints = 15,
                    Address = "89 Nguyễn Văn Trỗi, Phường 8, Quận Phú Nhuận, TP. Hồ Chí Minh"
                },
                new Customer
                {
                    CustomerId = 7,
                    CustomerName = "Đặng Minh Hoàng",
                    PhoneNumber = "0907890124",
                    MembershipRank = "Vàng",
                    RewardPoints = 180,
                    Address = "234 Võ Văn Tần, Phường 5, Quận 3, TP. Hồ Chí Minh"
                },
                new Customer
                {
                    CustomerId = 8,
                    CustomerName = "Bùi Thị Lan",
                    PhoneNumber = "0918901235",
                    MembershipRank = "Bạc",
                    RewardPoints = 95,
                    Address = "345 Hai Bà Trưng, Phường 8, Quận 3, TP. Hồ Chí Minh"
                },
                new Customer
                {
                    CustomerId = 9,
                    CustomerName = "Đỗ Văn Nam",
                    PhoneNumber = "0989012346",
                    MembershipRank = "Chuẩn",
                    RewardPoints = 30,
                    Address = "67 Lý Tự Trọng, Phường Bến Thành, Quận 1, TP. Hồ Chí Minh"
                },
                new Customer
                {
                    CustomerId = 10,
                    CustomerName = "Nguyễn Thị Mai",
                    PhoneNumber = "0901123456",
                    MembershipRank = "Vàng",
                    RewardPoints = 250,
                    Address = "90 Pasteur, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh"
                },
                new Customer
                {
                    CustomerId = 11,
                    CustomerName = "Trần Văn Phúc",
                    PhoneNumber = "0912234567",
                    MembershipRank = "Bạc",
                    RewardPoints = 70,
                    Address = "15 Hoàng Văn Thụ, Phường 15, Quận Phú Nhuận, TP. Hồ Chí Minh"
                },
                new Customer
                {
                    CustomerId = 12,
                    CustomerName = "Lý Thị Quỳnh",
                    PhoneNumber = "0983345678",
                    MembershipRank = "Chuẩn",
                    RewardPoints = 25,
                    Address = "228 Cộng Hòa, Phường 12, Quận Tân Bình, TP. Hồ Chí Minh"
                },
                new Customer
                {
                    CustomerId = 13,
                    CustomerName = "Phan Minh Tâm",
                    PhoneNumber = "0904456789",
                    MembershipRank = "Vàng",
                    RewardPoints = 320,
                    Address = "510 Trường Chinh, Phường 13, Quận Tân Bình, TP. Hồ Chí Minh"
                },
                new Customer
                {
                    CustomerId = 14,
                    CustomerName = "Huỳnh Thị Thảo",
                    PhoneNumber = "0915567890",
                    MembershipRank = "Bạc",
                    RewardPoints = 110,
                    Address = "75 Quang Trung, Phường 10, Quận Gò Vấp, TP. Hồ Chí Minh"
                },
                new Customer
                {
                    CustomerId = 15,
                    CustomerName = "Đinh Văn Tuấn",
                    PhoneNumber = "0986678901",
                    MembershipRank = "Chuẩn",
                    RewardPoints = 40,
                    Address = "302 Nguyễn Oanh, Phường 17, Quận Gò Vấp, TP. Hồ Chí Minh"
                }
            );

            // =====================================================
            // 4. DỮ LIỆU MẪU CHO USER (NHÂN VIÊN / TÀI KHOẢN HỆ THỐNG)
            // =====================================================

            // =====================================================
            // 4. DỮ LIỆU MẪU CHO USER (NHÂN VIÊN / TÀI KHOẢN HỆ THỐNG)
            // =====================================================

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Username = "admin01",
                    Password = "123456",
                    FullName = "Nguyễn Quản Trị",
                    Email = "admin01@minisupermarket.vn",
                    Role = "Admin",
                    FunctionScope = "Toàn quyền toàn bộ hệ thống",
                    IsActive = true
                },
                new User
                {
                    UserId = 2,
                    Username = "admin02",
                    Password = "123456",
                    FullName = "Trần Giám Đốc",
                    Email = "admin02@minisupermarket.vn",
                    Role = "Admin",
                    FunctionScope = "Toàn quyền toàn bộ hệ thống",
                    IsActive = true
                },
                new User
                {
                    UserId = 3,
                    Username = "cashier01",
                    Password = "123456",
                    FullName = "Lê Thu Ngân",
                    Email = "cashier01@minisupermarket.vn",
                    Role = "Cashier",
                    FunctionScope = "Màn hình POS, Khách hàng thành viên",
                    IsActive = true
                },
                new User
                {
                    UserId = 4,
                    Username = "cashier02",
                    Password = "123456",
                    FullName = "Phạm Bán Hàng",
                    Email = "cashier02@minisupermarket.vn",
                    Role = "Cashier",
                    FunctionScope = "Màn hình POS, Khách hàng thành viên",
                    IsActive = true
                },
                new User
                {
                    UserId = 5,
                    Username = "cashier03",
                    Password = "123456",
                    FullName = "Hoàng Thu Ngân",
                    Email = "cashier03@minisupermarket.vn",
                    Role = "Cashier",
                    FunctionScope = "Màn hình POS, Khách hàng thành viên",
                    IsActive = true
                },
                new User
                {
                    UserId = 6,
                    Username = "cashier04",
                    Password = "123456",
                    FullName = "Vũ Thị Quầy",
                    Email = "cashier04@minisupermarket.vn",
                    Role = "Cashier",
                    FunctionScope = "Màn hình POS, Khách hàng thành viên",
                    IsActive = true
                },
                new User
                {
                    UserId = 7,
                    Username = "cashier05",
                    Password = "123456",
                    FullName = "Đỗ Bán Lẻ",
                    Email = "cashier05@minisupermarket.vn",
                    Role = "Cashier",
                    FunctionScope = "Màn hình POS, Khách hàng thành viên",
                    IsActive = true
                },
                new User
                {
                    UserId = 8,
                    Username = "ware01",
                    Password = "123456",
                    FullName = "Ngô Quản Kho",
                    Email = "ware01@minisupermarket.vn",
                    Role = "Warehouse",
                    FunctionScope = "Sản phẩm, Nhóm hàng, Nhập xuất kho",
                    IsActive = true
                },
                new User
                {
                    UserId = 9,
                    Username = "ware02",
                    Password = "123456",
                    FullName = "Bùi Kiểm Kê",
                    Email = "ware02@minisupermarket.vn",
                    Role = "Warehouse",
                    FunctionScope = "Sản phẩm, Nhóm hàng, Nhập xuất kho",
                    IsActive = true
                },
                new User
                {
                    UserId = 10,
                    Username = "ware03",
                    Password = "123456",
                    FullName = "Dương Thủ Kho",
                    Email = "ware03@minisupermarket.vn",
                    Role = "Warehouse",
                    FunctionScope = "Sản phẩm, Nhóm hàng, Nhập xuất kho",
                    IsActive = true
                },
                new User
                {
                    UserId = 11,
                    Username = "ware04",
                    Password = "123456",
                    FullName = "Lý Nhập Hàng",
                    Email = "ware04@minisupermarket.vn",
                    Role = "Warehouse",
                    FunctionScope = "Sản phẩm, Nhóm hàng, Nhập xuất kho",
                    IsActive = true
                },
                new User
                {
                    UserId = 12,
                    Username = "admin_backup",
                    Password = "123456",
                    FullName = "Đặng Hỗ Trợ",
                    Email = "admin.backup@minisupermarket.vn",
                    Role = "Admin",
                    FunctionScope = "Toàn quyền toàn bộ hệ thống",
                    IsActive = true
                },
                new User
                {
                    UserId = 13,
                    Username = "cashier06",
                    Password = "123456",
                    FullName = "Hồ Ca Chiều",
                    Email = "cashier06@minisupermarket.vn",
                    Role = "Cashier",
                    FunctionScope = "Màn hình POS, Khách hàng thành viên",
                    IsActive = true
                },
                new User
                {
                    UserId = 14,
                    Username = "ware05",
                    Password = "123456",
                    FullName = "Trương Vận Chuyển",
                    Email = "ware05@minisupermarket.vn",
                    Role = "Warehouse",
                    FunctionScope = "Sản phẩm, Nhóm hàng, Nhập xuất kho",
                    IsActive = true
                },
                new User
                {
                    UserId = 15,
                    Username = "supervisor",
                    Password = "123456",
                    FullName = "Mai Giám Sát",
                    Email = "supervisor@minisupermarket.vn",
                    Role = "Admin",
                    FunctionScope = "Toàn quyền toàn bộ hệ thống",
                    IsActive = true
                }
            );

            // =====================================================
            // 5. DỮ LIỆU MẪU CHO ORDER (15 HÓA ĐƠN BÁN ĐỒ ĂN VẶT)
            // =====================================================

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderId = 1,
                    OrderCode = "HD20261001-001",
                    CreatedDate = new DateTime(2026, 10, 1, 8, 30, 0),
                    CustomerId = 1,
                    CashierUsername = "cashier01",
                    TotalItems = 2,
                    FinalAmount = 30000m,
                    RewardPoints = 3
                },
                new Order
                {
                    OrderId = 2,
                    OrderCode = "HD20261001-002",
                    CreatedDate = new DateTime(2026, 10, 1, 9, 15, 0),
                    CustomerId = 2,
                    CashierUsername = "cashier01",
                    TotalItems = 1,
                    FinalAmount = 25000m,
                    RewardPoints = 2
                },
                new Order
                {
                    OrderId = 3,
                    OrderCode = "HD20261001-003",
                    CreatedDate = new DateTime(2026, 10, 1, 10, 0, 0),
                    CustomerId = 3,
                    CashierUsername = "cashier02",
                    TotalItems = 3,
                    FinalAmount = 60000m,
                    RewardPoints = 6
                },
                new Order
                {
                    OrderId = 4,
                    OrderCode = "HD20261001-004",
                    CreatedDate = new DateTime(2026, 10, 1, 11, 20, 0),
                    CustomerId = 4,
                    CashierUsername = "cashier02",
                    TotalItems = 2,
                    FinalAmount = 24000m,
                    RewardPoints = 2
                },
                new Order
                {
                    OrderId = 5,
                    OrderCode = "HD20261002-001",
                    CreatedDate = new DateTime(2026, 10, 2, 13, 45, 0),
                    CustomerId = 5,
                    CashierUsername = "cashier03",
                    TotalItems = 4,
                    FinalAmount = 40000m,
                    RewardPoints = 4
                },
                new Order
                {
                    OrderId = 6,
                    OrderCode = "HD20261002-002",
                    CreatedDate = new DateTime(2026, 10, 2, 14, 10, 0),
                    CustomerId = 6,
                    CashierUsername = "cashier03",
                    TotalItems = 2,
                    FinalAmount = 30000m,
                    RewardPoints = 3
                },
                new Order
                {
                    OrderId = 7,
                    OrderCode = "HD20261002-003",
                    CreatedDate = new DateTime(2026, 10, 2, 15, 30, 0),
                    CustomerId = 7,
                    CashierUsername = "cashier04",
                    TotalItems = 5,
                    FinalAmount = 50000m,
                    RewardPoints = 5
                },
                new Order
                {
                    OrderId = 8,
                    OrderCode = "HD20261003-001",
                    CreatedDate = new DateTime(2026, 10, 3, 16, 0, 0),
                    CustomerId = 8,
                    CashierUsername = "cashier04",
                    TotalItems = 2,
                    FinalAmount = 30000m,
                    RewardPoints = 3
                },
                new Order
                {
                    OrderId = 9,
                    OrderCode = "HD20261003-002",
                    CreatedDate = new DateTime(2026, 10, 3, 17, 25, 0),
                    CustomerId = 9,
                    CashierUsername = "cashier05",
                    TotalItems = 3,
                    FinalAmount = 36000m,
                    RewardPoints = 3
                },
                new Order
                {
                    OrderId = 10,
                    OrderCode = "HD20261003-003",
                    CreatedDate = new DateTime(2026, 10, 3, 18, 40, 0),
                    CustomerId = 10,
                    CashierUsername = "cashier05",
                    TotalItems = 2,
                    FinalAmount = 70000m,
                    RewardPoints = 7
                },
                new Order
                {
                    OrderId = 11,
                    OrderCode = "HD20261004-001",
                    CreatedDate = new DateTime(2026, 10, 4, 9, 5, 0),
                    CustomerId = 11,
                    CashierUsername = "cashier06",
                    TotalItems = 1,
                    FinalAmount = 55000m,
                    RewardPoints = 5
                },
                new Order
                {
                    OrderId = 12,
                    OrderCode = "HD20261004-002",
                    CreatedDate = new DateTime(2026, 10, 4, 10, 50, 0),
                    CustomerId = 12,
                    CashierUsername = "cashier06",
                    TotalItems = 2,
                    FinalAmount = 40000m,
                    RewardPoints = 4
                },
                new Order
                {
                    OrderId = 13,
                    OrderCode = "HD20261004-003",
                    CreatedDate = new DateTime(2026, 10, 4, 14, 15, 0),
                    CustomerId = 13,
                    CashierUsername = "cashier01",
                    TotalItems = 3,
                    FinalAmount = 75000m,
                    RewardPoints = 7
                },
                new Order
                {
                    OrderId = 14,
                    OrderCode = "HD20261005-001",
                    CreatedDate = new DateTime(2026, 10, 5, 16, 30, 0),
                    CustomerId = 14,
                    CashierUsername = "cashier02",
                    TotalItems = 2,
                    FinalAmount = 80000m,
                    RewardPoints = 8
                },
                new Order
                {
                    OrderId = 15,
                    OrderCode = "HD20261005-002",
                    CreatedDate = new DateTime(2026, 10, 5, 19, 0, 0),
                    CustomerId = 15,
                    CashierUsername = "cashier03",
                    TotalItems = 1,
                    FinalAmount = 99000m,
                    RewardPoints = 9
                }
            );

            // =====================================================
            // 6. DỮ LIỆU MẪU CHO ORDER DETAIL (15 CHI TIẾT HÓA ĐƠN)
            // =====================================================

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail
                {
                    OrderDetailId = 1,
                    OrderId = 1,
                    ProductId = 1, // Snack khoai tây vị phô mai
                    Quantity = 2,
                    UnitPrice = 15000m,
                    LineTotal = 30000m
                },
                new OrderDetail
                {
                    OrderDetailId = 2,
                    OrderId = 2,
                    ProductId = 2, // Bánh quy socola
                    Quantity = 1,
                    UnitPrice = 25000m,
                    LineTotal = 25000m
                },
                new OrderDetail
                {
                    OrderDetailId = 3,
                    OrderId = 3,
                    ProductId = 3, // Kẹo dẻo trái cây
                    Quantity = 3,
                    UnitPrice = 20000m,
                    LineTotal = 60000m
                },
                new OrderDetail
                {
                    OrderDetailId = 4,
                    OrderId = 4,
                    ProductId = 4, // Trà đào đóng chai
                    Quantity = 2,
                    UnitPrice = 12000m,
                    LineTotal = 24000m
                },
                new OrderDetail
                {
                    OrderDetailId = 5,
                    OrderId = 5,
                    ProductId = 5, // Nước ngọt Coca Cola
                    Quantity = 4,
                    UnitPrice = 10000m,
                    LineTotal = 40000m
                },
                new OrderDetail
                {
                    OrderDetailId = 6,
                    OrderId = 6,
                    ProductId = 6, // Sữa tươi có đường
                    Quantity = 2,
                    UnitPrice = 15000m,
                    LineTotal = 30000m
                },
                new OrderDetail
                {
                    OrderDetailId = 7,
                    OrderId = 7,
                    ProductId = 7, // Sữa chua vị dâu
                    Quantity = 5,
                    UnitPrice = 10000m,
                    LineTotal = 50000m
                },
                new OrderDetail
                {
                    OrderDetailId = 8,
                    OrderId = 8,
                    ProductId = 8, // Mì cay hải sản
                    Quantity = 2,
                    UnitPrice = 15000m,
                    LineTotal = 30000m
                },
                new OrderDetail
                {
                    OrderDetailId = 9,
                    OrderId = 9,
                    ProductId = 9, // Phở bò ăn liền
                    Quantity = 3,
                    UnitPrice = 12000m,
                    LineTotal = 36000m
                },
                new OrderDetail
                {
                    OrderDetailId = 10,
                    OrderId = 10,
                    ProductId = 10, // Khô gà lá chanh
                    Quantity = 2,
                    UnitPrice = 35000m,
                    LineTotal = 70000m
                },
                new OrderDetail
                {
                    OrderDetailId = 11,
                    OrderId = 11,
                    ProductId = 11, // Khô bò miếng
                    Quantity = 1,
                    UnitPrice = 55000m,
                    LineTotal = 55000m
                },
                new OrderDetail
                {
                    OrderDetailId = 12,
                    OrderId = 12,
                    ProductId = 12, // Hạt hướng dương
                    Quantity = 2,
                    UnitPrice = 20000m,
                    LineTotal = 40000m
                },
                new OrderDetail
                {
                    OrderDetailId = 13,
                    OrderId = 13,
                    ProductId = 13, // Bánh tráng trộn đặc biệt
                    Quantity = 3,
                    UnitPrice = 25000m,
                    LineTotal = 75000m
                },
                new OrderDetail
                {
                    OrderDetailId = 14,
                    OrderId = 14,
                    ProductId = 14, // Xoài sấy dẻo
                    Quantity = 2,
                    UnitPrice = 40000m,
                    LineTotal = 80000m
                },
                new OrderDetail
                {
                    OrderDetailId = 15,
                    OrderId = 15,
                    ProductId = 15, // Combo Ăn Vặt Siêu Cay
                    Quantity = 1,
                    UnitPrice = 99000m,
                    LineTotal = 99000m
                }
            );
        }
    }
}