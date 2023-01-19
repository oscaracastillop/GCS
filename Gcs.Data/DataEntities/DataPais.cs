using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.Pais;

namespace Gcs.Data.DataEntities
{
    public class DataPais
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearPais(string IdUser, string NombrePais)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombrePais = new SqlParameter("@NombrePais", SqlDbType.VarChar) { Value = NombrePais };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearPais @IdUser, @NombrePais, @Resultado OUTPUT", varIdUser, varNombrePais, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el País " + NombrePais + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosPais(int IdPais, string IdUser, string NombrePais, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdPais = new SqlParameter("@IdPais", SqlDbType.Int) { Value = IdPais };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombrePais = new SqlParameter("@NombrePais", SqlDbType.VarChar) { Value = NombrePais };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosPais @IdPais, @IdUser, @NombrePais, @Activo, @Resultado OUTPUT", varIdPais, varIdUser, varNombrePais, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el País " + NombrePais + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarPais(string IdUser, int IdPais)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdPais = new SqlParameter("@IdPais", SqlDbType.Int) { Value = IdPais };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarPais @IdUser, @IdPais, @Resultado OUTPUT", varIdUser, varIdPais, varResultado);

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

        public List<CargarDatosPais> CargarDatosPais(int IdPais)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosPais>("SP_CargarDatosPais @IdPais",
                    new SqlParameter("@IdPais", IdPais)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaPais> ListaPais()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaPais>("SP_ListaPais").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridPais> GridPais()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridPais>("SP_GridPais").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
