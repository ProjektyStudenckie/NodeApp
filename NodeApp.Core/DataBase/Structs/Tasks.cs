using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp
{
    public class Tasks
    {
        public int task_id { get; set; }
        public string task_name { get; set; }
        public int active { get; set; }
        public int column_id { get; set; }


        public Tasks(SqlDataReader reader)
        {
            task_id = int.Parse(reader["task_id"].ToString());
            task_name = reader["task_name"].ToString();
            active= int.Parse(reader["active"].ToString());
            column_id= int.Parse(reader["column_id"].ToString());
        }

        public Tasks(string task_name, int active, int column_id)
        {
            this.task_name = task_name.Trim();
            this.active = active;
            this.column_id = column_id;
        }

        public Tasks(Tasks room)
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
            return $"('{active}','{task_name}','{column_id}')";
        }

        public override bool Equals(object obj)
        {
            var task = obj as Tasks;
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
