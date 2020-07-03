using Microsoft.EntityFrameworkCore.Migrations;

namespace Gears.Migrations
{
    public partial class PopulateAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO[dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES(N'3a1aebbc-9b70-4dc3-b518-832359d6f876', N'Amrmonbay', N'AMRMONBAY', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEKPF1wIivf677C0tmNhjr0ju1vMWTQYAytCtgJ828Sh7u6lzbkc6FQK8VyUebgFQ7Q==', N'RE4CTU43D5EU37R4YLV37B4477XJJSL2', N'58b7b15d-91f9-4df4-a2df-6954855d783e', NULL, 0, 0, NULL, 1, 0)");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
