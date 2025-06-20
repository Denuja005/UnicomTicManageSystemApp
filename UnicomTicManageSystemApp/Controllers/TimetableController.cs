using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Data;
using UnicomTicManageSystemApp.Models;

namespace UnicomTicManageSystemApp.Controllers
{
    public class TimetableController
    {
        public List<Timetable> GetAllTimetables()
        {
            var timetables = new List<Timetable>();

            using (var conn = DbCon.GetConnection())
            {
               
                var cmd = new SQLiteCommand("SELECT * FROM Timetables", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    timetables.Add(new Timetable
                    {
                        TimetableId = reader.GetInt32(0),
                        SectionId = reader.GetInt32(1),
                        SubjectId = reader.GetInt32(2),
                        LectureId = reader.GetInt32(3),
                        RoomId = reader.GetInt32(4),
                        Day = reader.GetString(5),
                        TimeSlot = reader.GetString(6),
                        StaffId = reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                        Date = reader.IsDBNull(8) ? "" : reader.GetString(8)
                    });
                }
            }

            return timetables;
        }

        public Timetable GetTimetableById(int timetableId)
        {
            using (var conn = DbCon.GetConnection())
            {
               
                var cmd = new SQLiteCommand("SELECT * FROM Timetables WHERE TimetableId = @TimetableId", conn);
                cmd.Parameters.AddWithValue("@TimetableId", timetableId);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Timetable
                    {
                        TimetableId = reader.GetInt32(0),
                        SectionId = reader.GetInt32(1),
                        SubjectId = reader.GetInt32(2),
                        LectureId = reader.GetInt32(3),
                        RoomId = reader.GetInt32(4),
                        Day = reader.GetString(5),
                        TimeSlot = reader.GetString(6),
                        StaffId = reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                        Date = reader.IsDBNull(8) ? "" : reader.GetString(8)
                    };
                }
            }

            return null;
        }

        public DataTable GetTimetableBySectionId(int sectionId)
        {
            var dt = new DataTable();
            using (var conn = DbCon.GetConnection())
            {

                var query = @"SELECT t.TimetableId, s.SubjectName, r.RoomName, l.Name AS LectureName, t.Day, t.TimeSlot
                          FROM Timetables t
                          JOIN Subjects s ON t.SubjectId = s.SubjectId
                          JOIN Rooms r ON t.RoomId = r.RoomId
                          JOIN Lectures l ON t.LectureId = l.LectureId
                          WHERE t.SectionId = @SectionId";
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@SectionId", sectionId);
                var adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }


        public void AddTimetable(Timetable timetable)
        {
            using (var conn = DbCon.GetConnection())
            {
               
                var cmd = new SQLiteCommand(@"
                    INSERT INTO Timetables (SectionId, SubjectId, LectureId, RoomId, Day, TimeSlot, StaffId, Date)
                    VALUES (@SectionId, @SubjectId, @LectureId, @RoomId, @Day, @TimeSlot, @StaffId, @Date)", conn);

                cmd.Parameters.AddWithValue("@SectionId", timetable.SectionId);
                cmd.Parameters.AddWithValue("@SubjectId", timetable.SubjectId);
                cmd.Parameters.AddWithValue("@LectureId", timetable.LectureId);
                cmd.Parameters.AddWithValue("@RoomId", timetable.RoomId);
                cmd.Parameters.AddWithValue("@Day", timetable.Day);
                cmd.Parameters.AddWithValue("@TimeSlot", timetable.TimeSlot);
                cmd.Parameters.AddWithValue("@StaffId", timetable.StaffId);
                cmd.Parameters.AddWithValue("@Date", timetable.Date);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateTimetable(Timetable timetable)
        {
            using (var conn = DbCon.GetConnection())
            {
               
                var cmd = new SQLiteCommand(@"
                    UPDATE Timetables SET
                        SectionId = @SectionId,
                        SubjectId = @SubjectId,
                        LectureId = @LectureId,
                        RoomId = @RoomId,
                        Day = @Day,
                        TimeSlot = @TimeSlot,
                        StaffId = @StaffId,
                        Date = @Date
                    WHERE TimetableId = @TimetableId", conn);

                cmd.Parameters.AddWithValue("@SectionId", timetable.SectionId);
                cmd.Parameters.AddWithValue("@SubjectId", timetable.SubjectId);
                cmd.Parameters.AddWithValue("@LectureId", timetable.LectureId);
                cmd.Parameters.AddWithValue("@RoomId", timetable.RoomId);
                cmd.Parameters.AddWithValue("@Day", timetable.Day);
                cmd.Parameters.AddWithValue("@TimeSlot", timetable.TimeSlot);
                cmd.Parameters.AddWithValue("@StaffId", timetable.StaffId);
                cmd.Parameters.AddWithValue("@Date", timetable.Date);
                cmd.Parameters.AddWithValue("@TimetableId", timetable.TimetableId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTimetable(int timetableId)
        {
            using (var conn = DbCon.GetConnection())
            {
              
                var cmd = new SQLiteCommand("DELETE FROM Timetables WHERE TimetableId = @TimetableId", conn);
                cmd.Parameters.AddWithValue("@TimetableId", timetableId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
