using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Data;

namespace UnicomTicManageSystemApp.Controllers
{
    public class UserController
    {
        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Users", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        UserId = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        UserPassword = reader.GetString(2),
                        Role = reader.GetString(3)
                    });
                }
            }

            return users;
        }

        public void AddUser(User user)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Users (Username, UserPassword, Role) VALUES (@Username, @Password, @Role)", conn);
                cmd.Parameters.AddWithValue("@Username", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.UserPassword);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateUser(User user)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Users SET Username = @Username, UserPassword = @Password, Role = @Role WHERE UserId = @UserId", conn);
                cmd.Parameters.AddWithValue("@Username", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.UserPassword);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUser(int userId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Users WHERE UserId = @UserId", conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.ExecuteNonQuery();
            }
        }

        public User GetUserById(int userId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Users WHERE UserId = @UserId", conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new User
                    {
                        UserId = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        UserPassword = reader.GetString(2),
                        Role = reader.GetString(3)
                    };
                }
            }

            return null;
        }
    }
}
