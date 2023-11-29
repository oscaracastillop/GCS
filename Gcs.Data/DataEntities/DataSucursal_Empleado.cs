using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gcs.Data.DataContext;
using static Gcs.Models.Models.SucursalEmpleado;

namespace Gcs.Data.DataEntities
{
    public class DataSucursal_Empleado
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        private readonly DataRol dataRol = new DataRol();

        public string CrearSucursalEmpleado(string IdUser, int IdSucursal, int IdEmpleado, string FechaInicial, string FechaFinal)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varIdSucursal = new SqlParameter("@IdSucursal", SqlDbType.Int) { Value = IdSucursal };
                var varIdEmpleado = new SqlParameter("@IdEmpleado", SqlDbType.Int) { Value = IdEmpleado };
                var varFechaInicial = new SqlParameter("@FechaInicial", SqlDbType.VarChar) { Value = FechaInicial };
                var varFechaFinal = new SqlParameter("@FechaFinal", SqlDbType.VarChar) { Value = FechaFinal };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_CrearSucursal_Empleado @IdUser, @IdSucursal, @IdEmpleado, @FechaInicial, @FechaFinal, @Resultado OUTPUT", varIdUser, varIdSucursal, varIdEmpleado, varFechaInicial, varFechaFinal, varResultado);

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
                    //if (ex.Message.Contains("No se puede insertar"))
                    //{
                    //    resultado = "Error*No se puede insertar valores duplicados, la Sucursal " + NombreSucursal + " ya existe";
                    //}
                    //else
                    //{
                    //    resultado = "Error*En el momento no se puede realizar este proceso, por favor comuniquese con el Administrador";
                    //}
                }
            }
            return resultado;
        }

        public List<GridSucursalEmpleado> GridSucursalEmpleado()
        {
            try
            {
                var response = _conection.Database.SqlQuery<GridSucursalEmpleado>("SP_GridSucursal_Empleado").ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
