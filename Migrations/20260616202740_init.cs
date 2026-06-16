using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VRGamersWhoLift.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_UserName", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    ProfileUsernameID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.ProfileUsernameID);
                    table.ForeignKey(
                        name: "FK_profiles_Users_ProfileUsernameID",
                        column: x => x.ProfileUsernameID,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "66c0432f-cc51-44aa-81ea-7fdf9343000e", 0, "37ab9789-09d3-4b2e-82ec-c2cff5f80c6d", "Admin", "robert.arends100@gitmail.com", false, "Robert", "Arends", false, null, "Charles", null, null, "Password", null, null, false, "a", "64efbd09-2cfa-40be-89c6-d7acb4249512", false, "rarends" },
                    { "bc5f7fa8-ca85-45de-8bd3-95acd1a3b125", 0, "19a3611c-a78e-456b-ac6d-62e6b8d9e170", "Coach", "nolan.Greyson@viltrum.planet", false, "Nolan", "Greyson", false, null, "", null, null, "Password", null, null, false, "c", "ac423206-21d5-4a50-9484-da96f1329599", false, "ngreyson" },
                    { "c74b800c-1607-493f-99c5-cf7986515080", 0, "f7c9f4bc-1a15-4cc6-b4d6-d5e599ed1df4", "Member", "Samantha.Wilkins@gitmail.com", false, "Samantha", "Wilkins", false, null, "Eve", null, null, "Password", null, null, false, "m", "30a73f5e-b271-44a7-98a9-eb43f6c9fbde", false, "swilkins" }
                });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "ProfileUsernameID", "Name" },
                values: new object[,]
                {
                    { "ngreyson", "nolan_greyson" },
                    { "rarends", "robert_arends" },
                    { "swilkins", "samantha_wilkins" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
