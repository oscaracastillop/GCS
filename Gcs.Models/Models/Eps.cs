using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcs.Models.Models
{
    public class Eps
    {
        public class GridEps
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string CorreoContacto { get; set; }
            public string TelefonoContacto { get; set; }
            public string Estado { get; set; }
            public string CreateBy { get; set; }
            public string DateCreate { get; set; }
        }

        public class ListaEps
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        public class CargarDatosEps
        {
            public string Nombre { get; set; }
            public int Activo { get; set; }
        }
    }
}
