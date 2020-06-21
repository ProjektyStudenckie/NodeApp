using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp.DataBase
{
    public class DataLableTask
    {

        private const string ALL_TASKLABLE = "SELECT * FROM TaskLableRelation";
        private const string ADD_TASKLABLE = "INSERT INTO `TaskLableRelation`(`lable_id`, `task_id`) VALUES ";



        public static List<LableTask> DownloadLableTask()
        {
            List<LableTask> relations = new List<LableTask>();
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand(ALL_TASKLABLE, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    relations.Add(new LableTask(reader));
                connection.Close();
            }
            return relations;
        }

        public static bool AddLableTask(LableTask relation)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand($"{ADD_TASKLABLE} {relation.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                succ = true;

                connection.Close();
            }
            return succ;
        }

        public static bool DeleteLableTask(LableTask relation)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string DELETE_RELATION = $"DELETE FROM TaskLableRelation" +
                    $"WHERE lable_id={relation.lable_id}"+$"AND task_id={relation.task_id}";

                SqlCommand command = new SqlCommand(DELETE_RELATION, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }

        public static List<Lable> ReturnLabelsOfTask(Task task)
        {
            List<Lable> lables = new List<Task>();
            using (var connection = DBconnect.Instance.Connection)
            {

                string COLUMNS_OF_ROOM = $"SELECT * FROM TASK" +
                    $"WHERE column_id={column.room_id}";
                SqlCommand command = new SqlCommand(COLUMNS_OF_ROOM, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    lables.Add(new Task(reader));
                connection.Close();
            }
            return lables;

        }
    }
}
