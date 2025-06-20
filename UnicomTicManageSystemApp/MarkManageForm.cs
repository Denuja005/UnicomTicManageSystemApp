using System;
using System.Windows.Forms;
using UnicomTicManageSystemApp.Controllers;
using UnicomTicManageSystemApp.Models;

namespace UnicomTicManageSystemApp
{
    public partial class MarkManageForm : Form
    {
        private readonly MarksController marksController = new MarksController();
        private readonly StudentController studentController = new StudentController();
        private readonly SubjectController subjectController = new SubjectController();
        private readonly ExamController examController = new ExamController();

        private int selectedMarkId = -1;
        private int loggedInStaffId;

        public MarkManageForm(int staffId)
        {
            InitializeComponent();
            loggedInStaffId = staffId;

            InitializeGrid();
            LoadDropdowns();

            dgvMarks.SelectionChanged += DgvMarks_SelectionChanged;

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnView.Click += BtnView_Click;

            LoadMarks();  // Load data initially
        }

        public MarkManageForm()
        {
            InitializeComponent();

            InitializeGrid();
            LoadDropdowns();

            dgvMarks.SelectionChanged += DgvMarks_SelectionChanged;

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnView.Click += BtnView_Click;

            LoadMarks();  // Load data initially
        }

        private void InitializeGrid()
        {
            dgvMarks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMarks.MultiSelect = false;
            dgvMarks.AutoGenerateColumns = false;
            dgvMarks.Columns.Clear();

            // Add hidden IDs columns so they can be accessed in code
            dgvMarks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MarkId",
                HeaderText = "ID",
                Name = "MarkId",
                Visible = false
            });

            dgvMarks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StudentId",
                HeaderText = "StudentId",
                Name = "StudentId",
                Visible = false
            });

            dgvMarks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SubjectId",
                HeaderText = "SubjectId",
                Name = "SubjectId",
                Visible = false
            });

            dgvMarks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ExamId",
                HeaderText = "ExamId",
                Name = "ExamId",
                Visible = false
            });

            // Visible columns
            dgvMarks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StudentName",
                HeaderText = "Student",
                Name = "StudentName",
                Width = 150
            });

            dgvMarks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SubjectName",
                HeaderText = "Subject",
                Name = "SubjectName",
                Width = 150
            });

            dgvMarks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ExamName",
                HeaderText = "Exam",
                Name = "ExamName",
                Width = 150
            });

            dgvMarks.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Score",
                HeaderText = "Score",
                Name = "Score",
                Width = 70
            });
        }

        private void LoadDropdowns()
        {
            var students = studentController.GetAllStudents();
            cmbStudent.DataSource = students;
            cmbStudent.DisplayMember = "StudentName";
            cmbStudent.ValueMember = "StudentId";
            cmbStudent.SelectedIndex = -1;

            var subjects = subjectController.GetAllSubjects();
            cmbSubject.DataSource = subjects;
            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "SubjectId";
            cmbSubject.SelectedIndex = -1;

            var exams = examController.GetAllExams();
            cmbExam.DataSource = exams;
            cmbExam.DisplayMember = "ExamName";
            cmbExam.ValueMember = "ExamId";
            cmbExam.SelectedIndex = -1;
        }

        private void LoadMarks()
        {
            var marks = marksController.GetAllMarksWithDetails();
            dgvMarks.DataSource = marks;
        }

        private void DgvMarks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarks.SelectedRows.Count == 0)
            {
                ClearInputs();
                selectedMarkId = -1;
                return;
            }

            var row = dgvMarks.SelectedRows[0];
            selectedMarkId = Convert.ToInt32(row.Cells["MarkId"].Value);
            cmbStudent.SelectedValue = row.Cells["StudentId"].Value;
            cmbSubject.SelectedValue = row.Cells["SubjectId"].Value;
            cmbExam.SelectedValue = row.Cells["ExamId"].Value;
            txtScore.Text = row.Cells["Score"].Value.ToString();
        }

        private void ClearInputs()
        {
            cmbStudent.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            cmbExam.SelectedIndex = -1;
            txtScore.Text = "";
        }

        private bool ValidateInputs()
        {
            if (cmbStudent.SelectedValue == null || cmbSubject.SelectedValue == null || cmbExam.SelectedValue == null || string.IsNullOrWhiteSpace(txtScore.Text))
            {
                MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtScore.Text, out int score) || score < 0)
            {
                MessageBox.Show("Please enter a valid non-negative score.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var mark = new Mark
            {
                StudentId = Convert.ToInt32(cmbStudent.SelectedValue),
                SubjectId = Convert.ToInt32(cmbSubject.SelectedValue),
                ExamId = Convert.ToInt32(cmbExam.SelectedValue),
                Score = Convert.ToInt32(txtScore.Text),
                StaffId = loggedInStaffId
            };

            marksController.AddMark(mark);
            MessageBox.Show("Mark added successfully.");
            LoadMarks();
            ClearInputs();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedMarkId == -1)
            {
                MessageBox.Show("Please select a mark to update.");
                return;
            }

            if (!ValidateInputs()) return;

            var mark = new Mark
            {
                MarkId = selectedMarkId,
                StudentId = Convert.ToInt32(cmbStudent.SelectedValue),
                SubjectId = Convert.ToInt32(cmbSubject.SelectedValue),
                ExamId = Convert.ToInt32(cmbExam.SelectedValue),
                Score = Convert.ToInt32(txtScore.Text),
                StaffId = loggedInStaffId
            };

            marksController.UpdateMark(mark);
            MessageBox.Show("Mark updated successfully.");
            LoadMarks();
            ClearInputs();
            selectedMarkId = -1;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedMarkId == -1)
            {
                MessageBox.Show("Please select a mark to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this mark?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                marksController.DeleteMark(selectedMarkId);
                MessageBox.Show("Mark deleted successfully.");
                LoadMarks();
                ClearInputs();
                selectedMarkId = -1;
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            LoadMarks();
        }

        private void dgvMarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
