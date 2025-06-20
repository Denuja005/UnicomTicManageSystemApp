using System;
using System.Windows.Forms;

namespace UnicomTicManageSystemApp
{
    partial class Subject_SectionManageForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtSubject1 = new System.Windows.Forms.TextBox();
            this.cmbSectionSelect = new System.Windows.Forms.ComboBox();
            this.dgvSubjects = new System.Windows.Forms.DataGridView();
            this.btnAddSubjects = new System.Windows.Forms.Button();
            this.btnUpdateSubjects = new System.Windows.Forms.Button();
            this.btnDeleteSubjects = new System.Windows.Forms.Button();
            this.btnViewSubjects = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubject2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Section";
            // 
            // txtSubject1
            // 
            this.txtSubject1.Location = new System.Drawing.Point(112, 61);
            this.txtSubject1.Name = "txtSubject1";
            this.txtSubject1.Size = new System.Drawing.Size(387, 22);
            this.txtSubject1.TabIndex = 2;
            // 
            // cmbSectionSelect
            // 
            this.cmbSectionSelect.FormattingEnabled = true;
            this.cmbSectionSelect.Location = new System.Drawing.Point(112, 21);
            this.cmbSectionSelect.Name = "cmbSectionSelect";
            this.cmbSectionSelect.Size = new System.Drawing.Size(387, 24);
            this.cmbSectionSelect.TabIndex = 3;
            this.cmbSectionSelect.SelectedIndexChanged += new System.EventHandler(this.cmbSectionSelect_SelectedIndexChanged);
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.Location = new System.Drawing.Point(12, 199);
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.RowHeadersWidth = 51;
            this.dgvSubjects.RowTemplate.Height = 24;
            this.dgvSubjects.Size = new System.Drawing.Size(845, 150);
            this.dgvSubjects.TabIndex = 4;
            this.dgvSubjects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubjects_CellContentClick);
            // 
            // btnAddSubjects
            // 
            this.btnAddSubjects.Location = new System.Drawing.Point(406, 145);
            this.btnAddSubjects.Name = "btnAddSubjects";
            this.btnAddSubjects.Size = new System.Drawing.Size(105, 37);
            this.btnAddSubjects.TabIndex = 5;
            this.btnAddSubjects.Text = "ADD";
            this.btnAddSubjects.UseVisualStyleBackColor = true;
            this.btnAddSubjects.Click += new System.EventHandler(this.btnAddSubjects_Click);
            // 
            // btnUpdateSubjects
            // 
            this.btnUpdateSubjects.Location = new System.Drawing.Point(283, 145);
            this.btnUpdateSubjects.Name = "btnUpdateSubjects";
            this.btnUpdateSubjects.Size = new System.Drawing.Size(105, 37);
            this.btnUpdateSubjects.TabIndex = 6;
            this.btnUpdateSubjects.Text = "UPDATE";
            this.btnUpdateSubjects.UseVisualStyleBackColor = true;
            this.btnUpdateSubjects.Click += new System.EventHandler(this.btnUpdateSubjects_Click_1);
            // 
            // btnDeleteSubjects
            // 
            this.btnDeleteSubjects.Location = new System.Drawing.Point(151, 145);
            this.btnDeleteSubjects.Name = "btnDeleteSubjects";
            this.btnDeleteSubjects.Size = new System.Drawing.Size(105, 37);
            this.btnDeleteSubjects.TabIndex = 7;
            this.btnDeleteSubjects.Text = "DELETE";
            this.btnDeleteSubjects.UseVisualStyleBackColor = true;
            // 
            // btnViewSubjects
            // 
            this.btnViewSubjects.Location = new System.Drawing.Point(12, 145);
            this.btnViewSubjects.Name = "btnViewSubjects";
            this.btnViewSubjects.Size = new System.Drawing.Size(105, 37);
            this.btnViewSubjects.TabIndex = 8;
            this.btnViewSubjects.Text = "VIEW";
            this.btnViewSubjects.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Subject 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Subject  2";
            // 
            // txtSubject2
            // 
            this.txtSubject2.Location = new System.Drawing.Point(112, 100);
            this.txtSubject2.Name = "txtSubject2";
            this.txtSubject2.Size = new System.Drawing.Size(387, 22);
            this.txtSubject2.TabIndex = 17;
            this.txtSubject2.TextChanged += new System.EventHandler(this.txtSubject2_TextChanged);
            // 
            // Subject_SectionManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 450);
            this.Controls.Add(this.txtSubject2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnViewSubjects);
            this.Controls.Add(this.btnDeleteSubjects);
            this.Controls.Add(this.btnUpdateSubjects);
            this.Controls.Add(this.btnAddSubjects);
            this.Controls.Add(this.dgvSubjects);
            this.Controls.Add(this.cmbSectionSelect);
            this.Controls.Add(this.txtSubject1);
            this.Controls.Add(this.label2);
            this.Name = "Subject_SectionManageForm";
            this.Text = "SubjectManageForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void txtSubject2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSubject1;
        private System.Windows.Forms.ComboBox cmbSectionSelect;
        private System.Windows.Forms.DataGridView dgvSubjects;
        private System.Windows.Forms.Button btnAddSubjects;
        private System.Windows.Forms.Button btnUpdateSubjects;
        private System.Windows.Forms.Button btnDeleteSubjects;
        private System.Windows.Forms.Button btnViewSubjects;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubject2;
    }
}