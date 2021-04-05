using Microsoft.EntityFrameworkCore.Migrations;

namespace Medex.Persistence.Migrations
{
    public partial class FullTextIndexForProductName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
       sql: "CREATE FULLTEXT CATALOG fullTextCatalog AS DEFAULT;",
       suppressTransaction: true);

            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT INDEX ON Products(Name) KEY INDEX PK_Products;",
                suppressTransaction: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
               sql: "DROP FULLTEXT INDEX ON Products;",
               suppressTransaction: true);
        }
    }
}
