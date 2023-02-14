using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.Sucursal;

namespace Gcs.Data.DataEntities
{
    public class DataSucursal
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearSucursal(string IdUser, int IdEmpresa, string NombreSucursal, int IdTipoDocumento, string Identificacion, string Email, string Telefono, string Contacto, int IdCiudad, string Direccion)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdEmpresa = new SqlParameter("@IdEmpresa", SqlDbType.Int) { Value = IdEmpresa };
                var varNombreSucursal = new SqlParameter("@NombreSucursal", SqlDbType.VarChar) { Value = NombreSucursal };
                var varIdTipoDocumento = new SqlParameter("@IdTipoDocumento", SqlDbType.Int) { Value = IdTipoDocumento };
                var varIdentificacion = new SqlParameter("@Identificacion", SqlDbType.VarChar) { Value = Identificacion };
                var varEmail = new SqlParameter("@Email", SqlDbType.VarChar) { Value = Email };
                var varTelefono = new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = Telefono };
                var varContacto = new SqlParameter("@Contacto", SqlDbType.VarChar) { Value = Contacto };
                var varIdCiudad = new SqlParameter("@IdCiudad", SqlDbType.Int) { Value = IdCiudad };
                var varDireccion = new SqlParameter("@Direccion", SqlDbType.VarChar) { Value = Direccion };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearSucursal @IdUser, @IdEmpresa, @NombreSucursal, @IdTipoDocumento, @Identificacion, @Email, @Telefono, @Contacto, @IdCiudad, @Direccion, @Resultado OUTPUT", varIdUser, varIdEmpresa, varNombreSucursal, varIdTipoDocumento, varIdentificacion, varEmail, varTelefono, varContacto, varIdCiudad, varDireccion, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, la Sucursal " + NombreSucursal + " ya existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosSucursal(int IdSucursal, int IdEmpresa, string IdUser, string NombreSucursal, int IdTipoDocumento, string Identificacion, string Email, string Telefono, string Contacto, int IdCiudad, string Direccion, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdSucursal = new SqlParameter("@IdSucursal", SqlDbType.Int) { Value = IdSucursal };
                var varIdEmpresa = new SqlParameter("@IdEmpresa", SqlDbType.Int) { Value = IdEmpresa };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreSucursal = new SqlParameter("@NombreSucursal", SqlDbType.VarChar) { Value = NombreSucursal };
                var varIdTipoDocumento = new SqlParameter("@IdTipoDocumento", SqlDbType.Int) { Value = IdTipoDocumento };
                var varIdentificacion = new SqlParameter("@Identificacion", SqlDbType.VarChar) { Value = Identificacion };
                var varEmail = new SqlParameter("@Email", SqlDbType.VarChar) { Value = Email };
                var varTelefono = new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = Telefono };
                var varContacto = new SqlParameter("@Contacto", SqlDbType.VarChar) { Value = Contacto };
                var varIdCiudad = new SqlParameter("@IdCiudad", SqlDbType.Int) { Value = IdCiudad };
                var varDireccion = new SqlParameter("@Direccion", SqlDbType.VarChar) { Value = Direccion };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosSucursal @IdSucursal, @IdEmpresa, @IdUser, @NombreSucursal, @IdTipoDocumento, @Identificacion, @Email, @Telefono, @Contacto, @IdCiudad, @Direccion, @Activo, @Resultado OUTPUT", varIdSucursal, varIdEmpresa, varIdUser, varNombreSucursal, varIdTipoDocumento, varIdentificacion, varEmail, varTelefono, varContacto, varIdCiudad, varDireccion, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, la Sucursal " + NombreSucursal + " ya existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarSucursal(string IdUser, int IdSucursal)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdSucursal = new SqlParameter("@IdSucursal", SqlDbType.Int) { Value = IdSucursal };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarSucursal @IdUser, @IdSucursal, @Resultado OUTPUT", varIdUser, varIdSucursal, varResultado);

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
                    resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                }
            }
            return resultado;
        }

        public List<CargarDatosSucursal> CargarDatosSucursal(int IdSucursal)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosSucursal>("SP_CargarDatosSucursal @IdSucursal",
                    new SqlParameter("@IdSucursal", IdSucursal)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaSucursal> ListaSucursal()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaSucursal>("SP_ListaSucursal").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GridSucursal> GridSucursal()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridSucursal>("SP_GridSucursal").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
