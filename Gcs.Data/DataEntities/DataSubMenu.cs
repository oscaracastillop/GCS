using Gcs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gcs.Models.Models.SubMenu;

namespace Gcs.Data.DataEntities
{
    public class DataSubMenu
    {
        readonly GCS_DBEntities _conection = new GCS_DBEntities();
        public List<ListaSubMenu> ListaSubMenu(string Usuario, string Modulo)
        {
            try
            {
                var response = _conection.Database.SqlQuery<ListaSubMenu>("SP_ListaSubMenu @IdUsuario, @Modulo", new SqlParameter("@IdUsuario", Usuario), new SqlParameter("@Modulo", Modulo)).ToList();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
