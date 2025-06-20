using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Data;

namespace UnicomTicManageSystemApp.Controllers
{
    public class SubjectLectureController
    {
        // Get all SubjectLecture mappings
        public List<SubjectLecture> GetAll()
        {
            var list = new List<SubjectLecture>();

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT SubjectId, LectureId FROM Subject_Lecture", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new SubjectLecture
                    {
                        SubjectId = reader.GetInt32(0),
                        LectureId = reader.GetInt32(1)
                    });
                }
            }

            return list;
        }

        // Add a new mapping
        public void Add(SubjectLecture sl)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand(
                    "INSERT INTO Subject_Lecture (SubjectId, LectureId) VALUES (@SubjectId, @LectureId)", conn);
                cmd.Parameters.AddWithValue("@SubjectId", sl.SubjectId);
                cmd.Parameters.AddWithValue("@LectureId", sl.LectureId);
                cmd.ExecuteNonQuery();
            }
        }

        // Delete a mapping by composite key
        public void Delete(int subjectId, int lectureId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand(
                    "DELETE FROM Subject_Lecture WHERE SubjectId = @SubjectId AND LectureId = @LectureId", conn);
                cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                cmd.Parameters.AddWithValue("@LectureId", lectureId);
                cmd.ExecuteNonQuery();
            }
        }

        // Check if mapping exists
        public bool Exists(int subjectId, int lectureId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM Subject_Lecture WHERE SubjectId = @SubjectId AND LectureId = @LectureId", conn);
                cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                cmd.Parameters.AddWithValue("@LectureId", lectureId);

                long count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
