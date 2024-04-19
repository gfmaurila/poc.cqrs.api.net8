using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poc.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            // Inserção de dados na tabela Post
            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Title", "Content" },
                values: new object[,]
                {
                    { Guid.NewGuid(), "Título do Post 1", "Conteúdo do Post 1" },
                    { Guid.NewGuid(), "Título do Post 2", "Conteúdo do Post 2" },
                    // Adicione mais linhas conforme necessário
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
