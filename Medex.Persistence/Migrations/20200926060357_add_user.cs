using Microsoft.EntityFrameworkCore.Migrations;
using System.Security.Cryptography;
using System.Text;

namespace Medex.Persistence.Migrations
{
    public partial class adduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var alg = SHA256.Create();
            var password = Encoding.UTF8.GetBytes("111qqqAAA");
            var hashPassword = Encoding.UTF8.GetString((alg.ComputeHash(password)));
            migrationBuilder.InsertData("Users",
                new[] { "FirstName", "LastName", "MiddleName", "Email", "Password", "Login", "Phone", "IsConfirmed", "IsEmailSent" },
                new object[] { "Администратор", "", "", "mklarin@mail.ru", hashPassword, "admin", "Phone", true, true }
     );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
