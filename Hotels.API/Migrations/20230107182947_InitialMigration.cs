using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotels.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latutude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Latutude", "Longitude", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 44.8950001, 13.8131321, "Adrion Aparthotel", 103m },
                    { 2, 44.8921259, 13.8263311, "B&B Sonia", 56m },
                    { 3, 44.8920093, 13.826331, "Crazy House Hostel", 53m },
                    { 4, 44.8953402, 13.8200907, "Villa Brandestini", 217m },
                    { 5, 44.8982558, 13.7962011, "Milan Hotel", 150m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
