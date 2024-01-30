using AccesoDatos.Context;
using AccesoDatos.Models;

namespace AccesoDatos.Operaciones
{
    public class ProfesorDAO
    {
        public ProyectoContext contexto = new ProyectoContext();

        public Profesor login(String usuario, String pass)
        {
            var prof = contexto.Profesors.Where(p => p.Usuario == usuario && p.Pass == pass).FirstOrDefault();

            return prof;
        }
    }
}
