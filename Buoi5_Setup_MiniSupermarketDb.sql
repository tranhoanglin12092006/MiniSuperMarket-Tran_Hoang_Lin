-- =========================================================================
-- HỌ VÀ TÊN: Tran Hoang Lin
-- MSSV: 2124110134
-- KỊCH BẢN TẠO CSDL VÀ DỮ LIỆU MẪU BUỔI 5: ADO.NET NÂNG CAO, STORED PROCEDURE
-- =========================================================================

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'MiniSupermarketDb')
BEGIN
    CREATE DATABASE [MiniSupermarketDb];
END
GO

USE [MiniSupermarketDb];
GO

-- 1. BẢNG CATEGORIES
IF OBJECT_ID('OrderDetails', 'U') IS NOT NULL DROP TABLE OrderDetails;
IF OBJECT_ID('Orders', 'U') IS NOT NULL DROP TABLE Orders;
IF OBJECT_ID('Products', 'U') IS NOT NULL DROP TABLE Products;
IF OBJECT_ID('Categories', 'U') IS NOT NULL DROP TABLE Categories;
IF OBJECT_ID('Customers', 'U') IS NOT NULL DROP TABLE Customers;
IF OBJECT_ID('Users', 'U') IS NOT NULL DROP TABLE Users;
GO

CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) NULL
);
GO

CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    Barcode VARCHAR(50) NOT NULL UNIQUE,
    ProductName NVARCHAR(150) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    StockQuantity INT NOT NULL,
    CategoryId INT NOT NULL,
    CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId) ON DELETE CASCADE
);
GO

CREATE TABLE Customers (
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName NVARCHAR(100) NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,
    MembershipRank NVARCHAR(50) NOT NULL DEFAULT N'Chuẩn',
    RewardPoints INT NOT NULL DEFAULT 0,
    Address NVARCHAR(200) NULL
);
GO

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Email VARCHAR(150) NOT NULL,
    Role VARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    FunctionScope NVARCHAR(255) NOT NULL DEFAULT N'All'
);
GO

CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    OrderCode VARCHAR(50) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    CashierUsername VARCHAR(50) NOT NULL,
    CustomerId INT NOT NULL,
    TotalItems INT NOT NULL,
    FinalAmount DECIMAL(18,2) NOT NULL,
    RewardPoints INT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId) ON DELETE CASCADE
);
GO

CREATE TABLE OrderDetails (
    OrderDetailId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    LineTotal DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_OrderDetails_Orders FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE,
    CONSTRAINT FK_OrderDetails_Products FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);
GO

-- 2. DỮ LIỆU MẪU CATEGORIES
SET IDENTITY_INSERT Categories ON;
INSERT INTO Categories (CategoryId, CategoryName, Description) VALUES
(1, N'Bánh kẹo & Snack', N'Các loại đồ ăn vặt đóng gói'),
(2, N'Đồ uống giải khát', N'Nước ngọt, nước khoáng, trà lon'),
(3, N'Sữa & Chế phẩm sữa', N'Sữa tươi, sữa chua ăn, phô mai'),
(4, N'Mì gói & Đồ ăn liền', N'Mì tôm, cháo ăn liền, xúc xích');
SET IDENTITY_INSERT Categories OFF;
GO

