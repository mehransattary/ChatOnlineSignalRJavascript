using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeuserIsOnline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66696d61-e9b0-46cd-ac82-6a13a7f555bb");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "09bcb019-988f-4914-8b19-b2733f895c60", "02e5e4b9-4a58-4cc7-bc54-5287aac8fe25" });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09bcb019-988f-4914-8b19-b2733f895c60");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02e5e4b9-4a58-4cc7-bc54-5287aac8fe25");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 15, 21, 48, 44, 318, DateTimeKind.Local).AddTicks(9039),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 22, 46, 26, 172, DateTimeKind.Local).AddTicks(6777));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 15, 21, 48, 44, 318, DateTimeKind.Local).AddTicks(5731),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 22, 46, 26, 172, DateTimeKind.Local).AddTicks(4635));

            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                schema: "dbo",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IsOnline",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 22, 46, 26, 172, DateTimeKind.Local).AddTicks(6777),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 15, 21, 48, 44, 318, DateTimeKind.Local).AddTicks(9039));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 22, 46, 26, 172, DateTimeKind.Local).AddTicks(4635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 15, 21, 48, 44, 318, DateTimeKind.Local).AddTicks(5731));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09bcb019-988f-4914-8b19-b2733f895c60", null, "admin", "ADMIN" },
                    { "66696d61-e9b0-46cd-ac82-6a13a7f555bb", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarImage", "Branche", "CodeDispo", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02e5e4b9-4a58-4cc7-bc54-5287aac8fe25", 0, null, null, null, "8a5ed224-98f5-4a1c-bd38-d7812d97a3a3", null, "admin@gmail.com", false, null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEM4BKMhp3ulPE+Nl1+RVG7kepsIMRVHcuSk/lBFNnNPkU0bc66zSDuUaEyx2UrNTdA==", null, false, "966f6de3-7e43-4e0f-98b8-a36468f927be", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "09bcb019-988f-4914-8b19-b2733f895c60", "02e5e4b9-4a58-4cc7-bc54-5287aac8fe25" });
        }
    }
}
