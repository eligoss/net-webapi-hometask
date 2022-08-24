using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.HomeTask.Dal.Migrations
{
    public partial class UseNameAsLookupColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Tables_TableEntityId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_TablesSize_PeopleCount",
                table: "TablesSize");

            migrationBuilder.DropIndex(
                name: "IX_TablesSize_Size",
                table: "TablesSize");

            migrationBuilder.DropIndex(
                name: "IX_Tables_TableEntityId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "TablesSize");

            migrationBuilder.DropColumn(
                name: "TableEntityId",
                table: "Tables");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TablesSize",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TablesSize",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "TablesSize",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablesSize_Name",
                table: "TablesSize",
                column: "Name")
                .Annotation("SqlServer:Include", new[] { "PeopleCount" });

            migrationBuilder.CreateIndex(
                name: "IX_TablesSize_PeopleCount",
                table: "TablesSize",
                column: "PeopleCount")
                .Annotation("SqlServer:Include", new[] { "Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TablesSize_Name",
                table: "TablesSize");

            migrationBuilder.DropIndex(
                name: "IX_TablesSize_PeopleCount",
                table: "TablesSize");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TablesSize");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TablesSize");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TablesSize");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "TablesSize",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TableEntityId",
                table: "Tables",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TablesSize_PeopleCount",
                table: "TablesSize",
                column: "PeopleCount")
                .Annotation("SqlServer:Include", new[] { "Size" });

            migrationBuilder.CreateIndex(
                name: "IX_TablesSize_Size",
                table: "TablesSize",
                column: "Size")
                .Annotation("SqlServer:Include", new[] { "PeopleCount" });

            migrationBuilder.CreateIndex(
                name: "IX_Tables_TableEntityId",
                table: "Tables",
                column: "TableEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Tables_TableEntityId",
                table: "Tables",
                column: "TableEntityId",
                principalTable: "Tables",
                principalColumn: "Id");
        }
    }
}
