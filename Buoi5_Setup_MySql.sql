USE tranhoanglin_minisupermarketdb;

DROP PROCEDURE IF EXISTS sp_GetRevenueByCashier;
DELIMITER //
CREATE PROCEDURE sp_GetRevenueByCashier()
BEGIN
    SELECT 
        CashierUsername,
        COUNT(OrderId) AS TotalOrders,
        SUM(FinalAmount) AS TotalRevenue,
        SUM(RewardPoints) AS TotalPointsAwarded
    FROM orders
    GROUP BY CashierUsername
    ORDER BY TotalRevenue DESC;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_GetRevenueByDateRange;
DELIMITER //
CREATE PROCEDURE sp_GetRevenueByDateRange(IN p_FromDate DATETIME, IN p_ToDate DATETIME)
BEGIN
    SELECT 
        CashierUsername,
        COUNT(OrderId) AS TotalOrders,
        SUM(FinalAmount) AS TotalRevenue
    FROM orders
    WHERE CreatedDate >= p_FromDate AND CreatedDate <= p_ToDate
    GROUP BY CashierUsername
    ORDER BY TotalRevenue DESC;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_GetTop5SellingProducts;
DELIMITER //
CREATE PROCEDURE sp_GetTop5SellingProducts()
BEGIN
    SELECT 
        p.ProductId,
        p.Barcode,
        p.ProductName,
        SUM(od.Quantity) AS TotalSold,
        SUM(od.LineTotal) AS TotalSalesRevenue
    FROM orderdetails od
    INNER JOIN products p ON od.ProductId = p.ProductId
    GROUP BY p.ProductId, p.Barcode, p.ProductName
    ORDER BY TotalSold DESC
    LIMIT 5;
END //
DELIMITER ;
