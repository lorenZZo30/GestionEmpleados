using System.Text.Json.Serialization;

namespace GestionEmpleadosMaui.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int SedeId { get; set; }
        public int DepartamentoId { get; set; }


        Departamento departamento { get; set; }
        Sede sede { get; set; }
    }
}
