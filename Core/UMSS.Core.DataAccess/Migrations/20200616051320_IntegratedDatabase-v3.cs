using Microsoft.EntityFrameworkCore.Migrations;

namespace UMSS.Core.DataAccess.Migrations
{
    public partial class IntegratedDatabasev3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Musics_Name",
                table: "Musics",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artists_Name",
                table: "Artists",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Musics_Name",
                table: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Artists_Name",
                table: "Artists");
        }
    }
}
