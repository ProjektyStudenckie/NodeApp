using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp.DataBase
{
    public class DataPersonTask
    {

        private const string ALL_TASKPERSON = "SELECT * FROM TaskPersonRelation";
        private const string ADD_TASKPERSON = "INSERT INTO `TaskPersonRelation`(`person_id`, `task_id`) VALUES ";



        public static List<PersonTask> DownloadPersonTask()
        {
            List<PersonTask> relations = new List<PersonTask>();
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand(ALL_TASKPERSON, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    relations.Add(new PersonTask(reader));
                connection.Close();
            }
            return relations;
        }

        public static bool AddPersonTask(PersonTask relation)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand($"{ADD_TASKPERSON} {relation.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                succ = true;

                connection.Close();
            }
            return succ;
        }

        public static bool DeletePersonTask(PersonTask relation)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string DELETE_RELATION = $"DELETE FROM PERSON" +
                    $"WHERE person_id={relation.person_id}"+$"AND task_id={relation.task_id}";

                SqlCommand command = new SqlCommand(DELETE_RELATION, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }
    }
}
