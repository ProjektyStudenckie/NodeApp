using System.Collections.Generic;
using System.Data.SqlClient;

namespace NodeApp
{
    class DataTask
    {

        private const string ALL_TASKS = "SELECT * FROM TASK";
        private const string ADD_TASK = "INSERT INTO TASK VALUES ";



        public static List<Tasks> DownloadTasks()
        {
            List<Tasks> task = new List<Tasks>();
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand(ALL_TASKS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    task.Add(new Tasks(reader));
                connection.Close();
            }
            return task;
        }

        public static bool AddTask(Tasks task)

        {
            bool stan = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand($"{ADD_TASK} {task.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;

                command = new SqlCommand($"SELECT MAX(task_id) ID FROM TASK", connection);
                var reader = command.ExecuteReader();
                reader.Read();
                task.task_id = int.Parse(reader["ID"].ToString());

                connection.Close();
            }
            return stan;
        }

        public static bool EditTask(Tasks person, int idOsoby)

        {
            bool stan = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string EDIT_PERSON = $"UPDATE TASK SET task_name='{person.task_name}', " +
                    $"WHERE id_o={idOsoby}";

                SqlCommand command = new SqlCommand(EDIT_PERSON, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }

        public static bool DeleteTask(Tasks task)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string DELETE_TASK = $"DELETE FROM TASK" +
                    $" WHERE task_id={task.task_id}";

                SqlCommand command = new SqlCommand(DELETE_TASK, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }

        public static List<Tasks> ReturnTasksOfColumn(Column column)
        {
            List<Tasks> columns = new List<Tasks>();
            using (var connection = DBconnect.Instance.Connection)
            {

                string TASKS_OF_TASKS = $"SELECT * FROM TASK" +
                    $" WHERE column_id={column.column_id}";

                SqlCommand command = new SqlCommand(TASKS_OF_TASKS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    columns.Add(new Tasks(reader));
                connection.Close();
            }
            return columns;

        }

    }
}
