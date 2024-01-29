using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class TblEmpleado
{
    public short IdEmpleado { get; set; }

    public string Empleado { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public byte IdDepartamento { get; set; }

    public byte IdCargo { get; set; }

    public string Nseguro { get; set; } = null!;

    public virtual TblCargo IdCargoNavigation { get; set; } = null!;

    public virtual TblDepartamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual ICollection<TblEvaluacion> TblEvaluacions { get; set; } = new List<TblEvaluacion>();
}
