using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WMSMVC.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Clients_UserId1",
                table: "Baskets");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_ClientDatas_ClientId",
                table: "ClientDatas");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_UserId1",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "ClientDatas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Baskets");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Items",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Baskets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsRealised",
                table: "Baskets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ClientAdresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: true),
                    NumberOfHome = table.Column<int>(nullable: false),
                    NumberOfFlat = table.Column<int>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAdresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientAdresses_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientDatas_ClientId",
                table: "ClientDatas",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ClientId",
                table: "Baskets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAdresses_ClientId",
                table: "ClientAdresses",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Clients_ClientId",
                table: "Baskets",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Clients_ClientId",
                table: "Baskets");

            migrationBuilder.DropTable(
                name: "ClientAdresses");

            migrationBuilder.DropIndex(
                name: "IX_ClientDatas_ClientId",
                table: "ClientDatas");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_ClientId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "IsRealised",
                table: "Baskets");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "ClientDatas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Baskets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    NumberOfFlat = table.Column<int>(type: "int", nullable: true),
                    NumberOfHome = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientDatas_ClientId",
                table: "ClientDatas",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId1",
                table: "Baskets",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_ClientId",
                table: "Adresses",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Clients_UserId1",
                table: "Baskets",
                column: "UserId1",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
