using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuchhaltungRazor.Migrations
{
    public partial class BuchhaltungRazor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ladens",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ladens", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Aufwands",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    Betrag = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    LadenID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aufwands", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Aufwands_Ladens_LadenID",
                        column: x => x.LadenID,
                        principalTable: "Ladens",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AufwandListes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    Betrag = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PreisEinheit = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    AufwandID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AufwandListes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AufwandListes_Aufwands_AufwandID",
                        column: x => x.AufwandID,
                        principalTable: "Aufwands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    PublicSchedule = table.Column<string>(nullable: true),
                    PublicScheduleSize = table.Column<long>(nullable: false),
                    PrivateSchedule = table.Column<string>(nullable: true),
                    PrivateScheduleSize = table.Column<long>(nullable: false),
                    UploadDT = table.Column<DateTime>(nullable: false),
                    AufwandID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Schedules_Aufwands_AufwandID",
                        column: x => x.AufwandID,
                        principalTable: "Aufwands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AufwandListes_AufwandID",
                table: "AufwandListes",
                column: "AufwandID");

            migrationBuilder.CreateIndex(
                name: "IX_Aufwands_LadenID",
                table: "Aufwands",
                column: "LadenID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_AufwandID",
                table: "Schedules",
                column: "AufwandID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AufwandListes");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Aufwands");

            migrationBuilder.DropTable(
                name: "Ladens");
        }
    }
}
