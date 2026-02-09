using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutologApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBrandColumnOfCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Brand", table: "Cars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Cars",
                type: "text",
                nullable: false,
                defaultValue: ""
            );
        }
    }
}
