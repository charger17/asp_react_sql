using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class TblEvaluador
{
    public byte IdEvaluador { get; set; }

    public string Evaluador { get; set; } = null!;

    public virtual ICollection<TblEvaluacion> TblEvaluacions { get; set; } = new List<TblEvaluacion>();
}
