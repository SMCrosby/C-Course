using System;

using Microsoft.Data.SqlClient;

namespace PRSLibrary {
    
    public class PrsConnection {

        public SqlConnection sqlConnection { get; set; } = null;        //variable to hold instance --null is also default naturally

        public void Connect() {
            sqlConnection.Open();
                if (sqlConnection.State != System.Data.ConnectionState.Open) {
                   throw new Exception("\n---Can't connect to SQL!---");
                }
            Console.WriteLine("\n---SqlConnection Opened---");
            //System.Diagnostics.Debug.WriteLine("\n---SqlConnection Opened---");      //another way to show message not on console
                return;
        }

        public void Disconnect() {
            if(sqlConnection ==null) {
                return;
            }
            sqlConnection.Close();
            if (sqlConnection.State == System.Data.ConnectionState.Closed) {
                Console.WriteLine("\n---SqlConnecion Closed---");
            }
            sqlConnection = null;
        }

        public PrsConnection(string server, string database) {
            var connStr = $"server={server}\\sqlexpress;database={database};trusted_connection=true;";        // double \\ turns into \ in mySql

            sqlConnection = new SqlConnection(connStr);
            
           

        }




    }
}


