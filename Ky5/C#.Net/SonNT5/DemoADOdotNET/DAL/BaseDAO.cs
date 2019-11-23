using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public abstract class BaseDAO<T>
    {
        public SqlConnection connection;
        public BaseDAO()
        {
            string strConnection = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
            connection = new SqlConnection(strConnection);
        }

        public abstract List<T> getAll();
        public abstract DataTable getTable();
        public abstract void insert(T entity);

        public abstract T get(int id);
    }
}
