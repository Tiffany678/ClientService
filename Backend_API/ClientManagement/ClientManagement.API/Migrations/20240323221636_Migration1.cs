using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClientManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HelpServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<long>(type: "bigint", nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HelpServicesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_HelpServices_HelpServicesId",
                        column: x => x.HelpServicesId,
                        principalTable: "HelpServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HelpServices",
                columns: new[] { "Id", "Description", "ServiceName" },
                values: new object[,]
                {
                    { new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), "Family Service League provides prevention and comprehensive addiction treatment services to Suffolk county adults and adolescents—along with help and support to the families who love them. Our program features screenings, assessments and evaluations to determine the level of care needed to support outpatient recovery and abstinence.", "Addiction Treatment Services" },
                    { new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), "Family Service League provides a wide range of children and family services to help ensure that every child in Suffolk county has the opportunity to excel and choose the right path no matter their home situation.", "Children Services" },
                    { new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), "Chronic unemployment and underemployment are often at the root of individual and family hardship and dysfunction. Family Service League has a series of proven job training and vocational programs designed to build skills and confidence.", "Training & Employment" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_HelpServicesId",
                table: "Clients",
                column: "HelpServicesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "HelpServices");
        }
    }
}
