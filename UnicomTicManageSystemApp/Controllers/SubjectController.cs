using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Data;

namespace UnicomTicManageSystemApp.Controllers
{
    public class SubjectController
    {
        public List<Subject> GetAllSubjects()
        {
            var subjects = new List<Subject>();

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT SubjectId, SubjectName, SectionId FROM Subjects", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    subjects.Add(new Subject
                    {
                        SubjectId = reader.GetInt32(0),
                        SubjectName = reader.GetString(1),
                        SectionId = reader.GetInt32(2)
                    });
                }
            }

            return subjects;
        }

        // இதுதான் நீங்கள் கேட்ட 'GetBySectionId' மெத்தட்
        public List<Subject> GetBySectionId(int sectionId)
        {
            var subjects = new List<Subject>();

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT SubjectId, SubjectName, SectionId FROM Subjects WHERE SectionId = @SectionId", conn);
                cmd.Parameters.AddWithValue("@SectionId", sectionId);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    subjects.Add(new Subject
                    {
                        SubjectId = reader.GetInt32(0),
                        SubjectName = reader.GetString(1),
                        SectionId = reader.GetInt32(2)
                    });
                }
            }

            return subjects;
        }

        public void AddSubject(Subject subject)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("INSERT INTO Subjects (SubjectName, SectionId) VALUES (@SubjectName, @SectionId)", conn);
                cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                cmd.Parameters.AddWithValue("@SectionId", subject.SectionId);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateSubject(Subject subject)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("UPDATE Subjects SET SubjectName = @SubjectName, SectionId = @SectionId WHERE SubjectId = @SubjectId", conn);
                cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                cmd.Parameters.AddWithValue("@SectionId", subject.SectionId);
                cmd.Parameters.AddWithValue("@SubjectId", subject.SubjectId);
                cmd.ExecuteNonQuery();
            }
        }


        public List<Subject> GetSubjectsBySectionId(int sectionId)
        {
            var subjects = new List<Subject>();
            using (var conn = DbCon.GetConnection())
            {
                
                var cmd = new SQLiteCommand("SELECT * FROM Subjects WHERE SectionId = @SectionId", conn);
                cmd.Parameters.AddWithValue("@SectionId", sectionId);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    subjects.Add(new Subject
                    {
                        SubjectId = Convert.ToInt32(reader["SubjectId"]),
                        SubjectName = reader["SubjectName"].ToString(),
                        SectionId = Convert.ToInt32(reader["SectionId"])
                    });
                }
            }
            return subjects;
        }


        public void DeleteSubject(int subjectId)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("DELETE FROM Subjects WHERE SubjectId = @SubjectId", conn);
                cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
