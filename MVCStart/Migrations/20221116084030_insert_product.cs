using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCStart.Migrations
{
    public partial class insert_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Random random = new Random();

            for(int i=1; i<=100; i++)
            {

                //Random 1 to 3  use Next(1, 4)
                int categoryId = random.Next(1, 4);
                int price = random.Next(5000, 100001);

                migrationBuilder.Sql($"INSERT INTO Products (Name, Price, Description, CategoryId) VALUES ('Product {i}', {price}, 'Desc{i}', {categoryId})");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
