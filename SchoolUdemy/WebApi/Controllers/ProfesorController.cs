using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private ProfesorDAO profesorDAO = new ProfesorDAO();

        public ProfesorController()
        {
            
        }

        [HttpPost("autenticacion")]
        public string login([FromBody] Profesor profesor)
        {
            var prof = profesorDAO.login(profesor.Usuario, profesor.Pass);

            if (prof != null)
            {
                return prof.Usuario;
            }

            return null;
        }
    }
}
