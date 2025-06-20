using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace UnicomTicManageSystemApp
{
    public partial class SectionManageForm : Form
    {
        private string connectionString = "Data Source=UNICOMticDB.db;Version=3;";
        private int selectedSectionId = -1;

        public SectionManageForm()
        {
            InitializeComponent();
            LoadSections();

            dgvSections.CellClick += dgvSections_CellClick;
            btnAddSection.Click += btnAddSection_Click;
            btnUpdateSection.Click += btnUpdateSection_Click;
            btnDeleteSection.Click += btnDeleteSection_Click;
            btnViewSections.Click += btnViewSections_Click;
        }

        private void LoadSections()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Sections";
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSections.DataSource = dt;
            }

            dgvSections.Columns["SectionId"].Visible = false; // hide ID
            dgvSections.Columns["SectionName"].HeaderText = "Section Name";
        }

        private void btnAddSection_Click(object sender, EventArgs e)
        {
            string sectionName = txtSectionName.Text.Trim();
            if (string.IsNullOrEmpty(sectionName))
            {
                MessageBox.Show("Please enter section name.");
                return;
            }

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Sections (SectionName) VALUES (@name)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", sectionName);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Section added successfully.");
            txtSectionName.Clear();
            LoadSections();
        }

        private void btnUpdateSection_Click(object sender, EventArgs e)
        {
            if (selectedSectionId == -1)
            {
                MessageBox.Show("Please select a section to update.");
                return;
            }

            string sectionName = txtSectionName.Text.Trim();
            if (string.IsNullOrEmpty(sectionName))
            {
                MessageBox.Show("Please enter section name.");
                return;
            }

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Sections SET SectionName=@name WHERE SectionId=@id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", sectionName);
                    cmd.Parameters.AddWithValue("@id", selectedSectionId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Section updated successfully.");
            txtSectionName.Clear();
            selectedSectionId = -1;
            LoadSections();
        }

        private void btnDeleteSection_Click(object sender, EventArgs e)
        {
            if (selectedSectionId == -1)
            {
                MessageBox.Show("Please select a section to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Sections WHERE SectionId=@id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedSectionId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Section deleted successfully.");
                txtSectionName.Clear();
                selectedSectionId = -1;
                LoadSections();
            }
        }

        private void btnViewSections_Click(object sender, EventArgs e)
        {
            LoadSections();
        }

        private void dgvSections_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedSectionId = Convert.ToInt32(dgvSections.Rows[e.RowIndex].Cells["SectionId"].Value);
                txtSectionName.Text = dgvSections.Rows[e.RowIndex].Cells["SectionName"].Value.ToString();
            }
        }
    }
}
