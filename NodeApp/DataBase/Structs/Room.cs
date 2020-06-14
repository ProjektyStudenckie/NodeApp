using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp.DataBase
{
    public class Room
    {


        public int room_id { get; set; }
        public string room_name { get; set; }



        public Room(SqlDataReader reader)
        {
            room_id = int.Parse(reader["room_id"].ToString());
            room_name = reader["room_name"].ToString();
           

        }

        public Room(string name)
        {
            room_name = name.Trim();
        }

        public Room(Room room)
        {
            room_id = room.room_id;
            room_name = room.room_name;

        }



        public override string ToString()
        {
            return $" {room_name} ";
        }

        public string ToInsert()
        {
            return $"('{room_name}')";
        }

        public override bool Equals(object obj)
        {

            var room = obj as DataBase.Room;
            if (room is null) return false;
            if (room_name.ToLower() != room.room_name.ToLower()) return false;
            return true;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
