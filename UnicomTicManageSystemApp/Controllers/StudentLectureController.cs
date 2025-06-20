using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Data;

namespace UnicomTicManageSystemApp.Controllers
{
    public class StudentLectureController
    {
        // எல்லா StudentLecture ரெக்கார்ட்களையும் பெறும்
        public List<StudentLecture> GetAll()
        {
            var list = new List<StudentLecture>();

            using (var conn = DbCon.GetConnection())
            {
                conn.Open();  // Open connection (important)

                var cmd = new SQLiteCommand("SELECT StudentId, LectureId FROM Student_Lecture", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new StudentLecture
                    {
                        StudentId = reader.GetInt32(0),
                        LectureId = reader.GetInt32(1)
                    });
                }
            }

            return list;
        }

        // புதிய StudentLecture சேர்க்கும்
        public void Add(StudentLecture studentLecture)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand("INSERT INTO Student_Lecture (StudentId, LectureId) VALUES (@StudentId, @LectureId)", conn);
                cmd.Parameters.AddWithValue("@StudentId", studentLecture.StudentId);
                cmd.Parameters.AddWithValue("@LectureId", studentLecture.LectureId);
                cmd.ExecuteNonQuery();
            }
        }

        // StudentLecture ஏற்கனவே உள்ளதா என சரிபார்க்கும்
        public bool Exists(int studentId, int lectureId)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand("SELECT COUNT(1) FROM Student_Lecture WHERE StudentId = @StudentId AND LectureId = @LectureId", conn);
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                cmd.Parameters.AddWithValue("@LectureId", lectureId);
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // StudentLecture நீக்கும்
        public void Delete(int studentId, int lectureId)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand("DELETE FROM Student_Lecture WHERE StudentId = @StudentId AND LectureId = @LectureId", conn);
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                cmd.Parameters.AddWithValue("@LectureId", lectureId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
