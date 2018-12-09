using Microsoft.EntityFrameworkCore.Migrations;

namespace IntopaloApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annotations");

            migrationBuilder.DropTable(
                name: "CompositeKeyFields");

            migrationBuilder.DropTable(
                name: "KeyRelationships");

            migrationBuilder.DropTable(
                name: "Bases");

            migrationBuilder.DropTable(
                name: "Datastores");
        }
    }
}
