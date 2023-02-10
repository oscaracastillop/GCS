using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.TipoGenero;

namespace Gcs.Data.DataEntities
{
    public class DataTipoGenero
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearTipoGenero(string IdUser, string NombreTipoGenero)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoGenero = new SqlParameter("@NombreTipoGenero", SqlDbType.VarChar) { Value = NombreTipoGenero };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearTipoGenero @IdUser, @NombreTipoGenero, @Resultado OUTPUT", varIdUser, varNombreTipoGenero, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el tipo genero " + NombreTipoGenero + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosTipoGenero(int IdTipoGenero, string IdUser, string NombreTipoGenero, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdTipoGenero = new SqlParameter("@IdTipoGenero", SqlDbType.Int) { Value = IdTipoGenero };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoGenero = new SqlParameter("@NombreTipoGenero", SqlDbType.VarChar) { Value = NombreTipoGenero };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosTipoGenero @IdTipoGenero, @IdUser, @NombreTipoGenero, @Activo, @Resultado OUTPUT", varIdTipoGenero, varIdUser, varNombreTipoGenero, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el tipo genero " + NombreTipoGenero + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarTipoGenero(string IdUser, int IdTipoGenero)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdTipoGenero = new SqlParameter("@IdTipoGenero", SqlDbType.Int) { Value = IdTipoGenero };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarTipoGenero @IdUser, @IdTipoGenero, @Resultado OUTPUT", varIdUser, varIdTipoGenero, varResultado);

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

        public List<CargarDatosTipoGenero> CargarDatosTipoGenero(int IdTipoGenero)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosTipoGenero>("SP_CargarDatosTipoGenero @IdTipoGenero",
                    new SqlParameter("@IdTipoGenero", IdTipoGenero)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaTipoGenero> ListaTipoGenero()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaTipoGenero>("SP_ListaTipoGenero").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridTipoGenero> GridTipoGenero()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridTipoGenero>("SP_GridTipoGenero").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
