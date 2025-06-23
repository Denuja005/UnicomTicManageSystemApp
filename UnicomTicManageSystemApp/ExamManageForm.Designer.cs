using System;

namespace UnicomTicManageSystemApp
{
    partial class ExamManageForm
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
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.dtpExamDate = new System.Windows.Forms.DateTimePicker();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.btnAddExam = new System.Windows.Forms.Button();
            this.btnUpdateExam = new System.Windows.Forms.Button();
            this.btnDeleteExam = new System.Windows.Forms.Button();
            this.btnViewExams = new System.Windows.Forms.Button();
            this.dgvExams = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExams)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exam Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Exam Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select Subject";
            // 
            // txtExamName
            // 
            this.txtExamName.Location = new System.Drawing.Point(245, 32);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Size = new System.Drawing.Size(311, 22);
            this.txtExamName.TabIndex = 3;
            this.txtExamName.TextChanged += new System.EventHandler(this.txtExamName_TextChanged);
            // 
            // dtpExamDate
            // 
            this.dtpExamDate.Location = new System.Drawing.Point(245, 84);
            this.dtpExamDate.Name = "dtpExamDate";
            this.dtpExamDate.Size = new System.Drawing.Size(311, 22);
            this.dtpExamDate.TabIndex = 4;
            // 
            // cmbSubject
            // 
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(245, 134);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(311, 24);
            this.cmbSubject.TabIndex = 5;
            // 
            // btnAddExam
            // 
            this.btnAddExam.Location = new System.Drawing.Point(572, 205);
            this.btnAddExam.Name = "btnAddExam";
            this.btnAddExam.Size = new System.Drawing.Size(129, 41);
            this.btnAddExam.TabIndex = 6;
            this.btnAddExam.Text = "ADD";
            this.btnAddExam.UseVisualStyleBackColor = true;
            // 
            // btnUpdateExam
            // 
            this.btnUpdateExam.Location = new System.Drawing.Point(412, 205);
            this.btnUpdateExam.Name = "btnUpdateExam";
            this.btnUpdateExam.Size = new System.Drawing.Size(129, 41);
            this.btnUpdateExam.TabIndex = 7;
            this.btnUpdateExam.Text = "UPDATE";
            this.btnUpdateExam.UseVisualStyleBackColor = true;
            this.btnUpdateExam.Click += new System.EventHandler(this.btnUpdateExam_Click_1);
            // 
            // btnDeleteExam
            // 
            this.btnDeleteExam.Location = new System.Drawing.Point(245, 205);
            this.btnDeleteExam.Name = "btnDeleteExam";
            this.btnDeleteExam.Size = new System.Drawing.Size(129, 41);
            this.btnDeleteExam.TabIndex = 8;
            this.btnDeleteExam.Text = "DELETE";
            this.btnDeleteExam.UseVisualStyleBackColor = true;
            // 
            // btnViewExams
            // 
            this.btnViewExams.Location = new System.Drawing.Point(87, 205);
            this.btnViewExams.Name = "btnViewExams";
            this.btnViewExams.Size = new System.Drawing.Size(129, 41);
            this.btnViewExams.TabIndex = 9;
            this.btnViewExams.Text = "VIEW";
            this.btnViewExams.UseVisualStyleBackColor = true;
            // 
            // dgvExams
            // 
            this.dgvExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExams.Location = new System.Drawing.Point(33, 288);
            this.dgvExams.Name = "dgvExams";
            this.dgvExams.RowHeadersWidth = 51;
            this.dgvExams.RowTemplate.Height = 24;
            this.dgvExams.Size = new System.Drawing.Size(706, 150);
            this.dgvExams.TabIndex = 10;
            // 
            // ExamManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvExams);
            this.Controls.Add(this.btnViewExams);
            this.Controls.Add(this.btnDeleteExam);
            this.Controls.Add(this.btnUpdateExam);
            this.Controls.Add(this.btnAddExam);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.dtpExamDate);
            this.Controls.Add(this.txtExamName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ExamManageForm";
            this.Text = "ExamManageForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void txtExamName_TextChanged(object sender, EventArgs e)
        { }
            

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExamName;
        private System.Windows.Forms.DateTimePicker dtpExamDate;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Button btnAddExam;
        private System.Windows.Forms.Button btnUpdateExam;
        private System.Windows.Forms.Button btnDeleteExam;
        private System.Windows.Forms.Button btnViewExams;
        private System.Windows.Forms.DataGridView dgvExams;
    }
}