using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.Departamento;

namespace Gcs.Data.DataEntities
{
    public class DataDepartamento
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearDepartamento(string IdUser, int IdPais, string NombreDepartamento)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdPais = new SqlParameter("@IdPais", SqlDbType.Int) { Value = IdPais };
                var varNombreDepartamento = new SqlParameter("@NombreDepartamento", SqlDbType.VarChar) { Value = NombreDepartamento };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearDepartamento @IdUser, @IdPais,@NombreDepartamento, @Resultado OUTPUT", varIdUser, varIdPais, varNombreDepartamento, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el País " + NombreDepartamento + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosDepartamento(int IdPais, int IdDepartamento, string IdUser, string NombreDepartamento, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdPais = new SqlParameter("@IdPais", SqlDbType.Int) { Value = IdPais };
                var varIdDepartamento = new SqlParameter("@IdDepartamento", SqlDbType.Int) { Value = IdDepartamento };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreDepartamento = new SqlParameter("@NombreDepartamento", SqlDbType.VarChar) { Value = NombreDepartamento };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosDepartamento @IdPais, @IdDepartamento, @IdUser, @NombreDepartamento, @Activo, @Resultado OUTPUT", varIdPais, varIdDepartamento, varIdUser, varNombreDepartamento, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el País " + NombreDepartamento + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarDepartamento(string IdUser, int IdDepartamento)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdDepartamento = new SqlParameter("@IdDepartamento", SqlDbType.Int) { Value = IdDepartamento };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarDepartamento @IdUser, @IdDepartamento, @Resultado OUTPUT", varIdUser, varIdDepartamento, varResultado);

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

        public List<CargarDatosDepartamento> CargarDatosDepartamento(int IdDepartamento)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosDepartamento>("SP_CargarDatosDepartamento @IdDepartamento",
                    new SqlParameter("@IdDepartamento", IdDepartamento)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaDepartamento> ListaDepartamento()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaDepartamento>("SP_ListaDepartamento").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridDepartamento> GridDepartamento()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridDepartamento>("SP_GridDepartamento").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
