using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Data;

namespace UnicomTicManageSystemApp.Controllers
{
    public class StudentSubjectController
    {
        // Get all StudentSubject records
        public List<StudentSubject> GetAll()
        {
            var list = new List<StudentSubject>();

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT StudentId, SubjectId FROM Student_Subject", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new StudentSubject
                    {
                        StudentId = reader.GetInt32(0),
                        SubjectId = reader.GetInt32(1)
                    });
                }
            }

            return list;
        }

        // Add a new StudentSubject record
        public void Add(StudentSubject studentSubject)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Student_Subject (StudentId, SubjectId) VALUES (@StudentId, @SubjectId)", conn);
                cmd.Parameters.AddWithValue("@StudentId", studentSubject.StudentId);
                cmd.Parameters.AddWithValue("@SubjectId", studentSubject.SubjectId);
                cmd.ExecuteNonQuery();
            }
        }

        // Check if a StudentSubject record exists
        public bool Exists(int studentId, int subjectId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT COUNT(1) FROM Student_Subject WHERE StudentId = @StudentId AND SubjectId = @SubjectId", conn);
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // Delete a StudentSubject record
        public void Delete(int studentId, int subjectId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Student_Subject WHERE StudentId = @StudentId AND SubjectId = @SubjectId", conn);
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
