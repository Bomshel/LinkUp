using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApp.Migrations
{
    public partial class IsDeletedFlagInBlogPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BlogPosts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01B168FE-810B-432D-9010-233BA0B380E9",
                column: "ConcurrencyStamp",
                value: "72affc0a-f41d-438c-94d0-65053ff39bcd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "2d628c3b-735d-45f7-ac51-0531617acc22");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "3d7f6d6e-f139-416a-b045-4673dc5b814e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BlogPosts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01B168FE-810B-432D-9010-233BA0B380E9",
                column: "ConcurrencyStamp",
                value: "ffd00d36-647f-4c8e-b024-b9456312ac80");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "c6b105ea-f388-4f69-a94d-b304b829b0cb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7D9B7113-A8F8-4035-99A7-A20DD400F6A3",
                column: "ConcurrencyStamp",
                value: "0b2928cf-a8ef-4e02-9d07-72e9bfa8e4b8");
        }
    }
}
