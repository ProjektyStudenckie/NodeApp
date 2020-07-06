﻿using System.Collections.Generic;
using System.Data.SqlClient;


namespace NodeApp
{
    public class DataLableTask
    {

        private const string ALL_TASKLABLE = "SELECT * FROM TaskLableRelation";
        private const string ADD_TASKLABLE = "INSERT INTO TaskLableRelation VALUES ";



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

                    $" WHERE lable_id={relation.lable_id}"+$" AND task_id={relation.task_id}";


                SqlCommand command = new SqlCommand(DELETE_RELATION, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }


        public static List<Lable> ReturnLabelsOfTask(List<Lable> lables,Tasks task)

        {
            List<Lable> tasklables = new List<Lable>();
            using (var connection = DBconnect.Instance.Connection)
            {

                string COLUMNS_OF_ROOM = $"SELECT lable_id FROM TaskLableRelation" +
                    $" WHERE task_id={task.task_id}";
                SqlCommand command = new SqlCommand(COLUMNS_OF_ROOM, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    foreach (Lable x in lables)
                    {
                        if (x.lable_id == int.Parse(reader["lable_id"].ToString()))
                        {
                            tasklables.Add(x);
                        }

                    }
                }
                connection.Close();
            }
            return tasklables;

        }


        public static List<LableTask> ReturnRelationsOfTask(Tasks task)

        {
            List<LableTask> tasklables = new List<LableTask>();
            using (var connection = DBconnect.Instance.Connection)
            {

                string RelationsOfTask = ALL_TASKLABLE +
                    $" WHERE task_id={task.task_id}";
                SqlCommand command = new SqlCommand(RelationsOfTask, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    tasklables.Add(new LableTask(reader));
                connection.Close();
            }
            return tasklables;

        }

        public static List<LableTask> ReturnRelationsOfLable(Lable label)
        {
            List<LableTask> tasklables = new List<LableTask>();
            using (var connection = DBconnect.Instance.Connection)
            {

                string RelationsOfTask = ALL_TASKLABLE +
                    $" WHERE lable_id={label.lable_id}";
                SqlCommand command = new SqlCommand(RelationsOfTask, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    tasklables.Add(new LableTask(reader));
                connection.Close();
            }
            return tasklables;

        }

    }
}
