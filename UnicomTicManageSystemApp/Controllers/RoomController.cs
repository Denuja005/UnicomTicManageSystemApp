using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Data;

namespace UnicomTicManageSystemApp.Controllers
{
    public class RoomController
    {
        // எல்லா Rooms-ஐ Get செய்யும்
        public List<Room> GetAllRooms()
        {
            var rooms = new List<Room>();

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT RoomId, RoomName, RoomType FROM Rooms", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    rooms.Add(new Room
                    {
                        RoomId = reader.GetInt32(0),
                        RoomName = reader.GetString(1),
                        RoomType = reader.GetString(2)
                    });
                }
            }

            return rooms;
        }

        // Room-ஐ Add செய்யும்
        public void AddRoom(Room room)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Rooms (RoomName, RoomType) VALUES (@RoomName, @RoomType)", conn);
                cmd.Parameters.AddWithValue("@RoomName", room.RoomName);
                cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                cmd.ExecuteNonQuery();
            }
        }

        // Room-ஐ Update செய்யும்
        public void UpdateRoom(Room room)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Rooms SET RoomName = @RoomName, RoomType = @RoomType WHERE RoomId = @RoomId", conn);
                cmd.Parameters.AddWithValue("@RoomName", room.RoomName);
                cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                cmd.Parameters.AddWithValue("@RoomId", room.RoomId);
                cmd.ExecuteNonQuery();
            }
        }
        public Room GetRoomById(int id)
        {
            using (var conn = DbCon.GetConnection())
            {
                
                var cmd = new SQLiteCommand("SELECT RoomId, RoomName, RoomType FROM Rooms WHERE RoomId = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Room
                        {
                            RoomId = Convert.ToInt32(reader["RoomId"]),
                            RoomName = reader["RoomName"].ToString(),
                            RoomType = reader["RoomType"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        // Room-ஐ Delete செய்யும்
        public void DeleteRoom(int roomId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Rooms WHERE RoomId = @RoomId", conn);
                cmd.Parameters.AddWithValue("@RoomId", roomId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
