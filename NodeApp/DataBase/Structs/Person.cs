using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp
{
    class Person
    {

        #region Własności
        public int person_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int active { get; set; }
        #endregion

        #region Konstruktory

        public Person(SqlDataReader reader)
        {
            person_id = int.Parse(reader["person_id"].ToString());
            first_name = reader["first_name"].ToString();
            last_name = reader["last_name"].ToString();

        }

        public Person(string imie, string nazwisko)
        {
           
            first_name = imie.Trim();
            last_name = nazwisko.Trim();

        }

        public Person(Person person)
        {
            person_id = person.person_id;
            first_name = person.first_name;
            last_name = person.last_name;

        }

        #endregion

        #region Metody

        public override string ToString()
        {
            return $"{last_name} {first_name} ";
        }

        public string ToInsert()
        {
            return $"('{last_name}', '{first_name}')";
        }

        public override bool Equals(object obj)
        {

            var person = obj as Person;
            if (person is null) return false;
            if (first_name.ToLower() != person.first_name.ToLower()) return false;
            if (last_name.ToLower() != person.last_name.ToLower()) return false;
            return true;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }


}
