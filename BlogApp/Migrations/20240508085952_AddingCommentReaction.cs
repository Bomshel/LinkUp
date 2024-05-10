using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApp.Migrations
{
    public partial class AddingCommentReaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentReactions",
                columns: table => new
                {
                    ReactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsUpvote = table.Column<bool>(nullable: false),
                    CommentId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReactions", x => x.ReactionId);
                    table.ForeignKey(
                        name: "FK_CommentReactions_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentReactions_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01B168FE-810B-432D-9010-233BA0B380E9",
                column: "ConcurrencyStamp",
                value: "4d908b25-c84c-40cf-894e-aa03195a5797");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "03d3e3bc-0690-46cd-be42-66848c922d86");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "9a4974a5-a014-4029-921e-2560218a8935");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReactions_AuthorId",
                table: "CommentReactions",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReactions_CommentId",
                table: "CommentReactions",
                column: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentReactions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01B168FE-810B-432D-9010-233BA0B380E9",
                column: "ConcurrencyStamp",
                value: "0265491c-520d-4c91-9fb7-7e45abe10e0d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "15721766-0913-4e17-851e-31358a83911f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "edd9d4d0-0161-4784-9764-a7133717979d");
        }
    }
}
