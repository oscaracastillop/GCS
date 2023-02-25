using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcs.Models.Models
{
    public class Empleado
    {
        public class GridEmpleado
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string TipoDocumento { get; set; }
            public string Identificacion { get; set; }
            public string Estado { get; set; }
            public string CreateBy { get; set; }
            public string DateCreate { get; set; }
        }
        public class CargarDatosHVEmpleado
        {
            public string Nacionalidad { get; set; }
            public string FechaNacimiento { get; set; }
            public string LugarNacimiento { get; set; }
            public string Sexo { get; set; }
            public string EstadoCivil { get; set; }
            public string Email { get; set; }
            public string Telefono1 { get; set; }
            public string Telefono2 { get; set; }
            public string PaisResidencia { get; set; }
            public string DepartamentoResidencia { get; set; }
            public string CiudadResidencia { get; set; }
            public string DireccionResidencia { get; set; }
            public string TipoVivienda { get; set; }
            public string NombreArrendador { get; set; }
            public string TelefonoArrendador { get; set; }
            public string TiempoResidiendo { get; set; }
            public string NombreRF1 { get; set; }
            public string ParentescoRF1 { get; set; }
            public string TelefonoRF1 { get; set; }
            public string ProfesionRF1 { get; set; }
            public string NombreRF2 { get; set; }
            public string ParentescoRF2 { get; set; }
            public string TelefonoRF2 { get; set; }
            public string ProfesionRF2 { get; set; }
            public string NombreRP1 { get; set; }
            public string DireccionRP1 { get; set; }
            public string TelefonoRP1 { get; set; }
            public string ProfesionRP1 { get; set; }
            public string NombreRP2 { get; set; }
            public string DireccionRP2 { get; set; }
            public string TelefonoRP2 { get; set; }
            public string ProfesionRP2 { get; set; }
        }

        public class CargarDatosPersonales
        {
            public int IdNacionalidad { get; set; }
            public string FechaNacimiento { get; set; }
            public string LugarNacimiento { get; set; }
            public int IdSexo { get; set; }
            public int IdEstadoCivil { get; set; }
            public string Email { get; set; }
            public string Telefono1 { get; set; }
            public string Telefono2 { get; set; }
        }

        public class CargarDatosResidencia
        {
            public int IdPais { get; set; }
            public int IdDepartamento { get; set; }
            public int IdCiudad { get; set; }
            public string DireccionResidencia { get; set; }
            public int IdTipoVivienda { get; set; }
            public string NombreArrendador { get; set; }
            public string TelefonoArrendador { get; set; }
            public string TiempoResidiendo { get; set; }
        }

        public class CargarDatosCabeceraEmpleado
        {            
            public string NombreEmpleado { get; set; }
            public string Identificacion { get; set; }
        }

        public class CargarDatosRFEmpleado
        {
            public string NombreRF1Empleado { get; set; }
            public string ParentescoRF1Empleado { get; set; }
            public string TelefonoRF1Empleado { get; set; }
            public string ProfesionRF1Empleado { get; set; }
            public string NombreRF2Empleado { get; set; }
            public string ParentescoRF2Empleado { get; set; }
            public string TelefonoRF2Empleado { get; set; }
            public string ProfesionRF2Empleado { get; set; }
        }
    }
}
