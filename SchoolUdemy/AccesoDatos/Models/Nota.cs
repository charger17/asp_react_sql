using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Nota
{
    public int Idnota { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateOnly Fecha { get; set; }

    public int? UsuarioId { get; set; }
}
