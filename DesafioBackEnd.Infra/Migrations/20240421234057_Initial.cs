using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBackEnd.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motorcycle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    LicencePlate = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 21, 23, 40, 57, 261, DateTimeKind.Utc).AddTicks(3340)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Days = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 21, 23, 40, 57, 261, DateTimeKind.Utc).AddTicks(6210)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Plan",
                columns: new[] { "Id", "Days", "IsActive", "Price" },
                values: new object[,]
                {
                    { new Guid("1e21b652-80eb-45dd-a414-15cc3ec257d4"), 30, true, 30m },
                    { new Guid("244d529f-225f-47a3-bf50-d8c58a5ec10f"), 7, true, 30m },
                    { new Guid("334f5188-3e10-44f1-9e5f-663bc32d1e58"), 45, true, 30m },
                    { new Guid("597ffa44-698b-4096-88c4-0d522b614cb1"), 50, true, 30m },
                    { new Guid("658039ab-222c-44c7-8691-7af6dabed329"), 15, true, 30m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycle_IsActive",
                table: "Motorcycle",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_IsActive",
                table: "Plan",
                column: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motorcycle");

            migrationBuilder.DropTable(
                name: "Plan");
        }
    }
}
