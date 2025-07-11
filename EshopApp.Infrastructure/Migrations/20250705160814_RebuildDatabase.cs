using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EshopApp.Infrastructure.Migrations;


    /// <summary>
    /// Migration for renaming the 'Title' column to 'Name' in the 'Categories' table and vice versa.
    /// </summary>
    public partial class RebuildDatabase : Migration
    {
        /// <summary>
        /// Applies the migration by renaming the 'Title' column to 'Name' in the 'Categories' table.
        /// </summary>
        /// <param name="migrationBuilder">The builder used to construct migration operations.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Categories",
                newName: "Name");
        }

        /// <summary>
        /// Reverts the migration by renaming the 'Name' column back to 'Title' in the 'Categories' table.
        /// </summary>
        /// <param name="migrationBuilder">The builder used to construct migration operations.</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "Title");
        }
    }

