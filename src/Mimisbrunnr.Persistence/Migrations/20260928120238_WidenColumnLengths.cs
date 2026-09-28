using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mimisbrunnr.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class WidenColumnLengths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(9514),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 601, DateTimeKind.Utc).AddTicks(1673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(9157),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 601, DateTimeKind.Utc).AddTicks(1005));

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Sponsor",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
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
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 605, DateTimeKind.Utc).AddTicks(9204));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Sponsor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 955, DateTimeKind.Utc).AddTicks(2010),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 605, DateTimeKind.Utc).AddTicks(8647));

            migrationBuilder.AlterColumn<string>(
                name: "Benefits",
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
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(6427),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 604, DateTimeKind.Utc).AddTicks(8684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(6164),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 604, DateTimeKind.Utc).AddTicks(8242));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(2472),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 604, DateTimeKind.Utc).AddTicks(1696));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(2123),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 604, DateTimeKind.Utc).AddTicks(1090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 953, DateTimeKind.Utc).AddTicks(6057),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 602, DateTimeKind.Utc).AddTicks(2830));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 953, DateTimeKind.Utc).AddTicks(5693),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 602, DateTimeKind.Utc).AddTicks(2209));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(2432),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 599, DateTimeKind.Utc).AddTicks(6578));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(2106),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 599, DateTimeKind.Utc).AddTicks(5890));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 951, DateTimeKind.Utc).AddTicks(6420),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 598, DateTimeKind.Utc).AddTicks(3647));

            migrationBuilder.AlterColumn<string>(
                name: "Trivia",
                table: "MemberDetails",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Quote",
                table: "MemberDetails",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 951, DateTimeKind.Utc).AddTicks(6090),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 598, DateTimeKind.Utc).AddTicks(2864));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(8485),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 596, DateTimeKind.Utc).AddTicks(5821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(8094),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 596, DateTimeKind.Utc).AddTicks(5222));

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Image",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
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
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 594, DateTimeKind.Utc).AddTicks(9488));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Image",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Image",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 949, DateTimeKind.Utc).AddTicks(6627),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 594, DateTimeKind.Utc).AddTicks(8945));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 945, DateTimeKind.Utc).AddTicks(2091),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 588, DateTimeKind.Utc).AddTicks(8459));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Event",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Event",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Event",
                type: "varchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 945, DateTimeKind.Utc).AddTicks(1604),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 588, DateTimeKind.Utc).AddTicks(7825));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(1961),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 595, DateTimeKind.Utc).AddTicks(5675));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(1611),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 595, DateTimeKind.Utc).AddTicks(5154));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 934, DateTimeKind.Utc).AddTicks(3196),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 569, DateTimeKind.Utc).AddTicks(6647));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Album",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Album",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Album",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(2026, 9, 28),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValue: new DateOnly(2026, 9, 17));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 934, DateTimeKind.Utc).AddTicks(2888),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 569, DateTimeKind.Utc).AddTicks(6011));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 930, DateTimeKind.Utc).AddTicks(6894),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 562, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 929, DateTimeKind.Utc).AddTicks(3954),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 559, DateTimeKind.Utc).AddTicks(6723));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 601, DateTimeKind.Utc).AddTicks(1673),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(9514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SuperSchacht",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 601, DateTimeKind.Utc).AddTicks(1005),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(9157));

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Sponsor",
                type: "varchar(100)",
                maxLength: 100,
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
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 605, DateTimeKind.Utc).AddTicks(9204),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 955, DateTimeKind.Utc).AddTicks(2324));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Sponsor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 605, DateTimeKind.Utc).AddTicks(8647),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 955, DateTimeKind.Utc).AddTicks(2010));

            migrationBuilder.AlterColumn<string>(
                name: "Benefits",
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
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 604, DateTimeKind.Utc).AddTicks(8684),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(6427));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "SocialType",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 604, DateTimeKind.Utc).AddTicks(8242),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(6164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 604, DateTimeKind.Utc).AddTicks(1696),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(2472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Social",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 604, DateTimeKind.Utc).AddTicks(1090),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 954, DateTimeKind.Utc).AddTicks(2123));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 602, DateTimeKind.Utc).AddTicks(2830),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 953, DateTimeKind.Utc).AddTicks(6057));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumTerm",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 602, DateTimeKind.Utc).AddTicks(2209),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 953, DateTimeKind.Utc).AddTicks(5693));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 599, DateTimeKind.Utc).AddTicks(6578),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(2432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PraesidiumRole",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 599, DateTimeKind.Utc).AddTicks(5890),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 952, DateTimeKind.Utc).AddTicks(2106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 598, DateTimeKind.Utc).AddTicks(3647),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 951, DateTimeKind.Utc).AddTicks(6420));

            migrationBuilder.AlterColumn<string>(
                name: "Trivia",
                table: "MemberDetails",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Quote",
                table: "MemberDetails",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MemberDetails",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 598, DateTimeKind.Utc).AddTicks(2864),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 951, DateTimeKind.Utc).AddTicks(6090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 596, DateTimeKind.Utc).AddTicks(5821),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(8485));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "LustrumLid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 596, DateTimeKind.Utc).AddTicks(5222),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(8094));

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Image",
                type: "varchar(100)",
                maxLength: 100,
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
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 594, DateTimeKind.Utc).AddTicks(9488),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 949, DateTimeKind.Utc).AddTicks(7313));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Image",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Image",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 594, DateTimeKind.Utc).AddTicks(8945),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 949, DateTimeKind.Utc).AddTicks(6627));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 588, DateTimeKind.Utc).AddTicks(8459),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 945, DateTimeKind.Utc).AddTicks(2091));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Event",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Event",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Event",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Event",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 588, DateTimeKind.Utc).AddTicks(7825),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 945, DateTimeKind.Utc).AddTicks(1604));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 595, DateTimeKind.Utc).AddTicks(5675),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(1961));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Erelid",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 595, DateTimeKind.Utc).AddTicks(5154),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 950, DateTimeKind.Utc).AddTicks(1611));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 569, DateTimeKind.Utc).AddTicks(6647),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 934, DateTimeKind.Utc).AddTicks(3196));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Album",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Album",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Album",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(2026, 9, 17),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValue: new DateOnly(2026, 9, 28));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Album",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 569, DateTimeKind.Utc).AddTicks(6011),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 934, DateTimeKind.Utc).AddTicks(2888));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 562, DateTimeKind.Utc).AddTicks(4712),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 930, DateTimeKind.Utc).AddTicks(6894));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 17, 19, 2, 42, 559, DateTimeKind.Utc).AddTicks(6723),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2026, 9, 28, 12, 2, 37, 929, DateTimeKind.Utc).AddTicks(3954));
        }
    }
}
