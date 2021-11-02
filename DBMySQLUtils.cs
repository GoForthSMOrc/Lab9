using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace StudentSessionTry
{
    class DBMySQLUtils
    {
        public static MySqlConnection GetDBConnection(string host, int port, string database, string username, string password)
        {
            String connString = "Server = " + host + ";Database = " + database + "; Port = " + port + "; User = " + username + "; Password = " + password ;
            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }

        public static MySqlConnection GetDBConnection2(string host, int port, string database, string username, string password)
        {
            String connString = "Server = " + host + ";Database = " + database + "; Port = " + port + "; User = " + username + "; Password = " + password;
            MySqlConnection conn2 = new MySqlConnection(connString);

            return conn2;
        }
    }
}
