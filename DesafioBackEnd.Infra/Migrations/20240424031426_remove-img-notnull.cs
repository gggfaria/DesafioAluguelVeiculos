using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBackEnd.Infra.Migrations
{
    public partial class removeimgnotnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "people",
                keyColumn: "Id",
                keyValue: new Guid("150055ad-6107-4e89-a2df-8956ec294915"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: new Guid("1f84231e-67df-4a2a-ba79-7b600c3add04"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: new Guid("66364855-b556-48b3-a25c-b92a9d8377dd"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: new Guid("97cbdd38-e1ce-4972-b6b7-ab2fb2b2c651"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: new Guid("a68ebbfa-1b53-49d6-b06d-5c59c79b4eca"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: new Guid("b10babbb-437d-409d-b109-9756c1bb59a9"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rental",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 98, DateTimeKind.Utc).AddTicks(5690),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 0, 13, 48, 771, DateTimeKind.Utc).AddTicks(7720));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "plans",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 94, DateTimeKind.Utc).AddTicks(9680),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 0, 13, 48, 769, DateTimeKind.Utc).AddTicks(8340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "people",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 97, DateTimeKind.Utc).AddTicks(4130),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 0, 13, 48, 771, DateTimeKind.Utc).AddTicks(2110));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "motorcycles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 94, DateTimeKind.Utc).AddTicks(8450),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 0, 13, 48, 769, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "Discriminator", "IsActive", "Name", "Password", "Permission", "UserName" },
                values: new object[] { new Guid("a56286f1-118f-4903-a2a7-80f364206e91"), "Admin", true, "Galdalf", "eNi+nWQF12V2REazPSwJHgEIF8econx1akPJlg+wzYY=", "ADMIN", "mithrandir" });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "Id", "Days", "IsActive", "Price" },
                values: new object[,]
                {
                    { new Guid("6be2c9b5-779e-4e9c-a677-ded226a27b93"), 15, true, 30m },
                    { new Guid("740e2c28-0693-4366-8e0d-56eaa55dcd5d"), 30, true, 30m },
                    { new Guid("860f6314-0b56-4157-aee5-51fd7f353663"), 45, true, 30m },
                    { new Guid("b9edab01-daee-4655-b50e-f394a0c8d38c"), 7, true, 30m },
                    { new Guid("bf005aa3-37c0-4561-b665-5bc21262ca92"), 50, true, 30m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "people",
                keyColumn: "Id",
                keyValue: new Guid("a56286f1-118f-4903-a2a7-80f364206e91"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: new Guid("6be2c9b5-779e-4e9c-a677-ded226a27b93"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: new Guid("740e2c28-0693-4366-8e0d-56eaa55dcd5d"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: new Guid("860f6314-0b56-4157-aee5-51fd7f353663"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: new Guid("b9edab01-daee-4655-b50e-f394a0c8d38c"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: new Guid("bf005aa3-37c0-4561-b665-5bc21262ca92"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rental",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 0, 13, 48, 771, DateTimeKind.Utc).AddTicks(7720),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 98, DateTimeKind.Utc).AddTicks(5690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "plans",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 0, 13, 48, 769, DateTimeKind.Utc).AddTicks(8340),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 94, DateTimeKind.Utc).AddTicks(9680));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "people",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 0, 13, 48, 771, DateTimeKind.Utc).AddTicks(2110),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 97, DateTimeKind.Utc).AddTicks(4130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "motorcycles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 0, 13, 48, 769, DateTimeKind.Utc).AddTicks(7410),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 94, DateTimeKind.Utc).AddTicks(8450));

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "CreationDate", "Discriminator", "IsActive", "Name", "Password", "Permission", "UserName" },
                values: new object[] { new Guid("150055ad-6107-4e89-a2df-8956ec294915"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "Galdalf", "eNi+nWQF12V2REazPSwJHgEIF8econx1akPJlg+wzYY=", "ADMIN", "mithrandir" });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "Id", "CreationDate", "Days", "IsActive", "Price" },
                values: new object[,]
                {
                    { new Guid("1f84231e-67df-4a2a-ba79-7b600c3add04"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, true, 30m },
                    { new Guid("66364855-b556-48b3-a25c-b92a9d8377dd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, true, 30m },
                    { new Guid("97cbdd38-e1ce-4972-b6b7-ab2fb2b2c651"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, true, 30m },
                    { new Guid("a68ebbfa-1b53-49d6-b06d-5c59c79b4eca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, true, 30m },
                    { new Guid("b10babbb-437d-409d-b109-9756c1bb59a9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, true, 30m }
                });
        }
    }
}
