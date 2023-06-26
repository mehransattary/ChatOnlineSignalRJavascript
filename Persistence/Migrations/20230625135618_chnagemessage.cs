using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class chnagemessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_ChatRoomsAdmin_ChatRoomAdminId",
                schema: "dbo",
                table: "ChatMessages");

            migrationBuilder.DropTable(
                name: "ChatMessagesAdmin",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ChatRoomsAdmin",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_ChatRoomAdminId",
                schema: "dbo",
                table: "ChatMessages");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55a072eb-b4d7-4a84-9ecd-9fd1c41144dc");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e2a1b00-89cb-4c0f-864a-e8f71e968203", "a3c66579-effb-443d-8948-10477b82e2ec" });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e2a1b00-89cb-4c0f-864a-e8f71e968203");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3c66579-effb-443d-8948-10477b82e2ec");

            migrationBuilder.DropColumn(
                name: "ChatRoomAdminId",
                schema: "dbo",
                table: "ChatMessages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 17, 26, 18, 581, DateTimeKind.Local).AddTicks(4458),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 19, 7, 54, 800, DateTimeKind.Local).AddTicks(3411));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 25, 17, 26, 18, 581, DateTimeKind.Local).AddTicks(2164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 19, 7, 54, 799, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                schema: "dbo",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2bc462a0-1165-4e04-809b-fe3b5076de02", null, "user", "USER" },
                    { "3f1488e3-381b-4dea-b13c-73966ffb2f90", null, "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarImage", "Branche", "CodeDispo", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "IsAdmin", "IsOnline", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c6b5b101-1365-4ba1-ba8d-bc322f852475", 0, null, null, null, "01854c41-9920-4870-9d8a-0cf053b5edf0", null, "admin@gmail.com", false, null, false, false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEDZzZqchW9CXNspOGFDaaW6ZMkUGT1ShSctQJSUG9LiNvCceGT+w8BKjFhevLz5jTQ==", null, false, "cfe125b6-048f-46ba-8057-bdf30a5c3397", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3f1488e3-381b-4dea-b13c-73966ffb2f90", "c6b5b101-1365-4ba1-ba8d-bc322f852475" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bc462a0-1165-4e04-809b-fe3b5076de02");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3f1488e3-381b-4dea-b13c-73966ffb2f90", "c6b5b101-1365-4ba1-ba8d-bc322f852475" });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f1488e3-381b-4dea-b13c-73966ffb2f90");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6b5b101-1365-4ba1-ba8d-bc322f852475");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 19, 7, 54, 800, DateTimeKind.Local).AddTicks(3411),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 25, 17, 26, 18, 581, DateTimeKind.Local).AddTicks(4458));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 19, 7, 54, 799, DateTimeKind.Local).AddTicks(1879),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 25, 17, 26, 18, 581, DateTimeKind.Local).AddTicks(2164));

            migrationBuilder.AddColumn<Guid>(
                name: "ChatRoomAdminId",
                schema: "dbo",
                table: "ChatMessages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChatRoomsAdmin",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Admin1Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin2Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 6, 24, 19, 7, 54, 800, DateTimeKind.Local).AddTicks(7157)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoomsAdmin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessagesAdmin",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChatRoomAdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 6, 24, 19, 7, 54, 799, DateTimeKind.Local).AddTicks(7683)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MessageChat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeText = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessagesAdmin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessagesAdmin_AspNetUsers_AdminId",
                        column: x => x.AdminId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatMessagesAdmin_ChatRoomsAdmin_ChatRoomAdminId",
                        column: x => x.ChatRoomAdminId,
                        principalSchema: "dbo",
                        principalTable: "ChatRoomsAdmin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e2a1b00-89cb-4c0f-864a-e8f71e968203", null, "admin", "ADMIN" },
                    { "55a072eb-b4d7-4a84-9ecd-9fd1c41144dc", null, "user", "USER" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarImage", "Branche", "CodeDispo", "ConcurrencyStamp", "ConnectionId", "Email", "EmailConfirmed", "FullName", "IsOnline", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a3c66579-effb-443d-8948-10477b82e2ec", 0, null, null, null, "404364c5-8166-405b-836f-3a98c4e11ac6", null, "admin@gmail.com", false, null, false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEAJQtD374ySvKQZ34++jDGAv3s443pNfsdrUdDMnG+craWfakQfiiWlJmXzFBbf8CQ==", null, false, "c0eef82d-4695-416b-bf7a-be0c1ce8891a", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0e2a1b00-89cb-4c0f-864a-e8f71e968203", "a3c66579-effb-443d-8948-10477b82e2ec" });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ChatRoomAdminId",
                schema: "dbo",
                table: "ChatMessages",
                column: "ChatRoomAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessagesAdmin_AdminId",
                schema: "dbo",
                table: "ChatMessagesAdmin",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessagesAdmin_ChatRoomAdminId",
                schema: "dbo",
                table: "ChatMessagesAdmin",
                column: "ChatRoomAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_ChatRoomsAdmin_ChatRoomAdminId",
                schema: "dbo",
                table: "ChatMessages",
                column: "ChatRoomAdminId",
                principalSchema: "dbo",
                principalTable: "ChatRoomsAdmin",
                principalColumn: "Id");
        }
    }
}
