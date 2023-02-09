using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.TipoUnidadMedida;

namespace Gcs.Data.DataEntities
{
    public class DataTipoUnidadMedida
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearTipoUnidadMedida(string IdUser, string NombreTipoUnidadMedida)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoUnidadMedida = new SqlParameter("@NombreTipoUnidadMedida", SqlDbType.VarChar) { Value = NombreTipoUnidadMedida };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearTipoUnidadMedida @IdUser, @NombreTipoUnidadMedida, @Resultado OUTPUT", varIdUser, varNombreTipoUnidadMedida, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el tipo unidad medida " + NombreTipoUnidadMedida + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosTipoUnidadMedida(int IdTipoUnidadMedida, string IdUser, string NombreTipoUnidadMedida, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdTipoUnidadMedida = new SqlParameter("@IdTipoUnidadMedida", SqlDbType.Int) { Value = IdTipoUnidadMedida };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoUnidadMedida = new SqlParameter("@NombreTipoUnidadMedida", SqlDbType.VarChar) { Value = NombreTipoUnidadMedida };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosTipoUnidadMedida @IdTipoUnidadMedida, @IdUser, @NombreTipoUnidadMedida, @Activo, @Resultado OUTPUT", varIdTipoUnidadMedida, varIdUser, varNombreTipoUnidadMedida, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el tipo unidad medida " + NombreTipoUnidadMedida + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarTipoUnidadMedida(string IdUser, int IdTipoUnidadMedida)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdTipoUnidadMedida = new SqlParameter("@IdTipoUnidadMedida", SqlDbType.Int) { Value = IdTipoUnidadMedida };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarTipoUnidadMedida @IdUser, @IdTipoUnidadMedida, @Resultado OUTPUT", varIdUser, varIdTipoUnidadMedida, varResultado);

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

        public List<CargarDatosTipoUnidadMedida> CargarDatosTipoUnidadMedida(int IdTipoUnidadMedida)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosTipoUnidadMedida>("SP_CargarDatosTipoUnidadMedida @IdTipoUnidadMedida",
                    new SqlParameter("@IdTipoUnidadMedida", IdTipoUnidadMedida)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaTipoUnidadMedida> ListaTipoUnidadMedida()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaTipoUnidadMedida>("SP_ListaTipoUnidadMedida").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridTipoUnidadMedida> GridTipoUnidadMedida()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridTipoUnidadMedida>("SP_GridTipoUnidadMedida").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
