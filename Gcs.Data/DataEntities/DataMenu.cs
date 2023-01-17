using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.Menu;

namespace Gcs.Data.DataEntities
{
    public class DataMenu
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        public List<ListaMenu> ListaMenu(string Usuario)
        {
            try
            {
                var response = _conection.Database.SqlQuery<ListaMenu>("SP_Listamenu @IdUsuario", new SqlParameter("@IdUsuario", Usuario)).ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
