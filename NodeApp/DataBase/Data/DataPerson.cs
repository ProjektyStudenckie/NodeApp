using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp.DataBase
{
    public class DataPerson
    {

        private const string ALL_USERS = "SELECT * FROM PERSON";
        private const string ADD_PERSON = "INSERT INTO `PERSON`(`last_name`, `first_name`) VALUES ";



        public static List<Person> DownloadUsers()
        {
            List<Person> users = new List<Person>();
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand(ALL_USERS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    users.Add(new Person(reader));
                connection.Close();
            }
            return users;
        }

        public static bool AddPerson(Person person)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand($"{ADD_PERSON} {person.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                succ = true;

                command = new SqlCommand($"SELECT MAX(ID) FROM PERSON", connection);
                person.person_id = (int)command.ExecuteNonQuery();
                connection.Close();
            }
            return succ;
        }

        public static bool EditPerson(Person person, int idPerson)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string EDIT_PERSON = $"UPDATE PERSON SET first_name='{person.first_name}', last_name='{person.last_name}', " +
                    $"WHERE person_id={idPerson}";

                SqlCommand command = new SqlCommand(EDIT_PERSON, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }
        public static bool DeletePerson(Person person)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string DELETE_PERSON = $"DELETE FROM PERSON" +
                    $"WHERE person_id={person.person_id}";

                SqlCommand command = new SqlCommand(DELETE_PERSON, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }
    }
}
