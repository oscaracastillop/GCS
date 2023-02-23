using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcs.Models.Models
{
    public class TipoVivienda
    {
        public class GridTipoVivienda
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Estado { get; set; }
            public string CreateBy { get; set; }
            public string DateCreate { get; set; }
        }

        public class ListaTipoVivienda
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        public class CargarDatosTipoVivienda
        {
            public string Nombre { get; set; }
            public int Activo { get; set; }
        }
    }
}
