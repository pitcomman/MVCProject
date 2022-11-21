using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCStart.Migrations
{
    public partial class insert_category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories (CategoryName) VALUES ('Mobile')");
            migrationBuilder.Sql("INSERT INTO Categories (CategoryName) VALUES ('NoteBook')");
            migrationBuilder.Sql("INSERT INTO Categories (CategoryName) VALUES ('Tablet')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
