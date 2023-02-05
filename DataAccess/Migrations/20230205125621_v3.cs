using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherContacts_Teachers_TeacherId",
                table: "TeacherContacts");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherContacts_Teachers_TeacherId",
                table: "TeacherContacts",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherContacts_Teachers_TeacherId",
                table: "TeacherContacts");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherContacts_Teachers_TeacherId",
                table: "TeacherContacts",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
