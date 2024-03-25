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
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<long>(type: "bigint", nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HelpServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_HelpServices_HelpServiceId",
                        column: x => x.HelpServiceId,
                        principalTable: "HelpServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HelpServices",
                columns: new[] { "Id", "Description", "ServiceName" },
                values: new object[,]
                {
                    { new Guid("1b634fa4-4eff-42f1-9784-f0a14112e2b7"), "Family Service League is one of the foremost providers of mental health services on Long Island, treating all aspects of psychiatric illness and emotional distress for every age group and socioeconomic background. Our expert staff works collaboratively with healthcare providers and care management services to achieve true integrated healthcare for individuals impacted by mental illness—and the families who love them.", "Mental health & Integrated Care" },
                    { new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), "Family Service League provides prevention and comprehensive addiction treatment services to Suffolk county adults and adolescents—along with help and support to the families who love them. Our program features screenings, assessments and evaluations to determine the level of care needed to support outpatient recovery and abstinence. Each person who enters a FSL medically supervised program—either voluntarily or via mandate—is prescribed a plan to fit their specific needs.", "Addiction Treatment Services" },
                    { new Guid("65da73d1-5564-41f4-a49b-5de53e9218ff"), "Family Service League offers numerous programs and services to help families in need in Suffolk county. Our professionally trained staff and volunteers are available to assist everyone from at-risk youth to expectant and new parents with education, counseling and referrals to helpful resources.", "Family & Community Support" },
                    { new Guid("7ee9b631-d9ff-466a-8730-54a83337cf7c"), "Family Service League’s housing programs focus on providing emergency housing and supportive services to chronically homeless individuals and families throughout Suffolk county. Homelessness is often the result of a disability, mental illness or substance abuse, and it can be a daunting task to overcome the effects of these crippling conditions while attempting to become self-sufficient. We’re here to help.", "Housing & Homeless Services" },
                    { new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), "Family Service League provides a wide range of children and family services to help ensure that every child in Suffolk county has the opportunity to excel and choose the right path no matter their home situation. Programs and resources available offer professional guidance, counseling and positive, character-building recreational activities to support those in need and who may be most at risk.", "Children Services" },
                    { new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), "Chronic unemployment and underemployment are often at the root of individual and family hardship and dysfunction. Family Service League has a series of proven job training and vocational programs designed to build skills and confidence. Offering job skill improvement, job search services and placement assistance, these programs help those who have had difficulty finding and maintaining regular employment, as well as job seekers who are battling mental illness.", "Training & Employment" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "HelpServiceId", "LastName", "Mobile", "ProfileImageUrl" },
                values: new object[,]
                {
                    { new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"), new DateTime(1990, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "John.Doe@gmail.com", "John", new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), "Doe", 91254684586L, null },
                    { new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), new DateTime(2000, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corene.Wall@gmaill.com", "Corene", new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), "Wall", 91254684566L, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_HelpServiceId",
                table: "Clients",
                column: "HelpServiceId");
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
