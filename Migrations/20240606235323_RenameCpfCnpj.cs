using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutologApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameCpfCnpj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cpf_Cnpj",
                table: "Users",
                newName: "CpfCnpj");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CpfCnpj",
                table: "Users",
                newName: "Cpf_Cnpj");
        }
    }
}
