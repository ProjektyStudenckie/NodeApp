using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp.DataBase
{
    class DBconnect
    {
        private SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();

        private static DBconnect instance = null;
        public static DBconnect Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBconnect();
                return instance;
            }
        }

        public SqlConnection Connection => new SqlConnection(stringBuilder.ToString());


        private DBconnect()
        {
            stringBuilder.UserID = Properties.Settings.Default.userID;
            stringBuilder.DataSource = Properties.Settings.Default.server;
            stringBuilder.InitialCatalog = Properties.Settings.Default.database;
            stringBuilder.Password = Properties.Settings.Default.paswd;
        }
    }
}
