using AccesoDatos.Context;
using AccesoDatos.Models;

namespace AccesoDatos.Operaciones
{
    public class CalificacionDAO
    {

        private ProyectoContext contexto = new ProyectoContext();

        public List<Calificacion> seleccionar(int id)
        {
            var calificaciones = contexto.Calificacions.Where(c => c.MatriculaId == id).ToList();

            return calificaciones;
        }

        public bool agregarCalificacion(Calificacion calif)
        {
            try
            {
                contexto.Calificacions.Add(calif);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool eliminarCalificacion(int id)
        {
            try
            {
                var calificacicon = contexto.Calificacions.Where(c => c.Id == id).FirstOrDefault();

                if (calificacicon is not null)
                {
                    contexto.Calificacions.Remove(calificacicon);
                    contexto.SaveChanges();
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
