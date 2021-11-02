using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace StudentSessionTry
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "StudentSession";
            string username = "root";
            string password = "root";

            return DBMySQLUtils.GetDBConnection(host,port,database,username,password);
        }

        public static MySqlConnection GetDBConnection2()
        {
            string host = "localhost";
            int port = 3306;
            string database = "StudentSession";
            string username = "root";
            string password = "root";

            return DBMySQLUtils.GetDBConnection2(host, port, database, username, password);
        }
    }
}
