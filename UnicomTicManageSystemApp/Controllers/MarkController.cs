using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Data;
using UnicomTicManageSystemApp.Models;

namespace UnicomTicManageSystemApp.Controllers
{
    public class MarksController
    {
        // Marks-ஐ எல்லாம் பெற (basic)
        public List<Mark> GetAllMarks()
        {
            var marks = new List<Mark>();

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT MarkId, StudentId, SubjectId, ExamId, Score, StaffId FROM Marks", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    marks.Add(new Mark
                    {
                        MarkId = reader.GetInt32(0),
                        StudentId = reader.GetInt32(1),
                        SubjectId = reader.GetInt32(2),
                        ExamId = reader.GetInt32(3),
                        Score = reader.GetInt32(4),
                        StaffId = reader.GetInt32(5)
                    });
                }
            }

            return marks;
        }

        // புதிய Mark சேர்க்க
        public void AddMark(Mark mark)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand(@"INSERT INTO Marks (StudentId, SubjectId, ExamId, Score, StaffId) 
                                             VALUES (@StudentId, @SubjectId, @ExamId, @Score, @StaffId)", conn);
                cmd.Parameters.AddWithValue("@StudentId", mark.StudentId);
                cmd.Parameters.AddWithValue("@SubjectId", mark.SubjectId);
                cmd.Parameters.AddWithValue("@ExamId", mark.ExamId);
                cmd.Parameters.AddWithValue("@Score", mark.Score);
                cmd.Parameters.AddWithValue("@StaffId", mark.StaffId);
                cmd.ExecuteNonQuery();
            }
        }

        // Mark update செய்ய
        public void UpdateMark(Mark mark)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand(@"UPDATE Marks SET StudentId = @StudentId, SubjectId = @SubjectId, 
                                             ExamId = @ExamId, Score = @Score, StaffId = @StaffId 
                                             WHERE MarkId = @MarkId", conn);
                cmd.Parameters.AddWithValue("@StudentId", mark.StudentId);
                cmd.Parameters.AddWithValue("@SubjectId", mark.SubjectId);
                cmd.Parameters.AddWithValue("@ExamId", mark.ExamId);
                cmd.Parameters.AddWithValue("@Score", mark.Score);
                cmd.Parameters.AddWithValue("@StaffId", mark.StaffId);
                cmd.Parameters.AddWithValue("@MarkId", mark.MarkId);
                cmd.ExecuteNonQuery();
            }
        }

        // Mark நீக்க
        public void DeleteMark(int markId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Marks WHERE MarkId = @MarkId", conn);
                cmd.Parameters.AddWithValue("@MarkId", markId);
                cmd.ExecuteNonQuery();
            }
        }

        // MarkId மூலம் ஒரே ஒரு Mark detail க்காக
        public Mark GetMarkById(int markId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT MarkId, StudentId, SubjectId, ExamId, Score, StaffId FROM Marks WHERE MarkId = @MarkId", conn);
                cmd.Parameters.AddWithValue("@MarkId", markId);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Mark
                    {
                        MarkId = reader.GetInt32(0),
                        StudentId = reader.GetInt32(1),
                        SubjectId = reader.GetInt32(2),
                        ExamId = reader.GetInt32(3),
                        Score = reader.GetInt32(4),
                        StaffId = reader.GetInt32(5)
                    };
                }
            }
            return null;
        }
        public DataTable GetMarksByStudentId(int studentId)
        {
            var dt = new DataTable();
            using (var conn = DbCon.GetConnection())
            {
                var query = @"SELECT 
                        m.MarkId,
                        s.SubjectName,
                        e.ExamName,
                        m.Score
                      FROM Marks m
                      JOIN Subjects s ON m.SubjectId = s.SubjectId
                      JOIN Exams e ON m.ExamId = e.ExamId
                      WHERE m.StudentId = @StudentId";

                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", studentId);

                var adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }


        public List<dynamic> GetAllMarksWithDetails()
        {
            var list = new List<dynamic>();

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand(@"
            SELECT m.MarkId, m.StudentId, s.Name AS StudentName, m.SubjectId, sub.SubjectName,
                   m.ExamId, e.ExamName, m.Score, m.StaffId
            FROM Marks m
            INNER JOIN Students s ON m.StudentId = s.StudentId
            INNER JOIN Subjects sub ON m.SubjectId = sub.SubjectId
            INNER JOIN Exams e ON m.ExamId = e.ExamId
        ", conn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new
                    {
                        MarkId = reader.GetInt32(0),
                        StudentId = reader.GetInt32(1),
                        StudentName = reader.GetString(2),
                        SubjectId = reader.GetInt32(3),
                        SubjectName = reader.GetString(4),
                        ExamId = reader.GetInt32(5),
                        ExamName = reader.GetString(6),
                        Score = reader.GetInt32(7),
                        StaffId = reader.GetInt32(8)
                    });
                }
            }
            return list;
        }

    }
}

