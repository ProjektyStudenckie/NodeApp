using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace NodeApp
=======
namespace NodeApp.DataBase
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
{
    class DataColumn
    {

        private const string ALL_COLUMN = "SELECT * FROM COLUM";
<<<<<<< HEAD
        private const string ADD_COLUMN = "INSERT INTO COLUM VALUES ";
=======
        private const string ADD_COLUMN = "INSERT INTO `COLUM`('column_name','room_id') VALUES ";
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6



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

<<<<<<< HEAD
                command = new SqlCommand($"SELECT MAX(column_id) ID FROM COLUM", connection);
                var reader = command.ExecuteReader();
                reader.Read();
                column.column_id = int.Parse(reader["ID"].ToString());
=======
                command = new SqlCommand($"SELECT MAX(column_id) FROM COLUM", connection);
                column.column_id = (int)command.ExecuteNonQuery();
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
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
<<<<<<< HEAD
                    $" WHERE column_id={column.column_id}";
=======
                    $"WHERE column_id={column.column_id}";
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6

                SqlCommand command = new SqlCommand(DELETE_COLUMN, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }

<<<<<<< HEAD
        public static List<Column> ReturnColumnsOfRoom(Room room)
=======
        public List<Column> ReturnColumnsOfRoom(Room room)
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
        {
            List<Column> columns = new List<Column>();
            using (var connection = DBconnect.Instance.Connection)
            {

                string TASKS_OF_COLUMN = $"SELECT * FROM COLUM" +
<<<<<<< HEAD
                    $" WHERE room_id={room.room_id}";
=======
                    $"WHERE room_id={room.room_id}";
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
                SqlCommand command = new SqlCommand(TASKS_OF_COLUMN, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    columns.Add(new Column(reader));
                connection.Close();
            }
            return columns;

        }
    }
}
