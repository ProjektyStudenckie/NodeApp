using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp.DataBase
{
    class DataPerson
    {

        private const string WSZYSTKIE_OSOBY = "SELECT * FROM PERSON";
        private const string DODAJ_OSOBE = "INSERT INTO `PERSON`(`last_name`, `first_name`) VALUES ";



        public static List<Person> PobierzWszystkieOsoby()
        {
            List<Person> osoby = new List<Person>();
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand(WSZYSTKIE_OSOBY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    osoby.Add(new Person(reader));
                connection.Close();
            }
            return osoby;
        }

        public static bool AddPerson(Person person)
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

        public static bool EditPerson(Person person, int idOsoby)
        {
            bool stan = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string EDIT_PERSON = $"UPDATE PERSON SET first_name='{person.first_name}', last_name='{person.last_name}', " +
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
