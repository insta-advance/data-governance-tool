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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Field_Type = table.Column<string>(nullable: true),
                    StructuredBaseId = table.Column<int>(nullable: true),
                    SchemaName = table.Column<string>(nullable: true),
                    Schema_DatabaseId = table.Column<int>(nullable: true),
                    DatabaseId = table.Column<int>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    TableName = table.Column<string>(nullable: true),
                    SchemaId = table.Column<int>(nullable: true),
                    UnstructuredFile_FilePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bases_Bases_DatabaseId",
                        column: x => x.DatabaseId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bases_Bases_StructuredBaseId",
                        column: x => x.StructuredBaseId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bases_Bases_Schema_DatabaseId",
                        column: x => x.Schema_DatabaseId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bases_Bases_SchemaId",
                        column: x => x.SchemaId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Annotations",
                columns: table => new
                {
                    AnnotationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    BaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annotations", x => x.AnnotationId);
                    table.ForeignKey(
                        name: "FK_Annotations_Bases_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompositeKeyFields",
                columns: table => new
                {
                    FieldId = table.Column<int>(nullable: false),
                    CompositeKeyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompositeKeyFields", x => new { x.FieldId, x.CompositeKeyId });
                    table.ForeignKey(
                        name: "FK_CompositeKeyFields_Bases_CompositeKeyId",
                        column: x => x.CompositeKeyId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompositeKeyFields_Bases_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeyRelationships",
                columns: table => new
                {
                    FromId = table.Column<int>(nullable: false),
                    ToId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyRelationships", x => new { x.FromId, x.ToId });
                    table.ForeignKey(
                        name: "FK_KeyRelationships_Bases_FromId",
                        column: x => x.FromId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeyRelationships_Bases_ToId",
                        column: x => x.ToId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_BaseId",
                table: "Annotations",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_DatabaseId",
                table: "Bases",
                column: "DatabaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_StructuredBaseId",
                table: "Bases",
                column: "StructuredBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_Schema_DatabaseId",
                table: "Bases",
                column: "Schema_DatabaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_SchemaId",
                table: "Bases",
                column: "SchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_CompositeKeyFields_CompositeKeyId",
                table: "CompositeKeyFields",
                column: "CompositeKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyRelationships_ToId",
                table: "KeyRelationships",
                column: "ToId");
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
        }
    }
}
