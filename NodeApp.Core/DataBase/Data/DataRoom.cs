using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace NodeApp
=======
namespace NodeApp.DataBase
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
{
    public class DataRoom
    {
        private const string All_ROOMS = "SELECT * FROM ROOM";
<<<<<<< HEAD
        private const string ADD_ROOM = "INSERT INTO ROOM VALUES ";
=======
        private const string ADD_ROOM = "INSERT INTO `ROOM`(`room_name`) VALUES ";
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6



        public static List<Room> DownloadRooms()
        {
            List<Room> roooms = new List<Room>();
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand(All_ROOMS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    roooms.Add(new Room(reader));
                connection.Close();
            }
            return roooms;
        }

        public static bool AddRoom(Room room)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand($"{ADD_ROOM} {room.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                succ = true;

<<<<<<< HEAD
                command = new SqlCommand($"SELECT MAX(room_id) ID FROM ROOM", connection);
                var reader = command.ExecuteReader();
                reader.Read();
                room.room_id = int.Parse(reader["ID"].ToString());
                
=======
                command = new SqlCommand($"SELECT MAX(ID) FROM ROOM", connection);
                room.room_id = (int)command.ExecuteNonQuery();

>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6
                connection.Close();
            }
            return succ;
        }

        public static bool EditRoom(Room room, int room_id)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string EDIT_ROOM = $"UPDATE PERSON SET room_name='{room.room_name}', " +
                    $"WHERE room_id={room_id}";

                SqlCommand command = new SqlCommand(EDIT_ROOM, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }

        public static bool DeleteRoom(Room room)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string DELETE_ROOM = $"DELETE FROM ROOM" +
<<<<<<< HEAD
                    $" WHERE room_id ={room.room_id}";
=======
                    $"WHERE room_id={room.room_id}";
>>>>>>> 926d6b67812bb128536bc42fe89d022c4ae005e6

                SqlCommand command = new SqlCommand(DELETE_ROOM, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }
    }
}

