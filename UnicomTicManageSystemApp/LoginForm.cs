using System;
using System.Data.SQLite;
using System.Windows.Forms;
using UnicomTicManageSystemApp.Data;
using UnicomTicManageSystemApp.Controllers;
using UnicomTicManageSystemApp.Models;

namespace UnicomTicManageSystemApp
{
    public partial class LoginForm : Form
    {
        private StudentController studentController = new StudentController();
        private StaffController staffController = new StaffController(); // ✅ Added

        public LoginForm()
        {
            InitializeComponent();
            CreateDefaultAdminIfNotExists();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Lecture");
            cmbRole.Items.Add("Student");
            cmbRole.Items.Add("Staff");
            cmbRole.SelectedIndex = 0;
        }

        private void CreateDefaultAdminIfNotExists()
        {
            string username = "admin";
            string password = "admin123";
            string role = "Admin";

            using (var conn = DbCon.GetConnection())
            {
                var checkCmd = new SQLiteCommand("SELECT COUNT(*) FROM Users WHERE Username=@Username AND Role=@Role", conn);
                checkCmd.Parameters.AddWithValue("@Username", username);
                checkCmd.Parameters.AddWithValue("@Role", role);

                long count = (long)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    var insertCmd = new SQLiteCommand("INSERT INTO Users (Username, UserPassword, Role) VALUES (@Username, @UserPassword, @Role)", conn);
                    insertCmd.Parameters.AddWithValue("@Username", username);
                    insertCmd.Parameters.AddWithValue("@UserPassword", password);
                    insertCmd.Parameters.AddWithValue("@Role", role);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            using (var conn = DbCon.GetConnection())
            {
                var cmd = new SQLiteCommand("SELECT UserPassword FROM Users WHERE Username=@Username AND Role=@Role", conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Role", role);

                var storedPassword = cmd.ExecuteScalar() as string;

                if (storedPassword == null || storedPassword != password)
                {
                    MessageBox.Show("Invalid username or password.");
                    return;
                }
            }

            // ✅ Login success - open respective form
            this.Hide();

            if (role == "Admin")
            {
                new AdminForm().Show();
            }
            else if (role == "Lecture")
            {
                new LectureForm().Show();
            }
            else if (role == "Student")
            {
                int studentId = studentController.GetStudentIdByUsername(username);
                if (studentId != -1)
                    new StudentForm(studentId).Show();
                else
                {
                    MessageBox.Show("Student not found.");
                    this.Show();
                }
            }
            else if (role == "Staff")
            {
                int staffId = staffController.GetStaffIdByUsername(username); // ✅ Fix here
                if (staffId != -1)
                    new StaffForm(staffId).Show();
                else
                {
                    MessageBox.Show("Staff not found.");
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Role not recognized.");
                this.Show();
            }
        }
    }
}
