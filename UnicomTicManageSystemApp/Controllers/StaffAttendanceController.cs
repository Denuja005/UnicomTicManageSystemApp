using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Data;

namespace UnicomTicManageSystemApp.Controllers
{
    public class StaffAttendanceController
    {
        public List<StaffAttendance> GetAllAttendances()
        {
            var attendances = new List<StaffAttendance>();

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM StaffAttendance", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    attendances.Add(new StaffAttendance
                    {
                        AttendanceId = reader.GetInt32(0),
                        StaffId = reader.GetInt32(1),
                        AttendanceDate = DateTime.Parse(reader.GetString(2)),
                        Status = reader.GetString(3)
                    });
                }
            }

            return attendances;
        }

        public StaffAttendance GetAttendanceById(int attendanceId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM StaffAttendance WHERE AttendanceId = @AttendanceId", conn);
                cmd.Parameters.AddWithValue("@AttendanceId", attendanceId);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new StaffAttendance
                    {
                        AttendanceId = reader.GetInt32(0),
                        StaffId = reader.GetInt32(1),
                        AttendanceDate = DateTime.Parse(reader.GetString(2)),
                        Status = reader.GetString(3)
                    };
                }
            }

            return null;
        }

        public void AddAttendance(StaffAttendance attendance)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
                    INSERT INTO StaffAttendance (StaffId, AttendanceDate, Status)
                    VALUES (@StaffId, @AttendanceDate, @Status)", conn);

                cmd.Parameters.AddWithValue("@StaffId", attendance.StaffId);
                cmd.Parameters.AddWithValue("@AttendanceDate", attendance.AttendanceDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Status", attendance.Status);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateAttendance(StaffAttendance attendance)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
                    UPDATE StaffAttendance SET
                        StaffId = @StaffId,
                        AttendanceDate = @AttendanceDate,
                        Status = @Status
                    WHERE AttendanceId = @AttendanceId", conn);

                cmd.Parameters.AddWithValue("@StaffId", attendance.StaffId);
                cmd.Parameters.AddWithValue("@AttendanceDate", attendance.AttendanceDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Status", attendance.Status);
                cmd.Parameters.AddWithValue("@AttendanceId", attendance.AttendanceId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAttendance(int attendanceId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM StaffAttendance WHERE AttendanceId = @AttendanceId", conn);
                cmd.Parameters.AddWithValue("@AttendanceId", attendanceId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
