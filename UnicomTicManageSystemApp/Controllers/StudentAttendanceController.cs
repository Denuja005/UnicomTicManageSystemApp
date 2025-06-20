using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Data;

namespace UnicomTicManageSystemApp.Controllers
{
    public class StudentAttendanceController
    {
        public List<StudentAttendance> GetAllAttendances()
        {
            var attendances = new List<StudentAttendance>();

            using (var conn = DbCon.GetConnection())
            {


                var cmd = new SQLiteCommand("SELECT * FROM StudentAttendance", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    attendances.Add(new StudentAttendance
                    {
                        AttendanceId = reader.GetInt32(reader.GetOrdinal("AttendanceId")),
                        StudentId = reader.GetInt32(reader.GetOrdinal("StudentId")),
                        AttendanceDate = DateTime.Parse(reader.GetString(reader.GetOrdinal("AttendanceDate"))),
                        Status = reader.GetString(reader.GetOrdinal("Status"))
                    });
                }
            }

            return attendances;
        }

        public StudentAttendance GetAttendanceById(int attendanceId)
        {
            using (var conn = DbCon.GetConnection())
            {


                var cmd = new SQLiteCommand("SELECT * FROM StudentAttendance WHERE AttendanceId = @AttendanceId", conn);
                cmd.Parameters.AddWithValue("@AttendanceId", attendanceId);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new StudentAttendance
                    {
                        AttendanceId = reader.GetInt32(reader.GetOrdinal("AttendanceId")),
                        StudentId = reader.GetInt32(reader.GetOrdinal("StudentId")),
                        AttendanceDate = DateTime.Parse(reader.GetString(reader.GetOrdinal("AttendanceDate"))),
                        Status = reader.GetString(reader.GetOrdinal("Status"))
                    };
                }
            }

            return null;
        }

        public void AddAttendance(StudentAttendance attendance)
        {
            using (var conn = DbCon.GetConnection())
            {


                var cmd = new SQLiteCommand(@"
                    INSERT INTO StudentAttendance (StudentId, AttendanceDate, Status)
                    VALUES (@StudentId, @AttendanceDate, @Status)", conn);

                cmd.Parameters.AddWithValue("@StudentId", attendance.StudentId);
                cmd.Parameters.AddWithValue("@AttendanceDate", attendance.AttendanceDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Status", attendance.Status);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateAttendance(StudentAttendance attendance)
        {
            using (var conn = DbCon.GetConnection())
            {


                var cmd = new SQLiteCommand(@"
                    UPDATE StudentAttendance SET
                        StudentId = @StudentId,
                        AttendanceDate = @AttendanceDate,
                        Status = @Status
                    WHERE AttendanceId = @AttendanceId", conn);

                cmd.Parameters.AddWithValue("@StudentId", attendance.StudentId);
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


                var cmd = new SQLiteCommand("DELETE FROM StudentAttendance WHERE AttendanceId = @AttendanceId", conn);
                cmd.Parameters.AddWithValue("@AttendanceId", attendanceId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

