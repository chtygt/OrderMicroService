using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.Report.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReportStatus = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrderStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderCustomer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    TaxOffice = table.Column<string>(type: "text", nullable: true),
                    TaxNumber = table.Column<int>(type: "integer", nullable: false),
                    Adress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductCode = table.Column<string>(type: "text", nullable: true),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactReportDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderStatusReportId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderNumber = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactReportDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactReportDetails_ContactReports_OrderStatusReportId",
                        column: x => x.OrderStatusReportId,
                        principalTable: "ContactReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactReportDetails_OrderCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "OrderCustomer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderStatusReportDetailItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderDetailItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    Quantity = table.Column<double>(type: "double precision", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    OrderStatusReportDetailId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatusReportDetailItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderStatusReportDetailItem_ContactReportDetails_OrderStatu~",
                        column: x => x.OrderStatusReportDetailId,
                        principalTable: "ContactReportDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderStatusReportDetailItem_OrderProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "OrderProduct",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactReportDetails_CustomerId",
                table: "ContactReportDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactReportDetails_OrderStatusReportId",
                table: "ContactReportDetails",
                column: "OrderStatusReportId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatusReportDetailItem_OrderStatusReportDetailId",
                table: "OrderStatusReportDetailItem",
                column: "OrderStatusReportDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatusReportDetailItem_ProductId",
                table: "OrderStatusReportDetailItem",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderStatusReportDetailItem");

            migrationBuilder.DropTable(
                name: "ContactReportDetails");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "ContactReports");

            migrationBuilder.DropTable(
                name: "OrderCustomer");
        }
    }
}
