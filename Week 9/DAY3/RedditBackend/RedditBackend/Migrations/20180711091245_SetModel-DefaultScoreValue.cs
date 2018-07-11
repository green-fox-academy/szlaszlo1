using Microsoft.EntityFrameworkCore.Migrations;

namespace RedditBackend.Migrations
{
    public partial class SetModelDefaultScoreValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TimeStamp",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TimeStamp",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
