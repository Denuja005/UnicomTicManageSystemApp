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
    public partial class LectureForm : Form
    {
        public LectureForm()
        {
            InitializeComponent();
        }

        private void LectureForm_Load(object sender, EventArgs e)
        { }

     
        private void button1_Click(object sender, EventArgs e)
        {
            int loggedInStaffId = 1;
            MarkManageForm markManageForm = new MarkManageForm(loggedInStaffId);
            markManageForm.ShowDialog();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            StudentAttendanceManageForm manageAttendanceForm = new StudentAttendanceManageForm();
            manageAttendanceForm.Show();  
        }
    }
    
}
