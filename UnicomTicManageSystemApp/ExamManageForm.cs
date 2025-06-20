using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UnicomTicManageSystemApp.Controllers;
using UnicomTicManageSystemApp.Models;

namespace UnicomTicManageSystemApp
{
    public partial class ExamManageForm : Form
    {
        private ExamController examController = new ExamController();
        private SubjectController subjectController = new SubjectController();

        public ExamManageForm()
        {
            InitializeComponent();
            InitializeGrid();
            LoadSubjects();
            LoadExams();

            dgvExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExams.MultiSelect = false;
            dgvExams.SelectionChanged += DgvExams_SelectionChanged;

            btnAddExam.Click += BtnAddExam_Click;
            btnUpdateExam.Click += BtnUpdateExam_Click;
            btnDeleteExam.Click += BtnDeleteExam_Click;
            btnViewExams.Click += BtnViewExams_Click;
        }

        private void InitializeGrid()
        {
            dgvExams.AutoGenerateColumns = false;
            dgvExams.Columns.Clear();

            dgvExams.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ExamId",
                HeaderText = "ID",
                Name = "ExamId",
                Visible = false
            });

            dgvExams.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ExamName",
                HeaderText = "Exam Name",
                Name = "ExamName",
                Width = 150
            });

            dgvExams.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ExamDate",
                HeaderText = "Exam Date",
                Name = "ExamDate",
                Width = 100
            });

            dgvExams.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SubjectName",
                HeaderText = "Subject",
                Name = "SubjectName",
                Width = 150
            });
        }

        private void LoadSubjects()
        {
            var subjects = subjectController.GetAllSubjects();
            cmbSubject.DataSource = subjects;
            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "SubjectId";
            cmbSubject.SelectedIndex = -1;
        }

        private void LoadExams()
        {
            var exams = examController.GetAllExams();
            var subjects = subjectController.GetAllSubjects();

            var examViewList = exams.Select(e =>
            {
                var subjName = subjects.FirstOrDefault(s => s.SubjectId == e.SubjectId)?.SubjectName ?? "";
                return new
                {
                    e.ExamId,
                    e.ExamName,
                    ExamDate = e.ExamDate.ToString("yyyy-MM-dd"),
                    SubjectName = subjName
                };
            }).ToList();

            dgvExams.DataSource = examViewList;
        }

        private void DgvExams_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvExams.SelectedRows.Count == 0)
            {
                ClearInputs();
                return;
            }

            var row = dgvExams.SelectedRows[0];
            txtExamName.Text = row.Cells["ExamName"].Value?.ToString();

            if (DateTime.TryParse(row.Cells["ExamDate"].Value?.ToString(), out DateTime examDate))
            {
                dtpExamDate.Value = examDate;
            }

            var subjectName = row.Cells["SubjectName"].Value?.ToString();
            for (int i = 0; i < cmbSubject.Items.Count; i++)
            {
                var item = (Subject)cmbSubject.Items[i];
                if (item.SubjectName == subjectName)
                {
                    cmbSubject.SelectedIndex = i;
                    break;
                }
            }
        }

        private void ClearInputs()
        {
            txtExamName.Clear();
            dtpExamDate.Value = DateTime.Today;
            cmbSubject.SelectedIndex = -1;
        }

        private void BtnAddExam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExamName.Text))
            {
                MessageBox.Show("Please enter Exam Name.");
                return;
            }

            if (cmbSubject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Subject.");
                return;
            }

            var exam = new Exam
            {
                ExamName = txtExamName.Text.Trim(),
                ExamDate = dtpExamDate.Value,
                SubjectId = (int)cmbSubject.SelectedValue
            };

            examController.AddExam(exam);
            LoadExams();
            ClearInputs();

            MessageBox.Show("Exam added successfully.");
        }

        private void BtnUpdateExam_Click(object sender, EventArgs e)
        {
            if (dgvExams.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an Exam to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtExamName.Text))
            {
                MessageBox.Show("Please enter Exam Name.");
                return;
            }

            if (cmbSubject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Subject.");
                return;
            }

            var examId = Convert.ToInt32(dgvExams.SelectedRows[0].Cells["ExamId"].Value);

            var exam = new Exam
            {
                ExamId = examId,
                ExamName = txtExamName.Text.Trim(),
                ExamDate = dtpExamDate.Value,
                SubjectId = (int)cmbSubject.SelectedValue
            };

            examController.UpdateExam(exam);
            LoadExams();
            ClearInputs();

            MessageBox.Show("Exam updated successfully.");
        }

        private void BtnDeleteExam_Click(object sender, EventArgs e)
        {
            if (dgvExams.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an Exam to delete.");
                return;
            }

            var examId = Convert.ToInt32(dgvExams.SelectedRows[0].Cells["ExamId"].Value);

            var confirm = MessageBox.Show("Are you sure to delete this exam?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                examController.DeleteExam(examId);
                LoadExams();
                ClearInputs();

                MessageBox.Show("Exam deleted successfully.");
            }
        }

        private void BtnViewExams_Click(object sender, EventArgs e)
        {
            LoadExams();
            ClearInputs();
        }
    }
}
