using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NodeApp
{
    public class Tasks: System.IComparable<Tasks>
    {
        public int task_id { get; set; }
        public string task_name { get; set; }
        public int task_order { get; set; }
        public int column_id { get; set; }


        public Tasks(SqlDataReader reader)
        {
            task_id = int.Parse(reader["task_id"].ToString());
            task_name = reader["task_name"].ToString();
            task_order= int.Parse(reader["task_order"].ToString());
            column_id= int.Parse(reader["column_id"].ToString());
        }

        public Tasks(string task_name, int task_order, int column_id)
        {
            this.task_name = task_name.Trim();
            this.task_order = task_order;
            this.column_id = column_id;
            DataTask.AddTask(this);
        }

        public Tasks(int task_id, string task_name, int task_order, int column_id)
        {
            this.task_id = task_id;
            this.task_name = task_name;
            this.task_order = task_order;
            this.column_id = column_id;
            
        }

        public Tasks(Tasks room)
        {
            task_id = room.task_id;
            task_name = room.task_name;
            column_id = room.column_id;
            task_order = room.task_order;

        }

        public override string ToString()
        {
            return $" {task_name} ";
        }

        public string ToInsert()
        {
            return $"('{task_order}','{task_name}','{column_id}')";
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

        public int CompareTo(Tasks comparePart)
        {
            if (comparePart == null)
                return 1;
            else
                return this.task_order.CompareTo(comparePart.task_order);
        }
    }
}
