using Microsoft.EntityFrameworkCore.Migrations;

namespace Medex.Persistence.Migrations
{
    public partial class updateRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete Users Where Login != 'admin'");
            migrationBuilder.Sql($"Update Users set UserRole = {1}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
