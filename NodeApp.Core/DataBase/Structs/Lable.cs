using System.Data.SqlClient;

namespace NodeApp.DataBase
{



    public class Lable
    {
        public int lable_id { get; set; }
        public string lable_text { get; set; }
        public string background { get; set; }
        public string foreground { get; set; }


        public Lable(SqlDataReader reader)
        {
            lable_id = int.Parse(reader["lable_id"].ToString());
            lable_text = reader["lable_text"].ToString();
            background = reader["background"].ToString();
            foreground = reader["foreground"].ToString();
        }

        public Lable(string text, string background, string foreground,int column_id)
        {
           
            this.lable_text = text.Trim();
            this.background = background.Trim();
            this.foreground = foreground.Trim();
        }

        public Lable(Lable lable)
        {
            lable_id = lable.lable_id;
            lable_text = lable.lable_text;
            background = lable.background;
            foreground = lable.foreground;

        }


        public override string ToString()
        {
            return $"{lable_text}, {background},{foreground}";
        }

        public string ToInsert()
        {
            return $"('{lable_text}','{background}','{foreground}')";
        }

        public override bool Equals(object obj)
        {

            var lable = obj as Lable;
            if (lable is null) return false;
            if (lable_text.ToLower() != lable.lable_text.ToLower()) return false;
            if (background.ToLower() != lable.background.ToLower()) return false;
            if (foreground.ToLower() != lable.foreground.ToLower()) return false;
            return true;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
   
    }


}
