using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoomsAndStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-000000000105"), "105", "Лабораторія 105" },
                    { new Guid("11111111-1111-1111-1111-000000000201"), "201", "Аудиторія 201" },
                    { new Guid("11111111-1111-1111-1111-000000000303"), "303", "Аудиторія 303" },
                    { new Guid("11111111-1111-1111-1111-000000000402"), "402", "Аудиторія 402" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "GroupName" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-000000000001"), "Іван Петренко", "КН-21" },
                    { new Guid("22222222-2222-2222-2222-000000000002"), "Марія Коваленко", "КН-21" },
                    { new Guid("22222222-2222-2222-2222-000000000003"), "Олег Шевчук", "ІПЗ-22" },
                    { new Guid("22222222-2222-2222-2222-000000000004"), "Софія Бондаренко", "ІПЗ-22" },
                    { new Guid("22222222-2222-2222-2222-000000000005"), "Андрій Мельник", "КБ-23" },
                    { new Guid("22222222-2222-2222-2222-000000000006"), "Наталія Ткаченко", "КБ-23" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000105"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000201"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000303"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000402"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-000000000001"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-000000000002"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-000000000003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-000000000004"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-000000000005"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-000000000006"));
        }
    }
}
