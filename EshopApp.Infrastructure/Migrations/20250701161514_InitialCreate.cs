using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopApp.Infrastructure.Migrations;

    /// <summary>
    /// Represents the initial database migration for creating core tables and relationships.
    /// </summary>
    public partial class InitialCreate : Migration
{
    /// <summary>
    /// Builds the operations that will apply the migration (create tables, relationships, and indexes).
    /// </summary>
    /// <param name="migrationBuilder">The builder used to construct migration operations.</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Customers",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                FullName = table.Column<string>(type: "TEXT", nullable: false),
                PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                Email = table.Column<string>(type: "TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Customers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "StoreInfos",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                StoreName = table.Column<string>(type: "TEXT", nullable: false),
                Address = table.Column<string>(type: "TEXT", nullable: false),
                PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                LogoUrl = table.Column<string>(type: "TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StoreInfos", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Products",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                Name = table.Column<string>(type: "TEXT", nullable: false),
                Price = table.Column<decimal>(type: "TEXT", nullable: false),
                Stock = table.Column<int>(type: "INTEGER", nullable: false),
                Description = table.Column<string>(type: "TEXT", nullable: false),
                CategoryId = table.Column<Guid>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
                table.ForeignKey(
                    name: "FK_Products_Categories_CategoryId",
                    column: x => x.CategoryId,
                    principalTable: "Categories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Invoices",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                IssuedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                CustomerId = table.Column<Guid>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Invoices", x => x.Id);
                table.ForeignKey(
                    name: "FK_Invoices_Customers_CustomerId",
                    column: x => x.CustomerId,
                    principalTable: "Customers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "InvoiceItems",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                InvoiceId = table.Column<Guid>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_InvoiceItems", x => x.Id);
                table.ForeignKey(
                    name: "FK_InvoiceItems_Invoices_InvoiceId",
                    column: x => x.InvoiceId,
                    principalTable: "Invoices",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_InvoiceItems_Products_ProductId",
                    column: x => x.ProductId,
                    principalTable: "Products",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_InvoiceItems_InvoiceId",
            table: "InvoiceItems",
            column: "InvoiceId");

        migrationBuilder.CreateIndex(
            name: "IX_InvoiceItems_ProductId",
            table: "InvoiceItems",
            column: "ProductId");

        migrationBuilder.CreateIndex(
            name: "IX_Invoices_CustomerId",
            table: "Invoices",
            column: "CustomerId");

        migrationBuilder.CreateIndex(
            name: "IX_Products_CategoryId",
            table: "Products",
            column: "CategoryId");
    }

    /// <summary>
    /// Builds the operations that will revert the migration (drop tables and relationships).
    /// </summary>
    /// <param name="migrationBuilder">The builder used to construct migration operations.</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "InvoiceItems");

        migrationBuilder.DropTable(
            name: "StoreInfos");

        migrationBuilder.DropTable(
            name: "Invoices");

        migrationBuilder.DropTable(
            name: "Products");

        migrationBuilder.DropTable(
            name: "Customers");

        migrationBuilder.DropTable(
            name: "Categories");
    }
}
    
