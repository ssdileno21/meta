using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testeMeta.dal
{
    public class conection
    {
        public SqlConnection conn = new SqlConnection();
        
        public conection()
        {
            conn.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; 
                                    AttachDbFilename = C:\projects\meta\testeMeta\testeMeta\App_Data\bd_meta.mdf; 
                                    Integrated Security = True";
        }

        public SqlConnection ToConnect()
        { 
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
        
        public void Disconnect()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
