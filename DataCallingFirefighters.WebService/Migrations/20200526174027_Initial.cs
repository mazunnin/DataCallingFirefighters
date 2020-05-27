using Microsoft.EntityFrameworkCore.Migrations;

namespace DataCallingFirefighters.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataCallingFirefighters",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumberOfCalls = table.Column<string>(nullable: true),
                    Month = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataCallingFirefighters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DataCallingFirefighters",
                columns: new[] { "Id", "District", "Month", "NumberOfCalls", "Year" },
                values: new object[] { 1L, "Северный Административный округ", "Январь", "408", "2015" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataCallingFirefighters");
        }
    }
}
