using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcs.Data.DataEntities
{
    public class DataRol
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();

        public string BuscarRolUsuario(string IdUser)
        {
            string resultado = String.Empty;
            try
            {
                var varIdUser = new SqlParameter("@IdUser", SqlDbType.VarChar) { Value = IdUser };
                var varResultado = new SqlParameter("@Resultado", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 255 };

                _conection.Database.ExecuteSqlCommand("SP_BuscarRolUsuario @IdUser, @Resultado OUTPUT", varIdUser, varResultado);

                resultado = Convert.ToString(varResultado.Value);
            }
            catch (Exception ex)
            {
                resultado = "Error*" + ex.Message;
            }
            return resultado;
        }
    }
}
