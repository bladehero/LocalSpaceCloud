using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalSpaceCloud.Data.Migrations
{
    public partial class Initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemEntityTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemEntityTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BinEntities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RestorePath = table.Column<string>(type: "TEXT", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SystemEntityType = table.Column<int>(type: "INTEGER", nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BinEntities_SystemEntityTypes_SystemEntityType",
                        column: x => x.SystemEntityType,
                        principalTable: "SystemEntityTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BinEntities_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SystemEntityTypes",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 0, "File system cataloging structure which contains references to other computer files, and possibly other directories", "Directory" });

            migrationBuilder.InsertData(
                table: "SystemEntityTypes",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 1, "Computer resource for recording data discretely in a computer storage device", "File" });

            migrationBuilder.InsertData(
                table: "SystemEntityTypes",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 2, "An archive is an accumulation of historical records", "Archive" });

            migrationBuilder.CreateIndex(
                name: "IX_BinEntities_SystemEntityType",
                table: "BinEntities",
                column: "SystemEntityType");

            migrationBuilder.CreateIndex(
                name: "IX_BinEntities_UserID",
                table: "BinEntities",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinEntities");

            migrationBuilder.DropTable(
                name: "SystemEntityTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
