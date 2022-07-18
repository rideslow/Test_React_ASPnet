using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_React_ASPnet.DAL.Migrations
{
    public partial class Add_CountTools : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountTools",
                table: "Tool_User",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountTools",
                table: "Tool_User");
        }
    }
}
