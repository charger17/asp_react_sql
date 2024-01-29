using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class TblPeriodo
{
    public byte IdPeriodo { get; set; }

    public string Periodo { get; set; } = null!;

    public virtual ICollection<TblEvaluacion> TblEvaluacions { get; set; } = new List<TblEvaluacion>();
}
