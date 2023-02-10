using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.FondoCesantias;

namespace Gcs.Data.DataEntities
{
    public class DataFondoCesantias
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearFondoCesantias(string IdUser, string NombreFondoCesantias, string Email, string Telefono)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreFondoCesantias = new SqlParameter("@NombreFondoCesantias", SqlDbType.VarChar) { Value = NombreFondoCesantias };
                var varEmail = new SqlParameter("@Email", SqlDbType.VarChar) { Value = Email };
                var varTelefono = new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = Telefono };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearFondoCesantias @IdUser, @NombreFondoCesantias, @Email, @Telefono, @Resultado OUTPUT", varIdUser, varNombreFondoCesantias, varEmail, varTelefono, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, al fondo cesantías " + NombreFondoCesantias + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosFondoCesantias(int IdFondoCesantias, string IdUser, string NombreFondoCesantias, string Email, string Telefono, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdFondoCesantias = new SqlParameter("@IdFondoCesantias", SqlDbType.Int) { Value = IdFondoCesantias };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreFondoCesantias = new SqlParameter("@NombreFondoCesantias", SqlDbType.VarChar) { Value = NombreFondoCesantias };
                var varEmail = new SqlParameter("@Email", SqlDbType.VarChar) { Value = Email };
                var varTelefono = new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = Telefono };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosFondoCesantias @IdFondoCesantias, @IdUser, @NombreFondoCesantias, @Email, @Telefono, @Activo, @Resultado OUTPUT", varIdFondoCesantias, varIdUser, varNombreFondoCesantias, varEmail, varTelefono, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, al fondo cesantías " + NombreFondoCesantias + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarFondoCesantias(string IdUser, int IdFondoCesantias)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdFondoCesantias = new SqlParameter("@IdFondoCesantias", SqlDbType.Int) { Value = IdFondoCesantias };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarFondoCesantias @IdUser, @IdFondoCesantias, @Resultado OUTPUT", varIdUser, varIdFondoCesantias, varResultado);

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

        public List<CargarDatosFondoCesantias> CargarDatosFondoCesantias(int IdFondoCesantias)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosFondoCesantias>("SP_CargarDatosFondoCesantias @IdFondoCesantias",
                    new SqlParameter("@IdFondoCesantias", IdFondoCesantias)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaFondoCesantias> ListaFondoCesantias()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaFondoCesantias>("SP_ListaFondoCesantias").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridFondoCesantias> GridFondoCesantias()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridFondoCesantias>("SP_GridFondoCesantias").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
