using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineAssignment.Migrations
{
    public partial class Employees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeePassword = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Employees", x => x.EmployeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Employees");
        }
    }
}
