using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogCoreSeven.Migrations
{
    /// <inheritdoc />
    public partial class migfour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShowInMainPage",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShowInMainPage",
                table: "Posts");
        }
    }
}
