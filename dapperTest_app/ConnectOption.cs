using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dapperTest_app
{
    static public class ConnectOption
    {
        static string server = "localhost";
        static string database = "test";
        static string user = "root";
        static string pass = "";
        static string charset = "utf8";
        public static string connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3};", server, database, user, pass);
    }
}
