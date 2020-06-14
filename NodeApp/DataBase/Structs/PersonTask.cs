using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp.DataBase.Structs
{
    public class PersonTask
    {


        public int person_id { get; set; }
        public int task_id { get; set; }




        public PersonTask(SqlDataReader reader)
        {
            person_id = int.Parse(reader["person_id"].ToString());
            task_id = int.Parse(reader["task_id"].ToString());
          

        }

        public PersonTask(Person person, Task task)
        {


        }

        public PersonTask(PersonTask persontask)
        {
            person_id = persontask.person_id;
            task_id = persontask.task_id;

        }


        public override string ToString()
        {
            return $"{person_id} {task_id} ";
        }

        public string ToInsert()
        {
            return $"('{person_id}', '{task_id}')";
        }

        public override bool Equals(object obj)
        {

            var persontask = obj as PersonTask;
            if (persontask is null) return false;
            if (task_id != persontask.task_id) return false;
            if (person_id != persontask.person_id) return false;
            return true;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
