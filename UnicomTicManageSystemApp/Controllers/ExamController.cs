using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Data;
using UnicomTicManageSystemApp.Models;

namespace UnicomTicManageSystemApp.Controllers
{
    public class ExamController
    {
        public List<Exam> GetAllExams()
        {
            var exams = new List<Exam>();

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Exams", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    exams.Add(new Exam
                    {
                        ExamId = reader.GetInt32(0),
                        ExamName = reader.GetString(1),
                        ExamDate = DateTime.Parse(reader.GetString(2)),
                        SubjectId = reader.GetInt32(3)
                    });
                }
            }

            return exams;
        }

        public void AddExam(Exam exam)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Exams (ExamName, ExamDate, SubjectId) VALUES (@ExamName, @ExamDate, @SubjectId)", conn);
                cmd.Parameters.AddWithValue("@ExamName", exam.ExamName);
                cmd.Parameters.AddWithValue("@ExamDate", exam.ExamDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@SubjectId", exam.SubjectId);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateExam(Exam exam)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Exams SET ExamName = @ExamName, ExamDate = @ExamDate, SubjectId = @SubjectId WHERE ExamId = @ExamId", conn);
                cmd.Parameters.AddWithValue("@ExamName", exam.ExamName);
                cmd.Parameters.AddWithValue("@ExamDate", exam.ExamDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@SubjectId", exam.SubjectId);
                cmd.Parameters.AddWithValue("@ExamId", exam.ExamId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteExam(int examId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Exams WHERE ExamId = @ExamId", conn);
                cmd.Parameters.AddWithValue("@ExamId", examId);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetExamsBySectionId(int sectionId)
        {
            var dt = new DataTable();
            using (var conn = DbCon.GetConnection())
            {
                
                var query = @"SELECT e.ExamId, e.ExamName, e.ExamDate, s.SubjectName
                      FROM Exams e
                      JOIN Subjects s ON e.SubjectId = s.SubjectId
                      WHERE s.SectionId = @SectionId";
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@SectionId", sectionId);
                var adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }


        public Exam GetExamById(int examId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT * FROM Exams WHERE ExamId = @ExamId", conn);
                cmd.Parameters.AddWithValue("@ExamId", examId);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Exam
                    {
                        ExamId = reader.GetInt32(0),
                        ExamName = reader.GetString(1),
                        ExamDate = DateTime.Parse(reader.GetString(2)),
                        SubjectId = reader.GetInt32(3)
                    };
                }
            }

            return null;
        }
    }
}
