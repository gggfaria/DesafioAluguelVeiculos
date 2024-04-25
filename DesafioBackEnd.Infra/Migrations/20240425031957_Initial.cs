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
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 25, 3, 19, 57, 475, DateTimeKind.Utc).AddTicks(2010)),
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
                    ImageSize = table.Column<long>(type: "bigint", nullable: true),
                    ImageType = table.Column<string>(type: "varchar(10)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 25, 3, 19, 57, 476, DateTimeKind.Utc).AddTicks(6950)),
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
                    FineValue = table.Column<int>(type: "integer", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 25, 3, 19, 57, 475, DateTimeKind.Utc).AddTicks(2960)),
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
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EstimatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 25, 3, 19, 57, 477, DateTimeKind.Utc).AddTicks(2810)),
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
                values: new object[] { new Guid("616cf642-ea86-40d0-a2f4-28d64f521b35"), "Admin", true, "Galdalf", "eNi+nWQF12V2REazPSwJHgEIF8econx1akPJlg+wzYY=", "ADMIN", "mithrandir" });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "Id", "Days", "FineValue", "IsActive", "Price" },
                values: new object[,]
                {
                    { new Guid("10f0fa04-1724-46be-a9bc-c50f8bbf2955"), 45, null, true, 30m },
                    { new Guid("971df87c-5668-4ee3-b67a-1688421baa8b"), 50, null, true, 30m },
                    { new Guid("9cc89fa6-7341-4083-9901-0814f4e60e70"), 7, 20, true, 30m },
                    { new Guid("b3a0bdb3-6694-4a55-a37b-816d2fe629f8"), 30, null, true, 30m },
                    { new Guid("fbf01997-4f93-4832-bae6-043fe7d4f45e"), 15, 40, true, 30m }
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
