using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MealPlanner.data
{
    public class DBConnection
    {
        public static String GetConnection() {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static void OpenConnection(SqlConnection conn) {
            if (conn.State == System.Data.ConnectionState.Closed) {
                conn.Open();
            }
        }

        public static void CloseConnection(SqlConnection conn) {
            if (conn.State == System.Data.ConnectionState.Open) {
                conn.Close();
            }
        }
    }
}