using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcs.Models.Models
{
    public class Sucursal
    {
        public class GridSucursal
        {
            public int Id { get; set; }
            public string Empresa { get; set; }
            public string Nombre { get; set; }
            public string TipoDocumento { get; set; }
            public string Identificacion { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }
            public string Contacto { get; set; }
            public string Direccion { get; set; }
            public string Ciudad { get; set; }
            public string Estado { get; set; }
            public string CreateBy { get; set; }
            public string DateCreate { get; set; }
        }
        public class ListaSucursal
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }
        public class CargarDatosSucursal
        {
            public int IdEmpresa { get; set; }
            public string Nombre { get; set; }
            public int TipoDocumento { get; set; }
            public string Identificacion { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }
            public string Contacto { get; set; }
            public int Pais { get; set; }
            public int Departamento { get; set; }
            public int Ciudad { get; set; }
            public string Direccion { get; set; }
            public int Activo { get; set; }
        }
    }
}
