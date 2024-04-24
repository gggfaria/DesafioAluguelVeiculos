using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBackEnd.Infra.Migrations
{
    public partial class updatedriverimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2024, 4, 24, 16, 32, 53, 171, DateTimeKind.Utc).AddTicks(9490),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 98, DateTimeKind.Utc).AddTicks(5690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "plans",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 16, 32, 53, 169, DateTimeKind.Utc).AddTicks(8610),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 94, DateTimeKind.Utc).AddTicks(9680));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "people",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 16, 32, 53, 171, DateTimeKind.Utc).AddTicks(3380),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 97, DateTimeKind.Utc).AddTicks(4130));

            migrationBuilder.AddColumn<long>(
                name: "ImageSize",
                table: "people",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageType",
                table: "people",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "motorcycles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 16, 32, 53, 169, DateTimeKind.Utc).AddTicks(7630),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 94, DateTimeKind.Utc).AddTicks(8450));

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "Discriminator", "IsActive", "Name", "Password", "Permission", "UserName" },
                values: new object[] { new Guid("502e6b00-e8f3-491b-882b-8e8827a172f0"), "Admin", true, "Galdalf", "eNi+nWQF12V2REazPSwJHgEIF8econx1akPJlg+wzYY=", "ADMIN", "mithrandir" });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "Id", "Days", "IsActive", "Price" },
                values: new object[,]
                {
                    { new Guid("21afe4af-6f24-4bad-bded-42c09bdd0991"), 7, true, 30m },
                    { new Guid("3854c080-19e7-4954-a925-291edda0dfd4"), 15, true, 30m },
                    { new Guid("66fce299-ad1d-476c-a28f-c75ff62b6c49"), 50, true, 30m },
                    { new Guid("d0dca5f3-bcb6-47e7-85ad-40da8099d741"), 45, true, 30m },
                    { new Guid("f86a3af0-6bab-4d9b-b2b5-ac14682c5257"), 30, true, 30m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "people",
                keyColumn: "Id",
                keyValue: new Guid("502e6b00-e8f3-491b-882b-8e8827a172f0"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: new Guid("21afe4af-6f24-4bad-bded-42c09bdd0991"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: new Guid("3854c080-19e7-4954-a925-291edda0dfd4"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: new Guid("66fce299-ad1d-476c-a28f-c75ff62b6c49"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: new Guid("d0dca5f3-bcb6-47e7-85ad-40da8099d741"));

            migrationBuilder.DeleteData(
                table: "plans",
                keyColumn: "Id",
                keyValue: new Guid("f86a3af0-6bab-4d9b-b2b5-ac14682c5257"));

            migrationBuilder.DropColumn(
                name: "ImageSize",
                table: "people");

            migrationBuilder.DropColumn(
                name: "ImageType",
                table: "people");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rental",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 98, DateTimeKind.Utc).AddTicks(5690),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 16, 32, 53, 171, DateTimeKind.Utc).AddTicks(9490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "plans",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 94, DateTimeKind.Utc).AddTicks(9680),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 16, 32, 53, 169, DateTimeKind.Utc).AddTicks(8610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "people",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 97, DateTimeKind.Utc).AddTicks(4130),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 16, 32, 53, 171, DateTimeKind.Utc).AddTicks(3380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "motorcycles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 3, 14, 26, 94, DateTimeKind.Utc).AddTicks(8450),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 24, 16, 32, 53, 169, DateTimeKind.Utc).AddTicks(7630));

            migrationBuilder.InsertData(
                table: "people",
                columns: new[] { "Id", "CreationDate", "Discriminator", "IsActive", "Name", "Password", "Permission", "UserName" },
                values: new object[] { new Guid("a56286f1-118f-4903-a2a7-80f364206e91"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "Galdalf", "eNi+nWQF12V2REazPSwJHgEIF8econx1akPJlg+wzYY=", "ADMIN", "mithrandir" });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "Id", "CreationDate", "Days", "IsActive", "Price" },
                values: new object[,]
                {
                    { new Guid("6be2c9b5-779e-4e9c-a677-ded226a27b93"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, true, 30m },
                    { new Guid("740e2c28-0693-4366-8e0d-56eaa55dcd5d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, true, 30m },
                    { new Guid("860f6314-0b56-4157-aee5-51fd7f353663"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, true, 30m },
                    { new Guid("b9edab01-daee-4655-b50e-f394a0c8d38c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, true, 30m },
                    { new Guid("bf005aa3-37c0-4561-b665-5bc21262ca92"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, true, 30m }
                });
        }
    }
}
