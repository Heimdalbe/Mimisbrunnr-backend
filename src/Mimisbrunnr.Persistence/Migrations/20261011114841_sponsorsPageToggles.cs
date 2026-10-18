using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mimisbrunnr.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class sponsorsPageToggles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(2859),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(9514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(2560),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(9157));

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Sponsor",
                type: "varchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Sponsor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 388, DateTimeKind.Utc).AddTicks(3133),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 955, DateTimeKind.Utc).AddTicks(2324));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Sponsor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 388, DateTimeKind.Utc).AddTicks(2850),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 955, DateTimeKind.Utc).AddTicks(2010));

            migrationBuilder.AddColumn<bool>(
                name: "OnHomePage",
                table: "Sponsor",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OnSponsorPage",
                table: "Sponsor",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(7398),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(6427));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(7169),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(6164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(3955),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(2472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(3646),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(2123));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(8471),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 953, DateTimeKind.Utc).AddTicks(6057));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(8149),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 953, DateTimeKind.Utc).AddTicks(5693));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(6962),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(2432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(6687),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(2106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(2191),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 951, DateTimeKind.Utc).AddTicks(6420));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(1912),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 951, DateTimeKind.Utc).AddTicks(6090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 384, DateTimeKind.Utc).AddTicks(5573),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(8485));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 384, DateTimeKind.Utc).AddTicks(5259),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(8094));

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Image",
                type: "varchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Image",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 383, DateTimeKind.Utc).AddTicks(6736),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 949, DateTimeKind.Utc).AddTicks(7313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Image",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 383, DateTimeKind.Utc).AddTicks(6457),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 949, DateTimeKind.Utc).AddTicks(6627));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 380, DateTimeKind.Utc).AddTicks(3173),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 945, DateTimeKind.Utc).AddTicks(2091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 380, DateTimeKind.Utc).AddTicks(2844),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 945, DateTimeKind.Utc).AddTicks(1604));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 384, DateTimeKind.Utc).AddTicks(4),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(1961));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 383, DateTimeKind.Utc).AddTicks(9729),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(1611));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 370, DateTimeKind.Utc).AddTicks(3331),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 934, DateTimeKind.Utc).AddTicks(3196));

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Album",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(2026, 10, 11),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValue: new DateOnly(2026, 9, 28));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 370, DateTimeKind.Utc).AddTicks(2993),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 934, DateTimeKind.Utc).AddTicks(2888));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 367, DateTimeKind.Utc).AddTicks(552),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 930, DateTimeKind.Utc).AddTicks(6894));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 365, DateTimeKind.Utc).AddTicks(6080),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 929, DateTimeKind.Utc).AddTicks(3954));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnHomePage",
                table: "Sponsor");

            migrationBuilder.DropColumn(
                name: "OnSponsorPage",
                table: "Sponsor");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(9514),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(2859));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(9157),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(2560));

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Sponsor",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2000)",
                oldMaxLength: 2000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Sponsor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 955, DateTimeKind.Utc).AddTicks(2324),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 388, DateTimeKind.Utc).AddTicks(3133));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Sponsor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 955, DateTimeKind.Utc).AddTicks(2010),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 388, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(6427),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(7398));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(6164),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(7169));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(2472),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(3955));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(2123),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 387, DateTimeKind.Utc).AddTicks(3646));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 953, DateTimeKind.Utc).AddTicks(6057),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(8471));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 953, DateTimeKind.Utc).AddTicks(5693),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 386, DateTimeKind.Utc).AddTicks(8149));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(2432),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(6962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(2106),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(6687));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 951, DateTimeKind.Utc).AddTicks(6420),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(2191));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 951, DateTimeKind.Utc).AddTicks(6090),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 385, DateTimeKind.Utc).AddTicks(1912));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(8485),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 384, DateTimeKind.Utc).AddTicks(5573));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(8094),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 384, DateTimeKind.Utc).AddTicks(5259));

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Image",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2000)",
                oldMaxLength: 2000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Image",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 949, DateTimeKind.Utc).AddTicks(7313),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 383, DateTimeKind.Utc).AddTicks(6736));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Image",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 949, DateTimeKind.Utc).AddTicks(6627),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 383, DateTimeKind.Utc).AddTicks(6457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 945, DateTimeKind.Utc).AddTicks(2091),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 380, DateTimeKind.Utc).AddTicks(3173));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 945, DateTimeKind.Utc).AddTicks(1604),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 380, DateTimeKind.Utc).AddTicks(2844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(1961),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 384, DateTimeKind.Utc).AddTicks(4));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(1611),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 383, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 934, DateTimeKind.Utc).AddTicks(3196),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 370, DateTimeKind.Utc).AddTicks(3331));

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Album",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(2026, 9, 28),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValue: new DateOnly(2026, 10, 11));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 934, DateTimeKind.Utc).AddTicks(2888),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 370, DateTimeKind.Utc).AddTicks(2993));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 930, DateTimeKind.Utc).AddTicks(6894),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 367, DateTimeKind.Utc).AddTicks(552));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 929, DateTimeKind.Utc).AddTicks(3954),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 10, 11, 11, 48, 41, 365, DateTimeKind.Utc).AddTicks(6080));
        }
    }
}
