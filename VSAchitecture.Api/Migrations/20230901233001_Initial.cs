using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VSAchitecture.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    MobileTelephone = table.Column<string>(type: "TEXT", nullable: true),
                    HomeTelephone = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    OtherNames = table.Column<string>(type: "TEXT", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nationality = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    OtherNames = table.Column<string>(type: "TEXT", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nationality = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentParents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentParents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentParents_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentParents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "Address", "Email", "FirstName", "HomeTelephone", "ImageUrl", "LastName", "MobileTelephone", "Nationality", "OtherNames", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("8245fe4a-d402-451c-b9ed-9c1a04247482"), null, "william.smith@email.com", "William", null, null, "Smith", null, "", "", new DateTime(2023, 9, 1, 23, 30, 1, 794, DateTimeKind.Utc).AddTicks(3490) },
                    { new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"), null, "john.doe@email.com", "John", null, null, "Doe", null, "", "", new DateTime(2023, 9, 1, 23, 30, 1, 794, DateTimeKind.Utc).AddTicks(3440) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "Nationality", "OtherNames", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("5245fe4a-d402-451c-b9ed-9c1a04247482"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fredrick", null, "Smith", "", "", new DateTime(2023, 9, 1, 23, 30, 1, 794, DateTimeKind.Utc).AddTicks(3520) },
                    { new Guid("6245fe4a-d402-451c-b9ed-9c1a04247482"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joyce", null, "Doe", "", "", new DateTime(2023, 9, 1, 23, 30, 1, 794, DateTimeKind.Utc).AddTicks(3510) },
                    { new Guid("7245fe4a-d402-451c-b9ed-9c1a04247482"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chalese", null, "Doe", "", "", new DateTime(2023, 9, 1, 23, 30, 1, 794, DateTimeKind.Utc).AddTicks(3500) }
                });

            migrationBuilder.InsertData(
                table: "StudentParents",
                columns: new[] { "Id", "ParentId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("9875fe4a-d402-451c-b9ed-9c1a04247482"), new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"), new Guid("5245fe4a-d402-451c-b9ed-9c1a04247482") },
                    { new Guid("9995fe4a-d402-451c-b9ed-9c1a04247482"), new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"), new Guid("6245fe4a-d402-451c-b9ed-9c1a04247482") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentParents_ParentId",
                table: "StudentParents",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParents_StudentId",
                table: "StudentParents",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentParents");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
