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
                    LastLogin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                    { new Guid("275203f2-c6f0-403c-89da-820d716dbe6c"), new DateTime(2022, 2, 9, 21, 16, 22, 235, DateTimeKind.Local).AddTicks(9727), new DateTime(2022, 2, 9, 21, 16, 22, 237, DateTimeKind.Local).AddTicks(3601), "Admin" },
                    { new Guid("1475659b-9ca7-4b35-923c-8de32248c961"), new DateTime(2022, 2, 9, 21, 16, 22, 237, DateTimeKind.Local).AddTicks(4743), new DateTime(2022, 2, 9, 21, 16, 22, 237, DateTimeKind.Local).AddTicks(4748), "Caixa" },
                    { new Guid("e5fc000a-c417-4fc8-8eb5-4dcee13ebe29"), new DateTime(2022, 2, 9, 21, 16, 22, 237, DateTimeKind.Local).AddTicks(4751), new DateTime(2022, 2, 9, 21, 16, 22, 237, DateTimeKind.Local).AddTicks(4753), "Operador" }
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
