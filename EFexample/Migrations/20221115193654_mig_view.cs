using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFexample.Migrations
{
    public partial class mig_view : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                
                Create view vm_BookAuthors
                As
                Select * From Books
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"Drop View vm_BookAuthors");
        }
    }
}
