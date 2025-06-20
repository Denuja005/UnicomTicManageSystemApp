using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Data;
using UnicomTicManageSystemApp.Models;

namespace UnicomTicManageSystemApp.Controllers
{
    public class StudentController
    {
        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            using (var conn = DbCon.GetConnection())
            {
             

                // Schema column names: Name, Email, City
                string query = "SELECT StudentId, Name, Email, City, SectionId FROM Students";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                StudentId = Convert.ToInt32(reader["StudentId"]),
                                Name = reader["Name"].ToString(),        // "Name"
                                Email = reader["Email"].ToString(),      // "Email"
                                City = reader["City"].ToString(),        // "City"
                                SectionId = reader["SectionId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SectionId"])
                            });
                        }
                    }
                }
            }

            return students;
        }

        public void AddStudent(Student student)
        {
            using (var conn = DbCon.GetConnection())
            {
                
                var cmd = new SQLiteCommand(
                    "INSERT INTO Students (Name, Email, City, SectionId) VALUES (@Name, @Email, @City, @SectionId)",
                    conn);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@City", student.City);
                cmd.Parameters.AddWithValue("@SectionId", student.SectionId);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var conn = DbCon.GetConnection())
            {
               
                var cmd = new SQLiteCommand(
                    "UPDATE Students SET Name = @Name, Email = @Email, City = @City, SectionId = @SectionId WHERE StudentId = @Id",
                    conn);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@City", student.City);
                cmd.Parameters.AddWithValue("@SectionId", student.SectionId);
                cmd.Parameters.AddWithValue("@Id", student.StudentId);
                cmd.ExecuteNonQuery();
            }
        }

        public int GetStudentIdByUsername(string username)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT StudentId FROM Users WHERE Username = @username", conn);
                cmd.Parameters.AddWithValue("@username", username);
                var result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int studentId))
                    return studentId;
                return -1;
            }
        }

        public Student GetStudentById(int studentId)
        {
            using (var conn = DbCon.GetConnection())
            {
               
                var cmd = new SQLiteCommand("SELECT * FROM Students WHERE StudentId = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", studentId);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Student
                    {
                        StudentId = Convert.ToInt32(reader["StudentId"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        City = reader["City"].ToString(),
                        SectionId = Convert.ToInt32(reader["SectionId"])
                    };
                }
            }
            return null;
        }


        public void DeleteStudent(int studentId)
        {
            using (var conn = DbCon.GetConnection())
            {
               
                var cmd = new SQLiteCommand("DELETE FROM Students WHERE StudentId = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", studentId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
