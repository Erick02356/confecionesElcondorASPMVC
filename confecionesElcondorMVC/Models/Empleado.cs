using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace confecionesElcondorMVC.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int IdTipoDocumento { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public int IdArea { get; set; }
    [NotMapped]
    public virtual Area? IdAreaNavigation { get; set; } = null!;
    [NotMapped]
    public virtual TiposDocumento? IdTipoDocumentoNavigation { get; set; } = null!;
}
