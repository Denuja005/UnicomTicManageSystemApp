using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Data;
using UnicomTicManageSystemApp.Models;

namespace UnicomTicManageSystemApp.Controllers
{
    public class SectionController
    {
        public List<Section> GetAllSections()
        {
            var sections = new List<Section>();

            using (var conn = DbCon.GetConnection())
            {
                
                string query = "SELECT SectionId, SectionName FROM Sections";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sections.Add(new Section
                            {
                                SectionId = Convert.ToInt32(reader["SectionId"]),
                                SectionName = reader["SectionName"].ToString()
                            });
                        }
                    }
                }
            }

            return sections;
        }

        public string GetSectionNameById(int sectionId)
        {
            using (var conn = DbCon.GetConnection())
            {
                
                var cmd = new SQLiteCommand("SELECT SectionName FROM Sections WHERE SectionId = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", sectionId);
                var result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "";
            }
        }

        public string GetSectionNameById(int? id)
        {
            if (id == null)
            {
                return "No Section";
            }

            using (var conn = DbCon.GetConnection())
            {
               
                var cmd = new SQLiteCommand("SELECT SectionName FROM Sections WHERE SectionId = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id.Value);
                var result = cmd.ExecuteScalar();
                if (result != null)
                    return result.ToString();
            }

            return "Unknown Section";  // fallback return value
        }

    }
}
