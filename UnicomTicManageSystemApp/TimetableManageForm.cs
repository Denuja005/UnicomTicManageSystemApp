using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Controllers;

namespace UnicomTicManageSystemApp
{
    public partial class TimetableManageForm : Form
    {
        private readonly TimetableController timetableController = new TimetableController();
        private readonly SectionController sectionController = new SectionController();
        private readonly SubjectController subjectController = new SubjectController();
        private readonly LectureController lectureController = new LectureController();
        private readonly RoomController roomController = new RoomController();

        private int selectedTimetableId = -1;
        private int staffId;

        public TimetableManageForm(int loggedInStaffId)
        {
            InitializeComponent();
            staffId = loggedInStaffId;

            this.Load += TimetableManageForm_Load;

            dgvTimetable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTimetable.MultiSelect = false;
            dgvTimetable.ReadOnly = true;
            dgvTimetable.AllowUserToAddRows = false;

            dgvTimetable.CellClick += dgvTimetable_CellClick;

            cmbRoom.SelectedIndexChanged += cmbRoom_SelectedIndexChanged;

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnView.Click += btnView_Click;

            cmbRoomType.Enabled = false; // readonly
        }

        private void TimetableManageForm_Load(object sender, EventArgs e)
        {
            LoadDropdowns();
            LoadTimetables();
            ClearForm();
        }

        private void LoadDropdowns()
        {
            // Sections
            var sections = sectionController.GetAllSections();
            cmbSection.DataSource = sections;
            cmbSection.DisplayMember = "SectionName";
            cmbSection.ValueMember = "SectionId";
            cmbSection.SelectedIndex = -1;

            // Subjects
            var subjects = subjectController.GetAllSubjects();
            cmbSubject.DataSource = subjects;
            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "SubjectId";
            cmbSubject.SelectedIndex = -1;

            // Lectures
            var lectures = lectureController.GetAllLectures();
            cmbLecturer.DataSource = lectures;
            cmbLecturer.DisplayMember = "LectureName";
            cmbLecturer.ValueMember = "LectureId";
            cmbLecturer.SelectedIndex = -1;

            // Rooms
            var rooms = roomController.GetAllRooms();
            cmbRoom.DataSource = rooms;
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomId";
            cmbRoom.SelectedIndex = -1;

            // Days
            cmbDay.DataSource = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            cmbDay.SelectedIndex = -1;

            SetRoomTypeFromSelectedRoom();
        }

        private void SetRoomTypeFromSelectedRoom()
        {
            cmbRoomType.Items.Clear();
            cmbRoomType.Text = "";

            if (cmbRoom.SelectedValue == null) return;

            if (int.TryParse(cmbRoom.SelectedValue.ToString(), out int roomId))
            {
                var room = roomController.GetRoomById(roomId);
                if (room != null)
                {
                    cmbRoomType.Items.Add(room.RoomType);
                    cmbRoomType.SelectedIndex = 0;
                }
            }
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRoomTypeFromSelectedRoom();
        }

        private void LoadTimetables()
        {
            var timetables = timetableController.GetAllTimetables();
            dgvTimetable.DataSource = timetables;

            // Adjust columns if necessary
            dgvTimetable.Columns["TimetableId"].Visible = false;

            selectedTimetableId = -1;
        }

        private void dgvTimetable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvTimetable.Rows[e.RowIndex];
                if (row.Cells["TimetableId"].Value != null)
                {
                    selectedTimetableId = Convert.ToInt32(row.Cells["TimetableId"].Value);

                    cmbSection.SelectedValue = Convert.ToInt32(row.Cells["SectionId"].Value);
                    cmbSubject.SelectedValue = Convert.ToInt32(row.Cells["SubjectId"].Value);
                    cmbLecturer.SelectedValue = Convert.ToInt32(row.Cells["LectureId"].Value);
                    cmbRoom.SelectedValue = Convert.ToInt32(row.Cells["RoomId"].Value);
                    cmbDay.SelectedItem = row.Cells["Day"].Value.ToString();
                    txtTimeSlot.Text = row.Cells["TimeSlot"].Value.ToString();

                    DateTime date;
                    if (DateTime.TryParse(row.Cells["Date"].Value?.ToString(), out date))
                    {
                        dtpDate.Value = date;
                    }
                    else
                    {
                        dtpDate.Value = DateTime.Now;
                    }

                    SetRoomTypeFromSelectedRoom();
                }
            }
        }

        private bool ValidateInputs()
        {
            if (cmbSection.SelectedValue == null ||
                cmbSubject.SelectedValue == null ||
                cmbLecturer.SelectedValue == null ||
                cmbRoom.SelectedValue == null ||
                cmbDay.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtTimeSlot.Text))
            {
                MessageBox.Show("All fields are mandatory. Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            Timetable timetable = new Timetable
            {
                SectionId = Convert.ToInt32(cmbSection.SelectedValue),
                SubjectId = Convert.ToInt32(cmbSubject.SelectedValue),
                LectureId = Convert.ToInt32(cmbLecturer.SelectedValue),
                RoomId = Convert.ToInt32(cmbRoom.SelectedValue),
                Day = cmbDay.SelectedItem.ToString(),
                TimeSlot = txtTimeSlot.Text.Trim(),
                StaffId = staffId,
                Date = dtpDate.Value.ToString("yyyy-MM-dd")
            };

            try
            {
                timetableController.AddTimetable(timetable);
                MessageBox.Show("Timetable added successfully.");
                LoadTimetables();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding timetable: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedTimetableId == -1)
            {
                MessageBox.Show("Please select a timetable to update.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs()) return;

            Timetable timetable = new Timetable
            {
                TimetableId = selectedTimetableId,
                SectionId = Convert.ToInt32(cmbSection.SelectedValue),
                SubjectId = Convert.ToInt32(cmbSubject.SelectedValue),
                LectureId = Convert.ToInt32(cmbLecturer.SelectedValue),
                RoomId = Convert.ToInt32(cmbRoom.SelectedValue),
                Day = cmbDay.SelectedItem.ToString(),
                TimeSlot = txtTimeSlot.Text.Trim(),
                StaffId = staffId,
                Date = dtpDate.Value.ToString("yyyy-MM-dd")
            };

            try
            {
                timetableController.UpdateTimetable(timetable);
                MessageBox.Show("Timetable updated successfully.");
                LoadTimetables();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating timetable: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTimetableId == -1)
            {
                MessageBox.Show("Please select a timetable to delete.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete the selected timetable?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    timetableController.DeleteTimetable(selectedTimetableId);
                    MessageBox.Show("Timetable deleted successfully.");
                    LoadTimetables();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting timetable: " + ex.Message);
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadTimetables();
            ClearForm();
        }

        private void ClearForm()
        {
            selectedTimetableId = -1;

            cmbSection.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            cmbLecturer.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            cmbDay.SelectedIndex = -1;

            txtTimeSlot.Clear();
            dtpDate.Value = DateTime.Now;

            cmbRoomType.Items.Clear();
            cmbRoomType.Text = "";
        }
    }
}
