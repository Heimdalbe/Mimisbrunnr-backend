using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mimisbrunnr.Persistence.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20261105130000_AddSnakeScores")]
public class AddSnakeScores : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "SnakeScores",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Width = table.Column<int>(type: "int", nullable: false),
                Height = table.Column<int>(type: "int", nullable: false),
                Score = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SnakeScores", x => x.Id);
                table.ForeignKey("FK_SnakeScores_Users_UserId", x => x.UserId, "Users", "Id",
                    onDelete: ReferentialAction.Cascade);
            }).Annotation("MySql:CharSet", "utf8mb4");
        migrationBuilder.CreateIndex("IX_SnakeScores_UserId", "SnakeScores", "UserId");
        migrationBuilder.CreateIndex("IX_SnakeScores_Width_Height_UserId_Score", "SnakeScores",
            ["Width", "Height", "UserId", "Score"]);
    }

    protected override void Down(MigrationBuilder migrationBuilder) => migrationBuilder.DropTable("SnakeScores");
}
