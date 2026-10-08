using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class chay_lan_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FunctionScope = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "FullName", "FunctionScope", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "Nguyễn Quản Trị", "Toàn quyền toàn bộ hệ thống", "123456", "Admin", "admin01" },
                    { 2, "Trần Giám Đốc", "Toàn quyền toàn bộ hệ thống", "123456", "Admin", "admin02" },
                    { 3, "Lê Thu Ngân", "Màn hình POS, Khách hàng thành viên", "123456", "Cashier", "cashier01" },
                    { 4, "Phạm Bán Hàng", "Màn hình POS, Khách hàng thành viên", "123456", "Cashier", "cashier02" },
                    { 5, "Hoàng Thu Ngân", "Màn hình POS, Khách hàng thành viên", "123456", "Cashier", "cashier03" },
                    { 6, "Vũ Thị Quầy", "Màn hình POS, Khách hàng thành viên", "123456", "Cashier", "cashier04" },
                    { 7, "Đỗ Bán Lẻ", "Màn hình POS, Khách hàng thành viên", "123456", "Cashier", "cashier05" },
                    { 8, "Ngô Quản Kho", "Sản phẩm, Nhóm hàng, Nhập xuất kho", "123456", "Warehouse", "ware01" },
                    { 9, "Bùi Kiểm Kê", "Sản phẩm, Nhóm hàng, Nhập xuất kho", "123456", "Warehouse", "ware02" },
                    { 10, "Dương Thủ Kho", "Sản phẩm, Nhóm hàng, Nhập xuất kho", "123456", "Warehouse", "ware03" },
                    { 11, "Lý Nhập Hàng", "Sản phẩm, Nhóm hàng, Nhập xuất kho", "123456", "Warehouse", "ware04" },
                    { 12, "Đặng Hỗ Trợ", "Toàn quyền toàn bộ hệ thống", "123456", "Admin", "admin_backup" },
                    { 13, "Hồ Ca Chiều", "Màn hình POS, Khách hàng thành viên", "123456", "Cashier", "cashier06" },
                    { 14, "Trương Vận Chuyển", "Sản phẩm, Nhóm hàng, Nhập xuất kho", "123456", "Warehouse", "ware05" },
                    { 15, "Mai Giám Sát", "Toàn quyền toàn bộ hệ thống", "123456", "Admin", "supervisor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