-- 3. DỮ LIỆU MẪU PRODUCTS (ĐỦ 20 SẢN PHẨM KHỚP CHUẨN BUỔI 5)
SET IDENTITY_INSERT Products ON;
INSERT INTO Products (ProductId, Barcode, ProductName, Price, StockQuantity, CategoryId) VALUES
(1, '893456789001', N'Snack Khoai Tây O''Star Gói 60g', 12500, 250, 1),
(2, '893456789002', N'Bánh Quy Bơ Danisa Hộp Thiếc 454g', 135000, 40, 1),
(3, '893456789003', N'Kẹo Dẻo Chupa Chups Hương Trái Cây', 15000, 120, 1),
(4, '893456789004', N'Bánh Chocopie Orion Hộp 12 Cái', 54000, 60, 1),
(5, '893456789005', N'Nước Ngọt Coca Cola Lon 320ml', 10000, 320, 2),
(6, '893456789006', N'Nước Ngọt Pepsi Không Calo Lon 320ml', 10000, 280, 2),
(7, '893456789007', N'Trà Xanh Không Độ Chai 455ml', 12000, 180, 2),
(8, '893456789008', N'Nước Tăng Lực Redbull Lon 250ml', 15000, 140, 2),
(9, '893456789009', N'Sữa Tươi Tiệt Trùng Vinamilk 100% 1L', 36000, 85, 3),
(10, '893456789010', N'Sữa Chua Ăn Vinamilk Có Đường Lốc 4 Hộp', 28000, 95, 3),
(11, '893456789011', N'Phô Mai Con Bò Cười Hộp 8 Miếng', 42000, 70, 3),
(12, '893456789012', N'Mì Hảo Hảo Tôm Chua Cay Gói 75g', 4500, 500, 4),
(13, '893456789013', N'Mì Trộn Omachi Sốt Bò Xào Trùng Khánh', 9500, 220, 4),
(14, '893456789014', N'Mì Cay Samyang Hàn Quốc Gói 140g', 32000, 110, 4),
(15, '893456789015', N'Xúc Xích Tiệt Trùng CP Heo Cao Cấp Gói 4 Cây', 18000, 150, 4),
(16, '893456789016', N'Khăn Giấy Ướt Lotte Eco Gói 80 Tờ', 22000, 90, 1),
(17, '893456789017', N'Cà Phê Sữa Highland Lon 235ml', 16000, 130, 2),
(18, '893456789018', N'Sữa Hạt Óc Chó TH True Nut Hộp 180ml', 14000, 115, 3),
(19, '893456789019', N'Bánh Gạo One One Vị Bò Nướng Gói 150g', 27000, 80, 1),
(20, '893456789020', N'Nước Suối Aquafina Chai 500ml', 6000, 400, 2);
SET IDENTITY_INSERT Products OFF;
GO

-- 4. DỮ LIỆU MẪU CUSTOMERS
SET IDENTITY_INSERT Customers ON;
INSERT INTO Customers (CustomerId, CustomerName, PhoneNumber, MembershipRank, RewardPoints, Address) VALUES
(1, N'Nguyễn Văn An', '0901234567', N'Vàng', 120, N'123 Lê Duẩn, Q.1, TP.HCM'),
(2, N'Trần Thị Bích', '0912345678', N'Bạc', 65, N'456 Hai Bà Trưng, Q.3, TP.HCM'),
(3, N'Lê Hoàng Cường', '0987654321', N'Kim Cương', 550, N'789 Nguyễn Huệ, Q.1, TP.HCM'),
(4, N'Phạm Mỹ Duyên', '0933445566', N'Chuẩn', 20, N'321 Cách Mạng Tháng 8, Q.10, TP.HCM'),
(5, N'Hoàng Tuấn Em', '0977889900', N'Bạc', 75, N'654 Võ Văn Kiệt, Q.5, TP.HCM'),
(15, N'Khách hàng vãng lai', '0000000000', N'Chuẩn', 0, N'Khách mua lẻ trực tiếp tại quầy');
SET IDENTITY_INSERT Customers OFF;
GO

