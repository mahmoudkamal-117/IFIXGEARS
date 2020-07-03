using Microsoft.EntityFrameworkCore.Migrations;

namespace Gears.Migrations
{
    public partial class PopulateAccountdeveloper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql("INSERT INTO[dbo].[AspNetUsers]([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES(N'd497aaff-510b-4d95-867e-cef5694d5cac', N'mahmoud', N'MAHMOUD', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEOGcb/0Ke7bt84ekF9pUv6fWjbyP/vXXJWDbJ+8dwqXxVnYhn2z8qyd7iPflB5AHEQ==', N'QRTT2P4YM2V7EBOKHMBU5FDLWXD7AXZQ', N'b84ecf26-16ca-4345-96f5-6aeffbfbc904', NULL, 0, 0, NULL, 1, 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
