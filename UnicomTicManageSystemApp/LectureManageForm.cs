using System;
using System.Collections.Generic;
using System.Data.SQLite; // Install System.Data.SQLite from NuGet
using System.Windows.Forms;
using UnicomTicManageSystemApp.Models;

namespace UnicomTicManageSystemApp
{
    public partial class LectureManageForm : Form
    {
        private int selectedLectureId = -1;
        private string connectionString = "Data Source=UNICOMticDB.db;Version=3;"; // Database path

        public LectureManageForm()
        {
            InitializeComponent();

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnView.Click += btnView_Click;
            dgvLectures.CellClick += dgvLectures_CellClick;

            LoadSections();
            LoadLectures();
        }

        private void LoadSections()
        {
            List<Section> sections = new List<Section>();

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string query = "SELECT SectionId, SectionName FROM Sections";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
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

            cmbSection.DisplayMember = "SectionName";
            cmbSection.ValueMember = "SectionId";
            cmbSection.DataSource = sections;
            cmbSection.SelectedIndex = -1;
        }

        private void LoadLectures()
        {
            List<Lecture> lectures = new List<Lecture>();

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string query = "SELECT LectureId, Name, Email, Phone, City, SectionId FROM Lectures";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lectures.Add(new Lecture
                            {
                                LectureId = Convert.ToInt32(reader["LectureId"]),
                                LecturName = reader["Name"].ToString(),
                                LecturEmail = reader["Email"].ToString(),
                                LecturPhone = reader["Phone"].ToString(),
                                LecturCity = reader["City"].ToString(),
                                SectionId = Convert.ToInt32(reader["SectionId"])
                            });
                        }
                    }
                }
            }

            dgvLectures.DataSource = lectures;
            dgvLectures.Columns["LectureId"].Visible = false; // Hide ID column
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || cmbSection.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter name and select section.");
                return;
            }

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Lectures (Name, Email, Phone, City, SectionId) VALUES (@name, @email, @phone, @city, @sectionId)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@city", txtCity.Text);
                    cmd.Parameters.AddWithValue("@sectionId", (int)cmbSection.SelectedValue);

                    cmd.ExecuteNonQuery();
                }
            }

            LoadLectures();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedLectureId == -1)
            {
                MessageBox.Show("Select a lecture to update.");
                return;
            }

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Lectures SET Name=@name, Email=@email, Phone=@phone, City=@city, SectionId=@sectionId WHERE LectureId=@id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@city", txtCity.Text);
                    cmd.Parameters.AddWithValue("@sectionId", (int)cmbSection.SelectedValue);
                    cmd.Parameters.AddWithValue("@id", selectedLectureId);

                    cmd.ExecuteNonQuery();
                }
            }

            LoadLectures();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedLectureId == -1)
            {
                MessageBox.Show("Select a lecture to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure want to delete?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Lectures WHERE LectureId=@id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedLectureId);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadLectures();
                ClearFields();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadLectures();
        }

        private void dgvLectures_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var lecture = dgvLectures.Rows[e.RowIndex].DataBoundItem as Lecture;
            if (lecture != null)
            {
                selectedLectureId = lecture.LectureId;
                txtName.Text = lecture.LecturName;
                txtEmail.Text = lecture.LecturEmail;
                txtPhone.Text = lecture.LecturPhone;
                txtCity.Text = lecture.LecturCity;
                cmbSection.SelectedValue = lecture.SectionId;
            }
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtCity.Clear();
            cmbSection.SelectedIndex = -1;
            selectedLectureId = -1;
        }
    }
}
