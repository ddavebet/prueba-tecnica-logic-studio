using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    public partial class Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Contrasena", "Nombre", "Salt" },
                values: new object[] { 1, "vg0EhCNIiwog7rJVXRPQoCa+HfCgF/OxwhJwkRJPVN6Aivih4aCZNKzUnIDt//nvZfGa5w5xR+T+vJxaRW51Jg==", "admin", "5JQDVb2gBxzbgcTSNz4WFxEuB6yzEy7usQCHktLLOiJyx4E63FAmT80Ynu99rBvkivkTfN5CWi+a30qHaSImqg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
