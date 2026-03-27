using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Layer.Migrations
{
    /// <inheritdoc />
    public partial class Saved_Snippet_and_Article_Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedSnippets",
                table: "SavedSnippets");

            migrationBuilder.DropIndex(
                name: "IX_SavedSnippets_SnippetId",
                table: "SavedSnippets");

            migrationBuilder.DropIndex(
                name: "IX_SavedSnippets_UserId",
                table: "SavedSnippets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedArticles",
                table: "SavedArticles");

            migrationBuilder.DropIndex(
                name: "IX_SavedArticles_ArticleId",
                table: "SavedArticles");

            migrationBuilder.DropIndex(
                name: "IX_SavedArticles_UserId",
                table: "SavedArticles");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SavedSnippets",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SavedArticles",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedSnippets",
                table: "SavedSnippets",
                columns: new[] { "UserId", "SnippetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedArticles",
                table: "SavedArticles",
                columns: new[] { "UserId", "ArticleId" });

            migrationBuilder.CreateIndex(
                name: "IX_SavedSnippets_SnippetId",
                table: "SavedSnippets",
                column: "SnippetId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedArticles_ArticleId",
                table: "SavedArticles",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedSnippets",
                table: "SavedSnippets");

            migrationBuilder.DropIndex(
                name: "IX_SavedSnippets_SnippetId",
                table: "SavedSnippets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedArticles",
                table: "SavedArticles");

            migrationBuilder.DropIndex(
                name: "IX_SavedArticles_ArticleId",
                table: "SavedArticles");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SavedSnippets",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SavedArticles",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedSnippets",
                table: "SavedSnippets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedArticles",
                table: "SavedArticles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SavedSnippets_SnippetId",
                table: "SavedSnippets",
                column: "SnippetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SavedSnippets_UserId",
                table: "SavedSnippets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedArticles_ArticleId",
                table: "SavedArticles",
                column: "ArticleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SavedArticles_UserId",
                table: "SavedArticles",
                column: "UserId");
        }
    }
}
