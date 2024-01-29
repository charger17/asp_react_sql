using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string Password { get; set; } = null!;

    public int? EsAdmin { get; set; }
}
