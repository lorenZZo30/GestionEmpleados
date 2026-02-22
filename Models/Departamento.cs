using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEmpleadosMaui.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        List<Empleado> Empleados { get; set; }
    }
}
