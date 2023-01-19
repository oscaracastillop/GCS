using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcs.Models.Models
{
    public class Pais
    {
        public class GridPais
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Estado { get; set; }
        }

        public class ListaPais
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        public class CargarDatosPais
        {
            public string Nombre { get; set; }
            public int Activo { get; set; }
        }
    }
}
