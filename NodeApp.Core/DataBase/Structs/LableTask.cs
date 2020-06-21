<<<<<<< HEAD
﻿using System;
=======
﻿using NodeApp.DataBase;
using System;
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp
{
    public class LableTask
    {
<<<<<<< HEAD
=======


>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
        public int lable_id { get; set; }
        public int task_id { get; set; }


<<<<<<< HEAD
=======


>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
        public LableTask(SqlDataReader reader)
        {
            lable_id = int.Parse(reader["lable_id"].ToString());
            task_id = int.Parse(reader["task_id"].ToString());
<<<<<<< HEAD
        }

<<<<<<<< HEAD:NodeApp.Core/DataBase/Structs/LableTask.cs
        public LableTask(Lable person, Tasks task)
========
        public LableTask(Lable person, DataBase.Task task)
>>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6:NodeApp/DataBase/Structs/LableTask.cs
        {
            lable_id = person.lable_id;
            task_id = task.task_id;
=======


        }

        public LableTask(Lable person, Task task)
        {
            lable_id = person.lable_id;
            task_id = task.task_id;


>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
        }

        public LableTask(LableTask persontask)
        {
            lable_id = persontask.lable_id;
            task_id = persontask.task_id;
<<<<<<< HEAD
        }

=======

        }


>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
        public override string ToString()
        {
            return $"{lable_id} {task_id} ";
        }

        public string ToInsert()
        {
<<<<<<< HEAD
            return $"('{task_id}','{lable_id}')";
=======
            return $"('{lable_id}', '{task_id}')";
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
        }

        public override bool Equals(object obj)
        {
<<<<<<< HEAD
=======

>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
            var labletask = obj as LableTask;
            if (labletask is null) return false;
            if (task_id != labletask.task_id) return false;
            if (lable_id != labletask.lable_id) return false;
            return true;
        }

<<<<<<< HEAD
=======

>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
<<<<<<< HEAD
=======

        class PersonTask
        {
        }
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
    }
}
