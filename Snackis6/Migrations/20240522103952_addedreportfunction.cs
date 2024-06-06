using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snackis6.Migrations
{
    /// <inheritdoc />
    public partial class addedreportfunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reported",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReporterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReportedUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reported", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reported_AspNetUsers_ReportedUserId",
                        column: x => x.ReportedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reported_AspNetUsers_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reported_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reported_PostId",
                table: "Reported",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Reported_ReportedUserId",
                table: "Reported",
                column: "ReportedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reported_ReporterId",
                table: "Reported",
                column: "ReporterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reported");
        }
    }
}
