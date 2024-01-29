using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class TblSubCompetencium
{
    public byte IdSubCompetencia { get; set; }

    public string SubCompetencia { get; set; } = null!;

    public byte IdCompetencia { get; set; }

    public virtual TblCompetencium IdCompetenciaNavigation { get; set; } = null!;

    public virtual ICollection<TblEvaluacionDetalle> TblEvaluacionDetalles { get; set; } = new List<TblEvaluacionDetalle>();
}
