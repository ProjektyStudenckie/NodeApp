using System.Data.SqlClient;


namespace NodeApp
{
    public class Column
    {
        public int column_id { get; set; }
        public string column_name { get; set; }
        public int room_id { get; set; }

        public Column(SqlDataReader reader)
        {
            column_id = int.Parse(reader["column_id"].ToString());
            column_name = reader["column_name"].ToString();
            room_id = int.Parse(reader["room_id"].ToString());
        }

        public Column(string text, int room_id)
        {

            this.column_name = text.Trim();
            this.room_id = room_id;

        }

        public Column(Column lable)
        {
            column_id = lable.column_id;
            column_name = lable.column_name;
            room_id = lable.room_id;
        }

        public override string ToString()
        {
            return $"{column_name},{room_id}";
        }

        public string ToInsert()
        {
            return $"('{column_name}','{room_id}')";
        }

        public override bool Equals(object obj)
        {
            var lable = obj as Column;
            if (lable is null) return false;
            if (column_name.ToLower() != lable.column_name.ToLower()) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
