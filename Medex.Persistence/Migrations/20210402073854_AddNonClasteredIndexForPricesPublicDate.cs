using Microsoft.EntityFrameworkCore.Migrations;

namespace Medex.Persistence.Migrations
{
    public partial class AddNonClasteredIndexForPricesPublicDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(sql: @"CREATE NONCLUSTERED INDEX [NIX-Prices_PublicDate] ON [dbo].[Prices]
(
	[PublicDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]",
suppressTransaction: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(sql: @"DROP INDEX [NIX-Prices_PublicDate] ON [dbo].[Prices]",
suppressTransaction: true);
        }
    }
}
