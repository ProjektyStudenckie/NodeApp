using System.Collections.Generic;
using System.Data.SqlClient;

namespace NodeApp
{
    public class DataLable
    {

        private const string ALL_LABLE = "SELECT * FROM LABLE";
        private const string ADD_LABLE = "INSERT INTO LABLE VALUES ";




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
                
                command = new SqlCommand($"SELECT MAX(lable_id) ID FROM LABLE", connection);
                var reader = command.ExecuteReader();
                reader.Read();
                lable.lable_id = int.Parse(reader["ID"].ToString());

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


        public List<Tasks> ReturnTasksOfColumn(Column column)
        {
            List<Tasks> tasks = new List<Tasks>();
            using (var connection = DBconnect.Instance.Connection)
            {

                string COLUMNS_OF_ROOM = $"SELECT * FROM TASK" +
                    $"WHERE column_id={column.room_id}";
                SqlCommand command = new SqlCommand(COLUMNS_OF_ROOM, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())

                    tasks.Add(new Tasks(reader));
                connection.Close();
            }
            return tasks;

        }
    }
}
