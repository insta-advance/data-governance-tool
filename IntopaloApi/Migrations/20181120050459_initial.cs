using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntopaloApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bases",
                columns: table => new
                {
                    BaseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    DBName = table.Column<string>(nullable: true),
                    DBType = table.Column<string>(nullable: true),
                    FieldName = table.Column<string>(nullable: true),
                    FieldType = table.Column<string>(nullable: true),
                    StructuredBaseBaseID = table.Column<int>(nullable: true),
                    SchemaName = table.Column<string>(nullable: true),
                    CollectionName = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    TableName = table.Column<string>(nullable: true),
                    SchemaBaseID = table.Column<int>(nullable: true),
                    UnstructuredFile_FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bases", x => x.BaseID);
                    table.ForeignKey(
                        name: "FK_Bases_Bases_StructuredBaseBaseID",
                        column: x => x.StructuredBaseBaseID,
                        principalTable: "Bases",
                        principalColumn: "BaseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bases_Bases_SchemaBaseID",
                        column: x => x.SchemaBaseID,
                        principalTable: "Bases",
                        principalColumn: "BaseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KeyRelationships",
                columns: table => new
                {
                    BaseFromId = table.Column<int>(nullable: false),
                    BaseToId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyRelationships", x => new { x.BaseFromId, x.BaseToId });
                    table.ForeignKey(
                        name: "FK_KeyRelationships_Bases_BaseFromId",
                        column: x => x.BaseFromId,
                        principalTable: "Bases",
                        principalColumn: "BaseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeyRelationships_Bases_BaseToId",
                        column: x => x.BaseToId,
                        principalTable: "Bases",
                        principalColumn: "BaseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bases_StructuredBaseBaseID",
                table: "Bases",
                column: "StructuredBaseBaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_SchemaBaseID",
                table: "Bases",
                column: "SchemaBaseID");

            migrationBuilder.CreateIndex(
                name: "IX_KeyRelationships_BaseToId",
                table: "KeyRelationships",
                column: "BaseToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyRelationships");

            migrationBuilder.DropTable(
                name: "Bases");
        }
    }
}
