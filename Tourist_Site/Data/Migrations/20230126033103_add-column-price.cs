using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourist_Site.Data.Migrations
{
    public partial class addcolumnprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "AspNetUsers");
        }
    }
}
