using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeIsOnlineUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cab512b1-3279-4415-bea3-3c7d949bc50d");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "57bebda4-6ace-4d1b-a5a4-5ef0bc80d6f2", "1bcb1433-e26d-4548-b52d-1fe087fcbf15" });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57bebda4-6ace-4d1b-a5a4-5ef0bc80d6f2");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1bcb1433-e26d-4548-b52d-1fe087fcbf15");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 21, 19, 37, 57, 583, DateTimeKind.Local).AddTicks(5503),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 17, 10, 11, 29, 72, DateTimeKind.Local).AddTicks(2010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 21, 19, 37, 57, 583, DateTimeKind.Local).AddTicks(3318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 17, 10, 11, 29, 71, DateTimeKind.Local).AddTicks(8431));

            migrationBuilder.AlterColumn<bool>(
                name: "IsOnline",
                schema: "dbo",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2023, 6, 17, 10, 11, 29, 72, DateTimeKind.Local).AddTicks(2010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 21, 19, 37, 57, 583, DateTimeKind.Local).AddTicks(5503));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 10, 11, 29, 71, DateTimeKind.Local).AddTicks(8431),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 21, 19, 37, 57, 583, DateTimeKind.Local).AddTicks(3318));

            migrationBuilder.AlterColumn<bool>(
                name: "IsOnline",
                schema: "dbo",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57bebda4-6ace-4d1b-a5a4-5ef0bc80d6f2", null, "admin", "ADMIN" },
                    { "cab512b1-3279-4415-bea3-3c7d949bc50d", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarImage", "Branche", "CodeDispo", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "IsOnline", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1bcb1433-e26d-4548-b52d-1fe087fcbf15", 0, null, null, null, "7cf1e99d-fcb1-4140-b0c3-656049c0b526", null, "admin@gmail.com", false, null, null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEPbFUQygFh2eqKaR+Ty5d0Z8WFjsl9ouUpk26tIQmPLkAyvWXZXHKPNR+lJYJH1CKA==", null, false, "a94289a2-9f9c-4082-b1e0-d0ca811da74f", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "57bebda4-6ace-4d1b-a5a4-5ef0bc80d6f2", "1bcb1433-e26d-4548-b52d-1fe087fcbf15" });
        }
    }
}
