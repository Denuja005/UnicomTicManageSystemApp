using System;

namespace UnicomTicManageSystemApp
{
    partial class SectionManageForm
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
            this.txtSectionName = new System.Windows.Forms.TextBox();
            this.dgvSections = new System.Windows.Forms.DataGridView();
            this.btnAddSection = new System.Windows.Forms.Button();
            this.btnUpdateSection = new System.Windows.Forms.Button();
            this.btnDeleteSection = new System.Windows.Forms.Button();
            this.btnViewSections = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSections)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Section Name";
            // 
            // txtSectionName
            // 
            this.txtSectionName.Location = new System.Drawing.Point(259, 64);
            this.txtSectionName.Name = "txtSectionName";
            this.txtSectionName.Size = new System.Drawing.Size(327, 22);
            this.txtSectionName.TabIndex = 1;
            this.txtSectionName.TextChanged += new System.EventHandler(this.txtSectionName_TextChanged);
            // 
            // dgvSections
            // 
            this.dgvSections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSections.Location = new System.Drawing.Point(32, 225);
            this.dgvSections.Name = "dgvSections";
            this.dgvSections.RowHeadersWidth = 51;
            this.dgvSections.RowTemplate.Height = 24;
            this.dgvSections.Size = new System.Drawing.Size(715, 168);
            this.dgvSections.TabIndex = 2;
            // 
            // btnAddSection
            // 
            this.btnAddSection.Location = new System.Drawing.Point(583, 139);
            this.btnAddSection.Name = "btnAddSection";
            this.btnAddSection.Size = new System.Drawing.Size(143, 39);
            this.btnAddSection.TabIndex = 3;
            this.btnAddSection.Text = "ADD";
            this.btnAddSection.UseVisualStyleBackColor = true;
            // 
            // btnUpdateSection
            // 
            this.btnUpdateSection.Location = new System.Drawing.Point(412, 139);
            this.btnUpdateSection.Name = "btnUpdateSection";
            this.btnUpdateSection.Size = new System.Drawing.Size(143, 39);
            this.btnUpdateSection.TabIndex = 4;
            this.btnUpdateSection.Text = "UPDATE";
            this.btnUpdateSection.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSection
            // 
            this.btnDeleteSection.Location = new System.Drawing.Point(243, 139);
            this.btnDeleteSection.Name = "btnDeleteSection";
            this.btnDeleteSection.Size = new System.Drawing.Size(143, 39);
            this.btnDeleteSection.TabIndex = 5;
            this.btnDeleteSection.Text = "DELETE";
            this.btnDeleteSection.UseVisualStyleBackColor = true;
            this.btnDeleteSection.Click += new System.EventHandler(this.btnDeleteSection_Click);
            // 
            // btnViewSections
            // 
            this.btnViewSections.Location = new System.Drawing.Point(71, 139);
            this.btnViewSections.Name = "btnViewSections";
            this.btnViewSections.Size = new System.Drawing.Size(143, 39);
            this.btnViewSections.TabIndex = 6;
            this.btnViewSections.Text = "VIEW";
            this.btnViewSections.UseVisualStyleBackColor = true;
            // 
            // SectionManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnViewSections);
            this.Controls.Add(this.btnDeleteSection);
            this.Controls.Add(this.btnUpdateSection);
            this.Controls.Add(this.btnAddSection);
            this.Controls.Add(this.dgvSections);
            this.Controls.Add(this.txtSectionName);
            this.Controls.Add(this.label1);
            this.Name = "SectionManageForm";
            this.Text = "SectionManageForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSections)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void txtSectionName_TextChanged(object sender, EventArgs e)
        {
            
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSectionName;
        private System.Windows.Forms.DataGridView dgvSections;
        private System.Windows.Forms.Button btnAddSection;
        private System.Windows.Forms.Button btnUpdateSection;
        private System.Windows.Forms.Button btnDeleteSection;
        private System.Windows.Forms.Button btnViewSections;
    }
}