using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mimisbrunnr.Persistence.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20261030163000_AddMembershipFees")]
public class AddMembershipFees : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "MembershipFees",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false),
                FirstYearFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                RenewalFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_MembershipFees", x => x.Id));
        migrationBuilder.InsertData(
            table: "MembershipFees",
            columns: ["Id", "FirstYearFee", "RenewalFee"],
            columnTypes: ["int", "decimal(18,2)", "decimal(18,2)"],
            values: [1, 12m, 7m]);
    }

    protected override void Down(MigrationBuilder migrationBuilder) => migrationBuilder.DropTable("MembershipFees");
}
