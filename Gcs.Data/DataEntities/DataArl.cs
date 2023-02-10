using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.Arl;

namespace Gcs.Data.DataEntities
{
    public class DataArl
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearArl(string IdUser, string NombreArl)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreArl = new SqlParameter("@NombreArl", SqlDbType.VarChar) { Value = NombreArl };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearArl @IdUser, @NombreArl, @Resultado OUTPUT", varIdUser, varNombreArl, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, la arl " + NombreArl + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosArl(int IdArl, string IdUser, string NombreArl, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdArl = new SqlParameter("@IdArl", SqlDbType.Int) { Value = IdArl };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreArl = new SqlParameter("@NombreArl", SqlDbType.VarChar) { Value = NombreArl };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosArl @IdArl, @IdUser, @NombreArl, @Activo, @Resultado OUTPUT", varIdArl, varIdUser, varNombreArl, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, la arl " + NombreArl + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarArl(string IdUser, int IdArl)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdArl = new SqlParameter("@IdArl", SqlDbType.Int) { Value = IdArl };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarArl @IdUser, @IdArl, @Resultado OUTPUT", varIdUser, varIdArl, varResultado);

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

        public List<CargarDatosArl> CargarDatosArl(int IdArl)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosArl>("SP_CargarDatosArl @IdArl",
                    new SqlParameter("@IdArl", IdArl)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaArl> ListaArl()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaArl>("SP_ListaArl").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridArl> GridArl()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridArl>("SP_GridArl").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
