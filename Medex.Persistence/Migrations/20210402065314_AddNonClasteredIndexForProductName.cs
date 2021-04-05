using Microsoft.EntityFrameworkCore.Migrations;

namespace Medex.Persistence.Migrations
{
    public partial class AddNonClasteredIndexForProductName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
          sql: @"CREATE NONCLUSTERED INDEX [NIX_Products_Name] ON [dbo].[Products]
(
    [Name] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
",
          suppressTransaction: true);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
           sql: "DROP INDEX [NIX_Products_Name] ON [dbo].[Products]",
           suppressTransaction: true);
        }
    }
}
