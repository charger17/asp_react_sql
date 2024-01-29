

using AccesoDatos.Operaciones;

AlumnoDAO opAlumno = new AlumnoDAO();

var alumnos = opAlumno.seleccionarTodos();

foreach (var alumno in alumnos)
{
    Console.WriteLine(alumno.Nombre.ToString());
}


Console.WriteLine(opAlumno.seleccionar(1).Nombre.ToString());


//opAlumno.insertar("56456", "Carlos Perez", "calle", 20, "j@mail.com");
//opAlumno.actualizar(11, "56456", "Carlos Perez Salazr", "calle", 27, "j@mail.com");

//opAlumno.eliminar(11);

var alumnoasig = opAlumno.seleccionarAlumnosAsignaturas();

foreach (var data in alumnoasig)
{
    Console.WriteLine(data.NombreAlumno.ToString() + data.NombreAsignatura.ToString());
}