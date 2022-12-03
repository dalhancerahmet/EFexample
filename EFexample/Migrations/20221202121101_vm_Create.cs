using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFexample.Migrations
{
    public partial class vm_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"

                                Create view vm_test3
                                As
                                Select * from Persons
                                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
