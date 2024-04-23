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
                name: "motorcycles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Model = table.Column<string>(type: "varchar", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    LicencePlate = table.Column<string>(type: "varchar(20)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 22, 17, 55, 42, 51, DateTimeKind.Utc).AddTicks(5330)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_motorcycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    UserName = table.Column<string>(type: "varchar", nullable: false),
                    Password = table.Column<string>(type: "varchar", nullable: false),
                    Permission = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Cnpj_Number = table.Column<string>(type: "varchar(20)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CnhNumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    CnhType = table.Column<int>(type: "integer", nullable: true),
                    CnhImage = table.Column<string>(type: "varchar", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 22, 17, 55, 42, 52, DateTimeKind.Utc).AddTicks(2150)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "plans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Days = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 22, 17, 55, 42, 51, DateTimeKind.Utc).AddTicks(8510)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plans", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "Id", "Days", "IsActive", "Price" },
                values: new object[,]
                {
                    { new Guid("050757df-99dc-4318-86e2-20a13b8bc710"), 7, true, 30m },
                    { new Guid("2ba8fc6c-3fc1-4d49-995c-e627ebe122f9"), 30, true, 30m },
                    { new Guid("6df66017-d27d-493f-9f6e-47c10824762c"), 15, true, 30m },
                    { new Guid("a658b19b-98c8-4513-be13-5d7a2b2be96d"), 45, true, 30m },
                    { new Guid("a97f8661-edc2-47ce-8d33-61e401c89311"), 50, true, 30m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_motorcycles_IsActive",
                table: "motorcycles",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_motorcycles_LicencePlate",
                table: "motorcycles",
                column: "LicencePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_people_IsActive",
                table: "people",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_people_UserName",
                table: "people",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_plans_IsActive",
                table: "plans",
                column: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "motorcycles");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "plans");
        }
    }
}
