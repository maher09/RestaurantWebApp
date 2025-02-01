using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class newTransactionletter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TransactionNewsletters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "TransactionNewsletters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditDate",
                table: "TransactionNewsletters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditId",
                table: "TransactionNewsletters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TransactionNewsletters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TransactionNewsletters",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "EditDate",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "EditId",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TransactionNewsletters");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TransactionNewsletters");
        }
    }
}
