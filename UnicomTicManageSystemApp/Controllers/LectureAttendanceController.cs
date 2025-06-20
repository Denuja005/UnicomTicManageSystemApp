using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Data;

namespace UnicomTicManageSystemApp.Controllers
{
    public class LectureAttendanceController
    {
        public List<LectureAttendance> GetAllAttendances()
        {
            var attendances = new List<LectureAttendance>();

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM LectureAttendance", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    attendances.Add(new LectureAttendance
                    {
                        AttendanceId = reader.GetInt32(0),
                        LectureId = reader.GetInt32(1),
                        AttendanceDate = DateTime.Parse(reader.GetString(2)),
                        Status = reader.GetString(3)
                    });
                }
            }

            return attendances;
        }

        public LectureAttendance GetAttendanceById(int attendanceId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM LectureAttendance WHERE AttendanceId = @AttendanceId", conn);
                cmd.Parameters.AddWithValue("@AttendanceId", attendanceId);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new LectureAttendance
                    {
                        AttendanceId = reader.GetInt32(0),
                        LectureId = reader.GetInt32(1),
                        AttendanceDate = DateTime.Parse(reader.GetString(2)),
                        Status = reader.GetString(3)
                    };
                }
            }

            return null;
        }

        public void AddAttendance(LectureAttendance attendance)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
                    INSERT INTO LectureAttendance (LectureId, AttendanceDate, Status)
                    VALUES (@LectureId, @AttendanceDate, @Status)", conn);

                cmd.Parameters.AddWithValue("@LectureId", attendance.LectureId);
                cmd.Parameters.AddWithValue("@AttendanceDate", attendance.AttendanceDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Status", attendance.Status);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateAttendance(LectureAttendance attendance)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
                    UPDATE LectureAttendance SET
                        LectureId = @LectureId,
                        AttendanceDate = @AttendanceDate,
                        Status = @Status
                    WHERE AttendanceId = @AttendanceId", conn);

                cmd.Parameters.AddWithValue("@LectureId", attendance.LectureId);
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
                var cmd = new SQLiteCommand("DELETE FROM LectureAttendance WHERE AttendanceId = @AttendanceId", conn);
                cmd.Parameters.AddWithValue("@AttendanceId", attendanceId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
