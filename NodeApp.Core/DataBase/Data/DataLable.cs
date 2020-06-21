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
    public class DataLable
    {

        private const string ALL_LABLE = "SELECT * FROM LABLE";
<<<<<<< HEAD
        private const string ADD_LABLE = "INSERT INTO LABLE VALUES ";
=======
        private const string ADD_LABLE = "INSERT INTO `LABLE`('lable_text','background','foreground','column_id') VALUES ";
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6



        public static List<Lable> DownloadLables()
        {
            List<Lable> users = new List<Lable>();
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand(ALL_LABLE, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    users.Add(new Lable(reader));
                connection.Close();
            }
            return users;
        }

        public static bool AddLable(Lable lable)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand($"{ADD_LABLE} {lable.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                succ = true;
<<<<<<< HEAD
                
                command = new SqlCommand($"SELECT MAX(lable_id) ID FROM LABLE", connection);
                var reader = command.ExecuteReader();
                reader.Read();
                lable.lable_id = int.Parse(reader["ID"].ToString());
=======

                command = new SqlCommand($"SELECT MAX(lable_id) FROM LABLE", connection);
                lable.lable_id = (int)command.ExecuteNonQuery();
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
                connection.Close();
            }
            return succ;
        }

        public static bool EditLable(Lable lable, int idLable)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string EDIT_LABLE = $"UPDATE LABLE SET lable_text='{lable.lable_text}', lable_background='{lable.background}', column_id='??', " +
                    $"WHERE lable_id={idLable}";

                SqlCommand command = new SqlCommand(EDIT_LABLE, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }
        public static bool DeleteLable(Lable lable)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string DELETE_LABLE = $"DELETE FROM LABLE" +
                    $"WHERE lable_id={lable.lable_id}";

                SqlCommand command = new SqlCommand(DELETE_LABLE, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }

<<<<<<< HEAD
        public List<Tasks> ReturnTasksOfColumn(Column column)
        {
            List<Tasks> tasks = new List<Tasks>();
=======
        public List<Task> ReturnTasksOfColumn(Column column)
        {
            List<Task> tasks = new List<Task>();
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
            using (var connection = DBconnect.Instance.Connection)
            {

                string COLUMNS_OF_ROOM = $"SELECT * FROM TASK" +
                    $"WHERE column_id={column.room_id}";
                SqlCommand command = new SqlCommand(COLUMNS_OF_ROOM, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
<<<<<<< HEAD
                    tasks.Add(new Tasks(reader));
=======
                    tasks.Add(new Task(reader));
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
                connection.Close();
            }
            return tasks;

        }
    }
}
