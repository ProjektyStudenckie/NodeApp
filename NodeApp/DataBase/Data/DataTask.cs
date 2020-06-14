using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NodeApp.DataBase
{
    public class DataTask
    {
        private const string ALL_TASKS = "SELECT * FROM TASK";
        private const string ADD_TASK = "INSERT INTO `TASK`(`task_name`) VALUES ";



        public static List<Task> DownloadTasks()
        {
            List<Task> tasks = new List<Task>();
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand(ALL_TASKS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    tasks.Add(new Task(reader));
                connection.Close();
            }
            return tasks;
        }

        public static bool AddTask(Task task)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand($"{ADD_TASK} {task.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                succ = true;

                command = new SqlCommand($"SELECT MAX(ID) FROM TASK", connection);
                task.task_id = (int)command.ExecuteNonQuery();

                connection.Close();
            }
            return succ;
        }

        public static bool EditTask(Task task, int idTask)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string EDIT_PERSON = $"UPDATE TASK SET task_name='{task.task_name}', " +
                    $"WHERE task_id={idTask}";


                SqlCommand command = new SqlCommand(EDIT_PERSON, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();

                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }

        public static bool DeleteTask(Task task)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string DELETE_TASK = $"DELETE FROM TASK" +
                    $"WHERE person_id={task.task_id}";

                SqlCommand command = new SqlCommand(DELETE_TASK, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;


        }
    }
}
