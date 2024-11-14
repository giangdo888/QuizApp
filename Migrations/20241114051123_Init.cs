using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    AttemptedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QuizzesId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    QuestionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionsQuizzes",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "integer", nullable: false),
                    QuizzesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsQuizzes", x => new { x.QuestionsId, x.QuizzesId });
                    table.ForeignKey(
                        name: "FK_QuestionsQuizzes_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionsQuizzes_Quizzes_QuizzesId",
                        column: x => x.QuizzesId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "What is the capital of France?" },
                    { 2, "Which continent is known as the 'Dark Continent'?" },
                    { 3, "What is the longest river in the world?" },
                    { 4, "Mount Everest is located in which mountain range?" },
                    { 5, "Which ocean is the largest by surface area?" },
                    { 6, "What is the smallest country in the world?" },
                    { 7, "In which country is the Great Barrier Reef located?" },
                    { 8, "Which country has the most time zones?" },
                    { 9, "What is the largest desert in the world?" },
                    { 10, "The Andes mountain range is located on which continent?" }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 14, 5, 11, 22, 638, DateTimeKind.Utc).AddTicks(5701), "Quiz set 1" },
                    { 2, new DateTime(2024, 11, 14, 5, 11, 22, 638, DateTimeKind.Utc).AddTicks(5706), "Quiz set 2" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "IsCorrect", "QuestionsId", "Text" },
                values: new object[,]
                {
                    { 1, true, 1, "Paris" },
                    { 2, false, 1, "Berlin" },
                    { 3, false, 1, "Madrid" },
                    { 4, false, 1, "Rome" },
                    { 5, true, 2, "Africa" },
                    { 6, false, 2, "Asia" },
                    { 7, false, 2, "Europe" },
                    { 8, false, 2, "South America" },
                    { 9, false, 3, "Nile" },
                    { 10, true, 3, "Amazon" },
                    { 11, false, 3, "Yangtze" },
                    { 12, false, 3, "Mississippi" },
                    { 13, true, 4, "Himalayas" },
                    { 14, false, 4, "Andes" },
                    { 15, false, 4, "Rockies" },
                    { 16, false, 4, "Alps" },
                    { 17, true, 5, "Pacific" },
                    { 18, false, 5, "Atlantic" },
                    { 19, false, 5, "Indian" },
                    { 20, false, 5, "Arctic" },
                    { 21, true, 6, "Vatican City" },
                    { 22, false, 6, "Monaco" },
                    { 23, false, 6, "San Marino" },
                    { 24, false, 6, "Liechtenstein" },
                    { 25, true, 7, "Australia" },
                    { 26, false, 7, "USA" },
                    { 27, false, 7, "Brazil" },
                    { 28, false, 7, "South Africa" },
                    { 29, false, 8, "France" },
                    { 30, false, 8, "Russia" },
                    { 31, false, 8, "USA" },
                    { 32, true, 8, "France" },
                    { 33, true, 9, "Sahara" },
                    { 34, false, 9, "Gobi" },
                    { 35, false, 9, "Kalahari" },
                    { 36, false, 9, "Arabian" },
                    { 37, true, 10, "South America" },
                    { 38, false, 10, "Africa" },
                    { 39, false, 10, "Asia" },
                    { 40, false, 10, "Europe" }
                });

            migrationBuilder.InsertData(
                table: "QuestionsQuizzes",
                columns: new[] { "QuestionsId", "QuizzesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionsId",
                table: "Answers",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsQuizzes_QuizzesId",
                table: "QuestionsQuizzes",
                column: "QuizzesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "QuestionsQuizzes");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Quizzes");
        }
    }
}
