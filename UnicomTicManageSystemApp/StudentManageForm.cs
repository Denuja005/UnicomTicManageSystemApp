using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Controllers;

namespace UnicomTicManageSystemApp
{
    public partial class StudentManageForm : Form
    {
        private SectionController sectionController = new SectionController();
        private StudentController studentController = new StudentController();
        private int selectedStudentId = -1;

        public StudentManageForm()
        {
            InitializeComponent();
            dgvStudents.CellClick += dgvStudents_CellClick;  // Make sure event is hooked up
            this.Load += StudentManageForm_Load;
        }

        private void StudentManageForm_Load(object sender, EventArgs e)
        {
            LoadSectionsToComboBox();
            LoadStudentsToGrid();
        }

        private void LoadSectionsToComboBox()
        {
            List<Section> sections = sectionController.GetAllSections();
            cmbStream.DataSource = sections;
            cmbStream.DisplayMember = "SectionName";
            cmbStream.ValueMember = "SectionId";
            cmbStream.SelectedIndex = -1;
        }

        private void LoadStudentsToGrid()
        {
            var students = studentController.GetAllStudents();
            var table = new System.Data.DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("Email");
            table.Columns.Add("City");
            table.Columns.Add("Section");

            foreach (var student in students)
            {
                string sectionName = sectionController.GetSectionNameById(student.SectionId);
                table.Rows.Add(student.StudentId, student.Name, student.Email, student.City, sectionName);
            }

            dgvStudents.DataSource = table;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cmbStream.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            var selectedSection = (Section)cmbStream.SelectedItem;

            Student student = new Student
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                City = txtAddress.Text,
                SectionId = selectedSection.SectionId
            };

            studentController.AddStudent(student);
            MessageBox.Show("Student added successfully!");
            LoadStudentsToGrid();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1)
            {
                MessageBox.Show("Select a student to update.");
                return;
            }

            var selectedSection = (Section)cmbStream.SelectedItem;

            Student student = new Student
            {
                StudentId = selectedStudentId,
                Name = txtName.Text,
                Email = txtEmail.Text,
                City = txtAddress.Text,
                SectionId = selectedSection.SectionId
            };

            studentController.UpdateStudent(student);
            MessageBox.Show("Student updated successfully!");
            LoadStudentsToGrid();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1)
            {
                MessageBox.Show("Select a student to delete.");
                return;
            }

            studentController.DeleteStudent(selectedStudentId);
            MessageBox.Show("Student deleted successfully!");
            LoadStudentsToGrid();
            ClearInputs();
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvStudents.Rows[e.RowIndex];
                selectedStudentId = Convert.ToInt32(row.Cells["ID"].Value);
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtAddress.Text = row.Cells["City"].Value.ToString();

                string sectionName = row.Cells["Section"].Value.ToString();
                for (int i = 0; i < cmbStream.Items.Count; i++)
                {
                    Section sec = (Section)cmbStream.Items[i];
                    if (sec.SectionName == sectionName)
                    {
                        cmbStream.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadStudentsToGrid();
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            cmbStream.SelectedIndex = -1;
            selectedStudentId = -1;
        }
    }
}
