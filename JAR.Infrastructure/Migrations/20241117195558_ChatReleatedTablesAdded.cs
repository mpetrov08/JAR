using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChatReleatedTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferencesUsers_AspNetUsers_UserId",
                table: "ConferencesUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ConferencesUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Room Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Room`s Name"),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign key of room`s Admin"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Checks if the Room has been deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_AspNetUsers_AdminId",
                        column: x => x.AdminId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Message Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Message Content"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Message Timestamp"),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign key of user(sender)"),
                    RoomId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key of room"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Checks if the Message has been deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RoomUser",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key of room"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign key of user")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomUser", x => new { x.RoomId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RoomUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomUser_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87af9c54-5a96-46d7-b3ba-8cac072c29fa", "AQAAAAIAAYagAAAAECKpAqHmX0awU4KmsO9nQjcBwDmMPbGCs+4cx8LyoRQh2ScYxJ2iQmnDce0UO23FuA==", "96de102c-3b57-41be-a7f1-3d2834f4493b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "429b8195-6ebf-448e-82e8-19b07c737538", "AQAAAAIAAYagAAAAENzh1XW6iOxqv4Zp22TxTfAlajqTqQi+55l7oaqq5O2JZJwil3n6URL9ZZok2y+UZw==", "0b22105e-c6ef-44a3-93ec-d903ca1a1d78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ada5dc3c-3ebd-46d3-af4c-8ceea5d41667", "AQAAAAIAAYagAAAAEAVUzhiGfEAyVZZVwsbPtpEeX5/ay/GN/IPc73VbHxeQaOtgKUpvRrz/OKRBryGmrQ==", "486b8b61-e35c-4850-9d90-967679467b0e" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 17, 19, 55, 58, 152, DateTimeKind.Utc).AddTicks(8253));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 17, 19, 55, 58, 24, DateTimeKind.Utc).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 17, 19, 55, 58, 24, DateTimeKind.Utc).AddTicks(7794));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 17, 19, 55, 58, 24, DateTimeKind.Utc).AddTicks(7798));

            migrationBuilder.CreateIndex(
                name: "IX_ConferencesUsers_UserId1",
                table: "ConferencesUsers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Message_RoomId",
                table: "Message",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderId",
                table: "Message",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_AdminId",
                table: "Room",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomUser_UserId",
                table: "RoomUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConferencesUsers_AspNetUsers_UserId",
                table: "ConferencesUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConferencesUsers_AspNetUsers_UserId1",
                table: "ConferencesUsers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferencesUsers_AspNetUsers_UserId",
                table: "ConferencesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ConferencesUsers_AspNetUsers_UserId1",
                table: "ConferencesUsers");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "RoomUser");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropIndex(
                name: "IX_ConferencesUsers_UserId1",
                table: "ConferencesUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ConferencesUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e54584b-256e-468b-8216-881e79ea0bd4", "AQAAAAIAAYagAAAAELsDhCDN2jeCDICKd5winnEfZyEXNHKJ0Btc2UO6M0vHDkYUCTgaTQ5ZaR66yHchJw==", "69387a9b-9cc4-436f-b9a1-1f19d0b87188" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6377156d-934e-4196-8b49-61140ae06282", "AQAAAAIAAYagAAAAEH58PzLoGeqHNrs64G+/neiFN2Vfj16wn18se8MkwgAOT6OeyZ07hn6Lm/KHmA8ZeQ==", "b81add34-e608-4b2c-8704-353116c1d1ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb934af4-d68f-400d-ba63-8083d612bf66", "AQAAAAIAAYagAAAAEJwyA4n9CYMstwM8iioDEDLV0dWpogxazJN1/D0wa2djl7w2ICSo5Y6xRkEHQ+Z6lA==", "f8033dcd-fde5-47a4-8c07-2359a4ffcdf1" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 16, 10, 2, 21, 554, DateTimeKind.Utc).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 16, 10, 2, 21, 428, DateTimeKind.Utc).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 16, 10, 2, 21, 428, DateTimeKind.Utc).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 16, 10, 2, 21, 428, DateTimeKind.Utc).AddTicks(8523));

            migrationBuilder.AddForeignKey(
                name: "FK_ConferencesUsers_AspNetUsers_UserId",
                table: "ConferencesUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
