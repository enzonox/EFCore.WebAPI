using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.WebAPI.Migrations
{
    public partial class HeroisBatalhas_Identidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroi_Batalha_BatalhaId",
                table: "Heroi");

            migrationBuilder.DropIndex(
                name: "IX_Heroi_BatalhaId",
                table: "Heroi");

            migrationBuilder.DropColumn(
                name: "BatalhaId",
                table: "Heroi");

            migrationBuilder.CreateTable(
                name: "HeroiBatalha",
                columns: table => new
                {
                    HeroiId = table.Column<int>(nullable: false),
                    BatalhaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroiBatalha", x => new { x.BatalhaId, x.HeroiId });
                    table.ForeignKey(
                        name: "FK_HeroiBatalha_Batalha_BatalhaId",
                        column: x => x.BatalhaId,
                        principalTable: "Batalha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroiBatalha_Heroi_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Heroi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentidadeSecreta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeReal = table.Column<int>(nullable: false),
                    HeroiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentidadeSecreta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentidadeSecreta_Heroi_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Heroi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroiBatalha_HeroiId",
                table: "HeroiBatalha",
                column: "HeroiId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentidadeSecreta_HeroiId",
                table: "IdentidadeSecreta",
                column: "HeroiId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroiBatalha");

            migrationBuilder.DropTable(
                name: "IdentidadeSecreta");

            migrationBuilder.AddColumn<int>(
                name: "BatalhaId",
                table: "Heroi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Heroi_BatalhaId",
                table: "Heroi",
                column: "BatalhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroi_Batalha_BatalhaId",
                table: "Heroi",
                column: "BatalhaId",
                principalTable: "Batalha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
