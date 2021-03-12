using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineCard.Migrations
{
    public partial class entities_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MedicineCards_MedicineCardId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "MedicineCards");

            migrationBuilder.DropIndex(
                name: "IX_Users_MedicineCardId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MedicineCardId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Therapy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.AddColumn<long>(
                name: "MedicineCardId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MedicineCards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<long>(type: "bigint", nullable: true),
                    LastDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineCards_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_MedicineCardId",
                table: "Users",
                column: "MedicineCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineCards_DoctorId",
                table: "MedicineCards",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MedicineCards_MedicineCardId",
                table: "Users",
                column: "MedicineCardId",
                principalTable: "MedicineCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