-- 5. DỮ LIỆU MẪU USERS
SET IDENTITY_INSERT Users ON;
INSERT INTO Users (UserId, Username, Password, FullName, Email, Role, IsActive, FunctionScope) VALUES
(1, 'admin01', '$2a$11$w1pQzU3x7j1B4W3g0aL0beU04H3eWzGvE9wL7s3v7Xh9Wl1z1bCqW', N'Nguyễn Quản Trị', 'admin01@supermarket.vn', 'Admin', 1, 'All'),
(2, 'cashier01', '$2a$11$w1pQzU3x7j1B4W3g0aL0beU04H3eWzGvE9wL7s3v7Xh9Wl1z1bCqW', N'Lê Thu Ngân', 'cashier01@supermarket.vn', 'Cashier', 1, 'POS,Customer'),
(3, 'cashier02', '$2a$11$w1pQzU3x7j1B4W3g0aL0beU04H3eWzGvE9wL7s3v7Xh9Wl1z1bCqW', N'Phạm Bán Hàng', 'cashier02@supermarket.vn', 'Cashier', 1, 'POS,Customer'),
(4, 'cashier03', '$2a$11$w1pQzU3x7j1B4W3g0aL0beU04H3eWzGvE9wL7s3v7Xh9Wl1z1bCqW', N'Hoàng Thu Ngân', 'cashier03@supermarket.vn', 'Cashier', 1, 'POS,Customer'),
(5, 'cashier04', '$2a$11$w1pQzU3x7j1B4W3g0aL0beU04H3eWzGvE9wL7s3v7Xh9Wl1z1bCqW', N'Vũ Thị Quầy', 'cashier04@supermarket.vn', 'Cashier', 1, 'POS,Customer'),
(6, 'cashier05', '$2a$11$w1pQzU3x7j1B4W3g0aL0beU04H3eWzGvE9wL7s3v7Xh9Wl1z1bCqW', N'Đỗ Bán Lẻ', 'cashier05@supermarket.vn', 'Cashier', 1, 'POS,Customer');
SET IDENTITY_INSERT Users OFF;
GO

-- 6. DỮ LIỆU MẪU 15 HÓA ĐƠN KHỚP CHÍNH XÁC KẾT QUẢ TIẾT 3:
-- cashier05: 3 đơn -> TotalRevenue = 1,328,000, TotalPointsAwarded = 132
-- cashier03: 2 đơn -> TotalRevenue = 1,435,000, TotalPointsAwarded = 143
-- cashier01: 4 đơn -> TotalRevenue = 1,322,000, TotalPointsAwarded = 131
-- cashier04: 3 đơn -> TotalRevenue =   484,000, TotalPointsAwarded =  48
-- cashier02: 3 đơn -> TotalRevenue =   253,000, TotalPointsAwarded =  24
-- TỔNG CỘNG: 15 hóa đơn | 4,822,000.00 VND

SET IDENTITY_INSERT Orders ON;
INSERT INTO Orders (OrderId, OrderCode, CreatedDate, CashierUsername, CustomerId, TotalItems, FinalAmount, RewardPoints) VALUES
-- cashier05: 3 đơn (500k + 450k + 378k = 1,328,000đ | 50 + 45 + 37 = 132đ)
(1,  'HD-20260830-01', '2026-08-30 08:30:00', 'cashier05', 1, 6,  500000.00, 50),
(2,  'HD-20260830-02', '2026-08-30 09:15:00', 'cashier05', 2, 5,  450000.00, 45),
(3,  'HD-20260830-03', '2026-08-30 10:00:00', 'cashier05', 3, 4,  378000.00, 37),

-- cashier03: 2 đơn (735k + 700k = 1,435,000đ | 73 + 70 = 143đ)
(4,  'HD-20260830-04', '2026-08-30 10:45:00', 'cashier03', 1, 8,  735000.00, 73),
(5,  'HD-20260830-05', '2026-08-30 11:30:00', 'cashier03', 4, 7,  700000.00, 70),

-- cashier01: 4 đơn (350k + 400k + 272k + 300k = 1,322,000đ | 35 + 40 + 27 + 29 = 131đ)
(6,  'HD-20260830-06', '2026-08-30 13:00:00', 'cashier01', 2, 4,  350000.00, 35),
(7,  'HD-20260830-07', '2026-08-30 14:10:00', 'cashier01', 3, 5,  400000.00, 40),
(8,  'HD-20260830-08', '2026-08-30 15:20:00', 'cashier01', 5, 3,  272000.00, 27),
(9,  'HD-20260830-09', '2026-08-30 16:30:00', 'cashier01', 1, 4,  300000.00, 29),

