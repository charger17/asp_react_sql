using AccesoDatos.Context;
using AccesoDatos.Models;

namespace AccesoDatos.Operaciones
{
    public class AlumnoDAO
    {
        public ProyectoContext context = new ProyectoContext();

        public List<Alumno> seleccionarTodos()
        {
            var alumnos = context.Alumnos.ToList();

            return alumnos;
        }

        public Alumno seleccionar(int id)
        {
            var alumno = context.Alumnos.Where(x => x.Id == id).FirstOrDefault();

            return alumno;
        }

        public bool insertar(string dni, string nombre, string direccion, int edad, string email)
        {
            try
            {
                Alumno alumno = new Alumno()
                {
                    Dni = dni,
                    Nombre = nombre,
                    Direccion = direccion,
                    Email = email,
                    Edad = edad
                };

                context.Alumnos.Add(alumno);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool actualizar(int id, string dni, string nombre, string direccion, int edad, string email)
        {
            try
            {
                var alumno = seleccionar(id);

                if (alumno == null)
                {
                    return false;
                }

                alumno.Dni = dni;
                alumno.Nombre = nombre;
                alumno.Direccion = direccion;
                alumno.Edad = edad;
                alumno.Email = email;

                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool eliminar(int id)
        {
            try
            {
                var alumno = seleccionar(id);

                if (alumno == null)
                {
                    return false;
                }

                context.Alumnos.Remove(alumno);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<AlumnoAsignatura> seleccionarAlumnosAsignaturas()
        {
            var query = from A in context.Alumnos
                        join M in context.Matriculas on A.Id equals M.AlumnoId
                        join ASIG in context.Asignaturas on M.AsignaturaId equals ASIG.Id
                        select new AlumnoAsignatura()
                        {
                            NombreAlumno = A.Nombre,
                            NombreAsignatura = ASIG.Nombre
                        };

            return query.ToList();

        }

        public List<AlumnoProfesor> seleccionarAlumnosProfesor(string usuario)
        {
            var query = from A in context.Alumnos
                        join M in context.Matriculas on A.Id equals M.AlumnoId
                        join Asig in context.Asignaturas on M.AsignaturaId equals Asig.Id
                        where Asig.Profesor == usuario
                        select new AlumnoProfesor()
                        {
                            Id = A.Id,
                            Dni = A.Dni,
                            Nombre = A.Nombre,
                            Direccion = A.Direccion,
                            Edad = A.Edad,
                            Email = A.Email,
                            Asignatura = Asig.Nombre
                        };

            return query.ToList();
        }

        public Alumno seleccionarPorDni(string dni)
        {
            var alumno = context.Alumnos.Where(x => x.Dni == dni).FirstOrDefault();

            return alumno;
        }

        public bool insertarYMatricular(string dni, string nombre, string direccion, int edad, string email, int id_asig)
        {
            try
            {
                    Matricula m = new Matricula();
                var existe = seleccionarPorDni(dni);

                if (existe is null)
                {
                    insertar(dni, nombre, direccion, edad, email);
                    var insertado = seleccionarPorDni(dni);
                    m.AlumnoId = insertado.Id;
                    m.AsignaturaId = id_asig;

                }
                else
                {
                    m.AlumnoId = existe.Id;
                    m.AsignaturaId = id_asig;
                }

                context.Matriculas.Add(m);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool eliminarAlumno(int id)
        {
            try
            {
                var alumno = seleccionar(id);

                if (alumno != null)
                {
                    var matriculas = context.Matriculas.Where(m => m.AlumnoId == id);

                    foreach (var matricula in matriculas)
                    {
                        var calificaciones = context.Calificacions.Where(c => c.MatriculaId == matricula.Id);
                        context.Calificacions.RemoveRange(calificaciones);
                    }
                    context.Matriculas.RemoveRange(matriculas);
                    context.Alumnos.Remove(alumno);
                    context.SaveChanges();
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
