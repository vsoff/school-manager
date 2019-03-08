using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Dao
{
    public interface ISportEntitiesContextProvider
    {
        SportEntitiesContext GetContext();
    }

    public class SportEntitiesContextProvider : ISportEntitiesContextProvider
    {
        /// <summary>
        /// Возвращает ConnectionString.
        /// </summary>
        /// <remarks>Метод только на время отладки. Необходимо вынести в параметры бизнес логики.</remarks>
        private static string GetConnectionString()
        {
            SqlConnectionStringBuilder bldr = new SqlConnectionStringBuilder();
            bldr.InitialCatalog = "SportManagerReborn5";
            bldr.DataSource = @"localhost";
            bldr.IntegratedSecurity = true;
            return bldr.ConnectionString;
        }

        public SportEntitiesContext GetContext()
        {
            var context = new SportEntitiesContext(GetConnectionString());
            context.Configuration.LazyLoadingEnabled = false;
            return context;
        }
    }
}
