using Microsoft.EntityFrameworkCore.Migrations;

namespace Gears.Migrations
{
    public partial class Populatetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql("INSERT INTO HomeContents (Paragraph,Image) VALUES('نقدم لكم افضل الخدمات لتصليح الكيبورد والماوس والهيدفون','slider4')");
            migrationBuilder.Sql("INSERT INTO AboutUs (Paragraph) VALUES ('هذا المقال تجريبى هذا المقال تجريبىهذا المقال تجريبىهذا المقال تجريبىهذا المقال تجريبى ')");
            migrationBuilder.Sql("INSERT INTO VideoContents (Header,Paragraph) VALUES ('سوف تجد افضل الصيانه معنا ','نقوم بمعالجه وتفكيك الاجهزه بعنايه ومن ثم ذللك ان نقوم بالصيانه المحترفه التى ينبغى ان نقوم بها ع اكمل وجه')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
