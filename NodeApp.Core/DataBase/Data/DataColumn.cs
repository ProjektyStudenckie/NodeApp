﻿using System.Collections.Generic;
using System.Data.SqlClient;


namespace NodeApp
{
    public class DataColumn
    {

        private const string ALL_COLUMN = "SELECT * FROM COLUM";
        private const string ADD_COLUMN = "INSERT INTO COLUM VALUES ";




        public static List<Column> DownloadColumns()
        {
            List<Column> users = new List<Column>();
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand(ALL_COLUMN, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    users.Add(new Column(reader));
                connection.Close();
            }
            return users;
        }

        public static bool AddColumn(Column column)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                SqlCommand command = new SqlCommand($"{ADD_COLUMN} {column.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                succ = true;

                command = new SqlCommand($"SELECT MAX(column_id) ID FROM COLUM", connection);
                var reader = command.ExecuteReader();
                reader.Read();
                column.column_id = int.Parse(reader["ID"].ToString());
                connection.Close();
            }
            return succ;
        }

        public static bool EditColumn(Column column, int idColumn)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string EDIT_COLUMN = $"UPDATE COLUM SET column_name='{column.column_name}', room_id='{column.room_id}', column_order='{column.column_order}'" +
                    $"WHERE column_id={idColumn}";

                SqlCommand command = new SqlCommand(EDIT_COLUMN, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }
        public static bool DeleteColumn(Column column)
        {
            bool succ = false;
            using (var connection = DBconnect.Instance.Connection)
            {
                string DELETE_COLUMN = $"DELETE FROM COLUM" +
                    $" WHERE column_id={column.column_id}";


                SqlCommand command = new SqlCommand(DELETE_COLUMN, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) succ = true;

                connection.Close();
            }
            return succ;
        }

        public static List<Column> ReturnColumnsOfRoom(Room room)
        {
            List<Column> columns = new List<Column>();
            using (var connection = DBconnect.Instance.Connection)
            {

                string TASKS_OF_COLUMN = $"SELECT * FROM COLUM" +
                    $" WHERE room_id={room.room_id}";

                SqlCommand command = new SqlCommand(TASKS_OF_COLUMN, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    columns.Add(new Column(reader));
                connection.Close();
            }
            return columns;

        }
    }
}
