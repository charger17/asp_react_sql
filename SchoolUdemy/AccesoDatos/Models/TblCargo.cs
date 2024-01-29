using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class TblCargo
{
    public byte IdCargo { get; set; }

    public string Cargo { get; set; } = null!;

    public virtual ICollection<TblEmpleado> TblEmpleados { get; set; } = new List<TblEmpleado>();
}
