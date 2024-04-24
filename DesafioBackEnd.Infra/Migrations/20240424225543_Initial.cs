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
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 24, 22, 55, 43, 764, DateTimeKind.Utc).AddTicks(180)),
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
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 24, 22, 55, 43, 765, DateTimeKind.Utc).AddTicks(5070)),
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
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 24, 22, 55, 43, 764, DateTimeKind.Utc).AddTicks(1160)),
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
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 4, 24, 22, 55, 43, 766, DateTimeKind.Utc).AddTicks(850)),
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
                values: new object[] { new Guid("096996d8-7fb8-4b14-9e12-353b16f8a5f7"), "Admin", true, "Galdalf", "eNi+nWQF12V2REazPSwJHgEIF8econx1akPJlg+wzYY=", "ADMIN", "mithrandir" });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "Id", "Days", "IsActive", "Price" },
                values: new object[,]
                {
                    { new Guid("504002c4-da0a-4d65-bb3a-6228641d8fe2"), 15, true, 30m },
                    { new Guid("6f091623-da92-458c-a986-d10e2045ed72"), 45, true, 30m },
                    { new Guid("7d23463e-b613-4721-928c-5411711b25c3"), 30, true, 30m },
                    { new Guid("881200b5-76e0-488d-8bbc-df170ba4ca8c"), 50, true, 30m },
                    { new Guid("bdd124ab-ec00-4fcb-a995-6c1125b57609"), 7, true, 30m }
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
