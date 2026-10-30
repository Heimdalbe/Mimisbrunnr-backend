using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mimisbrunnr.Persistence.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20261030140000_AddAccountNames")]
public class AddAccountNames : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(name: "FirstName", table: "Account", type: "varchar(100)", maxLength: 100, nullable: true);
        migrationBuilder.AddColumn<string>(name: "LastName", table: "Account", type: "varchar(100)", maxLength: 100, nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(name: "FirstName", table: "Account");
        migrationBuilder.DropColumn(name: "LastName", table: "Account");
    }
}
