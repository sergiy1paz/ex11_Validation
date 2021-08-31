using Microsoft.EntityFrameworkCore.Migrations;

namespace ex11_Validation.Migrations
{
    public partial class ManagerHasLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Managers");
        }
    }
}
