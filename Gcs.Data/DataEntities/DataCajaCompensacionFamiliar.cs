using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.CajaCompensacionFamiliar;

namespace Gcs.Data.DataEntities
{
    public class DataCajaCompensacionFamiliar
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearCajaCompensacionFamiliar(string IdUser, string NombreCajaCompensacionFamiliar)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreCajaCompensacionFamiliar = new SqlParameter("@NombreCajaCompensacionFamiliar", SqlDbType.VarChar) { Value = NombreCajaCompensacionFamiliar };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearCajaCompensacionFamiliar @IdUser, @NombreCajaCompensacionFamiliar, @Resultado OUTPUT", varIdUser, varNombreCajaCompensacionFamiliar, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, la caja compensación familiar " + NombreCajaCompensacionFamiliar + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string GuardarCambiosCajaCompensacionFamiliar(int IdCajaCompensacionFamiliar, string IdUser, string NombreCajaCompensacionFamiliar, int Activo)
        {
            string resultado = String.Empty;
            try
            {
                var varIdCajaCompensacionFamiliar = new SqlParameter("@IdCajaCompensacionFamiliar", SqlDbType.Int) { Value = IdCajaCompensacionFamiliar };
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreCajaCompensacionFamiliar = new SqlParameter("@NombreCajaCompensacionFamiliar", SqlDbType.VarChar) { Value = NombreCajaCompensacionFamiliar };
                var varActivo = new SqlParameter("@Activo", SqlDbType.Int) { Value = Activo };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_GuardarCambiosCajaCompensacionFamiliar @IdCajaCompensacionFamiliar, @IdUser, @NombreCajaCompensacionFamiliar, @Activo, @Resultado OUTPUT", varIdCajaCompensacionFamiliar, varIdUser, varNombreCajaCompensacionFamiliar, varActivo, varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, la caja compensación familiar " + NombreCajaCompensacionFamiliar + " ya Existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }

        public string EliminarCajaCompensacionFamiliar(string IdUser, int IdCajaCompensacionFamiliar)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdCajaCompensacionFamiliar = new SqlParameter("@IdCajaCompensacionFamiliar", SqlDbType.Int) { Value = IdCajaCompensacionFamiliar };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_EliminarCajaCompensacionFamiliar @IdUser, @IdCajaCompensacionFamiliar, @Resultado OUTPUT", varIdUser, varIdCajaCompensacionFamiliar, varResultado);

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

        public List<CargarDatosCajaCompensacionFamiliar> CargarDatosCajaCompensacionFamiliar(int IdCajaCompensacionFamiliar)
        {
            try
            {
                return _conection.Database.SqlQuery<CargarDatosCajaCompensacionFamiliar>("SP_CargarDatosCajaCompensacionFamiliar @IdCajaCompensacionFamiliar",
                    new SqlParameter("@IdCajaCompensacionFamiliar", IdCajaCompensacionFamiliar)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ListaCajaCompensacionFamiliar> ListaCajaCompensacionFamiliar()
        {
            try
            {
                return _conection.Database.SqlQuery<ListaCajaCompensacionFamiliar>("SP_ListaCajaCompensacionFamiliar").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GridCajaCompensacionFamiliar> GridCajaCompensacionFamiliar()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridCajaCompensacionFamiliar>("SP_GridCajaCompensacionFamiliar").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
