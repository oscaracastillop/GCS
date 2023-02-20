using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.Empleado;

namespace Gcs.Data.DataEntities
{
    public class DataEmpleado
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearEmpleado(string IdUser, string NombreEmpleado, string ApellidoEmpleado, int IdTipoDocumento, string Identificacion)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varNombreEmpleado = new SqlParameter("@NombreEmpleado", SqlDbType.VarChar) { Value = NombreEmpleado };
                var varApellidoEmpleado = new SqlParameter("@ApellidoEmpleado", SqlDbType.VarChar) { Value = ApellidoEmpleado };
                var varIdTipoDocumento = new SqlParameter("@IdTipoDocumento", SqlDbType.Int) { Value = IdTipoDocumento };
                var varIdentificacion = new SqlParameter("@Identificacion", SqlDbType.VarChar) { Value = Identificacion };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearEmpleado @IdUser, @NombreEmpleado, @ApellidoEmpleado, @IdTipoDocumento, @Identificacion, @Resultado OUTPUT", varIdUser, varNombreEmpleado, varApellidoEmpleado, varIdTipoDocumento, varIdentificacion,  varResultado);

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
                        resultado = "Error*No se puede insertar valores duplicados, el empleado " + NombreEmpleado + " ya existe";
                    }
                    else
                    {
                        resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    }
                }
            }
            return resultado;
        }









        public List<GridEmpleado> GridEmpleado()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridEmpleado>("SP_GridEmpleado").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
