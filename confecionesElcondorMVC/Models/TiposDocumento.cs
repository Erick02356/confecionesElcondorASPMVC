using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace confecionesElcondorMVC.Models;

public partial class TiposDocumento
{
    public int IdTipoDocumento { get; set; }

    public string NombreTipo { get; set; } = null!;
    [NotMapped]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
