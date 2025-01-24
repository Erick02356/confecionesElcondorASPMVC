using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace confecionesElcondorMVC.Models;

public partial class Area
{
    public int IdArea { get; set; }

    public string NombreArea { get; set; } = null!;
    [NotMapped]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
