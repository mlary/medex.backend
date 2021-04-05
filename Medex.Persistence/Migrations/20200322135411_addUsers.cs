using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Medex.Persistence.Migrations
{
    public partial class addUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Users",
                new[] { "FirstName", "LastName", "MiddleName", "Email", "Password", "Login", "Phone", "IsConfirmed", "IsEmailSent", "CreatedOn" },
                new object[] { "Администратор", "", "", "mklarin@mail.ru", "Password", "Login", "Phone", true, true, DateTime.Now }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
