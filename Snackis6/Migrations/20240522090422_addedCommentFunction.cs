using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snackis6.Migrations
{
    /// <inheritdoc />
    public partial class addedCommentFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    postId = table.Column<int>(type: "int", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    subCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Comment_Category_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Comment_Post_postId",
                        column: x => x.postId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Comment_subcategory_subCategoryId",
                        column: x => x.subCategoryId,
                        principalTable: "subcategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_categoryId",
                table: "Comment",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_postId",
                table: "Comment",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_subCategoryId",
                table: "Comment",
                column: "subCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_userId",
                table: "Comment",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");
        }
    }
}
