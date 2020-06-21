
﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp
{
    public class LableTask
    {

        public int lable_id { get; set; }
        public int task_id { get; set; }


        public LableTask(SqlDataReader reader)
        {
            lable_id = int.Parse(reader["lable_id"].ToString());
            task_id = int.Parse(reader["task_id"].ToString());
        }


        public LableTask(Lable person, Tasks task)
        {
            lable_id = person.lable_id;
            task_id = task.task_id;


        }


        public LableTask(LableTask persontask)
        {
            lable_id = persontask.lable_id;
            task_id = persontask.task_id;

        }


        public override string ToString()
        {
            return $"{lable_id} {task_id} ";
        }

        public string ToInsert()
        {

            return $"('{task_id}','{lable_id}')";

        }

        public override bool Equals(object obj)
        {

            var labletask = obj as LableTask;
            if (labletask is null) return false;
            if (task_id != labletask.task_id) return false;
            if (lable_id != labletask.lable_id) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
