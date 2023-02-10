using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcs.Models.Models
{
    public class Arl
    {
        public class GridArl
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }
            public string Estado { get; set; }
            public string CreateBy { get; set; }
            public string DateCreate { get; set; }
        }

        public class ListaArl
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        public class CargarDatosArl
        {
            public string Nombre { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }
            public int Activo { get; set; }
        }
    }
}
