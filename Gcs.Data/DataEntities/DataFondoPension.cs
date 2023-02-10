using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.FondoPension;

namespace Gcs.Data.DataEntities
{
    public class DataFondoPension
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearFondoPension(string IdUser, string NombreFondoPension, string Email, string Telefono)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreFondoPension = new SqlParameter("@NombreFondoPension", SqlDbType.VarChar) { Value = NombreFondoPension };
                var varEmail = new SqlParameter("@Email", SqlDbType.VarChar) { Value = Email };
                var varTelefono = new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = Telefono };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearFondoPension @IdUser, @NombreFondoPension, @Email, @Telefono, @Resultado OUTPUT", varIdUser, varNombreFondoPension, varEmail, varTelefono, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el fondo pensión " + NombreFondoPension + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosFondoPension(int IdFondoPension, string IdUser, string NombreFondoPension, string Email, string Telefono, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdFondoPension = new SqlParameter("@IdFondoPension", SqlDbType.Int) { Value = IdFondoPension };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreFondoPension = new SqlParameter("@NombreFondoPension", SqlDbType.VarChar) { Value = NombreFondoPension };
                var varEmail = new SqlParameter("@Email", SqlDbType.VarChar) { Value = Email };
                var varTelefono = new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = Telefono };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosFondoPension @IdFondoPension, @IdUser, @NombreFondoPension, @Email, @Telefono, @Activo, @Resultado OUTPUT", varIdFondoPension, varIdUser, varNombreFondoPension, varEmail, varTelefono, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el fondo pensión " + NombreFondoPension + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarFondoPension(string IdUser, int IdFondoPension)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdFondoPension = new SqlParameter("@IdFondoPension", SqlDbType.Int) { Value = IdFondoPension };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarFondoPension @IdUser, @IdFondoPension, @Resultado OUTPUT", varIdUser, varIdFondoPension, varResultado);

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

        public List<CargarDatosFondoPension> CargarDatosFondoPension(int IdFondoPension)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosFondoPension>("SP_CargarDatosFondoPension @IdFondoPension",
                    new SqlParameter("@IdFondoPension", IdFondoPension)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaFondoPension> ListaFondoPension()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaFondoPension>("SP_ListaFondoPension").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridFondoPension> GridFondoPension()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridFondoPension>("SP_GridFondoPension").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
