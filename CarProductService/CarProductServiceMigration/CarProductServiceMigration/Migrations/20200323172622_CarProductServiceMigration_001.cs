using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarProductServiceMigration.Migrations
{
    public partial class CarProductServiceMigration_001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CAR_MAKER",
                columns: table => new
                {
                    MAKER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CREATE_TIME = table.Column<DateTime>(nullable: false),
                    CREATE_USER = table.Column<string>(nullable: true),
                    UPDATE_TIME = table.Column<DateTime>(nullable: false),
                    UPDATE_USER = table.Column<string>(nullable: true),
                    EX_STAMP = table.Column<byte[]>(rowVersion: true, nullable: true),
                    COUNTRY_CODE = table.Column<string>(nullable: true),
                    MAKER_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR_MAKER", x => x.MAKER_ID);
                });

            migrationBuilder.CreateTable(
                name: "CAR_MAKER_LANG",
                columns: table => new
                {
                    MAKER_ID = table.Column<int>(nullable: false),
                    LANG_ID = table.Column<string>(nullable: false),
                    CREATE_TIME = table.Column<DateTime>(nullable: false),
                    CREATE_USER = table.Column<string>(nullable: true),
                    UPDATE_TIME = table.Column<DateTime>(nullable: false),
                    UPDATE_USER = table.Column<string>(nullable: true),
                    EX_STAMP = table.Column<byte[]>(rowVersion: true, nullable: true),
                    MAKER_NAME_LANG = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR_MAKER_LANG", x => new { x.LANG_ID, x.MAKER_ID });
                    table.ForeignKey(
                        name: "FK_CAR_MAKER_LANG_CAR_MAKER",
                        column: x => x.MAKER_ID,
                        principalTable: "CAR_MAKER",
                        principalColumn: "MAKER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CAR_PRODUCT",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<int>(nullable: false),
                    MAKER_ID = table.Column<int>(nullable: false),
                    CREATE_TIME = table.Column<DateTime>(nullable: false),
                    CREATE_USER = table.Column<string>(nullable: true),
                    UPDATE_TIME = table.Column<DateTime>(nullable: false),
                    UPDATE_USER = table.Column<string>(nullable: true),
                    EX_STAMP = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TYPE_CODE = table.Column<string>(nullable: true),
                    PRODUCT_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR_PRODUCT", x => new { x.PRODUCT_ID, x.MAKER_ID });
                    table.ForeignKey(
                        name: "FK_CAR_PRODUCT_CAR_MAKER",
                        column: x => x.MAKER_ID,
                        principalTable: "CAR_MAKER",
                        principalColumn: "MAKER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CAR_SALES_YEAR",
                columns: table => new
                {
                    CAR_SALES_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CREATE_TIME = table.Column<DateTime>(nullable: false),
                    CREATE_USER = table.Column<string>(nullable: true),
                    UPDATE_TIME = table.Column<DateTime>(nullable: false),
                    UPDATE_USER = table.Column<string>(nullable: true),
                    EX_STAMP = table.Column<byte[]>(rowVersion: true, nullable: true),
                    MAKER_ID = table.Column<int>(nullable: false),
                    TARGET_YEAR = table.Column<string>(nullable: true),
                    SALES_VOLUME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR_SALES_YEAR", x => x.CAR_SALES_ID);
                    table.ForeignKey(
                        name: "FK_CAR_SALES_YEAR_CAR_MAKER",
                        column: x => x.MAKER_ID,
                        principalTable: "CAR_MAKER",
                        principalColumn: "MAKER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CAR_PRODUCT_LANG",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<int>(nullable: false),
                    MAKER_ID = table.Column<int>(nullable: false),
                    LANG_ID = table.Column<string>(nullable: false),
                    CREATE_TIME = table.Column<DateTime>(nullable: false),
                    CREATE_USER = table.Column<string>(nullable: true),
                    UPDATE_TIME = table.Column<DateTime>(nullable: false),
                    UPDATE_USER = table.Column<string>(nullable: true),
                    EX_STAMP = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PRODUCT_NAME_LANG = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR_PRODUCT_LANG", x => new { x.PRODUCT_ID, x.MAKER_ID, x.LANG_ID });
                    table.ForeignKey(
                        name: "FK_CAR_PRODUCT_LANG_CAR_PRODUCT",
                        columns: x => new { x.PRODUCT_ID, x.MAKER_ID },
                        principalTable: "CAR_PRODUCT",
                        principalColumns: new[] { "PRODUCT_ID", "MAKER_ID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CAR_PRODUCT_MODEL",
                columns: table => new
                {
                    MODEL_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CREATE_TIME = table.Column<DateTime>(nullable: false),
                    CREATE_USER = table.Column<string>(nullable: true),
                    UPDATE_TIME = table.Column<DateTime>(nullable: false),
                    UPDATE_USER = table.Column<string>(nullable: true),
                    EX_STAMP = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PRODUCT_ID = table.Column<int>(nullable: false),
                    MAKER_ID = table.Column<int>(nullable: false),
                    MODEL_YEAR = table.Column<string>(nullable: true),
                    PRODUCT_MODEL_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR_PRODUCT_MODEL", x => x.MODEL_ID);
                    table.ForeignKey(
                        name: "FK_CAR_PRODUCT_MODEL_CAR_PRODUCT",
                        columns: x => new { x.PRODUCT_ID, x.MAKER_ID },
                        principalTable: "CAR_PRODUCT",
                        principalColumns: new[] { "PRODUCT_ID", "MAKER_ID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CAR_MAKER_LANG_MAKER_ID",
                table: "CAR_MAKER_LANG",
                column: "MAKER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_PRODUCT_MAKER_ID",
                table: "CAR_PRODUCT",
                column: "MAKER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_PRODUCT_MODEL_PRODUCT_ID_MAKER_ID",
                table: "CAR_PRODUCT_MODEL",
                columns: new[] { "PRODUCT_ID", "MAKER_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_CAR_SALES_YEAR_MAKER_ID",
                table: "CAR_SALES_YEAR",
                column: "MAKER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CAR_MAKER_LANG");

            migrationBuilder.DropTable(
                name: "CAR_PRODUCT_LANG");

            migrationBuilder.DropTable(
                name: "CAR_PRODUCT_MODEL");

            migrationBuilder.DropTable(
                name: "CAR_SALES_YEAR");

            migrationBuilder.DropTable(
                name: "CAR_PRODUCT");

            migrationBuilder.DropTable(
                name: "CAR_MAKER");
        }
    }
}
