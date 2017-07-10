using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UrlShortener.Dal.Migrations
{
    public partial class optimizedstructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShortLinks",
                table: "ShortLinks");

            migrationBuilder.DropColumn(
                name: "LastDateUsed",
                table: "ShortLinks");

            migrationBuilder.DropColumn(
                name: "ShortenedUrl",
                table: "ShortLinks");

            migrationBuilder.AlterColumn<string>(
                name: "SourceUrl",
                table: "ShortLinks",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ShortLinks",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShortLinks",
                table: "ShortLinks",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShortLinks",
                table: "ShortLinks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShortLinks");

            migrationBuilder.AlterColumn<string>(
                name: "SourceUrl",
                table: "ShortLinks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDateUsed",
                table: "ShortLinks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ShortenedUrl",
                table: "ShortLinks",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShortLinks",
                table: "ShortLinks",
                column: "SourceUrl");
        }
    }
}
