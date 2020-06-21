using System.Data.SqlClient;

<<<<<<< HEAD
namespace NodeApp
{
=======
namespace NodeApp.DataBase
{



>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
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

<<<<<<< HEAD
        public Lable(string text, string background, string foreground)
=======
        public Lable(string text, string background, string foreground,int column_id)
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
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

<<<<<<< HEAD
=======

>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
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
<<<<<<< HEAD
=======

>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
            var lable = obj as Lable;
            if (lable is null) return false;
            if (lable_text.ToLower() != lable.lable_text.ToLower()) return false;
            if (background.ToLower() != lable.background.ToLower()) return false;
            if (foreground.ToLower() != lable.foreground.ToLower()) return false;
            return true;
        }

<<<<<<< HEAD
=======

>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
   
    }
<<<<<<< HEAD
=======


>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
}
