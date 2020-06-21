using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp
{
    class DataTask
    {
<<<<<<< HEAD
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
=======
        private const string WSZYSTKIE_OSOBY = "SELECT * FROM TASK";
        private const string DODAJ_OSOBE = "INSERT INTO `TASK`(`task_name`) VALUES ";



        public static List<Task> PobierzWszystkieOsoby()
        {
            List<Task> osoby = new List<Task>();
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand(WSZYSTKIE_OSOBY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    osoby.Add(new Task(reader));
                connection.Close();
            }
            return osoby;
        }

        public static bool AddTask(Task person)
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
        {
            bool stan = false;
            using (var connection = DBconnect.Instance.Connection)
            {
<<<<<<< HEAD
                SqlCommand command = new SqlCommand($"{ADD_TASK} {task.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;

                command = new SqlCommand($"SELECT MAX(task_id) ID FROM TASK", connection);
                var reader = command.ExecuteReader();
                reader.Read();
                task.task_id = int.Parse(reader["ID"].ToString());
=======
                SqlCommand command = new SqlCommand($"{DODAJ_OSOBE} {person.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                //osoba.person_id = (int)command.GetLastInsertId();
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
                connection.Close();
            }
            return stan;
        }

<<<<<<< HEAD
        public static bool EditTask(Tasks person, int idOsoby)
=======
        public static bool EditTask(Task person, int idOsoby)
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
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
<<<<<<< HEAD

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
=======
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
    }
}
