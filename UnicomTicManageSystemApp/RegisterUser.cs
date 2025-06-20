using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Controllers;

namespace UnicomTicManageSystemApp
{
    public partial class RegisterUser : Form
    {
        private UserController userController = new UserController();
        private int selectedUserId = -1;

        public RegisterUser()
        {
            InitializeComponent();

            // Event handlers attach பண்ணலாம் இதோடு கூட
            this.Load += RegisterUser_Load;

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnView.Click += btnView_Click;
            dgvUsers.CellClick += dgvUsers_CellClick;
        }

        private void RegisterUser_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new string[] { "Admin", "Lecture", "Student", "Staff" });
            cmbRole.SelectedIndex = 0;
            LoadUsersIntoGrid();
        }

        private void LoadUsersIntoGrid()
        {
            List<User> users = userController.GetAllUsers();
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = users;

            if (dgvUsers.Columns["UserPassword"] != null)
                dgvUsers.Columns["UserPassword"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            User user = new User
            {
                UserName = txtUserName.Text.Trim(),
                UserPassword = txtPassword.Text,
                Role = cmbRole.SelectedItem.ToString()
            };

            try
            {
                userController.AddUser(user);
                MessageBox.Show("User added successfully.");
                ClearForm();
                LoadUsersIntoGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a user to update.");
                return;
            }

            if (!ValidateInputs()) return;

            User user = new User
            {
                UserId = selectedUserId,
                UserName = txtUserName.Text.Trim(),
                UserPassword = txtPassword.Text,
                Role = cmbRole.SelectedItem.ToString()
            };

            try
            {
                userController.UpdateUser(user);
                MessageBox.Show("User updated successfully.");
                ClearForm();
                LoadUsersIntoGrid();
                selectedUserId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    userController.DeleteUser(selectedUserId);
                    MessageBox.Show("User deleted successfully.");
                    ClearForm();
                    LoadUsersIntoGrid();
                    selectedUserId = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message);
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadUsersIntoGrid();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvUsers.Rows[e.RowIndex];
                selectedUserId = Convert.ToInt32(row.Cells["UserId"].Value);
                txtUserName.Text = row.Cells["UserName"].Value.ToString();
                txtPassword.Text = row.Cells["UserPassword"].Value.ToString();
                cmbRole.SelectedItem = row.Cells["Role"].Value.ToString();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please fill all fields.");
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = 0;
            selectedUserId = -1;
        }
    }
}
