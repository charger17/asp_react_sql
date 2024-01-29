using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class TblEvaluacionDetalle
{
    public int IdEvaluacionD { get; set; }

    public int? IdEvaluacion { get; set; }

    public byte? IdSubCompetencia { get; set; }

    public byte Nota { get; set; }

    public virtual TblEvaluacion? IdEvaluacionNavigation { get; set; }

    public virtual TblSubCompetencium? IdSubCompetenciaNavigation { get; set; }
}
