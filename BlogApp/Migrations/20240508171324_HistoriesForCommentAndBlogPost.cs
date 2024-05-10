using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApp.Migrations
{
    public partial class HistoriesForCommentAndBlogPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BlogPostEditHistories",
                columns: table => new
                {
                    BlogPostEditHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogPostId = table.Column<int>(nullable: false),
                    OriginalTitle = table.Column<string>(nullable: true),
                    OriginalBody = table.Column<string>(nullable: true),
                    EditedTitle = table.Column<string>(nullable: true),
                    EditedBody = table.Column<string>(nullable: true),
                    OriginalTimestamp = table.Column<DateTime>(nullable: false),
                    EditedTimestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostEditHistories", x => x.BlogPostEditHistoryId);
                    table.ForeignKey(
                        name: "FK_BlogPostEditHistories_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPosts",
                        principalColumn: "BlogPostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentEditHistories",
                columns: table => new
                {
                    CommentEditHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(nullable: false),
                    OriginalContent = table.Column<string>(nullable: true),
                    EditedContent = table.Column<string>(nullable: true),
                    OriginalTimestamp = table.Column<DateTime>(nullable: false),
                    EditedTimestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentEditHistories", x => x.CommentEditHistoryId);
                    table.ForeignKey(
                        name: "FK_CommentEditHistories_Comments_CommentId",
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
                value: "dc745f58-002f-4d7f-bfbd-049c6a81805c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "795d8bb4-0364-4792-b475-cd171f78697c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "64e90d41-d45b-44ab-9219-b6b072362302");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostEditHistories_BlogPostId",
                table: "BlogPostEditHistories",
                column: "BlogPostId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentEditHistories_CommentId",
                table: "CommentEditHistories",
                column: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostEditHistories");

            migrationBuilder.DropTable(
                name: "CommentEditHistories");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01B168FE-810B-432D-9010-233BA0B380E9",
                column: "ConcurrencyStamp",
                value: "0a82d026-8c7f-4014-82cd-b8b1d1a6476e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "76e67678-ad57-40e9-85cd-ded9ffebb878");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "c0f31f1a-8d28-45de-aa4c-c9e41480ed57");
        }
    }
}
