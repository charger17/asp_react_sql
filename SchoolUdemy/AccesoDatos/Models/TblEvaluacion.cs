using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class TblEvaluacion
{
    public int IdEvaluacion { get; set; }

    public DateOnly Fecha { get; set; }

    public byte IdPeriodo { get; set; }

    public short IdEmpleado { get; set; }

    public byte IdEvaluador { get; set; }

    public string? Fortalezas { get; set; }

    public string? Oportunidades { get; set; }

    public string? Recomendaciones { get; set; }

    public virtual TblEmpleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual TblEvaluador IdEvaluadorNavigation { get; set; } = null!;

    public virtual TblPeriodo IdPeriodoNavigation { get; set; } = null!;

    public virtual ICollection<TblEvaluacionDetalle> TblEvaluacionDetalles { get; set; } = new List<TblEvaluacionDetalle>();
}
