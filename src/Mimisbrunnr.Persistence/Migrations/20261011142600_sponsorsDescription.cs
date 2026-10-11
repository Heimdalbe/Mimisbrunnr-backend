using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mimisbrunnr.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class sponsorsDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 971, DateTimeKind.Utc).AddTicks(4416),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(2859));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 971, DateTimeKind.Utc).AddTicks(4145),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(2560));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Sponsor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 973, DateTimeKind.Utc).AddTicks(4101),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 388, DateTimeKind.Utc).AddTicks(3133));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Sponsor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 973, DateTimeKind.Utc).AddTicks(3831),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 388, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sponsor",
                type: "varchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(8374),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(7398));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(8156),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(7169));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(5121),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(3955));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(4849),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(3646));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(70),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(8471));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 971, DateTimeKind.Utc).AddTicks(9770),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(8149));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(8848),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(6962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(8590),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(6687));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(4445),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(2191));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(4200),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(1912));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(8745),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 384, DateTimeKind.Utc).AddTicks(5573));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(8477),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 384, DateTimeKind.Utc).AddTicks(5259));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Image",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(1066),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 383, DateTimeKind.Utc).AddTicks(6736));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Image",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(806),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 383, DateTimeKind.Utc).AddTicks(6457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 966, DateTimeKind.Utc).AddTicks(1654),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 380, DateTimeKind.Utc).AddTicks(3173));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 966, DateTimeKind.Utc).AddTicks(1362),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 380, DateTimeKind.Utc).AddTicks(2844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(4129),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 384, DateTimeKind.Utc).AddTicks(4));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(3887),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 383, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 955, DateTimeKind.Utc).AddTicks(9076),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 370, DateTimeKind.Utc).AddTicks(3331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 955, DateTimeKind.Utc).AddTicks(8699),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 370, DateTimeKind.Utc).AddTicks(2993));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 952, DateTimeKind.Utc).AddTicks(2409),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 367, DateTimeKind.Utc).AddTicks(552));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 950, DateTimeKind.Utc).AddTicks(6294),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 365, DateTimeKind.Utc).AddTicks(6080));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sponsor");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(2859),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 971, DateTimeKind.Utc).AddTicks(4416));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(2560),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 971, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Sponsor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 388, DateTimeKind.Utc).AddTicks(3133),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 973, DateTimeKind.Utc).AddTicks(4101));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Sponsor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 388, DateTimeKind.Utc).AddTicks(2850),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 973, DateTimeKind.Utc).AddTicks(3831));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(7398),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(8374));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(7169),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(8156));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(3955),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(5121));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(3646),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(4849));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(8471),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(70));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(8149),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 971, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(6962),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(8848));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(6687),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(8590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(2191),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(4445));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(1912),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(4200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 384, DateTimeKind.Utc).AddTicks(5573),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(8745));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 384, DateTimeKind.Utc).AddTicks(5259),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(8477));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Image",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 383, DateTimeKind.Utc).AddTicks(6736),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(1066));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Image",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 383, DateTimeKind.Utc).AddTicks(6457),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(806));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 380, DateTimeKind.Utc).AddTicks(3173),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 966, DateTimeKind.Utc).AddTicks(1654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 380, DateTimeKind.Utc).AddTicks(2844),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 966, DateTimeKind.Utc).AddTicks(1362));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 384, DateTimeKind.Utc).AddTicks(4),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(4129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 383, DateTimeKind.Utc).AddTicks(9729),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(3887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 370, DateTimeKind.Utc).AddTicks(3331),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 955, DateTimeKind.Utc).AddTicks(9076));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 370, DateTimeKind.Utc).AddTicks(2993),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 955, DateTimeKind.Utc).AddTicks(8699));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 367, DateTimeKind.Utc).AddTicks(552),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 952, DateTimeKind.Utc).AddTicks(2409));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 365, DateTimeKind.Utc).AddTicks(6080),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 950, DateTimeKind.Utc).AddTicks(6294));
        }
    }
}
