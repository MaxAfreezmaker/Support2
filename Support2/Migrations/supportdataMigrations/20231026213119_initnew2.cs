using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Support2.Migrations.supportdataMigrations
{
    /// <inheritdoc />
    public partial class initnew2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Typ_zgloszenia",
                table: "zgloszenia",
                newName: "opis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "opis",
                table: "zgloszenia",
                newName: "Typ_zgloszenia");
        }
    }
}
