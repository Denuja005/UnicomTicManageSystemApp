using System;
using System.Data;
using System.Windows.Forms;
using UnicomTicManageSystemApp.Controllers;
using UnicomTicManageSystemApp.Models;
using System.Data.SQLite;
using UnicomTicManageSystemApp.Data;

namespace UnicomTicManageSystemApp
{
    public partial class StudentAttendanceManageForm : Form
    {
        private readonly StudentAttendanceController controller = new StudentAttendanceController();
        private DataTable studentsTable;

        public StudentAttendanceManageForm()
        {
            InitializeComponent();

            try
            {
                LoadStudents();
                LoadStatus();
                LoadAttendanceGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing form: " + ex.Message);
            }

            dgvAttendance.SelectionChanged += dgvAttendance_SelectionChanged;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnView.Click += btnView_Click;
        }

        private void LoadStudents()
        {
            try
            {
                using (var conn = DbCon.GetConnection())
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT StudentId, Name FROM Students", conn);
                    var reader = cmd.ExecuteReader();
                    studentsTable = new DataTable();
                    studentsTable.Load(reader);

                    cmbStudent.DataSource = studentsTable;
                    cmbStudent.DisplayMember = "Name";
                    cmbStudent.ValueMember = "StudentId";
                    cmbStudent.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }

        private void LoadStatus()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Present");
            cmbStatus.Items.Add("Absent");
            cmbStatus.SelectedIndex = -1;
        }

        private void LoadAttendanceGrid()
        {
            try
            {
                var attendances = controller.GetAllAttendances();

                var dt = new DataTable();
                dt.Columns.Add("AttendanceId", typeof(int));
                dt.Columns.Add("StudentId", typeof(int));
                dt.Columns.Add("Name", typeof(string)); // 👉 Add Name for display
                dt.Columns.Add("AttendanceDate", typeof(DateTime));
                dt.Columns.Add("Status", typeof(string));

                foreach (var a in attendances)
                {
                    // Find student name by StudentId
                    string name = GetStudentNameById(a.StudentId);
                    dt.Rows.Add(a.AttendanceId, a.StudentId, name, a.AttendanceDate, a.Status);
                }

                dgvAttendance.DataSource = dt;

                dgvAttendance.Columns["AttendanceId"].HeaderText = "ID";
                dgvAttendance.Columns["StudentId"].Visible = false; // hide id
                dgvAttendance.Columns["Name"].HeaderText = "Student";
                dgvAttendance.Columns["AttendanceDate"].HeaderText = "Date";
                dgvAttendance.Columns["Status"].HeaderText = "Status";

                dgvAttendance.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance records: " + ex.Message);
            }
        }

        private string GetStudentNameById(int studentId)
        {
            if (studentsTable == null) return "";

            var rows = studentsTable.Select($"StudentId = {studentId}");
            if (rows.Length > 0)
            {
                return rows[0]["Name"].ToString();
            }

            return "Unknown";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs()) return;

                var attendance = new StudentAttendance
                {
                    StudentId = Convert.ToInt32(cmbStudent.SelectedValue),
                    AttendanceDate = dtpAttendanceDate.Value.Date,
                    Status = cmbStatus.SelectedItem.ToString()
                };

                controller.AddAttendance(attendance);
                MessageBox.Show("Attendance added successfully.");
                LoadAttendanceGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding attendance: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAttendance.CurrentRow == null)
                {
                    MessageBox.Show("Please select an attendance record to update.");
                    return;
                }

                var attendanceIdObj = dgvAttendance.CurrentRow.Cells["AttendanceId"].Value;
                if (attendanceIdObj == null || attendanceIdObj == DBNull.Value)
                {
                    MessageBox.Show("Invalid attendance record selected.");
                    return;
                }

                if (!ValidateInputs()) return;

                var attendance = new StudentAttendance
                {
                    AttendanceId = Convert.ToInt32(attendanceIdObj),
                    StudentId = Convert.ToInt32(cmbStudent.SelectedValue),
                    AttendanceDate = dtpAttendanceDate.Value.Date,
                    Status = cmbStatus.SelectedItem.ToString()
                };

                controller.UpdateAttendance(attendance);
                MessageBox.Show("Attendance updated successfully.");
                LoadAttendanceGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating attendance: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAttendance.CurrentRow == null)
                {
                    MessageBox.Show("Please select an attendance record to delete.");
                    return;
                }

                var attendanceIdObj = dgvAttendance.CurrentRow.Cells["AttendanceId"].Value;
                if (attendanceIdObj == null || attendanceIdObj == DBNull.Value)
                {
                    MessageBox.Show("Invalid attendance record selected.");
                    return;
                }

                int attendanceId = Convert.ToInt32(attendanceIdObj);

                var confirm = MessageBox.Show("Are you sure you want to delete this attendance record?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    controller.DeleteAttendance(attendanceId);
                    MessageBox.Show("Attendance deleted successfully.");
                    LoadAttendanceGrid();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting attendance: " + ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                LoadAttendanceGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void dgvAttendance_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvAttendance.CurrentRow == null) return;

                var attendanceIdObj = dgvAttendance.CurrentRow.Cells["AttendanceId"].Value;
                if (attendanceIdObj == null || attendanceIdObj == DBNull.Value) return;

                cmbStudent.SelectedValue = dgvAttendance.CurrentRow.Cells["StudentId"].Value;
                dtpAttendanceDate.Value = Convert.ToDateTime(dgvAttendance.CurrentRow.Cells["AttendanceDate"].Value);
                cmbStatus.SelectedItem = dgvAttendance.CurrentRow.Cells["Status"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting row: " + ex.Message);
            }
        }

        private bool ValidateInputs()
        {
            if (cmbStudent.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a student.");
                return false;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a status (Present or Absent).");
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            cmbStudent.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            dtpAttendanceDate.Value = DateTime.Today;
            dgvAttendance.ClearSelection();
        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
