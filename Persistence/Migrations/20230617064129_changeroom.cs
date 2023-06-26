using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b258d57-b99f-408f-884e-eb959bad944e");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "558006ae-2f60-420e-97e5-6320fd3a3c1d", "6f9ea7cb-39d5-4d83-9c68-e05f96f20de8" });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "558006ae-2f60-420e-97e5-6320fd3a3c1d");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f9ea7cb-39d5-4d83-9c68-e05f96f20de8");

            migrationBuilder.DropColumn(
                name: "UserConnectionId",
                schema: "dbo",
                table: "ChatRooms");

            migrationBuilder.RenameColumn(
                name: "AdminConnectionId",
                schema: "dbo",
                table: "ChatRooms",
                newName: "UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 10, 11, 29, 72, DateTimeKind.Local).AddTicks(2010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 15, 21, 48, 44, 318, DateTimeKind.Local).AddTicks(9039));

            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                schema: "dbo",
                table: "ChatRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 10, 11, 29, 71, DateTimeKind.Local).AddTicks(8431),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 15, 21, 48, 44, 318, DateTimeKind.Local).AddTicks(5731));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AdminId",
                schema: "dbo",
                table: "ChatRooms");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "ChatRooms",
                newName: "AdminConnectionId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 15, 21, 48, 44, 318, DateTimeKind.Local).AddTicks(9039),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 17, 10, 11, 29, 72, DateTimeKind.Local).AddTicks(2010));

            migrationBuilder.AddColumn<string>(
                name: "UserConnectionId",
                schema: "dbo",
                table: "ChatRooms",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 15, 21, 48, 44, 318, DateTimeKind.Local).AddTicks(5731),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 17, 10, 11, 29, 71, DateTimeKind.Local).AddTicks(8431));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "558006ae-2f60-420e-97e5-6320fd3a3c1d", null, "admin", "ADMIN" },
                    { "6b258d57-b99f-408f-884e-eb959bad944e", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarImage", "Branche", "CodeDispo", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "IsOnline", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6f9ea7cb-39d5-4d83-9c68-e05f96f20de8", 0, null, null, null, "a160ba66-edbf-47ae-9ad2-0b8e121055f8", null, "admin@gmail.com", false, null, null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEOXY4SXvPg+MRTUvMs0cQVcQXalWp7fT26MVhOKMPDDkGdRkiunrpPRsOjFxmdWodQ==", null, false, "f412ac5a-d81e-4474-8ec9-72a6eb9f6aec", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "558006ae-2f60-420e-97e5-6320fd3a3c1d", "6f9ea7cb-39d5-4d83-9c68-e05f96f20de8" });
        }
    }
}
