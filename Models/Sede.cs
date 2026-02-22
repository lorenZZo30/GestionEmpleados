using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEmpleadosMaui.Models
{
    public class Sede
    {
        public int Id { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        
        List<Empleado> Empleados { get; set; }
    }
}
