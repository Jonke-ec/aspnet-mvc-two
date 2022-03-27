using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Profiles",
                type: "char(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(5)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Profiles",
                type: "char(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(6)");
        }
    }
}
