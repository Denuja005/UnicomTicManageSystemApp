using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTicManageSystemApp.Controllers;
using UnicomTicManageSystemApp.Models;

namespace UnicomTicManageSystemApp
{
    public partial class Subject_SectionManageForm : Form
    {
        private SectionController sectionController = new SectionController();
        private SubjectController subjectController = new SubjectController();

        public Subject_SectionManageForm()
        {
            InitializeComponent();
            InitializeGrid();
            LoadSections();

            cmbSectionSelect.SelectedIndexChanged += cmbSectionSelect_SelectedIndexChanged;

            btnAddSubjects.Click += btnAddSubjects_Click;
            btnUpdateSubjects.Click += btnUpdateSubjects_Click;
            btnDeleteSubjects.Click += btnDeleteSubjects_Click;
            btnViewSubjects.Click += btnViewSubjects_Click;

            dgvSubjects.SelectionChanged += dgvSubjects_SelectionChanged;
        }

        private void InitializeGrid()
        {
            dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubjects.MultiSelect = true;
            dgvSubjects.AutoGenerateColumns = false;
            dgvSubjects.Columns.Clear();

            dgvSubjects.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SubjectId",
                HeaderText = "ID",
                Name = "SubjectId",
                Visible = false
            });

            dgvSubjects.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SubjectName",
                HeaderText = "Subject Name",
                Name = "SubjectName",
                Width = 200
            });

            dgvSubjects.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SectionId",
                HeaderText = "Section ID",
                Name = "SectionId",
                Visible = false
            });
        }

        private void LoadSections()
        {
            var sections = sectionController.GetAllSections();
            cmbSectionSelect.DataSource = sections;
            cmbSectionSelect.DisplayMember = "SectionName";
            cmbSectionSelect.ValueMember = "SectionId";
            cmbSectionSelect.SelectedIndex = -1;
        }

        private void cmbSectionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubjects();
            ClearSubjectTextBoxes();
        }

        private void LoadSubjects()
        {
            if (cmbSectionSelect.SelectedValue == null)
            {
                dgvSubjects.DataSource = null;
                ClearSubjectTextBoxes();
                return;
            }

            if (int.TryParse(cmbSectionSelect.SelectedValue.ToString(), out int sectionId))
            {
                var subjects = subjectController.GetBySectionId(sectionId);
                dgvSubjects.DataSource = subjects;

                // Clear subject text boxes initially
                ClearSubjectTextBoxes();

                // If subjects exist, fill the textboxes with first two subjects
                if (subjects.Count > 0)
                    txtSubject1.Text = subjects[0].SubjectName;

                if (subjects.Count > 1)
                    txtSubject2.Text = subjects[1].SubjectName;
            }
        }

        private void ClearSubjectTextBoxes()
        {
            txtSubject1.Text = "";
            txtSubject2.Text = "";
        }

        private void btnAddSubjects_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(cmbSectionSelect.SelectedValue?.ToString(), out int sectionId))
            {
                MessageBox.Show("Please select a valid section.");
                return;
            }

            string subject1Name = txtSubject1.Text.Trim();
            string subject2Name = txtSubject2.Text.Trim();

            if (string.IsNullOrEmpty(subject1Name) || string.IsNullOrEmpty(subject2Name))
            {
                MessageBox.Show("Please enter both subject names.");
                return;
            }

            // Check if subjects already exist for this section
            var existingSubjects = subjectController.GetBySectionId(sectionId);
            if (existingSubjects.Count > 0)
            {
                MessageBox.Show("Subjects already exist for this section. Please update them instead.");
                return;
            }

            // Add new subjects
            subjectController.AddSubject(new Subject { SubjectName = subject1Name, SectionId = sectionId });
            subjectController.AddSubject(new Subject { SubjectName = subject2Name, SectionId = sectionId });

            MessageBox.Show("Subjects added successfully.");
            LoadSubjects();
            ClearSubjectTextBoxes();
        }

        private void btnUpdateSubjects_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(cmbSectionSelect.SelectedValue?.ToString(), out int sectionId))
            {
                MessageBox.Show("Please select a valid section.");
                return;
            }

            var subjects = subjectController.GetBySectionId(sectionId);
            if (subjects.Count == 0)
            {
                MessageBox.Show("No subjects found to update for this section.");
                return;
            }

            string name1 = txtSubject1.Text.Trim();
            string name2 = txtSubject2.Text.Trim();

            if (string.IsNullOrEmpty(name1) || string.IsNullOrEmpty(name2))
            {
                MessageBox.Show("Please enter both subject names.");
                return;
            }

            // Update subjects if available
            if (subjects.Count >= 1)
            {
                subjects[0].SubjectName = name1;
                subjectController.UpdateSubject(subjects[0]);
            }
            else
            {
                subjectController.AddSubject(new Subject { SubjectName = name1, SectionId = sectionId });
            }

            if (subjects.Count >= 2)
            {
                subjects[1].SubjectName = name2;
                subjectController.UpdateSubject(subjects[1]);
            }
            else
            {
                subjectController.AddSubject(new Subject { SubjectName = name2, SectionId = sectionId });
            }

            MessageBox.Show("Subjects updated successfully.");
            LoadSubjects();
            ClearSubjectTextBoxes();
        }

        private void btnDeleteSubjects_Click(object sender, EventArgs e)
        {
            if (dgvSubjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select subject(s) to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete the selected subject(s)?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No)
                return;

            foreach (DataGridViewRow row in dgvSubjects.SelectedRows)
            {
                if (row.Cells["SubjectId"].Value != null &&
                    int.TryParse(row.Cells["SubjectId"].Value.ToString(), out int subjectId))
                {
                    subjectController.DeleteSubject(subjectId);
                }
            }

            MessageBox.Show("Selected subject(s) deleted successfully.");
            LoadSubjects();
            ClearSubjectTextBoxes();
        }

        private void btnViewSubjects_Click(object sender, EventArgs e)
        {
            LoadSubjects();
            ClearSubjectTextBoxes();
        }

        private void dgvSubjects_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSubjects.SelectedRows.Count == 0)
            {
                ClearSubjectTextBoxes();
                return;
            }

            var rows = dgvSubjects.SelectedRows;

            if (rows.Count >= 1)
                txtSubject1.Text = rows[0].Cells["SubjectName"].Value?.ToString() ?? "";

            if (rows.Count >= 2)
                txtSubject2.Text = rows[1].Cells["SubjectName"].Value?.ToString() ?? "";
            else
                txtSubject2.Text = "";
        }

        private void btnUpdateSubjects_Click_1(object sender, EventArgs e)
        {

        }
    }
}
