using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcs.Models.Models
{
    public class TipoDocumento
    {
        public class GridTipoDocumento
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Estado { get; set; }
            public string CreateBy { get; set; }
            public string DateCreate { get; set; }
        }

        public class ListaTipoDocumento
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        public class CargarDatosTipoDocumento
        {
            public string Nombre { get; set; }
            public int Activo { get; set; }
        }
    }
}
