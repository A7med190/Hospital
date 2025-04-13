using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appiontments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appiontments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appiontments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Img", "Name", "Specialization" },
                values: new object[,]
                {
                    { 1, "doctor1.jpg", "Dr. John Smith", "Cardiology" },
                    { 2, "doctor2.jpg", "Dr. Sarah Johnson", "Pediatrics" },
                    { 3, "doctor4.jpg", "Dr. Emily Davis", "Dermatology" },
                    { 4, "doctor3.jpg", "Dr. Michael Lee", "Orthopedics" },
                    { 5, "doctor5.jpg", "Dr. William Clark", "Neurology" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appiontments_DoctorId",
                table: "Appiontments",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appiontments");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
