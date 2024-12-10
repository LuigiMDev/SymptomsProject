using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SymptomsProject.Migrations
{
    /// <inheritdoc />
    public partial class symptomAdjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Symptoms_Patients_PatientId",
                table: "Symptoms");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Symptoms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Symptoms_Patients_PatientId",
                table: "Symptoms",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Symptoms_Patients_PatientId",
                table: "Symptoms");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Symptoms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Symptoms_Patients_PatientId",
                table: "Symptoms",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
