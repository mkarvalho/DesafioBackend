using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioBackend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileUser",
                columns: table => new
                {
                    ProfilesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileUser", x => new { x.ProfilesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ProfileUser_Profiles_ProfilesId",
                        column: x => x.ProfilesId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Created", "Modified", "Name" },
                values: new object[,]
                {
                    { new Guid("358b0e4d-3de5-4f72-9b54-1ce3e96cd749"), new DateTime(2022, 2, 13, 19, 19, 47, 559, DateTimeKind.Local).AddTicks(4454), new DateTime(2022, 2, 13, 19, 19, 47, 560, DateTimeKind.Local).AddTicks(7332), "Admin" },
                    { new Guid("da27ffa7-c483-4e6d-b6f9-3ce15edf9ac1"), new DateTime(2022, 2, 13, 19, 19, 47, 560, DateTimeKind.Local).AddTicks(7850), new DateTime(2022, 2, 13, 19, 19, 47, 560, DateTimeKind.Local).AddTicks(7857), "Caixa" },
                    { new Guid("cc9d6a68-8d33-45f8-844d-9e1209af0041"), new DateTime(2022, 2, 13, 19, 19, 47, 560, DateTimeKind.Local).AddTicks(7860), new DateTime(2022, 2, 13, 19, 19, 47, 560, DateTimeKind.Local).AddTicks(7861), "Operador" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileUser_UsersId",
                table: "ProfileUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileUser");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
