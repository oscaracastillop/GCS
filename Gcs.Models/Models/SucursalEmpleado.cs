using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcs.Models.Models
{
    public class SucursalEmpleado
    {
        public class GridSucursalEmpleado
        {
            public int Id { get; set; }
            public string Sucursal { get; set; }
            public string Direccion { get; set; }
            public string Empleado { get; set; }
            public string FechaInicio { get; set; }
            public string Estado { get; set; }
            public string CreateBy { get; set; }
            public string DateCreate { get; set; }
        }
    }
}
