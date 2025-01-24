namespace confecionesElcondorMVC.ViewsModels
{
    public class EmpleadoViewModel
    {
        public int IdEmpleado { get; set; }
        public string NumeroDocumento { get; set; } = null!;
        public string NombreCompleto { get; set; } = null!;
        public string NombreTipoDocumento { get; set; } = null!;
        public string NombreArea { get; set; } = null!;
        public string FechaNacimiento { get; set; } = null!;
    }
}
