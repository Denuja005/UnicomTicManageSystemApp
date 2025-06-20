using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Data;

namespace UnicomTicManageSystemApp.Controllers
{
    public class LectureController
    {
        public List<Lecture> GetAllLectures()
        {
            var lectures = new List<Lecture>();

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT LectureId, Name, Email, Phone, City FROM Lectures", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lectures.Add(new Lecture
                    {
                        LectureId = reader.GetInt32(0),
                        LecturName = reader.GetString(1),
                        LecturEmail = reader.GetString(2),
                        LecturPhone = reader.GetString(3),
                        LecturCity = reader.GetString(4)
                    });
                }
            }

            return lectures;
        }

        public void AddLecture(Lecture lecture)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Lectures (Name, Email, Phone, City) VALUES (@Name, @Email, @Phone, @City)", conn);
                cmd.Parameters.AddWithValue("@Name", lecture.LecturName);
                cmd.Parameters.AddWithValue("@Email", lecture.LecturEmail);
                cmd.Parameters.AddWithValue("@Phone", lecture.LecturPhone);
                cmd.Parameters.AddWithValue("@City", lecture.LecturCity);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateLecture(Lecture lecture)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Lectures SET Name = @Name, Email = @Email, Phone = @Phone, City = @City WHERE LectureId = @LectureId", conn);
                cmd.Parameters.AddWithValue("@Name", lecture.LecturName);
                cmd.Parameters.AddWithValue("@Email", lecture.LecturEmail);
                cmd.Parameters.AddWithValue("@Phone", lecture.LecturPhone);
                cmd.Parameters.AddWithValue("@City", lecture.LecturCity);
                cmd.Parameters.AddWithValue("@LectureId", lecture.LectureId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteLecture(int lectureId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Lectures WHERE LectureId = @LectureId", conn);
                cmd.Parameters.AddWithValue("@LectureId", lectureId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
