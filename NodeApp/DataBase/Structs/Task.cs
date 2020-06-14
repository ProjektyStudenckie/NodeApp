using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NodeApp.DataBase
{
    public class Task

    {
        public int task_id { get; set; }
        public string task_name { get; set; }
        public int active { get; set; }



        public Task(SqlDataReader reader)
        {
            task_id = int.Parse(reader["task_id"].ToString());
            task_name = reader["task_name"].ToString();
            active= int.Parse(reader["active"].ToString());

        }

        public Task(string name,int act)
        {
            task_name = name.Trim();
            active = act;
        }

        public Task(Task room)
        {
            task_id = room.task_id;
            task_name = room.task_name;

        }



        public override string ToString()
        {
            return $" {task_name} ";
        }

        public string ToInsert()
        {
            return $"('{task_name}','{active}')";
        }

        public override bool Equals(object obj)
        {

            var task = obj as DataBase.Task;
            if (task is null) return false;
            if (task_name.ToLower() != task.task_name.ToLower()) return false;
            return true;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
