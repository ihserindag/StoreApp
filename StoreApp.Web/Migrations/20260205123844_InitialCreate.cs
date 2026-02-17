using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Telefon", "Güzel Telefon", "Samsung S25", 1000m },
                    { 2, "Telefon", "Güzel Telefon", "Samsung S24", 2000m },
                    { 3, "Telefon", "Güzel Telefon", "Samsung S23", 3000m },
                    { 4, "Telefon", "Güzel Telefon", "Samsung S22", 4000m },
                    { 5, "Telefon", "Güzel Telefon", "Samsung S21", 5000m },
                    { 6, "Telefon", "Güzel Telefon", "Samsung S20", 6000m },
                    { 7, "Telefon", "Güzel Telefon", "Samsung S10", 7000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
