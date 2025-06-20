using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UnicomTicManageSystemApp.Models;
using UnicomTicManageSystemApp.Controllers;

namespace UnicomTicManageSystemApp
{
    public partial class StaffManageForm : Form
    {
        private StaffController staffController = new StaffController();
        private int selectedStaffId = -1;

        public StaffManageForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff
            {
                StaffName = txtName.Text.Trim(),
                StaffEmail = txtEmail.Text.Trim(),
                StaffPhone = txtPhone.Text.Trim()
            };
            staffController.AddStaff(staff);
            MessageBox.Show("Staff Added Successfully");
            ClearInputs();
            LoadStaffData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStaffId == -1)
            {
                MessageBox.Show("Please select a staff to update");
                return;
            }

            Staff staff = new Staff
            {
                StaffId = selectedStaffId,
                StaffName = txtName.Text.Trim(),
                StaffEmail = txtEmail.Text.Trim(),
                StaffPhone = txtPhone.Text.Trim()
            };
            staffController.UpdateStaff(staff);
            MessageBox.Show("Staff Updated Successfully");
            ClearInputs();
            LoadStaffData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStaffId == -1)
            {
                MessageBox.Show("Please select a staff to delete");
                return;
            }

            var confirm = MessageBox.Show("Are you sure to delete this staff?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                staffController.DeleteStaff(selectedStaffId);
                MessageBox.Show("Staff Deleted Successfully");
                ClearInputs();
                LoadStaffData();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadStaffData();
        }

        private void LoadStaffData()
        {
            var list = staffController.GetAllStaffs();
            dgvStaff.DataSource = null;
            dgvStaff.DataSource = list;
            selectedStaffId = -1;
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            selectedStaffId = -1;
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvStaff.Rows[e.RowIndex];
                Staff staff = row.DataBoundItem as Staff;

                if (staff != null)
                {
                    selectedStaffId = staff.StaffId;
                    txtName.Text = staff.StaffName;
                    txtEmail.Text = staff.StaffEmail;
                    txtPhone.Text = staff.StaffPhone;
                }
            }
        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
