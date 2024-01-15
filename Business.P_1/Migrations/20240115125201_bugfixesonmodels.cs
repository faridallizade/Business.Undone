using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.P_1.Migrations
{
    public partial class bugfixesonmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "blogs");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "blogs");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
