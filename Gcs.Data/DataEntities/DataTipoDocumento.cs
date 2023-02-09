using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.TipoDocumento;

namespace Gcs.Data.DataEntities
{
    public class DataTipoDocumento
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearTipoDocumento(string IdUser, string NombreTipoDocumento)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoDocumento = new SqlParameter("@NombreTipoDocumento", SqlDbType.VarChar) { Value = NombreTipoDocumento };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearTipoDocumento @IdUser, @NombreTipoDocumento, @Resultado OUTPUT", varIdUser, varNombreTipoDocumento, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el tipo documento " + NombreTipoDocumento + " ya existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosTipoDocumento(int IdTipoDocumento, string IdUser, string NombreTipoDocumento, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdTipoDocumento = new SqlParameter("@IdTipoDocumento", SqlDbType.Int) { Value = IdTipoDocumento };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoDocumento = new SqlParameter("@NombreTipoDocumento", SqlDbType.VarChar) { Value = NombreTipoDocumento };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosTipoDocumento @IdTipoDocumento, @IdUser, @NombreTipoDocumento, @Activo, @Resultado OUTPUT", varIdTipoDocumento, varIdUser, varNombreTipoDocumento, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el tipo documento " + NombreTipoDocumento + " ya existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarTipoDocumento(string IdUser, int IdTipoDocumento)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdTipoDocumento = new SqlParameter("@IdTipoDocumento", SqlDbType.Int) { Value = IdTipoDocumento };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarTipoDocumento @IdUser, @IdTipoDocumento, @Resultado OUTPUT", varIdUser, varIdTipoDocumento, varResultado);

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

        public List<CargarDatosTipoDocumento> CargarDatosTipoDocumento(int IdTipoDocumento)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosTipoDocumento>("SP_CargarDatosTipoDocumento @IdTipoDocumento",
                    new SqlParameter("@IdTipoDocumento", IdTipoDocumento)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaTipoDocumento> ListaTipoDocumento()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaTipoDocumento>("SP_ListaTipoDocumento").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridTipoDocumento> GridTipoDocumento()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridTipoDocumento>("SP_GridTipoDocumento").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
