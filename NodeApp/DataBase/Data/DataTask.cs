using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp.DataBase
{
    class DataTask
    {
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
        {
            bool stan = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand($"{DODAJ_OSOBE} {person.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                //osoba.person_id = (int)command.GetLastInsertId();
                connection.Close();
            }
            return stan;
        }

        public static bool EditTask(Task person, int idOsoby)
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
    }
}
