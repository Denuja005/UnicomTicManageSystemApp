using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Data;

namespace UnicomTicManageSystemApp.Controllers
{
    public class LectureSectionController
    {
        // Get all LectureSection records
        public List<LectureSection> GetAll()
        {
            var list = new List<LectureSection>();

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT LectureId, SectionId FROM Lecture_Section", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new LectureSection
                    {
                        LectureId = reader.GetInt32(0),
                        SectionId = reader.GetInt32(1)
                    });
                }
            }

            return list;
        }

        // Add a new LectureSection mapping
        public void Add(LectureSection ls)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand(
                    "INSERT INTO Lecture_Section (LectureId, SectionId) VALUES (@LectureId, @SectionId)", conn);
                cmd.Parameters.AddWithValue("@LectureId", ls.LectureId);
                cmd.Parameters.AddWithValue("@SectionId", ls.SectionId);
                cmd.ExecuteNonQuery();
            }
        }

        // Delete a LectureSection mapping by composite key
        public void Delete(int lectureId, int sectionId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand(
                    "DELETE FROM Lecture_Section WHERE LectureId = @LectureId AND SectionId = @SectionId", conn);
                cmd.Parameters.AddWithValue("@LectureId", lectureId);
                cmd.Parameters.AddWithValue("@SectionId", sectionId);
                cmd.ExecuteNonQuery();
            }
        }

        // Check if a LectureSection mapping exists
        public bool Exists(int lectureId, int sectionId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand(
                    "SELECT COUNT(*) FROM Lecture_Section WHERE LectureId = @LectureId AND SectionId = @SectionId", conn);
                cmd.Parameters.AddWithValue("@LectureId", lectureId);
                cmd.Parameters.AddWithValue("@SectionId", sectionId);

                long count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
