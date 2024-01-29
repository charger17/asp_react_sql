using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class TblDepartamento
{
    public byte IdDepartamento { get; set; }

    public string Departamento { get; set; } = null!;

    public virtual ICollection<TblEmpleado> TblEmpleados { get; set; } = new List<TblEmpleado>();
}
