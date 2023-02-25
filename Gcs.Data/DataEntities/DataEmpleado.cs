using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.Empleado;

namespace Gcs.Data.DataEntities
{
    public class DataEmpleado
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearEmpleado(string IdUser, string NombreEmpleado, string ApellidoEmpleado, int IdTipoDocumento, string Identificacion)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreEmpleado = new SqlParameter("@NombreEmpleado", SqlDbType.VarChar) { Value = NombreEmpleado };
                var varApellidoEmpleado = new SqlParameter("@ApellidoEmpleado", SqlDbType.VarChar) { Value = ApellidoEmpleado };
                var varIdTipoDocumento = new SqlParameter("@IdTipoDocumento", SqlDbType.Int) { Value = IdTipoDocumento };
                var varIdentificacion = new SqlParameter("@Identificacion", SqlDbType.VarChar) { Value = Identificacion };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearEmpleado @IdUser, @NombreEmpleado, @ApellidoEmpleado, @IdTipoDocumento, @Identificacion, @Resultado OUTPUT", varIdUser, varNombreEmpleado, varApellidoEmpleado, varIdTipoDocumento, varIdentificacion,  varResultado);

                resultado = Convert.ToString(varResultado.Value);
            }
            catch (Exception ex)
            {
                var Rol = dataRol.BuscarRolUsuario(IdUser);
                if (Rol == "Administrador")
                {
                    resultado = "Error*" + ex.Message;
                }
                else
                {
                    if (ex.Message.Contains("No se puede insertar"))
                    {
                        resultado = "Error*No se puede insertar valores duplicados, el empleado " + NombreEmpleado + " ya existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }



        public List<CargarDatosCabeceraEmpleado> CargarDatosCabeceraEmpleado(int IdEmpleado)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosCabeceraEmpleado>("SP_CargarDatosCabeceraEmpleado @IdEmpleado",
                    new SqlParameter("@IdEmpleado", IdEmpleado)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public List<CargarDatosHVEmpleado> CargarDatosHVEmpleado(int IdEmpleado)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosHVEmpleado>("SP_CargarDatosHVEmpleado @IdEmpleado",
                    new SqlParameter("@IdEmpleado", IdEmpleado)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CargarDatosPersonales> CargarDatosPersonales(int IdEmpleado)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosPersonales>("SP_CargarDatosPersonales @IdEmpleado",
                    new SqlParameter("@IdEmpleado", IdEmpleado)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GuardarCambiosDatosPersonales(int IdEmpleado, string IdUser, int IdNacionalidad, string FechaNacimientoEmpleado, string LugarNacimientoEmpleado, int IdSexoEmpleado, int IdTipoEstadoCivil, string EmailEmpleado, string Telefono1Empleado, string Telefono2Empleado)
        {
            string resultado = String.Empty;            
                var varIdEmpleado = new SqlParameter("@IdEmpleado", SqlDbType.Int) { Value = IdEmpleado };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdNacionalidad = new SqlParameter("@IdNacionalidad", SqlDbType.Int) { Value = IdNacionalidad };
                var varFechaNacimientoEmpleado = new SqlParameter("@FechaNacimientoEmpleado", SqlDbType.VarChar) { Value = FechaNacimientoEmpleado };
                var varLugarNacimientoEmpleado = new SqlParameter("@LugarNacimientoEmpleado", SqlDbType.VarChar) { Value = LugarNacimientoEmpleado };
                var varIdSexoEmpleado = new SqlParameter("@IdSexoEmpleado", SqlDbType.Int) { Value = IdSexoEmpleado };
                var varIdTipoEstadoCivil = new SqlParameter("@IdTipoEstadoCivil", SqlDbType.Int) { Value = IdTipoEstadoCivil };
                var varEmailEmpleado = new SqlParameter("@EmailEmpleado", SqlDbType.VarChar) { Value = EmailEmpleado };
                var varTelefono1Empleado = new SqlParameter("@Telefono1Empleado", SqlDbType.VarChar) { Value = Telefono1Empleado };
                var varTelefono2Empleado = new SqlParameter("@Telefono2Empleado", SqlDbType.VarChar) { Value = Telefono2Empleado };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosDatosPersonales @IdEmpleado, @IdUser, @IdNacionalidad, @FechaNacimientoEmpleado, @LugarNacimientoEmpleado, @IdSexoEmpleado, @IdTipoEstadoCivil, @EmailEmpleado, @Telefono1Empleado, @Telefono2Empleado, @Resultado OUTPUT", varIdEmpleado, varIdUser, varIdNacionalidad, varFechaNacimientoEmpleado, varLugarNacimientoEmpleado, varIdSexoEmpleado, varIdTipoEstadoCivil, varEmailEmpleado, varTelefono1Empleado, varTelefono2Empleado, varResultado);

                resultado = Convert.ToString(varResultado.Value);   
            return resultado;
        }

        public List<CargarDatosResidencia> CargarDatosResidencia(int IdEmpleado)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosResidencia>("SP_CargarDatosResidencia @IdEmpleado",
                    new SqlParameter("@IdEmpleado", IdEmpleado)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GuardarCambiosDatosResidencia(int IdEmpleado, string IdUser, int IdCiudad, string DireccionEmpleado, int IdTipoVivienda, string NombreArrendador, string TelefonoArrendador, string TiempoResidiendo)
        {
            string resultado = String.Empty;
            var varIdEmpleado = new SqlParameter("@IdEmpleado", SqlDbType.Int) { Value = IdEmpleado };
            var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
            var varIdCiudad = new SqlParameter("@IdCiudad", SqlDbType.Int) { Value = IdCiudad };
            var varDireccionEmpleado = new SqlParameter("@DireccionEmpleado", SqlDbType.VarChar) { Value = DireccionEmpleado };
            var varIdTipoVivienda = new SqlParameter("@IdTipoVivienda", SqlDbType.Int) { Value = IdTipoVivienda };
            var varNombreArrendador = new SqlParameter("@NombreArrendador", SqlDbType.VarChar) { Value = NombreArrendador };
            var varTelefonoArrendador = new SqlParameter("@TelefonoArrendador", SqlDbType.VarChar) { Value = TelefonoArrendador };
            var varTiempoResidiendo = new SqlParameter("@TiempoResidiendo", SqlDbType.VarChar) { Value = TiempoResidiendo };
            var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

            _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosDatosResidencia @IdEmpleado, @IdUser, @IdCiudad, @DireccionEmpleado, @IdTipoVivienda, @NombreArrendador, @TelefonoArrendador, @TiempoResidiendo, @Resultado OUTPUT", varIdEmpleado, varIdUser, varIdCiudad, varDireccionEmpleado, varIdTipoVivienda, varNombreArrendador, varTelefonoArrendador, varTiempoResidiendo, varResultado);

            resultado = Convert.ToString(varResultado.Value);
            return resultado;
        }

        public List<CargarDatosRFEmpleado> CargarDatosRFEmpleado(int IdEmpleado)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosRFEmpleado>("SP_CargarDatosRFEmpleado @IdEmpleado",
                    new SqlParameter("@IdEmpleado", IdEmpleado)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GuardarCambiosRFEmpleado(int IdEmpleado, string IdUser, string NombreRF1Empleado, string ParentescoRF1Empleado, string TelefonoRF1Empleado, string ProfesionRF1Empleado, string NombreRF2Empleado, string ParentescoRF2Empleado, string TelefonoRF2Empleado, string ProfesionRF2Empleado)
        {
            string resultado = String.Empty;
            var varIdEmpleado = new SqlParameter("@IdEmpleado", SqlDbType.Int) { Value = IdEmpleado };
            var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
            var varNombreRF1Empleado = new SqlParameter("@NombreRF1Empleado", SqlDbType.VarChar) { Value = NombreRF1Empleado };
            var varParentescoRF1Empleado = new SqlParameter("@ParentescoRF1Empleado", SqlDbType.VarChar) { Value = ParentescoRF1Empleado };
            var varTelefonoRF1Empleado = new SqlParameter("@TelefonoRF1Empleado", SqlDbType.VarChar) { Value = TelefonoRF1Empleado };
            var varProfesionRF1Empleado = new SqlParameter("@ProfesionRF1Empleado", SqlDbType.VarChar) { Value = ProfesionRF1Empleado };
            var varNombreRF2Empleado = new SqlParameter("@NombreRF2Empleado", SqlDbType.VarChar) { Value = NombreRF2Empleado };
            var varParentescoRF2Empleado = new SqlParameter("@ParentescoRF2Empleado", SqlDbType.VarChar) { Value = ParentescoRF2Empleado };
            var varTelefonoRF2Empleado = new SqlParameter("@TelefonoRF2Empleado", SqlDbType.VarChar) { Value = TelefonoRF2Empleado };
            var varProfesionRF2Empleado = new SqlParameter("@ProfesionRF2Empleado", SqlDbType.VarChar) { Value = ProfesionRF2Empleado };
            var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

            _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosRFEmpleado @IdEmpleado, @IdUser, @NombreRF1Empleado, @ParentescoRF1Empleado, @TelefonoRF1Empleado, @ProfesionRF1Empleado, @NombreRF2Empleado, @ParentescoRF2Empleado, @TelefonoRF2Empleado, @ProfesionRF2Empleado, @Resultado OUTPUT", varIdEmpleado, varIdUser, varNombreRF1Empleado, varParentescoRF1Empleado, varTelefonoRF1Empleado, varProfesionRF1Empleado, varNombreRF2Empleado, varParentescoRF2Empleado, varTelefonoRF2Empleado, varProfesionRF2Empleado, varResultado);

            resultado = Convert.ToString(varResultado.Value);
            return resultado;
        }

        public List<GridEmpleado> GridEmpleado()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridEmpleado>("SP_GridEmpleado").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
