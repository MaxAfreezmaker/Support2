using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Support2.Migrations.supportdataMigrations
{
    /// <inheritdoc />
    public partial class initmaxsupportsecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "zgloszenia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "zgloszenia");
        }
    }
}
