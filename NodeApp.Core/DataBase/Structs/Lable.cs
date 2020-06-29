using System.Data.SqlClient;


namespace NodeApp
{
    public class Lable
    {
        public int lable_id { get; set; }
        public int room_id { get; set; }
        public string lable_text { get; set; }
        public string background { get; set; }
        public string foreground { get; set; }


        public Lable(SqlDataReader reader)
        {
            lable_id = int.Parse(reader["lable_id"].ToString());
            lable_text = reader["lable_text"].ToString();
            background = reader["background"].ToString();
            foreground = reader["foreground"].ToString();
            room_id = int.Parse(reader["room_id"].ToString());
        }

        public Lable(string text, string background, string foreground, int room_id)
        {
           
            this.lable_text = text.Trim();
            this.background = background.Trim();
            this.foreground = foreground.Trim();
            this.room_id = room_id;
        }

        public Lable(Lable lable)
        {
            lable_id = lable.lable_id;
            lable_text = lable.lable_text;
            background = lable.background;
            foreground = lable.foreground;
            room_id = lable.room_id;

        }
        public override string ToString()
        {
            return $"{lable_text}, {background},{foreground},{room_id}";
        }

        public string ToInsert()
        {
            return $"('{lable_text}','{background}','{foreground}','{room_id}')";
        }

        public override bool Equals(object obj)
        {
            var lable = obj as Lable;
            if (lable is null) return false;
            if (lable_text.ToLower() != lable.lable_text.ToLower()) return false;
            if (background.ToLower() != lable.background.ToLower()) return false;
            if (foreground.ToLower() != lable.foreground.ToLower()) return false;
            if (room_id!= lable.room_id) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
   
    }
}
