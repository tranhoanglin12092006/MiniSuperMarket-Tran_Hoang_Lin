using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class Chay_lan_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Description",
                value: "Nước ngọt, nước khoáng, trà đóng chai");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Description",
                value: "Nước mắm, tương ớt, sốt mayonnaise");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 6, "Khô & Đồ ăn vặt mặn", "Khô gà, khô bò, mực khô, cá khô" },
                    { 7, "Hạt & Đồ ăn vặt dinh dưỡng", "Hạt điều, hạnh nhân, đậu phộng, hạt hướng dương" },
                    { 8, "Đồ ăn vặt cay", "Snack cay, bánh tráng cay, mì cay" },
                    { 9, "Bánh tráng", "Bánh tráng trộn, bánh tráng cuộn, bánh tráng sa tế" },
                    { 10, "Đồ ăn vặt ngọt", "Bánh ngọt, kẹo, thạch, socola" },
                    { 11, "Trái cây sấy", "Xoài sấy, mít sấy, chuối sấy, khoai lang sấy" },
                    { 12, "Đồ ăn vặt đông lạnh", "Xúc xích, cá viên, bò viên, nem chua" },
                    { 13, "Cà phê & Thức uống pha sẵn", "Cà phê lon, cà phê hòa tan, cacao" },
                    { 14, "Kem & Đồ ăn lạnh", "Kem que, kem hộp, pudding, thạch lạnh" },
                    { 15, "Combo đồ ăn vặt", "Combo snack, combo bánh kẹo, combo ăn vặt" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "CustomerName", "PhoneNumber" },
                values: new object[] { "Nguyễn Văn An", "0901234567" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "CustomerName", "PhoneNumber", "RewardPoints" },
                values: new object[] { "Trần Thị Bình", "0912345678", 80 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "CustomerName", "PhoneNumber", "RewardPoints" },
                values: new object[] { "Lê Văn Cường", "0983456789", 20 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[,]
                {
                    { 4, null, "Phạm Thị Dung", "Vàng", "0904567891", 200 },
                    { 5, null, "Hoàng Văn Đức", "Bạc", "0915678902", 65 },
                    { 6, null, "Võ Thị Hà", "Chuẩn", "0986789013", 15 },
                    { 7, null, "Đặng Minh Hoàng", "Vàng", "0907890124", 180 },
                    { 8, null, "Bùi Thị Lan", "Bạc", "0918901235", 95 },
                    { 9, null, "Đỗ Văn Nam", "Chuẩn", "0989012346", 30 },
                    { 10, null, "Nguyễn Thị Mai", "Vàng", "0901123456", 250 },
                    { 11, null, "Trần Văn Phúc", "Bạc", "0912234567", 70 },
                    { 12, null, "Lý Thị Quỳnh", "Chuẩn", "0983345678", 25 },
                    { 13, null, "Phan Minh Tâm", "Vàng", "0904456789", 320 },
                    { 14, null, "Huỳnh Thị Thảo", "Bạc", "0915567890", 110 },
                    { 15, null, "Đinh Văn Tuấn", "Chuẩn", "0986678901", 40 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "893456789001", 1, 15000m, "Snack khoai tây vị phô mai", 100 },
                    { 2, "893456789002", 1, 25000m, "Bánh quy socola", 80 },
                    { 3, "893456789003", 1, 20000m, "Kẹo dẻo trái cây", 120 },
                    { 4, "893456789004", 2, 12000m, "Trà đào đóng chai", 100 },
                    { 5, "893456789005", 2, 10000m, "Nước ngọt Coca Cola", 150 },
                    { 6, "893456789006", 3, 15000m, "Sữa tươi có đường", 90 },
                    { 7, "893456789007", 3, 10000m, "Sữa chua vị dâu", 100 },
                    { 8, "893456789008", 4, 15000m, "Mì cay hải sản", 80 },
                    { 9, "893456789009", 4, 12000m, "Phở bò ăn liền", 90 },
                    { 10, "893456789010", 6, 35000m, "Khô gà lá chanh", 70 },
                    { 11, "893456789011", 6, 55000m, "Khô bò miếng", 60 },
                    { 12, "893456789012", 7, 20000m, "Hạt hướng dương", 80 },
                    { 13, "893456789013", 9, 25000m, "Bánh tráng trộn đặc biệt", 100 },
                    { 14, "893456789014", 11, 40000m, "Xoài sấy dẻo", 60 },
                    { 15, "893456789015", 15, 99000m, "Combo Ăn Vặt Siêu Cay", 50 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Description",
                value: "Nước ngọt, nước khoáng, trà");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "Description",
                value: "Nước mắm, hạt nêm, dầu thực vật");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "CustomerName", "PhoneNumber" },
                values: new object[] { "Nguyễn Văn A", "0901122334" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "CustomerName", "PhoneNumber", "RewardPoints" },
                values: new object[] { "Trần Thị B", "0918877665", 50 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "CustomerName", "PhoneNumber", "RewardPoints" },
                values: new object[] { "Lê Văn C", "0983344556", 10 });
        }
    }
}
