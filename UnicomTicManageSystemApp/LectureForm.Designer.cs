using System;

namespace UnicomTicManageSystemApp
{
    partial class LectureForm
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
            this.btnManageStudentAttendance = new System.Windows.Forms.Button();
            this.btnMarkManage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageStudentAttendance
            // 
            this.btnManageStudentAttendance.Location = new System.Drawing.Point(199, 185);
            this.btnManageStudentAttendance.Name = "btnManageStudentAttendance";
            this.btnManageStudentAttendance.Size = new System.Drawing.Size(378, 45);
            this.btnManageStudentAttendance.TabIndex = 10;
            this.btnManageStudentAttendance.Text = "Manage Student Attendance";
            this.btnManageStudentAttendance.UseVisualStyleBackColor = true;
            this.btnManageStudentAttendance.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnMarkManage
            // 
            this.btnMarkManage.Location = new System.Drawing.Point(199, 270);
            this.btnMarkManage.Name = "btnMarkManage";
            this.btnMarkManage.Size = new System.Drawing.Size(378, 45);
            this.btnMarkManage.TabIndex = 11;
            this.btnMarkManage.Text = "Manage Mark";
            this.btnMarkManage.UseVisualStyleBackColor = true;
            this.btnMarkManage.Click += new System.EventHandler(this.button1_Click);
            // 
            // LectureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMarkManage);
            this.Controls.Add(this.btnManageStudentAttendance);
            this.Name = "LectureForm";
            this.Text = "LectureForm";
            this.Load += new System.EventHandler(this.LectureForm_Load);
            this.ResumeLayout(false);

        }

     

     
        

        #endregion

        private System.Windows.Forms.Button btnManageStudentAttendance;
        private System.Windows.Forms.Button btnMarkManage;
    }
}