using System;
using System.Windows.Forms;

namespace UnicomTicManageSystemApp
{
    partial class StudentForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.btnMarks = new System.Windows.Forms.Button();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.btnTimetable = new System.Windows.Forms.Button();
            this.lstSubjects = new System.Windows.Forms.ListBox();
            this.Subjects = new System.Windows.Forms.Label();
            this.btnExams = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Student Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Student City:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Section:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(365, 12);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(295, 22);
            this.txtName.TabIndex = 4;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(365, 65);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(295, 22);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(365, 106);
            this.txtCity.Name = "txtCity";
            this.txtCity.ReadOnly = true;
            this.txtCity.Size = new System.Drawing.Size(295, 22);
            this.txtCity.TabIndex = 6;
            this.txtCity.TextChanged += new System.EventHandler(this.txtCity_TextChanged);
            // 
            // btnMarks
            // 
            this.btnMarks.Location = new System.Drawing.Point(398, 316);
            this.btnMarks.Name = "btnMarks";
            this.btnMarks.Size = new System.Drawing.Size(124, 42);
            this.btnMarks.TabIndex = 0;
            this.btnMarks.Text = "VIEW MARKS";
            this.btnMarks.UseVisualStyleBackColor = true;
            this.btnMarks.Click += new System.EventHandler(this.btnMarks_Click);
            // 
            // cmbSection
            // 
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(365, 159);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(303, 24);
            this.cmbSection.TabIndex = 7;
            this.cmbSection.SelectedIndexChanged += new System.EventHandler(this.cmbSection_SelectedIndexChanged_1);
            // 
            // btnTimetable
            // 
            this.btnTimetable.Location = new System.Drawing.Point(559, 316);
            this.btnTimetable.Name = "btnTimetable";
            this.btnTimetable.Size = new System.Drawing.Size(124, 42);
            this.btnTimetable.TabIndex = 1;
            this.btnTimetable.Text = "VIEW TIMETABLE";
            this.btnTimetable.UseVisualStyleBackColor = true;
            this.btnTimetable.Click += new System.EventHandler(this.btnTimetable_Click);
            // 
            // lstSubjects
            // 
            this.lstSubjects.FormattingEnabled = true;
            this.lstSubjects.ItemHeight = 16;
            this.lstSubjects.Location = new System.Drawing.Point(365, 212);
            this.lstSubjects.Name = "lstSubjects";
            this.lstSubjects.Size = new System.Drawing.Size(120, 84);
            this.lstSubjects.TabIndex = 8;
            this.lstSubjects.SelectedIndexChanged += new System.EventHandler(this.lstSubjects_SelectedIndexChanged);
            // 
            // Subjects
            // 
            this.Subjects.AutoSize = true;
            this.Subjects.Location = new System.Drawing.Point(230, 224);
            this.Subjects.Name = "Subjects";
            this.Subjects.Size = new System.Drawing.Size(59, 16);
            this.Subjects.TabIndex = 9;
            this.Subjects.Text = "Subjects";
            // 
            // btnExams
            // 
            this.btnExams.Location = new System.Drawing.Point(233, 316);
            this.btnExams.Name = "btnExams";
            this.btnExams.Size = new System.Drawing.Size(124, 42);
            this.btnExams.TabIndex = 3;
            this.btnExams.Text = "VIEW EXAMS";
            this.btnExams.UseVisualStyleBackColor = true;
            this.btnExams.Click += new System.EventHandler(this.btnExams_Click);
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(62, 407);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(952, 172);
            this.dgvData.TabIndex = 10;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // sqLiteCommand1
            // 
            this.sqLiteCommand1.CommandText = null;
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 702);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExams);
            this.Controls.Add(this.Subjects);
            this.Controls.Add(this.btnMarks);
            this.Controls.Add(this.btnTimetable);
            this.Controls.Add(this.lstSubjects);
            this.Name = "StudentForm";
            this.Text = "StudentForm";
            this.Load += new System.EventHandler(this.StudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lstSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cmbSection_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnExams_Click(object sender, EventArgs e)
        {
           
        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMarks_Click(object sender, EventArgs e)
        {
         
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panelStudentInfo_Paint(object sender, PaintEventArgs e)
        {
          
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtCity;
        private Button btnMarks;
        private ComboBox cmbSection;
        private Button btnTimetable;
        private ListBox lstSubjects;
        private Label Subjects;
        private Button btnExams;
        private DataGridView dgvData;
        private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
    }
}