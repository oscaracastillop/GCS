using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.TipoFormaPago;

namespace Gcs.Data.DataEntities
{
    public class DataTipoFormaPago
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearTipoFormaPago(string IdUser, string NombreTipoFormaPago)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoFormaPago = new SqlParameter("@NombreTipoFormaPago", SqlDbType.VarChar) { Value = NombreTipoFormaPago };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearTipoFormaPago @IdUser, @NombreTipoFormaPago, @Resultado OUTPUT", varIdUser, varNombreTipoFormaPago, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, la forma pago " + NombreTipoFormaPago + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosTipoFormaPago(int IdTipoFormaPago, string IdUser, string NombreTipoFormaPago, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdTipoFormaPago = new SqlParameter("@IdTipoFormaPago", SqlDbType.Int) { Value = IdTipoFormaPago };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoFormaPago = new SqlParameter("@NombreTipoFormaPago", SqlDbType.VarChar) { Value = NombreTipoFormaPago };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosTipoFormaPago @IdTipoFormaPago, @IdUser, @NombreTipoFormaPago, @Activo, @Resultado OUTPUT", varIdTipoFormaPago, varIdUser, varNombreTipoFormaPago, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, la forma pago " + NombreTipoFormaPago + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarTipoFormaPago(string IdUser, int IdTipoFormaPago)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdTipoFormaPago = new SqlParameter("@IdTipoFormaPago", SqlDbType.Int) { Value = IdTipoFormaPago };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarTipoFormaPago @IdUser, @IdTipoFormaPago, @Resultado OUTPUT", varIdUser, varIdTipoFormaPago, varResultado);

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

        public List<CargarDatosTipoFormaPago> CargarDatosTipoFormaPago(int IdTipoFormaPago)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosTipoFormaPago>("SP_CargarDatosTipoFormaPago @IdTipoFormaPago",
                    new SqlParameter("@IdTipoFormaPago", IdTipoFormaPago)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaTipoFormaPago> ListaTipoFormaPago()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaTipoFormaPago>("SP_ListaTipoFormaPago").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridTipoFormaPago> GridTipoFormaPago()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridTipoFormaPago>("SP_GridTipoFormaPago").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
