using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalAssesmentOracle.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Depot",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depot", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 250, nullable: false),
                    Doctor = table.Column<string>(maxLength: 250, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    SiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubjectBuy",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationName = table.Column<string>(maxLength: 250, nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectBuy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SubjectID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Medication_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicationDistribution",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(nullable: false),
                    MedicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationDistribution", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicationDistribution_Medication_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medication",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationUnit",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationId = table.Column<int>(nullable: false),
                    SiteId = table.Column<int>(nullable: false),
                    DepotId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationUnit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicationUnit_Depot_DepotId",
                        column: x => x.DepotId,
                        principalTable: "Depot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationUnit_Medication_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medication",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicationUnit_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medication_SubjectID",
                table: "Medication",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationDistribution_MedicationId",
                table: "MedicationDistribution",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationUnit_DepotId",
                table: "MedicationUnit",
                column: "DepotId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationUnit_MedicationId",
                table: "MedicationUnit",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationUnit_SiteId",
                table: "MedicationUnit",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicationDistribution");

            migrationBuilder.DropTable(
                name: "MedicationUnit");

            migrationBuilder.DropTable(
                name: "SubjectBuy");

            migrationBuilder.DropTable(
                name: "Depot");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
