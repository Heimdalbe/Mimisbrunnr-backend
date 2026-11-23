using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mimisbrunnr.Persistence.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20261123170000_AddAlbumThumbnails")]
public class AddAlbumThumbnails : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>("ThumbnailUrl", "Image", type: "varchar(2000)", maxLength: 2000, nullable: true);
        migrationBuilder.AddColumn<DateTime>("ThumbnailRetryAfter", "Image", type: "datetime(6)", nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn("ThumbnailRetryAfter", "Image");
        migrationBuilder.DropColumn("ThumbnailUrl", "Image");
    }
}
