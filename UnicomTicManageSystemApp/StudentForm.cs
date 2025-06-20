using System;
using System.Data;
using System.Windows.Forms;
using UnicomTicManageSystemApp.Controllers;
using UnicomTicManageSystemApp.Models;

namespace UnicomTicManageSystemApp
{
    public partial class StudentForm : Form
    {
        private readonly int studentId;
        private readonly StudentController studentController = new StudentController();
        private readonly SectionController sectionController = new SectionController();
        private readonly SubjectController subjectController = new SubjectController();
        private readonly ExamController examController = new ExamController();
        private readonly MarksController marksController = new MarksController();
        private readonly TimetableController timetableController = new TimetableController();

        public StudentForm(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;

            // Event handlers must be attached here or in designer
            cmbSection.SelectedIndexChanged += cmbSection_SelectedIndexChanged;
            btnExams.Click += btnViewExams_Click;
            btnMarks.Click += btnViewMarks_Click;
            btnTimetable.Click += btnViewTimetable_Click;

            LoadStudentInfo();
            LoadSections();
        }

        private void LoadStudentInfo()
        {
            var student = studentController.GetStudentById(studentId);
            if (student != null)
            {
                txtName.Text = student.Name;
                txtEmail.Text = student.Email;
                txtCity.Text = student.City;

                if (student.SectionId != null)
                {
                    cmbSection.SelectedValue = student.SectionId.Value;
                    LoadSubjects(student.SectionId.Value);
                }
            }
            else
            {
                MessageBox.Show("Student info not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSections()
        {
            var sections = sectionController.GetAllSections();
            cmbSection.DataSource = sections;
            cmbSection.DisplayMember = "SectionName";
            cmbSection.ValueMember = "SectionId";
        }

        private void LoadSubjects(int sectionId)
        {
            lstSubjects.Items.Clear();
            var subjects = subjectController.GetSubjectsBySectionId(sectionId);
            foreach (var subject in subjects)
            {
                lstSubjects.Items.Add(subject.SubjectName);
            }
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSection.SelectedValue != null && int.TryParse(cmbSection.SelectedValue.ToString(), out int selectedSectionId))
            {
                LoadSubjects(selectedSectionId);
            }
        }

        private void btnViewExams_Click(object sender, EventArgs e)
        {
            if (cmbSection.SelectedValue != null && int.TryParse(cmbSection.SelectedValue.ToString(), out int sectionId))
            {
                DataTable exams = examController.GetExamsBySectionId(sectionId);
                dgvData.DataSource = exams;
            }
            else
            {
                MessageBox.Show("Select a section first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnViewMarks_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Current studentId: " + studentId);
            var marks = marksController.GetMarksByStudentId(studentId);
            if (marks.Rows.Count == 0)
            {
                MessageBox.Show("Marks not found for this student.");
            }
            else
            {
                dgvData.DataSource = marks;
            }
        }


        private void btnViewTimetable_Click(object sender, EventArgs e)
        {
            if (cmbSection.SelectedValue != null && int.TryParse(cmbSection.SelectedValue.ToString(), out int sectionId))
            {
                DataTable timetable = timetableController.GetTimetableBySectionId(sectionId);
                dgvData.DataSource = timetable;
            }
            else
            {
                MessageBox.Show("Select a section first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
