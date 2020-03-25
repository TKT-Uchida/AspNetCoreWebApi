using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationTestMigration.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductModelMst",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    ModelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelMst", x => new { x.ProductId, x.ModelId });
                    table.UniqueConstraint("AK_ProductModelMst_ModelId", x => x.ModelId);
                });

            migrationBuilder.CreateTable(
                name: "ProductMst",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMst", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ModelUserMst",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelUserMst", x => new { x.UserId, x.ModelId });
                    table.ForeignKey(
                        name: "FK_ModelUserMst_ProductModelMst_ModelId",
                        column: x => x.ModelId,
                        principalTable: "ProductModelMst",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductMstChild",
                columns: table => new
                {
                    AParenctProductId = table.Column<int>(nullable: false),
                    ChildProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMstChild", x => new { x.AParenctProductId, x.ChildProductId });
                    table.ForeignKey(
                        name: "FK_ProductMstChild_ProductMst_AParenctProductId",
                        column: x => x.AParenctProductId,
                        principalTable: "ProductMst",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMstChild_ProductMst_ChildProductId",
                        column: x => x.ChildProductId,
                        principalTable: "ProductMst",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelUserMst_ModelId",
                table: "ModelUserMst",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMstChild_ChildProductId",
                table: "ProductMstChild",
                column: "ChildProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelUserMst");

            migrationBuilder.DropTable(
                name: "ProductMstChild");

            migrationBuilder.DropTable(
                name: "ProductModelMst");

            migrationBuilder.DropTable(
                name: "ProductMst");
        }
    }
}
