using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogCoreSeven.Migrations
{
    /// <inheritdoc />
    public partial class miguc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "ContactForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail",
                table: "ContactForms");
        }
    }
}
