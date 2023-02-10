using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.TipoMoneda;

namespace Gcs.Data.DataEntities
{
    public class DataTipoMoneda
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearTipoMoneda(string IdUser, string NombreTipoMoneda)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoMoneda = new SqlParameter("@NombreTipoMoneda", SqlDbType.VarChar) { Value = NombreTipoMoneda };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearTipoMoneda @IdUser, @NombreTipoMoneda, @Resultado OUTPUT", varIdUser, varNombreTipoMoneda, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el tipo moneda " + NombreTipoMoneda + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosTipoMoneda(int IdTipoMoneda, string IdUser, string NombreTipoMoneda, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdTipoMoneda = new SqlParameter("@IdTipoMoneda", SqlDbType.Int) { Value = IdTipoMoneda };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoMoneda = new SqlParameter("@NombreTipoMoneda", SqlDbType.VarChar) { Value = NombreTipoMoneda };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosTipoMoneda @IdTipoMoneda, @IdUser, @NombreTipoMoneda, @Activo, @Resultado OUTPUT", varIdTipoMoneda, varIdUser, varNombreTipoMoneda, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el tipo moneda " + NombreTipoMoneda + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarTipoMoneda(string IdUser, int IdTipoMoneda)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdTipoMoneda = new SqlParameter("@IdTipoMoneda", SqlDbType.Int) { Value = IdTipoMoneda };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarTipoMoneda @IdUser, @IdTipoMoneda, @Resultado OUTPUT", varIdUser, varIdTipoMoneda, varResultado);

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

        public List<CargarDatosTipoMoneda> CargarDatosTipoMoneda(int IdTipoMoneda)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosTipoMoneda>("SP_CargarDatosTipoMoneda @IdTipoMoneda",
                    new SqlParameter("@IdTipoMoneda", IdTipoMoneda)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaTipoMoneda> ListaTipoMoneda()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaTipoMoneda>("SP_ListaTipoMoneda").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridTipoMoneda> GridTipoMoneda()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridTipoMoneda>("SP_GridTipoMoneda").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
