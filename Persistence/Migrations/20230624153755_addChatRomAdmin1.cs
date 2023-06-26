using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addChatRomAdmin1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2023, 6, 24, 19, 7, 54, 800, DateTimeKind.Local).AddTicks(3411),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 18, 50, 34, 263, DateTimeKind.Local).AddTicks(3765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 19, 7, 54, 799, DateTimeKind.Local).AddTicks(1879),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 18, 50, 34, 263, DateTimeKind.Local).AddTicks(1780));

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
                    MessageChat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeText = table.Column<int>(type: "int", nullable: false),
                    ChatRoomAdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 6, 24, 19, 7, 54, 799, DateTimeKind.Local).AddTicks(7683)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2023, 6, 24, 18, 50, 34, 263, DateTimeKind.Local).AddTicks(3765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 19, 7, 54, 800, DateTimeKind.Local).AddTicks(3411));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 24, 18, 50, 34, 263, DateTimeKind.Local).AddTicks(1780),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 24, 19, 7, 54, 799, DateTimeKind.Local).AddTicks(1879));

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
    }
}
