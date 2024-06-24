using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutologApi.Migrations
{
    /// <inheritdoc />
    public partial class AddObservationClientInBudget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ObservationClient",
                table: "Budgets",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObservationClient",
                table: "Budgets");
        }
    }
}
