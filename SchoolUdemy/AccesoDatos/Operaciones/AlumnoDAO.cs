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

        public bool insertar(string dni, string nombre, string direccion,int edad, string email)
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
    }
}
