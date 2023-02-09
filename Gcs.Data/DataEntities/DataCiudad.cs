using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.Ciudad;

namespace Gcs.Data.DataEntities
{
    public class DataCiudad
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearCiudad(string IdUser, int IdDepartamento, string NombreCiudad)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdDepartamento = new SqlParameter("@IdDepartamento", SqlDbType.Int) { Value = IdDepartamento };
                var varNombreCiudad = new SqlParameter("@NombreCiudad", SqlDbType.VarChar) { Value = NombreCiudad };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearCiudad @IdUser, @IdDepartamento,@NombreCiudad, @Resultado OUTPUT", varIdUser, varIdDepartamento, varNombreCiudad, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, la Ciudad " + NombreCiudad + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosCiudad(int IdDepartamento, int IdCiudad, string IdUser, string NombreCiudad, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdDepartamento = new SqlParameter("@IdDepartamento", SqlDbType.Int) { Value = IdDepartamento };
                var varIdCiudad = new SqlParameter("@IdCiudad", SqlDbType.Int) { Value = IdCiudad };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreCiudad = new SqlParameter("@NombreCiudad", SqlDbType.VarChar) { Value = NombreCiudad };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosCiudad @IdDepartamento, @IdCiudad, @IdUser, @NombreCiudad, @Activo, @Resultado OUTPUT", varIdDepartamento, varIdCiudad, varIdUser, varNombreCiudad, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, la Ciudad " + NombreCiudad + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarCiudad(string IdUser, int IdCiudad)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdCiudad = new SqlParameter("@IdCiudad", SqlDbType.Int) { Value = IdCiudad };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarCiudad @IdUser, @IdCiudad, @Resultado OUTPUT", varIdUser, varIdCiudad, varResultado);

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

        public List<CargarDatosCiudad> CargarDatosCiudad(int IdCiudad)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosCiudad>("SP_CargarDatosCiudad @IdCiudad",
                    new SqlParameter("@IdCiudad", IdCiudad)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaCiudad> ListaCiudad()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaCiudad>("SP_ListaCiudad").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridCiudad> GridCiudad()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridCiudad>("SP_GridCiudad").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
