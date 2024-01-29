using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class TblCompetencium
{
    public byte IdCompetencia { get; set; }

    public string Competencia { get; set; } = null!;

    public virtual ICollection<TblSubCompetencium> TblSubCompetencia { get; set; } = new List<TblSubCompetencium>();
}
