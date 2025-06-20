namespace UnicomTicManageSystemApp
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnManageStudents = new System.Windows.Forms.Button();
            this.btnManageStaff = new System.Windows.Forms.Button();
            this.btnManageSubjects = new System.Windows.Forms.Button();
            this.btnManageSections = new System.Windows.Forms.Button();
            this.btnRegisterUser = new System.Windows.Forms.Button();
            this.btnManageExams = new System.Windows.Forms.Button();
            this.btnManageStaffAttendance = new System.Windows.Forms.Button();
            this.btnManageLecturerAttendance = new System.Windows.Forms.Button();
            this.btnManageLecture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageStudents
            // 
            this.btnManageStudents.Location = new System.Drawing.Point(46, 28);
            this.btnManageStudents.Name = "btnManageStudents";
            this.btnManageStudents.Size = new System.Drawing.Size(209, 41);
            this.btnManageStudents.TabIndex = 0;
            this.btnManageStudents.Text = "Manage Students";
            this.btnManageStudents.UseVisualStyleBackColor = true;
            this.btnManageStudents.Click += new System.EventHandler(this.btnManageStudents_Click);
            // 
            // btnManageStaff
            // 
            this.btnManageStaff.Location = new System.Drawing.Point(46, 90);
            this.btnManageStaff.Name = "btnManageStaff";
            this.btnManageStaff.Size = new System.Drawing.Size(209, 42);
            this.btnManageStaff.TabIndex = 1;
            this.btnManageStaff.Text = "Manage Staff";
            this.btnManageStaff.UseVisualStyleBackColor = true;
            this.btnManageStaff.Click += new System.EventHandler(this.btnManageStaff_Click);
            // 
            // btnManageSubjects
            // 
            this.btnManageSubjects.Location = new System.Drawing.Point(46, 225);
            this.btnManageSubjects.Name = "btnManageSubjects";
            this.btnManageSubjects.Size = new System.Drawing.Size(209, 42);
            this.btnManageSubjects.TabIndex = 2;
            this.btnManageSubjects.Text = "ManageSubject";
            this.btnManageSubjects.UseVisualStyleBackColor = true;
            this.btnManageSubjects.Click += new System.EventHandler(this.btnManageSubjects_Click);
            // 
            // btnManageSections
            // 
            this.btnManageSections.Location = new System.Drawing.Point(457, 28);
            this.btnManageSections.Name = "btnManageSections";
            this.btnManageSections.Size = new System.Drawing.Size(209, 42);
            this.btnManageSections.TabIndex = 3;
            this.btnManageSections.Text = "ManageSection";
            this.btnManageSections.UseVisualStyleBackColor = true;
            this.btnManageSections.Click += new System.EventHandler(this.btnManageSections_Click);
            // 
            // btnRegisterUser
            // 
            this.btnRegisterUser.Location = new System.Drawing.Point(246, 328);
            this.btnRegisterUser.Name = "btnRegisterUser";
            this.btnRegisterUser.Size = new System.Drawing.Size(209, 42);
            this.btnRegisterUser.TabIndex = 4;
            this.btnRegisterUser.Text = "Register Users";
            this.btnRegisterUser.UseVisualStyleBackColor = true;
            this.btnRegisterUser.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnManageExams
            // 
            this.btnManageExams.Location = new System.Drawing.Point(457, 90);
            this.btnManageExams.Name = "btnManageExams";
            this.btnManageExams.Size = new System.Drawing.Size(209, 42);
            this.btnManageExams.TabIndex = 5;
            this.btnManageExams.Text = "manage Exams";
            this.btnManageExams.UseVisualStyleBackColor = true;
            this.btnManageExams.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnManageStaffAttendance
            // 
            this.btnManageStaffAttendance.Location = new System.Drawing.Point(457, 160);
            this.btnManageStaffAttendance.Name = "btnManageStaffAttendance";
            this.btnManageStaffAttendance.Size = new System.Drawing.Size(209, 42);
            this.btnManageStaffAttendance.TabIndex = 7;
            this.btnManageStaffAttendance.Text = "Staff Attendance";
            this.btnManageStaffAttendance.UseVisualStyleBackColor = true;
            this.btnManageStaffAttendance.Click += new System.EventHandler(this.btnManageStaffAttendance_Click);
            // 
            // btnManageLecturerAttendance
            // 
            this.btnManageLecturerAttendance.Location = new System.Drawing.Point(457, 225);
            this.btnManageLecturerAttendance.Name = "btnManageLecturerAttendance";
            this.btnManageLecturerAttendance.Size = new System.Drawing.Size(209, 42);
            this.btnManageLecturerAttendance.TabIndex = 8;
            this.btnManageLecturerAttendance.Text = "Lecture Attendance";
            this.btnManageLecturerAttendance.UseVisualStyleBackColor = true;
            this.btnManageLecturerAttendance.Click += new System.EventHandler(this.btnManageLecturerAttendance_Click);
            // 
            // btnManageLecture
            // 
            this.btnManageLecture.Location = new System.Drawing.Point(46, 159);
            this.btnManageLecture.Name = "btnManageLecture";
            this.btnManageLecture.Size = new System.Drawing.Size(209, 43);
            this.btnManageLecture.TabIndex = 9;
            this.btnManageLecture.Text = "Manage Lecture";
            this.btnManageLecture.UseVisualStyleBackColor = true;
            this.btnManageLecture.Click += new System.EventHandler(this.btnManageLecture_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManageLecture);
            this.Controls.Add(this.btnManageLecturerAttendance);
            this.Controls.Add(this.btnManageStaffAttendance);
            this.Controls.Add(this.btnManageExams);
            this.Controls.Add(this.btnRegisterUser);
            this.Controls.Add(this.btnManageSections);
            this.Controls.Add(this.btnManageSubjects);
            this.Controls.Add(this.btnManageStaff);
            this.Controls.Add(this.btnManageStudents);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageStudents;
        private System.Windows.Forms.Button btnManageStaff;
        private System.Windows.Forms.Button btnManageSubjects;
        private System.Windows.Forms.Button btnManageSections;
        private System.Windows.Forms.Button btnRegisterUser;
        private System.Windows.Forms.Button btnManageExams;
        private System.Windows.Forms.Button btnManageStaffAttendance;
        private System.Windows.Forms.Button btnManageLecturerAttendance;
        private System.Windows.Forms.Button btnManageLecture;
    }
}