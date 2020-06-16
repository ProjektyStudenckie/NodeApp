using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp.DataBase
{
    class DataColumn
    {

        private const string ALL_COLUMN = "SELECT * FROM COLUM";
        private const string ADD_COLUMN = "INSERT INTO `COLUM`('column_name','room_id') VALUES ";



        public static List<Column> DownloadColumns()
        {
            List<Column> users = new List<Column>();
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand(ALL_COLUMN, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    users.Add(new Column(reader));
                connection.Close();
            }
            return users;
        }

        public static bool AddColumn(Column column)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand($"{ADD_COLUMN} {column.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                succ = true;

                command = new SqlCommand($"SELECT MAX(column_id) FROM COLUM", connection);
                column.column_id = (int)command.ExecuteNonQuery();
                connection.Close();
            }
            return succ;
        }

        public static bool EditColumn(Column column, int idColumn)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string EDIT_LABLE = $"UPDATE COLUM SET column_name='{column.column_name}', room_id='{column.room_id}', " +
                    $"WHERE room_id={idColumn}";

                SqlCommand command = new SqlCommand(EDIT_LABLE, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }
        public static bool DeleteColumn(Column column)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string DELETE_COLUMN = $"DELETE FROM COLUM" +
                    $"WHERE lable_id={column.column_id}";

                SqlCommand command = new SqlCommand(DELETE_COLUMN, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }
    }
}
