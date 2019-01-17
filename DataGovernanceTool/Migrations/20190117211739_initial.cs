using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataGT.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Annotations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annotations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Datastores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datastores", x => x.Id);
                    table.UniqueConstraint("AK_Datastores_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Bases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    TableId = table.Column<int>(nullable: true),
                    TableForeignId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    DatastoreId = table.Column<int>(nullable: true),
                    SchemaName = table.Column<string>(nullable: true),
                    Schema_DatabaseId = table.Column<int>(nullable: true),
                    DatabaseId = table.Column<int>(nullable: true),
                    Field_Type = table.Column<string>(nullable: true),
                    StructuredId = table.Column<int>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    StructuredFile_DatastoreId = table.Column<int>(nullable: true),
                    TableName = table.Column<string>(nullable: true),
                    SchemaId = table.Column<int>(nullable: true),
                    UnstructuredFile_FilePath = table.Column<string>(nullable: true),
                    UnstructuredFile_DatastoreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bases_Bases_TableForeignId",
                        column: x => x.TableForeignId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bases_Bases_TableId",
                        column: x => x.TableId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bases_Bases_DatabaseId",
                        column: x => x.DatabaseId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bases_Bases_StructuredId",
                        column: x => x.StructuredId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bases_Datastores_DatastoreId",
                        column: x => x.DatastoreId,
                        principalTable: "Datastores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bases_Datastores_DatastoreId1",
                        column: x => x.DatastoreId,
                        principalTable: "Datastores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bases_Bases_Schema_DatabaseId",
                        column: x => x.Schema_DatabaseId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bases_Datastores_StructuredFile_DatastoreId",
                        column: x => x.StructuredFile_DatastoreId,
                        principalTable: "Datastores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bases_Bases_SchemaId",
                        column: x => x.SchemaId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bases_Datastores_UnstructuredFile_DatastoreId",
                        column: x => x.UnstructuredFile_DatastoreId,
                        principalTable: "Datastores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnotationBases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AnnotationId = table.Column<int>(nullable: false),
                    BaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnotationBases", x => x.Id);
                    table.UniqueConstraint("AK_AnnotationBases_AnnotationId_BaseId", x => new { x.AnnotationId, x.BaseId });
                    table.ForeignKey(
                        name: "FK_AnnotationBases_Annotations_AnnotationId",
                        column: x => x.AnnotationId,
                        principalTable: "Annotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnotationBases_Bases_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompositeKeyFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FieldId = table.Column<int>(nullable: false),
                    CompositeKeyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompositeKeyFields", x => x.Id);
                    table.UniqueConstraint("AK_CompositeKeyFields_FieldId_CompositeKeyId", x => new { x.FieldId, x.CompositeKeyId });
                    table.ForeignKey(
                        name: "FK_CompositeKeyFields_Bases_CompositeKeyId",
                        column: x => x.CompositeKeyId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FromId = table.Column<int>(nullable: false),
                    ToId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyRelationships", x => x.Id);
                    table.UniqueConstraint("AK_KeyRelationships_FromId_ToId", x => new { x.FromId, x.ToId });
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnotationBases_BaseId",
                table: "AnnotationBases",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_TableForeignId",
                table: "Bases",
                column: "TableForeignId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_TableId",
                table: "Bases",
                column: "TableId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bases_DatabaseId",
                table: "Bases",
                column: "DatabaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_Name_DatabaseId",
                table: "Bases",
                columns: new[] { "Name", "DatabaseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bases_Name_DatastoreId",
                table: "Bases",
                columns: new[] { "Name", "DatastoreId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bases_StructuredId",
                table: "Bases",
                column: "StructuredId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_Name_StructuredId",
                table: "Bases",
                columns: new[] { "Name", "StructuredId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bases_DatastoreId",
                table: "Bases",
                column: "DatastoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_DatastoreId1",
                table: "Bases",
                column: "DatastoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_Schema_DatabaseId",
                table: "Bases",
                column: "Schema_DatabaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_Name_Schema_DatabaseId",
                table: "Bases",
                columns: new[] { "Name", "Schema_DatabaseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bases_StructuredFile_DatastoreId",
                table: "Bases",
                column: "StructuredFile_DatastoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_FilePath_StructuredFile_DatastoreId",
                table: "Bases",
                columns: new[] { "FilePath", "StructuredFile_DatastoreId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bases_SchemaId",
                table: "Bases",
                column: "SchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_UnstructuredFile_DatastoreId",
                table: "Bases",
                column: "UnstructuredFile_DatastoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_UnstructuredFile_FilePath_UnstructuredFile_DatastoreId",
                table: "Bases",
                columns: new[] { "UnstructuredFile_FilePath", "UnstructuredFile_DatastoreId" },
                unique: true);

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
                name: "AnnotationBases");

            migrationBuilder.DropTable(
                name: "CompositeKeyFields");

            migrationBuilder.DropTable(
                name: "KeyRelationships");

            migrationBuilder.DropTable(
                name: "Annotations");

            migrationBuilder.DropTable(
                name: "Bases");

            migrationBuilder.DropTable(
                name: "Datastores");
        }
    }
}
