using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.Eps;

namespace Gcs.Data.DataEntities
{
    public class DataEps
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearEps(string IdUser, string NombreEps)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreEps = new SqlParameter("@NombreEps", SqlDbType.VarChar) { Value = NombreEps };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearEps @IdUser, @NombreEps, @Resultado OUTPUT", varIdUser, varNombreEps, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, la Eps " + NombreEps + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosEps(int IdEps, string IdUser, string NombreEps, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdEps = new SqlParameter("@IdEps", SqlDbType.Int) { Value = IdEps };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreEps = new SqlParameter("@NombreEps", SqlDbType.VarChar) { Value = NombreEps };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosEps @IdEps, @IdUser, @NombreEps, @Activo, @Resultado OUTPUT", varIdEps, varIdUser, varNombreEps, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, la Eps " + NombreEps + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarEps(string IdUser, int IdEps)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdEps = new SqlParameter("@IdEps", SqlDbType.Int) { Value = IdEps };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarEps @IdUser, @IdEps, @Resultado OUTPUT", varIdUser, varIdEps, varResultado);

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

        public List<CargarDatosEps> CargarDatosEps(int IdEps)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosEps>("SP_CargarDatosEps @IdEps",
                    new SqlParameter("@IdEps", IdEps)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaEps> ListaEps()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaEps>("SP_ListaEps").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridEps> GridEps()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridEps>("SP_GridEps").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
