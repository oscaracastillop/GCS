using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcs.Models.Models
{
    public class Ciudad
    {
        public class GridCiudad
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string NombreDepartamento { get; set; }
            public string Estado { get; set; }
            public string CreateBy { get; set; }
            public string DateCreate { get; set; }
        }

        public class ListaCiudad
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        public class CargarDatosCiudad
        {
            public int IdDepartamento { get; set; }
            public string Nombre { get; set; }
            public int Activo { get; set; }
        }
    }
}
