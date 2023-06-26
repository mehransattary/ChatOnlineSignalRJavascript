using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bd9c7b9-5194-416e-a641-b77997fc28b4");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ecc0d71d-0ea1-4d65-ab38-ef4d38fa1920", "48154d60-44f6-45c4-ac62-4633cbfa5db1" });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecc0d71d-0ea1-4d65-ab38-ef4d38fa1920");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "48154d60-44f6-45c4-ac62-4633cbfa5db1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 14, 20, 6, 419, DateTimeKind.Local).AddTicks(2381),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 19, 26, 28, 813, DateTimeKind.Local).AddTicks(236));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 14, 20, 6, 418, DateTimeKind.Local).AddTicks(8464),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 7, 19, 26, 28, 812, DateTimeKind.Local).AddTicks(5656));

            migrationBuilder.AddColumn<string>(
                name: "CodeDispo",
                schema: "dbo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9da1a6e7-0285-42b0-8319-77be18d890cc", null, "user", "USER" },
                    { "eabcafc4-a768-4faf-b879-e4200f5bca3e", null, "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarImage", "Branche", "CodeDispo", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "38bc0695-4aa6-49bb-bb61-cbf3d2aa76a9", 0, null, null, null, "a4304d77-0d85-4f40-995e-d158b0787075", null, "admin@gmail.com", false, null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKdFfdOS2BR2E9AblmgJvday1GVwkL4NwCW80W5PNE2cRECYXqNx7jdf0jLgaJW8xg==", null, false, "501b0a75-07dd-4a1f-b0d3-28dddeece83f", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "eabcafc4-a768-4faf-b879-e4200f5bca3e", "38bc0695-4aa6-49bb-bb61-cbf3d2aa76a9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9da1a6e7-0285-42b0-8319-77be18d890cc");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eabcafc4-a768-4faf-b879-e4200f5bca3e", "38bc0695-4aa6-49bb-bb61-cbf3d2aa76a9" });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eabcafc4-a768-4faf-b879-e4200f5bca3e");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38bc0695-4aa6-49bb-bb61-cbf3d2aa76a9");

            migrationBuilder.DropColumn(
                name: "CodeDispo",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 19, 26, 28, 813, DateTimeKind.Local).AddTicks(236),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 14, 20, 6, 419, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 7, 19, 26, 28, 812, DateTimeKind.Local).AddTicks(5656),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 14, 20, 6, 418, DateTimeKind.Local).AddTicks(8464));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2bd9c7b9-5194-416e-a641-b77997fc28b4", null, "user", "USER" },
                    { "ecc0d71d-0ea1-4d65-ab38-ef4d38fa1920", null, "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarImage", "Branche", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "48154d60-44f6-45c4-ac62-4633cbfa5db1", 0, null, null, "a5740276-086f-4e50-9049-786b7f82efc8", null, "admin@gmail.com", false, null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEBBwu8EEV+OpfuoTTBZPww7nVQjjyXRCDyo8GTWm0ejGqbzX34OcgQ2Bb8gdD7+o8A==", null, false, "a37c8131-7a40-4300-a4b1-aefe7017e0ad", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ecc0d71d-0ea1-4d65-ab38-ef4d38fa1920", "48154d60-44f6-45c4-ac62-4633cbfa5db1" });
        }
    }
}
