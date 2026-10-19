using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mimisbrunnr.Persistence.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20261019150000_AddHeimieRole")]
public class AddHeimieRole : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("""
            INSERT INTO `Roles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`)
            SELECT '44c4b290-ccfa-4183-b74f-d1b525d171e2', 'Heimie', 'HEIMIE', 'heimie-v1'
            WHERE NOT EXISTS (SELECT 1 FROM `Roles` WHERE `NormalizedName` = 'HEIMIE');
            """);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DELETE FROM `Roles` WHERE `Id` = '44c4b290-ccfa-4183-b74f-d1b525d171e2';");
    }
}
