using System;
using System.Windows.Forms;

namespace UnicomTicManageSystemApp
{
    public partial class StaffForm : Form
    {
        private int staffId;

        // Constructor that accepts staffId from login
        public StaffForm(int staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
        }

        private void btnManageTimetable_Click(object sender, EventArgs e)
        {
            // ✅ Pass staffId to TimetableManageForm
            TimetableManageForm manageTimetableForm = new TimetableManageForm(staffId);
            manageTimetableForm.Show();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {

            RoomManageForm roomForm = new RoomManageForm();
            roomForm.Show();
        }
    }
    
}

