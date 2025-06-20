using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnicomTicManageSystemApp
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RegisterUser registerUserForm = new RegisterUser();
            registerUserForm.ShowDialog();  
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExamManageForm manageExamForm = new ExamManageForm();
            manageExamForm.Show();
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            StudentManageForm studentManageForm = new StudentManageForm();
            studentManageForm.Show();
        }

        private void btnManageStaff_Click(object sender, EventArgs e)
        {
            StaffManageForm staffManageForm = new StaffManageForm();
            staffManageForm.Show();
        }

       

        private void btnManageLecture_Click(object sender, EventArgs e)
        {
            LectureManageForm lectureManageForm = new LectureManageForm();
            lectureManageForm.Show();
        }

        private void btnManageSubjects_Click(object sender, EventArgs e)
        {
            Subject_SectionManageForm form = new Subject_SectionManageForm();
            form.Show();
        }

        private void btnManageSections_Click(object sender, EventArgs e)
        {
            SectionManageForm form = new SectionManageForm();
            form.Show();
        }

        private void btnManageStaffAttendance_Click(object sender, EventArgs e)
        {
            StaffAttendanceManageForm form = new StaffAttendanceManageForm();
            form.Show();
        }

        private void btnManageLecturerAttendance_Click(object sender, EventArgs e)
        {
            LectureAttendanceManageForm form = new LectureAttendanceManageForm();
            form.Show();
        }
    }
}

