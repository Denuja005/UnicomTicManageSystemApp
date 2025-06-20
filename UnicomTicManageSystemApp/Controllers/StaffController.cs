using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Data;

namespace UnicomTicManageSystemApp.Controllers
{
    public class StaffController
    {
        public List<Staff> GetAllStaffs()
        {
            var staffs = new List<Staff>();

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT StaffId, Name, Email, Phone FROM Staffs", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    staffs.Add(new Staff
                    {
                        StaffId = reader.GetInt32(0),
                        StaffName = reader.GetString(1),
                        StaffEmail = reader.GetString(2),  // expecting NOT NULL
                        StaffPhone = reader.GetString(3)   // expecting NOT NULL
                    });
                }
            }

            return staffs;
        }

        public void AddStaff(Staff staff)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Staffs (Name, Email, Phone) VALUES (@Name, @Email, @Phone)", conn);
                cmd.Parameters.AddWithValue("@Name", staff.StaffName);
                cmd.Parameters.AddWithValue("@Email", staff.StaffEmail);
                cmd.Parameters.AddWithValue("@Phone", staff.StaffPhone);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStaff(Staff staff)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Staffs SET Name = @Name, Email = @Email, Phone = @Phone WHERE StaffId = @StaffId", conn);
                cmd.Parameters.AddWithValue("@Name", staff.StaffName);
                cmd.Parameters.AddWithValue("@Email", staff.StaffEmail);
                cmd.Parameters.AddWithValue("@Phone", staff.StaffPhone);
                cmd.Parameters.AddWithValue("@StaffId", staff.StaffId);
                cmd.ExecuteNonQuery();
            }
        }
        public int GetStaffIdByUsername(string username)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
            SELECT StaffId FROM Users WHERE Username = @Username AND Role = 'Staff'
        ", conn);
                cmd.Parameters.AddWithValue("@Username", username);
                var result = cmd.ExecuteScalar();

                if (result == DBNull.Value || result == null)
                    return -1;

                return Convert.ToInt32(result);
            }
        }



        public void DeleteStaff(int staffId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Staffs WHERE StaffId = @StaffId", conn);
                cmd.Parameters.AddWithValue("@StaffId", staffId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
