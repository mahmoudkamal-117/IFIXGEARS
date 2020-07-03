using Microsoft.EntityFrameworkCore.Migrations;

namespace Gears.Migrations
{
    public partial class PopulateContactUs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ContactUs (Address,Phone,Url,Gmail) VALUES('شارع الغريب متفرع من شارع السودان ','01228595201','NotAddedyet','NotAddedyet')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
