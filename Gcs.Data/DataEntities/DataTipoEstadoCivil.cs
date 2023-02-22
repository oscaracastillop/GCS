using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.TipoEstadoCivil;

namespace Gcs.Data.DataEntities
{
    public class DataTipoEstadoCivil
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearTipoEstadoCivil(string IdUser, string NombreTipoEstadoCivil)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoEstadoCivil = new SqlParameter("@NombreTipoEstadoCivil", SqlDbType.VarChar) { Value = NombreTipoEstadoCivil };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearTipoEstadoCivil @IdUser, @NombreTipoEstadoCivil, @Resultado OUTPUT", varIdUser, varNombreTipoEstadoCivil, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el  tipo estado civil " + NombreTipoEstadoCivil + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosTipoEstadoCivil(int IdTipoEstadoCivil, string IdUser, string NombreTipoEstadoCivil, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdTipoEstadoCivil = new SqlParameter("@IdTipoEstadoCivil", SqlDbType.Int) { Value = IdTipoEstadoCivil };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoEstadoCivil = new SqlParameter("@NombreTipoEstadoCivil", SqlDbType.VarChar) { Value = NombreTipoEstadoCivil };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosTipoEstadoCivil @IdTipoEstadoCivil, @IdUser, @NombreTipoEstadoCivil, @Activo, @Resultado OUTPUT", varIdTipoEstadoCivil, varIdUser, varNombreTipoEstadoCivil, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el  tipo estado civil " + NombreTipoEstadoCivil + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarTipoEstadoCivil(string IdUser, int IdTipoEstadoCivil)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdTipoEstadoCivil = new SqlParameter("@IdTipoEstadoCivil", SqlDbType.Int) { Value = IdTipoEstadoCivil };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarTipoEstadoCivil @IdUser, @IdTipoEstadoCivil, @Resultado OUTPUT", varIdUser, varIdTipoEstadoCivil, varResultado);

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

        public List<CargarDatosTipoEstadoCivil> CargarDatosTipoEstadoCivil(int IdTipoEstadoCivil)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosTipoEstadoCivil>("SP_CargarDatosTipoEstadoCivil @IdTipoEstadoCivil",
                    new SqlParameter("@IdTipoEstadoCivil", IdTipoEstadoCivil)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaTipoEstadoCivil> ListaTipoEstadoCivil()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaTipoEstadoCivil>("SP_ListaTipoEstadoCivil").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridTipoEstadoCivil> GridTipoEstadoCivil()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridTipoEstadoCivil>("SP_GridTipoEstadoCivil").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
