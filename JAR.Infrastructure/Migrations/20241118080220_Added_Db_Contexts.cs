using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_Db_Contexts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferencesUsers_AspNetUsers_UserId",
                table: "ConferencesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ConferencesUsers_AspNetUsers_UserId1",
                table: "ConferencesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_SenderId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Room_RoomId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_AspNetUsers_AdminId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomUser_AspNetUsers_UserId",
                table: "RoomUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomUser_Room_RoomId",
                table: "RoomUser");

            migrationBuilder.DropIndex(
                name: "IX_ConferencesUsers_UserId1",
                table: "ConferencesUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomUser",
                table: "RoomUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ConferencesUsers");

            migrationBuilder.RenameTable(
                name: "RoomUser",
                newName: "RoomsUsers");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_RoomUser_UserId",
                table: "RoomsUsers",
                newName: "IX_RoomsUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Room_AdminId",
                table: "Rooms",
                newName: "IX_Rooms_AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_SenderId",
                table: "Messages",
                newName: "IX_Messages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_RoomId",
                table: "Messages",
                newName: "IX_Messages_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomsUsers",
                table: "RoomsUsers",
                columns: new[] { "RoomId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2656a468-b215-4b17-865d-240a63b0d5cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96852881-88c0-4092-aed7-88ca735f0f4c", "AQAAAAIAAYagAAAAEB76t6n0i7TsTA1yKdIWbTqFaXKd+QUhoj2NVHua+Ez5+uefHE6zudy1QdfDeZ3efA==", "e09369b6-6c95-4cf9-a284-b997719028c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71811921-1918-4043-90b9-20f2522f315b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95d0e263-2f6c-4278-89bb-4c4a55aefbf9", "AQAAAAIAAYagAAAAEHICajQjZVmOYmaDp4S84BL3+NQ+osq3mL1U4fplODKJchXfTiP1ipuJ9pVyPa/Qmg==", "c07e6bb3-2940-472f-882d-2761bd445ddc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80277b99-4cab-4ff1-8084-6d0a5df3e787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "899f4136-5b94-4b26-861d-212c1004e18d", "AQAAAAIAAYagAAAAEJJAtomAUzj7+lVVf1Fdb8h6UGGiabr6U6gr1XiDYohF0jRl3BepClEf7CMtDAlbMg==", "0036f698-e6cc-41a0-b17f-c9738361509d" });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumns: new[] { "JobOfferId", "UserId" },
                keyValues: new object[] { 1, "2656a468-b215-4b17-865d-240a63b0d5cf" },
                column: "AppliedOn",
                value: new DateTime(2024, 11, 18, 8, 2, 19, 808, DateTimeKind.Utc).AddTicks(554));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 18, 8, 2, 19, 597, DateTimeKind.Utc).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 18, 8, 2, 19, 597, DateTimeKind.Utc).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 18, 8, 2, 19, 597, DateTimeKind.Utc).AddTicks(6854));

            migrationBuilder.AddForeignKey(
                name: "FK_ConferencesUsers_AspNetUsers_UserId",
                table: "ConferencesUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Rooms_RoomId",
                table: "Messages",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_AspNetUsers_AdminId",
                table: "Rooms",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsUsers_AspNetUsers_UserId",
                table: "RoomsUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsUsers_Rooms_RoomId",
                table: "RoomsUsers",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferencesUsers_AspNetUsers_UserId",
                table: "ConferencesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Rooms_RoomId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_AspNetUsers_AdminId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsUsers_AspNetUsers_UserId",
                table: "RoomsUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsUsers_Rooms_RoomId",
                table: "RoomsUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomsUsers",
                table: "RoomsUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "RoomsUsers",
                newName: "RoomUser");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_RoomsUsers_UserId",
                table: "RoomUser",
                newName: "IX_RoomUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_AdminId",
                table: "Room",
                newName: "IX_Room_AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderId",
                table: "Message",
                newName: "IX_Message_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_RoomId",
                table: "Message",
                newName: "IX_Message_RoomId");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ConferencesUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomUser",
                table: "RoomUser",
                columns: new[] { "RoomId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_SenderId",
                table: "Message",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Room_RoomId",
                table: "Message",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_AspNetUsers_AdminId",
                table: "Room",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomUser_AspNetUsers_UserId",
                table: "RoomUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomUser_Room_RoomId",
                table: "RoomUser",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");
        }
    }
}
