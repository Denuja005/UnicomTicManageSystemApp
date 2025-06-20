using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTicManageSystemApp.Controllers;
using UnicomTicManageSystemApp.Models;

namespace UnicomTicManageSystemApp
{
    public partial class RoomManageForm : Form
    {
        private readonly RoomController roomController = new RoomController();
        private int selectedRoomId = -1;

        public RoomManageForm()
        {
            InitializeComponent();
            InitializeRoomGrid();
            LoadRoomTypes();
            LoadRooms();

            dgvRooms.SelectionChanged += dgvRooms_SelectionChanged;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnView.Click += btnView_Click;
        }

        private void InitializeRoomGrid()
        {
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.MultiSelect = false;
            dgvRooms.AutoGenerateColumns = false;
            dgvRooms.Columns.Clear();

            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomId",
                HeaderText = "Room ID",
                Name = "RoomId",
                Visible = false
            });

            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomName",
                HeaderText = "Room Name",
                Name = "RoomName",
                Width = 200
            });

            dgvRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomType",
                HeaderText = "Room Type",
                Name = "RoomType",
                Width = 120
            });
        }

        private void LoadRoomTypes()
        {
            cmbRoomType.Items.Clear();
            cmbRoomType.Items.Add("Lab");
            cmbRoomType.Items.Add("Hall");
            cmbRoomType.SelectedIndex = 0;
        }

        private void LoadRooms()
        {
            try
            {
                dgvRooms.DataSource = null;
                dgvRooms.DataSource = roomController.GetAllRooms();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rooms: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomName.Text))
            {
                MessageBox.Show("Please enter Room Name.");
                return;
            }

            var room = new Room
            {
                RoomName = txtRoomName.Text.Trim(),
                RoomType = cmbRoomType.SelectedItem.ToString()
            };

            roomController.AddRoom(room);
            MessageBox.Show("Room added successfully.");
            LoadRooms();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedRoomId == -1)
            {
                MessageBox.Show("Please select a room to update.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRoomName.Text))
            {
                MessageBox.Show("Please enter Room Name.");
                return;
            }

            var room = new Room
            {
                RoomId = selectedRoomId,
                RoomName = txtRoomName.Text.Trim(),
                RoomType = cmbRoomType.SelectedItem.ToString()
            };

            roomController.UpdateRoom(room);
            MessageBox.Show("Room updated successfully.");
            LoadRooms();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRoomId == -1)
            {
                MessageBox.Show("Please select a room to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure to delete this room?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                roomController.DeleteRoom(selectedRoomId);
                MessageBox.Show("Room deleted successfully.");
                LoadRooms();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void dgvRooms_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                ClearInputs();
                return;
            }

            var row = dgvRooms.SelectedRows[0];

            selectedRoomId = Convert.ToInt32(row.Cells["RoomId"].Value);
            txtRoomName.Text = row.Cells["RoomName"].Value?.ToString();
            string roomType = row.Cells["RoomType"].Value?.ToString();

            if (cmbRoomType.Items.Contains(roomType))
                cmbRoomType.SelectedItem = roomType;
            else
                cmbRoomType.SelectedIndex = 0;
        }

        private void ClearInputs()
        {
            txtRoomName.Clear();
            cmbRoomType.SelectedIndex = 0;
            selectedRoomId = -1;
        }
        private void dgvRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // இங்கு எதுவும் தேவையில்லை. இல்லென்றால் மட்டும் கூட add பண்ணனும்.
        }

    }
}
