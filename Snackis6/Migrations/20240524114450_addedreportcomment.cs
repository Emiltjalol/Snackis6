using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snackis6.Migrations
{
    /// <inheritdoc />
    public partial class addedreportcomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reported_Post_PostId",
                table: "Reported");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Reported",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Reported_PostId",
                table: "Reported",
                newName: "IX_Reported_CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reported_Comment_CommentId",
                table: "Reported",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reported_Comment_CommentId",
                table: "Reported");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Reported",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Reported_CommentId",
                table: "Reported",
                newName: "IX_Reported_PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reported_Post_PostId",
                table: "Reported",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
