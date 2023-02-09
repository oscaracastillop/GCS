using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.TipoHoraExtra;

namespace Gcs.Data.DataEntities
{
    public class DataTipoHoraExtra
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearTipoHoraExtra(string IdUser, string NombreTipoHoraExtra)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoHoraExtra = new SqlParameter("@NombreTipoHoraExtra", SqlDbType.VarChar) { Value = NombreTipoHoraExtra };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearTipoHoraExtra @IdUser, @NombreTipoHoraExtra, @Resultado OUTPUT", varIdUser, varNombreTipoHoraExtra, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el tipo hora extra " + NombreTipoHoraExtra + " ya existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosTipoHoraExtra(int IdTipoHoraExtra, string IdUser, string NombreTipoHoraExtra, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdTipoHoraExtra = new SqlParameter("@IdTipoHoraExtra", SqlDbType.Int) { Value = IdTipoHoraExtra };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoHoraExtra = new SqlParameter("@NombreTipoHoraExtra", SqlDbType.VarChar) { Value = NombreTipoHoraExtra };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosTipoHoraExtra @IdTipoHoraExtra, @IdUser, @NombreTipoHoraExtra, @Activo, @Resultado OUTPUT", varIdTipoHoraExtra, varIdUser, varNombreTipoHoraExtra, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el tipo hora extra " + NombreTipoHoraExtra + " ya existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarTipoHoraExtra(string IdUser, int IdTipoHoraExtra)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdTipoHoraExtra = new SqlParameter("@IdTipoHoraExtra", SqlDbType.Int) { Value = IdTipoHoraExtra };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarTipoHoraExtra @IdUser, @IdTipoHoraExtra, @Resultado OUTPUT", varIdUser, varIdTipoHoraExtra, varResultado);

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

        public List<CargarDatosTipoHoraExtra> CargarDatosTipoHoraExtra(int IdTipoHoraExtra)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosTipoHoraExtra>("SP_CargarDatosTipoHoraExtra @IdTipoHoraExtra",
                    new SqlParameter("@IdTipoHoraExtra", IdTipoHoraExtra)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaTipoHoraExtra> ListaTipoHoraExtra()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaTipoHoraExtra>("SP_ListaTipoHoraExtra").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridTipoHoraExtra> GridTipoHoraExtra()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridTipoHoraExtra>("SP_GridTipoHoraExtra").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