-- cashier04: 3 đơn (180k + 154k + 150k = 484,000đ | 18 + 15 + 15 = 48đ)
(10, 'HD-20260830-10', '2026-08-30 17:15:00', 'cashier04', 2, 2,  180000.00, 18),
(11, 'HD-20260830-11', '2026-08-30 18:00:00', 'cashier04', 4, 3,  154000.00, 15),
(12, 'HD-20260830-12', '2026-08-30 18:45:00', 'cashier04', 5, 2,  150000.00, 15),

-- cashier02: 3 đơn (85k + 90k + 78k = 253,000đ | 8 + 9 + 7 = 24đ)
(13, 'HD-20260830-13', '2026-08-30 19:30:00', 'cashier02', 1, 3,   85000.00,  8),
(14, 'HD-20260830-14', '2026-08-30 20:10:00', 'cashier02', 3, 2,   90000.00,  9),
(15, 'HD-20260830-15', '2026-08-30 21:00:00', 'cashier02', 15, 2,  78000.00,  7);
SET IDENTITY_INSERT Orders OFF;
GO

-- 7. CHI TIẾT HÓA ĐƠN MẪU ORDERDETAILS
SET IDENTITY_INSERT OrderDetails ON;
INSERT INTO OrderDetails (OrderDetailId, OrderId, ProductId, Quantity, UnitPrice, LineTotal) VALUES
(1,  1, 2,  3, 135000, 405000),
(2,  1, 1,  4,  12500,  50000),
(3,  1, 5,  4,  10000,  40000),
(4,  2, 4,  5,  54000, 270000),
(5,  2, 9,  5,  36000, 180000),
(6,  3, 2,  2, 135000, 270000),
(7,  3, 4,  2,  54000, 108000),
(8,  4, 2,  5, 135000, 675000),
(9,  4, 5,  6,  10000,  60000),
(10, 5, 4, 10,  54000, 540000),
(11, 5, 9,  4,  36000, 144000),
(12, 6, 2,  2, 135000, 270000),
(13, 7, 2,  2, 135000, 270000),
(14, 8, 4,  4,  54000, 216000),
(15, 9, 2,  2, 135000, 270000);
SET IDENTITY_INSERT OrderDetails OFF;
GO

-- =========================================================================
-- 8. TẠO CÁC STORED PROCEDURE BUỔI 5
-- =========================================================================

-- 8.1. sp_GetRevenueByCashier (Tiết 3)
IF OBJECT_ID('sp_GetRevenueByCashier', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetRevenueByCashier;
GO

CREATE PROCEDURE sp_GetRevenueByCashier
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CashierUsername,
        COUNT(OrderId) AS TotalOrders,
        SUM(FinalAmount) AS TotalRevenue,
        SUM(RewardPoints) AS TotalPointsAwarded
    FROM Orders
    GROUP BY CashierUsername
    ORDER BY TotalRevenue DESC;
END
GO

-- 8.2. sp_GetRevenueByDateRange (Bài tập 3.1)
IF OBJECT_ID('sp_GetRevenueByDateRange', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetRevenueByDateRange;
GO

CREATE PROCEDURE sp_GetRevenueByDateRange
    @FromDate DATETIME,
    @ToDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CashierUsername,
        COUNT(OrderId) AS TotalOrders,
        SUM(FinalAmount) AS TotalRevenue
    FROM Orders
    WHERE CreatedDate >= @FromDate AND CreatedDate <= @ToDate
    GROUP BY CashierUsername
    ORDER BY TotalRevenue DESC;
END
GO

-- 8.3. sp_GetTop5SellingProducts (Bài tập 3.2)
IF OBJECT_ID('sp_GetTop5SellingProducts', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetTop5SellingProducts;
GO

CREATE PROCEDURE sp_GetTop5SellingProducts
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 5
        p.ProductId,
        p.Barcode,
        p.ProductName,
        SUM(od.Quantity) AS TotalSold,
        SUM(od.LineTotal) AS TotalSalesRevenue
    FROM OrderDetails od
    INNER JOIN Products p ON od.ProductId = p.ProductId
    GROUP BY p.ProductId, p.Barcode, p.ProductName
    ORDER BY TotalSold DESC;
END
GO
