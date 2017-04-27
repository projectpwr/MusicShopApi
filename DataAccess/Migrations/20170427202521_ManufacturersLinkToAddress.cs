using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ManufacturersLinkToAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Manufacturers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_AddressId",
                table: "Manufacturers",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturers_Addresses_AddressId",
                table: "Manufacturers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturers_Addresses_AddressId",
                table: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_Manufacturers_AddressId",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Manufacturers");
        }
    }
}
