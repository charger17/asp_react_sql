using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alumno",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dni = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    direccion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__alumno__3213E83F9FD3A854", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "profesor",
                columns: table => new
                {
                    usuario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    pass = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__profesor__9AFF8FC7730DD581", x => x.usuario);
                });

            migrationBuilder.CreateTable(
                name: "asignatura",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    creditos = table.Column<int>(type: "int", nullable: false),
                    profesor = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__asignatu__3213E83FADF8F1B2", x => x.id);
                    table.ForeignKey(
                        name: "FK__asignatur__profe__29572725",
                        column: x => x.profesor,
                        principalTable: "profesor",
                        principalColumn: "usuario");
                });

            migrationBuilder.CreateTable(
                name: "matricula",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alumnoId = table.Column<int>(type: "int", nullable: false),
                    asignaturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__matricul__3213E83FE599E2B7", x => x.id);
                    table.ForeignKey(
                        name: "FK__matricula__alumn__2C3393D0",
                        column: x => x.alumnoId,
                        principalTable: "alumno",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__matricula__asign__2D27B809",
                        column: x => x.asignaturaId,
                        principalTable: "asignatura",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "calificacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    nota = table.Column<float>(type: "real", nullable: false),
                    porcentaje = table.Column<int>(type: "int", nullable: false),
                    matriculaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__califica__3213E83FEF89952F", x => x.id);
                    table.ForeignKey(
                        name: "FK__calificac__matri__300424B4",
                        column: x => x.matriculaId,
                        principalTable: "matricula",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_asignatura_profesor",
                table: "asignatura",
                column: "profesor");

            migrationBuilder.CreateIndex(
                name: "IX_calificacion_matriculaId",
                table: "calificacion",
                column: "matriculaId");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_alumnoId",
                table: "matricula",
                column: "alumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_asignaturaId",
                table: "matricula",
                column: "asignaturaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calificacion");

            migrationBuilder.DropTable(
                name: "matricula");

            migrationBuilder.DropTable(
                name: "alumno");

            migrationBuilder.DropTable(
                name: "asignatura");

            migrationBuilder.DropTable(
                name: "profesor");
        }
    }
}
