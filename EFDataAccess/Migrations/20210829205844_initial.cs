using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UseCaseLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Actor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UseCaseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseCaseLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Warranty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUseCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UseCaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUseCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserUseCases_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(1093), null, false, null, "Asus" },
                    { 2, new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(1684), null, false, null, "Alienware" },
                    { 3, new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(1700), null, false, null, "Lenovo" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "FirstName", "IsDeleted", "LastName", "ModifiedAt", "Password", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(7753), null, "admin@email.com", "Admin", false, "Adminovic", null, "sifra123", "adminuser" },
                    { 2, new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(9043), null, "micko@email.com", "Micko", false, "Mickovic", null, "sifra123", "mickuser" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CPU", "CreatedAt", "DeletedAt", "FormFactor", "GPU", "ImageUrl", "IsDeleted", "ModifiedAt", "Name", "OS", "PSU", "Price", "Quantity", "RAM", "Storage", "Warranty" },
                values: new object[,]
                {
                    { 1, 1, "AMD Ryzen 7 3700X", new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(2616), null, "Tower", "NVIDIA GeForce GTX 1650 4GB", "image1", false, null, "ASUS ROG Strix GL10DH Gaming Desktop", "Windows 10 Pro", "500W", 949.99m, 10, "8GB DDR4 2666MHz", "1TB PCIe NVMe M.2 SSD + 1TB 7200RPM HDD", 36 },
                    { 2, 1, "Intel Core i5-10400F", new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(5374), null, "Tower", "NVIDIA GeForce GTX 1660 SUPER 6GB", "image2", false, null, "ASUS ROG Strix G15CK Gaming Desktop", "Windows 10 Pro", "500W", 999.99m, 10, "8GB DDR4 2666MHz", "512GB PCIe NVMe M.2 SSD", 36 },
                    { 3, 1, "Intel Core i7-9700K", new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(5470), null, "Tower", "NVIDIA GeForce RTX 2070 8GB", "image3", false, null, "ASUS ROG Strix GL12 Gaming Desktop", "Windows 10 Pro", "750W", 1799.99m, 10, "16GB DDR4 2666MHz", "1TB HyperDrive M.2 SSD", 36 },
                    { 4, 2, "AMD Ryzen 5 5600X", new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(5473), null, "MidTower", "AMD Radeon RX 6800 XT 16GB", "image4", false, null, "ALIENWARE AURORA R10 Gaming Desktop", "Windows 10 Home", "750W", 1989.99m, 10, "8GB DDR4 3200MHz", "1TB M.2 PCIe NVMe SSD + 1TB 7200RPM HDD", 36 },
                    { 5, 2, "Intel Core i5 11400F", new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(5476), null, "MidTower", "NVIDIA GeForce GTX 1650 SUPER 4GB", "image5", false, null, "ALIENWARE AURORA R12 Gaming Desktop", "Windows 10 Home", "550W", 1129.99m, 10, "8GB DDR4 3200MHz", "1TB 7200RPM HDD", 36 },
                    { 6, 2, "AMD Ryzen 7 5800", new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(5549), null, "MidTower", "NVIDIA GeForce RTX 3060Ti 8GB", "image6", false, null, "ALIENWARE AURORA R11 Gaming Desktop", "Windows 10 Home", "750W", 1799.99m, 10, "16GB DDR4 3200MHz", "512GB M.2 PCIe NVMe SSD", 36 },
                    { 7, 3, "Intel Core i7-10700", new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(5552), null, "Tower", "NVIDIA GeForce GTX 1660 Super 6GB", "image7", false, null, "LENOVO Legion Tower 5i", "Windows 10 Home", "550W", 1214.99m, 10, "8GB DDR4 2933MHz", "256GB PCIe SSD + 1TB 7200RPM HDD", 36 },
                    { 8, 3, "Intel Core i7-11700F", new DateTime(2021, 8, 29, 20, 58, 44, 242, DateTimeKind.Utc).AddTicks(5554), null, "Tower", "NVIDIA GeForce RTX 3070 8GB", "image8", false, null, "LENOVO Legion Tower 6i", "Windows 10 Home", "750W", 1783.99m, 10, "16GB DDR4 3200MHz", "512GB PCIe SSD + 1TB 7200RPM HDD", 36 }
                });

            migrationBuilder.InsertData(
                table: "UserUseCases",
                columns: new[] { "Id", "UseCaseId", "UserId" },
                values: new object[,]
                {
                    { 15, 15, 1 },
                    { 16, 16, 1 },
                    { 17, 17, 1 },
                    { 18, 18, 1 },
                    { 22, 4, 2 },
                    { 20, 2, 2 },
                    { 21, 3, 2 },
                    { 14, 14, 1 },
                    { 23, 5, 2 },
                    { 19, 1, 2 },
                    { 13, 13, 1 },
                    { 9, 9, 1 },
                    { 11, 11, 1 },
                    { 10, 10, 1 },
                    { 24, 6, 2 },
                    { 8, 8, 1 },
                    { 7, 7, 1 },
                    { 6, 6, 1 },
                    { 5, 5, 1 },
                    { 4, 4, 1 },
                    { 3, 3, 1 },
                    { 2, 2, 1 },
                    { 1, 1, 1 },
                    { 12, 12, 1 },
                    { 25, 18, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserUseCases_UserId",
                table: "UserUseCases",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "UseCaseLogs");

            migrationBuilder.DropTable(
                name: "UserUseCases");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
