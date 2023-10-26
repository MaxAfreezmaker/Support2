using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Support2.Migrations
{
    /// <inheritdoc />
    public partial class initnewnoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_KontaktZgloszenieDownload",
                table: "KontaktZgloszenieDownload");

            migrationBuilder.RenameTable(
                name: "KontaktZgloszenieDownload",
                newName: "zgloszenia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_zgloszenia",
                table: "zgloszenia",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_zgloszenia",
                table: "zgloszenia");

            migrationBuilder.RenameTable(
                name: "zgloszenia",
                newName: "KontaktZgloszenieDownload");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KontaktZgloszenieDownload",
                table: "KontaktZgloszenieDownload",
                column: "ID");
        }
    }
}
