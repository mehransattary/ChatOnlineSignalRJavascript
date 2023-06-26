using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changechatmessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_FromId",
                schema: "dbo",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_ToId",
                schema: "dbo",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_FromId",
                schema: "dbo",
                table: "ChatMessages");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9d68b60-152b-4e76-9064-213928cb0891");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0d0a4dd1-2614-4dd3-811f-6a7c21bb0d98", "42375027-9a81-4e3a-bef0-00c58ea8f083" });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d0a4dd1-2614-4dd3-811f-6a7c21bb0d98");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42375027-9a81-4e3a-bef0-00c58ea8f083");

            migrationBuilder.DropColumn(
                name: "FromId",
                schema: "dbo",
                table: "ChatMessages");

            migrationBuilder.RenameColumn(
                name: "ToId",
                schema: "dbo",
                table: "ChatMessages",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_ToId",
                schema: "dbo",
                table: "ChatMessages",
                newName: "IX_ChatMessages_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 22, 46, 26, 172, DateTimeKind.Local).AddTicks(6777),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 18, 46, 6, 358, DateTimeKind.Local).AddTicks(8098));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 22, 46, 26, 172, DateTimeKind.Local).AddTicks(4635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 18, 46, 6, 358, DateTimeKind.Local).AddTicks(5795));

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                schema: "dbo",
                table: "ChatMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_UserId",
                schema: "dbo",
                table: "ChatMessages",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_UserId",
                schema: "dbo",
                table: "ChatMessages");

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

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                schema: "dbo",
                table: "ChatMessages");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "ChatMessages",
                newName: "ToId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_UserId",
                schema: "dbo",
                table: "ChatMessages",
                newName: "IX_ChatMessages_ToId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 18, 46, 6, 358, DateTimeKind.Local).AddTicks(8098),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 22, 46, 26, 172, DateTimeKind.Local).AddTicks(6777));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 8, 18, 46, 6, 358, DateTimeKind.Local).AddTicks(5795),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 8, 22, 46, 26, 172, DateTimeKind.Local).AddTicks(4635));

            migrationBuilder.AddColumn<string>(
                name: "FromId",
                schema: "dbo",
                table: "ChatMessages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d0a4dd1-2614-4dd3-811f-6a7c21bb0d98", null, "admin", "ADMIN" },
                    { "b9d68b60-152b-4e76-9064-213928cb0891", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarImage", "Branche", "CodeDispo", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "42375027-9a81-4e3a-bef0-00c58ea8f083", 0, null, null, null, "0b2e1063-eb67-4ac6-89da-a7b47fdbe112", null, "admin@gmail.com", false, null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEDa7G3aRowZf53qiRS2iJB5IqoF/MQ4BNeN4iOKm7pc9p9taHwmnqzU68MV0g+oOpA==", null, false, "f6fa561e-efa3-4e6e-ba3e-e2ca9baaf01b", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0d0a4dd1-2614-4dd3-811f-6a7c21bb0d98", "42375027-9a81-4e3a-bef0-00c58ea8f083" });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_FromId",
                schema: "dbo",
                table: "ChatMessages",
                column: "FromId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_FromId",
                schema: "dbo",
                table: "ChatMessages",
                column: "FromId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_ToId",
                schema: "dbo",
                table: "ChatMessages",
                column: "ToId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
