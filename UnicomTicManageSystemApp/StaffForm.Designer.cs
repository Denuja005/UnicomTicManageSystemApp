namespace UnicomTicManageSystemApp
{
    partial class StaffForm
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
            this.btnManageTimetable = new System.Windows.Forms.Button();
            this.btnRoom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageTimetable
            // 
            this.btnManageTimetable.Location = new System.Drawing.Point(116, 183);
            this.btnManageTimetable.Name = "btnManageTimetable";
            this.btnManageTimetable.Size = new System.Drawing.Size(500, 42);
            this.btnManageTimetable.TabIndex = 7;
            this.btnManageTimetable.Text = "Manage Timetable";
            this.btnManageTimetable.UseVisualStyleBackColor = true;
            this.btnManageTimetable.Click += new System.EventHandler(this.btnManageTimetable_Click);
            // 
            // btnRoom
            // 
            this.btnRoom.Location = new System.Drawing.Point(116, 48);
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.Size = new System.Drawing.Size(500, 42);
            this.btnRoom.TabIndex = 8;
            this.btnRoom.Text = "Manage Room";
            this.btnRoom.UseVisualStyleBackColor = true;
            this.btnRoom.Click += new System.EventHandler(this.btnRoom_Click);
            // 
            // StaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRoom);
            this.Controls.Add(this.btnManageTimetable);
            this.Name = "StaffForm";
            this.Text = "StaffForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageTimetable;
        private System.Windows.Forms.Button btnRoom;
    }
}