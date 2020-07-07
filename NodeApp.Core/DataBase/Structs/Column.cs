using System.Data.SqlClient;


namespace NodeApp
{
    public class Column : System.IComparable<Column>
    {
        public int column_id { get; set; }
        public string column_name { get; set; }
        public int column_order { get; set; }
        public int room_id { get; set; }

        public Column(SqlDataReader reader)
        {
            column_id = int.Parse(reader["column_id"].ToString());
            column_order= int.Parse(reader["column_order"].ToString());
            column_name = reader["column_name"].ToString();
            room_id = int.Parse(reader["room_id"].ToString());
        }

        public Column(string text, int room_id, int column_order)
        {
            this.column_name = text.Trim();
            this.room_id = room_id;
            this.column_order = column_order;
            DataColumn.AddColumn(this);
        }

        public Column(int column_id,string text, int room_id, int column_order)
        {
            this.column_id = column_id;
            this.column_name = text;
            this.room_id = room_id;
            this.column_order = column_order;
        }

        public Column(Column column)
        {
            column_id = column.column_id;
            column_name = column.column_name;
            room_id = column.room_id;
            column_order = column.column_order;
        }

        public override string ToString()
        {
            return $"{column_name},{room_id},{column_order}";
        }

        public string ToInsert()
        {
            return $"('{column_name}','{room_id}','{column_order}')";
        }

        public override bool Equals(object obj)
        {
            var lable = obj as Column;
            if (lable is null) return false;
            if (column_name.ToLower() != lable.column_name.ToLower()) return false;
            return true;
        }

        public int CompareTo(Column comparePart)
        {
            if (comparePart == null)
                return 1;
            else
                return this.column_order.CompareTo(comparePart.column_order);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
