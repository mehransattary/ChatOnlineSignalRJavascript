using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addChatRomAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67db148b-6571-484b-bc10-238ce4ff7c6e");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c94c08bb-0ba9-499d-928f-b50ad5273ef6", "a4382014-5ff6-417f-9216-c6b0ab833a25" });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c94c08bb-0ba9-499d-928f-b50ad5273ef6");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4382014-5ff6-417f-9216-c6b0ab833a25");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 18, 50, 34, 263, DateTimeKind.Local).AddTicks(3765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 21, 19, 37, 57, 583, DateTimeKind.Local).AddTicks(5503));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 18, 50, 34, 263, DateTimeKind.Local).AddTicks(1780),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 21, 19, 37, 57, 583, DateTimeKind.Local).AddTicks(3318));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "590b7814-1ab1-49a9-a73c-22ee3cb67055", null, "user", "USER" },
                    { "d17940a4-f85d-4d8d-9544-e7053dfb6cbb", null, "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarImage", "Branche", "CodeDispo", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "IsOnline", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f7b248f2-1fe5-49a0-b8a4-1ffbf15cd63f", 0, null, null, null, "2e5ec523-19ba-4a8f-937e-fe2c260ea821", null, "admin@gmail.com", false, null, false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEFcWLDWn++hTaWGXuD0SllYon/CZgNIOOnTY5Fj4ImZUi99CWrubXeKiTVdXuQ2Yfg==", null, false, "719a1cb3-6f6a-45b9-a7ba-a09a9335e7a7", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d17940a4-f85d-4d8d-9544-e7053dfb6cbb", "f7b248f2-1fe5-49a0-b8a4-1ffbf15cd63f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "590b7814-1ab1-49a9-a73c-22ee3cb67055");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d17940a4-f85d-4d8d-9544-e7053dfb6cbb", "f7b248f2-1fe5-49a0-b8a4-1ffbf15cd63f" });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d17940a4-f85d-4d8d-9544-e7053dfb6cbb");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f7b248f2-1fe5-49a0-b8a4-1ffbf15cd63f");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 21, 19, 37, 57, 583, DateTimeKind.Local).AddTicks(5503),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 18, 50, 34, 263, DateTimeKind.Local).AddTicks(3765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 21, 19, 37, 57, 583, DateTimeKind.Local).AddTicks(3318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 18, 50, 34, 263, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67db148b-6571-484b-bc10-238ce4ff7c6e", null, "user", "USER" },
                    { "c94c08bb-0ba9-499d-928f-b50ad5273ef6", null, "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarImage", "Branche", "CodeDispo", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "IsOnline", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a4382014-5ff6-417f-9216-c6b0ab833a25", 0, null, null, null, "31c21a2d-95ce-4fb3-9699-63dff9774769", null, "admin@gmail.com", false, null, false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEO/zHz7cCCXXC+OEeAJ/Ztifp8j+Hv4Jq5V3zRyHTIHTrgP+gdFPtdBwXAUukDC5Og==", null, false, "ea4dc937-5771-401e-8e50-7e2b1f4a74b3", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c94c08bb-0ba9-499d-928f-b50ad5273ef6", "a4382014-5ff6-417f-9216-c6b0ab833a25" });
        }
    }
}
