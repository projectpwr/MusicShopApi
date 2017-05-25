using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddredRowVersionAndContraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ProductTypes",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Manufacturers",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Manufacturers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstLine",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondLine",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThirdLine",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Addresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "County",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "FirstLine",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "SecondLine",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ThirdLine",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Products",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Manufacturers",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
