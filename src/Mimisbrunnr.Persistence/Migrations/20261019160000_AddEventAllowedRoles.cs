using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mimisbrunnr.Persistence.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20261019160000_AddEventAllowedRoles")]
public class AddEventAllowedRoles : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // NULL keeps the existing event's OPEN/CLOSED audience until it is edited.
        migrationBuilder.AddColumn<string>(name: "AllowedRoles", table: "Event", type: "longtext", nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(name: "AllowedRoles", table: "Event");
    }
}
