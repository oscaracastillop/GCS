using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.TipoVivienda;

namespace Gcs.Data.DataEntities
{
    public class DataTipoVivienda
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearTipoVivienda(string IdUser, string NombreTipoVivienda)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoVivienda = new SqlParameter("@NombreTipoVivienda", SqlDbType.VarChar) { Value = NombreTipoVivienda };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearTipoVivienda @IdUser, @NombreTipoVivienda, @Resultado OUTPUT", varIdUser, varNombreTipoVivienda, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el tipo vivienda " + NombreTipoVivienda + " ya existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosTipoVivienda(int IdTipoVivienda, string IdUser, string NombreTipoVivienda, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdTipoVivienda = new SqlParameter("@IdTipoVivienda", SqlDbType.Int) { Value = IdTipoVivienda };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreTipoVivienda = new SqlParameter("@NombreTipoVivienda", SqlDbType.VarChar) { Value = NombreTipoVivienda };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosTipoVivienda @IdTipoVivienda, @IdUser, @NombreTipoVivienda, @Activo, @Resultado OUTPUT", varIdTipoVivienda, varIdUser, varNombreTipoVivienda, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el tipo vivienda " + NombreTipoVivienda + " ya existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarTipoVivienda(string IdUser, int IdTipoVivienda)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdTipoVivienda = new SqlParameter("@IdTipoVivienda", SqlDbType.Int) { Value = IdTipoVivienda };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarTipoVivienda @IdUser, @IdTipoVivienda, @Resultado OUTPUT", varIdUser, varIdTipoVivienda, varResultado);

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

        public List<CargarDatosTipoVivienda> CargarDatosTipoVivienda(int IdTipoVivienda)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosTipoVivienda>("SP_CargarDatosTipoVivienda @IdTipoVivienda",
                    new SqlParameter("@IdTipoVivienda", IdTipoVivienda)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaTipoVivienda> ListaTipoVivienda()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaTipoVivienda>("SP_ListaTipoVivienda").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridTipoVivienda> GridTipoVivienda()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridTipoVivienda>("SP_GridTipoVivienda").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
