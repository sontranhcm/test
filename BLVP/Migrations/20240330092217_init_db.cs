using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLVP.Migrations
{
    public partial class init_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TEST_SCHEMA");

            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IDCOUNTER",
                schema: "TEST_SCHEMA",
                columns: table => new
                {
                    KEY = table.Column<string>(type: "varchar(255)", nullable: false),
                    NUMBERFORMAT = table.Column<string>(type: "longtext", nullable: false),
                    FORMAT = table.Column<string>(type: "longtext", nullable: false),
                    COUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDCOUNTER", x => x.KEY);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IDCOUNTER",
                schema: "TEST_SCHEMA");
        }
    }
}
