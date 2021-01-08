using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OShop.Services
{
    public class DataComponent
    {
        public static ConnectionStringSettings sql_cs = ConfigurationManager.ConnectionStrings["dbConnectionString"];
        //public static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
    }
}
