using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mimisbrunnr.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class memberDetailsFunFacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 506, DateTimeKind.Utc).AddTicks(5832),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 971, DateTimeKind.Utc).AddTicks(4416));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 506, DateTimeKind.Utc).AddTicks(5264),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 971, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Sponsor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 511, DateTimeKind.Utc).AddTicks(1057),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 973, DateTimeKind.Utc).AddTicks(4101));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Sponsor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 511, DateTimeKind.Utc).AddTicks(505),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 973, DateTimeKind.Utc).AddTicks(3831));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 509, DateTimeKind.Utc).AddTicks(8746),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(8374));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 509, DateTimeKind.Utc).AddTicks(8263),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(8156));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 509, DateTimeKind.Utc).AddTicks(1879),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(5121));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 509, DateTimeKind.Utc).AddTicks(1248),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(4849));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 507, DateTimeKind.Utc).AddTicks(6838),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(70));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 507, DateTimeKind.Utc).AddTicks(6213),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 971, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 505, DateTimeKind.Utc).AddTicks(3832),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(8848));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 505, DateTimeKind.Utc).AddTicks(3211),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(8590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 504, DateTimeKind.Utc).AddTicks(681),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(4445));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 504, DateTimeKind.Utc).AddTicks(122),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(4200));

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "MemberDetails",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavoriteGame",
                table: "MemberDetails",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FavoriteHeimdal",
                table: "MemberDetails",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StudieRichting",
                table: "MemberDetails",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 502, DateTimeKind.Utc).AddTicks(4556),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(8745));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 502, DateTimeKind.Utc).AddTicks(3950),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(8477));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Image",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 500, DateTimeKind.Utc).AddTicks(7669),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(1066));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Image",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 500, DateTimeKind.Utc).AddTicks(6940),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(806));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 492, DateTimeKind.Utc).AddTicks(1465),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 966, DateTimeKind.Utc).AddTicks(1654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 492, DateTimeKind.Utc).AddTicks(643),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 966, DateTimeKind.Utc).AddTicks(1362));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 501, DateTimeKind.Utc).AddTicks(4111),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(4129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 501, DateTimeKind.Utc).AddTicks(3575),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(3887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 471, DateTimeKind.Utc).AddTicks(8160),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 955, DateTimeKind.Utc).AddTicks(9076));

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Album",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(2026, 10, 12),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValue: new DateOnly(2026, 10, 11));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 471, DateTimeKind.Utc).AddTicks(7530),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 955, DateTimeKind.Utc).AddTicks(8699));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 465, DateTimeKind.Utc).AddTicks(841),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 952, DateTimeKind.Utc).AddTicks(2409));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 461, DateTimeKind.Utc).AddTicks(5851),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 950, DateTimeKind.Utc).AddTicks(6294));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "MemberDetails");

            migrationBuilder.DropColumn(
                name: "FavoriteGame",
                table: "MemberDetails");

            migrationBuilder.DropColumn(
                name: "FavoriteHeimdal",
                table: "MemberDetails");

            migrationBuilder.DropColumn(
                name: "StudieRichting",
                table: "MemberDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 971, DateTimeKind.Utc).AddTicks(4416),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 506, DateTimeKind.Utc).AddTicks(5832));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 971, DateTimeKind.Utc).AddTicks(4145),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 506, DateTimeKind.Utc).AddTicks(5264));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Sponsor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 973, DateTimeKind.Utc).AddTicks(4101),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 511, DateTimeKind.Utc).AddTicks(1057));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Sponsor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 973, DateTimeKind.Utc).AddTicks(3831),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 511, DateTimeKind.Utc).AddTicks(505));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(8374),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 509, DateTimeKind.Utc).AddTicks(8746));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(8156),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 509, DateTimeKind.Utc).AddTicks(8263));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(5121),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 509, DateTimeKind.Utc).AddTicks(1879));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(4849),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 509, DateTimeKind.Utc).AddTicks(1248));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 972, DateTimeKind.Utc).AddTicks(70),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 507, DateTimeKind.Utc).AddTicks(6838));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 971, DateTimeKind.Utc).AddTicks(9770),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 507, DateTimeKind.Utc).AddTicks(6213));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(8848),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 505, DateTimeKind.Utc).AddTicks(3832));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(8590),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 505, DateTimeKind.Utc).AddTicks(3211));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(4445),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 504, DateTimeKind.Utc).AddTicks(681));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 970, DateTimeKind.Utc).AddTicks(4200),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 504, DateTimeKind.Utc).AddTicks(122));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(8745),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 502, DateTimeKind.Utc).AddTicks(4556));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(8477),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 502, DateTimeKind.Utc).AddTicks(3950));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Image",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(1066),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 500, DateTimeKind.Utc).AddTicks(7669));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Image",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(806),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 500, DateTimeKind.Utc).AddTicks(6940));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 966, DateTimeKind.Utc).AddTicks(1654),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 492, DateTimeKind.Utc).AddTicks(1465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 966, DateTimeKind.Utc).AddTicks(1362),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 492, DateTimeKind.Utc).AddTicks(643));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(4129),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 501, DateTimeKind.Utc).AddTicks(4111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 969, DateTimeKind.Utc).AddTicks(3887),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 501, DateTimeKind.Utc).AddTicks(3575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 955, DateTimeKind.Utc).AddTicks(9076),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 471, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Album",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(2026, 10, 11),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValue: new DateOnly(2026, 10, 12));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 955, DateTimeKind.Utc).AddTicks(8699),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 471, DateTimeKind.Utc).AddTicks(7530));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 952, DateTimeKind.Utc).AddTicks(2409),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 465, DateTimeKind.Utc).AddTicks(841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 14, 25, 59, 950, DateTimeKind.Utc).AddTicks(6294),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 12, 14, 52, 44, 461, DateTimeKind.Utc).AddTicks(5851));
        }
    }
}
