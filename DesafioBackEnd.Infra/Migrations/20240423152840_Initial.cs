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
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 23, 15, 28, 40, 851, DateTimeKind.Utc).AddTicks(3670)),
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
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 23, 15, 28, 40, 852, DateTimeKind.Utc).AddTicks(8120)),
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
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 23, 15, 28, 40, 851, DateTimeKind.Utc).AddTicks(4560)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rental",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MotorcycleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    DriverId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EstimatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 23, 15, 28, 40, 853, DateTimeKind.Utc).AddTicks(3530)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rental", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rental_motorcycles_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "motorcycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rental_people_DriverId",
                        column: x => x.DriverId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rental_plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "Discriminator", "IsActive", "Name", "Password", "Permission", "UserName" },
                values: new object[] { new Guid("44d06df4-9840-4cd6-a27b-e538c7fdb512"), "Admin", true, "Galdalf", "eNi+nWQF12V2REazPSwJHgEIF8econx1akPJlg+wzYY=", "ADMIN", "mithrandir" });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "Id", "Days", "IsActive", "Price" },
                values: new object[,]
                {
                    { new Guid("1a936486-3255-40d9-b3b7-57a1fcdc032b"), 15, true, 30m },
                    { new Guid("21937039-153d-49f9-b18b-06f44e3364d1"), 30, true, 30m },
                    { new Guid("527fbb56-913b-4cf8-9700-1befe3d196d8"), 50, true, 30m },
                    { new Guid("e190db2a-e827-407f-812e-29daa7f9ea0e"), 7, true, 30m },
                    { new Guid("e36a8312-0984-43e5-bd2e-a8ce25a26be7"), 45, true, 30m }
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

            migrationBuilder.CreateIndex(
                name: "IX_rental_DriverId",
                table: "rental",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_rental_IsActive",
                table: "rental",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_rental_MotorcycleId",
                table: "rental",
                column: "MotorcycleId");

            migrationBuilder.CreateIndex(
                name: "IX_rental_PlanId",
                table: "rental",
                column: "PlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rental");

            migrationBuilder.DropTable(
                name: "motorcycles");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "plans");
        }
    }
}
